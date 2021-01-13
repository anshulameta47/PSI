using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Installers
{
    public interface IInstaller
    {
        public void installService(IServiceCollection services, IConfiguration Configuration);
    }
}
