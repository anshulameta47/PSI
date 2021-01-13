using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Sapient.Contracts.V1.Requests;
using Com.Sapient.Models;
using Login.Contracts.V1.Response;
using Login.Models;

namespace Com.Sapient.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model,out int status);
        UserAccount GetByEmail(string Email);

        SecutityQuestionsOfUser GetSecurityQuestionsOfUser(long userId);
        Task<IEnumerable<UserAccount>> GetAll();
        bool CheckToken(string token);
        string GetToken(string emailId);
         void Logout(string token);
        // Task<bool> ActivateUser(UserAccount user);
         bool AreDetailsCorrect(long UserId,List<UserAnswerBody> answersFromUser);
        Task<bool> DeleteUser(string token,string password);
        Task<bool> DeactivateUser(string token, string password);
        public string GenerateJwtToken(UserAccount user);
        
    }
}