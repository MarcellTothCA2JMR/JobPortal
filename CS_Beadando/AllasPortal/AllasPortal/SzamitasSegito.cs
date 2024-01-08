using AllasPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllasPortal
{
    static class SzamitasSegito
    {
        /// <summary>
        /// Generál egy véletlen azonosítót
        /// </summary>
        /// <returns>Azonosító</returns>
        public static string AzonositoGenerator()
        {
            string biztonAzon = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                char c = (char)rnd.Next(65, 91);
                biztonAzon += c;
            }
            return biztonAzon;
        }

        /// <summary>
        /// Ha a munka megfelel a feltételeknek igennel tér vissza, ha nem, hamissal
        /// </summary>
        /// <param name="kiertekelendo">Vizsgált munka</param>
        /// <param name="kategoria">Kategoria checkbox</param>
        /// <param name="megnevezes">Megnevezes checkbox</param>
        /// <param name="fizetes">Fizetes checkbox</param>
        /// <param name="leiras">Leiras checkbox</param>
        /// <param name="kulcsszavak">Kulcsszavak checkbox</param>
        /// <param name="kat">Kategória</param>
        /// <param name="megnev">Megnevezés</param>
        /// <param name="fizu">Fizetés</param>
        /// <param name="leir">Leírás</param>
        /// <param name="kulcssz">Kulcsszavak</param>
        /// <param name="aktiv">Aktív-e checkbox</param>
        /// <returns>Megfelelő-e az állás</returns>
        public static bool SzuresFeltetelKiertekelo(Job kiertekelendo, CheckBox kategoria, CheckBox megnevezes, 
            CheckBox fizetes, CheckBox leiras, CheckBox kulcsszavak, ComboBox kat, TextBox megnev, 
            NumericUpDown fizu, TextBox leir, CheckedListBox kulcssz, CheckBox aktiv)
        {
            bool megfelelo = true;
            if (megfelelo && aktiv.Checked && kiertekelendo.Idopont.Date < DateTime.Now.Date)
            {
                megfelelo = false;
            }
            if (megfelelo && kategoria.Checked && kiertekelendo.Kategoria != kat.Text)
            {
                megfelelo = false;
            }
            if (megfelelo && megnevezes.Checked && kiertekelendo.Megnevezes.ToUpper() != megnev.Text.ToUpper())
            {
                megfelelo = false;
            }
            if (megfelelo && fizetes.Checked && kiertekelendo.Fizetes < (int)fizu.Value)
            {
                megfelelo = false;
            }
            if (megfelelo && leiras.Checked && !kiertekelendo.Leiras.ToUpper().Contains(leir.Text.ToUpper()))
            {
                megfelelo = false;
            }
            if (megfelelo && kulcsszavak.Checked)
            {
                string[] kszavak = kiertekelendo.Kulcsszavak.Trim().Split(", ");
                bool valamelyikbeBeletartozik = false;

                foreach (var ksz in kulcssz.CheckedItems)
                {
                    for (int i = 0; i < kszavak.Length; i++)
                    {
                        if (kszavak[i] == ksz.ToString())
                        {
                            valamelyikbeBeletartozik = true;
                            break;
                        }
                    }
                }
                megfelelo = valamelyikbeBeletartozik;
            }
            return megfelelo;
        }

        /// <summary>
        /// Checkedlistboxot Feltölti a munkák kulcsszavaival
        /// </summary>
        /// <returns>Kulcsszavak listája</returns>
        public static List<string> CheckedlistboxFeltolto()
        {
            List<string> kulcsszoLista = new List<string>();
            Adatbazis ab = new Adatbazis();
            foreach (Job munka in ab.Jobs)
            {
                string[] kulcsszavai = munka.Kulcsszavak.Trim().Split(", ");
                for (int i = 0; i < kulcsszavai.Length; i++)
                {
                    if (!kulcsszoLista.Contains(kulcsszavai[i]))
                    {
                        kulcsszoLista.Add(kulcsszavai[i]);
                    }
                }
            }
            kulcsszoLista.Sort();
            return kulcsszoLista;
        }

        /// <summary>
        /// Visszaadja a munka kategóriákat
        /// </summary>
        /// <returns>Kategóriák listája</returns>
        public static List<string> ComboboxFeltolto()
        {
            List<string> kategoriaLista = new List<string>();
            Adatbazis ab = new Adatbazis();
            foreach (Job munka in ab.Jobs)
            {
                if (!kategoriaLista.Contains(munka.Kategoria))
                {
                    kategoriaLista.Add(munka.Kategoria);
                }
            }
            kategoriaLista.Sort();
            return kategoriaLista;
        }

        /// <summary>
        /// Összegyűjti az adatokat a vonaldiagramhoz
        /// </summary>
        /// <param name="kiertekelendo">Vizsgált munka</param>
        /// <returns>Összegyűjtött adatok</returns>
        public static Dictionary<DateTime, int> VonalDiagramAdatgyujto(Job kiertekelendo)
        {
            Adatbazis ab = new Adatbazis();
            Dictionary<DateTime, int> masikAdatok = new Dictionary<DateTime, int>();
            DateTime intervallumKezd = kiertekelendo.FeladasiDatum.Date;
            DateTime intervallumVege;
            DateTime vege = kiertekelendo.Idopont.Date;
            DateTime most = DateTime.Now.Date;
            if (vege > most)
            {
                intervallumVege = most;
            }
            else
            {
                intervallumVege = vege;
            }
            while (intervallumKezd <= intervallumVege)
            {
                masikAdatok.Add(intervallumKezd, 0);
                intervallumKezd = intervallumKezd.AddDays(1);
            }
            foreach (Registration item in ab.Registrations)
            {
                if (item.HirdetesAzon == kiertekelendo.Id)
                {
                    masikAdatok[item.RegDatum.Date]++;
                }
            }
            return masikAdatok;
        }

        /// <summary>
        /// Megrajzolja a vonaldiagramot
        /// </summary>
        /// <param name="chart2">Chart, amire rajzol</param>
        /// <param name="kiertekelendo">Vizsgált állás</param>
        /// <returns>Chart feltötltve</returns>
        public static void VonalDiagramRajzolo(Chart chart2, Job kiertekelendo)
        {
            chart2.Top = 60;
            chart2.Left = 650;

            chart2.ChartAreas.Add(new ChartArea());
            Series ser = new Series();
            chart2.Series.Add(ser);
            ser.ChartType = SeriesChartType.Line;
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -60;

            Dictionary<DateTime, int> masikAdatok = VonalDiagramAdatgyujto(kiertekelendo);

            int diagramErtek = 0;
            foreach (KeyValuePair<DateTime, int> item in masikAdatok)
            {
                DataPoint dp = new DataPoint();
                diagramErtek += item.Value;
                dp.YValues[0] = diagramErtek;
                dp.AxisLabel = item.Key.ToShortDateString();
                ser.Points.Add(dp);
            }
        }

        /// <summary>
        /// Összegyűjti az adatokat a kördiagramhoz
        /// </summary>
        /// <returns>Összegyűjtött adatok a kördiagramhoz</returns>
        public static Dictionary<string, int> KorDiagramAdatgyujto()
        {
            Adatbazis ab = new Adatbazis();
            Dictionary<string, int> adatokSzamokban = new Dictionary<string, int>();
            foreach (Job item in ab.Jobs)
            {
                if (item.Idopont > DateTime.Now)
                {
                    if (adatokSzamokban.ContainsKey(item.Kategoria))
                    {
                        adatokSzamokban[item.Kategoria]++;
                    }
                    else
                    {
                        adatokSzamokban.Add(item.Kategoria, 1);
                    }
                }
            }
            return adatokSzamokban;
        }
        
        /// <summary>
        /// Kör diagramot rajzol a bejövő adatokból
        /// </summary>
        /// <param name="chart1">Diagram amire rajzol</param>
        public static void KorDiagramRajzolo(Chart chart1)
        {
            chart1.Top = 300;
            chart1.Left = 400;

            chart1.ChartAreas.Add(new ChartArea());
            Series ser = new Series();
            chart1.Series.Add(ser);
            ser.ChartType = SeriesChartType.Pie;

            Dictionary<string, int> adatokSzamokban = KorDiagramAdatgyujto();

            foreach (KeyValuePair<string, int> item in adatokSzamokban)
            {
                DataPoint dp = new DataPoint();
                dp.YValues[0] = item.Value;
                dp.Label = item.Key;
                ser.Points.Add(dp);
            }
        }

        /// <summary>
        /// A kiválasztott kategória alapján sorba rendezi az állásokat
        /// </summary>
        /// <param name="lb">Állásokat szerepeltető ListBox</param>
        /// <param name="cb">Kategóriát szerepeltető ComboBox</param>
        /// <returns>Állások rendezve</returns>
        public static List<Job> AllastRendezo(ListBox lb, ComboBox cb)
        {
            List<Job> lista = new List<Job>();
            foreach (Job item in lb.Items)
            {
                lista.Add(item);
            }

            var result = from x in lista orderby x.Id select x;
            if (cb.Text == "ABC (növekvő)")
            {
                result = from x in lista orderby x.Megnevezes select x;
            }
            else if(cb.Text == "Fizetés (csökkenő)")
            {
                result = from x in lista orderby x.Fizetes descending select x;
            }

            List<Job> listtt = new List<Job>();
            foreach (var item in result)
            {
                listtt.Add(item);
            }

            return listtt;
        }

        /// <summary>
        /// A kiválasztott kategória alapján sorba rendezi a dolgozókat
        /// </summary>
        /// <param name="lb">Dolgozókat szerepeltető ListBox</param>
        /// <param name="cb">Kategóriát szerepeltető ComboBox</param>
        /// <returns>Dolgozók rendezve</returns>
        public static List<Worker> DolgozotRendezo(ListBox lb, ComboBox cb)
        {
            List<Worker> lista = new List<Worker>();
            foreach (Worker item in lb.Items)
            {
                lista.Add(item);
            }
            
            var result = from x in lista orderby x.Id select x;
            if (cb.Text == "ABC (növekvő)")
            {
                result = from x in lista orderby x.VezNev,x.Kernev select x;
            }
            else if (cb.Text == "Szül. Dátum (növekvő)")
            {
                result = from x in lista orderby x.SzulEv select x;
            }

            List<Worker> listtt = new List<Worker>();
            foreach (var item in result)
            {
                listtt.Add(item);
            }

            return listtt;
        }

        /// <summary>
        /// Népszerűségi sorrendbe állítja a választható munkákat
        /// </summary>
        /// <param name="lb">Listbox, amelyben az munkák reprezentálódnak</param>
        /// <returns>Munka népszerűségi adatai</returns>
        public static Dictionary<int, int> NepszerusegMero(ListBox lb)
        {
            Adatbazis ab = new Adatbazis();
            Dictionary<int, int> adatok = new Dictionary<int, int>();
            foreach (Job j in lb.Items)
            {
                if (!adatok.ContainsKey(j.Id))
                {
                    adatok.Add(j.Id, 0);
                }
            }
            foreach (Registration item in ab.Registrations)
            {
                if (adatok.ContainsKey(item.HirdetesAzon))
                {
                    adatok[item.HirdetesAzon]++;
                }
            }
            adatok = adatok.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value);
            return adatok;
        }

        /// <summary>
        /// Igazzal tér vissza ha a munkás megfelel a munkára, hamissal ha nem
        /// </summary>
        /// <param name="munka">Munka</param>
        /// <param name="dolgozo">Dolgozó</param>
        /// <returns>Munkás megfelelő-e</returns>
        public static bool MegfelelEAMunkas(Job munka, Worker dolgozo)
        {
            bool result = false;

            string[] kulcsszavak = munka.Kulcsszavak.Split(", ");
            foreach (string ksz in kulcsszavak)
            {
                if(dolgozo.SzakmaiTapasztalatok.Contains(ksz))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
