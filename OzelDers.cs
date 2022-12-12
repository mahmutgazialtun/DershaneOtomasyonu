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
    public partial class OzelDers : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public OzelDers()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("insert into OzelDers (OgrenciAdi,OgrenciSoyadi,OgretmenAdi,OgretmenSoyadi,DersAdi,OzelDersinKonusu)" +
                "values(@ogrenciad,@ogrencisoyad,@ogretmenadi,@ogretmensoyadi,@dersadi,@ozeldersinkonusu)", conn);
            cmd.Parameters.AddWithValue("@ogrenciad", textEdit1.Text);
            cmd.Parameters.AddWithValue("@ogrencisoyad", textEdit2.Text);
            cmd.Parameters.AddWithValue("@ogretmenadi", textEdit3.Text);           
            cmd.Parameters.AddWithValue("@ogretmensoyadi", textEdit4.Text);
            cmd.Parameters.AddWithValue("@dersadi", textEdit5.Text);
            cmd.Parameters.AddWithValue("@ozeldersinkonusu", richTextBox1.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Güncelle
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
            SqlCommand cmd = new SqlCommand("update OzelDers set OgrenciAdi='" + textEdit1.Text + "',OgrenciSoyadi='" + textEdit2.Text + "',OgretmenAdi='" + textEdit3.Text + "',OgretmenSoyadi='" + textEdit4.Text + "',DersAdi='" + textEdit5.Text + "',OzelDersinKonusu='" + richTextBox1.Text + "'where ID='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        public void BilgiCek()
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("OgrenciAdi").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("OgrenciSoyadi").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("OgretmenAdi").ToString();
            textEdit4.Text = gridView1.GetFocusedRowCellValue("OgretmenSoyadi").ToString();
            textEdit5.Text = gridView1.GetFocusedRowCellValue("DersAdi").ToString();
            richTextBox1.Text = gridView1.GetFocusedRowCellValue("OzelDersinKonusu").ToString();

            simpleButton2.Text = "Veriyi Güncelle";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //Sil
            Sil();
        }
        public void Sil()
        {
            DialogResult onay = MessageBox.Show("kaydı silmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                conn.Open();
                string id = gridView1.GetFocusedRowCellValue("ID").ToString();
                SqlCommand cmd = new SqlCommand("delete from OzelDers where ID='" + id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Listele();

            }

        }
        public void Listele()
        {
            string komut = "select * from OzelDers";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
            textEdit4.Text = " ";
            textEdit5.Text = " ";
            richTextBox1.Text = " ";
        }

        private void OzelDers_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
