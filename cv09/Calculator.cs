using System;

namespace cv09
{
    public class Calculator
    {
        private enum Stav { ZadavaniCisel, ZadavaniOperatoru, Vysledek }
        private Stav _stav = Stav.ZadavaniCisel;
        private string _display = "0";
        private string _pamet = "";

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
                    _display = "0";
                    _stav = Stav.ZadavaniCisel;
                    break;
                case "+/-":
                    if (_display.StartsWith("-"))
                        _display = _display.Substring(1);
                    else
                        _display = "-" + _display;
                    break;
                case "CE":
                    if (_display.Length > 1)
                        _display = _display.Substring(0, _display.Length - 1);
                    else
                        _display = "0";
                    break;
                case ".":
                    if (!_display.Contains("."))
                        _display += ".";
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    _display = _display + tlacitko;
                    _stav = Stav.ZadavaniCisel;
                    break;
                case "=":
                    if (_stav == Stav.ZadavaniCisel)
                    {
                        try
                        {
                            var result = Evaluate(_pamet + " " + _display);
                            _display = result.ToString();
                            _pamet = "";
                            _stav = Stav.Vysledek;
                        }
                        catch (Exception ex)
                        {
                            _display = "Error";
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                default:
                    if (_display == "0" || _stav == Stav.Vysledek)
                        _display = tlacitko;
                    else
                        _display += tlacitko;
                    _stav = Stav.ZadavaniCisel;
                    break;
            }
        }

        private double Evaluate(string expression)
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(expression, null));
        }
    }
}
