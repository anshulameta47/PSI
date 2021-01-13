using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Options;
using Tweetbook.Services;

namespace Tweetbook.Installers
{
    public class FacebookAuthInstaller : IInstaller
    {
        public void installService(IServiceCollection services, IConfiguration Configuration)
        {
            var facebookAuthSettings = new FacebookAuthSettings();
            Configuration.Bind(nameof(FacebookAuthSettings), facebookAuthSettings);
            services.AddSingleton(facebookAuthSettings);

            services.AddHttpClient();
            services.AddSingleton<IFacebookAuthService, FacebookAuthService>();
        }
    }
}
