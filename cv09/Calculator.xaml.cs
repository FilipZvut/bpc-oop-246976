
using System.Windows;


public partial class Calculator
{
    private enum Stav
    {
        PrvniCislo,
        Operace,
        DruheCislo,
        Vysledek
    };

    private Stav _stav;
    private double _prvniCislo;
    private string? _operace;
    private double _druheCislo;

    public string Display { get; private set; }
    public string Pamet { get; private set; }

    public Calculator()
    {
        _stav = Stav.PrvniCislo;
        Display = "0";
        Pamet = "";
        
    }

    public void Tlacitko(string tlacitko)
    {
        switch (_stav)
        {
            case Stav.PrvniCislo:
                if (double.TryParse(tlacitko, out double cislo))
                {
                    if (Display == "0" && tlacitko != "0")
                        Display = tlacitko;
                    else
                        Display += tlacitko;
                }
                else if (tlacitko == ".")
                {
                    if (!Display.Contains("."))
                        Display += ".";
                }
                else if (tlacitko == "CE")
                {
                    Display = "0";
                }
                else if (tlacitko == "C")
                {
                    Display = "0";
                    Pamet = "";
                }
                else if (tlacitko == "M+")
                {
                    double hodnota;
                    if (double.TryParse(Display, out hodnota))
                        Pamet = hodnota.ToString();
                }
                else if (tlacitko == "M-")
                {
                    Pamet = "";
                }
                else if (tlacitko == "MRC")
                {
                    if (!string.IsNullOrEmpty(Pamet))
                        Display = Pamet;
                }
                else if (tlacitko == "+/-")
                {
                    if (!Display.Contains("-"))
                        Display = "-" + Display;
                    else
                        Display = Display.TrimStart('-');
                }
                else if (tlacitko == "=")
                {
                    // Ignorujeme, není aplikovatelné ve stavu PrvniCislo
                }
                else
                {
                    _operace = tlacitko;
                    _stav = Stav.Operace;
                }
                break;

            case Stav.Operace:
                if (tlacitko == "=")
                {
                    // Ignorujeme, není aplikovatelné ve stavu Operace
                }
                else
                {
                    if (double.TryParse(Display, out _prvniCislo))
                    {
                        Display = "0";
                        _stav = Stav.DruheCislo;
                        _operace = tlacitko;
                    }
                }
                break;

            case Stav.DruheCislo:
                if (double.TryParse(tlacitko, out double cislo2))
                {
                    if (Display == "0" && tlacitko != "0")
                        Display = tlacitko;
                    else
                        Display += tlacitko;
                }
                else if (tlacitko == ".")
                {
                    if (!Display.Contains("."))
                        Display += ".";
                }
                else if (tlacitko == "CE")
                {
                    Display = "0";
                }
                else if (tlacitko == "C")
                {
                    Display = "0";
                    Pamet = "";
                    _stav = Stav.PrvniCislo;
                }
                else if (tlacitko == "+/-")
                {
                    if (!Display.Contains("-"))
                        Display = "-" + Display;
                    else
                        Display = Display.TrimStart('-');
                }
                else if (tlacitko == "=")
                {
                    if (double.TryParse(Display, out _druheCislo))
                    {
                        double vysledek = SpocitejVysledek();
                        Display = vysledek.ToString();
                        Pamet = vysledek.ToString();
                        _stav = Stav.Vysledek;
                    }
                }
                break;

            case Stav.Vysledek:
                if (double.TryParse(tlacitko, out double cislo3))
                {
                    Display = tlacitko;
                    _stav = Stav.PrvniCislo;
                }
                else if (tlacitko == ".")
                {
                    Display = "0.";
                    _stav = Stav.PrvniCislo;
                }
                else if (tlacitko == "CE")
                {
                    Display = "0";
                    _stav = Stav.PrvniCislo;
                }
                else if (tlacitko == "C")
                {
                    Display = "0";
                    Pamet = "";
                    _stav = Stav.PrvniCislo;
                }
                else if (tlacitko == "M+")
                {
                    double hodnota;
                    if (double.TryParse(Display, out hodnota))
                        Pamet = hodnota.ToString();
                }
                else if (tlacitko == "M-")
                {
                    Pamet = "";
                }
                else if (tlacitko == "MRC")
                {
                    if (!string.IsNullOrEmpty(Pamet))
                        Display = Pamet;
                }
                else if (tlacitko == "+/-")
                {
                    if (!Display.Contains("-"))
                        Display = "-" + Display;
                    else
                        Display = Display.TrimStart('-');
                }
                else if (tlacitko == "=")
                {
                    // Ignorujeme, není aplikovatelné ve stavu Vysledek
                }
                else
                {
                    _operace = tlacitko;
                    _stav = Stav.Operace;
                }
                break;
        }
    }

    private double SpocitejVysledek()
    {
        switch (_operace)
        {
            case "+":
                return _prvniCislo + _druheCislo;
            case "-":
                return _prvniCislo - _druheCislo;
            case "×":
                return _prvniCislo * _druheCislo;
            case "÷":
                if (_druheCislo != 0)
                    return _prvniCislo / _druheCislo;
                else
                    throw new DivideByZeroException();
            default:
                throw new InvalidOperationException("Neplatná operace");
        }
    }
}
