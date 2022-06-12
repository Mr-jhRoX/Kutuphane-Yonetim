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
    public partial class KitapEklefrm : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        DataTable tablo = new DataTable();


        public KitapEklefrm()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
        }

        private void KitapEklefrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
             {
              MessageBox.Show("Kitap Adi Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          else  if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Kitap Barkod No Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          else  if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Kitap Yazar Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          else  if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Kitap Sayfa Sayisi Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         else   if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Kitap Raf Numarasi Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                DialogResult cevap = new DialogResult();
                cevap = MessageBox.Show("Kitap Eklemek İstediğinize Eminmisiniz", "Kitap Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    griddoldur();
                    string sorgu = "Insert into Kitap (KitapAdi,KitapYazar,KitapBarkodNo,KitapSayfaSayisi,KitapRafNumarasi) values (@KitapAdi,@KitapYazar,@KitapBarkodNo,@KitapSayfaSayisi,@KitapRafNumarasi)";
                    cmd = new OleDbCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@KitapAdi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@KitapYazar", textBox3.Text);
                    cmd.Parameters.AddWithValue("@KitapSayfaSayisi", Convert.ToInt32(textBox4.Text));
                    cmd.Parameters.AddWithValue("@KitapBarkodNo", Convert.ToInt32(textBox2.Text));
                    cmd.Parameters.AddWithValue("@KitapRafNumarasi", Convert.ToInt32(textBox5.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                    MessageBox.Show("Kitap Başarıyla Kaydedildi.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                    MessageBox.Show("İşlem İptal Edildi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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