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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }


        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //Satış Yap butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN =int.Parse(lookUpEdit1.EditValue.ToString());
            t.MUSTERI =int.Parse(lookUpEdit2.EditValue.ToString());
            t.PERSONEL = int.Parse(lookUpEdit3.EditValue.ToString());
            t.TARIH = DateTime.Parse(txtTarih.Text);
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.URUNSERINO = txtSeriNo.Text;

            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün satışı yapıldı");
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            //ürün tablosundan verileri dropdown içerisine aktardık
            lookUpEdit1.Properties.DataSource = (from x in db.TBLURUN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();

            //cari tablosundan verileri dropdown içerisine aktardık
            lookUpEdit2.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD=x.AD+" "+x.SOYAD
                                                 }).ToList();

            //personel tablosundan verileri dropdown içerisine aktardık
            lookUpEdit3.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD=x.AD+" "+x.SOYAD
                                                 }).ToList();
        }
    }
}
