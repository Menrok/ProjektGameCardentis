namespace ProjektGameCardentis.Application.DTOs;

public class AuthResult
{
    public bool Success { get; }
    public string Message { get; }

    private AuthResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static AuthResult Ok(string message) => new(true, message);

    public static AuthResult Fail(string message) => new(false, message);
}
