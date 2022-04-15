global using Blazor_AutoSchool.Shared;
global using System.Net.Http.Json;
global using Blazor_AutoSchool.Client.Services.EmployeeService;
global using Blazor_AutoSchool.Client.Services.AutoService;
global using Blazor_AutoSchool.Client.Services.AuthService;
global using Blazor_AutoSchool.Client.Services.GroupService;
global using Blazor_AutoSchool.Client.Services.CategoryService;
using Blazor_AutoSchool.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
