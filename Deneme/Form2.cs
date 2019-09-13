using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static class Ortak
        {
            public static int fi_n { get; set; }
            public static int e_ { get; set; }
           
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(textBox1.Text);
            int q = Convert.ToInt32(textBox2.Text);
            if (isprime(p) == 0 || isprime(q) == 0)
            {
                MessageBox.Show("Sayılar Asal olmalıdır.");
            }
            else 
            {
                int n = p * q;
                Ortak.fi_n= (p - 1) * (q - 1);
                for (int i = 0; i <= 999999999; i++)
                {
                    Ortak.e_ = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Fi(n) ile aralarında asal bir sayı giriniz", "e sayısı seçme", "", 10, 10));
                    if (a_asal(Ortak.e_, Ortak.fi_n) == 1)
                        break;
                    else 
                    {
                        MessageBox.Show("e sayısı ile Fi(n) aralarında asal olmalıdır.");
                    }
                }
                int d = ters(Ortak.e_, Ortak.fi_n);
                
                textBox7.Text = Convert.ToString(d);
                textBox8.Text = Convert.ToString(Ortak.fi_n);
                 textBox5.Text = Convert.ToString(Ortak.e_);
                 textBox6.Text = Convert.ToString(Ortak.fi_n);
                
                
            }
        }
        public static double isprime(double sayi)
        {
            if (sayi == 1 || sayi < 1)
            {
                MessageBox.Show("Girilen sayı 1 den büyük olmalıdır.");
                return 0;
            }
            else
            {
                for (int i = 2; i < sayi; i++)
                {
                    if (sayi % i == 0)
                        return 0;
                }
               
              
                return 1;
            
            }
        }
        public static int a_asal(int a, int b)
        {

            
            int min = a;

            if (b < min) min = b;

            for (int i = 2; i <= min; i++)
            {
                if (a % i == 0 && b % i == 0)
                {

                    return 0; 

                }
                else if (i == min)

                { return 1; }

            }
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Close();
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        public static int ters(int e, int fi)
        {
            double result;
            int k = 1;
            while (true)
            {
                result = (1 + (k * fi)) / (double)e;
                if ((Math.Round(result, 5) % 1) == 0) //integer
                {
                    return (int)result;
                }
                else
                {
                    k++;
                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }

}
