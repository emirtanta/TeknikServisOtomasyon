using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec; //qr kod kütüphanesi

namespace TeknikServis.Formlar
{
    public partial class FrmQRCode : Form
    {
        public FrmQRCode()
        {
            InitializeComponent();
        }

        private void BtnQR_Click(object sender, EventArgs e)
        {
            //qr kod oluşturma
            QRCodeEncoder enc = new QRCodeEncoder();
            pictureEdit1.Image = enc.Encode(textEdit1.Text);
        }

        //vazgeç butonu bölümü
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
