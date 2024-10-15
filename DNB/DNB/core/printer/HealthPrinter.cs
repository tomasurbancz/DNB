using System.Transactions;
using Console = System.Console;

namespace SimpleEnemyFight2.printer;

public class HealthPrinter : Printer
{
    private int HP;
    private int MaxHP;
    private string Name;
    
    public HealthPrinter(Stats stats, string name)
    {
        HP = (int) stats.HP;
        MaxHP = stats.MaxHP;
        Name = name;
    }

    protected override void Print()
    {
        Console.WriteLine("\nŽivoty hráče " + Name + ": ");
        int percent = (int) Math.Floor(HP * 100d / MaxHP);
        int remaining = 20;
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("[");
        
        Console.ForegroundColor = ConsoleColor.Green;
        while (percent >= 5)
        {
            percent -= 5;
            remaining--;
            Console.Write("#");
        }

        Console.ForegroundColor = ConsoleColor.Red;
        while (remaining > 0)
        {
            remaining--;
            Console.Write("#");
        }
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("]");
        
        int spaces = 10 - ((HP.ToString().Length + MaxHP.ToString().Length)/2);
        while (spaces > 0)
        {
            spaces--;
            Console.Write(" ");
        }
        
        Console.WriteLine(HP + "/" + MaxHP + "\n");
    }

    protected override void Print(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
    {
        Print();
    }
}