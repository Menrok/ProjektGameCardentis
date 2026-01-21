namespace ProjektGameCardentis.Game;

public static class StarterDeckFactory
{
    public static Deck Create()
    {
        var deck = new Deck();

        deck.Cards.AddRange(CreateCard("Precyzyjne Uderzenie", 2, CardType.Attack, CardEffect.DealDamage, 5, "Zadaj 5 obrażeń", 3));
        deck.Cards.AddRange(CreateCard("Silne Uderzenie", 3, CardType.Attack, CardEffect.DealDamage, 7, "Zadaj 7 obrażeń", 2));
        deck.Cards.AddRange(CreateCard("Natarcie", 3, CardType.Attack, CardEffect.DealDamage, 6, "Zadaj 6 obrażeń. Jeśli w tej rundzie zagrasz inną kartę, zadaj +2 obrażenia", 2));
        deck.Cards.AddRange(CreateCard("Szybki Cios", 1, CardType.Attack, CardEffect.DealDamage, 3, "Zadaj 3 obrażenia", 2));
        deck.Cards.AddRange(CreateCard("Dobicie", 2, CardType.Attack, CardEffect.DealDamage, 4, "Zadaj 4 obrażenia. Jeśli przeciwnik ma ≤10 HP, zadaj +3 obrażenia", 1));

        deck.Cards.AddRange(CreateCard("Lekka Obrona", 1, CardType.Defense, CardEffect.GainDefense, 3, "Zyskaj 3 obrony w tej rundzie", 3));
        deck.Cards.AddRange(CreateCard("Mocna Obrona", 2, CardType.Defense, CardEffect.GainDefense, 6, "Zyskaj 6 obrony w tej rundzie", 2));
        deck.Cards.AddRange(CreateCard("Blok Awaryjny", 0, CardType.Defense, CardEffect.GainDefense, 1, "Zyskaj 1 obrony w tej rundzie", 1));
        deck.Cards.AddRange(CreateCard("Przygotowana Obrona", 1, CardType.Defense, CardEffect.GainDefense, 2, "Zyskaj 2 obrony. Jeśli przeciwnik zagra ≥2 karty, zyskaj +2 obrony", 1));

        deck.Cards.AddRange(CreateCard("Skupienie", 0, CardType.Utility, CardEffect.DrawCard, 1, "Dobierz 1 kartę", 3));
        deck.Cards.AddRange(CreateCard("Szybka Analiza", 0, CardType.Utility, CardEffect.DrawCard, 1, "Dobierz 1 kartę. Jeśli to jedyna karta w tej rundzie, zachowaj 1 energię", 1));
        deck.Cards.AddRange(CreateCard("Żar Walki", 1, CardType.Utility, CardEffect.RestoreEnergy, 2, "Jeśli w tej rundzie zadasz obrażenia, odzyskaj 2 energii", 2));
        deck.Cards.AddRange(CreateCard("Taktyczny Ruch", 1, CardType.Utility, CardEffect.None, 0, "Jeśli zagrasz tylko 1 kartę w tej rundzie, zachowaj +2 energii na następną rundę", 1));

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
