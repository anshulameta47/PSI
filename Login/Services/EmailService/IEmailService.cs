using Com.Sapient.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Com.Sapient.Services.EmailService
{
	/// <summary>Interface <c>IEmailService</c> containes the methods
	/// needs to be implemented for sending mail. This can be extended
	/// to any email service.</summary>
	///
	public interface IEmailService<T>
	{
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
		/// <returns>Email Message Object.</returns>
		/// 
		T CreateEmail(UserAccount to, string subject, [Optional] UserAccount cc,
			[Optional] UserAccount bcc, [Optional] string textBody,
			[Optional] string htmlBody, [Optional] EmailAttachment attachment);

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
		/// <returns>Email Message Object.</returns>
		/// 
		T CreateEmailMultipleUsers(IEnumerable<UserAccount> tos, string subject,
			[Optional] UserAccount cc, [Optional] UserAccount bcc, [Optional] string textBody,
			[Optional] string htmlBody, [Optional] EmailAttachment attachment);

		Task<HttpStatusCode> Send(T msg);
	}
}