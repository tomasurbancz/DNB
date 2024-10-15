using SimpleEnemyFight2.game;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.manager;

public class SelectionManager : Manager
{

    public SelectionManager() : base(3)
    {
        
    }
    
    protected override void MakeAction(int num)
    {
        if (num == 1)
        {
            if (Game.Instance.IsInRoom)
            {
                ChangeManager(new FightManager());
            }
            else
            {
                Game.Instance.CreateNewRoom();
                ChangeManager(new RoomManager());
            }
        }
        if (num == 2) ChangeManager(new InventoryManager());
        if (num == 3) ChangeManager(new StatsManager());
    }

    protected override void PrintLine()
    {
        List<string> list = new List<string>();
        list.Add("Vyber si možnost");
        new BigPrinter(list).Run();
    }

    public override void PrintKeys()
    {
        if (Game.Instance.IsInRoom)
        {
            Console.WriteLine("1 - Boj");
        }
        else
        {
            Console.WriteLine("1 - Vstup do nové místnosti");
        }
        Console.WriteLine("2 - Inventář");
        Console.WriteLine("3 - Stastiky");
    }
}