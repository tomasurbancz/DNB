namespace SimpleEnemyFight2.printer;

public class SuccessPrinter : Printer
{
    private string Success;
    
    public SuccessPrinter(string success)
    {
        Success = success;
    }

    protected override void Print()
    {
        Print(ConsoleColor.Green, ConsoleColor.Black);
    }

    protected override void Print(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
    {
        Console.BackgroundColor = ForegroundColor;
        Console.ForegroundColor = BackgroundColor;
        Console.WriteLine(Success);
    }
}