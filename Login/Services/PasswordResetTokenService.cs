using System;
using System.Threading.Tasks;
using Com.Sapient.Contracts.V1;
using Com.Sapient.Models;
using Com.Sapient.Services.ActivationTokenService;
using Com.Sapient.Services.EmailService;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Mail;

namespace Com.Sapient.Services
{
    public class PasswordResetTokenService : IActivationTokenService
    {
        private readonly IEmailService<SendGridMessage> _emailService;

        public PasswordResetTokenService(IEmailService<SendGridMessage> emailService)
        {
            _emailService = emailService;
        }

        public string GenerateToken(string id)
        {
            var timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var token = timeStamp + id.GetHashCode().ToString();
            return token;
        }

        public async Task SendToken(HttpContext httpContext, UserAccount userAccount, string token)
        {
            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host.ToUriComponent()}";
            var url = $"{baseUrl}/{ApiRoutes.Users.VerifyPasswordResetLink}?userid={userAccount.Email}&token={token}";
            var htmlBody = $"<p>You are activated now!</p>";
            htmlBody += $"<p><a href=\"{url}\">Click Here</a></p>";
            var msg = _emailService.CreateEmail(to: userAccount, subject: "Sign up | Verification", htmlBody: htmlBody);
            await _emailService.Send(msg);
        }

        public async Task SendConfirmationMail(UserAccount userAccount)
        {
            var htmlBody = $"<p>Your password has been changed successfully</p>";
            var msg = _emailService.CreateEmail(to: userAccount, subject: $"Password Reset confirmation", htmlBody: htmlBody);
            await _emailService.Send(msg);
        }
    }
}