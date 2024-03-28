public class RocniTeplota
{
    public int Rok;
    public List<double> MesicniTeploty;

    public RocniTeplota(int rok, List<double> mesicniTeploty)
    {
        Rok = rok;
        MesicniTeploty = mesicniTeploty;
    }
    public double MaxTeplota
    {
        get { return MesicniTeploty.Max(); }
    }
    public double MinTeplota
    {
        get { return MesicniTeploty.Min(); }
    }
    public double PrumRocniTeplota
    {
        get { return MesicniTeploty.Average(); }
    }
}

