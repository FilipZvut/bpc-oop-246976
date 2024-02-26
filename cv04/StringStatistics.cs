using System.Security.Cryptography.X509Certificates;

class StringStatistics
{
    string str;
    public StringStatistics(string strstats)
    {
        str = strstats;
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
    public string NejdelsiSlovo()
    {
        string nejdelsi = "";
        string slovo = "";
        int pismena = 0;
        
        foreach (char c in str)
        {
            slovo += c;
            pismena++;
            if (c == ' ' || c=='!' || c=='.' || c=='?' )
            {
                if(pismena < slovo.Length)
                    nejdelsi = slovo;

                slovo = "";
                pismena = 0;
            }
        }
        return nejdelsi;
    }
}

