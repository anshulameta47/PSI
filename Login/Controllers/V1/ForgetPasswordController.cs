using System;
using System.Collections.Generic;
using Com.Sapient.Contracts.V1;
using Com.Sapient.Contracts.V1.Requests;
using Com.Sapient.Services;
using Microsoft.AspNetCore.Mvc;
using Com.Sapient.Services.RedisService;
using Com.Sapient.Services.EmailService;
using Login.Contracts.V1.Requests;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Com.Sapient.Controllers.V1
{
    [ApiController]
    public class ForgetPasswordController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRedisService _redisService;
        private readonly IEmailService<SendGridMessage> _emailService;

        public ForgetPasswordController(IUserService userService, IRedisService redisService, IEmailService<SendGridMessage> emailService)
        {
            _userService = userService;
            _redisService = redisService;
            _emailService = emailService;
        }

        [HttpGet(ApiRoutes.Users.GetFavouriteQuestions + "/{email}")]
        public IActionResult GetFavouriteQuestions([FromRoute] string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
                return NotFound();

            var sqList = _userService.GetSecurityQuestionsOfUser(user.Id) ?? throw new ArgumentNullException(nameof(email));

            return Ok(sqList);
        }
        [HttpPost(ApiRoutes.Users.GetResetPassword)]
        public IActionResult AreDetailsCorrect([FromRoute] long userId, [FromBody] List<UserAnswerBody> answersFromUser)
        {
            var areDetailsOfSqCorrect = _userService.AreDetailsCorrect(userId, answersFromUser);
            if (areDetailsOfSqCorrect)
                return Ok();
            return BadRequest("given answers are not correct");
        }

        [HttpPost(ApiRoutes.Users.GetOtpPage)]
        public async Task<IActionResult> GetOtp([FromBody] EmailRequest emailRequest)
        {
            var user = _userService.GetByEmail(emailRequest.Email);
            if (user == null)
                return BadRequest("user is not exists");
            Random randomOtp = new Random();
            var otp = randomOtp.Next(10000, 99999).ToString();
            var conn = _redisService.RedisConnection();
            string htmlBody = $"your otp for reset password: {otp}";
            _redisService.InsertData(conn, emailRequest.Email, otp);
            var msg = _emailService.CreateEmail(to: user, subject: "OTP for reset password", htmlBody: htmlBody);
            await _emailService.Send(msg);
            return Ok();
        }

        [HttpPost(ApiRoutes.Users.VerifyOtpPage)]
        public IActionResult VerifyOtp([FromBody] OtpVerificationRequest otpRequest)
        {
            var user =  _userService.GetByEmail(otpRequest.Email);
            if (user == null)
                return BadRequest("user is not exists");
            var conn = _redisService.RedisConnection();
            var otpExpected =_redisService.ReadData(conn, otpRequest.Email);
            

            if (otpRequest!=null && otpExpected.Equals(otpRequest.Otp))
            {
                _redisService.DeleteData(conn, otpRequest.Email);
                return Ok();
            }
            else 
                return BadRequest("Please try again.");
           
        }


    }
}

