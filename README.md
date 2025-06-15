Dynamic Resume with GitHub Integration (ASP.NET Core)
This project is a personal resume website built with C# and ASP.NET Core that connects to your GitHub account and dynamically displays your repositories using live GitHub API data.

🔥 Features
✅ Connects to GitHub using GitHub REST API v3
⭐ Displays star count for each repository
🍴 Shows fork count
🗓️ Shows repository creation date
📝 Displays repository description and primary language
🔍 Filter or sort repositories by language, stars, or creation date (extensible)
⚡ Caches API responses in memory for 10 minutes to reduce API calls
💻 Built with ASP.NET Core (.NET 6/7) and C#
🧰 Tech Stack
ASP.NET Core Razor Pages
C#
GitHub REST API
IMemoryCache (System.Runtime.Caching)
Bootstrap or Tailwind CSS (optional for UI)
🏁 Getting Started
1. Clone the repository
git clone https://github.com/miriam40421/CV-site.git
cd Cv-site
2. Generate a GitHub Personal Access Token
Go to:
GitHub → Settings → Developer Settings → Personal Access Tokens
Generate a token with repo (read-only) scope.

3. Configure your settings
Create or edit the appsettings.json file:

{
  "GitHub": {
    "Username": "your-github-username",
    "Token": "your-personal-access-token"
  }
}
🔐 Never commit your token to a public repository!

4. Run the project
dotnet run
5. Open the website in your browser
Visit:

https://localhost:5001
Or the URL displayed in the console after the app starts.

🎯 Roadmap (Planned Features)
 Search by repository name
 Sort dropdown (stars, forks, creation date)
 Filter by language
 GitHub profile summary (e.g., total stars, top languages)
 Redis or distributed cache support
📃 License
MIT License

🚀 This project is perfect for showcasing your GitHub contributions in a professional and dynamic format.
It’s easily extendable to support portfolio items, blog posts, or additional profile content.

About
No description, website, or topics provided.
Resources
 Readme
 Activity
Stars
 0 stars
Watchers
 0 watching
Forks
 0 forks
Report repository
Releases
No releases published
Packages
No packages published
Languages
C#
100.0%
Footer
