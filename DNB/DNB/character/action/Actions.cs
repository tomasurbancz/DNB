namespace SimpleEnemyFight2.action;

public class Actions
{
    private Blocking Blocking;
    private Fighting Fighting;
    private Healing Healing;

    public void SetUpActions(Character character)
    {
        Blocking = new Blocking();
        Fighting = new Fighting();
        Healing = new Healing();
        Blocking.SetUp(character);
        Fighting.SetUp(character);
        Healing.SetUp(character);
    }

    public void Attack(Character enemyCharacter)
    {
        Fighting.Attack(enemyCharacter);
    }
    
    public void Attack(Character enemyCharacter, int times)
    {
        Fighting.Attack(enemyCharacter, times);
    }


    public void Block(Character enemyCharacter)
    {
        Blocking.Block(enemyCharacter);
    }

    public void Heal(Potion potion)
    {
        Healing.Heal(potion);
    }
}