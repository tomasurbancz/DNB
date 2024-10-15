using SimpleEnemyFight2.action;
using SimpleEnemyFight2.game;

namespace SimpleEnemyFight2.manager;

public class HealManager : Manager
{
    public HealManager() : base(Game.Instance.Player.Inventory.GetListItemsOfType(typeof(Potion)).Count + 1)
    {
        
    }
    
    protected override void MakeAction(int num)
    {
        if (num == Game.Instance.Player.Inventory.GetListItemsOfType(typeof(Potion)).Count + 1)
        {
            ChangeManager(new FightManager());
            return;
        }
        Potion potion = (Potion) Game.Instance.Player.Inventory.GetListItemsOfType(typeof(Potion))[num - 1];
        Game.Instance.Player.Move.ChangeMove(Move.Type.Heal);
        Game.Instance.Player.Move.ChangePotion(potion);
        
        ChangeManager(new FightStatsManager());
        Console.Clear();
        MoveManager.Play(Game.Instance.Player, Game.Instance.Enemy);
        Game.Instance.manager.PrintKeys();
    }

    protected override void PrintLine()
    {
        if (!Game.Instance.Player.Inventory.ContainsType(typeof(Potion)))
        {
            Console.WriteLine("Nemáš žádný potion v inventáři\n");
            return;
        }
        Console.WriteLine("Vyber si potion:\n");
    }

    public override void PrintKeys()
    {
        for (int i = 0; i < Game.Instance.Player.Inventory.GetListItemsOfType(typeof(Potion)).Count; i++)
        {
            Potion potion = (Potion) Game.Instance.Player.Inventory.GetListItemsOfType(typeof(Potion))[i];
            Console.WriteLine((i + 1) + " - " + potion.GetName() + " (" + potion.GetStat() + ")");
        }
        Console.WriteLine((Game.Instance.Player.Inventory.GetListItemsOfType(typeof(Potion)).Count + 1 )+ " - zpět");
    }
}