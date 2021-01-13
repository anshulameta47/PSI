
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Installers
{
    public class MvcInstallers:IInstaller
    {
        public void installService(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TweetBook API", Version = "v1" });
                });
        }
    }
}
