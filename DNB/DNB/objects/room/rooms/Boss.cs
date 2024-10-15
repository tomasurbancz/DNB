namespace SimpleEnemyFight2.rooms;

public class Boss : Room
{
    public Boss(int stage) : base(stage + 1)
    {
        
    }

    public override bool IsBoss()
    {
        return true;
    }

    protected override double GetDifficulty()
    {
        return 0.65;
    }

    protected override string GetName()
    {
        return "Boss";
    }
}