using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //mail göndermek için
using System.Net.Mail; //mail göndermek için

namespace TeknikServis.İletişim
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        //Gönder butonu bölümü
        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            string frommail = "gonderici"; //gönderici mail adresi
            string sifre = "şifreniz"; //mail şifresi
            string alici = txtAlici.Text;
            string konu = txtKonu.Text;
            string icerik = txtIcerik.Text;

            mail.From = new MailAddress(frommail);
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(frommail, sifre);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);

            MessageBox.Show("Mail gönderildi");
        }

        //vazgeç butonu bölümü
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
