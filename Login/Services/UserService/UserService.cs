using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Com.Sapient.Contracts.V1.Requests;
using Com.Sapient.Data;
using Com.Sapient.Helpers;
using Com.Sapient.Models;
using Com.Sapient.Services.EmailService;
using Com.Sapient.Services.RedisService;
using Com.Sapient.Utility;
using Login.Contracts.V1.Response;
using Login.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;

namespace Com.Sapient.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly AppSettings _appSettings;
        private readonly IRedisService _redisService;
        private readonly IEmailService<SendGridMessage> _emailservice;

        public UserService(IOptions<AppSettings> appSettings, DataContext dataContext, IRedisService redisService,IEmailService<SendGridMessage> emailService)
        {
            _appSettings = appSettings.Value;
            _dataContext = dataContext;
            _redisService = redisService;
            _emailservice = emailService;
        }

        public bool CheckToken(string token)
        {
            token = token.Remove(0, 6).Trim();
            var conn = _redisService.RedisConnection();
            var emailId = _redisService.ReadData(conn, token);
            return emailId != null;
        }
        public string GetToken(string emailId)
        {
            var conn = _redisService.RedisConnection();
            return _redisService.ReadData(conn, emailId);

        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, out int status)
        {

            var user = _dataContext.UserAccounts.SingleOrDefault(x => x.Email == model.Email);


            // return null if emailId not found
            if (user == null)
            { status = 404;
                return null;
            }

            if (PasswordUtility.AreEqual(model.Password, user.Password))
            {
                var conn = _redisService.RedisConnection();
                var storedToken = _redisService.ReadData(conn, model.Email);
                if (storedToken != null)
                {
                    status = 200;
                    return new AuthenticateResponse(storedToken); }
                // authentication successful so generate jwt token
                var token = GenerateJwtToken(user);
                if (!user.IsActive)
                {
                    user.IsActive = true;
                    _dataContext.SaveChanges();


                    //Send email to user about his reactivation.
                    var htmlmessage = "Your status is now activated.";
                   var msg= _emailservice.CreateEmail(to: user, subject: "Reactivation", htmlBody: htmlmessage);
                    _emailservice.Send(msg);



                }
                //Here Unique Id is user's mail 

                _redisService.InsertData(conn, model.Email, token);
                _redisService.InsertData(conn, token, model.Email);
                status = 200;
                return new AuthenticateResponse(token);
            }
            status = 400;
            return null;


        }
        public SecutityQuestionsOfUser GetSecurityQuestionsOfUser(long userId)
        {
            SecutityQuestionsOfUser securityquestionofuser = new SecutityQuestionsOfUser();
            securityquestionofuser.UserId = userId;
            List<short> mylist = new List<short>();
            foreach (var temp in _dataContext.User_SecurityQuestion_Mappings)
            {
                if (temp.UserAccountId == userId)
                {
                    mylist.Add(temp.SecurityQuestionId);

                }
            }
            securityquestionofuser.SecurityQuestionIdList = mylist;

            return securityquestionofuser;
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            return await _dataContext.UserAccounts.ToListAsync();
        }

        public bool AreDetailsCorrect(long userId, List<UserAnswerBody> answersFromUser)
        {
            UserAnswerBody firstAnswer = answersFromUser[0];
            bool first = false;
            bool second = false;
            UserAnswerBody secondAnswer = answersFromUser[1];
            foreach (var temp in _dataContext.User_SecurityQuestion_Mappings)
            {
                if (temp.UserAccountId == userId)
                {
                    if (temp.SecurityQuestionId == firstAnswer.SecurityQuestionId && temp.Answer == firstAnswer.Answer)
                    {
                        first = true;
                    }

                    if (temp.SecurityQuestionId == secondAnswer.SecurityQuestionId &&
                        temp.Answer == secondAnswer.Answer)
                    {
                        second = true;
                    }
                }
            }

            if (first && second)
                return true;
            return false;
        }
        public UserAccount GetByEmail(string email)
        {
            return _dataContext.UserAccounts.FirstOrDefault(x => x.Email == email);
        }
        public string GenerateJwtToken(UserAccount user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", user.Email) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public void Logout(string token)
        {
            var conn = _redisService.RedisConnection();
            var email = _redisService.ReadData(conn, token);
            _redisService.DeleteData(conn, token);
            _redisService.DeleteData(conn, email);

        }




        public async Task<bool> DeleteUser(string token, string password)
        {
            var conn = _redisService.RedisConnection();
            var email = _redisService.ReadData(conn, token);
            var user = GetByEmail(email);
            if (PasswordUtility.AreEqual(password, user.Password))
            {
                _redisService.DeleteData(conn, token);
                _redisService.DeleteData(conn, email);
                _dataContext.UserAccounts.Remove(user);
                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }
        public async Task<bool> DeactivateUser(string token, string password)
        {
            var conn = _redisService.RedisConnection();
            var email = _redisService.ReadData(conn, token);
            var user = GetByEmail(email);
            if (PasswordUtility.AreEqual(password, user.Password))
            {
                //deletes the token from redis database
                _redisService.DeleteData(conn, token);
                _redisService.DeleteData(conn, email);
                _dataContext.UserAccounts.Remove(user);

                //change active status to false;
                user.IsActive = false;
                _dataContext.UserAccounts.Update(user);
                var updated = await _dataContext.SaveChangesAsync();

                return updated > 0;
            }
            return false;
        }
    }


    }

   
        
    
