using System;
using System.Collections.Generic;

#nullable disable

namespace AllasPortal.Models
{
    public partial class Job
    {
        public Job()
        {
            Registrations = new HashSet<Registration>();
        }

        public int Id { get; set; }
        public string Kategoria { get; set; }
        public string Megnevezes { get; set; }
        public int Fizetes { get; set; }
        public string Leiras { get; set; }
        public DateTime Idopont { get; set; }
        public string Kulcsszavak { get; set; }
        public string BiztAzon { get; set; }
        public DateTime FeladasiDatum { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }


        public Job(string kategoria, string megnevezes, int fizetes, string leiras, DateTime idopont, string kulcsszavak, string biztazon, DateTime feladasidatum)
        {
            Kategoria = kategoria;
            Megnevezes = megnevezes;
            Fizetes = fizetes;
            Leiras = leiras;
            Idopont = idopont;
            Kulcsszavak = kulcsszavak;
            BiztAzon = biztazon;
            FeladasiDatum = feladasidatum;
        }

        public override string ToString()
        {
            return $"{Id}   -   {BiztAzon}  -   {Kategoria} -   {Megnevezes}    -   {Fizetes}   -   {Idopont}";
        }
    }
}
