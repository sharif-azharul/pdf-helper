using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PDFHelper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filenameSrc = @"C:\pdf\result_Blank CONFIDENTIALITY AND NON-DISCLOSURE AGREEMENT - 2020 WG Signature (002).pdf";
            string filenameDest = @"C:\pdf\fresult_Blank CONFIDENTIALITY AND NON-DISCLOSURE AGREEMENT - 2020 WG Signature (002).pdf";
            string imageLoc = @"C:\pdf\20210412_123003_2.jpg";
            PdfDocument pdf = PdfReader.Open(filenameSrc, PdfDocumentOpenMode.Modify);

            PdfPage pdfPage = pdf.Pages[5];
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            //double x = double.Parse(textBox1.Text), y = double.Parse(textBox2.Text), w = double.Parse(textBox3.Text), h = double.Parse(textBox4.Text);

            int x = int.Parse(textBox1.Text), y = int.Parse(textBox2.Text), w = int.Parse(textBox3.Text), h = int.Parse(textBox4.Text);

            var tf = new XTextFormatter(graph);
            tf.Alignment = XParagraphAlignment.Justify;
            
            var rect = new XRect(x, y, w, h);

            XPen xpen = new XPen(XColors.White, 0);

            //graph.DrawRectangle(xpen,XBrushes.White, rect);
            //       XStringFormat format = new XStringFormat();
            
            //      format.LineAlignment = XLineAlignment.Near;
            //    format.Alignment = XStringAlignment.Near;




            XBrush brush = XBrushes.Black;
            tf.DrawString("06/01/2022", new
             XFont("Arial", 12), XBrushes.Black, new XRect(x, y, w, h));
            // agrremnet 355,120,150,50
            // Blank 320,250,150,40

            //DrawImage(graph, imageLoc, x, y, w, h);

            //            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Automatic);

            //XFont font = new XFont("SolaimanLipi", 12, XFontStyle.Regular, options);

            //            tf.DrawString("আমি আপনাদের কোন ফন্ট ডাউনলোড করতে পারছি না আমার সোনার বাংলা আমি তোমায় ভালোবাসি", font, XBrushes.Red, new XRect(x, y, w, h),XStringFormat.TopLeft);

            string pdfFilename = "firstpage.pdf";
            pdf.Save(filenameDest);
            textBox5.Text = string.Format("{0},{1},{2},{3}", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            MessageBox.Show("OK");
        }

        void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, x, y, width, height);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(","))
            {
                string[] list = textBox1.Text.Split(',');
                if (list.Length > 0)
                    textBox1.Text = list[0];
                if (list.Length > 1)
                    textBox2.Text = list[1];
                if (list.Length > 2)
                    textBox3.Text = list[2];
                if (list.Length > 3)
                    textBox4.Text = list[3];
            }
        }
    }
}
