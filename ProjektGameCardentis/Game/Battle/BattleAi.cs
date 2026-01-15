namespace ProjektGameCardentis.Game.Battle;

public static class BattleAi
{
    public static void PlayTurn(BattleState battle)
    {
        var enemy = battle.CurrentPlayer;

        var playableCard = enemy.Hand.Cards
            .FirstOrDefault(c => c.ManaCost <= enemy.Energy);

        if (playableCard != null)
            battle.PlayCard(playableCard);

        battle.EndTurn();
    }
}
