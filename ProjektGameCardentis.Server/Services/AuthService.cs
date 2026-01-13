using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Application.DTOs;
using ProjektGameCardentis.Application.Interfaces;
using ProjektGameCardentis.Domain.Entities;
using ProjektGameCardentis.Infrastructure.Data;

namespace ProjektGameCardentis.Server.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly AuthState _authState;
    private readonly PasswordHasher<User> _hasher = new();

    public AuthService(AppDbContext db, AuthState authState)
    {
        _db = db;
        _authState = authState;
    }

    public async Task<AuthResult> Register(RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return AuthResult.Fail("Login jest wymagany");

        if (string.IsNullOrWhiteSpace(request.Email))
            return AuthResult.Fail("Email jest wymagany");

        if (string.IsNullOrWhiteSpace(request.Password))
            return AuthResult.Fail("Hasło jest wymagane");

        if (request.Password.Length < 6)
            return AuthResult.Fail("Hasło musi mieć min. 6 znaków");

        if (await _db.Users.AnyAsync(u => u.Username == request.Username))
            return AuthResult.Fail("Login już istnieje");

        if (await _db.Users.AnyAsync(u => u.Email == request.Email))
            return AuthResult.Fail("Email już istnieje");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        user.PasswordHash = _hasher.HashPassword(user, request.Password);

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return AuthResult.Ok("Rejestracja zakończona sukcesem");
    }

    public async Task<AuthResult> Login(LoginRequest request)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null)
            return AuthResult.Fail("Nieprawidłowy login lub hasło");

        var result = _hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password);

        if (result == PasswordVerificationResult.Failed)
            return AuthResult.Fail("Nieprawidłowy login lub hasło");

        _authState.Login(user.Username);

        return AuthResult.Ok("Zalogowano");
    }

    public void Logout()
    {
        _authState.Logout();
    }
}
