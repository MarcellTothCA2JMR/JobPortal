using System;
using System.Collections.Generic;

#nullable disable

namespace AllasPortal.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Registrations = new HashSet<Registration>();
        }

        public int Id { get; set; }
        public string VezNev { get; set; }
        public string Kernev { get; set; }
        public int SzulEv { get; set; }
        public string Vegzettseg { get; set; }
        public string Munkahelyek { get; set; }
        public string SzakmaiTapasztalatok { get; set; }
        public string TelSzam { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }


        public Worker(string veznev, string kernev, int szulev, string vegzettseg, string munkahelyek, string szakmaitapasztalatok, string telszam)
        {
            VezNev = veznev;
            Kernev = kernev;
            SzulEv = szulev;
            Vegzettseg = vegzettseg;
            Munkahelyek = munkahelyek;
            SzakmaiTapasztalatok = szakmaitapasztalatok;
            TelSzam = telszam;
        }

        public override string ToString()
        {
            return $"{Id}   -   {VezNev}    -   {Kernev}    -   {SzulEv}    -   {Vegzettseg}   -   {SzakmaiTapasztalatok}  -   {TelSzam}";
        }
    }
}
