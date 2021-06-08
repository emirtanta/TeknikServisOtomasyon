using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               CARI=x.TBLCARI.AD+" " + x.TBLCARI.SOYAD,
                               PERSONEL=x.TBLPERSONEL.AD + " "+x.TBLPERSONEL.SOYAD,
                               x.GELISTARIHI,
                               x.CIKISTARIHI,
                               x.URUNSERINO,
                               x.URUMDURUMDETAY
                           };
            gridControl1.DataSource = degerler.ToList();

            //arızalı ürün sayısı
            labelControl3.Text =db.TBLURUNKABUL.Count(x=>x.URUNDURUM==true).ToString();

            //tadilatı bitimiş ürün sayısı
            labelControl5.Text= db.TBLURUNKABUL.Count(x => x.URUNDURUM == false).ToString();

            //parça bekleyen ürün sayısı
            labelControl7.Text = db.TBLURUNKABUL.Count(x => x.URUMDURUMDETAY == "Parça bekliyor").ToString();

            //mesaj beklenen müşteriler
            labelControl15.Text= db.TBLURUNKABUL.Count(x => x.URUMDURUMDETAY == "Mesaj bekliyor").ToString();

            //toplam ürün sayısı
            labelControl11.Text = db.TBLURUN.Count().ToString();

            //iptal edilen işlemleri
            labelControl13.Text = db.TBLURUNKABUL.Count(x => x.URUMDURUMDETAY == "İptal bekliyor").ToString(); ;

            //charta veritabanından dinamik olarak verileri getirdik
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QVN1TMN;Initial Catalog=DBTeknikServis;User ID=sa;Password=1234");
            SqlCommand komut = new SqlCommand("Select  URUNDURUMDETAY,COUNT(*) from TBLURUNKABUL Group By URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        //gridview double clik ile arıza detay popuna yönlerdime yaptık
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();

            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();

            fr.Show();
        }
    }
}
