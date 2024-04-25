using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new VyukaContext())
            {
                // Naplnění databáze vzorovými daty
                NaplnDatabazi(db);

                // Vytvoření dotazu pro vypsání předmětů spolu s počty zapsaných studentů
                var vysledky = from predmet in db.Predmety
                               join zapsani in db.Zapsani.GroupBy(z => z.Zkratka_predmetu).Select(g => new { Zkratka_predmetu = g.Key, PocetStudentu = g.Count() })
                               on predmet.Zkratka equals zapsani.Zkratka_predmetu into predmetZapsani
                               from item in predmetZapsani.DefaultIfEmpty()
                               orderby item.PocetStudentu descending
                               select new { predmet.Nazev, PocetStudentu = item.PocetStudentu};

                Console.WriteLine("Předměty s počtem zapsaných studentů:");
                foreach (var item in vysledky)
                {
                    Console.WriteLine($"{item.Nazev}: {item.PocetStudentu}");
                }

                // Vypsání předmětů spolu s průměrnou známkou
                var prumernaZnamka = from predmet in db.Predmety
                                     join hodnoceni in db.Hodnoceni
                                     on predmet.Zkratka equals hodnoceni.Zkratka_predmetu into predmetHodnoceni
                                     select new
                                     {
                                         Nazev = predmet.Nazev,
                                         PrumernaZnamka = predmetHodnoceni.Average(h => h.hodnoceni)
                                     };

                Console.WriteLine("Předměty s průměrnou známkou:");
                foreach (var item in prumernaZnamka)
                {
                    Console.WriteLine($"{item.Nazev}: {item.PrumernaZnamka}");
                }

                // Získání studentů předmětu a předmětů studenta
                var studentId = 1;
                var predmetId = "Matematika";

                var studentiPredmetu = StudentiPredmetu(db, predmetId);
                var predmetyStudenta = PredmetyStudenta(db, studentId);

                Console.WriteLine("Studenti předmětu:");
                foreach (var student in studentiPredmetu)
                {
                    Console.WriteLine($"{student.Jmeno} {student.Prijmeni}");
                }

                Console.WriteLine("Předměty studenta:");
                foreach (var predmet in predmetyStudenta)
                {
                    Console.WriteLine($"{predmet.Nazev}");
                }
            }
        }

        static void NaplnDatabazi(VyukaContext db)
        {
            if (!db.Studenti.Any())
            {
                db.Studenti.Add(new Student { Jmeno = "Jan", Prijmeni = "Novák", DatumNarozeni = new DateTime(2000, 5, 10) });
                db.Studenti.Add(new Student { Jmeno = "Petr", Prijmeni = "Svoboda", DatumNarozeni = new DateTime(1999, 9, 15) });
                db.Studenti.Add(new Student { Jmeno = "Marie", Prijmeni = "Nováková", DatumNarozeni = new DateTime(2001, 2, 20) });

                db.SaveChanges();
            }

            if (!db.Predmety.Any())
            {
                db.Predmety.Add(new Predmet { Zkratka = "MAT", Nazev = "Matematika" });
                db.Predmety.Add(new Predmet { Zkratka = "ANG", Nazev = "Angličtina" });
                db.Predmety.Add(new Predmet { Zkratka = "FYZ", Nazev = "Fyzika" });

                db.SaveChanges();
            }

            if (!db.Hodnoceni.Any())
            {
                db.Hodnoceni.Add(new Hodnoceni { ID_studenta = 1, Zkratka_predmetu = "MAT", Datum_hodnoceni = new DateTime(2023, 5, 20), hodnoceni = 90 });
                db.Hodnoceni.Add(new Hodnoceni { ID_studenta = 1, Zkratka_predmetu = "MAT", Datum_hodnoceni = new DateTime(2023, 6, 15), hodnoceni = 85 });
                db.Hodnoceni.Add(new Hodnoceni { ID_studenta = 2, Zkratka_predmetu = "MAT", Datum_hodnoceni = new DateTime(2023, 6, 1), hodnoceni = 75 });
                db.Hodnoceni.Add(new Hodnoceni { ID_studenta = 2, Zkratka_predmetu = "ANG", Datum_hodnoceni = new DateTime(2023, 5, 25), hodnoceni = 80 });
                db.Hodnoceni.Add(new Hodnoceni { ID_studenta = 3, Zkratka_predmetu = "FYZ", Datum_hodnoceni = new DateTime(2023, 6, 10), hodnoceni = 88 });

                db.SaveChanges();
            }

            if (!db.Zapsani.Any())
            {
                db.Zapsani.Add(new Zapsani { ID_studenta = 1, Zkratka_predmetu = "MAT" });
                db.Zapsani.Add(new Zapsani { ID_studenta = 1, Zkratka_predmetu = "ANG" });
                db.Zapsani.Add(new Zapsani { ID_studenta = 2, Zkratka_predmetu = "MAT" });
                db.Zapsani.Add(new Zapsani { ID_studenta = 2, Zkratka_predmetu = "FYZ" });
                db.Zapsani.Add(new Zapsani { ID_studenta = 3, Zkratka_predmetu = "FYZ" });

                db.SaveChanges();
            }
        }

        static IQueryable<Student> StudentiPredmetu(VyukaContext db, string predmetZkratka)
        {
            return from zapsani in db.Zapsani
                   where zapsani.Zkratka_predmetu == predmetZkratka
                   join Student in db.Studenti on zapsani.ID_studenta equals Student.Id
                   select Student;
        }

        static IQueryable<Predmet> PredmetyStudenta(VyukaContext db, int studentId)
        {
            return from zapsani in db.Zapsani
                   where zapsani.ID_studenta == studentId
                   join predmet in db.Predmety on zapsani.Zkratka_predmetu equals predmet.Zkratka
                   select predmet;
        }
    }
}
