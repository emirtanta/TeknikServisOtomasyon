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

namespace TeknikServis.Formlar
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            //kritik seviye groupcontrol kısmı (kritik sevideki (30) ürünleri listeleme)
            gridControl3.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x => x.STOK < 30).ToList();

            //fihrist groupcontrol kısmı
            gridControl1.DataSource = (from y in db.TBLCARI
                                       select new
                                       {
                                           y.AD,
                                           y.SOYAD,
                                           y.IL
                                       }).ToList();

            //Ürün- Kategori groupcontrol kısmına kategorideki ürünlerin adetini getiren procedure
            gridControl2.DataSource = db.urunkategori().ToList();

            //Bugün Yapılacaklar groupcontrol kısmı ilgili güne göre yapılacak listesini listeleme
            DateTime bugun = DateTime.Today;
            var deger = (from x in db.TBLNOTLARIM.OrderBy(y => y.TARIH) where (x.TARIH == bugun) select new { x.BASLIK, x.ICERIK });

            gridControl4.DataSource = deger.ToList();

            //Son 10 mesaj kısmındaki mesaj değerlerini getirilmesi
            string konu1, ad1, konu2, ad2, konu3, ad3, konu4, ad4;
            konu1 = db.TBLILETISIM.First(x => x.ID == 1).KONU;
            ad1 = db.TBLILETISIM.First(x => x.ID == 1).ADSOYAD;
            labelControl1.Text = konu1 + " - " + ad1;

            //konu2 = db.TBLILETISIM.First(x => x.ID == 2).KONU;
            //ad2 = db.TBLILETISIM.First(x => x.ID == 2).ADSOYAD;
            //labelControl1.Text = konu1 + " - " + ad1;

            //konu3 = db.TBLILETISIM.First(x => x.ID == 3).KONU;
            //ad3 = db.TBLILETISIM.First(x => x.ID == 3).ADSOYAD;
            //labelControl1.Text = konu1 + " - " + ad1;

            //konu4 = db.TBLILETISIM.First(x => x.ID == 4).KONU;
            //ad4 = db.TBLILETISIM.First(x => x.ID == 4).ADSOYAD;
            //labelControl1.Text = konu1 + " - " + ad1;
        }
    }
}
