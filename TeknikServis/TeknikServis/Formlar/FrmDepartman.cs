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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();

            //toplam departman sayısı
            labelControl6.Text = db.TBLDEPARTMAN.Count().ToString();

            //toplam personel sayısı
            labelControl14.Text = db.TBLPERSONEL.Count().ToString();
            //en fazla departmanda çalışan personel sayısı
            //en az departmanda çalışan personel sayısı
        }

        //kaydet butonu bölgesi
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();

            if (txtAd.Text.Length<=50 && txtAd.Text !="" && richTxtAciklama.Text.Length>=1)
            {
                t.AD = txtAd.Text;
                t.ACIKLAMA = richTxtAciklama.Text;

                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();

                MessageBox.Show("Departman kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Kayıt yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Sil butonu bölümü
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtDepartmanID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);

            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();

            MessageBox.Show("Departman silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        //Güncelle butonu bölümü
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtDepartmanID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);

            deger.AD = txtAd.Text;
            deger.ACIKLAMA = richTxtAciklama.Text;

            db.SaveChanges();

            MessageBox.Show("Departman güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Listele butonu bölümü
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDepartmanID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            richTxtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }
    }
}
