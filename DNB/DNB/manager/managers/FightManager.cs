using SimpleEnemyFight2.action;
using SimpleEnemyFight2.game;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.manager;

public class FightManager : Manager
{
    public FightManager() : base(3)
    {
    }

    protected override void MakeAction(int num)
    {
        if (num == 1)
        {
            Game.Instance.Player.Move.ChangeMove(Move.Type.Fight);
            ChangeManager(new FightStatsManager());
            Console.Clear();
            MoveManager.Play(Game.Instance.Player, Game.Instance.Enemy);
            Game.Instance.manager.PrintKeys();
        }
        else if (num == 2)
        {
            ChangeManager(new HealManager());
        }
        else
        {
            ChangeManager(new SelectionManager());
        }
    }

    protected override void PrintLine()
    {
        List<string> s = new List<string>();
        s.Add("Vstoupil jsi do dalšího kola souboje");
        s.Add("Vyber si:");
        new BigPrinter(s).Run();
    }

    public override void PrintKeys()
    {
        Console.WriteLine("1 - Zaútočit");
        Console.WriteLine("2 - Uzdravit se");
        Console.WriteLine("3 - Zpět");
    }
}