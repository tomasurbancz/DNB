namespace SimpleEnemyFight2.rooms;

public class Easy : Room
{
    public Easy(int stage) : base(stage + 1)
    {
        
    }

    public override bool IsBoss()
    {
        return false;
    }
    
    protected override double GetDifficulty()
    {
        return 0.1;
    }

    protected override string GetName()
    {
        return "Easy";
    }
}