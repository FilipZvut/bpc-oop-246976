
public class Auto
{
    private TypPaliva palivo;
    private int velikostNadrze;
    private float stavNadrze;
    public Autoradio Radio = new();

    public enum TypPaliva
    {
        Benzin,
        Nafta
    }

    protected Auto(TypPaliva palivo, int velikostNadrze)
    {
        this.palivo = palivo;
        this.velikostNadrze = velikostNadrze;
        this.stavNadrze = 0;
    }

    public TypPaliva Palivo
    {
        get { return palivo; }
        protected set { palivo = value; }
    }
    public int VelikostNadrze
    {
        get { return velikostNadrze; }
        protected set { velikostNadrze = value; }
    }
    public float StavNadrze
    {
        get { return stavNadrze; }
        protected set { stavNadrze = value; }
    }
    public void Natankuj(TypPaliva palivo, float mnozstvi)
    {
        if(stavNadrze+mnozstvi <= velikostNadrze)
        
            stavNadrze += mnozstvi;        
        else
            throw new Exception("Nadrz by pretekla");
        

        if (this.palivo != palivo)
            throw new Exception("Spatny typ paliva");
    }

    public override string ToString()
    {
        return $"Palivo: {palivo}, velikost nadrze: {velikostNadrze}, stav nadrze: {stavNadrze}\n";
    }

    
}
