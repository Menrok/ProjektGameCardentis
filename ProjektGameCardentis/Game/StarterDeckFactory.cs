namespace ProjektGameCardentis.Game;

public static class StarterDeckFactory
{
public static Deck Create()
{
    var deck = new Deck();

    deck.Cards.AddRange(CreateCard("Precyzyjne Uderzenie", 2, CardType.Attack, CardEffect.DealDamage, 5, "Zadaj 5 obrażeń", 2));
    deck.Cards.AddRange(CreateCard("Silne Uderzenie", 3, CardType.Attack, CardEffect.DealDamage, 7, "Zadaj 7 obrażeń", 1));
    deck.Cards.AddRange(CreateCard("Natarcie", 3, CardType.Attack, CardEffect.DealDamage, 6, "Zadaj 6 obrażeń", 1));
    deck.Cards.AddRange(CreateCard("Lekka Obrona", 1, CardType.Defense, CardEffect.GainDefense, 2, "Zyskaj 2 obrony w tej rundzie", 2));
    deck.Cards.AddRange(CreateCard("Mocna Obrona", 2, CardType.Defense, CardEffect.GainDefense, 4, "Zyskaj 4 obrony w tej rundzie", 1));

    return deck;
}


    private static IEnumerable<Card> CreateCard(
        string name,
        int cost,
        CardType type,
        CardEffect effect,
        int effectValue,
        string description,
        int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new Card
            {
                Id = Guid.NewGuid(),
                Name = name,
                ManaCost = cost,
                Type = type,
                Effect = effect,
                EffectValue = effectValue,
                Description = description
            };
        }
    }
}
