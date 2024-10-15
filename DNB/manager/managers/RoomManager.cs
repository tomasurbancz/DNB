using SimpleEnemyFight2.game;

namespace SimpleEnemyFight2.manager;

public class RoomManager : Manager
{
    public RoomManager() : base(1)
    {
    }

    protected override void MakeAction(int num)
    {
        ChangeManager(new SelectionManager());
    }

    protected override void PrintLine()
    {
        Console.WriteLine("Vstoupil jsi do místnosti:\n" + Game.Instance.CurrentRoom.ToString());
    }

    public override void PrintKeys()
    {
        Console.WriteLine("1 - Zpět");
    }
}