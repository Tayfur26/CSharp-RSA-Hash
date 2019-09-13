using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sha = new SHA256Managed();
            SHA256 sifrele = new SHA256CryptoServiceProvider();
            string SifrelenecekMetin = textBox1.Text;
            string SifreliVeri = Convert.ToBase64String(sifrele.ComputeHash(Encoding.UTF8.GetBytes(SifrelenecekMetin)));
            var bytess = System.Text.Encoding.UTF8.GetBytes(SifreliVeri);
            var longValue = BitConverter.ToInt64(bytess, 0);
            textBox2.Text = SifreliVeri;
            textBox3.Text = Convert.ToString(longValue);
            


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Tüm Dosyalar |*.*| Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi";
            dosya.Title = "Dosya Seç";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            textBox1.Text = dosya.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = GetChecksum(textBox1.Text);
            textBox3.Text = GetChecksum1(textBox1.Text);
            textBox4.Text = GetChecksum2(textBox1.Text);
        }

        public static string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
                
            }
        }
        public static string GetChecksum1(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                var longValue = BitConverter.ToInt64(checksum, 0);
                return longValue.ToString();

            }
        }
        public static string GetChecksum2(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);

                return checksum.ToString();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int boy = textBox2.Text.Length;
            label7.Text = boy.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show(); 
            Form1 f1 = new Form1();
            f1.Close();
            this.Hide();
        }
    }
}
