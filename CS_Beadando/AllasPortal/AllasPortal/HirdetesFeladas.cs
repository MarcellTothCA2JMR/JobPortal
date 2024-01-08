using AllasPortal.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AllasPortal
{
    public partial class HirdetesFeladas : Form
    {
        string[] kategoriaNevek = { "Fizikai", "Irodai", "IT, programozás", "Vendéglátás", "Turisztikai", "Pénzügyi", "HR" };
        string biztonAzon = SzamitasSegito.AzonositoGenerator();
        public HirdetesFeladas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(cbKat.Items.Contains(cbKat.Text)))
            {
                MessageBox.Show("A választható kategóriák között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Biztosan hozzá szeretné adni ezt az állást?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            biztonAzon = SzamitasSegito.AzonositoGenerator();
            Job job = new Job(cbKat.Text, tbMegnev.Text, (int)nudFizu.Value, tbLeir.Text, DateTime.Now.AddDays(30), tbKulcsszavak.Text, biztonAzon, DateTime.Now);
            
            Adatbazis ab = new Adatbazis();
            ab.Jobs.Add(job);
            ab.SaveChanges();
            MessageBox.Show("Az állás sikeresen hozzá lett adva!", "Sikeres kísérlet!", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan szeretne file-ból beolvasni egy vagy több állást?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            string beolvasandoFajl;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    beolvasandoFajl = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("A beolvasási műveletet megszakította!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                    return;
                }
            }
            try
            {
                List<Job> ujAllasLista = XMLkezelo.Beolvasas(beolvasandoFajl);
                Adatbazis ab = new Adatbazis();
                foreach (Job item in ujAllasLista)
                {
                    ab.Jobs.Add(item);
                }
                ab.SaveChanges();
                MessageBox.Show("A beolvasás sikeresen megtörtént!", "Sikeres kísérlet!", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("A beolvasás közben hiba történt!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!cbKat.Items.Contains(cbKat.Text))
            {
                MessageBox.Show("A választható kategóriák között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Biztosan szeretné file-ba kiírni az állást?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            Job ujMunka = new Job(cbKat.Text, tbMegnev.Text, (int)nudFizu.Value, tbLeir.Text, DateTime.Now.AddDays(30), tbKulcsszavak.Text, biztonAzon, DateTime.Now);            
            string irandoFajl =PickFileName();
            if (String.IsNullOrEmpty(irandoFajl))
            {
                MessageBox.Show("A kiírási műveletet megszakította!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                List<Job> allasok = new List<Job>();
                allasok.Add(ujMunka);
                XMLkezelo.Kiiras(allasok, irandoFajl);
                MessageBox.Show("A kiírás sikeresen megtörtént!", "Sikeres kísérlet!", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("A kiírás közben hiba történt!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!cbKat.Items.Contains(cbKat.Text))
            {
                MessageBox.Show("A választható kategóriák között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Biztosan szeretné file-ba kiírni az állásokat?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            string irandoFajl = PickFileName();
            if (String.IsNullOrEmpty(irandoFajl))
            {
                MessageBox.Show("A kiírási műveletet megszakította!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            
            try
            {
                List<Job> allasok = new List<Job>();
                Adatbazis ab = new Adatbazis();
                foreach (Job item in ab.Jobs)
                {
                    allasok.Add(item);
                }
                XMLkezelo.Kiiras(allasok, irandoFajl);
                MessageBox.Show("A kiírás sikeresen megtörtént!", "Sikeres kísérlet!", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("A kiírás közben hiba történt!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
            }
        }

        private string PickFileName()
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                return sd.FileName;
            }
            else
            {
                return null;
            }
        }

        private void HirdetesFeladas_Load(object sender, EventArgs e)
        {
            foreach (string kat in kategoriaNevek)
            {
                cbKat.Items.Add(kat);
            }
        }
    }
}
