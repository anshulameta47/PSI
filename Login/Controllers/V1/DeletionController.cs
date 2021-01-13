/*
*Module-Name:Deletion Controller
*Author:Arnab
*Creation-Date:17/10/20
*Synopsis:Module deletes the user.
*/
using Com.Sapient.Contracts.V1;
using Com.Sapient.Data;
using Com.Sapient.Services;
using Com.Sapient.Services.EmailService;
using Com.Sapient.Services.RedisService;
using Login.Contracts.V1.Requests;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers.V1
{
    public class DeletionController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService<SendGridMessage> _emailService ;
        private readonly IRedisService _redisService;
        private readonly DataContext _dataContext;
        public DeletionController(IUserService userService,IEmailService<SendGridMessage> emailService,DataContext dataContext,IRedisService redisService)
        {
            _userService = userService;
            _emailService = emailService;
            _dataContext = dataContext;
            _redisService = redisService;
        }
        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<IActionResult> Delete([FromHeader(Name = "Authorization")] string token, [FromBody] PasswordRequest passwordRequest)
        {
            if (_userService.CheckToken(token))
            {
                token = token.Remove(0, 6).Trim();
                var conn = _redisService.RedisConnection();
                var email = _redisService.ReadData(conn, token);
                var user = _dataContext.UserAccounts.SingleOrDefault(x => x.Email == email);
                var deleted = await _userService.DeleteUser(token, passwordRequest.Password);
                string htmlBody = "Your Account has been deleted";
                if (deleted)
                {
                    var msg = _emailService.CreateEmail(to: user, subject: "Account Deleted", htmlBody: htmlBody);
                    await _emailService.Send(msg);
                    return Ok();
                }
                    
                return BadRequest("Incorrect password");
            }

            return BadRequest("First sign in");

        }
    }
}
