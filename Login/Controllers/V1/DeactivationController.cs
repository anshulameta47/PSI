/*
*Module-Name:Deactivation Controller
*Author:Aditya
*Creation-Date:17/10/20
*Synopsis:Module deactivates the user.
*/
using Com.Sapient.Contracts.V1;
using Com.Sapient.Data;
using Com.Sapient.Services;
using Com.Sapient.Services.EmailService;
using Com.Sapient.Services.RedisService;
using Login.Contracts.V1.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Controllers.V1
{
    public class DeactivationController:Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService<SendGridMessage> _emailService;
        private readonly DataContext _dataContext;
        private readonly IRedisService _redisService;

        public DeactivationController(IUserService userService,IEmailService<SendGridMessage>emailService,DataContext dataContext,IRedisService redisService)
        {
            _userService = userService;
            _emailService = emailService;
            _dataContext = dataContext;
            _redisService = redisService;

        }
        [HttpDelete(ApiRoutes.Users.Deactivate)]
        public async Task<IActionResult> Deactivate([FromHeader(Name = "Authorization")] string token, [FromBody] PasswordRequest passwordRequest)
        {
            if (_userService.CheckToken(token))
            {
                token = token.Remove(0, 6).Trim();
                var conn = _redisService.RedisConnection();
                var email = _redisService.ReadData(conn, token);
                var user = _dataContext.UserAccounts.SingleOrDefault(x=>x.Email==email);
                var deactivated = await _userService.DeactivateUser(token, passwordRequest.Password);
                string htmlBody = "Your Account has been deactivated";
                if (deactivated)
                {
                    var msg=_emailService.CreateEmail(to:user, subject:"Account Deactivated",htmlBody:htmlBody);
                    await _emailService.Send(msg);
                    return Ok(); 
                }
                return BadRequest("Incorrect password");
            }

            return BadRequest("First sign in");

        }
       
    }

}
