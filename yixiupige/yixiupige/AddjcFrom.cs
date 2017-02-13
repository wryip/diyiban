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
    public partial class AddjcFrom : Form
    {
        public AddjcFrom()
        {
            InitializeComponent();
        }
        public static string path1="";
        JCInfoBLL jcinfobll = new JCInfoBLL();
        fuwuBLL fuwubl = new fuwuBLL();
        List<string> list = new List<string>();
        private FilterInfoCollection videoDevices;
        jbcsBLL jbbll = new jbcsBLL();
        staffInfoBLL staffbll = new staffInfoBLL();
        private static AddjcFrom _danli = null;
        public static AddjcFrom CreateForm()
        {
            if (_danli == null)
            {
                _danli = new AddjcFrom();
            }
            return _danli;
        }
        private void AddjcFrom_Load(object sender, EventArgs e)
        {
            List<jbcs> listtype = jbbll.selectList(5);
            foreach (var iteam in listtype)
            {
                comboBox1.Items.Add(iteam.AllType);
            }
            listtype = jbbll.selectList(1);
            foreach (var iteam in listtype)
            {
                comboBox2.Items.Add(iteam.AllType);
            }
            listtype = jbbll.selectList(2);
            foreach (var iteam in listtype)
            {
                comboBox3.Items.Add(iteam.AllType);
            }
            listtype = staffbll.selectSH();
            foreach (var iteam in listtype)
            {
                comboBox4.Items.Add(iteam.AllType);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddjcFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            _danli = null;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
            string sb = "";
            string[] ss = DateTime.Now.ToString("yyyy MM dd HH:mm:ss").Split(new char[] { '/', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in ss)
            {
                sb += s;
            }
            Random rad = new Random();
            sb += rad.Next(1000, 9999);
            shInfoList model = new shInfoList();
            //model.jcName = textBox1.Text;
            //model.jcCardNumber = textBox3.Text;
            model.PinPai = comboBox2.Text;
            model.Color = comboBox3.Text;
            model.YMoney = Convert.ToInt32(textBox13.Text.Trim());
            model.Type = comboBox1.Text;
            model.FuWuName = textBox9.Text;
            model.Remark = textBox11.Text;
            model.CJQuestion = textBox10.Text;
            model.PaiNumber = textBox5.Text;
            model.YMPerson = comboBox4.Text;
            //model.d = DateTime.Now.ToString("yyyy MM dd");
            //model.jcEndDate = dateTimePicker1.Text.ToString();
            while (path1 == "")
            {
                Thread.Sleep(1000);
            }
            model.ImgUrl = path1;
            List<shInfoList> list = new List<shInfoList>();
            list.Add(model);
            bool result = jcinfobll.addJCList(list, textBox3.Text.Trim(), textBox1.Text.Trim(), dateTimePicker1.Text.ToString().Trim(), sb);
            if (result)
            {
                MessageBox.Show("添加成功！");
                this.Close();
            }
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
            string[] name = DateTime.Now.ToString("yyyy MM dd HH:mm:ss").Split(new char[] { '/', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name1 = "";
            foreach (var ite in name)
            {
                name1 += ite.ToString();
            }
            string path = dirpath + "\\" + name1 + ".bmp";
            if (newImage != null)
                newImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
            pictureBox1.ImageLocation = path;
            path1 = path;
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

        private void textBox9_Click(object sender, EventArgs e)
        {
            jbfuCheckBoxFrom shouhuojb = jbfuCheckBoxFrom.CreateForm(jbFuWuCount);
            shouhuojb.ShowDialog();
            shouhuojb.Focus();
        }
        //计算基本服务的价格，将名称与价格进行显示
        public void jbFuWuCount(string model)
        {
            textBox9.Text = model;
            int money = 0;
            string type = "无卡";
            List<fuwuModel> list = fuwubl.selectAllList();
            string[] name = model.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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
            textBox13.Text = money.ToString();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            cjQuestion cjquest = cjQuestion.CreateForm(cjquestion);
            cjquest.ShowDialog();
            cjquest.Focus();
        }
        public void cjquestion(string name)
        {
            textBox10.Text = name;
        }
    }
}
