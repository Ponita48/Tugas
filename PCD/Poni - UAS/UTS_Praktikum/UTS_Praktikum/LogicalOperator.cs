using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCD05_AreaBasedFiltering
{
    public class LogicalOperator
    {
        private Bitmap bmpimg, bmpimg2;

        public LogicalOperator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void setImage(Bitmap bmp)
        {
            bmpimg = bmpimg2 = (Bitmap)bmp.Clone();
        }

        public Bitmap getImage()
        {
            return bmpimg;
        }

        public Bitmap getImage2()
        {
            return (Bitmap)bmpimg2.Clone();
        }

        public void gray_Erosion(byte[,] sele)
        {
            Bitmap tempbmp = (Bitmap)bmpimg.Clone();

            BitmapData data2 = tempbmp.LockBits(new Rectangle(0, 0, tempbmp.Width, tempbmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData data = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte[,] sElement = sele;

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                byte* tptr = (byte*)data2.Scan0;

                ptr += data.Stride + 3;
                tptr += data.Stride + 3;

                int remain = data.Stride - data.Width * 3;

                for (int i = 1; i < data.Height - 1; i++)
                {
                    for (int j = 1; j < data.Width - 1; j++)
                    {


                        byte* temp = ptr - data.Stride - 3;
                        byte min = 255;

                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                if (min > temp[data.Stride * k + l * 3])
                                {
                                    if (sElement[k, l] != 0)
                                        min = temp[data.Stride * k + l * 3];
                                }
                            }
                        }

                        tptr[0] = tptr[1] = tptr[2] = min;


                        ptr += 3;
                        tptr += 3;
                    }
                    ptr += remain + 6;
                    tptr += remain + 6;
                }
            }

            bmpimg.UnlockBits(data);
            tempbmp.UnlockBits(data2);

            bmpimg = (Bitmap)tempbmp.Clone();
        }

        public void gray_Dilation(byte[,] sele)
        {
            //Black as background -> Dilation

            Bitmap tempbmp = (Bitmap)this.bmpimg.Clone();

            BitmapData data2 = tempbmp.LockBits(new Rectangle(0, 0, tempbmp.Width, tempbmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData data = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte[,] sElement = sele;

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                byte* tptr = (byte*)data2.Scan0;

                ptr += data.Stride + 3;
                tptr += data.Stride + 3;

                int remain = data.Stride - data.Width * 3;

                for (int i = 1; i < data.Height - 1; i++)
                {
                    for (int j = 1; j < data.Width - 1; j++)
                    {
                        byte* temp = ptr - data.Stride - 3;
                        byte min = 0;

                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                if (min < temp[data.Stride * k + l * 3])
                                {
                                    if (sElement[k, l] != 0)
                                        min = temp[data.Stride * k + l * 3];
                                }
                            }
                        }

                        tptr[0] = tptr[1] = tptr[2] = min;


                        ptr += 3;
                        tptr += 3;
                    }
                    ptr += remain + 6;
                    tptr += remain + 6;
                }
            }

            bmpimg.UnlockBits(data);
            tempbmp.UnlockBits(data2);

            bmpimg = (Bitmap)tempbmp.Clone();
        }

        public void threshx(int thresval)
        {
            BitmapData data = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int remain = data.Stride - data.Width * 3;

                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        if (((ptr[0] + ptr[1] + ptr[2]) / 3) > thresval) ptr[0] = ptr[1] = ptr[2] = 255;
                        else ptr[0] = ptr[1] = ptr[2] = 0;
                        ptr += 3;
                    }
                    ptr += remain;
                }
            }
            bmpimg.UnlockBits(data);
        }

        public void Konversi2GreyViaPointer()
        {
            BitmapData bmData = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    p[0] = (byte)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                    p[1] = p[0];
                    p[2] = p[0];
                    p += 3;
                }
            }
            bmpimg.UnlockBits(bmData);
        }
    }
}
