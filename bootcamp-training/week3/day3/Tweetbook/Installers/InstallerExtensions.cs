using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration Configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
             typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();


            installers.ForEach(installer => installer.installService(services, Configuration));

        }
    }
}
