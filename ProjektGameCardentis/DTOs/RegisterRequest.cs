using System.ComponentModel.DataAnnotations;

namespace ProjektGameCardentis.DTOs;

public class RegisterRequest
{
    [Required(ErrorMessage = "Login jest wymagany")]
    [MinLength(3, ErrorMessage = "Login musi mieć minimum 3 znaki")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email jest wymagany")]
    [EmailAddress(ErrorMessage = "Nieprawidłowy format email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Hasło jest wymagane")]
    [MinLength(6, ErrorMessage = "Hasło musi mieć minimum 6 znaków")]
    public string Password { get; set; } = string.Empty;
}
