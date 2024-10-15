using SimpleEnemyFight2.game;

namespace SimpleEnemyFight2.manager;

public class ChestManager : Manager
{
    public ChestManager() : base(1)
    {
    }

    protected override void MakeAction(int num)
    {
        Game.Instance.Player.Inventory.AddItem(Game.Instance.CurrentRoom.Chest.Item);
        Game.Instance.LeaveRoom();
        ChangeManager(new SelectionManager());
    }

    protected override void PrintLine()
    {
        Console.WriteLine("Otevřel jsi chestku");
        Console.WriteLine(Game.Instance.Chest.ToString());
        Console.WriteLine();
    }

    public override void PrintKeys()
    {
        Console.WriteLine("1 - zpět");
    }
}