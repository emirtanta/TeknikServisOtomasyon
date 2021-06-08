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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        int secilen; //il dropdowlisti için seçilen ilin ilçelerini getirebilmek için tanımladık

        //cari listeleme metodu
        void liste()
        {
            var degerler = from x in db.TBLCARI
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.IL,
                               x.ILCE
                           };

            gridControl1.DataSource = degerler.ToList();
        }

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {

            liste();

            //il tablosundan verileri dropdown içerisine aktardık
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.SehirId,
                                                     x.SehirAdi
                                                 }).ToList();

            //ilçe tablosundan verileri dropdown içerisine aktardık
            //lookUpEdit2.Properties.DataSource = (from x in db.TBLILCELER
            //                                     select new
            //                                     {
            //                                         x.ilceId,
            //                                         x.IlceAdi
            //                                     }).ToList();


            //en fazla cari olan il
            labelControl6.Text = db.TBLCARI.Count().ToString();

            //toplam il sayısı
            labelControl16.Text = db.TBLCARI.Select(x=>x.IL).Distinct().Count().ToString();

            //toplam ilçe sayısı 
            labelControl18.Text= db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
        }

        //il seçildiğinde ilçesini getirme
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());

            lookUpEdit2.Properties.DataSource = (from x in db.TBLILCELER
                                                 select new
                                                 {
                                                     x.ilceId,
                                                     x.IlceAdi,
                                                     x.SehirId
                                                 }).Where(z => z.SehirId == secilen).ToList();
        }

        //Cari Kaydet
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtCariAd.Text!="" && txtCariSoyad.Text!="" && txtCariAd.Text.Length<=50)
            {
                TBLCARI t = new TBLCARI();
                t.AD = txtCariAd.Text;
                t.SOYAD = txtCariSoyad.Text;
                t.IL = lookUpEdit1.Text;
                t.ILCE = lookUpEdit2.Text;

                db.TBLCARI.Add(t);
                db.SaveChanges();

                MessageBox.Show("Cari Eklendi");
                liste();
            }

            else
            {
                MessageBox.Show("Cari Eklenmedi");
            }

            
        }
    }
}
