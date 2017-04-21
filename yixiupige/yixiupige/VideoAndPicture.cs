using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using Commond;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yixiupige
{
    public partial class VideoAndPicture : Form
    {
        public VideoAndPicture()
        {
            InitializeComponent();
        }
        public delegate void dAdd(string path);
        public dAdd myAdd; 
        private FilterInfoCollection videoDevices;
        List<string> list = new List<string>();
        PictureBox picbox;
        RowStyle rowsty;
        bool StopREC = true;
        VideoFileWriter writer;
        private static VideoAndPicture _danli = null;
        public static string Path;
        public delegate void  videoaction();
        public static videoaction action1;
        public static VideoAndPicture CreateForm(string path,videoaction action2)
        {
            action1 = action2;
            Path = path;
            if (_danli == null)
            {
                _danli = new VideoAndPicture();
            }
            return _danli;
        }
        private void VideoAndPicture_Load(object sender, EventArgs e)
        {
            try
            {
                //连接//开启摄像头
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                foreach (FilterInfo device in videoDevices)
                {
                    list.Add(device.Name);
                }
                CameraConn();
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }
        }
        private void CameraConn()
        {
            string carmar = FilterClass.PicImg;
            //new FilterInfo(videoDevices[0].MonikerString);
            FilterInfo state = new FilterInfo(videoDevices[0].MonikerString);
            foreach (FilterInfo device in videoDevices)
            {
                if (device.Name.Trim() == (carmar == null ? videoDevices[0].Name.Trim() : carmar.Trim()))
                {
                    state = device;
                }
            }
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //videoSource.VideoCapabilities.SetValue(new Size(320, 240), 0);
            videoSource.VideoResolution = videoSource.VideoCapabilities[2];

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }
        private void VideoAndPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            action1();
            //writer.Dispose();
            _danli = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bool isjx;
            if (radioButton1.Checked)
            {
                MessageBox.Show("请正确选择！");
                return;
            }            
            if (button1.Text == "开始录制")
            {
                //isjx = true;
                button1.Text = "结束录制";
                if (writer == null)
                {
                    writer = new VideoFileWriter();
                }
                //以下是视频录制
                videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame1);
            }
            else 
            {
                //isjx = false;
                button1.Text = "开始录制";
                videoSourcePlayer1.NewFrame -= new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame1);
                writer.Close();
                button1.Enabled = false;
                //writer.Dispose();
            }          
        }

        void videoSourcePlayer1_NewFrame1(object sender, ref Bitmap image)
        {
            // create instance of video writer
            
            //int width = 320;
            //int height = 240;
            if (StopREC)
            {
                StopREC = false;
                string pat = "";
                foreach (string s in DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Split(new char[] { '-', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    pat += s;
                }
                pat = Path + "\\" + pat + ".avi";
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);
                // create new video file
                writer.Open(pat, image.Width, image.Height, 25, VideoCodec.MPEG4);
                // create a bitmap to save into the video file
                //Bitmap image = (Bitmap)videoSourcePlayer1.BackgroundImage;
                //Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                // write 1000 video frames
                //for (int i = 0; i < 1000; i++)
                //{
                //image.SetPixel(i % width, i % height, Color.Red);
                writer.WriteVideoFrame(image);
                //}
            }
            else
            {
                writer.WriteVideoFrame(image);
            }
        }
        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            Bitmap bitmap = (Bitmap)image.Clone();
            //pictureBox1.Image = bitmap;
            //image.Dispose();
            #region//图片保存
            Bitmap newImage = new Bitmap(320, 240);
            Graphics draw = Graphics.FromImage(newImage);
            draw.DrawImage(bitmap, 0, 0);
            draw.Dispose();
            string dirpath = Path;
            if (!Directory.Exists(dirpath))
                Directory.CreateDirectory(dirpath);
            string[] name = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Split(new char[] { '/', ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string name1 = "";
            foreach (var ite in name)
            {
                name1 += ite.ToString();
            }
            Random r= new Random();
            name1 += r.Next(0,999);
            string path = dirpath + "\\" + name1 + ".bmp";
            if (newImage != null)
            {
                //Thread.Sleep(500);
                newImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            //pinea2AddPic(path);'
          
            #endregion
            videoSourcePlayer1.NewFrame -= new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
            Thread th = new Thread(pinea2AddPic);
            //th.IsBackground = true;
            th.Start(path);
        }
        private void pinea2AddPic(object path)
        {
            myAdd = new dAdd(add);
            panel2.Invoke(myAdd,path.ToString());
            //PictureBox picbox = new PictureBox();
            //picbox.ImageLocation = path.ToString(); ;
            //panel2.Controls.Add(picbox);
        }
        public void add(string path)
        {
            tableLayoutPanel1.Height = (tableLayoutPanel1.RowStyles.Count-1) * 173;
            Image imag = Image.FromFile(path);
            picbox = new PictureBox();
            picbox.Width = 200;
            picbox.Height = 173;
            picbox.BackgroundImage = imag;
            pictureBox1.BackgroundImage = imag;
            picbox.BackgroundImageLayout = ImageLayout.Zoom;
            rowsty = new RowStyle(SizeType.Absolute, 173);
            tableLayoutPanel1.Controls.Add(picbox, 0,tableLayoutPanel1.RowStyles.Count-2);
            tableLayoutPanel1.RowStyles.Add(rowsty);
            //panel2.Controls.Add(picbox);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                MessageBox.Show("请正确选择！");
                return;
            }
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
        }
    }
}
