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
    public partial class Merek : Form
    {
        ServiceReference1.SepatuClient service = new ServiceReference1.SepatuClient();

        public Merek()
        {
            InitializeComponent();
            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DtBahan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(DtMerek.Rows[e.RowIndex].Cells[0].Value);
            tbMerekSepatu.Text = Convert.ToString(DtMerek.Rows[e.RowIndex].Cells[1].Value);

            tbMerekSepatu.Enabled = true;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            int ID_Merek = int.Parse(tbID.Text);

            var a = service.deleteMerek(ID_Merek);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int ID_Merek = int.Parse(tbID.Text);
            string Merek_Sepatu = tbMerekSepatu.Text;

            var a = service.editMerek(ID_Merek, Merek_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            int ID_Merek = int.Parse(tbID.Text);
            string Merek_Sepatu = tbMerekSepatu.Text;

            var a = service.TambahMerekk(ID_Merek, Merek_Sepatu);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void tbJenisSepatu_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void TampilData()
        {
            var List = service.ListMerek();
            DtMerek.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbMerekSepatu.Clear();

            tbMerekSepatu.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void Merek_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
