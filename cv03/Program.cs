using System;
using System.Numerics;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        double[,] matA = { { 1, 2, 3 }, 
                           { 4, 5, 6 }, 
                           { 7, 8, 9 }};

        double[,] matB = { { 9, 8, 7 }, 
                           { 6, 5, 4 }, 
                           { 3, 2, 1 }};
        
        Matrix MaticeA = new Matrix(matA);
        Matrix MaticeB = new Matrix(matB);
        
        Console.WriteLine("Matice A:" + MaticeA);
        Console.WriteLine("Matice B:" + MaticeB);

        
        Console.WriteLine("Součet:" + (MaticeA + MaticeB));
        Console.WriteLine("Rozdíl:" + (MaticeA - MaticeB));
        Console.WriteLine("Součin:" + (MaticeA * MaticeB));
        Console.WriteLine("Unární operátor:" + (-MaticeA));

        Console.WriteLine("Porovnání:" + (MaticeA == MaticeB));
        Console.WriteLine("Nerovnost:" + (MaticeA != MaticeB));

        Console.WriteLine("Determinant matice A:" + MaticeA.Determinant());

        Console.WriteLine("\nTestování chyb:");
        
        MaticeA = null;
        Console.WriteLine(MaticeA + MaticeB);
        Console.WriteLine(MaticeA - MaticeB);

        MaticeA= new Matrix(null);
        Console.WriteLine(MaticeA * MaticeB);


    }
}
