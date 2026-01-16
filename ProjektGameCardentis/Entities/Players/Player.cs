namespace ProjektGameCardentis.Entities.Players;

public class Player
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Username { get; set; } = null!;

    public Deck Deck { get; set; } = new();
}
