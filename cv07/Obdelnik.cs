public class Obdelnik : Objekt2D
{
    private double StranaA;
    private double StranaB;

    public Obdelnik(double StranaA, double StranaB)
    {
        this.StranaA = StranaA;
        this.StranaB = StranaB;
    }

    public override double Plocha()
    {
        return StranaA * StranaB;
    }

    public override string ToString()
    {
        return $"Plocha je: {Plocha()}";
    }
}
