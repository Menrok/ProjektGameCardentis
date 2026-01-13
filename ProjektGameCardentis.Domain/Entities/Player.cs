namespace ProjektGameCardentis.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";

        public int Health { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }

        public Deck Deck { get; private set; }

        private Player()
        {
            Deck = new Deck();
        }

        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Health = 30;
            Attack = 0;
            Defense = 0;
            Deck = new Deck();
        }

        public void TakeDamage(int damage)
        {
            var effectiveDamage = Math.Max(0, damage - Defense);
            Health = Math.Max(0, Health - effectiveDamage);
        }
    }
}
