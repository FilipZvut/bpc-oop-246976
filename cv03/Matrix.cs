public class Matrix
{
    private double[,] matice;
    public Matrix(double[,] zadana)
    {
        try
        {
            if (zadana == null)
            {
                throw new ArgumentNullException("Zadana matice je null");
            }
            matice = zadana;
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static Matrix operator +(Matrix matA, Matrix matB)
    {
        try
        {
            double[,] Vysledek = new double[matA.matice.GetLength(0),matA.matice.GetLength(1)];
            
            for (int i = 0; i < matA.matice.GetLength(0); i++)
            {
                for (int j = 0; j < matA.matice.GetLength(1); j++)
                {
                   Vysledek[i, j] = matA.matice[i, j] + matB.matice[i, j];
                }
            }
            return new Matrix(Vysledek);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Nelze scitat, \n" + ex.Message);
            return matA;
        }
    }

    public static Matrix operator -(Matrix matA, Matrix matB)
    {
        try
        {
            double[,] Vysledek = new double[matA.matice.GetLength(0), matA.matice.GetLength(1)];

            for (int i = 0; i < matA.matice.GetLength(0); i++)
            {
                for (int j = 0; j < matA.matice.GetLength(1); j++)
                {
                    Vysledek[i, j] = matA.matice[i, j] - matB.matice[i, j];
                }
            }

            return new Matrix(Vysledek);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Nelze odečítat, \n" + ex.Message);
            return matA;
        }
    }
    public static Matrix operator *(Matrix matA, Matrix matB)
    {
        try
        {
            if (matA.matice.GetLength(1) != matB.matice.GetLength(0))           
                throw new InvalidOperationException("Špatný počet sloupců a řádků matic");
            

            int radky = matA.matice.GetLength(0);
            int sloupce = matB.matice.GetLength(1);
            double[,] vysledek = new double[radky, sloupce];

            
            for (int i = 0; i < radky; i++)
            {
                for (int j = 0; j < sloupce; j++)
                {
                    double soucet = 0;
                    for (int k = 0; k < sloupce; k++)
                    {
                        soucet += matA.matice[i, k] * matB.matice[k, j];
                    }
                    vysledek[i, j] = soucet;
                }
            }

            return new Matrix(vysledek);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Nelze násobit, \n"+ ex.Message);
            return matA;
        }
    }

    public static bool operator ==(Matrix matA, Matrix matB)
    {
        try
        {
            if(matA.matice.GetLength(0) != matB.matice.GetLength(0) || matA.matice.GetLength(1) != matB.matice.GetLength(1))
                return false;            

            for (int i = 0; i < matA.matice.GetLength(0); i++)
            {
                for (int j = 0; j < matA.matice.GetLength(1); j++)
                {
                    if (matA.matice[i, j] != matB.matice[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine("Nelze porovnávat, \n" + ex.Message);
            return false;
        }
    }
    public static bool operator !=(Matrix matA, Matrix matB)
    {
        return !(matA == matB);
    }
    public static Matrix operator -(Matrix matA)
    {
        try
        {
            double[,] Vysledek = new double[matA.matice.GetLength(0), matA.matice.GetLength(1)];
            for (int i = 0; i < matA.matice.GetLength(0); i++)
            {
                for (int j = 0; j < matA.matice.GetLength(1); j++)
                {
                    Vysledek[i, j] = matA.matice[i, j] * -1;
                }
            }
            return new Matrix(Vysledek);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Nelze provést, \n" + ex.Message);
        }
        return matA;
    }
    public override string ToString()
    {
        try
        {
            string vysledek = "\n";
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                for (int j = 0; j < matice.GetLength(1); j++)
                {

                    vysledek += matice[i, j] + " ";
                }
                vysledek += "\n";
            }
            return vysledek;
        }
        catch
        {
            return "null";
        }
    }
    public double Determinant()
    {
        try
        {
            double vysledek = 0;
            if (matice.GetLength(0)>3 ||  matice.GetLength(1)>3)
                throw new InvalidOperationException("Matice je větší než 3x3");
            if (matice.GetLength(0) != matice.GetLength(1))
                throw new InvalidOperationException("Matice není čtvercová");

            if(matice.GetLength(0) == 3)
            return matice[0, 0] * matice[1, 1] * matice[2, 2] + matice[0, 1] * matice[1, 2] * matice[2, 0] + matice[0, 2] * matice[1, 0] * matice[2, 1]
                  -matice[0, 2] * matice[1, 1] * matice[2, 0] - matice[0, 1] * matice[1, 0] * matice[2, 2] - matice[0, 0] * matice[1, 2] * matice[2, 1];

            if (matice.GetLength(0) == 2)
                return matice[0, 0] * matice[1, 1] - matice[1, 0] * matice[0, 1];
        }
        catch(Exception ex)
        {
            Console.WriteLine("Nelze vypocítat determinant, \n" + ex); 
        }
            return 0;
    }
} 
