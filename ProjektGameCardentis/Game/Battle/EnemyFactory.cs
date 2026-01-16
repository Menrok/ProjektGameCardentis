using ProjektGameCardentis.Entities.Players;

namespace ProjektGameCardentis.Game.Battle;

public static class EnemyFactory
{
    public static BattlePlayer CreateBasicEnemy()
    {
        var deck = StarterDeckFactory.Create();
        deck.Shuffle();

        var enemy = new BattlePlayer
        {
            PlayerId = Guid.NewGuid(),
            Deck = deck
        };

        for (int i = 0; i < 5; i++)
            enemy.DrawCard();

        return enemy;
    }
}
