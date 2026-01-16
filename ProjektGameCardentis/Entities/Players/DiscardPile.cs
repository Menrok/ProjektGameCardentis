namespace ProjektGameCardentis.Entities.Players;

public class DiscardPile
{
    public List<Card> Cards { get; set; } = new();

    public int Count => Cards.Count;
}
