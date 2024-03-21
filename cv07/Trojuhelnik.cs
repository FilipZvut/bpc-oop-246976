public class Trojuhelnik : Objekt2D
{
    private double StranaA;
    private double StranaB;
    private double StranaC;

    public Trojuhelnik(double stranaA, double stranaB, double stranaC)
    {
        StranaA = stranaA;
        StranaB = stranaB;
        StranaC = stranaC;
    }

    public override double Plocha()
    {
        double s = (StranaA + StranaB + StranaC) / 2;
        return Math.Sqrt(s * (s - StranaA)*(s - StranaB)*(s - StranaC));
    }

    public override string ToString()
    {
        return $"Plocha je : {Plocha()}";
    }
}
