using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge.Video.DirectShow;
using MODEL;
using BLL;
using System.Drawing.Printing;

namespace yixiupige
{
    public partial class lsdzjForm : Form
    {
        public lsdzjForm()
        {
            InitializeComponent();
        }
        public delegate void databind();
        public static databind bind;
        DPInfoBLL dpbll = new DPInfoBLL();
        private FilterInfoCollection videoDevices;
        private static lsdzjForm lsdzj;
        public static lsdzjForm Create(databind bind1)
        {
            bind = bind1;
            if (lsdzj==null)
            {
                lsdzj = new lsdzjForm();
            }
            return lsdzj;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //退出程序
        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //调入图片
        private void button1_Click(object sender, EventArgs e)
        {
            


        }
        //OpenFileDialog od = new OpenFileDialog();
        //    od.Title = "请选择文件";
        //    od.Multiselect = false;
        //    od.Filter = "图片文件|*.jpg";
        //    od.ShowDialog();
        //    string path = od.FileName;
        //    if (path == "")
        //    {
        //        return;
        //    }
        //    pictureBox1.ImageLocation = path;
        private void lsdzjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            lsdzj = null;
        }
        List<string> list = new List<string>();
        private void lsdzjForm_Load(object sender, EventArgs e)
        {
            string printername = "";
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
                CameraConn(0);
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }
            foreach (var iteam in list)
            {
                comboBox1.Items.Add(iteam);
            }
            comboBox1.SelectedIndex = 0;
            //设置不干胶打印机和小票打印机
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                printername = PrinterSettings.InstalledPrinters[i];
                comboBox2.Items.Add(printername);
                comboBox3.Items.Add(printername);
            }
        }
        private void CameraConn(int i)
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
            videoSource.DesiredFrameSize = new Size(320, 240);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            CameraConn(comboBox1.SelectedIndex);
        }

        private void bcbutton_Click(object sender, EventArgs e)
        {
            DianPu model = new DianPu();
            model.DPName = dpmcBox.Text.Trim();
            model.DPPerson = lxrBox.Text.Trim();
            model.DPTel = lxdhBox.Text.Trim();
            model.DPAddress = dpdztBox.Text.Trim();
            model.DPRemark = bzxxBox.Text.Trim();
            model.DPContent = textBox1.Text.Trim();
            model.DPPicture = comboBox1.Text.Trim();
            model.DPNo = textBox2.Text.Trim();
            model.DPDay = DateTime.Now.Day.ToString();
            model.BGJPrint = comboBox2.Text;
            model.MemberPrint = comboBox3.Text;
            model.DPNumber = "1";
            if (model.DPName == "" || model.DPPerson == "" || model.DPTel == "" || model.DPAddress == "" || model.DPRemark == "" || model.DPPicture == "")
            {
                MessageBox.Show("请将信息填写完整！");
                return;
            }
            bool result = dpbll.AddModel(model);
            if (result)
            {
                MessageBox.Show("添加成功！");
                bind();
                this.Close();
                return;
            }
            MessageBox.Show("添加失败！");
        }
    }
}
