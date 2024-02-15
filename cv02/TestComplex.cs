
using System.Diagnostics;
using System.Net;


class TestComplex
{
    const double Epsilon = 1E-6;

    public static void Test(Complex skutecna, Complex ocekavana, string test)
    {
        Complex chyba = new Complex();
        chyba = skutecna - ocekavana;
        Math.Abs(chyba.Realna);

        if ((Math.Abs(chyba.Realna) < Epsilon) && (Math.Abs(chyba.Imaginarni) < Epsilon))
        {
            Console.WriteLine(test + " .... OK");
        }
        else
            Console.WriteLine(test + " .... Chyba (Očekávaná: " + ocekavana + ", Skutečná: " + skutecna + ")");
    }
}

