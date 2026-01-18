namespace ProjektGameCardentis.Game.Battle;

public static class BattleAi
{
    public static BattlePlan CreatePlan(BattlePlayer ai)
    {
        var cards = ai.Hand.Cards.Where(c => c.ManaCost <= ai.Energy).Take(2).ToList();

        return new BattlePlan(ai.PlayerId, cards);
    }
}
