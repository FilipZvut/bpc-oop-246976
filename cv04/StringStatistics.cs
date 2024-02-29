using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

class StringStatistics
{
    string str;
    char[] mezera = { ' ', '\n', ',', '!', '.', '?', ')', '(' };
    public StringStatistics(string StrZadavany)
    {
        str = StrZadavany;
    }

    public int PocetSlov()
    {
        int pocet = 1;
        foreach (char c in str)
        {
            if (c == ' ' || c == '\n')
            {
                pocet++;
            }
        }
        return pocet;
    }
    public int PocetRadku()
    {
        int pocet = 1;
        foreach (char c in str)
        {
            if (c == '\n')
            {
                pocet++;
            }
        }
        return pocet;
    }
    public int PocetVet()
    {
        bool znamenko = false;
        int pocet = 1;
        foreach (char c in str)
        {
            if (c == '.' || c == '!' || c == '?')
            {
                znamenko = true;
            }

            if (znamenko && char.IsUpper(c))
            {
                pocet++;
                znamenko = false;
            }
            else if (znamenko && char.IsLower(c))
            {
                znamenko = false;
            }
        }

        return pocet;
    }
    public string[] NejdelsiSlova()
    {
        string[] slova = str.Split(mezera, StringSplitOptions.RemoveEmptyEntries);
        int max = slova.Max(word => word.Length);
        return slova.Where(word => word.Length == max).ToArray();
    }
    public string[] NejkratsiSlova()
    {
        string[] slova = str.Split(mezera, StringSplitOptions.RemoveEmptyEntries);
        int min = slova.Min(slovo => slovo.Length);
        return slova.Where(slovo => slovo.Length == min).ToArray();
    }

    public string[] NejcastejsiSlovo()
    {
        string[] slova = str.Split(mezera, StringSplitOptions.RemoveEmptyEntries);
        var ListSlov = new Dictionary<string, int>();
        foreach (string slovo in slova)
        {
            if (ListSlov.ContainsKey(slovo))
                ListSlov[slovo]++;
            else
                ListSlov[slovo] = 1;
        }
        int maxPocet = ListSlov.Max(pocetslov => pocetslov.Value);
        return ListSlov.Where(pocetslov => pocetslov.Value == maxPocet).Select(pocetslov => pocetslov.Key).ToArray();
    }    
    public string[] Abecedne()
    {
        var slova = str.Split(mezera, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(slova);
        return slova;
    }
}

