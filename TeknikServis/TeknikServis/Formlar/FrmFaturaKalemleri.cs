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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //Ara butonu bölümü
        private void btnAra_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtFaturaID.Text);

            //fatura arama işlemi
            var degerler = (from u in db.TBLFATURADETAY
                           select new
                           {
                               u.FATURADETAYID,
                               u.URUN,
                               u.FIYAT,
                               u.TUTAR,
                               u.FATURAID
                           }).Where(x=>x.FATURAID==id).ToList();

            gridControl1.DataSource = degerler.ToList();
        }
    }
}
