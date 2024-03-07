public class Program
{
    static void Main(string[] args)
    {
        Nakladni nakladak = new (3, Auto.TypPaliva.Benzin, 100);
        nakladak.Naklad(2);
        nakladak.Radio.RadioZapnuto = true;

        Console.WriteLine(nakladak);
    }
}