namespace ProjektGameCardentis.Game.Battle;

public static class BattleResolver
{
    public static void ResolveRound(BattleState state, BattlePlan planA, BattlePlan planB)
    {
        if (state.IsFinished) return;

        ApplyStartPhase(state);

        ResolvePlan(state.PlayerA, planA);
        ResolvePlan(state.PlayerB, planB);

        ResolveDamage(state);

        Cleanup(state);
        CheckGameOver(state);

        state.RoundNumber++;
    }

    private static void ApplyStartPhase(BattleState state)
    {
        foreach (var p in new[] { state.PlayerA, state.PlayerB })
        {
            p.Energy = Math.Min(p.MaxEnergy, p.Energy + 1);
            p.DrawCard();

            p.PendingAttack = 0;
            p.PendingDefense = 0;
        }
    }

    private static void ResolvePlan(BattlePlayer player, BattlePlan plan)
    {
        if (plan.IsPass)
        {
            player.ConsecutivePasses++;
            return;
        }

        player.ConsecutivePasses = 0;
        player.Energy -= plan.TotalEnergyCost;

        foreach (var card in plan.Cards)
        {
            if (card.Effect == CardEffect.DealDamage)
                player.PendingAttack += card.EffectValue;

            if (card.Effect == CardEffect.GainDefense)
                player.PendingDefense += card.EffectValue;

            player.Hand.Cards.Remove(card);
            player.DiscardPile.Cards.Add(card);
        }
    }

    private static void ResolveDamage(BattleState state)
    {
        var damageToA = Math.Max(0, state.PlayerB.PendingAttack - state.PlayerA.PendingDefense);
        var damageToB = Math.Max(0, state.PlayerA.PendingAttack - state.PlayerB.PendingDefense);

        state.PlayerA.Health -= damageToA;
        state.PlayerB.Health -= damageToB;

        state.Log.Add(new(state.RoundNumber,
            $"{state.PlayerA.Name} otrzymuje {damageToA} obrażeń, {state.PlayerB.Name} otrzymuje {damageToB} obrażeń"));
    }

    private static void Cleanup(BattleState state)
    {
        foreach (var p in new[] { state.PlayerA, state.PlayerB })
        {
            if (p.ConsecutivePasses >= 4)
            {
                state.IsFinished = true;
                state.Winner = p == state.PlayerA ? state.PlayerB : state.PlayerA;
            }
        }
    }

    private static void CheckGameOver(BattleState state)
    {
        if (!state.PlayerA.IsAlive)
        {
            state.IsFinished = true;
            state.Winner = state.PlayerB;
        }

        if (!state.PlayerB.IsAlive)
        {
            state.IsFinished = true;
            state.Winner = state.PlayerA;
        }
    }
}
