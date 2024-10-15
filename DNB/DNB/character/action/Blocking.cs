using SimpleEnemyFight2.printer;

namespace SimpleEnemyFight2.action;

public class Blocking
{
    private Character Character;

    public void SetUp(Character character)
    {
        Character = character;
    }
    

    public void Block(Character enemyCharacter)
    {
        new SuccessPrinter(Character.Stats.Name + " zablokoval útok od " + enemyCharacter.Stats.Name).Run();
    }
}