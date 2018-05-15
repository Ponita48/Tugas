using System;
using System.Drawing;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using AForge.Imaging.Filters;

namespace AForgeWebcam
{
    public partial class Form1 : Form
    {
        FilterInfoCollection webCams;
        VideoCaptureDevice kamera;
        Bitmap frame;
        MJPEGStream stream, streamVideo;
        VideoFileSource baca;

        bool proses = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            if (kamera != null && kamera.IsRunning)
            {
                kamera.Stop();
            }
            if (of.ShowDialog() == DialogResult.OK)
            {
                baca = new VideoFileSource(of.FileName);
                baca.NewFrame += new NewFrameEventHandler(kamera_ProsesFrame);
                baca.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baca != null && baca.IsRunning)
            {
                baca.Stop();
            }
            webCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            kamera = new VideoCaptureDevice(webCams[0].MonikerString);
            kamera.NewFrame += new NewFrameEventHandler(kamera_ProsesFrame);
            kamera.Start();
        }

        void kamera_ProsesFrame(object sender, NewFrameEventArgs eventArgs)
        {
            frame = (Bitmap)eventArgs.Frame.Clone();
            Grayscale gs = new Grayscale(0.2125, 0.7154, 0.0721);
            Threshold th = new Threshold(100);
            Bitmap img = gs.Apply(frame);
            th.ApplyInPlace(img);
            pictureBox1.Image = frame;
            pictureBox2.Image = img;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (kamera != null && kamera.IsRunning)
                {
                    kamera.Stop();
                }
                Environment.Exit(0);
            }
        }
    }
}
