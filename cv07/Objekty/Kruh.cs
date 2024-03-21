public class Kruh : Objekt2D
{
    private double Polomer;

    public Kruh(double Polomer)
    {
        this.Polomer = Polomer;
    }

    public override double Plocha()
    {
        return Polomer * Polomer * double.Pi;
    }

    public override string ToString()
    {
        return $"Plocha je: {Plocha()}";
    }
}
