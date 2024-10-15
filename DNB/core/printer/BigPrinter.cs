namespace SimpleEnemyFight2.printer;

public class BigPrinter : Printer
{
    private List<string> Info;
    
    public BigPrinter(List<string> info)
    {
        Info = info;
    }
    
    protected override void Print()
    {
        Print(ForegroundColor, BackgroundColor);
    }

    protected override void Print(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
    {
        Console.ForegroundColor = ForegroundColor;
        Console.BackgroundColor = BackgroundColor;
        int largest = 0;
        foreach (var text in Info)
        {
            if (largest < text.Length) largest = text.Length;
        }
        PrintSpace(largest + 6);
        foreach (var text in Info)
        {
            int space = (largest - text.Length)/2 + 3;
            while (space > 0)
            {
                space--;
                Console.Write(" ");
            }
            Console.Write(text);
            space = (largest - text.Length)/2 + 3;
            while (space > 0)
            {
                space--;
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        PrintSpace(largest + 6);
    }

    private void PrintSpace(int space)
    {
        while (space > 0)
        {
            space--;
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}