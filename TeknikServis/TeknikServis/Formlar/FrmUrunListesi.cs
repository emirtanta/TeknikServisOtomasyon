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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //ürün listesini getiren metot
        void metot1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               u.ALISFIYAT,
                               u.SATISFIYAT,
                               u.STOK,
                               kategori=u.TBLKATEGORI.Ad //kategorileri diğer tablodan seçmeyi sağladık
                           };
            //dorpdownlist içerisine kategorilerin adını getirdik
            gridControl1.DataSource = (from x in db.TBLKATEGORI
                                       select new { x.Ad, x.ID }).ToList();
        }
        
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //ürünleri listeledik
            //var degerler = db.TBLURUN.ToList();
            metot1();

            //kategorilerin dropdown içerisine çekimi
            lookUpEdit1.Properties.DataSource = db.TBLKATEGORI.ToList();
            
        }

        //ürün kaydetme bölgesi
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.ALISFIYAT = decimal.Parse(txtAlisFiyati.Text);
            t.SATISFIYAT = decimal.Parse(txtSatisFiyati.Text);
            t.STOK =short.Parse(txtStok.Text);
            t.DURUM = false;
            t.KATEGORI =byte.Parse(lookUpEdit1.EditValue.ToString());

            db.TBLURUN.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Temizle Butonu bölümü
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtAlisFiyati.Text = "";
            txtSatisFiyati.Text = "";
            txtMarka.Text = "";
            txtStok.Text = "";
            txtUrunAd.Text = "";
            txtUrunID.Text = "";

        }

        //ürün listesi bölgesi
        private void BtnListele_Click(object sender, EventArgs e)
        {
            //var degerler = db.TBLURUN.ToList();
            //gridControl1.DataSource = degerler;
            metot1();
        }

        //giridview içerisindeki satırlara basınca basılan değerin textboxlarda gözükmesini sağlar
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtUrunID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                txtAlisFiyati.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                txtSatisFiyati.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata oldu");
            }

            

        }

        //ürün silme butonu bölgesi
        //int id;
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUrunID.Text);
            var deger = db.TBLURUN.Find(id);

            db.TBLURUN.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        //ürün güncelleme bölgesi
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtUrunID.Text);
            var deger = db.TBLURUN.Find(id);
            deger.AD = txtUrunAd.Text;
            deger.MARKA = txtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(txtAlisFiyati.Text);
            deger.SATISFIYAT = decimal.Parse(txtSatisFiyati.Text);
            deger.STOK =short.Parse(txtStok.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());

            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
