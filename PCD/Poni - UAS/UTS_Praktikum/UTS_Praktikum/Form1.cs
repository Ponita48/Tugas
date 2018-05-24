using OtsuThreshold;
using PCD05_AreaBasedFiltering;
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

namespace UTS_Praktikum
{
    public partial class Form1 : Form
    {
        private Otsu ot = new Otsu();
        private LogicalOperator lp = new LogicalOperator();
        Bitmap a, b;

        public Form1()
        {
            InitializeComponent();
            lp.setImage((Bitmap)pictureBox1.Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "2";
            textBox3.Text = "1";
            textBox4.Text = "2";
            textBox5.Text = "4";
            textBox6.Text = "2";
            textBox7.Text = "1";
            textBox8.Text = "2";
            textBox9.Text = "1";
            textBox10.Text = "16";
            textBox11.Text = "0";
            MaskFilter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "-2";
            textBox3.Text = "0";
            textBox4.Text = "-2";
            textBox5.Text = "11";
            textBox6.Text = "-2";
            textBox7.Text = "0";
            textBox8.Text = "-2";
            textBox9.Text = "0";
            textBox10.Text = "3";
            textBox11.Text = "0";
            MaskFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "-1";
            textBox2.Text = "-1";
            textBox3.Text = "-1";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "1";
            textBox8.Text = "1";
            textBox9.Text = "1";
            textBox10.Text = "1";
            textBox11.Text = "127";
            MaskFilter();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "-1";
            textBox2.Text = "0";
            textBox3.Text = "-1";
            textBox4.Text = "0";
            textBox5.Text = "4";
            textBox6.Text = "0";
            textBox7.Text = "-1";
            textBox8.Text = "0";
            textBox9.Text = "-1";
            textBox10.Text = "1";
            textBox11.Text = "127";
            MaskFilter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Median(bm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Averaging(bm);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Minimum(bm);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Maximum(bm);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Brightness(bm);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Invert(bm);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Grayscale(bm);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Threshold(bm);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            bm = Threshold(bm);
            pictureBox2.Image = Dilation(bm);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            bm = Threshold(bm);
            pictureBox2.Image = Dilation(bm);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "1";
            textBox3.Text = "0";
            textBox4.Text = "1";
            textBox5.Text = "1";
            textBox6.Text = "1";
            textBox7.Text = "0";
            textBox8.Text = "1";
            textBox9.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "0";
            textBox3.Text = "1";
            textBox4.Text = "0";
            textBox5.Text = "1";
            textBox6.Text = "0";
            textBox7.Text = "1";
            textBox8.Text = "0";
            textBox9.Text = "1";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "1";
            textBox3.Text = "1";
            textBox4.Text = "1";
            textBox5.Text = "1";
            textBox6.Text = "1";
            textBox7.Text = "1";
            textBox8.Text = "1";
            textBox9.Text = "1";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "1";
            textBox3.Text = "1";
            textBox4.Text = "1";
            textBox5.Text = "0";
            textBox6.Text = "1";
            textBox7.Text = "1";
            textBox8.Text = "1";
            textBox9.Text = "1";

        }

        private void MaskFilter()
        {
            Operator Filter = new Operator();
            Filter.topLeft = Convert.ToInt16(textBox1.Text);
            Filter.top = Convert.ToInt16(textBox2.Text);
            Filter.topRight = Convert.ToInt16(textBox3.Text);
            Filter.midLeft = Convert.ToInt16(textBox4.Text);
            Filter.mid = Convert.ToInt16(textBox5.Text);
            Filter.midRight = Convert.ToInt16(textBox6.Text);
            Filter.botLeft = Convert.ToInt16(textBox7.Text);
            Filter.bot = Convert.ToInt16(textBox8.Text);
            Filter.botRight = Convert.ToInt16(textBox9.Text);
            Filter.factor = Convert.ToInt16(textBox10.Text);
            Filter.offset = Convert.ToInt16(textBox11.Text);
            pictureBox2.Image = (Bitmap)Filter.Konvolusi((Bitmap)pictureBox1.Image, Filter);
        }

        public Bitmap Median(Bitmap b)
        {
            Bitmap bm = (Bitmap)b.Clone();
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr ScanSrc0 = bmSrc.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)ScanSrc0;
                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;
                int nPixel;
                for (int y = 0; y < nHeight; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        int[] array = {pSrc[2], pSrc[5], pSrc[8],
                            pSrc[2+stride], pSrc[5+stride], pSrc[8+stride],
                            pSrc[2+stride2], pSrc[5+stride2], pSrc[8+stride2]};
                        Array.Sort(array);
                        nPixel = array.ElementAt(4);
                        p[5 + stride] = (byte)nPixel;
                        int[] array2 = {pSrc[1], pSrc[4], pSrc[7],
                            pSrc[1+stride], pSrc[4+stride], pSrc[7+stride],
                            pSrc[1+stride2], pSrc[4+stride2], pSrc[7+stride2]};
                        Array.Sort(array2);
                        nPixel = array2.ElementAt(4);
                        p[4 + stride] = (byte)nPixel;
                        int[] array3 = {pSrc[0], pSrc[3], pSrc[6],
                            pSrc[0+stride], pSrc[3+stride], pSrc[6+stride],
                            pSrc[0+stride2], pSrc[3+stride2], pSrc[6+stride2]};
                        Array.Sort(array3);
                        nPixel = array3.ElementAt(4);
                        p[3 + stride] = (byte)nPixel;
                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                bm.UnlockBits(bmData);
                b.UnlockBits(bmSrc);
                return bm;
            }
        }

        public Bitmap Averaging(Bitmap b)
        {
            Bitmap bm = (Bitmap)b.Clone();
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr ScanSrc0 = bmSrc.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)ScanSrc0;
                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;
                int nPixel;
                for (int y = 0; y < nHeight; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        int[] array = {pSrc[2], pSrc[5], pSrc[8],
                            pSrc[2+stride], pSrc[5+stride], pSrc[8+stride],
                            pSrc[2+stride2], pSrc[5+stride2], pSrc[8+stride2]};
                        nPixel = Convert.ToInt16(array.Average());
                        p[5 + stride] = (byte)nPixel;
                        int[] array2 = {pSrc[1], pSrc[4], pSrc[7],
                            pSrc[1+stride], pSrc[4+stride], pSrc[7+stride],
                            pSrc[1+stride2], pSrc[4+stride2], pSrc[7+stride2]};
                        nPixel = Convert.ToInt16(array2.Average());
                        p[4 + stride] = (byte)nPixel;
                        int[] array3 = {pSrc[0], pSrc[3], pSrc[6],
                            pSrc[0+stride], pSrc[3+stride], pSrc[6+stride],
                            pSrc[0+stride2], pSrc[3+stride2], pSrc[6+stride2]};
                        nPixel = Convert.ToInt16(array3.Average());
                        p[3 + stride] = (byte)nPixel;
                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                bm.UnlockBits(bmData);
                b.UnlockBits(bmSrc);
                return bm;
            }
        }

