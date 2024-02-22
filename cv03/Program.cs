class Program
{
    static void Main()
    {
        double[,] matA = { { 8, 5, 9 }, 
                           { 7, 9, 10 }, 
                           { 8, 1, 2 }};

        double[,] matB = { {10, 3, 2 }, 
                           { 7, 8, 5 }, 
                           { 1, 2, 2 }};
        
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
