using ProjektGameCardentis.Entities;

namespace ProjektGameCardentis.Game;

public static class StarterDeckFactory
{
    public static Deck Create()
    {
        var deck = new Deck();

        // ATAK
        deck.Cards.AddRange(CreateCard("Szybki Cios", 1, CardType.Attack, CardEffect.DealDamage, 3, "Zadaj 3 obrażenia", 2));
        deck.Cards.AddRange(CreateCard("Precyzyjne Uderzenie", 2, CardType.Attack, CardEffect.DealDamage, 5, "Zadaj 5 obrażeń", 2));
        deck.Cards.AddRange(CreateCard("Wzmocniony Atak", 3, CardType.Attack, CardEffect.DealDamage, 6, "Zadaj 6 obrażeń (+2 jeśli zagrano inną kartę)", 2));
        deck.Cards.AddRange(CreateCard("Finisz", 4, CardType.Attack, CardEffect.DealDamage, 8, "Zadaj 8 obrażeń", 2));
        deck.Cards.AddRange(CreateCard("Cios Kontrujący", 2, CardType.Attack, CardEffect.DealDamage, 5, "Jeśli masz pancerz → zadaj 5 obrażeń", 2));

        // OBRONA
        deck.Cards.AddRange(CreateCard("Lekka Tarcza", 1, CardType.Defense, CardEffect.GainArmor, 3, "Zyskaj 3 pancerza do końca tury", 2));
        deck.Cards.AddRange(CreateCard("Tarcza Energii", 2, CardType.Defense, CardEffect.GainArmor, 6, "Zyskaj 6 pancerza", 2));
        deck.Cards.AddRange(CreateCard("Blok Taktyczny", 2, CardType.Defense, CardEffect.GainArmor, 3, "Następne obrażenia w tej turze –3", 2));
        deck.Cards.AddRange(CreateCard("Odbudowa", 3, CardType.Defense, CardEffect.GainArmor, 4, "Zyskaj 4 pancerza i dobierz 1 kartę", 2));

        // UMIEJĘTNOŚCI
        deck.Cards.AddRange(CreateCard("Skupienie", 1, CardType.Skill, CardEffect.DrawCard, 1, "Dobierz 1 kartę", 2));
        deck.Cards.AddRange(CreateCard("Przygotowanie", 2, CardType.Skill, CardEffect.DrawCard, 2, "Dobierz 2 karty", 2));
        deck.Cards.AddRange(CreateCard("Akumulator Energii", 1, CardType.Skill, CardEffect.ReduceNextCardCost, 1, "Następna karta w tej turze kosztuje –1", 2));
        deck.Cards.AddRange(CreateCard("Wzmocnienie", 2, CardType.Skill, CardEffect.IncreaseNextDamage, 3, "Następne obrażenia w tej turze +3", 2));

        // REAKCJE
        deck.Cards.AddRange(CreateCard("Zakłócenie", 2, CardType.Reaction, CardEffect.ModifyOpponentCost, 2, "Następna karta przeciwnika kosztuje +2", 2));
        deck.Cards.AddRange(CreateCard("Tarcza Odruchowa", 2, CardType.Reaction, CardEffect.AbsorbDamage, 3, "Przy pierwszych obrażeniach w turze: absorbuj 3", 2));

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
