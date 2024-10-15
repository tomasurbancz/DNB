using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.gameStatus;

public class Lose : GameStatus
{
    public override void MakeAction()
    {
        Console.Clear();
        List<String> lines = new List<string>();
        lines.Add("Prohrál jsi");
        new BigPrinter(lines).Run(ConsoleColor.Black, ConsoleColor.Red);
        Environment.Exit(0);
    }
}