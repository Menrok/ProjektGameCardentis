namespace ProjektGameCardentis.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";

        public int Health { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }

        private Player() { }

        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Health = 100;
            Attack = 10;
            Defense = 5;
        }

        public void TakeDamage(int damage)
        {
            var effectiveDamage = damage - Defense;
            if (effectiveDamage < 0)
                effectiveDamage = 0;

            Health -= effectiveDamage;

            if (Health < 0)
                Health = 0;
        }
    }
}
