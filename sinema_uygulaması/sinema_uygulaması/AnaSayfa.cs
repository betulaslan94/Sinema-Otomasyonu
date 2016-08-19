using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema_uygulaması
{
    public partial class AnaSayfa : Form
    {
        SinemaEntities db = new SinemaEntities();
        public AnaSayfa()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            //film adlarının gösterimi
            var k = from x in db.film select x.fAdi;
            foreach(string item in k)
            {
                comboBox1.Items.Add(item);
            }
            //seansların gösterimi
            var a = from b in db.seans select b.saat;
           foreach(string item in a)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filmekle fekle = new filmekle();
            fekle.Owner = this;
            fekle.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Seçilen seans filme göre salon no ve resmin gösterilmesi
            var x = from k in db.film where k.fAdi == comboBox1.Text select k.resim;
            var a = from b in db.film where b.fAdi == comboBox1.Text select b.salon_id;
            foreach(int item in a) {
                label5.Text = item.ToString();
            }
             foreach(string item in x)
            {
                pictureBox1.ImageLocation = item;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && listBox1.Text != "")
            {
                if (label5.Text == "1")
                {
                    salon1 s1 = new salon1();
                    s1.Owner = this;
                    s1.label15.Text = listBox1.Text;
                    s1.koltuk_durum(listBox1.Text, comboBox1.Text);
                    s1.ShowDialog();
                }
                else if (label5.Text == "2")
                {
                    salon2 s2 = new salon2();
                    s2.Owner = this;
                    s2.label15.Text = listBox1.Text;
                    s2.koltuk_durum(listBox1.Text, comboBox1.Text);
                    s2.ShowDialog();
                }
            }
            else { MessageBox.Show("Eksik seçim yapmayınız!"); }
        }
    }
}
