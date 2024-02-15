using System;

class Program
{
    static void Main(string[] args)
    {
        Complex c1 = new Complex(3, 4);
        Complex c2 = new Complex(1, 2);

        Console.WriteLine($"c1 = {c1}");
        Console.WriteLine($"c2 = {c2}");
        Console.WriteLine($"\nc1 + c2 = {c1 + c2}");
        Console.WriteLine($"c1 - c2 = {c1 - c2}");
        Console.WriteLine($"c1 * c2 = {c1 * c2}");
        Console.WriteLine($"c1 / c2 = {c1 / c2}");
        Console.WriteLine($"Sdružené číslo k c1 = {c1.Conjugate()}");
        Console.WriteLine($"Modul c1 = {c1.Modulus()}");
        Console.WriteLine($"Argument c1 = {c1.Argument()}");

        Console.WriteLine($"Jsou c1 a c2 rovna? {c1 == c2}");
        Console.WriteLine($"Jsou c1 a c2 různá? {c1 != c2}");

        
        Console.WriteLine("\n...\n");
        

        Console.WriteLine("Začátek testování:");

        TestComplex.Test(c1 + c2, new Complex(4, 6), "Součet");
        TestComplex.Test(c1 - c2, new Complex(2, 2), "Rozdíl");
        TestComplex.Test(c1 * c2, new Complex(3, 8), "Součin");
        TestComplex.Test(c1 / c2, new Complex(3, 2), "Podíl");
        TestComplex.Test(-c1, new Complex(-3, -4), "Operátor -");
        TestComplex.Test(c1.Conjugate(), new Complex(3, -4), "Komplexně sdružené");
        
    }
}