using System.ComponentModel.DataAnnotations;

namespace ProjektGameCardentis.DTOs;

public class LoginRequest
{
    [Required(ErrorMessage = "Login jest wymagany")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Hasło jest wymagane")]
    public string Password { get; set; } = string.Empty;
}
