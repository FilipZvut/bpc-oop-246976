
class Koule : Objekt3D
{
    public double Polomer;

    public Koule(double polomer)
    {
        Polomer = polomer;
    }

    public override double SpoctiObjem()
    {
        return 4 / 3 * Math.PI * Polomer * Polomer * Polomer;
    }

    public override double SpoctiPovrch()
    {
        return 4 * Math.PI * Polomer * Polomer;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Koule,\t\t Polomer: {Polomer}");
    }
}