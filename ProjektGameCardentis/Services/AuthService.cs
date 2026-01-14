using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Data;
using ProjektGameCardentis.DTOs;
using ProjektGameCardentis.Entities;

namespace ProjektGameCardentis.Services;

public class AuthService
{
    private readonly AppDbContext _db;
    private readonly PasswordHasher<User> _hasher = new();

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AuthResult> Register(RegisterRequest request)
    {
        if (request.Username.Length < 3)
        return AuthResult.Fail("Login musi mieć minimum 3 znaki");

        if (await _db.Users.AnyAsync(u => u.Username == request.Username))
            return AuthResult.Fail("Login jest już zajęty");

        if (await _db.Users.AnyAsync(u => u.Email == request.Email))
            return AuthResult.Fail("Email jest już zajęty");

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
        var user = await _db.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null)
            return AuthResult.Fail("Nieprawidłowy login lub hasło");

        var result = _hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password);

        if (result == PasswordVerificationResult.Failed)
            return AuthResult.Fail("Nieprawidłowy login lub hasło");

        return AuthResult.Ok(user.Username);
    }
}
