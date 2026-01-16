namespace ProjektGameCardentis.Game.Battle;

public static class BattlePlayerFactory
{
    public static BattlePlayer Create(Entities.Players.Player player)
    {
        return new BattlePlayer
        {
            PlayerId = player.Id,
            Deck = player.Deck.Clone()
        };
    }
}
