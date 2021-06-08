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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //vazgeç butonu bölgesi
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            //FrmYeniUrun fr = new FrmYeniUrun();
            this.Close();
        }

        //Ürün Ekle Butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            TBLURUN t = new TBLURUN();
            t.AD = txtUrunAd.Text;
            t.ALISFIYAT = decimal.Parse(txtAlısFiyat.Text);
            t.SATISFIYAT = decimal.Parse(txtSatısFiyat.Text);
            t.STOK = short.Parse(txtStok.Text);
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.MARKA = txtMarka.Text;

            db.TBLURUN.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Kaydedildi");
        }

        //ürün adı kısmına basınca placeholderi otomatik kapattık
        private void txtUrunAd_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = "";
            txtUrunAd.Focus();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            //from yüklendiğinde kategori dopdown'ini yükledik
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.Ad,
                                                     x.ID
                                                 }).ToList();
        }
    }
}
