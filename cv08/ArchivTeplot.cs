public class ArchivTeplot
{   
    public SortedDictionary<int, RocniTeplota> _archiv;

    public ArchivTeplot()
    {
        _archiv = new();
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

    public void Kalibrace

}