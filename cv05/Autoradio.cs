
public class Autoradio
{
    private float naladenyKmitocet;
    private bool radioZapnuto;
    private Dictionary<int, float> RadioPredvolba = new();

    public float NaladenyKmitocet
    {
        get { return naladenyKmitocet; }
        set { naladenyKmitocet = value; }
    }

    public bool RadioZapnuto
    {
        get { return radioZapnuto; }
        set { radioZapnuto = value; }
    }

    public void NastavPredvolbu(int cislo, float kmitocet)
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