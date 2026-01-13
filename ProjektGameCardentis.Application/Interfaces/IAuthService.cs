using ProjektGameCardentis.Application.DTOs;

namespace ProjektGameCardentis.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResult Register(string username, string password);
        AuthResult Login(string username, string password);
        void Logout();
        bool IsAuthenticated { get; }
        string? CurrentUser { get; }
    }
}
