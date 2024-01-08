using AllasPortal.Models;
using System;
using System.Windows.Forms;

namespace AllasPortal
{
    public partial class LejaratMeghosszabbitas : Form
    {
        Job jobToUpdt;
        public LejaratMeghosszabbitas(Job munka)
        {
            InitializeComponent();
            jobToUpdt = munka;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (jobToUpdt.BiztAzon != textBox1.Text)
            {
                MessageBox.Show("A megadott biztonsági kód helytelen!", "Sikertelen művelet!", MessageBoxButtons.OK);
                return;
            }
            if (dateTimePicker1.Value <= jobToUpdt.Idopont)
            {
                MessageBox.Show("A megadott dátum nem nagyobb mint a jelenlegi!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Biztosan szeretné meghosszabbítani az állást?", "Erősítse meg!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            Adatbazis ab = new Adatbazis();
            foreach (Job item in ab.Jobs)
            {
                if (item.Id == jobToUpdt.Id && item.BiztAzon == textBox1.Text)
                {
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = item.Idopont;
                    TimeSpan t = d2 - d1;
                    double NrOfDays = t.TotalDays;

                    if (NrOfDays > 0 && NrOfDays < 7)
                    {
                        item.Idopont = dateTimePicker1.Value;
                        MessageBox.Show("A módosítás megtörtént!", "Sikeres módosítás!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Nem vagyunk a módosítási időszakban!", "Sikertelen módosítás!", MessageBoxButtons.OK);
                    }
                }
            }
            ab.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
