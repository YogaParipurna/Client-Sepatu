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
    public partial class Jenis : Form
    {
        ServiceReference1.SepatuClient service = new ServiceReference1.SepatuClient();

        public Jenis()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

        }

        private void Jenis_Load(object sender, EventArgs e)
        {

        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            int ID_Bahan = int.Parse(tbID.Text);
            string Jenis_Sepatu = tbJenisSepatu.Text;

            var a = service.TambahJeniss(ID_Bahan, Jenis_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int ID_Bahan = int.Parse(tbID.Text);
            string Jenis_Sepatu = tbJenisSepatu.Text;

            var a = service.editJenis(ID_Bahan, Jenis_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            int ID_Bahan = int.Parse(tbID.Text);

            var a = service.deleteJenis(ID_Bahan);
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
            tbJenisSepatu.Text = Convert.ToString(DtBahan.Rows[e.RowIndex].Cells[1].Value);

            tbJenisSepatu.Enabled = true;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }

        public void TampilData()
        {
            var List = service.ListJenis();
            DtBahan.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbJenisSepatu.Clear();

            tbJenisSepatu.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void Jenis_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
