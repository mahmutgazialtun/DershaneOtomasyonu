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
    public partial class OgrenciIsleri : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public OgrenciIsleri()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Ekle
            Ekle();
        }
        public void Ekle()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Ogrenci (Ad,Soyad,TCKimlik,Sinif,Alani,VeliAdi,YillikUcret,Adres)"+
                "values(@ad,@soyad,@tckimlik,@sinif,@alani,@veliadi,@yillikucret,@adres)",conn);
            cmd.Parameters.AddWithValue("@ad",textEdit1.Text);
            cmd.Parameters.AddWithValue("@soyad", textEdit2.Text);
            cmd.Parameters.AddWithValue("@tckimlik", textEdit3.Text);
            cmd.Parameters.AddWithValue("@sinif", comboBoxEdit1.SelectedItem);
            cmd.Parameters.AddWithValue("@alani", comboBoxEdit2.SelectedItem);
            cmd.Parameters.AddWithValue("@veliadi", textEdit6.Text);
            cmd.Parameters.AddWithValue("@yillikucret", textEdit7.Text);
            cmd.Parameters.AddWithValue("@adres", richTextBox1.Text);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Güncelle
            if(simpleButton2.Text=="veriyi güncelle")
            {
                Guncelle();
            }
            BilgiCek();
            
        }
        public void Guncelle()
        {
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("ID").ToString();
            SqlCommand cmd = new SqlCommand("update Ogrenci set Ad='" + textEdit1.Text + "',Soyad='" +textEdit2.Text+"',TCKimlik='"+textEdit3.Text+"',VeliAdi='"+textEdit6.Text+"',Sinifi='"+comboBoxEdit2.SelectedText+"',YillikUcret='"+textEdit7.Text+"',Alani='"+comboBoxEdit1.SelectedText+"',Adres='"+richTextBox1.Text+"' where ID='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        public void BilgiCek()
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("TCKimlik").ToString();
            textEdit6.Text = gridView1.GetFocusedRowCellValue("VeliAdi").ToString();
            textEdit7.Text = gridView1.GetFocusedRowCellValue("YillikUcret").ToString();          
            //comboBoxEdit1.Text = gridView1.GetFocusedRowCellValue("Sinif").ToString();
            //comboBoxEdit2.Text = gridView1.GetFocusedRowCellValue("Alani").ToString();
            richTextBox1.Text = gridView1.GetFocusedRowCellValue("Adres").ToString();

            //if (gridView1.GetFocusedRowCellValue("Sinifi") == "12")
                //comboBoxEdit1.SelectedIndex = 0;
           // else comboBoxEdit1.SelectedIndex = 1;
            if (gridView1.GetFocusedRowCellValue("Alani").ToString() == "Sayısal")
                comboBoxEdit1.SelectedIndex = 0;
            else comboBoxEdit1.SelectedIndex = 1;

            simpleButton2.Text = "Veriyi Güncelle";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //Sil
            Sil();
        }
        public void Sil()
        {
            DialogResult onay = MessageBox.Show("kaydı silmek istediğinize emin misiniz?","Onay Kutusu",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
             conn.Open();
            string id = gridView1.GetFocusedRowCellValue("ID").ToString();
            SqlCommand cmd = new SqlCommand("delete from Ogrenci where ID='"+id+"'",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();

            }
            
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //Listele
            Listele();
        }
        private void OgrenciIsleri_Load(object sender, EventArgs e)
        {
            Listele();
            gridView1.OptionsBehavior.ReadOnly = true;
        }
        public void Listele()
        {
            string komut = "select * from Ogrenci";
            SqlDataAdapter da = new SqlDataAdapter(komut,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
            textEdit6.Text = " ";
            textEdit7.Text = " ";
            textEdit8.Text = " ";
            richTextBox1.Text = " ";
            comboBoxEdit1.SelectedIndex = 0;
            comboBoxEdit2.SelectedIndex = 0;

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
