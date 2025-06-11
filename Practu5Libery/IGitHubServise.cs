using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
namespace Practu5Libery
{


    public interface IGitHubService
    {
        Task<int> GetUserFollowersAsync(string userName);
        Task<List<Repository>> SearchRepositoriesInCSharp();
         Task<List<RepositoryInfo>> GetPortfolio();

        Task<List<string>> Getrepositorybyparams(string? username, string? repositoryname, string? language);
        Task<IEnumerable<Repository>> GetAllRepositories();
        //לא צריך
        Task<IEnumerable<Repository>> GetRepositoriesForUser();

        Task<IEnumerable<Activity>> getAllActivities();


    }
    //Task<IEnumerable<Repository>> GetRepositoriesForUser();


}



