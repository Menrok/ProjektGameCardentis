using Microsoft.EntityFrameworkCore;

namespace ProjektGameCardentis.Entities.Auth;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public Player Player { get; set; } = null!;
}
