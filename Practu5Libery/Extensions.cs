using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practu5Libery
{
    public   static class Extensions
    {
        public static void addGitHubIntegratinOption(this IServiceCollection service ,Action<GitHubIntegratinOption> configuration)
        {
            service.Configure(configuration);
            service.AddScoped<IGitHubService, GitHubService>();
        }
    }
}
