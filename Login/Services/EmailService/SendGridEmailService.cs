using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Com.Sapient.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Com.Sapient.Services.EmailService
{
	/// <summary>Class <c>SendGridService</c> implements the
	/// IEmailService.</summary>
	///
	public class SendGridEmailService : IEmailService<SendGridMessage>
	{
		/// <summary>Property <c>ApiKey</c> represents the API Key
		/// reuired to the send the mails using the Sendgrid.</summary>
		private string ApiKey { get; }
		/// <summary>Instance Constant <c>FromEmail</c> represents the email id
		/// with which will be ssent.</summary>
		private const string FromEmail = "sagbansa@publicisgroupe.net";
		/// <summary>Instance Constant <c>FromName</c> represents the name
		/// with which will be ssent.</summary>
		private const string FromName = "PS ASDE Batch-2 Training";

		public SendGridEmailService() { }
		public SendGridEmailService(IConfiguration configuration)
		{
			ApiKey = configuration.GetSection("SENDGRID_API_KEY").Value;
		}

		/// <summary>method <c>CreateEmail</c> Creates a SendGrid Email Message 
		/// which can be sent to the one user.</summary>
		/// <param name="to">UserAccount to which you want to sent the email.</param>
		/// <param name="subject">Subject of the email.</param>
		/// <param name="cc">UserAccount you want to add as CC [optional].</param>
		/// <param name="bcc">UserAccount you want to add as BCC [optional].</param>
		/// <param name="textBody">Text Body of the Email [optional].</param>
		/// <param name="htmlBody">HTML Body of the Email [optional]. It has the
		/// high priority if both textBody and htmlbody are provided.</param>
		/// <param name="attachment">Attatchment you can want to add the email [optional].</param>
		/// <returns>SendGridMessage Object, which will be needed to send the email.</returns>
		/// 
		public SendGridMessage CreateEmail(UserAccount to, string subject,
			UserAccount cc = null, UserAccount bcc = null, string textBody = null,
			string htmlBody = null, EmailAttachment attachment = null)
		{
			var from = new EmailAddress(FromEmail , FromName);
			var toEmail = new EmailAddress(to.Email, to.FullName());
			var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, textBody, htmlBody);
			if (cc != null)
			{
				msg.AddCc(new EmailAddress(cc.Email, cc.FullName()));
			}
			if (bcc != null)
			{
				msg.AddBcc(new EmailAddress(bcc.Email, bcc.FullName()));
			}
			if (attachment != null)
			{
				var banner = new Attachment()
				{
					Content = Convert.ToBase64String(attachment.Content),
					Type = attachment.Type,
					Filename = attachment.Filename,
					Disposition = attachment.Disposition,
					ContentId = attachment.ContentId
				};

				msg.AddAttachment(banner);
			}
			return msg;
		}

		/// <summary>method <c>CreateEmailMultipleUsers</c> Creates a SendGrid Email Message 
		/// which can be sent to the list of the user.</summary>
		/// <param name="tos">List of UserAccounts to which you want to sent the email.</param>
		/// <param name="subject">Subject of the email.</param>
		/// <param name="cc">UserAccount you want to add as CC [optional].</param>
		/// <param name="bcc">UserAccount you want to add as BCC [optional].</param>
		/// <param name="textBody">Text Body of the Email [optional].</param>
		/// <param name="htmlBody">HTML Body of the Email [optional]. It has the
		/// high priority if both textBody and htmlbody are provided.</param>
		/// <param name="attachment">Attatchment you can want to add the email [optional].</param>
		/// <returns>SendGridMessage Object, which will be needed to send the email.</returns>
		/// 
		public SendGridMessage CreateEmailMultipleUsers(IEnumerable<UserAccount> tos, string subject, UserAccount cc = null, UserAccount bcc = null,
			string textBody = null, string htmlBody = null, EmailAttachment attachment = null)
		{
			var from = new EmailAddress(FromEmail, FromName);
			var toEmails = tos.Select(to => new EmailAddress(to.Email, to.FullName())).ToList();
			var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, toEmails, subject, textBody, htmlBody);
			if (cc != null)
			{
				msg.AddCc(new EmailAddress(cc.Email, cc.FullName()));
			}
			if (bcc != null)
			{
				msg.AddBcc(new EmailAddress(bcc.Email, bcc.FullName()));
			}
			if (attachment != null)
			{
				var banner = new Attachment()
				{
					Content = Convert.ToBase64String(attachment.Content),
					Type = attachment.Type,
					Filename = attachment.Filename,
					Disposition = attachment.Disposition,
					ContentId = attachment.ContentId
				};

				msg.AddAttachment(banner);
			}

			return msg;
		}

		/// <summary>method <c>Send</c> Sends the SendGrid Email Message.</summary>
		/// <param name="msg">SendGridMesaage Object.</param>
		/// <returns>HttpStatusCode, the status code of the response from the SendGrid server.</returns>
		/// 
		public async Task<HttpStatusCode> Send(SendGridMessage msg)
		{
			var client = new SendGridClient(ApiKey);
			var response = await client.SendEmailAsync(msg);
			return response.StatusCode;
		}
	}
}