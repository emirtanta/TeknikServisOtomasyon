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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();

            if (txtDepartmanAd.Text.Length <= 50 && txtDepartmanAd.Text != "" )
            {
                t.AD = txtDepartmanAd.Text;
                //t.ACIKLAMA = richTxtAciklama.Text;

                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();

                MessageBox.Show("Departman kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Kayıt yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
