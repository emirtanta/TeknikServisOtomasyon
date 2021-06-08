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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKategoriAd.Text!="" && txtKategoriAd.Text.Length<=50)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.Ad = txtKategoriAd.Text;

                db.TBLKATEGORI.Add(t);
                db.SaveChanges();

                MessageBox.Show("Kategori eklendi");
            }

            else
            {
                MessageBox.Show("Lütfen karakter sayısını 0-50 arasında giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //x butonu bölümü
        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
