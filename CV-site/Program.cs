
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.Configure<GitHubIntegratinOption>(builder.Configuration.GetSection(nameof(GitHubIntegratinOption)));
//builder.Services.addGitHubIntegratinOption(options => builder.Configuration.GetSection(nameof(GitHubIntegratinOption)).Bind(options));
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using Practi5Webapi.CachedServices;
using Practu5Libery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<GitHubIntegratinOption>(builder.Configuration.GetSection(nameof(GitHubIntegratinOption)));

//builder.Services.AddOptions<GitHubIntegratinOption>().Bind(builder.Configuration.GetSection(nameof(GitHubIntegratinOption)));
builder.Services.addGitHubIntegratinOption(options => builder.Configuration.GetSection(nameof(GitHubIntegratinOption)).Bind(options));
// var token2 = builder.Configuration[token];
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IGitHubService,GitHubService>();
builder.Services.Decorate<IGitHubService, CachedGitHubService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

