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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            //kategorileri listeledik
            var degerler = from k in db.TBLKATEGORI
                           select new
                           {
                               k.ID,
                               k.Ad
                           };
            gridControl1.DataSource = degerler.ToList(); 
        }

        //kategori kaydet bölümü
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text!="" && txtAd.Text.Length<=50)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.Ad = txtAd.Text;

                db.TBLKATEGORI.Add(t);
                db.SaveChanges();

                MessageBox.Show("Kategori Kaydedildi");
            }

            else
            {
                MessageBox.Show("Kategori adı boş olamaz ve kategori adı 50 karakterden fazla olamaz");
            }

            
        }

        //Temizle butonu bölümü
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtID.Text = "";
        }

        //kategori listele butonu
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from k in db.TBLKATEGORI
                           select new
                           {
                               k.ID,
                               k.Ad
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        //gridview içerisine sütüna tıklandığında textbox içerisine verileri getirmek içi tanımladık
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        //kategori silme butonu
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLKATEGORI.Find(id);

            db.TBLKATEGORI.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Kategori Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        //kategori güncelleme butonu
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TBLKATEGORI.Find(id);

            deger.Ad = txtAd.Text;

            db.SaveChanges();

            MessageBox.Show("Kategori güncellendi");
        }
    }
}
