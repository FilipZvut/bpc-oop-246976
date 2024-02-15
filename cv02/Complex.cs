
class Complex
{
    public double Realna;
    public double Imaginarni;
    public Complex(double realna=0.0, double imaginarni = 0.0)
    {
        Realna = realna;
        Imaginarni = imaginarni;
    }
    
    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Realna + b.Realna, a.Imaginarni + b.Imaginarni);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Realna - b.Realna, a.Imaginarni - b.Imaginarni);
    }

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(a.Realna * b.Realna, a.Imaginarni * b.Imaginarni);
    }

    public static Complex operator /(Complex a, Complex b)
    {
        return new Complex(a.Realna / b.Realna, a.Imaginarni / b.Imaginarni);
    }

    public static bool operator ==(Complex a, Complex b)
    {
        return a.Realna == b.Realna && a.Imaginarni == b.Imaginarni;
    }

    public static bool operator !=(Complex a, Complex b)
    {
        return !(a.Realna == b.Realna && a.Imaginarni == b.Imaginarni);
    }

    public static Complex operator -(Complex a)
    {
        return new Complex(-a.Realna, -a.Imaginarni);
    }
    public override string ToString()
    {
       
        if(Imaginarni >= 0)
            return $"{Realna} + j{Imaginarni}";
        else
            return $"{Realna} - j{-Imaginarni}";       
    }

    public Complex Conjugate()
    {
        return new Complex(Realna, -Imaginarni);
    }

    public double Modulus()
    {
        return Math.Sqrt(Realna * Realna + Imaginarni * Imaginarni);
    }

    public double Argument()
    {
        return Math.Atan2(Imaginarni, Realna);
    }
}