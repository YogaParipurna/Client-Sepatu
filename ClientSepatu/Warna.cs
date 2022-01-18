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
    public partial class Warna : Form
    {
        ServiceReference1.SepatuClient service = new ServiceReference1.SepatuClient();

        public Warna()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            int ID_Warna = int.Parse(tbID.Text);
            string Warna_Sepatu = tbWarna.Text;

            var a = service.TambahWarnaa(ID_Warna, Warna_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int ID_Warna = int.Parse(tbID.Text);
            string Warna_Sepatu = tbWarna.Text;

            var a = service.editWarna(ID_Warna, Warna_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            int ID_Warna = int.Parse(tbID.Text);

            var a = service.deleteWarna(ID_Warna);
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
            var List = service.ListWarna();
            DtWarrna.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbWarna.Clear();

            tbWarna.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void DtWarrna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(DtWarrna.Rows[e.RowIndex].Cells[0].Value);
            tbWarna.Text = Convert.ToString(DtWarrna.Rows[e.RowIndex].Cells[1].Value);

            tbWarna.Enabled = true;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }

        private void Warna_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
