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
    public partial class Bahan : Form
    {
        ServiceReference1.SepatuClient service = new ServiceReference1.SepatuClient();

        public Bahan()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            int ID_Bahan = int.Parse(tbID.Text);
            string Jenis_Bahan = tbJenisBahan.Text;

            var a = service.TambahBahan(ID_Bahan, Jenis_Bahan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int ID_Bahan = int.Parse(tbID.Text);
            string Jenis_Bahan = tbJenisBahan.Text;

            var a = service.editBahan(ID_Bahan, Jenis_Bahan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            int IDPemesanan = int.Parse(tbID.Text);

            var a = service.deleteBahan(IDPemesanan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DtBahan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(DtBahan.Rows[e.RowIndex].Cells[0].Value);
            tbJenisBahan.Text = Convert.ToString(DtBahan.Rows[e.RowIndex].Cells[1].Value);

            tbJenisBahan.Enabled = true;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }

        public void TampilData()
        {
            var List = service.ListBahan();
            DtBahan.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbJenisBahan.Clear();

            tbJenisBahan.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void Bahan_Load(object sender, EventArgs e)
        {

        }

        private void Bahan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
