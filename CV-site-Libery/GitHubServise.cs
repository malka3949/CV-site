using Microsoft.VisualBasic.FileIO;
using Octokit;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Practu5Libery
{
    // מחלקה בשם GitHubService שמיישמת את הממשק IGitHubService
    public class GitHubService : IGitHubService
    {
        // משתנה פרטי מסוג GitHubClient שמיועד לתקשורת עם GitHub
        private readonly GitHubClient _client;

        private readonly GitHubIntegratinOption _options;

        // בנאי של המחלקה שמאתחל את ה-GitHubClient
        public GitHubService(IOptions<GitHubIntegratinOption> options)
        {
            // יצירת אובייקט GitHubClient עם שם המוצר
            _client = new GitHubClient(new ProductHeaderValue("my-github-app"));


            _options = options.Value;
            _client.Credentials = new Credentials(_options.token);

        }

        // פונקציה אסינכרונית שמחזירה את מספר העוקבים של משתמש ב-GitHub
        public async Task<int> GetUserFollowersAsync(string userName)
        {
            // שולח בקשה לקבלת פרטי המשתמש
            var user = await _client.User.Get(userName);
            // מחזיר את מספר העוקבים של המשתמש
            return user.Followers;
        }

        // פונקציה אסינכרונית שמחזירה רשימה של מאגרי נתונים בשפת C#
        public async Task<List<Repository>> SearchRepositoriesInCSharp()
        {
            // יצירת בקשה לחיפוש מאגרי נתונים
            var request = new SearchRepositoriesRequest("repo-name") { Language = Language.CSharp };
            // שולח את הבקשה וממתין לתוצאה
            var result = await _client.Search.SearchRepo(request);
            // מחזיר את רשימת המאגרי נתונים
            return result.Items.ToList();
        }



        public async Task<List<RepositoryInfo>> GetPortfolio()
        {
            var goodrepositories = new List<RepositoryInfo>();
            var repositories = await _client.Repository.GetAllForUser(_options.username);
            List<string> allanguage = new List<string>();
            foreach (var repo in repositories)
            {

                var commits = await _client.Repository.Commit.GetAll(_options.username, repo.Name);
                var lastgitCommit = commits.FirstOrDefault();
                var languages = await _client.Repository.GetAllLanguages(_options.username, repo.Name);
                var languagesList = new List<string>();

                foreach (var language in languages)
                {
                    languagesList.Add(language.Name); // Assuming language has a Key property
                }
                var pullRequests = await _client.PullRequest.GetAllForRepository(_options.username, repo.Name);

                var repoInfo = new RepositoryInfo
                {
                    Name = repo.Name,
                    Url = repo.HtmlUrl,
                    Stars = (int)repo.StargazersCount,
                    Languages = languagesList,
                    //LastCommit = lastCommit,
                    LastCommit = lastgitCommit.Commit.Author.Date,
                    PullRequests = pullRequests.Count(),
                };

                goodrepositories.Add(repoInfo);
            }

            return goodrepositories;
        }
        //לא צריך
        public async Task<IEnumerable<Repository>> GetRepositoriesForUser()
        {
            var repositories = await _client.Repository.GetAllForUser(_options.username);
            return repositories;
        }
        public async Task<List<string>> Getrepositorybyparams(string? username, string? repositoryname, string? language)
        {
            List<string> repositoryInfos = new List<string>();

            var allRepositories = await _client.Repository.GetAllForCurrent();
            if (username != null)
            {
                allRepositories = await _client.Repository.GetAllForUser(username);
            }
            if (repositoryname != null)
            {
                allRepositories = allRepositories.Where(r => r.Name == repositoryname).ToList();
            }
            foreach (var repo in allRepositories)
            {
                bool flag = false;
                var languages = await _client.Repository.GetAllLanguages(repo.Owner.Login, repo.Name);
                if (language != null)
                {
                    foreach (var l in languages)
                    {

                        if (l.Name == language)
                            flag = true;
                    }


                    if (flag == true)
                    { repositoryInfos.Add(repo.Name); }
                }
                else
                    repositoryInfos.Add(repo.Name);

            }
            return repositoryInfos;

        }

        public async Task<IEnumerable<Repository>> GetAllRepositories()
        {
            var allRepositories = await _client.Repository.GetAllForCurrent();
            return allRepositories;
        }


        public async Task<IEnumerable<Activity>> getAllActivities()


        {

           // var events = await _client.Activity.Events.GetAllForRepository("owner", "repo");
            //var orgEvents = await _client.Activity.Events.GetAllForOrganization("organization");
            //var repoEvents = await _client.Activity.Events.GetAllForRepository("owner", "repo");


            var AllActivity = await _client.Activity.Events.GetAllUserPerformed(_options.username);
            return AllActivity.ToList();
        }

    }
}






