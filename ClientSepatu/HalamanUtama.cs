using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSepatu
{
    public partial class HalamanUtama : Form
    {
        public HalamanUtama()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bahan().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Jenis().Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Merek().Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Nota().Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Ukuran().Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Warna().Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
