using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practu5Libery
{
    public class RepositoryInfo
    {

        public string Name { get; set; }
        public  List<string> Languages { get; set; }
        //public Octokit.GitHubCommit LastCommit { get; set; }
        public DateTimeOffset LastCommit { get; set; }

        public int Stars { get; set; }
        public int PullRequests { get; set; }
        public string Url { get; set; }

        //public RepositoryInfo ConverttoRepositoryInfo(Repository repo)
        //{
        //    var repoInfo = new RepositoryInfo
        //    {
        //        Name = repo.Name.ToString(),
        //        Url = repo.HtmlUrl.ToString(),
        //        Stars = (int)repo.StargazersCount,
        //        languages = await _client.Repository.Content.GetAllLanguages(owner, repo.Name);
        //        LastCommit = await GetLastCommit(repo["commits_url"].ToString().Split('{')[0]),
        //        PullRequests = await GetPullRequestCount(repo["pulls_url"].ToString().Split('{')[0])
        //    };
        //    return repoInfo;
        //}
    }
}