        public Bitmap Maximum(Bitmap b)
        {
            Bitmap bm = (Bitmap)b.Clone();
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr ScanSrc0 = bmSrc.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)ScanSrc0;
                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;
                int nPixel;
                for (int y = 0; y < nHeight; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        int[] array = {pSrc[2], pSrc[5], pSrc[8],
                            pSrc[2+stride], pSrc[5+stride], pSrc[8+stride],
                            pSrc[2+stride2], pSrc[5+stride2], pSrc[8+stride2]};
                        List<int> list = new List<int>(array);
                        nPixel = list.Max();
                        p[5 + stride] = (byte)nPixel;
                        int[] array2 = {pSrc[1], pSrc[4], pSrc[7],
                            pSrc[1+stride], pSrc[4+stride], pSrc[7+stride],
                            pSrc[1+stride2], pSrc[4+stride2], pSrc[7+stride2]};
                        List<int> list2 = new List<int>(array2);
                        nPixel = list2.Max();
                        p[4 + stride] = (byte)nPixel;
                        int[] array3 = {pSrc[0], pSrc[3], pSrc[6],
                            pSrc[0+stride], pSrc[3+stride], pSrc[6+stride],
                            pSrc[0+stride2], pSrc[3+stride2], pSrc[6+stride2]};
                        List<int> list3 = new List<int>(array3);
                        nPixel = list3.Max();
                        p[3 + stride] = (byte)nPixel;
                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                bm.UnlockBits(bmData);
                b.UnlockBits(bmSrc);
                return bm;
            }
        }

