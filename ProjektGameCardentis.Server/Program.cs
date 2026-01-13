using ProjektGameCardentis.Server.Components;
using ProjektGameCardentis.Application.Interfaces;
using ProjektGameCardentis.Application.Services;
using ProjektGameCardentis.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<AuthState>();

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
