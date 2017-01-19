using AForge.Video.DirectShow;
using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace yixiupige
{

    public partial class hyzjForm : Form
    {
        public hyzjForm()
        {
            InitializeComponent();
        }
        private static hyzjForm hyzj;
        public static hyzjForm Create()
        {
            if (hyzj==null)
            {
                hyzj = new hyzjForm();
            }
            return hyzj;
        }

        public memberInfoBLL modelbll = new memberInfoBLL();
        public memberTypeCURD bll = new memberTypeCURD();
        public string password;
        public Bitmap bitmap { get; set; }
        private FilterInfoCollection videoDevices;
        //public int flag = 0;
        //EncodingOptions options = null;
        //BarcodeWriter writer = null;
        List<string> list = new List<string>();
        public void fuzhipwd(string str)
        {
            password = str;
        }
        private void hyzjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            hyzj = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qdbutton_Click(object sender, EventArgs e)
        {
            if (hydhtextBox.Text == "" || hykhtextBox.Text == "" || hyxmtextBox.Text == "" || sfzhtextBox.Text == "" || hyxbcomboBox.Text == "" || lsdcomboBox.Text == "")
            {
                MessageBox.Show("请将信息填写完整！");
                return;
            }
            else
            {
                #region//封装用户填写进去的内容，进行添加
                memberInfoModel model = new memberInfoModel();
                model.memberCardNo = hykhtextBox.Text;
                model.memberName = hyxmtextBox.Text;
                model.memberTel = hydhtextBox.Text;
                model.memberDocument = sfzhtextBox.Text;
                model.birDate = csrqdateTimePicker.Text.ToString();
                model.cardDate = bkrqdateTimePicker.Text.ToString();
                model.memberSex = hyxbcomboBox.Text;
                model.rebate = spzktextBox.Text;
                if (qydqxzcheckBox.Checked)
                {
                    model.endDate = dateTimePicker1.Text.ToString();
                }
                else
                {
                    model.endDate = "无";
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
                if (qyhymmcheckBox.Checked)
                {
                    model.password = password;
                }
                #region//过程
                //SaveFileDialog filedialog = new SaveFileDialog();               
                //System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                //ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                //EncoderParameter myEncoderParameter = myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                //EncoderParameters myEncoderParameters = new EncoderParameters(1);
                //myEncoderParameters.Param[0] = myEncoderParameter;
                //bitmap.Save(Application.StartupPath + "/a.jpeg", myImageCodecInfo, myEncoderParameters);
                /////////
                //Bitmap newbit = new Bitmap(100, 100);
                //Graphics smg = Graphics.FromImage(newbit);
                //if (bitmap == null)
                //{
                //    MessageBox.Show("空的");
                //}
                //smg.DrawImage((Image)bitmap, 0, 0, 100, 100);
                //string path = Application.StartupPath+"\\a.Png";
                //newbit.Save(path);
                //if (!Directory.Exists(dirpath))
                //    Directory.CreateDirectory(dirpath);
                #endregion
                Bitmap newImage = new Bitmap(160, 120);
                Graphics draw = Graphics.FromImage(newImage);
                draw.DrawImage(bitmap, 0, 0);
                draw.Dispose();
                string dirpath = "E:\\mymemberimg";
                if (!Directory.Exists(dirpath))
                    Directory.CreateDirectory(dirpath);
                string path = dirpath + "\\" + hykhtextBox.Text.Trim()+ ".bmp";
                if (newImage != null)
                    newImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                model.imageUrl = path;
                bool result=modelbll.AddMemberInfo(model);
                if (result)
                {
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后再试！");
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
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.DesiredFrameSize = new Size(160, 120);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        private void hyzjForm_Load(object sender, EventArgs e)
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
            string[] str=new string[]{};
            List<string> list1 = bll.selectNodes();
            str = list1.ToArray();           
            hyflcomboBox.Items.AddRange(str);
            hyflcomboBox.SelectedIndex = 0;
            string name = hyflcomboBox.Text;
            memberType mode = bll.EditMember(name);
            spzktextBox.Text = mode.memberRebate;
            spzktextBox.ReadOnly = true;
            fwzktextBox.Text = "0";
            fwzktextBox.ReadOnly = true;
            czjetextBox.Text = mode.memberTopUp;
            czjetextBox.ReadOnly = true;
            bkjetextBox.Text = mode.memberCardMoney;
            textBox1.Text = mode.memberTypechild;
            textBox1.ReadOnly = true;
            hyxbcomboBox.SelectedIndex = 0;
            ztcomboBox.SelectedIndex = 0;
            dateTimePicker1.Enabled = false;
            szmmbutton.Enabled = false;
            #endregion
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //private static ImageCodecInfo GetEncoderInfo(String mimeType)
        //{
        //    int j;
        //    ImageCodecInfo[] encoders;
        //    encoders = ImageCodecInfo.GetImageEncoders();
        //    for (j = 0; j < encoders.Length; ++j)
        //    {
        //        if (encoders[j].MimeType == mimeType)
        //            return encoders[j];
        //    }
        //    return null;
        //}

        private void qkzpbutton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void hyflcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = hyflcomboBox.Text;
            memberType mode = bll.EditMember(name);
            spzktextBox.Text = mode.memberRebate;
            spzktextBox.ReadOnly = true;
            fwzktextBox.Text = "0";
            fwzktextBox.ReadOnly = true;
            czjetextBox.Text = mode.memberTopUp;
            czjetextBox.ReadOnly = true;
            bkjetextBox.Text = mode.memberCardMoney;
            textBox1.Text = mode.memberTypechild;
            textBox1.ReadOnly = true;
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
            szpassword pwd = szpassword.Create(fuzhipwd);
            pwd.Show();
            pwd.Focus();
        }
    }
}
