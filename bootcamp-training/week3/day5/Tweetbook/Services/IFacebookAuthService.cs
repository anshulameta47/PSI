using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.External.Contracts;

namespace Tweetbook.Services
{
    interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);

        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
      
    }
}
