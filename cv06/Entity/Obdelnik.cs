
public class Obdelnik :Objekt2D
{
    private double StranaA;
    private double StranaB;

    public Obdelnik(double stranaA, double stranaB)
    {
        StranaA = stranaA;
        StranaB = stranaB;
    }

    public override double SpoctiPlochu()
    {
        return StranaA*StranaB;
    }
    public override void Kresli()
    {
        Console.WriteLine($"Obdelnik, StranaA: {StranaA}, StranaB: {StranaB}");
    }
}

