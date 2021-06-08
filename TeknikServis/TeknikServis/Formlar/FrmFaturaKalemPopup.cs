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
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        public int id;

        //faturanın detaylarını getirdik
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLFATURADETAY.Where(x => x.FATURAID == id).ToList();
            gridControl2.DataSource = db.TBLFATURABILGI.Where(x => x.ID == id).ToList();
        }

        //pdf formatında indirme butonu bölümü
        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.pdf";
            gridControl1.ExportToPdf(path);
        }

        //excel formatında indirme butonu bölümü
        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.xls";
            gridControl1.ExportToXls(path);
        }

        //x butonu bölümü
        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
