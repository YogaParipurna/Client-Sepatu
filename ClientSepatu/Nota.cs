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

    public partial class Nota : Form
    {
        ServiceReference1.SepatuClient service = new ServiceReference1.SepatuClient();

        public Nota()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string ID_Nota = tbID.Text;
            string Tanggal = tbTanggal.Text;
            string Bulan = tbBulan.Text;
            string Tahun = tbTahun.Text;
            string Jumlah = tbJumlah.Text;

            var a = service.TambahNotaa(ID_Nota, Tanggal, Bulan, Tahun, Jumlah);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ID_Nota = tbID.Text;
            string Tanggal = tbTanggal.Text;
            string Bulan = tbBulan.Text;
            string Tahun = tbTahun.Text;
            string Jumlah = tbJumlah.Text;

            var a = service.editNota(ID_Nota, Tanggal, Bulan, Tahun, Jumlah);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string ID_Nota = tbID.Text;

            var a = service.deleteNota(ID_Nota);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }



        public void TampilData()
        {
            var List = service.ListNota();
            DtNota.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbTanggal.Clear();
            tbBulan.Clear();
            tbTahun.Clear();
            tbJumlah.Clear();

            tbJumlah.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void DtNota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(DtNota.Rows[e.RowIndex].Cells[1].Value);
            tbTanggal.Text = Convert.ToString(DtNota.Rows[e.RowIndex].Cells[4].Value);
            tbBulan.Text = Convert.ToString(DtNota.Rows[e.RowIndex].Cells[0].Value);
            tbTahun.Text = Convert.ToString(DtNota.Rows[e.RowIndex].Cells[3].Value);
            tbJumlah.Text = Convert.ToString(DtNota.Rows[e.RowIndex].Cells[2].Value);


            tbTanggal.Enabled = false;
            tbBulan.Enabled = false;
            tbTahun.Enabled = false;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }

        private void Nota_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
