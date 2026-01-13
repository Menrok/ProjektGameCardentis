using ProjektGameCardentis.Server.Components;
using ProjektGameCardentis.Application.Interfaces;
using ProjektGameCardentis.Server.Services;
using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddScoped<AuthState>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=cardentis.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
