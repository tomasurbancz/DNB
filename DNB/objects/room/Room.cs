using SimpleEnemyFight2.rooms;

namespace SimpleEnemyFight2;

public abstract class Room
{
    public int Stage { get; private set; }
    public Character Monster { get; private set; }
    public Chest Chest { get; private set; }
    
    public Room(int stage)
    {
        Stage = stage;
        Monster = CreateMonster();
        Chest = CreateChest();
    }
    
    public static Room CreateNewRoom(int stage)
    {
        int val = new Random().Next(100);
        int BossChance = stage*3 + 10;
        Room room = null;
        if (val < BossChance)
        {
            room = new Boss(stage);
        }
        else
        {
            int roomRandom = new Random().GetRandomValue([10, 7, 5]);
            if(roomRandom == 0) 
                room = new Easy(stage);
            else if(roomRandom == 1)
                room = new Medium(stage);
            else 
                room = new Hard(stage);
        }
        return room;
    }

    private Character CreateMonster()
    {
        Character character = null;
        int randomCharSelected = new Random().GetRandomValue([1, 1, 1]);
        Inventory inventory = new Inventory();
        int bossMultiplier = 1;
        if (IsBoss()) bossMultiplier = 2;
        if (randomCharSelected == 0)
        {
            character = Character.Factory.CreateArcher("Lučišník");

            Weapon weapon = new Weapon((int)((5 + (Stage / 2d)) * GetDifficulty() * bossMultiplier), "Luk");
            inventory.AddItem(weapon);

            Potion heal = new Potion((int)((10 + Stage) * (GetDifficulty() + 1) * bossMultiplier), "Malý potion");
            inventory.AddItem(heal);
        }

        if (randomCharSelected == 1)
        {
            character = Character.Factory.CreateMage("Kouzelník");

            Weapon weapon = new Weapon((int)((10 + (Stage / 2d)) * GetDifficulty() * bossMultiplier), "Hůl");
            inventory.AddItem(weapon);

            Potion heal = new Potion((int)((5 + Stage) * (GetDifficulty() + 1) * bossMultiplier), "Malý potion");
            inventory.AddItem(heal);
        }

        if (randomCharSelected == 2)
        {
            character = Character.Factory.CreateWarrior("Bojovník");

            Weapon weapon = new Weapon((int)((7 + (Stage / 2d)) * GetDifficulty() * bossMultiplier), "Luk");
            inventory.AddItem(weapon);

            Potion heal = new Potion((int)((7 + Stage) * (GetDifficulty() + 1) * bossMultiplier), "Malý potion");
            inventory.AddItem(heal);
        }

        character.SetInventory(inventory);
        
        return character;
    }

    private Chest CreateChest()
    {
        return new Chest(Stage);
    }

    public abstract bool IsBoss();
    protected abstract double GetDifficulty();

    protected abstract string GetName();
    
    public string ToString()
    {
        return $"Kolo: {Stage}\nObtížnost: {GetName()}\nTřída protihráče: {Monster.characterClass}";
    }
}