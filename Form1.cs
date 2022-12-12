using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace loginpage
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
            Inıt_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string o_numarasi = textBox1.Text;
            string sifre = textBox2.Text;
            bool kayitli_mi = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Login2", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (o_numarasi == dr["OkulNumarasi"].ToString() && sifre==dr["Sifre"].ToString())
                {
                    kayitli_mi = true;
                    break;
                }               
            }
            conn.Close();
            if (kayitli_mi == true)
            {
                Sava_Data();
                RibbonForm1 rbnfrm1 = new RibbonForm1();
                rbnfrm1.Show();
                this.Hide();
            }

            else MessageBox.Show("Kullanıcı adı veya şifre yanlış");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Inıt_Data()
        {
            if (Properties.Settings.Default.KullaniciAdi != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    textBox1.Text = Properties.Settings.Default.KullaniciAdi;
                    textBox2.Text = Properties.Settings.Default.Sifre;
                    checkBox1.Checked = true;
                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.KullaniciAdi;
                }
            }
        }
        private void Sava_Data()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.KullaniciAdi = textBox1.Text;
                Properties.Settings.Default.Sifre = textBox2.Text;
                Properties.Settings.Default.Remember =true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.KullaniciAdi = "";
                Properties.Settings.Default.Sifre = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
