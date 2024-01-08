using AllasPortal.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllasPortal
{
    public partial class JelentkezesekAttekintese : Form
    {
        Job kiertekelendo;
        public JelentkezesekAttekintese(Job munka)
        {
            InitializeComponent();
            kiertekelendo = munka;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kiertekelendo.BiztAzon != textBox1.Text)
            {
                MessageBox.Show("A megadott biztonsági kód helytelen!", "Sikertelen kiiratás!", MessageBoxButtons.OK);
                return;
            }

            listBox1.Items.Clear();
            Adatbazis ab = new Adatbazis();

            foreach (Registration reg in ab.Registrations)
            {
                if (reg.HirdetesAzon == kiertekelendo.Id)
                {
                    listBox1.Items.Add(reg);
                }
            }

            Chart chart2 = new Chart();
            foreach (var item in Controls)
            {
                if (item.GetType() == chart2.GetType())
                {
                    Controls.Remove((Control)item);
                }
            }
            SzamitasSegito.VonalDiagramRajzolo(chart2, kiertekelendo);
            Controls.Add(chart2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kiertekelendo.BiztAzon != textBox1.Text)
            {
                MessageBox.Show("A megadott biztonsági kód helytelen!", "Sikertelen kiiratás!", MessageBoxButtons.OK);
                return;
            }

            listBox2.Items.Clear();
            Adatbazis ab = new Adatbazis();
            List<int> jelentkezett = new List<int>();
            foreach (Registration reg in ab.Registrations)
            {
                if (reg.HirdetesAzon == kiertekelendo.Id && !(jelentkezett.Contains(reg.PalyazoAzon)))
                {
                    jelentkezett.Add(reg.PalyazoAzon);
                }
            }

            int szamuk = 0;
            foreach (Worker w in ab.Workers)
            {
                if(!(jelentkezett.Contains(w.Id)) && SzamitasSegito.MegfelelEAMunkas(kiertekelendo, w))
                {
                    listBox2.Items.Add(w);
                    szamuk++;
                }
            }
            if(szamuk==0)
            {
                MessageBox.Show("Nincs az adatbázisban további ember, aki megfelelhet!", "Sikertelen kiiratás!", MessageBoxButtons.OK);
            }
        }
    }
}
