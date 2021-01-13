/*
*Module-Name:Login Controller
*Author:Aditya, Aditya and Rashmit
*Creation-Date:15/10/20
*Synopsis:Module authenticates the user and also provides functionality of password reset.
*/
using System;
using System.Threading.Tasks;
using Com.Sapient.Contracts.V1;
using Com.Sapient.Contracts.V1.Requests;
using Com.Sapient.Services;
using Com.Sapient.Services.ActivationTokenService;
using Com.Sapient.Services.RedisService;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Com.Sapient.Controllers.V1
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IActivationTokenService _passwordResetTokenService;
        private readonly IRedisService _redisService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IActivationTokenService activationTokenService,
            IRedisService redisService, IConfiguration configuration)
        {
            _userService = userService;
            _redisService = redisService;
            _configuration = configuration;
            _passwordResetTokenService = activationTokenService;
        }

        [HttpPost(ApiRoutes.Users.Authenticate)]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model, out var status);
            return status switch
            {
                400 => BadRequest(new {message = "password is incorrect"}),
                404 => NotFound(),
                _ => Ok(response)
            };
        }

        [Authorize]
        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> GetAll([FromHeader(Name = "Authorization")] string header)
        {
            if (!_userService.CheckToken(header)) return BadRequest("First sign in");
            var users = await _userService.GetAll();
            return Ok(users);

        }

        [HttpPost(ApiRoutes.Users.SendPasswordResetLink)]
        public async Task<IActionResult> SendPasswordResetLink([FromBody] UserEmail userEmail)
        {
            var user = _userService.GetByEmail(userEmail.Email);
            if (user == null)
                return BadRequest("User with email does not exists.");
            var token = _passwordResetTokenService.GenerateToken(user.Email);
            var conn = _redisService.RedisConnection();
            _redisService.InsertData(conn, user.Email, token);
            await _passwordResetTokenService.SendToken(HttpContext, user, token);
            return Ok("Password Reset Link has been sent!");
        }

        [HttpGet(ApiRoutes.Users.VerifyPasswordResetLink)]
        public void VerifyPasswordResetLink([FromQuery]string userId, [FromQuery]string token)
        {
            //Here Unique Id is user's mail 
            var conn = _redisService.RedisConnection();
            //Get the token from Cache
            Console.WriteLine(userId);
            Console.WriteLine(token);
            var tokenFromCache = _redisService.ReadData(conn, userId);
            var tokenMatches = string.Equals(token, tokenFromCache);
            if (tokenMatches)
            {
                Response.Redirect($"{_configuration.GetSection("Frontend_Server").Value}/change-password/{userId}");
                return;
            }
            Response.Redirect($"{_configuration.GetSection("Frontend_Server").Value}/error");
        }
    }
}