using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.action;

public class Fighting
{
    private Character Character;

    public void SetUp(Character character)
    {
        Character = character;
    }

    public Dictionary<double, bool> CalculateDamage()
    {
        double damage = Character.Stats.BaseDamage;
        bool critic = new Random().Next(100) <= Character.Stats.CriticalChance;
        if (Character.Inventory.IsSameType(Character.Inventory.GetItemAtSlot(0), typeof(Weapon)))
        {
            Weapon weapon = (Weapon) Character.Inventory.GetItemAtSlot(0);
            damage += weapon.GetStat();
        }
        Dictionary<double, bool> returnDamage = new Dictionary<double, bool>();
        returnDamage.Add(critic ? damage * Character.Stats.CriticalDamage : damage, critic);
        return returnDamage;
    }
    
    public void Attack(Character enemyCharacter)
    {
        Attack(enemyCharacter, 1);
    }
    
    public void Attack(Character enemyCharacter, int times)
    {
        if (new Random().Next(100) <= Character.Stats.BlockChance)
        {
            enemyCharacter.Block(Character);
            return;
        }
        
        
        Dictionary<double, bool> dmg = CalculateDamage();
        double damage = dmg.First().Key;
        
        string bonusText = "";
        if (times != 1)
        {
            bonusText = times + "x";
            damage *= times;
        }
        
        if (dmg.First().Value)
            new SuccessPrinter(Character.Stats.Name + " úspěšně zaútočil na " + enemyCharacter.Stats.Name + " " + bonusText +
                               " a způsobil kritický zásah s poškozením " + damage).Run();
        else 
            Console.WriteLine(Character.Stats.Name + " úspěšně zaútočil na " + enemyCharacter.Stats.Name + " " + bonusText + " a způsobil " + damage);
        enemyCharacter.Stats.HP -= damage;
        new HealthPrinter(enemyCharacter.Stats, enemyCharacter.Stats.Name).Run();
    }
}