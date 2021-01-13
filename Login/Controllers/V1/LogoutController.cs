using Com.Sapient.Contracts.V1;
using Com.Sapient.Services;
using Login.Contracts.V1.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Com.Sapient.Controllers.V1
{
    public class LogoutController:Controller
    {
        private readonly IUserService _userService;
        public LogoutController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpDelete(ApiRoutes.Users.Logout)]
        public IActionResult Logout([FromHeader(Name = "Authorization")] string header)
        {
            string token = header.Remove(0, 6);
            token = token.Trim();
            _userService.Logout(token);
            return Ok("you have been successfully logout");
        }
        
    }
}
