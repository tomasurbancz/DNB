using System.Drawing;
using SimpleEnemyFight2.game;
using SimpleEnemyFight2.gameStatus;
using SimpleEnemyFight2.manager;
using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.action;

public class MoveManager
{
    private static bool SecondHealthBoss = false;
    
    public static void Play(Character char1, Character char2) 
    {
        if (CheckForEndGame(char1, char2)) new Lose().MakeAction();
        
        if (char1.Move.MoveType == Move.Type.Fight)
        {
            char1.Attack(char2);
        }
        else
        {
            char1.Heal(char1.Move.SelectedPotion);
        }

        if (CheckForEndGame(char1, char2))
        {
            Victory();
            return;
        }

        Game.Instance.Ai.Run();
        if (Game.Instance.CurrentRoom.IsBoss())
        {
            if (char2.Move.MoveType == Move.Type.Fight)
            {
                if (new[] { (int)char2.Stats.HP, char2.Stats.MaxHP }.GetPercent() <= 50)
                {
                    char2.Attack(char1, 2);
                }
                else
                {
                    char2.Attack(char1);
                }
            }
            else
            {
                char2.Heal(char2.Move.SelectedPotion);
            }
        }
        else
        {
            if (char2.Move.MoveType == Move.Type.Fight)
            {
                char2.Attack(char1);
            }
            else
            {
                char2.Heal(char2.Move.SelectedPotion);
            }
        }

        if (CheckForEndGame(char1, char2)) new Lose().MakeAction();
    }

    private static void Victory()
    {
        if (Game.Instance.CurrentRoom.IsBoss())
        {
            if (!SecondHealthBoss)
            {
                SecondHealthBoss = true;
                Game.Instance.Enemy.Revive();
                new BigPrinter(["Boss se oživil"]).Run(ConsoleColor.Black, ConsoleColor.Red);
                Console.WriteLine();
                return;
            }
            new Victory().MakeAction();
        }
        Game.Instance.LeaveRoom();
    }

    private static bool CheckForEndGame(Character char1, Character char2)
    {
        return char1.Stats.HP <= 0 || char2.Stats.HP <= 0;
    }
}