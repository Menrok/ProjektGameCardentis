namespace ProjektGameCardentis.Entities.Player;

public class Deck
{
    public List<Card> Cards { get; set; } = new();

    private static readonly Random _rng = new();

    public void Shuffle()
    {
        for (int i = Cards.Count - 1; i > 0; i--)
        {
            int j = _rng.Next(i + 1);
            (Cards[i], Cards[j]) = (Cards[j], Cards[i]);
        }
    }

    public Card? DrawRandom()
    {
        if (Cards.Count == 0)
            return null;

        int index = _rng.Next(Cards.Count);
        var card = Cards[index];
        Cards.RemoveAt(index);
        return card;
    }
}
