using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Subscriptions.Web;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var subscriptionsApi = builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213") });
builder.Services.AddScoped<SubscriptionService>();

await builder.Build().RunAsync();
