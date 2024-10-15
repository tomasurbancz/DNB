using SimpleEnemyFight2.ai;
using SimpleEnemyFight2.listener;
using SimpleEnemyFight2.manager;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.game;

public class Game
{
    public Manager manager;
    public Character Player { get; private set; }
    public Chest Chest { get; private set; }
    public Character Enemy;
    public Room CurrentRoom { get; private set; }
    public bool IsInRoom { get; private set; }
    public static Game Instance { get; private set; }

    public Ai Ai { get; private set; }

    public Game()
    {
        IsInRoom = false;
        Instance = this;
        Register();
        AddStartItems();
        manager = new SelectionManager();
        CurrentRoom = Room.CreateNewRoom(-1);
        Enemy = CurrentRoom.Monster;
        Chest = CurrentRoom.Chest;
        Ai = new Ai(Enemy);
        new Listener();
    }

    private void AddStartItems()
    {
        Weapon weapon = new Weapon(100, "Začátečnická zbraň");
        Player.Inventory.AddItem(weapon);
    }

    private void Register()
    {
        string name = "";
        int selected = 0;
        Console.WriteLine("Napiš jméno své postavy");
        name = Console.ReadLine();
        Console.WriteLine("Vyber si postavu:\n1 - Kouzelnik\n2 - Lučišník\n3 - Bojovník");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n >= 1 && n <= 3)
                {
                    selected = n;
                    break;
                }
            }
            new ErrorPrinter("Špatný input").Run();
        }
        if (selected == 1)
        {
            Player = Character.Factory.CreateMage(name);
        } else if (selected == 2)
        {
            Player = Character.Factory.CreateArcher(name);
        }
        else
        {
            Player = Character.Factory.CreateWarrior(name);
        }
    }

    public void LeaveRoom()
    {
        IsInRoom = false;
    }
    
    public void CreateNewRoom()
    {
        IsInRoom = true;
        CurrentRoom = Room.CreateNewRoom(CurrentRoom.Stage);
        Enemy = CurrentRoom.Monster;
        Chest = CurrentRoom.Chest;
        Ai = new Ai(Enemy);
    }
}