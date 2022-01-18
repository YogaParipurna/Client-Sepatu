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
    public partial class Ukuran : Form
    {
        ServiceReference1.SepatuClient service = new ServiceReference1.SepatuClient();

        public Ukuran()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            int ID_Ukuran = int.Parse(tbID.Text);
            string Ukuran_Sepatu = tbUkuran.Text;

            var a = service.TambahUkurann(ID_Ukuran, Ukuran_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int ID_Ukuran = int.Parse(tbID.Text);
            string Ukuran_Sepatu = tbUkuran.Text;

            var a = service.editUkuran(ID_Ukuran, Ukuran_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            int ID_Ukuran = int.Parse(tbID.Text);

            var a = service.deleteUkuran(ID_Ukuran);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void DtUkuran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(DtUkuran.Rows[e.RowIndex].Cells[0].Value);
            tbUkuran.Text = Convert.ToString(DtUkuran.Rows[e.RowIndex].Cells[1].Value);

            tbUkuran.Enabled = true;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }

        public void TampilData()
        {
            var List = service.ListUkuran();
            DtUkuran.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbUkuran.Clear();

            tbUkuran.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void Ukuran_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
