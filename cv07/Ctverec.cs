public class Ctverec : Objekt2D
{
    private double StranaA;

    public Ctverec(double StranaA)
    {  
        this.StranaA = StranaA;
    }
    
    public override double Plocha()
    {
        return StranaA*StranaA;
    }

    public override string ToString()
    {
        return $"Plocha je: {Plocha()}";
    }
}
