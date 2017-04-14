using AForge.Video.DirectShow;
using BLL;
using Commond;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yixiupige
{
    public partial class DPUpdateFrom : Form
    {
        public DPUpdateFrom()
        {
            InitializeComponent();
        }
        public static DianPu model1;
        public delegate void databind();
        public static databind bind;
        DPInfoBLL dpbll = new DPInfoBLL();
        private FilterInfoCollection videoDevices;
        private static DPUpdateFrom lsdzj;
        public static DPUpdateFrom Create(databind bind1, DianPu model)
        {
            model1 = model;
            bind = bind1;
            if (lsdzj == null)
            {
                lsdzj = new DPUpdateFrom();
            }
            return lsdzj;
        }
        List<string> list=new List<string>();
        private void DPUpdateFrom_Load(object sender, EventArgs e)
        {
            string printername = "";
            dpmcBox.ReadOnly = true;
            dpmcBox.Text = model1.DPName;
            lxrBox.Text = model1.DPPerson;
            lxdhBox.Text = model1.DPTel;
            dpdztBox.Text = model1.DPAddress;
            bzxxBox.Text = model1.DPRemark;
            textBox2.Text = model1.DPNo;
            textBox1.Text = model1.DPContent;
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
                CameraConn(-1);
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }           
            foreach (var iteam in list)
            {
                comboBox1.Items.Add(iteam);
            }
            comboBox1.Text = model1.DPPicture;
            //设置不干胶打印机和小票打印机
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                printername = PrinterSettings.InstalledPrinters[i];
                comboBox2.Items.Add(printername);
                comboBox3.Items.Add(printername);
            }
            comboBox2.Text = FilterClass.BGJPrinter;
            comboBox3.Text = FilterClass.MemberXF;
        }
        private void CameraConn(int i)
        {
            VideoCaptureDevice videoSource;
            if (i < 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            }
            else
            {
               videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
            }
            videoSource.DesiredFrameSize = new Size(320, 240);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }
        private void DPUpdateFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            lsdzj = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bcbutton_Click(object sender, EventArgs e)
        {
            DianPu model = new DianPu();
            model.DPName = dpmcBox.Text.Trim();
            model.DPPerson = lxrBox.Text.Trim();
            model.DPTel = lxdhBox.Text.Trim();
            model.DPNo = textBox2.Text.Trim();
            model.DPAddress = dpdztBox.Text.Trim();
            model.DPRemark = bzxxBox.Text.Trim();
            model.DPContent = textBox1.Text.Trim();
            model.DPPicture = comboBox1.Text.Trim();
            model.BGJPrint = comboBox2.Text;
            model.MemberPrint = comboBox3.Text;
            if (model.DPName == "" || model.DPPerson == "" || model.DPTel == "" || model.DPAddress == "" || model.DPRemark == "" || model.DPPicture == "")
            {
                MessageBox.Show("请将信息填写完整！");
                return;
            }
            bool result = dpbll.UpdateModel(model);
            if (result)
            {
                MessageBox.Show("修改成功！");
                bind();
                this.Close();
                return;
            }
            MessageBox.Show("修改失败！");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            CameraConn(comboBox1.SelectedIndex);
        }
    }
}
