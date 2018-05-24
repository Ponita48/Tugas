using AForge;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
