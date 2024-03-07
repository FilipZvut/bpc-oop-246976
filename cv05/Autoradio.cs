
public class Autoradio
{
    private double naladenyKmitocet;
    private bool radioZapnuto;
    private Dictionary<int, double> RadioPredvolba = new();

    public double NaladenyKmitocet
    {
        get { return naladenyKmitocet; }
        set { naladenyKmitocet = value; }
    }

    public bool RadioZapnuto
    {
        get { return radioZapnuto; }
        set { radioZapnuto = value; }
    }

    public void NastavPredvolbu(int cislo, double kmitocet)
    {
        RadioPredvolba.Add(cislo, kmitocet);
    }

    public void PreladNaPredvolbu(int predvolba)
    {
        NaladenyKmitocet = RadioPredvolba[predvolba];
    }

    public override string ToString()
    {
        return $"Naladeny kmitocet: {NaladenyKmitocet}, Radio zapnuto: {RadioZapnuto}";
    }
}