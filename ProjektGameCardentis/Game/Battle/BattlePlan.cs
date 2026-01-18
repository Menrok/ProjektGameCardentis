namespace ProjektGameCardentis.Game.Battle;

public class BattlePlan
{
    public Guid PlayerId { get; }
    public IReadOnlyList<Card> Cards { get; }
    public int TotalEnergyCost { get; }
    public bool IsPass => Cards.Count == 0;

    public BattlePlan(Guid playerId, List<Card> cards)
    {
        PlayerId = playerId;
        Cards = cards;
        TotalEnergyCost = cards.Sum(c => c.ManaCost);
    }
}