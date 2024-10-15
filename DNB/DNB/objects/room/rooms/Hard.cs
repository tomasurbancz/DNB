namespace SimpleEnemyFight2.rooms;

public class Hard : Room
{
    public Hard(int stage) : base(stage + 1)
    {
        
    }

    public override bool IsBoss()
    {
        return false;
    }

    protected override double GetDifficulty()
    {
        return 0.5;
    }

    protected override string GetName()
    {
        return "Hard";
    }
}