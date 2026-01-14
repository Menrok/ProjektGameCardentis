namespace ProjektGameCardentis.DTOs;

public class AuthResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public static AuthResult Ok(string message) => new() { Success = true, Message = message };

    public static AuthResult Fail(string message) => new() { Success = false, Message = message };
}
