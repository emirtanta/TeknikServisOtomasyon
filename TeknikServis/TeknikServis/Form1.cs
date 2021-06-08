using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ürün listesini formuna geçiş yaptık
            Formlar.FrmUrunListesi fr = new Formlar.FrmUrunListesi();

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmUrunListesi();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Yeni Ürün Butonu bölgesi
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ürün listesini formuna geçiş yaptık
            Formlar.FrmYeniUrun fr = new Formlar.FrmYeniUrun();
            fr.Show();
        }

        //kategori listesi butonu
        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKategori fr = new Formlar.FrmKategori();

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmKategori();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Yeni Kategori butonu bölgesi
        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            fr.Show();
        }

        //Ürün İstatistikleri butonu bölgesi
        private void BtnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmIstatistik fr = new Formlar.FrmIstatistik();

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmIstatistik();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        // Marka İstatistikleri butonu bölgesi
        private void BtnMarkaIst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmMarkalar fr = new Formlar.FrmMarkalar();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmMarkalar();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Cari Listesi Butonu
        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariListesi fr = new Formlar.FrmCariListesi();

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmCariListesi();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Cari İl İstatistikleri Butonu
        private void BtnCariilistatistigi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariiller fr = new Formlar.FrmCariiller();

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmCariiller();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Yeni Cari Ekle Butonu bölümü
        private void BtnCariEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariEkle fr = new Formlar.FrmCariEkle();
            fr.Show();
        }

        //departman listesi butonu
        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartman fr = new Formlar.FrmDepartman();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmDepartman();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Yeni Departman Butonu bölümü
        private void BtnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniDepartman fr = new Formlar.FrmYeniDepartman();
            fr.Show();
        }

        //Personel Listesi butonu bölümü
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonel fr = new Formlar.FrmPersonel();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmPersonel();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Hesap Makinesi Butonu bölümü
        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bilgisayardaki hesap makinesinin çalıştırılmasını sağlar
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnDovizKurlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKurlar fr = new Formlar.FrmKurlar();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmKurlar();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bilgisayardaki word'ün çalıştırılmasını sağlar
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bilgisayardaki excel'in çalıştırılmasını sağlar
            System.Diagnostics.Process.Start("excel");
        }

        //Youtube butonu bölümü
        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYoutube fr = new Formlar.FrmYoutube();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmYoutube();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Ajanda Butonu bölgesi
        private void BtnNotListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmNotlar fr = new Formlar.FrmNotlar();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmNotlar();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Arızakı Ürün Listesi Butonu
        private void BtnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaListesi fr = new Formlar.FrmArizaListesi();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmArizaListesi();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Yeni Ürün Satış Butonu
        private void BtnUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatis fr = new Formlar.FrmUrunSatis();
            fr.Show();
        }

        //Satış Listesi butonu
        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmSatislar fr = new Formlar.FrmSatislar();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmSatislar();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Yeni Arızalı Ürün Kaydı Butonu
        private void BtnYeniArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunKaydi fr = new Formlar.FrmArizaliUrunKaydi();
            fr.Show();
        }

        //Arızalı Ürün Açıklama butonu
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaDetaylar fr = new Formlar.FrmArizaDetaylar();
            fr.Show();
        }

        private void BtnArizaliUrunDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunDetayListesi fr = new Formlar.FrmArizaliUrunDetayListesi();
            fr.Show();
        }

        //QR Kod Oluştur butonu
        private void BtnQRKodOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRCode fr = new Formlar.FrmQRCode();
            fr.Show();
        }

        private void BtnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaListesi fr = new Formlar.FrmFaturaListesi();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmFaturaListesi();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Faturaa Kalem Girişi butonu
        private void BtnFaturKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalem fr = new Formlar.FrmFaturaKalem();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmFaturaKalem();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //Detaylı Fatura Sorgulama butonu
        private void BtnFaturaKalemListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalemleri fr = new Formlar.FrmFaturaKalemleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGauge fr = new Formlar.FrmGauge();
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmGauge();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        //rapor sihiribazı butonu bölümü
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRapor fr = new Formlar.FrmRapor();
            fr.Show();
        }

        Formlar.FrmAnaSayfa fr ;
        private void Form1_Load(object sender, EventArgs e)
        {

            if (fr==null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }

            
        }

        //AnaSayfa butonu bölümü
        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //butona basıldığında sınırsızca yeni sekme açmayı engellemek için tanımladık
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }

        }
        
        //Rehber butonu bölümü
        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            İletişim.FrmRehber fr = new İletişim.FrmRehber();
            if (fr == null || fr.IsDisposed)
            {
                fr = new İletişim.FrmRehber();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void BtnGelenMesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            İletişim.FrmGelenMesajlar fr = new İletişim.FrmGelenMesajlar();
            if (fr == null || fr.IsDisposed)
            {
                fr = new İletişim.FrmGelenMesajlar();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void BtnYeniMesaj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            İletişim.FrmMail fr = new İletişim.FrmMail();

            fr.Show();
            
        }
    }
}
