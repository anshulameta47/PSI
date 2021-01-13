using Com.Sapient.Contracts.V1;
using Com.Sapient.Models;
using Com.Sapient.Services.EmailService;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Com.Sapient.Services.ActivationTokenService
{
    public class ActivationTokenService : IActivationTokenService
    {

        private readonly IEmailService<SendGridMessage> _emailService;
        

        public ActivationTokenService(IEmailService<SendGridMessage> emailService)
        {
            _emailService = emailService;
        }
        public ActivationTokenService()
        {
        }
        //Generates Token for authentication
        public string GenerateToken(string Id)
        {
            long timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            string token = timeStamp.ToString() + Id.GetHashCode().ToString();
            return token;
        }
        public async Task SendToken(HttpContext httpContext, UserAccount userAccount, string token)
        {
           
            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host.ToUriComponent()}";
            string url = $"{baseUrl}/{ApiRoutes.Users.ConfirmEmail}?userid={userAccount.Email}&token={token}";
            string htmlBody = $"<p>You are activated now!</p>";
            htmlBody += $"<p><a href=\"{url}\">Click Here</a></p>";
            var msg = _emailService.CreateEmail(to: userAccount, subject: "Sign up | Verification", htmlBody: htmlBody);
            await _emailService.Send(msg);
        }
        public async Task SendConfirmationMail(UserAccount userAccount)
        {
            string htmlBody = $"<p>Your email has been confirmed successfully</p>";
            var msg = _emailService.CreateEmail(to: userAccount, subject: "Registraton confirmation", htmlBody: htmlBody);
            await _emailService.Send(msg);
        }
    }
}
