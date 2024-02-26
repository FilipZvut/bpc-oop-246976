class program
{
    static void Main()
    {
        string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
                             + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                             + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                             + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                             + "posledni veta!";

        StringStatistics str = new(testovaciText);
        Console.WriteLine(testovaciText+"\n");

        Console.WriteLine(str.PocetSlov());
        Console.WriteLine(str.PocetRadku());
        Console.WriteLine(str.PocetVet());
        Console.WriteLine(string.Join(", ", str.NejdelsiSlova()));
        Console.WriteLine(string.Join(", " , str.NejkratsiSlova()));
        Console.WriteLine(str.NejcastejsiSlovo());
    }
}