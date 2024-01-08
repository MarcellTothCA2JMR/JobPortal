using AllasPortal.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AllasPortal
{
    public partial class UjDolgozo : Form
    {
        enum vegzettsegTipusok
        {
            Nyolc_általános, Szakközépiskola, Érettségi, Főiskola, Egyetem
        }

        public UjDolgozo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse(typeof(vegzettsegTipusok), comboBox1.Text, out object? result))
            {
                MessageBox.Show("A választható végzettség típusok között nem szerepel a megadott!", "Sikertelen kísérlet!", MessageBoxButtons.OK);
                return;
            }
            
            Adatbazis ab = new Adatbazis();

            Worker dolgozo = new Worker(textBox1.Text, textBox2.Text, (int)numericUpDown1.Value, comboBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text);

            ab.Workers.Add(dolgozo);
            ab.SaveChanges();
            MessageBox.Show("Az új dolgozó hozzáadása megtörtént!", "Sikeres művelet!", MessageBoxButtons.OK);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UjDolgozo_Load(object sender, EventArgs e)
        {
            foreach (vegzettsegTipusok veg in Enum.GetValues(typeof(vegzettsegTipusok)))
            {
                comboBox1.Items.Add(veg);
            }
        }
    }
}
