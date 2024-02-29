

class Program
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

        Console.WriteLine("Pocet slov: " + str.PocetSlov());
        Console.WriteLine("Pocet radku: " + str.PocetRadku());
        Console.WriteLine("Pocet vet:" + str.PocetVet());
        Console.WriteLine("Nejdelsi slovo: " + string.Join(", ", str.NejdelsiSlova()));
        Console.WriteLine("Nejkratsi slovo: " + string.Join(", ", str.NejkratsiSlova()));
        Console.WriteLine("Nejcastejsi slovo: " + string.Join(", ", str.NejcastejsiSlovo()));
        Console.WriteLine("Setridena slova podle abecedy: \n" + string.Join(", ", str.Abecedne()));
    }
}