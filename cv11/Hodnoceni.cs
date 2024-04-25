using System;

namespace EFCore
{
    public class Hodnoceni
    {
        public int ID_studenta { get; set; }
        public string Zkratka_predmetu { get; set; }
        public DateTime Datum_hodnoceni { get; set; }
        public double? hodnoceni { get; set; }
    }
}
