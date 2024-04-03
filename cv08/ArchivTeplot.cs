public class ArchivTeplot
{   
    public SortedDictionary<int, RocniTeplota> _archiv;

    public ArchivTeplot()
    {
        _archiv = new SortedDictionary<int, RocniTeplota>();
    }

    public void Load(string path)
    {
        _archiv.Clear();
        
        foreach(string radek in File.ReadLines(path))
        {
            string[] data = radek.Split(':', ';');
            int rok = int.Parse(data[0]);
            List<double> teploty = data.Skip(1).Select(double.Parse).ToList();
            _archiv.Add(rok, new RocniTeplota(rok, teploty));
        }

    }

    public void Save(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach(var hodnoty in _archiv.Values) 
            {
                sw.Write(hodnoty.Rok + ": ");
                sw.WriteLine(string.Join("; ",hodnoty.MesicniTeploty.Select(T => T.ToString("0.0"))));
            }
        }
        Console.WriteLine("Ulozeno");
    }

    public void Kalibrace(double konstanta)
    {
        foreach (var rocniTeplota in _archiv)
        {
            for (int i = 0; i < rocniTeplota.Value.MesicniTeploty.Count; i++)
            {
                rocniTeplota.Value.MesicniTeploty[i] += konstanta;
            }
        }
    }

    public RocniTeplota Vyhledej(int rok)
    {
        if (_archiv.ContainsKey(rok))
            return _archiv[rok];
        else
            return null;
    }

    public void TiskTeplot()
    {
        foreach (var rocniteploty in _archiv)
        {
            Console.Write(rocniteploty.Key + ":   ");
            Console.Write(string.Join("   ", rocniteploty.Value.MesicniTeploty.Select(T => T.ToString("0.0"))));
            Console.WriteLine();
        }
        Console.WriteLine() ;
    }

    public void TiskPrumernychRocnichTeplot()
    {
        foreach (var rocniteploty in _archiv)
        {
            Console.Write(rocniteploty.Key + ":   ");
            Console.Write(rocniteploty.Value.PrumRocniTeplota.ToString("0.0"));
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void TiskPrumernychMesicnichTeplot()
    {
        for (int mesic = 0; mesic < 12; mesic++)
        {
            double prum = 0;
            foreach (var rocniTeplota in _archiv.Values)
            {
                prum += rocniTeplota.MesicniTeploty[mesic];
            }
            prum = prum / _archiv.Count;
            Console.WriteLine($"Mesic {mesic + 1}:\t {prum.ToString("0.0")} °C");
        }
        Console.WriteLine();
    }
}

