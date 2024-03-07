
public class Nakladni : Auto
{
    private float MaxNaklad;
    private float PrepravovanyNaklad;

    public Nakladni(float MaxNaklad, TypPaliva Palivo, int VelikostNadrze) 
        : base(Palivo, VelikostNadrze)
    {
        this.MaxNaklad = MaxNaklad;
        PrepravovanyNaklad = 0;
    }

    public void Naklad(int Naklad)
    {
        try
        {
            if (Naklad <= MaxNaklad)
                PrepravovanyNaklad = Naklad;
            else
                throw new Exception("Nemam volne misto pro naklad");
        }catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public override string ToString()
    {
        return base.ToString() + $"max naklad: {MaxNaklad}, prepravovany naklad: {PrepravovanyNaklad}";

    }
}

