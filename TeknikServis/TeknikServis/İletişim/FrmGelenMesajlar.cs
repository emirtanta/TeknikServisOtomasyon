using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeknikServis;

namespace TeknikServis.İletişim
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            //toplam mesaj sayısı
            labelControl6.Text = db.TBLILETISIM.Count().ToString();

            //toplam teşekkür mesaj sayısı
            labelControl14.Text = db.TBLILETISIM.Where(x => x.KONU == "Teşekkür").Count().ToString();

            //rica mesaj sayısı
            labelControl16.Text = db.TBLILETISIM.Where(x => x.KONU == "Rica").Count().ToString(); ;

            //şikayet mesaj sayısı
            labelControl18.Text= db.TBLILETISIM.Where(x => x.KONU == "Şikayet").Count().ToString();

            //toplam personel sayısı
            labelControl1.Text= db.TBLPERSONEL.Count().ToString();

            //toplam cari sayısı
            labelControl3.Text= db.TBLCARI.Count().ToString();

            //toplam kategori sayısı
            labelControl5.Text= db.TBLKATEGORI.Count().ToString();

            //toplam ürün sayısı
            labelControl8.Text= db.TBLURUN.Count().ToString();

            //iletişimdeki gelen mesajları gridde listeledik
            gridControl1.DataSource = (from x in db.TBLILETISIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.MAIL,
                                           x.MESAJ
                                       }).ToList();
        }
    }
}
