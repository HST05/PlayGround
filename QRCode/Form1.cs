using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace QRCoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData data =
                qrCodeGenerator.CreateQrCode("SAMET GOTUNU S2M KAJSHDLASJKHDAS", QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(data);
            Bitmap bitmap = qrCode.GetGraphic(8);

            pictureBox1.Image = bitmap;
        }
    }
}
