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
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Rendering;
using BLL;
using MODEL;
using System.IO;
using Commond;
using System.Text.RegularExpressions;
//[code=csharp]using System;
namespace yixiupige
{
    public partial class shglform : Form
    {
        //员工提成
        //public static int tcMoney = 0;
        TJBBBLL tjbb = new TJBBBLL();
        CardExitMoneyBll carexibll = new CardExitMoneyBll();
        //商品的bll
        GoodInfoBLL gbbll = new GoodInfoBLL();
        //会员类型，目的是拿到折扣卡的相应折扣
        memberTypeCURD membll = new memberTypeCURD();
        //寄存管理的业务处理曾对象
        JCInfoBLL jcbll = new JCInfoBLL();
        public static List<LiShiConsumption> DYList=new List<LiShiConsumption>();
        public static string Path;
        public string hypassword { get; set; }
        public DateTime EndDate { get; set; }
        //public string hyshurupwd { get; set; }
        public static string Tel;
        //将写有寄存的信息加入到该list集合中
        public static List<shInfoList> jclist = new List<shInfoList>();
        //次卡相对应的金额
        public static double ckmoney=0;
        public int jishu = 1;
        public static bool huaka = false;
        DPInfoBLL dpbll = new DPInfoBLL();
        //EncodingOptions options = null;
        ExitDanBLL exitdan = new ExitDanBLL();
        LSConsumptionBLL lsbll = new LSConsumptionBLL();
        QrCodeEncodingOptions option;
        BarcodeWriter writer = null; 
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
        public memberInfoBLL bll=new memberInfoBLL();
        fuwuBLL fuwubl = new fuwuBLL();
        //删除的历史纪录要返还的钱
        public double delecount { get; set; }
        public LiShiConsumption modeldele { get; set; }
        public shglform()
        {
            InitializeComponent();
           // option = new EncodingOptions
            option=new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 320,
                Height = 240
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;//二维码
            //writer.Format = BarcodeFormat.ITF;//改变条形码条形码
            writer.Options = option;  
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
        public jbcsBLL jbbll = new jbcsBLL();
        staffInfoBLL staffbll = new staffInfoBLL();
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shglform_Load(object sender, EventArgs e)
        {
            #region//配置打印机
            
            #endregion
            //1品牌2颜色3常见问题4商品5寄存（收活类别）6员工工种
            dataGridView3.Visible = false;
            radioButton1.Checked = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            checkBox1.Checked = true;
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
            //listtype = staffbll.selectSH();
            //foreach (var iteam in listtype)
            //{
            //    comboBox4.Items.Add(iteam.AllType);
            //}
        }
        //相机连接
        private void CameraConn()
        {
            string carmar=FilterClass.PicImg;
            //new FilterInfo(videoDevices[0].MonikerString);
            FilterInfo state = new FilterInfo(videoDevices[0].MonikerString);
            foreach (FilterInfo device in videoDevices)
            {
                if (device.Name.Trim() ==(carmar==null?videoDevices[0].Name.Trim():carmar.Trim()))
                {
                    state = device;
                }
            }
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //MessageBox.Show(videoSource.VideoCapabilities[2].FrameSize.Width.ToString());
            //MessageBox.Show(videoSource.VideoCapabilities[2].FrameSize.Height.ToString());
            videoSource.VideoResolution = videoSource.VideoCapabilities[2];
            //videoSource.DesiredFrameRate = 1;

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
        /// <summary>
        /// 相机图片保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="image"></param>
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
            string dirpath = "..\\..\\memberInfo\\" + textBox5.Text.Trim() + "";
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
            #endregion
            videoSourcePlayer1.NewFrame -= new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (EndDate.CompareTo(DateTime.Now) <= 0)
                {
                    MessageBox.Show("该会员卡已到期！");
                    return;
                }
            }
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
            if (textBox17.Text.Trim() == "" && textBox18.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空！");
                return;
            }
            if (radioButton2.Checked)
            {
                if (textBox4.Text.Trim() != "")
                {
                    MessageBox.Show("错误！当前操作用户选项为散客，但实际要消费的是会员，请更改！");
                    return;
                }
            }
            DialogResult result= MessageBox.Show("是否寄存", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            shInfoList model = new shInfoList();//基本服务的模型
            //shInfoList modelqt = new shInfoList();//其他服务的模型
            if (result == DialogResult.OK)
            {
                model.JiCun = true;
                if (numericUpDown1.Value != 1)
                {
                    MessageBox.Show("寄存商品请单件寄存！");
                    return;
                }
            }
            else
            {
                model.JiCun = false;
            }
            model.Id = jishu;
            //modelqt.Id = ++jishu;
            model.FuWuName = textBox13.Text.Trim()+textBox16.Text.Trim();
            //modelqt.FuWuName = ;
            #region//是会员或者不是会员的话!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (radioButton1.Checked)
            {
                if (textBox12.Text.Trim() == "计次卡")
                {
                        //model.CiCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) / ckmoney)));
                    model.CiCount = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value);
                        if (huaka)
                        {
                            //model.CiCount += Convert.ToInt32(Math.Ceiling(Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim()) / ckmoney));
                            model.CiCount += Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                            model.YMoney = 0;
                            model.FuKuan = true;
                        }
                        else
                        {
                            model.YMoney = Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                            model.FuKuan = false;
                        }
                        //model.CountMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                        model.CountMoney = Convert.ToDouble(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * ckmoney;
                        if (huaka)
                        {
                            model.CountMoney += Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim()) * ckmoney;
                        }
                        else
                        {
                            model.CountMoney += Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                        }
                        //model.YMoney = 0;
                        //model.IsHuaCard = true;
                        //model.FuKuan = true;
                }
                else if (textBox12.Text.Trim() == "储值卡")
                {
                    model.CiCount = 0;
                    if (model.FuWuName != "")
                    {
                        model.CountMoney = Convert.ToDouble(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                        if (huaka)
                        {
                            model.YMoney = 0;
                            model.FuKuan = true;
                        }
                        else
                        {
                            model.YMoney = Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                            model.FuKuan = false;
                        }
                    }
                }
                else//折扣卡
                {
                    model.CiCount = 0;
                    if (model.FuWuName != "")
                    {
                        model.CountMoney = Convert.ToDouble(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                        if (huaka)
                        {
                            model.YMoney = 0;
                            model.FuKuan = true;
                        }
                        else
                        {
                            model.YMoney = Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                            model.FuKuan = false;
                        }
                    }
                    //这是折扣卡执行的条件
                    //model.CiCount = 0;
                    //model.CountMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                    //model.YMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());            
                }
            }
            else
            {
                //不是会员的话执行的
                model.CiCount = 0;
                model.CountMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                model.YMoney = model.CountMoney;
                //model.YMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
            }
            #endregion
            model.Count = Convert.ToInt32(numericUpDown1.Value);
            model.PaiNumber = "";
            model.CJQuestion = textBox19.Text;
            model.Remark = textBox20.Text;
            model.Type = comboBox1.Text;
            model.PinPai = comboBox2.Text;
            model.Color = comboBox3.Text;
            model.YMPerson = FilterClass.DianPu1.LoginName;
            model.ImgUrl = Path;
            pictureBox1.ImageLocation = Path;
            GridView2Bind(model);
            jishu++;
            #region//确定之后清空右边属性
            textBox13.Text = "";//基本服务
            textBox16.Text = "";//其他服务
            textBox17.Text = "";//金额
            textBox18.Text = "";//应付
            textBox19.Text = "";
            textBox20.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            //comboBox4.Text = "";
            numericUpDown1.Value = 1;
            #endregion

        }
        //向datagridview2里面累加数据
        public void GridView2Bind(shInfoList model)
        {
            List<shInfoList> list = new List<shInfoList>();
            if (dataGridView2.Rows.Count == 0)
            {
                list.Add(model);
                dataGridView2.DataSource = list;
            }
            else
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    list.Add((shInfoList)dataGridView2.Rows[i].DataBoundItem);
                }
                list.Add(model); 
                dataGridView2.DataSource = list;
            }
        }
        // //向datagridview2里面累加数据这个函数累加的是商品
        public void GridView2BindSP(shInfoList model,bool result)
        {
            model.YMPerson = FilterClass.DianPu1.LoginName;
            //ckmoney
            if (textBox12.Text.Trim() == "计次卡"&&result)
            {
                model.CiCount = Convert.ToInt32(Math.Ceiling(model.CountMoney / ckmoney));
            }
            else if (textBox12.Text.Trim() == "计次卡" && !result)
            {
                model.CiCount = 0;
            }
            if (result)
            {
                model.YMoney = 0;
                model.FuKuan = true;
            }
            else
            {
                model.YMoney = model.CountMoney;
                model.FuKuan = false;
            }
            //int count = dataGridView2.Rows.Count + 1;
            model.Id = jishu;
            List<shInfoList> list = new List<shInfoList>();
            if (dataGridView2.Rows.Count == 0)
            {
                list.Add(model);
                dataGridView2.DataSource = list;
            }
            else
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    list.Add((shInfoList)dataGridView2.Rows[i].DataBoundItem);
                }
                list.Add(model);
                dataGridView2.DataSource = list;
            }
        }
        public void Decode(PictureBox pictureBox1)
        {
            BarcodeReader reader =new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
            //暂时不用
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //识别条形码
            //BarcodeReader reader = new BarcodeReader();
            //Result result = reader.Decode((Bitmap)pictureBoxQr.Image);
            //MessageBox.Show(result.Text);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = "";
                textBox1.ReadOnly = true;
                textBox2.Text = "";
                textBox2.ReadOnly = true;
            }
            else
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
            }
        }
        public List<shMemberInfo> listSousuo;
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sousuo = textBox3.Text.Trim();
                bool mohu = checkBox1.Checked;
                listSousuo = bll.selectForIdList(sousuo, mohu);
                if (listSousuo.Count == 0)
                {
                    MessageBox.Show("没有相对应信息！");
                    return;
                }
                dataGridView3.DataSource = listSousuo;
                dataGridView3.Visible = true;
                if (listSousuo.Count == 1)
                {
                    dataGridView3_CellClick(dataGridView3,new DataGridViewCellEventArgs(0,0));
                }
                dataGridView2.DataSource = new List<shInfoList>();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dataGridView3.Visible = false;
            string card=listSousuo[index].ID.ToString();
            memberInfoModel model = bll.SelectId(card);
            ckmoney = Convert.ToDouble(model.cardMoney) / Convert.ToDouble(model.toUpMoney);
            EndDate = Convert.ToDateTime(model.endDate);
            if (model.password.Trim() == "")
            {
                hypassword = "";
            }
            else
            {
                hypassword = model.password.Trim();
            }
            textBox4.Text = model.memberName;
            textBox5.Text = model.memberCardNo;
            textBox6.Text = model.memberTel;
            textBox7.Text = model.rebate;
            textBox12.Text = model.cardType;
            textBox10.Text = model.memberType;
            textBox11.Text = model.cardDate;
            //pictureBox1.ImageLocation = model.imageUrl;
            if (model.cardType.Trim() == "计次卡")
            {
                textBox8.Text = model.toUpMoney;
                if (textBox8.Text.Contains("."))
                {
                    textBox8.Text = textBox8.Text.Split(new char[]{'.'},StringSplitOptions.RemoveEmptyEntries)[0];
                }
                textBox9.Text = "0";
            }
            else if (model.cardType.Trim() == "储值卡")
            {
                textBox8.Text = "0";
                textBox9.Text = model.toUpMoney;
            }
            else 
            {
                textBox8.Text = "0";
                textBox9.Text = model.toUpMoney;
            }
            button5_Click(button5, new EventArgs());
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" && radioButton2.Checked == false)
            {
                MessageBox.Show("请先查找会员！");
                return;
            }
            jbfuCheckBoxFrom shouhuojb = jbfuCheckBoxFrom.CreateForm(jbFuWuCount);
            shouhuojb.ShowDialog();
            shouhuojb.Focus();
        }
        //计算基本服务的价格，将名称与价格进行显示   这里将计算对的金额   即折扣卡或者计次卡等相对应的信息
        public void jbFuWuCount(string model)
        {
            int bate = 0;
            textBox13.Text = model;
            double money = 0;            
            string type = textBox10.Text.Trim() == "" ? "无卡" : textBox10.Text.Trim();
            //如果卡的类型为这折扣卡，那么就按无卡计算钱
            if (textBox12.Text.Trim() == "折扣卡")
            {
                type = "无卡";
                //然后拿到当前会员卡的名字textBox10 通过名字拿到相对应的折扣
                bate = membll.selectZK(textBox10.Text.Trim());
            }
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
                                money += Convert.ToDouble(iteamdan.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            if (bate == 0)
            {
                //等于0的时候有可能是计次卡或者储值卡
                textBox17.Text = money.ToString();
            }
            else
            {
                //不等于0的时候   代表是折扣卡
                textBox17.Text = (money * bate /100 ).ToString();
            }
        }
        /// <summary>
        /// 返回是否划卡消费和fanhuijine   其他服务
        /// </summary>
        /// <param name="name"></param>
        /// <param name="money"></param>
        /// <param name="result"></param>
        public void qtfuwumoney(string name,double money,bool result)
        {
            int bate = 0;
            huaka = result;
            //划卡的时候
            if (result)
            {
                if (textBox12.Text.Trim() == "折扣卡")
                {
                    //然后拿到当前会员卡的名字textBox10 通过名字拿到相对应的折扣
                    bate = membll.selectZK(textBox10.Text.Trim());
                }
                if (bate == 0)
                {
                    textBox16.Text = name;
                    textBox18.Text = money.ToString();
                }
                else
                {
                    textBox16.Text = name;
                    textBox18.Text = (money * bate / 100).ToString();
                }
            }
                //不划卡的时候
            else
            {
                textBox16.Text = name;
                textBox18.Text = money.ToString();
            }
        }
        private void textBox16_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" && radioButton2.Checked == false)
            {
                MessageBox.Show("请先查找会员！");
                return;
            }
            qtfuCheckBoxFrom qtfuwu = qtfuCheckBoxFrom.CreateForm(qtfuwumoney);
            qtfuwu.Show();
            qtfuwu.Focus();
        }
        public void cjquestion(string name)
        {
            textBox19.Text = name;
        }
        private void textBox19_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" && radioButton2.Checked == false)
            {
                MessageBox.Show("请先查找会员！");
                return;
            }
            cjQuestion cjquest = cjQuestion.CreateForm(cjquestion);
            cjquest.ShowDialog();
            cjquest.Focus();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 7)
            {
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
            
        }
        #region//右键单击datagridview
        private void dataGridView2_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            int i = dataGridView2.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                dataGridView2.Rows[j].Selected = false;
            }
            try
            {
                dataGridView2.Rows[e.RowIndex].Selected = true;
            }
            catch
            {
                return;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                //if (this.ContextMenuStrip != null && this.ContextMenuStripNeeded != null)
                //{
                //int rowIndex = this.GetRowIndexAt(e.Location);  // 计算行号  
                //int colIndex = this.GetColIndexAt(e.Location);  // 计算列号  this.ContextMenuStrip, rowIndex, colIndex
                DataGridViewRowContextMenuStripNeededEventArgs ee;  // 事件参数  
                ee = new DataGridViewRowContextMenuStripNeededEventArgs(1);
                this.dataGridView2_RowContextMenuStripNeeded(e.Location, ee);  // 引发自定义事件，执行事件方法  
                //}

            }
        }
        #endregion

        private void 删除本条ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }
            List<shInfoList> list1 = new List<shInfoList>();
            int index = dataGridView2.SelectedRows[0].Index;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (i == index)
                {
                    continue;
                }
                shInfoList model = (shInfoList)dataGridView2.Rows[i].DataBoundItem;
                list1.Add(model);
            }
            dataGridView2.DataSource = list1;
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataviewRowsChange();
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dataviewRowsChange();
        }
        public void dataviewRowsChange()
        {
            List<shInfoList> list = (List<shInfoList>)dataGridView2.DataSource;
            double hjje = 0;
            int hjcs = 0;
            double yfje = 0;
            foreach (var iteam in list)
            {
                hjje += Convert.ToDouble(iteam.CountMoney);
                hjcs += Convert.ToInt32(iteam.CiCount);
                yfje += Convert.ToDouble(iteam.YMoney);
            }
            textBox14.Text = hjje.ToString();
            textBox21.Text = hjcs.ToString();
            textBox22.Text = yfje.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView2.Rows[e.RowIndex].Cells["shImgUrl"].Value.ToString();
        }
        //会员点击保存之后   如果有密码则开始输入密码   并将用户输入的密码合最开始的进行对比
        public void TwoPwdYZ(string pwd)
        {
            bool IsSave = true;
            if (hypassword != pwd)
            {
                MessageBox.Show("密码错误！消费失败！");
                return;
            }
            DialogResult res = MessageBox.Show("是否打印小票", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                IsSave = false;
            }
            BaoCunClick(IsSave);
        }
        //不管有没有密码   点击保存之后执行的方法
        public void BaoCunClick(bool issave)
        {
            string sb = "";
            string[] ss = DateTime.Now.ToString("yyyy-MM-dd").Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in ss)
            {
                sb += s;
            }
            Random rad = new Random();
            sb += rad.Next(1000, 9999);
            //将数据表中的数据拿出来，然后遍历，将是寄存的商品单独提取到另一个收活list中，然后添加到寄存管理里面
            List<shInfoList> listjieshu = (List<shInfoList>)dataGridView2.DataSource;
            if (listjieshu == null)
            {
                MessageBox.Show("无数据！");
                return;
            }
            List<LiShiConsumption> listLS = new List<LiShiConsumption>();
            LiShiConsumption model;
            foreach (var iteam in listjieshu)
            {
                model = new LiShiConsumption();
                Tel = textBox6.Text.Trim() == "" ? textBox2.Text.Trim() : textBox6.Text.Trim();
                model.IsJC = iteam.JiCun;
                model.LSName = textBox4.Text.Trim() == "" ? textBox1.Text.Trim() : textBox4.Text.Trim();
                model.LSDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                model.ImgUrl = iteam.ImgUrl;
                model.LSStaff = iteam.Type + ":" + iteam.FuWuName;
                if (radioButton1.Checked)
                {
                    model.LSNumberCount = textBox6.Text.Trim();
                }
                else
                {
                    model.LSNumberCount = textBox2.Text.Trim();
                }
                //model.LSNumberCount = "0";
                model.LSMoney = iteam.CountMoney.ToString();
                model.LSYMoney = iteam.YMoney.ToString();
                model.IsXMoney = iteam.FuKuan;
                model.LSCount = iteam.Count.ToString();
                model.LSPinPai = iteam.PinPai;
                model.LSColor = iteam.Color;
                model.LSSalesman = iteam.YMPerson;
                model.LSCardNumber = textBox5.Text.Trim() == "" ? "散客" : textBox5.Text.Trim();
                int panduan = 0;
                int.TryParse(iteam.ImgUrl, out panduan);
                if (panduan != 0)
                {
                    model.IsSP = true;
                }
                else
                {
                    model.IsSP = false;
                }
                //此处需要连锁店明，后期导入
                model.LSMultipleName = FilterClass.DianPu1.UserName;
                model.LSQuestion = iteam.CJQuestion;
                model.LSRemark = iteam.Remark;
                model.LSDanNumber = sb;
                if (iteam.JiCun == true)
                {
                    jclist.Add(iteam);
                    if (dateTimePicker1.Value.Day == DateTime.Now.Day)
                    {
                        MessageBox.Show("有物品需要寄存，请更改取件日期！");
                        jclist = new List<shInfoList>(); ;
                        return;
                    }
                    //如果有寄存并且日期正确，那么再次将需要寄存的项加入到集合中，放入寄存管理内
                }
                else
                {
                    if (iteam.YMoney != 0 && !iteam.FuKuan)
                    {
                        MessageBox.Show("有物品未寄存并且有欠款未付！");
                        jclist = new List<shInfoList>();
                        return;
                    }
                }
                listLS.Add(model);
            }
            //需要减去卡上余额
            bool xiaofeiresult = false;
            if (!radioButton2.Checked)
            {
                string cardNumber = textBox5.Text.Trim();
                if (textBox12.Text.Trim() == "计次卡")
                {
                    int oldccount = Convert.ToInt32(textBox8.Text.Trim());
                    int Scount = oldccount - Convert.ToInt32(textBox21.Text.Trim());
                    if (oldccount > 0 && Scount < 0)
                    {
                        MessageBox.Show("余额不足！");
                        jclist = new List<shInfoList>();
                        return;
                    }
                    xiaofeiresult = bll.XFmoney(cardNumber, Scount.ToString());
                    textBox8.Text = Scount.ToString();
                    if (!xiaofeiresult)
                    {
                        MessageBox.Show("消费失败！");
                        jclist = new List<shInfoList>();
                        return;
                    }
                }
                else if (textBox12.Text.Trim() == "储值卡")
                {
                    double oldmoney = Convert.ToDouble(textBox9.Text.Trim());
                    double Xmoney = oldmoney - (Convert.ToDouble(textBox14.Text.Trim()) - Convert.ToDouble(textBox22.Text.Trim()));
                    if (Xmoney <= 0.0 && oldmoney > 0.0)
                    {
                        MessageBox.Show("余额不足！");
                        return;
                    }
                    xiaofeiresult = bll.XFmoney(cardNumber, Xmoney.ToString());
                    textBox9.Text = Xmoney.ToString();
                    if (!xiaofeiresult)
                    {
                        MessageBox.Show("消费失败！");
                        return;
                    }
                }
                else if (textBox12.Text.Trim() == "折扣卡")
                {
                    double oldmoney = Convert.ToDouble(textBox9.Text.Trim());
                    double Xmoney = oldmoney - (Convert.ToDouble(textBox14.Text.Trim()) - Convert.ToDouble(textBox22.Text.Trim()));
                    if (Xmoney < 0.0 && oldmoney > 0.0)
                    {
                        MessageBox.Show("余额不足！");
                        return;
                    }
                    xiaofeiresult = bll.XFmoney(cardNumber, Xmoney.ToString());
                    textBox9.Text = Xmoney.ToString();
                    if (!xiaofeiresult)
                    {
                        MessageBox.Show("消费失败！");
                        return;
                    }
                }
            }
            //数据添加到寄存表中之前先打印不干胶，并将信息同时添加到寄存表中
            for (int g = 0; g < jclist.Count; g++)
            {
                string bgjtm = "";
                string num = "";
                string dpname = FilterClass.DianPu1.UserName.Trim();
                //拿到店铺编号，合今日所松溪的数量的number，然后拼接不干胶打印机条码的数字
                //第一个是前面的店铺编号，后面的是所卖的数量
                string[] dpnumber = dpbll.selectNumberAndNo(dpname);
                string dpID = dpnumber[2].Trim();
                num = dpnumber[1].Trim();
                for (int i = num.Length; i < 4; i++)
                {
                    num = "0" + num;
                }
                //保存为正确格式的条码
                bgjtm = dpnumber[0].Trim() + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + num;
                //不干胶打印//成功后打印不干胶条形码!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                bool result = PirentZXingNet.PirentTM(bgjtm, jclist[0].FuWuName, sb, dateTimePicker1.Value.ToString("yyyy-MM-dd"), jclist.Count, (g + 1), jclist[0].CJQuestion, jclist[0].Type, jclist[0].PinPai, jclist[0].Color, jclist[0].Remark);
                if (result)
                {
                    jclist[g].PaiNumber = bgjtm;
                    int j = Convert.ToInt32(num);
                    j++;
                    result = dpbll.uodateNumber(dpID, j);
                }
            }
            //将寄存数据添加到寄存数据表中
            bool addjcresult = jcbll.addJCList(jclist, textBox5.Text.Trim(), textBox4.Text.Trim() == "" ? textBox1.Text.Trim() : textBox4.Text.Trim(), TimeGuiGe.TimePicterBegin(dateTimePicker1.Text).ToString(), sb, Tel);

            jclist = new List<shInfoList>();
            //将数据添加到消费记录里面
            bool resultls = lsbll.AddList(listLS);
            if (resultls)
            {
                //将刚刚消费的数据添加到消费记录里面
                dataBindgridview1(listLS);
                //DYList = listLS;
            }
            string websb = "http://yhc19950315.imwork.net:28948?id=" + sb;
            Bitmap bitmap = writer.Write(websb);
            //pictureBoxQr.Image = bitmap;
            string gksy = "";
            if (textBox12.Text.Trim() == "计次卡")
            {
                gksy = "余次：" + textBox8.Text + "次";
            }
            else if (textBox12.Text.Trim() == "储值卡" || textBox12.Text.Trim() == "折扣卡")
            {
                gksy = "余额：" + textBox9.Text + "元";
            }
            else
            {
                gksy = "电话" + textBox2.Text;
            }
            if (issave)
            {
                ///合计金额  合计次数  应付金额   刚刚的消费记录   二维码   包含的网址链接   姓名  卡号   到期日期   余额
                PirentDocumentClass.PirentSH(textBox14.Text, textBox21.Text, textBox22.Text, listjieshu, bitmap, sb, textBox4.Text, textBox5.Text, dateTimePicker1.Text, gksy);

            }//printDocument1.Print();
            dataGridView2.DataSource = new List<shInfoList>();
            TJBBBuy(listjieshu);
            //清空数据
            emptyInfo();
            jishu = 1;
        }
        /// <summary>
        /// 点击保存之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            bool IsSave = true;
            if (radioButton2.Checked&&textBox1.Text==""&&textBox2.Text=="")
            {
                DialogResult result= MessageBox.Show("散客用户名和密码均为空，是否使用默认？","提示信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    textBox1.Text = "[默认用户名]";
                    textBox2.Text = "[默认电话号]";
                }
                else
                {
                    return;
                }
            }
            if (radioButton2.Checked)
            {
                if (textBox4.Text.Trim() != "")
                {
                    MessageBox.Show("错误！当前操作用户选项为散客，但实际要消费的是会员，请更改！");
                    return;
                }
            }
            else//是会员的时候
            {
                if (hypassword != "")//会员设置了密码
                {
                    HYXFPassword from = HYXFPassword.CreateForm(TwoPwdYZ);
                    from.Show();
                    return;
                }
            }
            DialogResult res= MessageBox.Show("是否打印小票","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                IsSave = false;
            }
            BaoCunClick(IsSave);
        }
        /// <summary>
        /// 数据清空
        /// </summary>
        public void emptyInfo()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            dateTimePicker1.ResetText();
            dataGridView1.DataSource = new List<LiShiConsumption>();
        }
        /// <summary>
        /// 点完保存之后才执行
        /// </summary>
        /// <param name="list"></param>
        public void TJBBBuy(List<shInfoList> list)
        {
            //将卡消费进行统计保存
            string membername = textBox4.Text.Trim();
            if (membername != "")
            {
                string membernum = textBox5.Text.Trim();
                string cardname = textBox10.Text.Trim();
                string cardtype = textBox12.Text.Trim();
                carexibll.AddList(list, membername, membernum, cardname, cardtype);
            }
            List<shInfoList> list1 = new List<shInfoList>();
            foreach (var iteam in list)
            {
                int count = iteam.Count;
                string no = iteam.ImgUrl.Trim();
                if (iteam.FuWuName.Length < 4)
                {
                    continue;
                }
                if (iteam.FuWuName.Substring(0, 4) == "购买商品")
                {
                    PutHuo model = new PutHuo()
                    {
                        PutCardNo = textBox5.Text.Trim(),
                        PutCount = iteam.Count.ToString(),
                        //PutDate = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日",
                        PutDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        PutDianName = FilterClass.DianPu1.UserName.Trim(),
                        PutMoney = iteam.CountMoney.ToString(),
                        PutName = iteam.FuWuName.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)[1],
                        PutNo = iteam.ImgUrl.Trim(),
                        PutSale = FilterClass.DianPu1.LoginName,
                        PutType = iteam.Type                        
                        //PubPersonName = textBox4.Text.Trim()
                    };
                    if (radioButton1.Checked)
                    {
                        model.PubPersonName = textBox4.Text.Trim();
                    }
                    else
                    {
                        model.PubPersonName = textBox1.Text.Trim();
                    }
                    //首先应该减去数量
                    SPDelete(no,count);
                    //第二应该将纪录天交到表格中
                    AddIteam(model);
                }
            }
        }
        /// <summary>
        /// 购买商品成功之后，减去所属商品的数量
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dian"></param>
        /// <param name="count"></param>
        public void SPDelete(string no, int count)
        {
            
            gbbll.UpdateXF(no,count);
        }
        /// <summary>
        /// 将购买商品的信息放入到表格记录里面
        /// </summary>
        /// <param name="model"></param>
        public void AddIteam(PutHuo model)
        {
            
            tjbb.AddIteam(model);
        }
        public void dataBindgridview1(List<LiShiConsumption> list)
        {
            dataGridView1.DataSource = list;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            spSalesFrom spsale = spSalesFrom.CreateForm(GridView2BindSP);
            spsale.Show();
            spsale.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //是会员的时候
            if (radioButton1.Checked)
            {
                if (textBox5.ToString().Trim() == "")
                {
                    MessageBox.Show("请先查找会员！");
                    return;
                }
                string name = FilterClass.DianPu1.UserName;
                dataGridView1.DataSource = lsbll.selectAllList(textBox5.Text.Trim(), name);
            }
            else //不是会员的时候
            {
                if ((textBox1.Text.Trim() == "")&& (textBox2.Text.Trim() == ""))
                {
                    MessageBox.Show("请输入散客信息！");
                    return;
                }
                string name = FilterClass.DianPu1.UserName;
                //散客消费信息查询
                dataGridView1.DataSource = lsbll.selectAllListSK(textBox1.Text.Trim(),textBox2.Text.Trim(), name);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //}
            //dataGridView1.Rows[e.RowIndex].Selected = true;
            if (dataGridView1.Rows.Count > 0 && e.RowIndex > 0)
            {
                pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells["Imgurl"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = "";
            string cardnum = "";
            string tel = "";
            if (radioButton1.Checked)
            {
                if (textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("请先查找会员！");
                        return;
                }
                name = textBox4.Text.Trim();
                cardnum = textBox5.Text.Trim();
                tel = textBox6.Text.Trim();

            }
            else//不是会员的时候
            {
                if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入散客信息！");
                    return;
                }
                name = textBox1.Text.Trim();
                tel = textBox2.Text.Trim();
            }
            bdpjFrom bdpj = bdpjFrom.Create(name, cardnum, tel);
            bdpj.Show();
            bdpj.Focus();
        }


        private void 删除本条ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LiShiConsumption model = (LiShiConsumption)dataGridView1.SelectedRows[0].DataBoundItem;
            modeldele = model;           
            //将删除的数据当时消费的金额或者次数提取出来
            if (textBox12.Text.Trim() == "储值卡")
            {
                delecount = Convert.ToDouble(model.LSMoney);
            }
            else if (textBox12.Text.Trim() == "计次卡")
            {
                delecount = Convert.ToDouble(model.LSMoney);
            }
            else if (textBox12.Text.Trim() == "折扣卡")
            {
                double money = Convert.ToDouble(model.LSMoney);
                int bate = membll.selectZK(textBox10.Text.Trim());
                delecount = money * 100 / bate;
            } 
            //caocuofrom caozuo = caocuofrom.Create(deletePassword, model.ID.ToString());
            //caozuo.Show();
            deletePassword(model.ID.ToString());
        }
        public void deletePassword(string cardNo)
        {
            string name = FilterClass.DianPu1.UserName;
                LSConsumptionBLL infobll = new LSConsumptionBLL();
                bool result = infobll.deleteID(cardNo);
                dataGridView1.DataSource = lsbll.selectAllList(textBox5.Text.Trim(), name);
                if (result)
                {
                    MessageBox.Show("退单成功！");
                    if (textBox12.Text.Trim() == "储值卡")
                    {
                        //把钱加回来  之前消费的
                        string money=(Convert.ToDouble(textBox9.Text.Trim()) + delecount).ToString();
                        bll.XFmoney(textBox5.Text.Trim(), money);  
                        textBox9.Text = money;                     
                    }                                              
                    else if (textBox12.Text.Trim() == "计次卡")    
                    {                                              
                        string count=(Convert.ToInt32(textBox8.Text.Trim()) + delecount).ToString();
                        bll.XFmoney(textBox5.Text.Trim(), count);
                        textBox8.Text = count;
                    }
                    else if (textBox12.Text.Trim() == "折扣卡")
                    {
                        //把钱加回来  之前消费的
                        string money = (Convert.ToDouble(textBox9.Text.Trim()) + delecount).ToString();
                        bll.XFmoney(textBox5.Text.Trim(), money);  
                        textBox9.Text = money;                     
                    }                           
                    }
                    if (modeldele.IsSP)
                    {
                        #region MyRegion//把商品数量加回来
                        //如果是商品就把数量加回来
                        int spid = 0;
                        int ID = 0;
                        int.TryParse(modeldele.ImgUrl, out spid);
                        if (spid != 0)
                        {
                            ID = spid;
                        }
                        gbbll.DeleteAdd(ID, Convert.ToInt32(modeldele.LSCount.Trim())); 
                        #endregion
                        #region //将售出的商品表中的内容删除掉  本应将数据删除，但由于后期客户添加了退单功能所以退掉的单需要单独统计，所以此处陷阱行注释，砍退单后销售的记录是否还继续保存
                        //string staff=modeldele.LSStaff.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        //string dianpu = FilterClass.DianPu1.UserName.Trim();
                        //string cardno = modeldele.LSCardNumber.Trim();
                        //string pattern = @"[\d]+";
                        //Regex regex = new Regex(pattern, RegexOptions.None);
                        //int dyear = Convert.ToInt32(regex.Matches(modeldele.LSDate)[0].Value);
                        //int dmonth = Convert.ToInt32(regex.Matches(modeldele.LSDate)[1].Value);
                        //int dday = Convert.ToInt32(regex.Matches(modeldele.LSDate)[2].Value);
                        //string date = dyear.ToString() + "年" + dmonth.ToString() + "月" + dday.ToString() + "日";
                        //int gid = tjbb.getIteamId(staff, dianpu, cardno, date);
                        //tjbb.DeleteIteamID(gid);
                        #endregion
                    }
                    #region MyRegion//无论是不是商品或者寄存，一旦退单九江退单记录进行添加，加到退单统计表中
                    ExitDanTJ();
                    #endregion
                    if (modeldele.IsJC)
                    {
                        #region //寄存表中删除  同上，由于加了退单功能，此处先不进行删除  根据客户要求在进行修改
                        //如果是寄存就把寄存信息删除
                        //string dianpu = FilterClass.DianPu1.UserName.Trim();
                        //string cardno = modeldele.LSCardNumber.Trim();
                        //string date = modeldele.LSDate.Substring(0, 10);
                        //string money = modeldele.LSYMoney;
                        //string staff = modeldele.LSStaff;
                        //string pinpai = modeldele.LSPinPai;
                        //string color = modeldele.LSColor;
                        //int id = jcbll.seleDelete(dianpu, cardno, date, money, staff, pinpai, color);
                        //jcbll.deleteIDIteam(id.ToString()); 
                        #endregion
                    }
                }
        /// <summary>
        /// 此方法是将退单信息添加到退单记录中
        /// </summary>
        public void ExitDanTJ()
        {
            ExitDanModel model = new ExitDanModel();
            model.DanMoney = modeldele.LSMoney;
            model.memberName = modeldele.LSName;
            model.memberCardNo = modeldele.LSDanNumber;
            model.saleMen = FilterClass.DianPu1.LoginName;
            model.DPName = modeldele.LSMultipleName;
            model.StaffName = modeldele.LSStaff;
            model.ExitDanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            exitdan.AddExitDan(model);
        }
        private void dataGridView1_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            int i = dataGridView1.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                dataGridView1.Rows[j].Selected = false;
            }
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch
            {
                return;
            }
        }
        public void videoStar()
        {
            CameraConn();
        }
        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {
            string str = "..\\..\\memberInfo\\" + textBox5.Text.Trim() + "";
            if (textBox4.Text.Trim() == "")
            {
                str = "..\\..\\memberInfo\\sanke";
            }
            VideoAndPicture frompic = VideoAndPicture.CreateForm(str, videoStar);
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            frompic.Show();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                dateTimePicker1.ResetText();
                dataGridView1.DataSource = new List<LiShiConsumption>();
                dataGridView2.DataSource = new List<shInfoList>();
            }
        }        
    }
}

