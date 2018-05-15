using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using System.Web;
using System.Net;

namespace ForgeUlti
{
    public partial class Form1 : Form
    {
        FilterInfoCollection webCams;
        VideoCaptureDevice kamera;
        Bitmap frame, frame2;
        MJPEGStream stream,streamVideo;
        VideoFileSource baca;
        public Form1()
        {
            InitializeComponent();
        }
        void kamera_ProsesFrame(object sender, NewFrameEventArgs eventArgs)
        {
            frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame;
        }
        void kamera_ProsesFrame3(object sender, NewFrameEventArgs eventArgs)
        {
            frame = (Bitmap)eventArgs.Frame.Clone();
            frame2 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame;
            // create filter
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(frame2);
            Threshold filter2 = new Threshold(100);
            // apply the filter

            pictureBox2.Image = filter2.Apply(grayImage);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            webCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            kamera = new VideoCaptureDevice(webCams[0].MonikerString);
            kamera.NewFrame += new NewFrameEventHandler(kamera_ProsesFrame3);
            kamera.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kamera.Stop();
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            Bitmap bmpPrc = (Bitmap)eventArgs.Frame.Clone();
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(bmpPrc);
            Threshold filter2 = new Threshold(100);
            pictureBox1.Image = bmp;
            pictureBox2.Image = filter2.Apply(grayImage);
            /*
             * Cara Menggunakan versi Apps IP Webcam
             * Jalankan IP Webcam di Perangkat Android
             * Buka IP di browser Komputer
             * Pilih ke Mode Browser untuk output video
             * Klik kanan pada video copy link (alamat)
             * Copy kan di stream = new MJPEGStream("http://192.168.43.1:8080/video");
             * 
             * Regard:
             * Sufyan97
             */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baca.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "null")
            {
                stream = new MJPEGStream(textBox1.Text);
                stream.NewFrame += stream_NewFrame;
                stream.Start();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            if (of.ShowDialog() == DialogResult.OK)
            {
                baca = new VideoFileSource(of.FileName);
                baca.NewFrame += stream_NewFrame;
                baca.Start();

            }
            
        }
    }
}
