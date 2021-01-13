using Com.Sapient.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Com.Sapient.Services.ActivationTokenService
{
    public interface IActivationTokenService
    {
        string GenerateToken(string Id);
        Task SendToken(HttpContext httpContext, UserAccount userAccount, string token);
        Task SendConfirmationMail(UserAccount userAccount);
    }
}
