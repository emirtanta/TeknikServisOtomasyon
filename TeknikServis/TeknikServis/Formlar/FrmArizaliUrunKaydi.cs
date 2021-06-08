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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //Kayıt yap butonu bölümü
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            

            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GELISTARIHI = DateTime.Parse(txtTarih.Text);
            t.PERSONEL = int.Parse(lookUpEdit2.EditValue.ToString());
            t.URUNSERINO = txtSeriNo.Text;
            t.URUMDURUMDETAY = "Ürün kaydoldu";

            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün arıza girişi kaydedildi");
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            //form yüklendiğinde cari dopdown'ini yükledik
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     AD=x.AD + " "+x.SOYAD,
                                                     x.ID
                                                 }).ToList();

            //form yüklendiğinde personel dopdown'ini yükledik
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     AD = x.AD + " " + x.SOYAD,
                                                     x.ID
                                                 }).ToList();
        }

        //Vazgeç butonu bölümü
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //tarih değerini bugünün tarihine göre getirmek için tanımladık
        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
