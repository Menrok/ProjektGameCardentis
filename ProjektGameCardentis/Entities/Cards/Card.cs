namespace ProjektGameCardentis.Entities.Cards;

public class Card
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;

    public int ManaCost { get; set; }

    public CardType Type { get; set; }
    public CardEffect Effect { get; set; }

    public int EffectValue { get; set; }
}
