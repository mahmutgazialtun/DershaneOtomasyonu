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
    public partial class OdemeYap : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MN15E09\\SQLEXPRESS; initial catalog=proje; Integrated Security=TRUE");
        public OdemeYap()
        {
            InitializeComponent();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Odeme yap
            conn.Open();
            string id = gridView1.GetFocusedRowCellValue("ID").ToString();
            int odenen = Convert.ToInt16(textEdit3.Text);
            int kalan = Convert.ToInt16(textEdit4.Text);
            int yeniborc = kalan - odenen;
            textEdit4.Text = yeniborc.ToString();

            //SqlCommand cmd = new SqlCommand("update BorcOdemeEkran set @p1=KalanBorc where  @p2=IsletmeAdi", conn);
            //cmd.Parameters.AddWithValue("@p2", textEdit1.Text);
            //cmd.Parameters.AddWithValue("@p1", textEdit4.Text);
            //cmd.ExecuteNonQuery();
           // conn.Close();

            //conn.Open();
            
            SqlCommand cmd = new SqlCommand("update BorcOdemeEkran set IsletmeAdi='" + textEdit1.Text + "',KalanBorc='" + textEdit4.Text + "'where ID='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele();
        }
        public void BilgiCek()
        {
            textEdit1.Text = gridView1.GetFocusedRowCellValue("IsletmeAdi").ToString();
            //textEdit2.Text = gridView1.GetFocusedRowCellValue("BorcMiktari").ToString();
            textEdit4.Text = gridView1.GetFocusedRowCellValue("KalanBorc").ToString();
            

            
        }
        public void Listele()
        {
            string komut = "select*from BorcOdemeEkran";
            SqlDataAdapter da = new SqlDataAdapter(komut, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
            textEdit4.Text = " ";
        }

        private void OdemeYap_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            BilgiCek();
        }
    }
}
