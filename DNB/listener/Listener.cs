using SimpleEnemyFight2.game;

namespace SimpleEnemyFight2.listener;

public class Listener
{
    public Listener()
    {
        while (true)
        {
            Game.Instance.manager.CheckForInput(Console.ReadLine());
        }
    }
}