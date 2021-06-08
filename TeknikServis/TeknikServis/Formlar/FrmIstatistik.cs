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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //istatistik formu bölgesi
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //toplam ürün sayısı
            labelControl2.Text = db.TBLURUN.Count().ToString();

            //toplam kategori sayısı
            labelControl3.Text = db.TBLKATEGORI.Count().ToString();

            //toplam stok sayısı
            labelControl5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();

            //kritik seviye
            labelControl7.Text = "10";

            //bugün satılan ürün sayısı
            labelControl9.Text = "";


            //

            //en fazla stoklu ürün adı
            labelControl11.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();

            //en az stoklu ürün adı
            labelControl13.Text= (from x in db.TBLURUN
                                  orderby x.STOK ascending
                                  select x.AD).FirstOrDefault();

            //en fazla ürün kategorisi
            labelControl15.Text = db.makskategoriurun().FirstOrDefault();

            //en yüksek fiyatlı ürün adı
            labelControl17.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();

            //en düşük fiyatlı ürün adı
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault(); ;

            //

            //toplam marka sayısı
            labelControl21.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();

            //en fazla ürünlü marka adı
            labelControl23.Text = "";

            //arızalı ürün sayısı
            labelControl25.Text = db.TBLURUNKABUL.Count().ToString();

            //tamirdeki ürün sayısı
            labelControl27.Text = "";

            //bugün getirilen arızalı ürün sayısı
            labelControl29.Text = "";

            //

            //tadilatı bitmiş ürün sayısı
            labelControl31.Text = "";

            //kargodaki ürün sayısı
            labelControl33.Text = "";

            //beyaz eşya stok sayısı
            labelControl35.Text = db.TBLURUN.Count(x=>x.KATEGORI==4).ToString();

            //bilgisayar stok saysı
            labelControl37.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();

            //küçük ev aletleri stok sayısı
            labelControl39.Text = db.TBLURUN.Count(x => x.KATEGORI == 3).ToString();
        }
    }
}
