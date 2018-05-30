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
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Newtonsoft.Json;

namespace PCD13ImageAnalysisFramework
{
    public partial class Form1 : Form
    {
        Bitmap imageCCL = new Bitmap(PCD13ImageAnalysisFramework.Properties.Resources.ConnectedLabel);
        Bitmap imageHough = new Bitmap(PCD13ImageAnalysisFramework.Properties.Resources.houghImageSample);
        public Form1()
        {
            
            InitializeComponent();
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button1.Enabled = true;
                pictureBox1.Image = imageCCL;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                button1.Enabled = true;
                pictureBox1.Image = imageCCL;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                button1.Enabled = true;
                pictureBox1.Image = imageHough;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                button1.Enabled = true;
                pictureBox1.Image = imageHough;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                textBox1.Text = "";
                ConnectedComponentsLabeling filterCCL = new ConnectedComponentsLabeling();
                Bitmap resultCCL = filterCCL.Apply(imageCCL);
                pictureBox2.Image = resultCCL;
                int count = filterCCL.ObjectCount;
                String info = "Mode \t\t : CCL \r\n Jumlah Object \t : " + count;
                textBox1.Text = info;
            }
            if (comboBox1.SelectedIndex == 1 )
            {
                textBox1.Text = "";
                convexHullBlov(imageCCL);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = "";
                houghTranformLine666(imageHough);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Text = "";
                houghCircle(imageHough);
            }
        }

        private void convexHullBlov(Bitmap saus)
        {
            // http://www.aforgenet.com/framework/features/blobs_processing.html
            Bitmap olahData = (Bitmap)saus.Clone();
            BlobCounter blCount = new BlobCounter();
            blCount.ProcessImage(saus);
            Blob[] blobs = blCount.GetObjectsInformation();
            GrahamConvexHull hullFinder = new GrahamConvexHull();
            BitmapData data = olahData.LockBits(new Rectangle(0, 0, olahData.Width, olahData.Height),ImageLockMode.ReadWrite, olahData.PixelFormat);
            foreach (Blob blob in blobs)
            {
                List<IntPoint> leftPoints, rightPoints;
                List<IntPoint> edgePoints = new List<IntPoint>();

                // get blob's edge points
                blCount.GetBlobsLeftAndRightEdges(blob,out leftPoints, out rightPoints);

                edgePoints.AddRange(leftPoints);
                edgePoints.AddRange(rightPoints);

                // blob's convex hull
                List<IntPoint> hull = hullFinder.FindHull(edgePoints);

                Drawing.Polygon(data, hull, Color.Red);
            }
            olahData.UnlockBits(data);
            pictureBox2.Image = olahData;
        }

        public static Bitmap ConvertToFormat(Bitmap image)
        {
            GrayscaleBT709 gg = new GrayscaleBT709();
            Bitmap akhir = gg.Apply(image);
            return akhir;
        }

       
       
        private void houghTranformLine666(Bitmap sausBasic)
        {
            Bitmap saus = ConvertToFormat(sausBasic);
            HoughLineTransformation lineTransform = new HoughLineTransformation();
            // apply Hough line transofrm
            lineTransform.ProcessImage(saus);
            Bitmap houghLineImage = lineTransform.ToBitmap();
            // get lines using relative intensity
            HoughLine[] lines = lineTransform.GetLinesByRelativeIntensity(0.5);

            foreach (HoughLine line in lines)
            {
                Console.WriteLine(JsonConvert.SerializeObject(line, Formatting.Indented));
            }
            pictureBox2.Image = houghLineImage;
        }

        private void houghCircle(Bitmap basicSaus)
        {
            Bitmap saus = ConvertToFormat(basicSaus);
            HoughCircleTransformation circleTransform = new HoughCircleTransformation(35);
            // apply Hough circle transform
            circleTransform.ProcessImage(saus);
            Bitmap houghCirlceImage = circleTransform.ToBitmap();
            // get circles using relative intensity
            HoughCircle[] circles = circleTransform.GetCirclesByRelativeIntensity(0.1);

            foreach (HoughCircle circle in circles)
            {
                Console.WriteLine(JsonConvert.SerializeObject(circle, Formatting.Indented));
            }
            pictureBox2.Image = houghCirlceImage;
        }
    }
}
