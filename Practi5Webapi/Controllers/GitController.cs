using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using Practu5Libery;

namespace Practi5Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitController : ControllerBase
    {

        public readonly IGitHubService _gitHubService;
        public GitController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }
        [HttpGet]

        public async Task<int> Getccc(string username)
        {
            return await _gitHubService.GetUserFollowersAsync(username);

        }
        [HttpGet("/SearchRepositoriesInCSharp")]
        public async Task<List<Repository>> SearchRepositoriesInCSharp()
        {
            return await _gitHubService.SearchRepositoriesInCSharp();

        }
        //[HttpGet("GetPortfolio")]

        //public async Task<RepositoryInfo> GetPortfolio(string usernam)
        //{
        //    return await _gitHubService.GetPortfolio(usernam);
        //}
        [HttpGet("GetSinglePortfolio")]
        public async Task<RepositoryInfo[]> GetAllPortfolios()
        {
            var portfolios = await _gitHubService.GetPortfolio();
            return portfolios.ToArray(); // מחזיר את כל המערך
        }
        [HttpGet("getAllRepository1")]
        public async Task<IEnumerable<Repository>> GetRepositoriesForUser()
        {
            var portfolios = await _gitHubService.GetRepositoriesForUser();
            return portfolios.ToArray();
        }

        [HttpGet("getAllRepository2")]

        public async Task<IEnumerable<Repository>> GetAllRepositories()
        {
            var portfolios = await _gitHubService.GetAllRepositories();
            return portfolios.ToArray();
        }

        [HttpGet("getByParameters")]

        //public async Task<IEnumerable<Repository>> GetAllRepositories(string? username, string? repositoryname, string? language)
        //{
        //    var portfolios = await _gitHubService.GetAllRepositories();
        //    return portfolios.ToArray();
        //}
        public async Task<List<string>> Getrepositorybyparams(string? username, string? repositoryname, string? language)
        {
            var result = await _gitHubService.Getrepositorybyparams( username, repositoryname,  language);
            return result.ToList();
        }

        [HttpGet("getAllActivities")]

        public async Task<IEnumerable<Activity>> getAllActivities()
        {
            var result = await _gitHubService.getAllActivities();
            return result;
        }

    }
}
