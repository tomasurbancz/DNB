using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.action;

public class Healing
{
    private Character Character;

    public void SetUp(Character character)
    {
        Character = character;
    }
    

    public void Heal(Potion potion)
    {
        new SuccessPrinter(Character.Stats.Name + " vypil potion " + potion.GetName() + " a obnovil si " + potion.GetStat()).Run();
        Character.Stats.HP = Math.Min(Character.Stats.HP + potion.GetStat(), Character.Stats.MaxHP);
        new HealthPrinter(Character.Stats, Character.Stats.Name).Run();
        Character.Inventory.RemoveItem(potion);
    }
}