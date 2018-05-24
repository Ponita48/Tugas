using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasSebelumUAS
{
    public partial class Form1 : Form
    {
        Bitmap gbr;
        int pointNum;
        Bitmap drawArea;

        public Form1()
        {
            InitializeComponent();
            drawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pointNum = Convert.ToInt16(textBox1.Text);
            Graphics graph = Graphics.FromImage(drawArea);
            graph.Clear(Color.White);
            List<IntPoint> list = new List<IntPoint>();
            Random rand = new Random();
            for (int i = 0; i < pointNum; i++)
            {
                list.Add(new IntPoint(
                        rand.Next(200),
                        rand.Next(200)
                    ));
            }

            foreach (var point in list)
            {
                graph.FillEllipse(Brushes.Black, point.X, point.Y, 10, 10);
            }
            pictureBox1.Image = drawArea;
            graph.Dispose();

            IConvexHullAlgorithm hullFinder = new GrahamConvexHull();
            List<IntPoint> hulls = hullFinder.FindHull(list);
            Bitmap bmp = new Bitmap(drawArea);
            Graphics graph2 = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Lime, 5);
            for (int i = 0; i < hulls.Count-1; i++)
            {
                graph2.DrawLine(pen, hulls.ElementAt(i).X, hulls.ElementAt(i).Y,
                    hulls.ElementAt(i+1).X, hulls.ElementAt(i+1).Y);
            }
            graph2.DrawLine(pen, hulls.ElementAt(0).X, hulls.ElementAt(0).Y,
                hulls.ElementAt(hulls.Count - 1).X, hulls.ElementAt(hulls.Count - 1).Y);
            pictureBox2.Image = bmp;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gbr = (Bitmap)pictureBox1.Image;
            ConnectedComponentsLabeling filter = new ConnectedComponentsLabeling();
            Bitmap final = filter.Apply(gbr);
            pictureBox2.Image = final;
            MessageBox.Show(filter.ObjectCount.ToString() + " Buah Objek", 
                "Connected Component Labeling");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void changePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp *.jpg)|*.bmp; *.jpg";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(of.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gbr = (Bitmap)pictureBox1.Image;
            Rectangle rect = new Rectangle(0, 0, gbr.Width, gbr.Height);
            HoughLineTransformation hough = new HoughLineTransformation();
            hough.ProcessImage(ConvertToFormat(gbr, PixelFormat.Format8bppIndexed));
            Bitmap res = hough.ToBitmap();
            HoughLine[] lines = hough.GetLinesByRelativeIntensity(0.5);
            MessageBox.Show("Jumlah Garis: " + lines.Length);
            foreach (var line in lines)
            {
                // get line's radius and theta values
                int r = line.Radius;
                double t = line.Theta;

                // check if line is in lower part of the image
                if (r < 0)
                {
                    t += 180;
                    r = -r;
                }

                // convert degrees to radians
                t = (t / 180) * Math.PI;

                // get image centers (all coordinate are measured relative
                // to center)
                int w2 = gbr.Width / 2;
                int h2 = gbr.Height / 2;

                double x0 = 0, x1 = 0, y0 = 0, y1 = 0;

                if (line.Theta != 0)
                {
                    // none-vertical line
                    x0 = -w2; // most left point
                    x1 = w2;  // most right point

                    // calculate corresponding y values
                    y0 = (-Math.Cos(t) * x0 + r) / Math.Sin(t);
                    y1 = (-Math.Cos(t) * x1 + r) / Math.Sin(t);
                }
                else
                {
                    // vertical line
                    x0 = line.Radius;
                    x1 = line.Radius;

                    y0 = h2;
                    y1 = -h2;
                }

                Pen pen = new Pen(Brushes.Red, 3);
                Graphics g = Graphics.FromImage(res);
                g.DrawLine(pen, (int)x0 + w2, h2 - (int)y0, (int)x1 + w2, h2 - (int)y1);
                // draw line on the image
                //Drawing.Line(data,
                //    new IntPoint((int)x0 + w2, h2 - (int)y0),
                //    new IntPoint((int)x1 + w2, h2 - (int)y1),
                //    Color.Red);
                g.Dispose();
            }
            pictureBox2.Image = res;

        }

        public static Bitmap ConvertToFormat(Bitmap image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            Bitmap dis = new Bitmap(copy.Width, copy.Height);
            using (Graphics gr = Graphics.FromImage(dis))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap sourceImage = (Bitmap)pictureBox1.Image;
            HoughCircleTransformation circleTransform = new HoughCircleTransformation(35);
            // apply Hough circle transform
            circleTransform.ProcessImage(ConvertToFormat(sourceImage, PixelFormat.Format8bppIndexed));
            Bitmap houghCirlceImage = circleTransform.ToBitmap();
            // get circles using relative intensity
            HoughCircle[] circles = circleTransform.GetCirclesByRelativeIntensity(0.5);
            Graphics g;
            MessageBox.Show("Jumlah Lingkaran: " + circles.Length.ToString());

            foreach (HoughCircle circle in circles)
            {
                Pen pen = new Pen(Brushes.Black, 5);
                g = Graphics.FromImage(houghCirlceImage);
                g.DrawEllipse(pen, circle.X, circle.Y, 5, 5);
                g.Dispose();
            }
            pictureBox2.Image = sourceImage;
        }
    }
}
