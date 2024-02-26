using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

class StringStatistics
{
    string str;
    public StringStatistics(string StrZadavany)
    {
        str = StrZadavany;
    }

    public int PocetSlov()
    {
        int pocet = 1;
        foreach (char c in str)
        {
            if (c == ' '|| c=='\n')
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
        bool znamenko=false;
        int pocet = 1;
        foreach (char c in str)
        {
            if(c == '.' || c == '!' || c == '?')
            {
                znamenko=true;
            }

            if(znamenko&& char.IsUpper(c))
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
        var slova = str.Split(' ', '\n');
        int max = slova.Max(word => word.Length);
        return slova.Where(word => word.Length == max).ToArray();
    }
    public string[] NejkratsiSlova()
    {
        var slova = str.Split(' ', '\n');
        int min = slova.Min(word => word.Length);
        return slova.Where(word => word.Length == min).ToArray();
    }
    public string NejcastejsiSlovo()
    {
        var slova = str.Split(' ', '\n');
        var nejvicslov = slova.Max(word => word.Length);
        return slova.First(word => word.Length == nejvicslov);

    }
}

