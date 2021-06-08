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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //Faturaya Kalem girme 
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = txtUrun.Text;
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.TUTAR = decimal.Parse(txtTutar.Text);
            t.FATURAID = int.Parse(txtFaturaID.Text);

            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();

            MessageBox.Show("Faturaya ait kalem girişi başarı ile yapıldı");
        }

        //Listele butonu
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURADETAY
                           select new
                           {
                               u.FATURADETAYID,
                               u.URUN,
                               u.FIYAT,
                               u.TUTAR,
                               u.FATURAID
                           };

            gridControl1.DataSource = degerler.ToList();
        }

        //FrmFaturaKalem load bölümü
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURADETAY
                           select new
                           {
                               u.FATURADETAYID,
                               u.URUN,
                               u.FIYAT,
                               u.TUTAR,
                               u.FATURAID
                           };

            gridControl1.DataSource = degerler.ToList();
        }
    }
}
