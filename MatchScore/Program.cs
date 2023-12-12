using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MatchScore.Services;
using MatchScore;
using Microsoft.AspNetCore.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<FootballApiService>(client =>
{
    client.BaseAddress = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures");
    client.DefaultRequestHeaders.Add("x-rapidapi-key", "d2873b99a4msh55a63eeb1169758p13c37djsnc25655bf0322");
    client.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
});



builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await builder.Build().RunAsync();
