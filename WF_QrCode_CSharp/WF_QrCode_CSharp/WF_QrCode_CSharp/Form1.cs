using System;
using System.Drawing;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace WF_QrCode_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            QRCodeEncoder qrencod = new QRCodeEncoder();
            Bitmap qrcode = qrencod.Encode(url);
            picImage.Image = qrcode as Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG | *.png| JPEG| *.jpg | BMP| *.bmp";
            if (sfd.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                picImage.Image.Save(sfd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picImage.ImageLocation = ofd.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            MessageBox.Show(decoder.decode(new QRCodeBitmapImage(picImage.Image as Bitmap)));
        }
    }
}
