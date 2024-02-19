using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

public class Matrix
{
    private double[,] matice;
    public Matrix(double[,] zadana)
    {
        try
        {
            matice = zadana;
            if (zadana == null)
            {
                throw new ArgumentNullException(nameof(zadana), "Matice nemůže být null");
            }
        }catch
        {
            Console.WriteLine("Nelze vytvořit, matice je null");
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
        catch
        {
            Console.WriteLine("Nelze scitat");
        }
        return matA;
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
        catch
        {
            Console.WriteLine("Nelze odečítat");
        }
        return matA;
    }
    public static Matrix operator *(Matrix matA, Matrix matB)
    {
        try
        {
            if (matA.matice.GetLength(1) != matB.matice.GetLength(0))
            {
                throw new InvalidOperationException("Špatný počet sloupců a řádků matic");
            }

            int radky = matA.matice.GetLength(0);
            int sloupce = matB.matice.GetLength(1);
            int finsloupce = matA.matice.GetLength(1); // Počet sloupců první matice je roven počtu řádků druhé matice

            // Inicializace výsledné matice
            double[,] vysledek = new double[radky, sloupce];

            // Násobení matic
            for (int i = 0; i < radky; i++)
            {
                for (int j = 0; j < sloupce; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < finsloupce; k++)
                    {
                        sum += matA.matice[i, k] * matB.matice[k, j];
                    }
                    vysledek[i, j] = sum;
                }
            }

            return new Matrix(vysledek);
        }
        catch
        {
            Console.WriteLine("Nelze násobit");
        }
        return matA;
    }

    public static bool operator ==(Matrix matA, Matrix matB)
    {
        try
        {
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
        catch
        {
            Console.WriteLine("Nelze porovnávat");
        }
        return false;
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
        catch
        {
            Console.WriteLine("Nelze provést");
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
            if (matice.GetLength(0)!=3 ||  matice.GetLength(1)!=3)
                throw new InvalidOperationException("Matice není 3x3");

            return matice[0, 0] * matice[1, 1] * matice[2, 2] +
                  matice[0, 1] * matice[1, 2] * matice[2, 0] +
                  matice[0, 2] * matice[1, 0] * matice[2, 1] -
                  matice[0, 2] * matice[1, 1] * matice[2, 0] -
                  matice[0, 1] * matice[1, 0] * matice[2, 2] -
                  matice[0, 0] * matice[1, 2] * matice[2, 1];
        }
        catch 
        {
            Console.WriteLine("Nelze vypocítat"); 
            return 0;
        }
    }
} 