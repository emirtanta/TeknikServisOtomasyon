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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            //okunmayan lotları listeleme
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();

            //okunan notları listeleme
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();


        }

        //Kaydet butonu bölümü
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.BASLIK = txtBaslık.Text;
            t.ICERIK = txtIcerik.Text;
            t.DURUM = false;
            t.TARIH = DateTime.Parse(txtTarih.Text);

            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();

            MessageBox.Show("Not eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Listele butonu bölümü
        private void BtnListele_Click(object sender, EventArgs e)
        {
            //okunmayan lotları listeleme
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();

            //okunan notları listeleme
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();
        }

        //Güncelle butonu bölümü
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked==true)
            {
                int id = int.Parse(txtNotID.Text);

                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;

                db.SaveChanges();

                MessageBox.Show("Not durumu güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            txtNotID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }
    }
}
