
public class Osobni : Auto 
{
    private int maxOsob;
    public int prepravovaneOsoby { private set; get; }

    public Osobni(int MaxOsob, TypPaliva Palivo, int VelikostNadrze) 
        : base(Palivo, VelikostNadrze)
    {
        maxOsob = MaxOsob;
        prepravovaneOsoby = 0;
    }
    public void Osoby(int PocetOsob)
    {
        try
        {
            if (PocetOsob <= maxOsob)
            {
                prepravovaneOsoby = PocetOsob;
            }
            else
            {
                throw new Exception("Nemam volne misto pro osoby");
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public override string ToString()
    {
        return base.ToString() + $"Max osob: {maxOsob}, Prepravovane osoby: {prepravovaneOsoby}";
    }

}


