namespace SimpleEnemyFight2.manager;

public class ChestOpenerManager : Manager
{
    public ChestOpenerManager() : base(1)
    {
        
    }

    protected override void MakeAction(int num)
    {
        ChangeManager(new ChestManager());
    }

    protected override void PrintLine()
    {
        Console.WriteLine("Získal jsi chestku");
        Console.WriteLine();
    }

    public override void PrintKeys()
    {
        Console.WriteLine("1 - otevřít");
    }
}