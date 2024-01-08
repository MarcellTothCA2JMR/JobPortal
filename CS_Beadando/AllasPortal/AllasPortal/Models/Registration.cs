using System;
using System.Collections.Generic;

#nullable disable

namespace AllasPortal.Models
{
    public partial class Registration
    {
        public int Id { get; set; }
        public int HirdetesAzon { get; set; }
        public int PalyazoAzon { get; set; }
        public DateTime RegDatum { get; set; }

        public virtual Job HirdetesAzonNavigation { get; set; }
        public virtual Worker PalyazoAzonNavigation { get; set; }


        public Registration(int hirdetesazon, int palyazoazon, DateTime regdatum)
        {
            HirdetesAzon = hirdetesazon;
            PalyazoAzon = palyazoazon;
            RegDatum = regdatum;
        }

        public Registration()
        {
        }

        public override string ToString()
        {
            return $"{HirdetesAzon} -   { PalyazoAzon}  -   {RegDatum}";
        }
    }
}