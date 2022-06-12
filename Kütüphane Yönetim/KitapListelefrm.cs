using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp2
{
    public partial class KitapListelefrm : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        DataTable tablo = new DataTable();
        public KitapListelefrm()
        {
            InitializeComponent();
        }

        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
        }

        private void KitapListelefrm_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
            da = new OleDbDataAdapter("SElect *from Kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitap");
            dataGridView1.DataSource = ds.Tables["Kitap"];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
            da = new OleDbDataAdapter("SElect *from Kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitap");
            dataGridView1.DataSource = ds.Tables["Kitap"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Veriyi Silmek İstediğinize Eminmisiniz", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
                string sorgu = "Delete From Kitap Where KitapID=@no";
                cmd = new OleDbCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[0].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
                da = new OleDbDataAdapter("SElect *from Kitap", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Kitap");
                dataGridView1.DataSource = ds.Tables["Kitap"];
                con.Close();
                MessageBox.Show("Veri Başarıyla Silindi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Çıkmak İstediğinize Eminmisiniz", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
