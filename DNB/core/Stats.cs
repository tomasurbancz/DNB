namespace SimpleEnemyFight2;

public class Stats
{
    private double localHP;
    
    public double HP
    {
        get => localHP;
        set => localHP = value < 0 ? 0 : value;
    }
    public int MaxHP { get; private set; }
    public double BaseDamage { get; private set; }
    public string Name { get; private set; }
    public int CriticalChance { get; private set; }
    public double CriticalDamage { get; private set; }
    public int BlockChance { get; private set; }


    public Stats(string name, double baseDamage, int hp, int criticalChance, double criticalDamage, int blockChance)
    {
        Name = name;
        BaseDamage = baseDamage;
        HP = hp;
        MaxHP = hp;
        CriticalChance = criticalChance;
        CriticalDamage = criticalDamage;
        BlockChance = blockChance;
    }

    public static class Register
    {
        public static Stats Mage(string name)
        {
            return new Stats(name, 20, 250, 25, 1.5, 5);
        }
        
        public static Stats Warrior(string name)
        {
            return new Stats(name, 10, 500, 5, 1.25, 25);
        }
        
        public static Stats Archer(string name)
        {
            return new Stats(name, 14, 400, 15, 1.3, 15);
        }
    }

    public void Print()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("BaseDamage: " + BaseDamage);
        Console.WriteLine("HP: " + HP);
        Console.WriteLine("MaxHP: " + MaxHP);
        Console.WriteLine("CriticalChance: " + CriticalChance);
        Console.WriteLine("CriticalDamage: " + CriticalDamage);
        Console.WriteLine("BlockChance: " + BlockChance);
    }
}