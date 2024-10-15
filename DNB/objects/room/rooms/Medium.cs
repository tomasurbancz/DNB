namespace SimpleEnemyFight2.rooms;

public class Medium : Room
{
    public Medium(int stage) : base(stage + 1)
    {
        
    }

    public override bool IsBoss()
    {
        return false;
    }

    protected override double GetDifficulty()
    {
        return 0.3;
    }

    protected override string GetName()
    {
        return "Medium";
    }
}