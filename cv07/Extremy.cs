public class Extremy
{
    public static T Nejvetsi<T>(T[] data) where T : IComparable
    {
        T maximalni = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i].CompareTo(maximalni) > 0)
                maximalni = data[i];
        }
        return maximalni;
    }

    public static T Nejmensi<T>(T[] data) where T : IComparable
    {
        T minimalni = data[0];
        for(int i = 1;i < data.Length;i++)
        {
            if (data[i].CompareTo(minimalni) < 0 ) 
                minimalni = data[i];
        }
        return minimalni;
    }
}

