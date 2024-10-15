namespace SimpleEnemyFight2;

public static class Overrider
{
    public static double GetPercent(this int[] source)
    {
        return ((double) source[0])/source[1]*100;
    }

    public static int GetRandomValue(this Random random, int[] chances)
    {
        int maxChance = 0;
        foreach (int chance in chances)
            maxChance += chance;
        int randomVal = random.Next(maxChance);
        int currentVal = 0;
        int id = 0;
        foreach (int chance in chances)
        {
            currentVal += chance;
            if (currentVal > randomVal) return id;
            id++;
        }
        return 0;
    }
}