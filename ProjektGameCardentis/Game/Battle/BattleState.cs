namespace ProjektGameCardentis.Game.Battle;

public class BattleState
{
    public int RoundNumber { get; set; } = 1;

    public BattlePlayer PlayerA { get; init; } = null!;
    public BattlePlayer PlayerB { get; init; } = null!;

    public bool IsFinished { get; set; }
    public BattlePlayer? Winner { get; set; }

    public List<BattleLogEntry> Log { get; } = new();
}
