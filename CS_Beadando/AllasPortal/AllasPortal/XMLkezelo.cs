using AllasPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AllasPortal
{
    static class XMLkezelo
    {
        public static List<Job> Beolvasas(string fileNev)
        {
            MunkaLista beolvasott = new MunkaLista();
            List<Job> munkakListaja = new List<Job>();
            try
            {
                if (File.Exists(fileNev))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(MunkaLista));
                    using (StreamReader sr = new StreamReader(fileNev))
                    {
                        beolvasott = (MunkaLista)xs.Deserialize(sr);
                    }

                    foreach (MunkaXML item in beolvasott.Munkak)
                    {
                        Job j = new Job();
                        j.Kategoria = item.Kategoria;
                        j.Megnevezes = item.Megnevezes;
                        j.Fizetes = item.Fizetes;
                        j.Leiras = item.Leiras;
                        j.Idopont = DateTime.Now.AddDays(30);
                        j.Kulcsszavak = item.Kulcsszavak;
                        j.BiztAzon = SzamitasSegito.AzonositoGenerator();
                        j.FeladasiDatum = DateTime.Now;
                        munkakListaja.Add(j);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return munkakListaja;
        }

        public static void Kiiras(List<Job> munka, string fileNev)
        {
            MunkaLista ml = new MunkaLista();
            foreach (Job item in munka)
            {
                MunkaXML j = new MunkaXML();
                j.Kategoria = item.Kategoria;
                j.Megnevezes = item.Megnevezes;
                j.Fizetes = item.Fizetes;
                j.Leiras = item.Leiras;
                j.Idopont = item.Idopont;
                j.Kulcsszavak = item.Kulcsszavak;
                j.BiztAzon = item.BiztAzon;
                j.FeladasiDatum = item.FeladasiDatum;
                ml.Munkak.Add(j);
            }

            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(MunkaLista));
                using (StreamWriter sw = new StreamWriter(fileNev))
                {
                    xs.Serialize(sw, ml);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
