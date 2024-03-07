
public class Program
{
    static void Main(string[] args)
    {

        Nakladni Nakladak = new(20, Auto.TypPaliva.Nafta, 100);
        Osobni Autobus = new(20, Auto.TypPaliva.Benzin, 80);
        
        Nakladak.Naklad(12);
        Nakladak.Natankuj(Auto.TypPaliva.Nafta, 20);

        Nakladak.Radio.NaladenyKmitocet = 98.6;

        Console.WriteLine(Nakladak.Radio+"\n");

        Nakladak.Radio.RadioZapnuto = true;
        Nakladak.Radio.NastavPredvolbu(1, 106.8);
        Nakladak.Radio.PreladNaPredvolbu(1);

        Console.WriteLine("Stav nakladniho auta:");
        Console.WriteLine(Nakladak);

        Autobus.Osoby(15);
        Autobus.Natankuj(Auto.TypPaliva.Benzin, 40);
        Autobus.Radio.RadioZapnuto = true;
        Autobus.Radio.NaladenyKmitocet = 89.5;

        Console.WriteLine("\nStav autobusu:");
        Console.WriteLine(Autobus);
        Console.WriteLine("\n");
        
        Autobus.Osoby(50);
        Nakladak.Naklad(50);
        Nakladak.Natankuj(Auto.TypPaliva.Benzin, 20);
        Autobus.Natankuj(Auto.TypPaliva.Benzin, 100);
        Autobus.Natankuj(Auto.TypPaliva.Nafta, 100);


    }
}