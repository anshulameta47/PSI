using Microsoft.AspNetCore.Identity;
using OpenXmlPowerTools.HtmlToWml.CSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly FacebookAuthService _facebookAuthService;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityService(FacebookAuthService facebookAuthService, UserManager<IdentityUser> userManager)
        {
            _facebookAuthService = facebookAuthService;
            _userManager = userManager;
        }

       

       
        public async Task<AuthenticationResult> LoginWithFacebookAsync(string accessToken)
        {
            var ValidatedTokenResult = await _facebookAuthService.ValidateAccessTokenAsync(accessToken);
            
            if(!ValidatedTokenResult.Data.IsValid)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"Invalid Facebook Token"}
                };

            }

            var userInfo = await _facebookAuthService.GetUserInfoAsync(accessToken);
            
            if(userInfo.Email.Equals("anshulameta@gmail.com))
            {
                return new AuthenticationResult { success=true };

            }
            return new AuthenticationResult
            {
                success = false
            };
        }

       
    }
}
