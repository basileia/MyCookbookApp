using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyCookbook.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

string baseAddress = builder.HostEnvironment.BaseAddress;
string apiBaseUrl;

if (baseAddress.Contains("localhost"))
{
    apiBaseUrl = "https://localhost:7060/"; 
}
else
{
    apiBaseUrl = baseAddress;
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });


builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();
