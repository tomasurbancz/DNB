using SimpleEnemyFight2.game;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.manager;

public class StatsManager : Manager
{
    public StatsManager() : base(1)
    {
        
    }

    protected override void MakeAction(int num)
    {
        ChangeManager(new SelectionManager());
    }

    protected override void PrintLine()
    {
        Game.Instance.Player.PrintStats();
        Console.WriteLine();
        Game.Instance.Enemy.PrintStats();
        Console.WriteLine(); 
    }

    public override void PrintKeys()
    {
        Console.WriteLine("1 - Zpět");
    }
}