namespace ProjektGameCardentis.Game.Battle;

public static class EnemyFactory
{
    public static BattlePlayer CreateBasicEnemy()
    {
        var deck = StarterDeckFactory.Create();
        deck.Shuffle();

        return new BattlePlayer
        {
            PlayerId = Guid.NewGuid(),
            Name = "Przeciwnik AI",
            Deck = deck,
            Energy = 2,
            MaxEnergy = 6
        };
    }
}
