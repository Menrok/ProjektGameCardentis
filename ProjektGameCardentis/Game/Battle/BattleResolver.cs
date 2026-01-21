namespace ProjektGameCardentis.Game.Battle;

public static class BattleResolver
{
    public static void ResolveRound(BattleState state, BattlePlan planA, BattlePlan planB)
    {
        if (state.IsFinished) return;

        ApplyStartPhase(state);

        ResolvePlan(state.PlayerA, planA);
        ResolvePlan(state.PlayerB, planB);

        ResolveConditionalEffects(state, planA, planB);

        ResolveDamage(state);

        ApplyEndPhase(state);

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
            p.PendingEnergyGain = 0;
            p.PendingCardDraw = 0;
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
            switch (card.Effect)
            {
                case CardEffect.DealDamage:
                    player.PendingAttack += card.EffectValue;
                    break;

                case CardEffect.GainDefense:
                    player.PendingDefense += card.EffectValue;
                    break;

                case CardEffect.DrawCard:
                    player.PendingCardDraw += card.EffectValue;
                    break;
            }

            player.Hand.Cards.Remove(card);
            player.DiscardPile.Cards.Add(card);
        }
    }

    private static void ResolveConditionalEffects(BattleState state, BattlePlan planA, BattlePlan planB)
    {
        ApplyConditional(state.PlayerA, planA, state.PlayerB, planB);
        ApplyConditional(state.PlayerB, planB, state.PlayerA, planA);
    }

    private static void ApplyConditional(BattlePlayer player, BattlePlan plan, BattlePlayer opponent, BattlePlan opponentPlan)
    {
        foreach (var card in plan.Cards)
        {
            switch (card.Name)
            {
                case "Natarcie":
                    if (plan.Cards.Count > 1)
                        player.PendingAttack += 2;
                    break;

                case "Dobicie":
                    if (opponent.Health <= 10)
                        player.PendingAttack += 3;
                    break;

                case "Przygotowana Obrona":
                    if (opponentPlan.Cards.Count >= 2)
                        player.PendingDefense += 2;
                    break;

                case "Szybka Analiza":
                    if (plan.Cards.Count == 1)
                        player.PendingEnergyGain += 1;
                    break;

                case "Żar Walki":
                    if (player.PendingAttack > 0)
                        player.PendingEnergyGain = Math.Max(player.PendingEnergyGain, 2);                    
                    break;

                case "Taktyczny Ruch":
                    if (plan.Cards.Count == 1)
                        player.PendingEnergyGain += 2;
                    break;
            }
        }
    }

    private static void ResolveDamage(BattleState state)
    {
        var damageToA = Math.Max(0, state.PlayerB.PendingAttack - state.PlayerA.PendingDefense);

        var damageToB = Math.Max(0, state.PlayerA.PendingAttack - state.PlayerB.PendingDefense);

        state.PlayerA.Health -= damageToA;
        state.PlayerB.Health -= damageToB;

        state.Log.Add(new(state.RoundNumber, $"{state.PlayerA.Name} otrzymuje {damageToA} obrażeń, " + $"{state.PlayerB.Name} otrzymuje {damageToB} obrażeń"));
    }

    private static void ApplyEndPhase(BattleState state)
    {
        foreach (var p in new[] { state.PlayerA, state.PlayerB })
        {
            for (int i = 0; i < p.PendingCardDraw; i++)
                p.DrawCard();

            p.Energy = Math.Min(p.MaxEnergy, p.Energy + p.PendingEnergyGain);
        }
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
