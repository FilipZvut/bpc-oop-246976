using System.Data;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        double plocha = 0;
        double povrch = 0;
        double objem = 0;


        GrObjekt[] Objekty = new GrObjekt[]
        {
            new Valec(3, 10),
            new Trojuhelnik(3, 5, 6),
            new Obdelnik(4, 10),
            new Kvadr(5, 4, 3),
            new Kruh(10),
            new Koule(20),
            new Jehlan(5,3,4),
            new Elipsa(10,15)
        };

        foreach (var objekt in Objekty)
        {
            objekt.Kresli();
            if (objekt is Objekt2D)
            {
                plocha += ((Objekt2D)objekt).SpoctiPlochu();
            }
            else
            {
                objem += ((Objekt3D)objekt).SpoctiObjem();
                povrch += ((Objekt3D)objekt).SpoctiPovrch();
            }
        }
        Console.WriteLine($"Celkova plocha je {plocha}, celkovy objem je {objem}, celkovy povrch je {povrch}");
        Console.ReadKey();
    }
}