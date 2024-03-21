public class Program
{
    static void Main(string[] args)
    {
        int[] ints = { 1, 3, 5, 7, 9 };
        string[] strings = { "atest", "test1", "test3", "ztest" };
        
        Kruh[] kruhy = { new Kruh(10),
                         new Kruh(20),
                         new Kruh(30),
                         new Kruh(5),
                         new Kruh(15) };

        Obdelnik[] obdelniky = { new Obdelnik(2, 5), 
                                 new Obdelnik(3, 10), 
                                 new Obdelnik(5, 5) };

        Ctverec[] ctverce = { new Ctverec(5), 
                              new Ctverec(2), 
                              new Ctverec(10) };

        Elipsa[] elipsy = { new Elipsa(5, 4), 
                            new Elipsa(2, 6), 
                            new Elipsa(8, 10) };

        Trojuhelnik[] trojuhelniky = { new Trojuhelnik(5, 4, 3), 
                                       new Trojuhelnik(4, 5, 5), 
                                       new Trojuhelnik(3, 3, 3) };

        Objekt2D[] objekty2d = { new Kruh(1), 
                                 new Obdelnik(50, 5), 
                                 new Ctverec(5), 
                                 new Elipsa(10, 7), 
                                 new Trojuhelnik(4, 3, 2) };

        Console.WriteLine("Int:");
        Console.WriteLine($"Nejvetší int: {Extremy.Nejvetsi(ints)}");
        Console.WriteLine($"Nejmenší int: {Extremy.Nejmensi(ints)}");

        Console.WriteLine("\nString:");
        Console.WriteLine($"Abecedne posledni String: {Extremy.Nejvetsi(strings)}");
        Console.WriteLine($"Abecedne prvni String: {Extremy.Nejmensi(strings)}");

        Console.WriteLine("\nKruh:");
        Console.WriteLine($"Nejvetsi kruh: {Extremy.Nejvetsi(kruhy)}");
        Console.WriteLine($"Nejmensi kruh: {Extremy.Nejmensi(kruhy)}");

        Console.WriteLine("\nObdelnik:");
        Console.WriteLine($"Nejvetsi obdelnik: {Extremy.Nejvetsi(obdelniky)}");
        Console.WriteLine($"Nejmensi obdelnik: {Extremy.Nejmensi(obdelniky)}");

        Console.WriteLine("\nCtverec:");
        Console.WriteLine($"Nejvetsi ctverec : {Extremy.Nejvetsi(ctverce)}");
        Console.WriteLine($"Nejmensi ctverec : {Extremy.Nejmensi(ctverce)}");

        Console.WriteLine("\nElipsa:");
        Console.WriteLine($"Nejvetsi elipsa : {Extremy.Nejvetsi(elipsy)}");
        Console.WriteLine($"Nejmensi elipsa : {Extremy.Nejmensi(elipsy)}");
        
        Console.WriteLine("\nTrojuhelnik");
        Console.WriteLine($"Nejvetsi trojuhelnik : {Extremy.Nejvetsi(trojuhelniky)}");
        Console.WriteLine($"Nejmensi trojuhelnik : {Extremy.Nejmensi(trojuhelniky)}");
        
        Console.WriteLine("\nObjekty:");
        Console.WriteLine($"Nejvetsi plocha objektu {Extremy.Nejvetsi(objekty2d).GetType()}: {Extremy.Nejvetsi(objekty2d)}");
        Console.WriteLine($"Nejmensi plocha objektu {Extremy.Nejmensi(objekty2d).GetType()}: {Extremy.Nejmensi(objekty2d)}");
        
        int[] filtr = ints.Where(k => k>=4 && k<=8).ToArray();
        Console.WriteLine("\nVyfiltrovaný list intu je:" + string.Join("," , filtr));

                
    }
}