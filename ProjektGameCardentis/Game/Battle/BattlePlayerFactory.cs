namespace ProjektGameCardentis.Game.Battle;

public static class BattlePlayerFactory
{
    public static BattlePlayer Create(Player player)
    {
        return new BattlePlayer
        {
            PlayerId = player.Id,
            Name = player.Username,
            Deck = player.Deck.Clone(),
            Energy = 3,
            MaxEnergy = 10
        };
    }
}
