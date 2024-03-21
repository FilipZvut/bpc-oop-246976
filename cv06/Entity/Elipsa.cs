
class Elipsa : Objekt2D
{
    private double PoloosaA;
    private double PoloosaB;

    public Elipsa(double poloosaA, double poloosaB)
    {
        PoloosaA = poloosaA;
        PoloosaB = poloosaB;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Elipsa,\t\t PoloosaA: {PoloosaA}, PoloosaB: {PoloosaB}");
    }

    public override double SpoctiPlochu()
    {
        return PoloosaA * PoloosaB * Math.PI;
    }
}