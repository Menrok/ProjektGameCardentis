namespace ProjektGameCardentis.Services;

public class AuthState
{
    public bool IsAuthenticated { get; private set; }
    public string? Username { get; private set; }

    public void Login(string username)
    {
        IsAuthenticated = true;
        Username = username;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        Username = null;
    }
}
