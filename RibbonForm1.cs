using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace loginpage
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            OgrenciIsleri ogris = new OgrenciIsleri();
            ogris.MdiParent = this;
            ogris.Show();

        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            //Form2 frm2 = new Form2();
            //frm2.MdiParent = this;
            //frm2.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            OgretmenIsleri ogrtis = new OgretmenIsleri();
            ogrtis.MdiParent = this;
            ogrtis.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            PersonelIsleri peris = new PersonelIsleri();
            peris.MdiParent = this;
            peris.Show();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            BorcOde borcode = new BorcOde();
            borcode.MdiParent = this;
            borcode.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Odev odev = new Odev();
            odev.MdiParent = this;
            odev.Show();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            OdemeYap odemeyap = new OdemeYap();
            odemeyap.MdiParent = this;
            odemeyap.Show();

            
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            OzelDers ozelders = new OzelDers();
            ozelders.MdiParent = this;
            ozelders.Show();
        }
    }
}