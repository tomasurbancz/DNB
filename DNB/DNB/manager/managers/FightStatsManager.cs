using SimpleEnemyFight2.game;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.manager;

public class FightStatsManager : Manager
{
    public FightStatsManager() : base(1)
    {
        
    }
    
    protected override void MakeAction(int num)
    {
        if(Game.Instance.IsInRoom)
            ChangeManager(new SelectionManager());
        else 
            Game.Instance.manager.ChangeManager(new ChestOpenerManager());
    }

    protected override void PrintLine()
    {
        
    }

    public override void PrintKeys()
    {
        if(Game.Instance.IsInRoom)
            Console.WriteLine("1 - Zpět");
        else 
            Console.WriteLine("1 - Pokračovat v místnosti");
    }
}