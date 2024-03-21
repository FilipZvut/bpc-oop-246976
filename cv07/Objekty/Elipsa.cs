public class Elipsa : Objekt2D
{
    private double PoloosaA;
    private double PoloosaB;

    public Elipsa(double PoloosaA, double PoloosaB)
    {
        this.PoloosaA = PoloosaA;
        this.PoloosaB = PoloosaB;
    }

    public override double Plocha()
    {
        return PoloosaA*PoloosaB*double.Pi;
    }

    public override string ToString()
    {
        return $"Plocha je: {Plocha()}";
    }
}
