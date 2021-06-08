using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = rchTxtAciklama.Text;
            t.SERINO = txtSeriNo.Text;
            t.TARIH = DateTime.Parse(txtSeriNo.Text);

            db.TBLURUNTAKIP.Add(t);

            //combox içerisini güncelleme
            TBLURUNKABUL tb = new TBLURUNKABUL();
            int urunid =int.Parse(id.ToString());
            var deger = db.TBLURUNKABUL.Find(urunid);
            tb.URUMDURUMDETAY = comboBox1.Text;
            db.SaveChanges();

            MessageBox.Show("Ürün arıza detayları güncellendi");
        }

        //Seri No textbox
        private void textEdit1_Click(object sender, EventArgs e)
        {
            txtSeriNo.Text = "";
        }

        //tarih textbox'ı
        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void rchTxtAciklama_Click(object sender, EventArgs e)
        {
            rchTxtAciklama.Text = "";
        }

        //vazgeç butonu
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //combox içerisindeki manuel olarak girilen değerleri veritabanına aktarabilmek için tanımladık
        public string id,serino;

        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
            txtSeriNo.Text = serino;
        }
    }
}
