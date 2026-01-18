namespace ProjektGameCardentis.Game.Battle;

public class BattleLogEntry
{
    public int Round { get; }
    public string Message { get; }

    public BattleLogEntry(int round, string message)
    {
        Round = round;
        Message = message;
    }
}
