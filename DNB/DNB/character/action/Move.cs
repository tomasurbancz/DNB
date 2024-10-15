namespace SimpleEnemyFight2.action;

public class Move
{
    public Type MoveType;
    public Potion SelectedPotion;
    
    public enum Type
    {
        Fight,
        Heal
    }

    public void ChangePotion(Potion potion)
    {
        SelectedPotion = potion;
    }

    public void ChangeMove(Type moveType)
    {
        MoveType = moveType;
    }
}