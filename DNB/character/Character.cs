using SimpleEnemyFight2.action;

namespace SimpleEnemyFight2;

public class Character : Actions
{
    public CharacterClass characterClass { get; private set; }
    public Stats Stats { get; private set; }
    private string Name;
    public Inventory Inventory { get; private set; }
    public Move Move;
    
    public enum CharacterClass {
        Mage,
        Warrior,
        Archer
    }

    public Character(CharacterClass characterClass, string name)
    {
        this.characterClass = characterClass;
        Name = name;
        Move = new Move();
        
        Inventory = new Inventory();
        
        SetUp();
    }

    private void SetUp()
    {
        SetUpStats();
        SetUpActions(this);
    }

    private void SetUpStats()
    {
        switch (characterClass)
        {
            case CharacterClass.Mage:
            {
                Stats = Stats.Register.Mage(Name);
                break;
            }
            case CharacterClass.Warrior:
            {
                Stats = Stats.Register.Warrior(Name);
                break;
            }
            case CharacterClass.Archer:
            {
                Stats = Stats.Register.Archer(Name);
                break;
            }
        }
    }

    public static class Factory
    {
        public static Character CreateMage(string name)
        {
            return new Character(CharacterClass.Mage, name);
        }
        
        public static Character CreateWarrior(string name)
        {
            return new Character(CharacterClass.Warrior, name);
        }
        
        public static Character CreateArcher(string name)
        {
            return new Character(CharacterClass.Archer, name);
        }
    }

    public void SetInventory(Inventory inventory)
    {
        Inventory = inventory;
    }

    public void PrintStats()
    {
        Stats.Print();
    }

    public void Revive()
    {
        Stats.HP = Stats.MaxHP;
    }
}