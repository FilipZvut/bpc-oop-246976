
public class Valec : Objekt3D
{
    private double Polomer;
    private double Vyska;

    public Valec(double polomer, double vyska)
    {
        Polomer = polomer;
        Vyska = vyska;
    }

    public override double SpoctiObjem()
    {
        return Math.PI * Polomer * Polomer * Vyska;
    }
    public override double SpoctiPovrch()
    {
        return 2 * Math.PI * Polomer * Vyska + 2 * Math.PI *Polomer * Polomer;
    }
    public override void Kresli()
    {
        Console.WriteLine($"Valec, Polomer: {Polomer}, Vyska: {Vyska}");
    }
}

