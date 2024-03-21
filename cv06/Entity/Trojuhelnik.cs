
class Trojuhelnik : Objekt2D
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

    public override void Kresli()
    {
        Console.WriteLine($"Trojuhelnik,\t StranaA: {StranaA}, StranaB: {StranaB}, StranaC: {StranaC}");
    }

    public override double SpoctiPlochu()
    {
        double s = (StranaA + StranaB + StranaC) / 2;
        return Math.Sqrt(s * (s - StranaA) * (s - StranaB) * (s - StranaC));
    }
    
}
