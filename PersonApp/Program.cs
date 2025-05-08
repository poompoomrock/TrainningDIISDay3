using PersonApp.Client;
using PersonApp.Client.Helpers;
using PersonApp.Client.IServices;
using PersonApp.Client.Pages;
using PersonApp.Client.Services;
using PersonApp.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PersonApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<SingletonService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopeService>();

//builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonService, PersonInMemoryService>();
builder.Services.AddScoped<AuthenticationStateProvider, DummyAuthenticationStateProvider>();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<DbModelContext>(options =>
{
    options.UseNpgsql(conn);
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PersonApp.Client._Imports).Assembly);

app.Run();
