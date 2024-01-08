using AllasPortal.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllasPortal
{
    public partial class Form1 : Form
    {
        string[] rendezesiLehetosegek = { "ABC (növekvő)", "Fizetés (csökkenő)", "Népszerűség (csökkenő)" };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Adatbazis ab = new Adatbazis();
            foreach (Job item in ab.Jobs)
            {
                if (SzamitasSegito.SzuresFeltetelKiertekelo(item, checkBox1, checkBox2, checkBox3, checkBox4,
                        checkBox5, comboBox1, textBox1, numericUpDown1, textBox2, checkedListBox1, checkBox6))
                {
                    listBox1.Items.Add(item);
                }
            }

            comboBox1.Items.Clear();
            foreach (string item in SzamitasSegito.ComboboxFeltolto())
            {
                comboBox1.Items.Add(item);
            }

            checkedListBox1.Items.Clear();
            List<string> kulcsszavak = SzamitasSegito.CheckedlistboxFeltolto();
            kulcsszavak.Sort();
            foreach (string item in kulcsszavak)
            {
                checkedListBox1.Items.Add(item);
            }

            Chart chart1 = new Chart();
            foreach (var item in Controls)
            {
                if (item.GetType() == chart1.GetType())
                {
                    Controls.Remove((Control)item);
                }
            }
            SzamitasSegito.KorDiagramRajzolo(chart1);
            Controls.Add(chart1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HirdetesFeladas hf = new HirdetesFeladas();
            hf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                MessageBox.Show("Nincs kiválasztva elem, válasszon állást a listából!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            if (!(((Job)(listBox1.SelectedItem)).Idopont.Date >= DateTime.Now.Date))
            {
                MessageBox.Show("Az állás már nem aktív, így nem hosszabbítható meg!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            
            LejaratMeghosszabbitas lm = new LejaratMeghosszabbitas((Job)listBox1.SelectedItem);
            lm.Show();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(!(((Job)((ListBox)sender).SelectedItem).Idopont.Date >= DateTime.Now.Date))
            {
                MessageBox.Show("Az állás már nem aktív, így nem lehet rá jelentkezni!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            Jelentkezes jelent = new Jelentkezes(((Job)((ListBox)sender).SelectedItem).Id);
            jelent.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(comboBox2.Items.Contains(comboBox2.Text)))
            {
                MessageBox.Show("A választható rendezési lehetőségek között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            Adatbazis ab = new Adatbazis();
            List<Job> rendezett = new List<Job>();
            if (comboBox2.Text == "Népszerűség (csökkenő)")
            {
                Dictionary<int, int> nepszeruSorrend = SzamitasSegito.NepszerusegMero(listBox1);
                foreach (var nepsz in nepszeruSorrend)
                {
                    foreach (Job munka in ab.Jobs)
                    {
                        if(munka.Id == nepsz.Key)
                        {
                            rendezett.Add(munka);
                            break;
                        }
                    }
                }
            }
            else
            {
                rendezett = SzamitasSegito.AllastRendezo(listBox1, comboBox2);
            }

            listBox1.Items.Clear();
            foreach (Job j in rendezett)
            {
                listBox1.Items.Add(j);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Nincs kiválasztva elem, válasszon állást a listából!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            AllasModositasa am = new AllasModositasa((Job)listBox1.SelectedItem);
            am.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Nincs kiválasztva elem, válasszon állást a listából!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            JelentkezesekAttekintese ja = new JelentkezesekAttekintese((Job)listBox1.SelectedItem);
            ja.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string ren in rendezesiLehetosegek)
            {
                comboBox2.Items.Add(ren);
            }

            foreach (string item in SzamitasSegito.ComboboxFeltolto())
            {
                comboBox1.Items.Add(item);
            }

            foreach (string item in SzamitasSegito.CheckedlistboxFeltolto())
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan szeretné file-ba kiírni a listában szereplő állásokat?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            string irandoFajl;
            SaveFileDialog sd = new SaveFileDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                irandoFajl = sd.FileName;
            }
            else
            {
                MessageBox.Show("A kiírási műveletet megszakította!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                List<Job> allasok = new List<Job>();
                foreach (Job item in listBox1.Items)
                {
                    allasok.Add(item);
                }
                XMLkezelo.Kiiras(allasok, irandoFajl);
                MessageBox.Show("A kiírási sikeresen megtörtént!", "Sikeres kísérlet!", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("A kiírás közben hiba történt!", "Sikertelen kísérlet!", MessageBoxButtons.OK);                
            }
        }
    }
}
