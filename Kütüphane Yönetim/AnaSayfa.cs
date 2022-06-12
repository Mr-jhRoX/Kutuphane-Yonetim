using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UyeEklefrm uyeekle = new UyeEklefrm();
            uyeekle.Show();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapEklefrm kitapekle = new KitapEklefrm();
            kitapekle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapListelefrm kitaplistele = new KitapListelefrm();
            kitaplistele.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmanetKitapEklefrm emanetkitapekle = new EmanetKitapEklefrm();
            emanetkitapekle.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            EmanetListeleme emanetliste = new EmanetListeleme();
            emanetliste.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UyeListelemefrm uyelistele = new UyeListelemefrm();
            uyelistele.Show();
        }
    }
}
