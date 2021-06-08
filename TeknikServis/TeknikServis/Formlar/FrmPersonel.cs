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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        //personellerin listesini getiren metot
        void liste()
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            liste();

            //departmanları dropdownliste çekme
            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                select new
                                                {
                                                    x.ID,
                                                    x.AD
                                                }).ToList();

            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;
            //1.personel
            ad1= db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1= db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl8.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAIL;

            //personelin departmanını yazdırdık
            labelControl6.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD;

            labelControl3.Text = ad1 + " " + soyad1;

            //2. personel
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;

            //personelin mail adresini getirdik
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;

            //personelin departmanını yazdırdık
            labelControl11.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;

            //ad soyad getirdik
            labelControl14.Text = ad1 + " " + soyad1;

            //3. personel
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;

            //personelin mail adresini getirdik
            labelControl16.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;

            //personelin departmanını yazdırdık
            labelControl18.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;

            //ad soyad getirdik
            labelControl20.Text = ad1 + " " + soyad1;

            //4. personel
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;

            //personelin mail adresini getirdik
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;

            //personelin departmanını yazdırdık
            labelControl11.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;

            //ad soyad getirdik
            labelControl14.Text = ad1 + " " + soyad1;
        }

        //Kaydet butonu bölümü
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;
            t.DEPARTMAN = int.Parse(lookUpEdit1.EditValue.ToString());
            t.TELEFON = txtTelefon.Text;
            t.MAIL = txtMail.Text;

            db.TBLPERSONEL.Add(t);
            db.SaveChanges();

            MessageBox.Show("Personel eklendi");

            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }
    }
}
