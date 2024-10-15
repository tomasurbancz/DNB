using SimpleEnemyFight2.game;

namespace SimpleEnemyFight2;

public class Chest
{
    public Item Item { get; private set; }
    private int Stage;

    public Chest(int stage)
    {
        Stage = stage;
        GenerateItem();
    }

    private void GenerateItem()
    {
        int num = new Random().GetRandomValue([1, 1]);
        if (num == 0)
        {
            int healAmount = 0;
            string name = "";
            int potionType = new Random().GetRandomValue([3, 2, 1]);
            if (potionType == 0)
            {
                healAmount = new Random().Next(5 + Stage, 20 + Stage);
                name = "Malý potion";
            } else if (potionType == 1)
            {
                healAmount = new Random().Next(15 + Stage, 40 + Stage);
                name = "Střední potion";
            }
            else
            {
                healAmount = new Random().Next(25 + Stage, 60 + Stage);
                name = "Velký potion";
            }

            Item = new Potion(healAmount, name);
        }
        else
        {
            int damage = 0;
            string name = "";
            if (Game.Instance.Player.characterClass == Character.CharacterClass.Archer)
            {
                name = "Luk";
                damage = new Random().Next(8 + Stage, 12 + Stage);
            }
            else if (Game.Instance.Player.characterClass == Character.CharacterClass.Mage)
            {
                name = "Hůl";
                damage = new Random().Next(13 + Stage, 17 + Stage);
            }
            else 
            {
                name = "Meč";
                damage = new Random().Next(5 + Stage, 7 + Stage);
            }

            Item = new Weapon(damage, name);
        }
    }

    public override string ToString()
    {
        if (new Inventory().IsSameType(Item, typeof(Weapon)))
        {
            return $"Typ: Weapon\nNázev: {Item.GetName()}\nPoškození: {Item.GetStat()}";
        }

        return $"Typ: Potion\nNázev: {Item.GetName()}\nUzdravení: {Item.GetStat()}";
    }
}