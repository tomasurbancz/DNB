namespace SimpleEnemyFight2;

public class Potion : Item
{
    private int HealAmount;
    private string PotionName;

    public Potion(int healAmount, string potionName)
    {
        HealAmount = healAmount;
        PotionName = potionName;
    }

    public override int GetStat()
    {
        return HealAmount;
    }

    public override string GetName()
    {
        return PotionName;
    }
}