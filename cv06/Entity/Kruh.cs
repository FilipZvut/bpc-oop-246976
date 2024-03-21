
class Kruh : Objekt2D
{
    private double Polomer;

    public Kruh(double polomer)
    {
        Polomer = polomer;
    }

    public override double SpoctiPlochu() 
    {
        return Math.PI * Polomer * Polomer; 
    }

    public override void Kresli()
    {
        Console.WriteLine($"Kruh,\t\t Polomer: {Polomer}");
    }
}