namespace SimpleEnemyFight2;

public class Weapon : Item
{
    private int Damage;
    private string Name;

    public Weapon(int damage, string name)
    {
        Damage = damage;
        Name = name;
    }

    public override int GetStat()
    {
        return Damage;
    }

    public override string GetName()
    {
        return Name;
    }
}