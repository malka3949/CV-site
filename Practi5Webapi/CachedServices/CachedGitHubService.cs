using Microsoft.Extensions.Caching.Memory;
using Octokit;
using Practu5Libery;
namespace Practi5Webapi.CachedServices
{
    public class CachedGitHubService : IGitHubService
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMemoryCache _memoryCache;
        private object? Portfolio;
        public const string UserPortfoliokey = "UserPortfoliokey";
        public  CachedGitHubService(IGitHubService gitHubService, IMemoryCache memoryCache) {
            _gitHubService= gitHubService;
            _memoryCache= memoryCache;
        }

        public Task<IEnumerable<Repository>> GetAllRepositories()
        {
           return  _gitHubService.GetAllRepositories();
        }

        public async Task<List<RepositoryInfo>> GetPortfolio()
        {

            if (_memoryCache.TryGetValue(UserPortfoliokey, out List<RepositoryInfo> repositoryInfos))
                return repositoryInfos;

            var ChcheOption = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
            .SetSlidingExpiration(TimeSpan.FromSeconds(10));


            repositoryInfos=await _gitHubService.GetPortfolio();
            _memoryCache.Set(UserPortfoliokey, repositoryInfos, ChcheOption);

            return repositoryInfos;




        }

        public Task<IEnumerable<Repository>> GetRepositoriesForUser()
        {
            return _gitHubService.GetRepositoriesForUser();    }

        public Task<List<string>> Getrepositorybyparams(string? username, string? repositoryname, string? language)
        {
           return _gitHubService.Getrepositorybyparams(username, repositoryname, language);
        }

        public Task<int> GetUserFollowersAsync(string userName)
        {
           return _gitHubService.GetUserFollowersAsync(userName);   
        }

        public Task<List<Repository>> SearchRepositoriesInCSharp()
        {
               return _gitHubService.SearchRepositoriesInCSharp(); 
                }

        public Task<IEnumerable<Activity>> getAllActivities()
        {
            return _gitHubService.getAllActivities();
        }

    }
}

