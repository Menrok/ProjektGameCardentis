namespace ProjektGameCardentis.Server.Services
{
    public class AuthState
    {
        public bool IsAuthenticated { get; private set; }
        public string? Username { get; private set; }

        public event Action? OnChange;

        public void Login(string username)
        {
            IsAuthenticated = true;
            Username = username;
            NotifyStateChanged();
        }

        public void Logout()
        {
            IsAuthenticated = false;
            Username = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
