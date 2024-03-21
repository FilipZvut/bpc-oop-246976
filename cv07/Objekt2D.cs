public abstract class Objekt2D : I2D, IComparable
{
    public int CompareTo(object obj)
    {
        if (((Objekt2D)obj).Plocha() > this.Plocha())
            return -1;
        else 
            return 1;
    }
    public abstract double Plocha();

}

