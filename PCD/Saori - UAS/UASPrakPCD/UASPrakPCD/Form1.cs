using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace UASPrakPCD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            clearAwal();
        }

        private void ac1_Click(object sender, EventArgs e)
        {
            ac1.Enabled = false;
            dc1.Enabled = true;
            ac2.Enabled = false;
            dc2.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            pictureBox2.Hide();
        }

        private void ac2_Click(object sender, EventArgs e)
        {
            ac1.Enabled = false;
            dc1.Enabled = false;
            ac2.Enabled = false;
            dc2.Enabled = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = true;
                //dobrightness
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Enabled = false;
                //doinvert
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Enabled = true;
                //dothresholding
            }
            if (comboBox1.SelectedIndex == 4)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 5)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 6)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 7)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 8)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 9)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 10)
            {
                textBox1.Enabled = true;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 11)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 12)
            {
                textBox1.Enabled = true;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 13)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 14)
            {
                textBox1.Enabled = false;
                //dograyscale
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap meh = new Bitmap(pictureBox1.Image);
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = true;
                int val = Convert.ToInt16(textBox1.Text);
                textBox3.AppendText("Brightness\r\n");
                brightness(bmp, val);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Invert\r\n");
                invertBM(bmp);
                //doinvert
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Gray\r\n");
                Konversi2GreyViaPointer(bmp);
                //dograyscale
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Enabled = true;
                int val = Convert.ToInt16(textBox1.Text);
                textBox3.AppendText("thresholding\r\n");
                meh=thresholdingBM(bmp, val);
                //dothresholding
            }
            if(comboBox1.SelectedIndex == 4)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("bluring\r\n");
                bluring(bmp);
                //dobluring
            }
            if (comboBox1.SelectedIndex == 5)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("sharpening\r\n");
                sharpening(bmp);
                //dosharpening
            }
            if (comboBox1.SelectedIndex == 6)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("sharpening\r\n");
                sharpening(bmp);
                //dosharpening
            }
            if (comboBox1.SelectedIndex == 7)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("embosing\r\n");
                embosing(bmp);
                //doembosing
            }
            if (comboBox1.SelectedIndex == 7)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("edging\r\n");
                edging(bmp);
                //doedging
            }
            if (comboBox1.SelectedIndex == 8)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Dilasi\r\n");
                Dilasi(meh);
                //dodilation
            }
            if (comboBox1.SelectedIndex == 9)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Erosi\r\n");
                Erosi(meh);
                //doerosi
            }
            if (comboBox1.SelectedIndex == 10)
            {
                textBox1.Enabled = true;
                textBox3.AppendText("Rotasi\r\n");
                rotasi(bmp);
                //dorotasi
            }
            if (comboBox1.SelectedIndex == 11)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Translasi\r\n");
                translasi(bmp);
                //dotranslasi
            }
            if (comboBox1.SelectedIndex == 12)
            {
                pictureBox3.SizeMode = PictureBoxSizeMode.Normal;
                textBox1.Enabled = true;
                textBox3.AppendText("scale\r\n");
                scale(bmp);
                //doscale
            }
            if (comboBox1.SelectedIndex == 13)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Mirror x\r\n");
                Bitmap bmpz = new Bitmap(pictureBox1.Image);
                bmpz.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox3.Image = bmpz;
                //domirrorx
            }
            if (comboBox1.SelectedIndex == 14)
            {
                textBox1.Enabled = false;
                textBox3.AppendText("Mirror y\r\n");
                Bitmap bmpz = new Bitmap(pictureBox1.Image);
                bmpz.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox3.Image = bmpz;
                //domirrory
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            /*
             * Add
             * Substract
             * Average
             * Minimum
             * Maximum
             */
            if (comboBox2.SelectedIndex == 0)
            {
                //doAdd
            }
            if (comboBox2.SelectedIndex == 1)
            {
                //doSubstract
            }
            if (comboBox2.SelectedIndex == 2)
            {
                //doAverage
            }
            if (comboBox2.SelectedIndex == 3)
            {
                //doMin
            }
            if (comboBox2.SelectedIndex == 0)
            {
                //doMax
            }
        }

        private void brightness(Bitmap bitmap, int value)
        {
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = data.Stride - data.Width * 3, nVal, nBrightness;
            int nWidth = data.Width * 3;
            nBrightness = Convert.ToInt16(value);
            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = (int)(ptr[0] + nBrightness);
                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;
                        ptr[0] = (byte)nVal;
                        ++ptr;
                    }
                    ptr += nOffset;
                }
            }
            bitmap.UnlockBits(data);
            pictureBox3.Image = bitmap;
        }

        private void dc1_Click(object sender, EventArgs e)
        {
            clearAwal();
        }
        public void clearAwal()
        {
            ac1.Enabled = true;
            dc1.Enabled = false;
            ac2.Enabled = true;
            dc2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Text = "0";
            textBox2.Enabled = false;
            textBox2.Text = "0";
            textBox3.Clear();
            pictureBox2.Show();
            pictureBox3.Image = null;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void dc2_Click(object sender, EventArgs e)
        {
            clearAwal();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void image1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bit = new Bitmap(open.FileName);
                    pictureBox1.Image = bit;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void image2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bit = new Bitmap(open.FileName);
                    pictureBox2.Image = bit;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tidak bisa load file");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /*SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(pictureBox3.Image);
                    dialog.DefaultExt = "png";
                    dialog.AddExtension = true;
                    bmp.Save("save.png", ImageFormat.Png);
                }*/
            Bitmap bmp = new Bitmap(pictureBox3.Image);
                bmp.Save("save.png", ImageFormat.Png);
                MessageBox.Show("Saved at Output Folder ^-^");
            }
            catch (Exception)
            {
                MessageBox.Show("Tidak bisa simpan file");
            }

        }

        private void invertBM(Bitmap bitmap)
        {
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = data.Stride - data.Width * 3, nVal;
            int nWidth = data.Width * 3;
            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = (int)(255 - ptr[0]);
                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;
                        ptr[0] = (byte)nVal;
                        ++ptr;
                    }
                    ptr += nOffset;
                }
            }
            bitmap.UnlockBits(data);
            pictureBox3.Image = bitmap;
        }
        private void Konversi2GreyViaPointer(Bitmap bmp)
        {
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    p[0] = (byte)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                    p[1] = p[0];
                    p[2] = p[0];
                    p += 3;
                }
            }
            bmp.UnlockBits(bmData);
            pictureBox3.Image = bmp;
        }
        private Bitmap thresholdingBM(Bitmap bitmap, int value)
        {
            Konversi2GreyViaPointer(bitmap);
            Bitmap gs = new Bitmap(pictureBox2.Image);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = data.Stride - data.Width * 3, nVal, nT = value;
            int nWidth = data.Width * 3;
            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = (int)(ptr[0]);
                        if (nVal <= nT) nVal = 0;
                        if (nVal > nT) nVal = 255;
                        ptr[0] = (byte)nVal;
                        ++ptr;
                    }
                    ptr += nOffset;
                }
            }
            bitmap.UnlockBits(data);
            pictureBox3.Image = bitmap;
            return bitmap;
        }

        private void bluring(Bitmap bmp)
        {
            Operator Filter = new Operator();
            Filter.TopLeft = 1;
            Filter.TopMid = 2;
            Filter.TopRight = 1;
            Filter.MidLeft = 2;
            Filter.Pixel = 4;
            Filter.MidRight = 2;
            Filter.BottomLeft = 1;
            Filter.BottomMid = 2;
            Filter.BottomRight = 1;
            Filter.Factor = 16;
            Filter.Offset = 0;
            pictureBox3.Image = (Bitmap)Filter.Konvolusi((Bitmap)pictureBox1.Image, Filter);
        }

        private void sharpening(Bitmap bmp)
        {
            Operator Filter = new Operator();
            Filter.TopLeft = 0;
            Filter.TopMid = -2;
            Filter.TopRight = 0;
            Filter.MidLeft = -2;
            Filter.Pixel = 11;
            Filter.MidRight = -2;
            Filter.BottomLeft = 0;
            Filter.BottomMid = 2;
            Filter.BottomRight = 0;
            Filter.Factor = 3;
            Filter.Offset = 0;
            pictureBox3.Image = (Bitmap)Filter.Konvolusi((Bitmap)pictureBox1.Image, Filter);
        }
        private void embosing(Bitmap bmp)
        {
            Operator Filter = new Operator();
            Filter.TopLeft = -1;
            Filter.TopMid = 0;
            Filter.TopRight = -1;
            Filter.MidLeft = 0;
            Filter.Pixel = 4;
            Filter.MidRight = 0;
            Filter.BottomLeft = -1;
            Filter.BottomMid = 0;
            Filter.BottomRight = -1;
            Filter.Factor = 1;
            Filter.Offset = 127;
            pictureBox3.Image = (Bitmap)Filter.Konvolusi((Bitmap)pictureBox1.Image, Filter);
        }
        private void edging(Bitmap bmp)
        {
            Operator Filter = new Operator();
            Filter.TopLeft = -1;
            Filter.TopMid = -1;
            Filter.TopRight = -1;
            Filter.MidLeft = 0;
            Filter.Pixel = 0;
            Filter.MidRight = 0;
            Filter.BottomLeft = 1;
            Filter.BottomMid = 1;
            Filter.BottomRight = 1;
            Filter.Factor = 1;
            Filter.Offset = 127;
            pictureBox3.Image = (Bitmap)Filter.Konvolusi((Bitmap)pictureBox1.Image, Filter);
        }
        private void Erosi(Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp);
            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;
                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        //Channel warna ...
                        List<int> listPixel = new List<int>();

                       
                            listPixel.Add(pSrc[2]);
                            listPixel.Add(pSrc[5]);
                            listPixel.Add(pSrc[8]);
                            listPixel.Add(pSrc[2 + stride]);
                            listPixel.Add(pSrc[5 + stride]);
                            listPixel.Add(pSrc[8 + stride]);
                            listPixel.Add(pSrc[2 + stride2]);
                            listPixel.Add(pSrc[5 + stride2]);
                            listPixel.Add(pSrc[8 + stride2]);
                        
                        nPixel = listPixel.Max();

                        //nPixel = (pSrc[2] + pSrc[5] + pSrc[8] + pSrc[2 + stride] + pSrc[5 + stride] + pSrc[8 + stride] + pSrc[2 + stride2] + pSrc[5 + stride2] + pSrc[8 + stride2]) / 9;
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[5 + stride] = (byte)nPixel;
                        //Ulangi perintah ini untuk 2 channel warna lainnya dengan mengubah indeksnya 

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                b.UnlockBits(bmData);
                bSrc.UnlockBits(bmSrc);
                pictureBox3.Image = b;
            }
        }

        private void Dilasi(Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp);
            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;
                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        //Channel warna ...
                        List<int> listPixel = new List<int>();

                        
                            listPixel.Add(pSrc[2]);
                            listPixel.Add(pSrc[5]);
                            listPixel.Add(pSrc[8]);
                            listPixel.Add(pSrc[2 + stride]);
                            listPixel.Add(pSrc[5 + stride]);
                            listPixel.Add(pSrc[8 + stride]);
                            listPixel.Add(pSrc[2 + stride2]);
                            listPixel.Add(pSrc[5 + stride2]);
                            listPixel.Add(pSrc[8 + stride2]);
                       
                        nPixel = listPixel.Min();

                        //nPixel = (pSrc[2] + pSrc[5] + pSrc[8] + pSrc[2 + stride] + pSrc[5 + stride] + pSrc[8 + stride] + pSrc[2 + stride2] + pSrc[5 + stride2] + pSrc[8 + stride2]) / 9;
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[5 + stride] = (byte)nPixel;
                        //Ulangi perintah ini untuk 2 channel warna lainnya dengan mengubah indeksnya 

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                b.UnlockBits(bmData);
                bSrc.UnlockBits(bmSrc);
                pictureBox3.Image = b;
            }
        }
        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }
        private void rotasi(Bitmap bmp)
        {
            int angle = Convert.ToInt16(textBox1.Text);
            bmp = RotateImage(bmp, angle);
            pictureBox3.Image = bmp;
        }
        private Bitmap TranslateImage(Bitmap bmp, int x, int y)
        {
            Bitmap translatedImage = new Bitmap(bmp.Width, bmp.Height);
            using (Graphics g = Graphics.FromImage(translatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(x, y);
                g.DrawImage(bmp, new Point(0, 0));
            }
            return translatedImage;
        }
        private void translasi(Bitmap bmp)
        {
            pictureBox3.Image= TranslateImage(bmp, 30, 30);

        }
        private void scale(Bitmap bmp)
        {
            int size = Convert.ToInt16(textBox1.Text);
            bmp = new Bitmap(bmp, new Size(bmp.Width + size, bmp.Height + size));
            pictureBox3.Image = bmp;
        }
        public Bitmap frameBased(Bitmap sourceBitmap, Bitmap blendBitmap, string operasi)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);


            BitmapData blendData = blendBitmap.LockBits(new Rectangle(0, 0,
                                   blendBitmap.Width, blendBitmap.Height),
                                   ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] blendBuffer = new byte[blendData.Stride * blendData.Height];
            Marshal.Copy(blendData.Scan0, blendBuffer, 0, blendBuffer.Length);
            blendBitmap.UnlockBits(blendData);


            for (int k = 0; (k + 4 < pixelBuffer.Length) &&
                            (k + 4 < blendBuffer.Length); k += 4)
            {
                pixelBuffer[k] = Hitung(pixelBuffer[k], blendBuffer[k], operasi);


                pixelBuffer[k + 1] = Hitung(pixelBuffer[k + 1], blendBuffer[k + 1], operasi);


                pixelBuffer[k + 2] = Hitung(pixelBuffer[k + 2], blendBuffer[k + 2], operasi);
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public byte Hitung(byte color1, byte color2, string tipe)
        {
            byte resultValue = 0;
            int intResult = 0;

            if (tipe == "Add")
            {
                intResult = color1 + color2;
            }
            else if (tipe == "Subtract")
            {
                intResult = color1 - color2;
            }
            else if (tipe == "Diﬀerence")
            {
                intResult = Math.Abs(color1 - color2);
            }
            else if (tipe == "Multiply")
            {
                intResult = (int)((color1 / 255.0 * color2 / 255.0) * 255.0);
            }
            else if (tipe == "Average")
            {
                intResult = (color1 + color2) / 2;
            }
            else if (tipe == "Cross Fading")
            {
                //int(img1[x][y].r∗weight + img2[x][y].r∗(1−weight)) ;
                //intResult = (color1* + color2*(1-));
            }
            else if (tipe == "Min")
            {
                intResult = (color1 < color2 ? color1 : color2);
            }
            else if (tipe == "Max")
            {
                intResult = (color1 > color2 ? color1 : color2);
            }
            else if (tipe == "Amplitude")
            {
                intResult = (int)(Math.Sqrt(color1 * color1 + color2 * color2)
                                                            / Math.Sqrt(2.0));
            }
            else if (tipe == "AND")
            {
                intResult = color1 & color2;
            }
            else if (tipe == "OR")
            {
                intResult = color1 | color2;
            }
            else if (tipe == "XOR")
            {
                intResult = color1 ^ color2;
            }


            if (intResult < 0)
            {
                resultValue = 0;
            }
            else if (intResult > 255)
            {
                resultValue = 255;
            }
            else
            {
                resultValue = (byte)intResult;
            }


            return resultValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap g1 = new Bitmap(pictureBox1.Image);
            Bitmap g2 = new Bitmap(pictureBox2.Image);
            if (comboBox2.SelectedIndex == 0)
            {
                pictureBox3.Image = frameBased(g1, g2, "Add");
                textBox3.AppendText("Add\r\n");
            }
            if (comboBox2.SelectedIndex == 1)
            {
                pictureBox3.Image = frameBased(g1, g2, "Subtract");
                textBox3.AppendText("Subtract\r\n");
                //doSubstract
            }
            if (comboBox2.SelectedIndex == 2)
            {
                pictureBox3.Image = frameBased(g1, g2, "Average");
                textBox3.AppendText("Average\r\n");
                //doAverage
            }
            if (comboBox2.SelectedIndex == 3)
            {
                pictureBox3.Image = frameBased(g1, g2, "Min");
                textBox3.AppendText("Min\r\n");
                //doMin
            }
            if (comboBox2.SelectedIndex == 4)
            {
                pictureBox3.Image = frameBased(g1, g2, "Max");
                textBox3.AppendText("Max\r\n");
                //doMax
            }
        }
    }
}
