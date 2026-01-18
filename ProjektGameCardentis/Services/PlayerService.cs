using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Data;

namespace ProjektGameCardentis.Services;

public class PlayerService
{
    private readonly AppDbContext _db;
    private readonly AuthState _auth;

    public PlayerService(AppDbContext db, AuthState auth)
    {
        _db = db;
        _auth = auth;
    }

    public async Task<Player?> GetCurrentPlayer()
    {
        if (!_auth.IsAuthenticated || string.IsNullOrEmpty(_auth.Username))
            return null;

        return await _db.Players.AsNoTracking().Include(p => p.Deck).ThenInclude(d => d.Cards).FirstOrDefaultAsync(p => p.Username == _auth.Username);
    }
}
