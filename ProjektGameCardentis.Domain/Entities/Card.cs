using ProjektGameCardentis.Domain.Enums;

namespace ProjektGameCardentis.Domain.Entities
{
    public class Card
    {
        public Guid Id { get; private set; }
        public  string Name { get; private set; } = "";
        public CardType Type { get; private set; }
        public int Cost { get; private set; }
        public int Value { get; private set; }

        private Card() { }

        public Card(string name, CardType type, int cost, int value)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Cost = cost;
            Value = value;
        }
    }
}
