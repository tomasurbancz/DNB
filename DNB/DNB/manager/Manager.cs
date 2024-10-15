using SimpleEnemyFight2.game;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.manager;

public abstract class Manager
{
    private int MaxKey;

    public Manager(int maxKey)
    {
        MaxKey = maxKey;
        Console.Clear();
        PrintLine();
        PrintKeys();
    }
    
    public void CheckForInput(string line)
    {
        if (int.TryParse(line, out int num))
        {
            if (num >= 1 && num <= MaxKey)
            {
                MakeAction(num);
                return;
            }
        }

        new ErrorPrinter("Špatný input").Run();
    }
    
    protected abstract void MakeAction(int num);

    public void ChangeManager(Manager manager)
    {
        Game.Instance.manager = manager;
    }

    protected abstract void PrintLine();
    public abstract void PrintKeys();
}