namespace ProjektGameCardentis.Game.Battle;

public class BattlePlayer
{
    public Guid PlayerId { get; set; }

    public int Health { get; set; } = 30;
    public int Armor { get; set; } = 0;

    public int Energy { get; private set; } = 3;
    public int MaxEnergy { get; private set; } = 10;

    public int BonusDamage { get; set; }
    public int NextCardCostModifier { get; set; }
    public int AbsorbDamage { get; set; }

    public Deck Deck { get; set; } = new();
    public Hand Hand { get; set; } = new();
    public DiscardPile DiscardPile { get; set; } = new();

    public bool IsAlive => Health > 0;


    public void StartTurn()
    {
        if (Energy < MaxEnergy)
            Energy++;

        DrawCard();
    }

    public void EndTurn()
    {
        BonusDamage = 0;
        NextCardCostModifier = 0;
        AbsorbDamage = 0;
    }

    public void DrawCard()
    {
        var card = Deck.DrawRandom();
        if (card != null)
            Hand.Cards.Add(card);
    }

    public void SpendEnergy(int amount)
    {
        Energy -= amount;
    }

    public void Discard(Card card)
    {
        Hand.Cards.Remove(card);
        DiscardPile.Cards.Add(card);
    }

    public void TakeDamage(int amount)
    {
        var absorbedByShield = Math.Min(AbsorbDamage, amount);
        AbsorbDamage -= absorbedByShield;
        amount -= absorbedByShield;

        var absorbedByArmor = Math.Min(Armor, amount);
        Armor -= absorbedByArmor;
        amount -= absorbedByArmor;

        Health -= amount;
    }

    public void GainArmor(int amount)
    {
        Armor += amount;
    }
}
