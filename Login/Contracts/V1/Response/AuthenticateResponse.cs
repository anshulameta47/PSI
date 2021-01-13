using Com.Sapient.Models;
namespace Login.Contracts.V1.Response
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public AuthenticateResponse(string token)
        {
            Token = token;
        }
    }
}
