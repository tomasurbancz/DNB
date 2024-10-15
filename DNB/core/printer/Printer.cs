namespace SimpleEnemyFight2.printer;

public abstract class Printer
{
    protected ConsoleColor ForegroundColor { get; private set; }
    protected ConsoleColor BackgroundColor { get; private set; }
    
    public Printer()
    {
        ForegroundColor = Console.ForegroundColor;
        BackgroundColor = Console.BackgroundColor;
    }

    public void Run()
    {
        Print();
        ResetColor();
    }

    public void Run(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
    {
        Print(ForegroundColor, BackgroundColor);
        ResetColor();
    }

    protected abstract void Print();
    protected abstract void Print(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor);

    protected void ResetColor()
    {
        Console.ForegroundColor = ForegroundColor;
        Console.BackgroundColor = BackgroundColor;
    }
}