using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.gameStatus;

public class Victory : GameStatus
{
    public override void MakeAction()
    {
        Console.Clear();
        List<String> lines = new List<string>();
        lines.Add("Vyhrál jsi");
        new BigPrinter(lines).Run(ConsoleColor.Black, ConsoleColor.Green);
        Environment.Exit(0);
    }
}