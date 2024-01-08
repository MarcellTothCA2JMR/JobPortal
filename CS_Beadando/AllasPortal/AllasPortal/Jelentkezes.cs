using AllasPortal.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AllasPortal
{
    public partial class Jelentkezes : Form
    {
        string[] rendezesiLehetosegek = { "ABC (növekvő)", "Szül. Dátum (növekvő)" };

        int MunkaID;
        public Jelentkezes(int jel)
        {
            InitializeComponent();
            MunkaID = jel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Adatbazis ab = new Adatbazis();

            foreach (Worker item in ab.Workers)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UjDolgozo ud = new UjDolgozo();
            ud.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Nincs kiválasztva elem, válasszon dolgozót a listából!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }

            int DolgozoID = ((Worker)(listBox1.SelectedItem)).Id;

            Adatbazis ab = new Adatbazis();

            Registration jelentkezes = new Registration(MunkaID, DolgozoID, DateTime.Now);
            
            ab.Registrations.Add(jelentkezes);
            ab.SaveChanges();
            MessageBox.Show("Az állásra való jelentkezés megtörtént!", "Sikeres jelentkezés!", MessageBoxButtons.OK);
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(comboBox1.Items.Contains(comboBox1.Text)))
            {
                MessageBox.Show("A választható rendezési lehetőségek között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            
            List<Worker> rendezett = new List<Worker>();
            rendezett = SzamitasSegito.DolgozotRendezo(listBox1, comboBox1);

            listBox1.Items.Clear();
            foreach (Worker w in rendezett)
            {
                listBox1.Items.Add(w);
            }
        }

        private void Jelentkezes_Load(object sender, EventArgs e)
        {
            foreach (string ren in rendezesiLehetosegek)
            {
                comboBox1.Items.Add(ren);
            }
        }
    }
}
