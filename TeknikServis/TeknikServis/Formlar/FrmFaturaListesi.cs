﻿using System;
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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               CARI=u.TBLCARI.AD+u.TBLCARI.SOYAD,
                               PERSONEL=u.TBLPERSONEL.AD+u.TBLPERSONEL.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();

            //carileri dropdownliste çekme
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD=x.AD+ " "+x.SOYAD
                                                 }).ToList();

            //personelleri dropdownliste çekme
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     //AD= denmesinin sebebi veritabanında da aynı AD değeri olduğundan dolayı hata almamak için tanımladık
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        //Listele butonu bölümü
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               CARI = u.TBLCARI.AD + u.TBLCARI.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD + u.TBLPERSONEL.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();

            //carileri dropdownliste çekme
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();

            //personelleri dropdownliste çekme
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        //Kaydet butonu (Yeni Fatura Girişi)
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = txtSeri.Text;
            t.SIRANO = txtSira.Text;
            t.TARIH =DateTime.Parse(txtTarih.Text);
            t.SAAT = txtSaat.Text;
            t.VERGIDAIRE = txtVergiDairesi.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = int.Parse(lookUpEdit2.EditValue.ToString());

            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();

            MessageBox.Show("Fatura sisteme kaydedildi,kalem girişi yapabilirsiniz");
        }

       

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();

            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

            fr.Show();
        }
    }
}
