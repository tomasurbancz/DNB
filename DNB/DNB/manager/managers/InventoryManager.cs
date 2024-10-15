using SimpleEnemyFight2.game;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.manager;

public class InventoryManager : Manager
{
    public InventoryManager() : base(2)
    {
    }

    protected override void MakeAction(int num)
    {
        if(num == 1) ChangeManager(new SelectionManager());
        else
        {
            Console.WriteLine(Game.Instance.Player.Inventory.PickStrongestWeapon());
        }
    }

    protected override void PrintLine()
    {
        Game.Instance.Player.Inventory.Print();
        Console.WriteLine();
    }

    public override void PrintKeys()
    {
        Console.WriteLine("1 - Zpět");
        Console.WriteLine("2 - Vzít nejsilnější zbraň");
    }
}