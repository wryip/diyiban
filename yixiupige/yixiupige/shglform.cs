//using AForge.Video;
//using AForge.Controls;
//using AForge.Video.DirectShow;
//using AForge.Video.FFMPEG;
//using Size = System.Drawing.Size;
//using System.Runtime.InteropServices;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
namespace yixiupige
{
    public partial class shglform : Form
    {
        #region//定义变量
        private FilterInfoCollection videoDevices;
        //private bool stopREC = true;
        //private bool createNewFile = true;

        //private string videoFileFullPath = string.Empty; //视频文件全路径
        //private string imageFileFullPath = string.Empty; //图像文件全路径
        //private string videoPath = @"E:\video\"; //视频文件路径
        //private string imagePath = @"E:\video\images\"; //图像文件路径
        //private string videoFileName = string.Empty; //视频文件名
        //private string imageFileName = string.Empty; //图像文件名
        //private string drawDate = string.Empty;
        //private VideoFileWriter videoWriter = null;

        //public delegate void MyInvoke(); //定义一个委托方法

        //string g_s_AutoSavePath = AppDomain.CurrentDomain.BaseDirectory + "Capture\\";
        //object objLock = new object(); //定义一个对象的锁
        //int frameRate = 20; //默认帧率
        //private Stopwatch stopWatch = null;
        //IVideoSource iVideoSource = null;

        #endregion
        public shglform()
        {
            InitializeComponent();
        }
        private static shglform _danli = null;
        public static shglform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new shglform();
            }
            return _danli;
        }
        List<string> list = new List<string>();
        private void shglform_Load(object sender, EventArgs e)
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
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.DesiredFrameSize = new Size(320, 240);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        private void shglform_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            //Application.Exit();
            _danli = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DirectoryInfo di = new DirectoryInfo("c:\\AMCap");
            //if (!di.Exists)
            //{
            //    Directory.CreateDirectory("c:\\AMCap");
            //}
            //string path = "C:\\AMCap\\" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".jpeg";
            //if (pictureBox2.Image != null)
            //{
            //    Bitmap bt = new Bitmap(pictureBox2.Image);
            //    bt.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    bt.Dispose();
            //}
            //else
            //{
            //    video.GrabImage(pictureBox1.Handle, path);
            //}
            //tsslPath.Text = "已经保存至：" + path;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
