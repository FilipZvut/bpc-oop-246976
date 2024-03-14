
public class Jehlan : Objekt3D
{
    private double StranaA;
    private double StranaB;
    private double Vyska;

    public Jehlan(double stranaA, double stranaB, double vyska)
    {
        StranaA = stranaA;
        StranaB = stranaB;
        Vyska = vyska;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Jehlan, StranaA: {StranaA}, StranaB: {StranaB}, Vyska: {Vyska}");
    }

    public override double SpoctiObjem()
    {
        return ((StranaA * StranaB * Vyska) / 2);
    }

    public override double SpoctiPovrch()
    {

        return StranaA*StranaB + 2*((StranaA * Vyska)/2) + 2*((StranaB*Vyska)/2);
    }
}