        public Bitmap Minimum(Bitmap b)
        {
            Bitmap bm = (Bitmap)b.Clone();
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr ScanSrc0 = bmSrc.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)ScanSrc0;
                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;
                int nPixel;
                for (int y = 0; y < nHeight; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        int[] array = {pSrc[2], pSrc[5], pSrc[8],
                            pSrc[2+stride], pSrc[5+stride], pSrc[8+stride],
                            pSrc[2+stride2], pSrc[5+stride2], pSrc[8+stride2]};
                        nPixel = array.Min();
                        p[5 + stride] = (byte)nPixel;
                        int[] array2 = {pSrc[1], pSrc[4], pSrc[7],
                            pSrc[1+stride], pSrc[4+stride], pSrc[7+stride],
                            pSrc[1+stride2], pSrc[4+stride2], pSrc[7+stride2]};
                        nPixel = array2.Min();
                        p[4 + stride] = (byte)nPixel;
                        int[] array3 = {pSrc[0], pSrc[3], pSrc[6],
                            pSrc[0+stride], pSrc[3+stride], pSrc[6+stride],
                            pSrc[0+stride2], pSrc[3+stride2], pSrc[6+stride2]};
                        nPixel = array3.Min();
                        p[3 + stride] = (byte)nPixel;
                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                bm.UnlockBits(bmData);
                b.UnlockBits(bmSrc);
                return bm;
            }
        }

        public Bitmap Grayscale(Bitmap bmp)
        {
            Bitmap bm = (Bitmap)bmp.Clone();
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width,
                bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = bmData.Stride - bmData.Width * 3;
            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    p[0] = (byte)((p[2] + p[1] + p[0])/3);
                    p[1] = p[0];
                    p[2] = p[0];
                    p += 3;
                }
                //p += nOffset;
            }
            bm.UnlockBits(bmData);
            return bm;
        }

        public Bitmap Brightness(Bitmap bmp)
        {
            Bitmap bm = (Bitmap)bmp.Clone();
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataSrc = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = data.Stride - data.Width * 3, nVal, nBrightness = trackBar1.Value;
            int nWidth = data.Width * 3;
            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                byte* ptrSrc = (byte*)dataSrc.Scan0;
                for (int y = 0; y < data.Height; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        nVal = (int)ptrSrc[0] + nBrightness;
                        if (nVal < 0)
                        {
                            nVal = 0;
                        }
                        if (nVal > 255)
                        {
                            nVal = 255;
                        }
                        ptrSrc[0] = (byte)nVal;
                        ++ptrSrc;
                    }
                    ptrSrc += nOffset;
                }

            }
            bmp.UnlockBits(data);
            bm.UnlockBits(dataSrc);
            return bm;
        }

        public Bitmap Invert(Bitmap bmp)
        {
            Bitmap bm = (Bitmap)bmp.Clone();
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataSrc = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = data.Stride - data.Width * 3;
            int nWidth = data.Width * 3;
            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                byte* ptrSrc = (byte*)dataSrc.Scan0;
                for (int y = 0; y < data.Height; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        ptrSrc[0] = (byte)(255 - ptrSrc[0]);
                        ptrSrc[1] = (byte)(255 - ptrSrc[1]);
                        ptrSrc[2] = (byte)(255 - ptrSrc[2]);
                        ptrSrc += 1;
                    }
                    ptrSrc += nOffset;
                }

            }
            bmp.UnlockBits(data);
            bm.UnlockBits(dataSrc);
            return bm;
        }

        public Bitmap Threshold(Bitmap bmp)
        {
            Bitmap bm = Grayscale(bmp);
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width,
                bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int nOffset = bmData.Stride - bmData.Width * 3;
            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    p[0] = (byte)(p[0] > 125 ? 255 : 0);
                    p += 1;
                }
                //p += nOffset;
            }
            bm.UnlockBits(bmData);
            return bm;
        }

        public Bitmap Dilation(Bitmap b)
        {
            byte[,] sElement = new byte[3, 3] {
                    {Convert.ToByte(textBox1.Text),Convert.ToByte(textBox2.Text),Convert.ToByte(textBox3.Text) },
                    {Convert.ToByte(textBox4.Text),Convert.ToByte(textBox5.Text), Convert.ToByte(textBox6.Text) },
                    {Convert.ToByte(textBox7.Text), Convert.ToByte(textBox8.Text), Convert.ToByte(textBox9.Text) }
                };
            Bitmap bm = (Bitmap)b.Clone();
            lp.setImage(bm);
            lp.gray_Dilation(sElement);
            bm = lp.getImage();
            return bm;
        }

        public Bitmap Erosion(Bitmap b)
        {
            byte[,] sElement = new byte[3, 3] {
                    {Convert.ToByte(textBox1.Text),Convert.ToByte(textBox2.Text),Convert.ToByte(textBox3.Text) },
                    {Convert.ToByte(textBox4.Text),Convert.ToByte(textBox5.Text), Convert.ToByte(textBox6.Text) },
                    {Convert.ToByte(textBox7.Text), Convert.ToByte(textBox8.Text), Convert.ToByte(textBox9.Text) }
                };
            Bitmap bm = (Bitmap)b.Clone();
            bm = Grayscale(bm);
            lp.setImage(bm);
            lp.gray_Erosion(sElement);
            bm = lp.getImage();
            return bm;
        }

        public Bitmap AdaptiveManual(Bitmap bmp)
        {
            int sum = 0;
            for (int i = 0; i < pictureBox1.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Height; j++)
                {
                    int temp = bmp.GetPixel(i, j).R + bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).B;
                    bmp.SetPixel(i, j, Color.FromArgb(temp / 3, temp / 3, temp / 3));
                    sum += bmp.GetPixel(i, j).R;
                }
            }
            pictureBox1.Image = bmp;
            int inten = sum / (pictureBox1.Image.Width * pictureBox1.Image.Height);
            while (true)
            {
                int miuA = 0;
                int miuB = 0;
                int a = 0;
                int b = 0;
                for (int i = 0; i < pictureBox1.Image.Width; i++)
                {
                    for (int j = 0; j < pictureBox1.Image.Height; j++)
                    {
                        if (bmp.GetPixel(i, j).R > inten)
                        {
                            miuA += bmp.GetPixel(i, j).R;
                            a++;
                        }
                        else
                        {
                            miuB += bmp.GetPixel(i, j).R;
                            b++;
                        }
                    }
                }
                if (a > 0)
                {
                    miuA /= a;
                }
                if (b > 0)
                {
                    miuB /= b;
                }
                int temp = inten;
                inten = (miuA + miuB) / 2;
                if (temp == inten)
                {
                    break;
                }
            }

            Bitmap hasil = (Bitmap)pictureBox1.Image;

            for (int i = 0; i < pictureBox1.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Height; j++)
                {
                    if (bmp.GetPixel(i, j).R < inten)
                    {
                        hasil.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        hasil.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return hasil;
        }

        class Operator
        {

            public int topLeft = 0, top = 0, topRight = 0;
            public int midLeft = 0, midRight = 0, mid = 1;
            public int botLeft = 0, bot = 0, botRight = 0;

            public int factor = 1;
            public int offset = 0;

            public void SetAll(int val)
            {
                topLeft = top = topRight = midLeft = mid = midRight = botLeft = bot = botRight = val;
            }

            public Bitmap Konvolusi(Bitmap b, Operator m)
            {
                Bitmap bm = (Bitmap)b.Clone();
                if (m.factor == 0) return b;
                BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite,
                    PixelFormat.Format24bppRgb);
                BitmapData bmSrc = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite,
                    PixelFormat.Format24bppRgb);
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
                    for (int y = 0; y < nHeight; y++)
                    {
                        for (int x = 0; x < nWidth; x++)
                        {
                            nPixel = ((((pSrc[2] * m.topLeft) + (pSrc[5] * m.top) + (pSrc[8] * m.topRight)
                                + (pSrc[2 + stride] * m.midLeft) + (pSrc[5 + stride] * m.mid) + (pSrc[8 + stride] * m.midRight)
                                + (pSrc[2 + stride2] * m.botLeft) + (pSrc[5 + stride2] * m.bot) + (pSrc[8 + stride2] * m.botRight))
                                / m.factor) + m.offset);
                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;
                            p[5 + stride] = (byte)nPixel;
                            nPixel = ((((pSrc[1] * m.topLeft) + (pSrc[4] * m.top) + (pSrc[7] * m.topRight)
                                + (pSrc[1 + stride] * m.midLeft) + (pSrc[4 + stride] * m.mid) + (pSrc[7 + stride] * m.midRight)
                                + (pSrc[1 + stride2] * m.botLeft) + (pSrc[4 + stride2] * m.bot) + (pSrc[7 + stride2] * m.botRight))
                                / m.factor) + m.offset);
                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;
                            p[4 + stride] = (byte)nPixel;
                            nPixel = ((((pSrc[0] * m.topLeft) + (pSrc[3] * m.top) + (pSrc[6] * m.topRight)
                                + (pSrc[0 + stride] * m.midLeft) + (pSrc[3 + stride] * m.mid) + (pSrc[6 + stride] * m.midRight)
                                + (pSrc[0 + stride2] * m.botLeft) + (pSrc[3 + stride2] * m.bot) + (pSrc[6 + stride2] * m.botRight))
                                / m.factor) + m.offset);
                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;
                            p[3 + stride] = (byte)nPixel;
                            p += 3;
                            pSrc += 3;
                        }
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
                b.UnlockBits(bmData);
                bm.UnlockBits(bmSrc);
                return bm;
            }
        }

        private void gantiFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp *.jpg)|*.bmp; *.jpg";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(of.FileName);
            }
        }
        private void simpanHasilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new SaveFileDialog();
            fd.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg";
            fd.AddExtension = true;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch (Path.GetExtension(fd.FileName).ToUpper())
                {
                    case ".BMP":
                        pictureBox2.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".JPG":
                        pictureBox2.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".PNG":
                        pictureBox2.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            Bitmap temp = bm;
            //una
            button15_Click(sender, e); //plus
            pictureBox1.Image = bm;
            button4_Click(sender, e); //edging
            bm = (Bitmap)pictureBox2.Image;
            button15_Click(sender, e); //plus
            bm = Threshold(bm);
            pictureBox1.Image = bm;
            button1_Click(sender, e);
            bm = (Bitmap)pictureBox1.Image;
            button1_Click(sender, e);
            bm = (Bitmap)pictureBox1.Image;
            button1_Click(sender, e);
            bm = (Bitmap)pictureBox1.Image;
            button8_Click(sender, e); // max
            bm = Threshold(bm);
            button15_Click(sender, e); //plus
            bm = Erosion(bm); bm = Erosion(bm);
            bm = Dilation(bm);

            pictureBox1.Image = temp;
            pictureBox2.Image = bm;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            Bitmap temp = bm;
            //poni
            button15_Click(sender, e); //plus
            bm = Erosion(bm);
            bm = Dilation(bm);
            pictureBox1.Image = bm;
            button4_Click(sender, e); //edging
            bm = (Bitmap)pictureBox2.Image;
            button15_Click(sender, e); //plus
            bm = Erosion(bm);
            //bm = Invert(bm);
            //bm = AdaptiveManual(bm);
            bm = Threshold(bm);
            //bm = Invert(bm);
            bm = Dilation(bm);
            bm = Erosion(bm);

            pictureBox1.Image = temp;
            pictureBox2.Image = bm;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            Bitmap bm = (Bitmap)pictureBox1.Image;
            Bitmap temp = bm;

            //piiyy
            button4_Click(sender, e); //edging
            bm = (Bitmap)pictureBox2.Image;
            bm = Threshold(bm);
            //bm = Invert(bm);
            pictureBox1.Image = bm;
            button16_Click(sender, e); //cross
            bm = Erosion(bm);
            bm = Dilation(bm);
            button16_Click(sender, e); //cross
            bm = Erosion(bm);

            pictureBox1.Image = temp;
            pictureBox2.Image = bm;
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

        private void assign()
        {
            this.a = (Bitmap)pictureBox1.Image;
            this.b = (Bitmap)pictureBox3.Image;
        }

        // add
        private void button22_Click(object sender, EventArgs e)
        {
            assign();
            pictureBox2.Image = frameBased(a, b, "Add");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            assign();
            pictureBox2.Image = frameBased(a, b, "Subtract");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            assign();
            pictureBox2.Image = frameBased(a, b, "Average");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            assign();
            pictureBox2.Image = frameBased(a, b, "Min");
        }
        
        // select 2nd image
        private void button26_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp *.jpg)|*.bmp; *.jpg";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(of.FileName);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            assign();
            pictureBox2.Image = frameBased(a, b, "Max");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int angle = Convert.ToInt16(numericUpDown3.Value.ToString());
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp = RotateImage(bmp, angle);
            pictureBox2.Image = bmp;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(numericUpDown1.Value.ToString());
            int y = Convert.ToInt16(numericUpDown2.Value.ToString());
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp = TranslateImage(bmp, x, y);
            pictureBox2.Image = bmp;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(numericUpDown1.Value.ToString());
            int y = Convert.ToInt16(numericUpDown2.Value.ToString());
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp = new Bitmap(pictureBox1.Image, new Size(bmp.Width + x, bmp.Height + y));
            pictureBox2.Image = bmp;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox2.Image = bmp;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox2.Image = bmp;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox2.Image = bmp;

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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] hehe = {68, 119, 105, 107, 105, 32, 78, 117, 114, 107, 117, 114, 110, 105, 97, 119, 97, 110};
            String hehe1 = "";
            for (int i = 0; i < hehe.Length; i++)
            {
                hehe1 += Char.ConvertFromUtf32(hehe[i]);
            }
            MessageBox.Show(hehe1,"About");
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
    }
}
