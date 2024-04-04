using System;

namespace cv09
{
    public class Calculator
    {
        private enum Stav { ZadavaniCisel, ZadavaniOperatoru, Vysledek }
        private Stav _stav = Stav.ZadavaniCisel;
        private string _display = "0";
        private string _pamet = "";
        private string aktualni = "";
        private string ulozeno = "";

        public string Display
        {
            get { return _display; }
        }

        public string Pamet
        {
            get { return _pamet; }
        }

        public void Tlacitko(string tlacitko)
        {
            switch (tlacitko)
            {
                case "C":
                    aktualni = "0";
                    _stav = Stav.ZadavaniCisel;
                    break;
                case "CE":
                    aktualni = "";
                    break;
                case "+/-":
                    if (aktualni.StartsWith("-"))
                        aktualni = aktualni.Substring(1);
                    else
                        aktualni = "-" + aktualni;
                    break;
                case "←":
                    if (aktualni.Length > 1)
                        aktualni = aktualni.Substring(0, aktualni.Length - 1);
                    else
                        aktualni = "0";
                    break;
                case ".":
                    if (!aktualni.Contains("."))
                        aktualni += ".";
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    if (_stav == Stav.ZadavaniOperatoru)
                    {
                        ulozeno += aktualni + tlacitko;
                        aktualni = "";
                        _stav = Stav.ZadavaniCisel;
                    }
                    break;
                case "=":
                    if (_stav == Stav.ZadavaniOperatoru)
                    {
                        try
                        {
                            var result = Vypocti(ulozeno+aktualni);
                            aktualni = result.ToString();
                            _pamet = result.ToString();
                            ulozeno = "";
                            _stav = Stav.Vysledek;
                        }
                        catch (Exception ex)
                        {
                            ulozeno = "";
                            _display = "Error";
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                default:
                    if (aktualni == "0" || _stav == Stav.Vysledek)
                        aktualni = tlacitko;
                    else
                        aktualni += tlacitko;
                    _stav = Stav.ZadavaniOperatoru;
                    break;
            }

            _display = ulozeno + aktualni;
        }

        private double Vypocti(string rovnice)
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(rovnice, null));
        }
    }
}
