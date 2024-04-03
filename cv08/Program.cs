class Program
{
    static void Main(string[] args)
    {
        ArchivTeplot archiv = new ArchivTeplot();
        archiv.Load("teploty.txt");
    
        Console.WriteLine("Původní teploty:");
        archiv.TiskTeplot();
    
        Console.WriteLine("Tisk prumernych rocnich teplot:");
        archiv.TiskPrumernychRocnichTeplot();

        Console.WriteLine("Tisk prumernych mesicnich teplot:");
        archiv.TiskPrumernychMesicnichTeplot();



        archiv.Kalibrace(-0.1);
        Console.WriteLine("Teploty po kalibraci:");
        archiv.TiskTeplot();
    
        archiv.Save("kalibrovane_teploty.txt");
        Console.WriteLine("Data byla uložena do souboru 'kalibrovane_teploty.txt'.");
    }

}