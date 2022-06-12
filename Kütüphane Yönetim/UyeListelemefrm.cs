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
    public partial class UyeListelemefrm : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public UyeListelemefrm()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
            da = new OleDbDataAdapter("SElect *from Uye", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Uye");
            dataGridView1.DataSource = ds.Tables["Uye"];
            con.Close();
        }

        private void UyeListelemefrm_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
            da = new OleDbDataAdapter("SElect *from Uye", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Uye");
            dataGridView1.DataSource = ds.Tables["Uye"];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Veriyi Silmek İstediğinize Eminmisiniz", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
                string sorgu = "Delete From Uye Where UyeID=@no";
                cmd = new OleDbCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[0].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
                da = new OleDbDataAdapter("SElect *from Uye", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Uye");
                dataGridView1.DataSource = ds.Tables["Uye"];
                con.Close();
                MessageBox.Show("Veri Başarıyla Silindi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Çıkmak İstediğinize Eminmisiniz","Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
