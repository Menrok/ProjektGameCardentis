using ProjektGameCardentis.Application.DTOs;
using ProjektGameCardentis.Application.Interfaces;

namespace ProjektGameCardentis.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly Dictionary<string, string> _users = new();

        public bool IsAuthenticated { get; private set; }
        public string? CurrentUser { get; private set; }

        public AuthResult Register(string username, string password)
        {
            if (_users.ContainsKey(username))
                return new AuthResult { Success = false, Message = "Użytkownik już istnieje." };

            if (password.Length < 4)
                return new AuthResult { Success = false, Message = "Hasło musi mieć co najmniej 4 znaki." };

            _users[username] = password;
            return new AuthResult { Success = true, Message = "Rejestracja zakończona sukcesem." };
        }

        public AuthResult Login(string username, string password)
        {
            if (!_users.TryGetValue(username, out var storedPassword))
                return new AuthResult { Success = false, Message = "Nieprawidłowy login." };

            if (storedPassword != password)
                return new AuthResult { Success = false, Message = "Nieprawidłowe hasło." };

            IsAuthenticated = true;
            CurrentUser = username;

            return new AuthResult { Success = true, Message = "Zalogowano pomyślnie." };
        }

        public void Logout()
        {
            IsAuthenticated = false;
            CurrentUser = null;
        }
    }
}
