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
    public partial class FrmCariiller : Form
    {
        public FrmCariiller()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //grafikte carilerin bulunduğu illeri göstermek için tanımladık
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QVN1TMN;Initial Catalog=DBTeknikServis;User ID=sa");

        private void FrmCariiller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 22);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 10);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 12);

            //carileri bulunduğu ile göre gruplandırarak listeledik
            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).
                GroupBy(y => y.IL).
                Select(z => new
                {
                    İL = z.Key,
                    TOPLAM = z.Count()
                }).ToList();

            //chart üzerinde carileri gruplayarak gösterme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,COUNT(*) FROM TBLCARI group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString( dr[0]),int.Parse(dr[1].ToString()));

                baglanti.Close();
            }
        }
    }
}
