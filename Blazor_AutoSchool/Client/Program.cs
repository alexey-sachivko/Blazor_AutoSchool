global using Blazor_AutoSchool.Shared;
global using System.Net.Http.Json;
global using Blazor_AutoSchool.Client.Services.EmployeeService;
global using Blazor_AutoSchool.Client.Services.AutoService;
using Blazor_AutoSchool.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAutoService, AutoService>();

await builder.Build().RunAsync();
