namespace SimpleEnemyFight2.printer;

public class ErrorPrinter : Printer
{
    private string Error;
    
    public ErrorPrinter(string error)
    {
        Error = error;
    }

    protected override void Print()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        int spaces = (6 + Error.Length) / 2;
        String space = "";
        bool bonusSpace = ((spaces * 2 + 1) != (Error.Length + 6));
        while (spaces > 0)
        {
            spaces--;
            space += " ";
        }
        Console.WriteLine(space + "!" + space);
        Console.Write("   " + Error + "   ");
        if(bonusSpace) Console.WriteLine(" ");
        else Console.WriteLine();
        Console.WriteLine(space + "!" + space);
    }

    protected override void Print(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
    {
        Print();
    }
}