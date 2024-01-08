using AllasPortal.Models;
using System;
using System.Windows.Forms;

namespace AllasPortal
{
    public partial class AllasModositasa : Form
    {
        string[] kategoriaNevek = { "Fizikai", "Irodai", "IT, programozás", "Vendéglátás", "Turisztikai", "Pénzügyi", "HR" };

        Job jobToUpdt;
        public AllasModositasa(Job aktJob)
        {
            InitializeComponent();
            jobToUpdt = aktJob;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (jobToUpdt.BiztAzon != textBox1.Text)
            {
                MessageBox.Show("A megadott biztonsági kód helytelen!", "Sikertelen művelet!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Biztosan szeretné törölni az állást?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Adatbazis ab = new Adatbazis();
            bool torolheto = true;
            foreach (Registration reg in ab.Registrations)
            {
                if (reg.HirdetesAzon == jobToUpdt.Id)
                {
                    torolheto = false;
                }
            }
            if (!torolheto)
            {
                MessageBox.Show("A kiválasztott állás nem törölhető, mert már történtek rá jelentkezések!", "Sikertelen művelet!", MessageBoxButtons.OK);
                return;
            }

            foreach (Job item in ab.Jobs)
            {
                if (item.Id == jobToUpdt.Id && item.BiztAzon.TrimEnd() == textBox1.Text)
                {
                    ab.Jobs.Remove(item);
                    MessageBox.Show("Az állás törlésre került!", "Sikeres törlés!", MessageBoxButtons.OK);
                }
            }
            ab.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (jobToUpdt.BiztAzon != textBox1.Text)
            {
                MessageBox.Show("A megadott biztonsági kód helytelen!", "Sikertelen művelet!", MessageBoxButtons.OK);
                return;
            }
            if (!(comboBox1.Items.Contains(comboBox1.Text)))
            {
                MessageBox.Show("A választható kategóriák között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Biztosan szeretné módosítani az állást?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            Adatbazis ab = new Adatbazis();
            foreach (Job item in ab.Jobs)
            {
                if (item.Id == jobToUpdt.Id && item.BiztAzon.TrimEnd() == textBox1.Text)
                {
                    item.Kategoria = comboBox1.Text;
                    item.Megnevezes = textBox2.Text;
                    item.Fizetes = (int)numericUpDown1.Value;
                    item.Leiras = textBox4.Text;
                    item.Kulcsszavak = textBox5.Text;
                    MessageBox.Show("Az állás módosítása megtörtént!", "Sikeres módosítás!", MessageBoxButtons.OK);
                }
            }
            ab.SaveChanges();
            Close();
        }

        private void AllasModositasa_Load(object sender, EventArgs e)
        {
            foreach (string kat in kategoriaNevek)
            {
                comboBox1.Items.Add(kat);
            }
            comboBox1.Text = jobToUpdt.Kategoria;
            textBox2.Text = jobToUpdt.Megnevezes;
            numericUpDown1.Value = jobToUpdt.Fizetes;
            textBox4.Text = jobToUpdt.Leiras;
            textBox5.Text = jobToUpdt.Kulcsszavak;
        }
    }
}
