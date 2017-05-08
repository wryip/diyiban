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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yixiupige
{
    public partial class xiugaimember : Form
    {
        public xiugaimember()
        {
            InitializeComponent();
        }
        staffInfoBLL staff = new staffInfoBLL();
        DPInfoBLL dpbll = new DPInfoBLL();
        public delegate void binddata();
        public static binddata bdata;
        private static xiugaimember hyzj;
        public static xiugaimember Create(memberInfoModel model,binddata bindd)
        {
            bdata = bindd;
            modelmember = model;
            if (hyzj == null)
            {
                hyzj = new xiugaimember();
            }
            return hyzj;
        }
        public static memberInfoModel modelmember;
        public string password="0";
        public Bitmap bitmap { get; set; }
        private FilterInfoCollection videoDevices;
        List<string> list = new List<string>();
        public memberInfoBLL modelbll = new memberInfoBLL();
        public void fuzhipwd(string str)
        {
            password = str;
        }
        private void xiugaimember_Load(object sender, EventArgs e)
        {
            #region//打开摄像头
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
            #endregion
            #region//窗口打开的时候初始化的内容
            //初始化会员分类
            if (FilterClass.isadmin())
            {
                List<string> strdp = dpbll.selectDPName();
                foreach (var iteam in strdp)
                {
                    lsdcomboBox.Items.Add(iteam);
                }
            }
            else
            {
                lsdcomboBox.Text = modelmember.dianName;
                lsdcomboBox.Enabled = false;
            }
            List<jbcs> listname = staff.selectSH();
            foreach (var iteam in listname)
            {
                ywycomboBox.Items.Add(iteam.AllType);
            }
            hykhtextBox.Text = modelmember.memberCardNo;
            //hykhtextBox.ReadOnly = true;
            hyxmtextBox.Text = modelmember.memberName;
            hydhtextBox.Text = modelmember.memberTel;
            sfzhtextBox.Text = modelmember.memberDocument;
            hyflcomboBox.Text = modelmember.memberType;
            hyflcomboBox.Enabled = false;
            spzktextBox.Text = modelmember.rebate;
            spzktextBox.ReadOnly = true;
            fwzktextBox.Text = "0";
            fwzktextBox.ReadOnly = true;
            czjetextBox.Text = modelmember.toUpMoney;
            czjetextBox.ReadOnly = false;
            bkjetextBox.Text = modelmember.cardMoney;
            bkjetextBox.ReadOnly = true;
            textBox1.Text = modelmember.cardType;
            textBox1.ReadOnly = true;
            hyxbcomboBox.Text = modelmember.memberSex;
            ztcomboBox.Text = modelmember.zhuangtai;
            bzxxtextBox.Text = modelmember.remark;
            dwtextBox.Text = modelmember.address;
            ywycomboBox.Text = modelmember.saleMan;
            
            csrqdateTimePicker.Text = modelmember.birDate.Trim();
            bkrqdateTimePicker.Text = modelmember.cardDate.Trim();
            if (modelmember.password.Trim() != "")
            {
                szmmbutton.Enabled = true;
                qyhymmcheckBox.Checked = true;
                szmmbutton.Text = "修改密码";                
            }
            else
            {
                szmmbutton.Enabled = false;
                qyhymmcheckBox.Checked = false;
                szmmbutton.Text = "设置密码";
            }
            if (modelmember.endDate.Trim() != "无")
            {
                dateTimePicker1.Enabled = true;
                qydqxzcheckBox.Checked = true;
                dateTimePicker1.Text = modelmember.endDate;
            }
            else
            {
                qydqxzcheckBox.Checked = false;
                dateTimePicker1.Enabled = false;
            } 
            pictureBox1.ImageLocation = modelmember.imageUrl;
            #endregion
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xiugaimember_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            bdata();
            hyzj = null;
        }

        private void qdbutton_Click(object sender, EventArgs e)
        {
            if (hydhtextBox.Text == "" || hykhtextBox.Text == "" || hyxmtextBox.Text == ""  || hyxbcomboBox.Text == "" || lsdcomboBox.Text == "")
            {
                MessageBox.Show("请将信息填写完整！");
                return;
            }
            else
            {
                #region//封装用户填写进去的内容，进行添加
                memberInfoModel model = new memberInfoModel();
                model.ID = modelmember.ID;
                model.memberCardNo = hykhtextBox.Text;
                model.memberName = hyxmtextBox.Text;
                model.memberTel = hydhtextBox.Text;
                model.memberDocument = sfzhtextBox.Text;
                model.birDate = TimeGuiGe.TimePicterBegin(csrqdateTimePicker.Text);
                model.cardDate = TimeGuiGe.TimePicterEng(bkrqdateTimePicker.Text);
                model.memberSex = hyxbcomboBox.Text;
                model.rebate = spzktextBox.Text;
                if (qydqxzcheckBox.Checked)
                {
                    model.endDate = TimeGuiGe.TimePicterBegin(dateTimePicker1.Text);
                }
                else
                {
                    model.endDate = TimeGuiGe.TimePicterBegin(dateTimePicker1.Text);
                }
                model.fuwuBate = fwzktextBox.Text;
                model.toUpMoney = czjetextBox.Text;
                model.cardMoney = bkjetextBox.Text;
                model.dianName = lsdcomboBox.Text;
                model.cardType = textBox1.Text;
                model.saleMan = ywycomboBox.Text;
                model.memberType = hyflcomboBox.Text;
                model.address = dwtextBox.Text;
                model.remark = bzxxtextBox.Text;
                model.zhuangtai = ztcomboBox.Text;
                if (qyhymmcheckBox.Checked && password!="0")
                {
                    model.password = password;
                }                
                Bitmap newImage = new Bitmap(160, 120);
                Graphics draw = Graphics.FromImage(newImage);
                if (bitmap != null)
                {
                    draw.DrawImage(bitmap, 0, 0);
                    draw.Dispose();
                    string dirpath = "..\\..\\memberInfo";
                    if (!Directory.Exists(dirpath))
                        Directory.CreateDirectory(dirpath);
                    string path = dirpath + "\\" + hykhtextBox.Text.Trim() + ".bmp";
                    if (newImage != null)
                        newImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                    model.imageUrl = path;
                }
                else
                {
                    model.imageUrl = pictureBox1.ImageLocation;
                }
                bool result = modelbll.EditMemberInfo(model);
                if (result)
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后再试！");
                }
                #endregion
            }
        }

        private void cjzpbutton_Click(object sender, EventArgs e)
        {
            //点击之后进行照片截图
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
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
            videoSource.VideoResolution = videoSource.VideoCapabilities[1];

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            bitmap = (Bitmap)image.Clone();
            //image.Dispose();
            try
            {
                pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存图像失败!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            videoSourcePlayer1.NewFrame -= new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
        }

        private void qkzpbutton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void qydqxzcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (qydqxzcheckBox.Checked)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        private void qyhymmcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (qyhymmcheckBox.Checked)
            {
                szmmbutton.Enabled = true;
            }
            else
            {
                szmmbutton.Enabled = false;
            }      
        }

        private void szmmbutton_Click(object sender, EventArgs e)
        {
            if (szmmbutton.Text == "修改密码")
            {
                //那就将密码传入进去
            }
            else
            {
                szpassword pwd = szpassword.Create(fuzhipwd);
                pwd.Show();
                pwd.Focus();
            }
        }
    }
}
