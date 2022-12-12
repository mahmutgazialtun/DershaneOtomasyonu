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
    public partial class BorcOde : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public BorcOde()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Borç Ekle
            Ekle();
        }
        public void Ekle()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into BorcEkrani(FirmaAdi,OdenecekTutar,OdemeTuru)" +
                "values(@firmaadi,@odenecektutar,@odemeturu)", conn);
            cmd.Parameters.AddWithValue("@firmaadi", textEdit1.Text);
            cmd.Parameters.AddWithValue("@odenecektutar", textEdit2.Text);
            cmd.Parameters.AddWithValue("@odemeturu", textEdit3.Text);
            

            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Borcu Güncelle
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
            SqlCommand cmd = new SqlCommand("update BorcEkrani set FirmaAdi='" + textEdit1.Text + "',BorcMiktari='" + textEdit2.Text + "',OdemeTuru='" + textEdit3.Text + "'where ID='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        public void BilgiCek()
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("FirmaAdi").ToString();
            textEdit2.Text = gridView1.GetFocusedRowCellValue("BorcMiktari").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("OdemeTuru").ToString();
            

            simpleButton2.Text = "Veriyi Güncelle";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //Borcu Sil
            Sil();
        }
        public void Sil()
        {
            DialogResult onay = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                conn.Open();
                string id = gridView1.GetFocusedRowCellValue("ID").ToString();
                SqlCommand cmd = new SqlCommand("delete from BorcEkrani where ID='" + id + "'", conn);
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
        private void BorcOde_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            string komut = "select*from BorcEkrani";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
        }

        
    }
}
