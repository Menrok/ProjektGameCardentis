using ProjektGameCardentis.Entities.Cards;

namespace ProjektGameCardentis.Game.Battle;

public class BattleState
{
    public BattlePlayer Player { get; set; } = null!;
    public BattlePlayer Enemy { get; set; } = null!;

    public int Turn { get; private set; } = 1;
    public bool IsPlayerTurn { get; private set; } = true;
    public bool IsFinished { get; private set; }

    private bool _isFirstTurn = true;

    public BattlePlayer CurrentPlayer => IsPlayerTurn ? Player : Enemy;
    public BattlePlayer Opponent => IsPlayerTurn ? Enemy : Player;
    
    public void StartBattle(int startingHandSize = 5)
    {
        Player.Deck.Shuffle();
        Enemy.Deck.Shuffle();

        for (int i = 0; i < startingHandSize; i++)
        {
            Player.DrawCard();
            Enemy.DrawCard();
        }

        StartTurn();
    }   

    public void StartTurn()
    {
        if (_isFirstTurn)
        {
            _isFirstTurn = false;
            return;
        }

        CurrentPlayer.StartTurn();
    }

    public void EndTurn()
    {
        CurrentPlayer.EndTurn();

        if (CheckGameOver())
        {
            IsFinished = true;
            return;
        }

        IsPlayerTurn = !IsPlayerTurn;

        if (IsPlayerTurn)
            Turn++;

        StartTurn();
    }

    public bool PlayCard(Card card)
    {
        if (IsFinished)
            return false;

        if (!CurrentPlayer.Hand.Cards.Contains(card))
            return false;

        var cost = Math.Max(0, card.ManaCost + CurrentPlayer.NextCardCostModifier);

        if (CurrentPlayer.Energy < cost)
            return false;

        CurrentPlayer.SpendEnergy(cost);
        CurrentPlayer.NextCardCostModifier = 0;

        CurrentPlayer.Hand.Cards.Remove(card);
        ApplyEffect(card);
        CurrentPlayer.DiscardPile.Cards.Add(card);

        return true;
    }

    private void ApplyEffect(Card card)
    {
        switch (card.Effect)
        {
            case CardEffect.DealDamage:
                Opponent.TakeDamage(card.EffectValue + CurrentPlayer.BonusDamage);
                CurrentPlayer.BonusDamage = 0;
                break;

            case CardEffect.GainArmor:
                CurrentPlayer.GainArmor(card.EffectValue);
                break;

            case CardEffect.DrawCard:
                for (int i = 0; i < card.EffectValue; i++)
                    CurrentPlayer.DrawCard();
                break;

            case CardEffect.IncreaseNextDamage:
                CurrentPlayer.BonusDamage += card.EffectValue;
                break;

            case CardEffect.ReduceNextCardCost:
                CurrentPlayer.NextCardCostModifier -= card.EffectValue;
                break;

            case CardEffect.ModifyOpponentCost:
                Opponent.NextCardCostModifier += card.EffectValue;
                break;

            case CardEffect.AbsorbDamage:
                CurrentPlayer.AbsorbDamage += card.EffectValue;
                break;
        }
    }

    private bool CheckGameOver()
        => !Player.IsAlive || !Enemy.IsAlive;
}
