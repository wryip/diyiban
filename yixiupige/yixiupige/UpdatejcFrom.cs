using AForge.Video.DirectShow;
using BLL;
using Commond;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yixiupige
{
    public partial class UpdatejcFrom : Form
    {
        public UpdatejcFrom()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }
        memberInfoBLL memberinfo = new memberInfoBLL();
        fuwuBLL fuwubl = new fuwuBLL();
        bool resultupdate = false;
        private FilterInfoCollection videoDevices;
        public static string Path = "";
        JCInfoBLL bll = new JCInfoBLL();
        public delegate void databind();
        public static databind databind1;
        public static int id;
        private static UpdatejcFrom _danli = null;
        public static JCInfoModel model;
        public static UpdatejcFrom CreateForm(int ID, databind bind)
        {
            id = ID;
            databind1 = bind;
            if (_danli == null)
            {
                _danli = new UpdatejcFrom();
            }
            return _danli;
        }
        private void UpdatejcFrom_Load(object sender, EventArgs e)
        {
            model = bll.SelectID(id);
            textBox1.Text = model.jcName;
            textBox2.Text = "未上架";
            textBox3.Text = model.jcCardNumber;
            textBox4.Text = model.jcPinPai;
            textBox5.Text = model.jcPaiNumber;
            textBox6.Text = model.jcColor;
            textBox7.Text = model.jcBeginDate;
            textBox8.Text = model.jcQMoney.Trim();
            textBox9.Text = model.jcType;
            textBox10.Text = model.jcStaff;
            textBox11.Text = model.jcRemark;
            pictureBox1.ImageLocation = model.jcImgUrl;
        }

        private void UpdatejcFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            Bitmap bitmap = (Bitmap)image.Clone();
            #region//图片保存
            Bitmap newImage = new Bitmap(320, 240);
            Graphics draw = Graphics.FromImage(newImage);
            draw.DrawImage(bitmap, 0, 0);
            draw.Dispose();
            string dirpath = "E:\\mymemberimg";
            if (!Directory.Exists(dirpath))
                Directory.CreateDirectory(dirpath);
            string[] name = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Split(new char[] { '/', ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string name1 = "";
            foreach (var ite in name)
            {
                name1 += ite.ToString();
            }
            string path = dirpath + "\\" + name1 + ".bmp";
            if (newImage != null)
                newImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
            Path = path;
            //bool result = modelbll.AddMemberInfo(model);
            //if (result)
            //{
            //    MessageBox.Show("添加成功！");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("添加失败，请稍后再试！");
            //}
            #endregion
            videoSourcePlayer1.NewFrame -= new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
            model.jcName = textBox1.Text;
            model.jcCardNumber = textBox3.Text;
            model.jcPinPai = textBox4.Text;
            model.jcColor = textBox6.Text;
            model.jcQMoney = textBox8.Text;
            model.jcType = textBox9.Text;
            model.jcStaff = textBox10.Text;
            model.jcRemark = textBox11.Text;
            while (Path == "")
            {
                Thread.Sleep(1000);
            }
            model.jcImgUrl = Path;
            resultupdate = bll.UpdateInfoModel(model);
            if (resultupdate)
            {
                MessageBox.Show("修改成功！");
                this.Close();
            }
        }
        List<string> list = new List<string>();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
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
            else
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }
        }
        private void CameraConn()
        {
            FilterInfo state = new FilterInfo(videoDevices[0].MonikerString);
            foreach (FilterInfo device in videoDevices)
            {
                if (device.Name.Trim() == FilterClass.PicImg.Trim())
                {
                    state = device;
                }
            }
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.DesiredFrameSize = new Size(320, 240);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            jbfuCheckBoxFrom shouhuojb = jbfuCheckBoxFrom.CreateForm(jbFuWuCount);
            shouhuojb.ShowDialog();
            shouhuojb.Focus();
        }
        public void jbFuWuCount(string model1)
        {
            textBox10.Text = model1;
            int money = 0;
            string type = memberinfo.selectType(model.jcCardNumber.Trim()).Trim();
            List<fuwuModel> list = fuwubl.selectAllList();
            string[] name = model1.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var iteam in list)
            {
                foreach (var itname in name)
                {
                    if (itname.Trim() == iteam.Name.Trim())
                    {
                        string neirong = iteam.neirong.Trim();
                        //不同卡对应的钱
                        string[] str = neirong.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var iteamdan in str)
                        {
                            if (iteamdan.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim() == type)
                            {
                                money += Convert.ToInt32(iteamdan.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            textBox8.Text = money.ToString();
        }
    }
}
