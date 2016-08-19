using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema_uygulaması
{
    public partial class filmekle : Form
    {
        SinemaEntities db = new SinemaEntities();
        public filmekle()
        {
            InitializeComponent();
            var p = from liste in db.salon select liste.salon_id;
            foreach (int item in p)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                film yenifilm = new film();
                yenifilm.fAdi = textBox1.Text;
                yenifilm.fTur = textBox2.Text;
                yenifilm.sure = textBox3.Text;
                yenifilm.salon_id = Convert.ToInt32(comboBox1.Text);
                yenifilm.resim = _resimsakla;
                db.film.Add(yenifilm);
                db.SaveChanges();
                MessageBox.Show("Film eklenmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = "";
                pictureBox1.Image = null;
            }
            else
            {
                MessageBox.Show("Lütfen alanları eksiksiz doldurun!");
            }
        }
        public static string _resimsakla;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Resim dosyaları |*.jpg;*.jpeg;*.gif;*.bmp;" +
                "*.png;*ico|JPEG Files ( *.jpg;*.jpeg )|*.jpg;*.jpeg|GIF Files ( *.gif )|*.gif|BMP Files ( *.bmp )" +
                "|*.bmp|PNG Files ( *.png )|*.png|Icon Files ( *.ico )|*.ico";
            openDialog.Title = "Resim Ekle";
            openDialog.InitialDirectory = Application.StartupPath + @"\\DataPicture\";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _resimsakla = openDialog.FileName.ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = _resimsakla;
            }
            openDialog.Dispose();
        }
    }
}
