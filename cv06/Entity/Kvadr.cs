
class Kvadr : Objekt3D
{
    private double StranaA;
    private double StranaB;
    private double Vyska;

    public Kvadr(double stranaA, double stranaB, double vyska)
    {
        StranaA = stranaA;
        StranaB = stranaB;
        Vyska = vyska;
    }

    public override double SpoctiObjem()
    {
        return StranaA*StranaB*Vyska;
    }

    public override double SpoctiPovrch()
    {
        return 2 * (StranaA * StranaB + StranaB * Vyska + StranaA * Vyska);
    }

    public override void Kresli()
    {
        Console.WriteLine($"Kvadr,\t\t StranaA: {StranaA}, StranaB: {StranaB}, Vyska: {Vyska}");
    }
}
