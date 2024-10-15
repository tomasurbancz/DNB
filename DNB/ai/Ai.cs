using SimpleEnemyFight2.action;

namespace SimpleEnemyFight2.ai;

public class Ai
{
    private Character Character;
    
    public Ai(Character character)
    {
        Character = character;
    }

    public void Run()
    {
        Move move = DecideNextMove();
        Character.Move = move;
    }
    
    protected Move DecideNextMove()
    {
        Move move = new Move();

        move.ChangeMove(Move.Type.Fight);
        if (Character.Inventory.ContainsType(typeof(Potion)))
        {
            if (new[] { (int)Character.Stats.HP, Character.Stats.MaxHP }.GetPercent() <= 60)
            {
                move.ChangeMove(Move.Type.Heal);
                move.ChangePotion((Potion) Character.Inventory.GetListItemsOfType(typeof(Potion))[0]);
            }
        }
        
        return move;
    }
}