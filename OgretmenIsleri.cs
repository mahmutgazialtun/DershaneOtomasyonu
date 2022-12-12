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
    
    public partial class OgretmenIsleri : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public OgretmenIsleri()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Ekle
            Ekle();
        }
        public void Ekle()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Ogretmen(Adi,Soyadi,Yasi,Bransi,TelefonNumarasi,Maasi)" +
                "values(@adi,@soyadi,@yasi,@bransi,@telefonnumarasi,@maasi)",conn);
            cmd.Parameters.AddWithValue("@adi",textEdit1.Text);
            cmd.Parameters.AddWithValue("@soyadi", textEdit2.Text);
            cmd.Parameters.AddWithValue("@yasi", textEdit3.Text);
            cmd.Parameters.AddWithValue("@bransi", textEdit4.Text);
            cmd.Parameters.AddWithValue("@telefonnumarasi", textEdit5.Text);
            cmd.Parameters.AddWithValue("@maasi", textEdit6.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Güncelle
            if(simpleButton2.Text=="Veriyi Güncelle")
            {
                Guncelle();
            }
            BilgiCek();

        }
        public void Guncelle()
        {
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("ID").ToString();
            SqlCommand cmd = new SqlCommand("update Ogretmen set Adi='"+textEdit1.Text+"',Soyadi='"+textEdit2.Text+"',Yasi='"+textEdit3.Text+"',Bransi='"+textEdit4.Text+"',TelefonNumarasi='"+textEdit5.Text+"',Maasi='"+textEdit6.Text+"'where ID='"+id+"'",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        public void BilgiCek()
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("Adi").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Soyadi").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("Yasi").ToString();
            textEdit4.Text = gridView1.GetFocusedRowCellValue("Bransi").ToString();
            textEdit5.Text = gridView1.GetFocusedRowCellValue("TelefonNumarasi").ToString();
            textEdit6.Text = gridView1.GetFocusedRowCellValue("Maasi").ToString();

            simpleButton2.Text = "Veriyi Güncelle";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //Sil
            Sil();
        }
        public void Sil()
        {
            DialogResult onay = MessageBox.Show("Silmek istediğinize emin misiniz?","Onay Kutusu",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                conn.Open();
                string id = gridView1.GetFocusedRowCellValue("ID").ToString();
                SqlCommand cmd = new SqlCommand("delete from Ogretmen where ID='" + id + "'",conn);
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

        private void OgretmenIsleri_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            string komut = "select*from Ogretmen";
            SqlDataAdapter da = new SqlDataAdapter(komut,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
            textEdit4.Text = " ";
            textEdit5.Text = " ";
            textEdit6.Text = " ";
            
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
