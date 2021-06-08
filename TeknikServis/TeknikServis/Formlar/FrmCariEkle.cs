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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        int secilen; //il dropdowlisti için seçilen ilin ilçelerini getirebilmek için tanımladık

        //load kısmı
        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            //il tablosundan verileri dropdown içerisine aktardık
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.SehirId,
                                                     x.SehirAdi
                                                 }).ToList();
        }

        //Kaydet butonu bölgesi
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLCARI t = new TBLCARI();
                t.AD = txtCariAd.Text;
                t.SOYAD = txtCariSoyad.Text;
                t.IL = lookUpEdit1.Text;
                t.ILCE = lookUpEdit2.Text;

                db.TBLCARI.Add(t);
                db.SaveChanges();

                MessageBox.Show("Cari Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }

            
        }

        //Vazgeç butonu
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //seçilen ile göre ilçeyi getirme
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());

            lookUpEdit2.Properties.DataSource = (from x in db.TBLILCELER
                                                 select new
                                                 {
                                                     x.ilceId,
                                                     x.IlceAdi,
                                                     x.SehirId
                                                 }).Where(z => z.SehirId == secilen).ToList();
        }

        private void pictureEdit13_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
