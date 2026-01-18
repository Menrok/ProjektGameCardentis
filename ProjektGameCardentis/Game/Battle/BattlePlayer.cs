namespace ProjektGameCardentis.Game.Battle;

public class BattlePlayer
{
    public Guid PlayerId { get; init; }
    public string Name { get; init; } = "";

    public int Health { get; set; } = 30;

    public int Energy { get; set; } = 2;
    public int MaxEnergy { get; set; } = 6;

    public int ConsecutivePasses { get; set; }

    public Deck Deck { get; init; } = new();
    public Hand Hand { get; init; } = new();
    public DiscardPile DiscardPile { get; init; } = new();

    public int PendingAttack { get; set; }
    public int PendingDefense { get; set; }

    public bool IsAlive => Health > 0;

    public void DrawCard()
    {
        var card = Deck.DrawRandom();
        if (card != null)
            Hand.Cards.Add(card);
    }
}
