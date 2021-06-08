using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            //her bir markanın ürün sayısını getirdik
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });

            gridControl1.DataSource = degerler.ToList();

            //toplam ürün sayısı
            labelControl2.Text = db.TBLURUN.Count().ToString();

            //toplam marka sayısı
            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();

            //en fazla ürünü olan marka
            labelControl5.Text =db.maksurunmarka().FirstOrDefault();


            //en yüksek fiyatlı marka adı
            labelControl7.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.AD).FirstOrDefault();


            //charta veritabanından dinamik olarak verileri getirdik
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QVN1TMN;Initial Catalog=DBTeknikServis;User ID=sa;Password=1234");
            SqlCommand komut = new SqlCommand("Select  MARKA,COUNT(*) from TBLURUN Group By MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            //chartcontrol'e manuel değer girme
            //chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Beko", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("Toshiba", 1);
            //chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 1);

            //line charta veritabanından değer girme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select  TBLKATEGORI.AD,COUNT(*) from TBLURUN INNER JOIN TBLKATEGORI ON TBLKATEGORI.ID = TBLURUN.KATEGORI Group By TBLKATEGORI.Ad ", baglanti);
            SqlDataReader dr2 = komut.ExecuteReader();

            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }

            //chartControl1.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            //chartControl1.Series["Kategoriler"].Points.AddPoint("Bilgisyar", 3);
            //chartControl1.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 6);
            //chartControl1.Series["Kategoriler"].Points.AddPoint("TV", 3);
            //chartControl1.Series["Kategoriler"].Points.AddPoint("Telefon", 2);
            //chartControl1.Series["Kategoriler"].Points.AddPoint("Diğer", 2);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
