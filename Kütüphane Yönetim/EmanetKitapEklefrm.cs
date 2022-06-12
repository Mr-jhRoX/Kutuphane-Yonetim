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
    public partial class EmanetKitapEklefrm : Form
    {
        bool durum;
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        DataTable tablo = new DataTable();
        public EmanetKitapEklefrm()
        {
            InitializeComponent();
        }

        void VarMi()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from Emanet where KitapBarkodNo=@p1", con);
            komut.Parameters.AddWithValue("@p1", textBox4.Text);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Üye Ad Soyad Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Üye Cinsiyet Bölgesini Seçin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Uye Okul Numarasi Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Üyenin Alanı Bölgesini Seçin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Üye Sınıf Bölgesini Seçin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Üye Şube Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Emanet Edilecek Kitap Adi Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Emanet Edilecek Kitap Barkod Bölgesini Boş Bırakmayın!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                VarMi();

                if (durum == false)
                {
                    MessageBox.Show("Bu Kitap Barkod No İle Daha Önce Kayıt Yapılmış", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult cevap = new DialogResult();
                    cevap = MessageBox.Show("Emanet Eklemek İstediğinize Eminmisiniz", "Emanet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Kütüphane.accdb");
                        string sorgu = "Insert into Emanet (AdSoyad,Cinsiyet,OkulNumarasi,Sinif,UyeAlani,KitapAdi,KitapBarkodNo,EmanetTarihi) values (@AdSoyad,@Cinsiyet,@OkulNumarasi,@Sinif,@UyeAlani,@KitapAdi,@KitapBarkodNo,@EmanetTarihi)";
                        cmd = new OleDbCommand(sorgu, con);
                        cmd.Parameters.AddWithValue("@AdSoyad", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Cinsiyet", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@OkulNumarasi", Convert.ToInt32(textBox2.Text));
                        cmd.Parameters.AddWithValue("@Sinif", comboBox2.Text + "/" + textBox3.Text);
                        cmd.Parameters.AddWithValue("@UyeAlani", comboBox3.Text);
                        cmd.Parameters.AddWithValue("@KitapAdi", textBox5.Text);
                        cmd.Parameters.AddWithValue("@KitapBarkodNo", Convert.ToInt32(textBox4.Text));
                        cmd.Parameters.AddWithValue("@EmanetTarihi", dateTimePicker1.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox2.Text = "";
                        textBox5.Text = "";
                        MessageBox.Show("Kitap Başarıyla Emanet Edildi.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    else
                    {
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox2.Text = "";
                        textBox5.Text = "";
                        MessageBox.Show("İşlem İptal Edildi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void EmanetKitapEklefrm_Load(object sender, EventArgs e)
        {

        }
    }
}
