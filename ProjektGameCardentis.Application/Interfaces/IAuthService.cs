using ProjektGameCardentis.Application.DTOs;

namespace ProjektGameCardentis.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResult> Register(RegisterRequest request);
    Task<AuthResult> Login(LoginRequest request);
    void Logout();
}
