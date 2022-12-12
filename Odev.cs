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
    public partial class Odev : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public Odev()
        {
            InitializeComponent();
        }

        private void Odev_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Ekle
            Ekle();
        }
        public void Ekle()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Odev(Ders,Konu,Odev)" +
                "values(@ders,@konu,@odev)", conn);
            cmd.Parameters.AddWithValue("@ders", textEdit1.Text);
            cmd.Parameters.AddWithValue("@konu", textEdit2.Text);
            cmd.Parameters.AddWithValue("@odev", richTextBox1.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Guncelle
            if (simpleButton2.Text == "Veriyi Güncelle")
            {
                Guncelle();
            }
            BilgiCek();
        }
        public void Guncelle()
        {
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("ID").ToString();
            SqlCommand cmd = new SqlCommand("update Odev set Ders='" + textEdit1.Text + "',Konu='" + textEdit2.Text + "',Odev='" + richTextBox1.Text + "' where ID='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        public void BilgiCek()
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ders").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Konu").ToString();
            richTextBox1.Text = gridView1.GetFocusedRowCellValue("Odev").ToString();
           

            simpleButton2.Text = "Veriyi Güncelle";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //Sil
            Sil();
        }
        public void Sil()
        {
            DialogResult onay = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                conn.Open();
                string id = gridView1.GetFocusedRowCellValue("ID").ToString();
                SqlCommand cmd = new SqlCommand("delete from Odev where ID='" + id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Listele();
            }

        }
        public void Listele()
        {
            string komut = "select*from Odev";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            textEdit1.Text = " ";
            textEdit2.Text = " ";
            richTextBox1.Text = " ";
        }
    }
}