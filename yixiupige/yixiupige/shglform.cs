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
//[code=csharp]using System;
namespace yixiupige
{
    public partial class shglform : Form
    {
        //员工提成
        //public static int tcMoney = 0;
        //商品的bll
        GoodInfoBLL gbbll = new GoodInfoBLL();
        //寄存管理的业务处理曾对象
        JCInfoBLL jcbll = new JCInfoBLL();
        public static List<LiShiConsumption> DYList=new List<LiShiConsumption>();
        public static string Path;
        //将写有寄存的信息加入到该list集合中
        public static List<shInfoList> jclist = new List<shInfoList>();
        //次卡相对应的金额
        public static double ckmoney=0;
        public static int jishu = 1;
        public static bool huaka = false;
        //EncodingOptions options = null;
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
        public int delecount { get; set; }
        public bool IsJC { get; set; }
        public bool IsSP { get; set; }
        public int SPcount { get; set; }
        public int spID { get; set; }
        public shglform()
        {
            InitializeComponent();
            //options = new EncodingOptions
            option=new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = pictureBoxQr.Height,
                Height = pictureBoxQr.Height
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
        private void shglform_Load(object sender, EventArgs e)
        {
            #region//配置打印机
            
            #endregion
            //1品牌2颜色3常见问题4商品5寄存（收活类别）6员工工种
            dataGridView3.Visible = false;
            radioButton1.Checked = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
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
            listtype = staffbll.selectSH();
            foreach (var iteam in listtype)
            {
                comboBox4.Items.Add(iteam.AllType);
            }
        }
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
            //try
            //{
            //    pictureBox1.Image = bitmap;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("保存图像失败!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            videoSourcePlayer1.NewFrame -= new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(videoSourcePlayer1_NewFrame);
            #region         
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
            #endregion
            if (textBox17.Text.Trim() == "" && textBox18.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空！");
                return;
            }
            DialogResult result= MessageBox.Show("是否寄存", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            shInfoList model = new shInfoList();
            if (result == DialogResult.OK)
            {
                model.JiCun = true;
            }
            else
            {
                model.JiCun = false;
            }
            model.Id = jishu;
            model.FuWuName = textBox13.Text.Trim() + textBox16.Text;
            #region//是会员或者不是会员的话
            if (radioButton1.Checked)
            {
                if (textBox12.Text.Trim() == "计次卡")
                {
                    model.CiCount = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                    model.CountMoney = (Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim())) * ckmoney;
                    if (huaka)
                    {
                        model.YMoney = 0;
                    }
                    else
                    {
                        model.YMoney = Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim()) * ckmoney;
                    }
                }
                else if (textBox12.Text.Trim() == "储值卡")
                {
                    model.CiCount = 0;
                    model.CountMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                    if (huaka)
                    {
                        model.YMoney = 0;
                    }
                    else
                    {
                        model.YMoney = Convert.ToDouble(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                    }
                }
            }
            else
            {
                model.CiCount = 0;
                model.CountMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
                model.YMoney = Convert.ToInt32(textBox17.Text.Trim() == "" ? "0" : textBox17.Text.Trim()) * Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(textBox18.Text.Trim() == "" ? "0" : textBox18.Text.Trim());
            }
            #endregion

            model.FuKuan = false;
            model.Count = Convert.ToInt32(numericUpDown1.Value);
            model.PaiNumber = textBox15.Text;
            model.CJQuestion = textBox19.Text;
            model.Remark = textBox20.Text;
            model.Type = comboBox1.Text;
            model.PinPai = comboBox2.Text;
            model.Color = comboBox3.Text;
            model.YMPerson = comboBox4.Text;
            model.ImgUrl = Path;
            pictureBox1.ImageLocation = Path;
            GridView2Bind(model);
            //string sb = "http//:www.baidu.com";
            ////string[] ss = DateTime.Now.ToString("yyyy MM dd HH:mm:ss").Split(new char[] { '/', ':',' ' }, StringSplitOptions.RemoveEmptyEntries);
            ////foreach (var s in ss)
            ////{
            ////    sb += s;
            ////}
            //Bitmap bitmap = writer.Write(sb);
            //pictureBoxQr.Image = bitmap;
            jishu++;
            #region//确定之后清空右边属性
            textBox13.Text = "";//基本服务
            textBox16.Text = "";//其他服务
            textBox17.Text = "";//金额
            textBox18.Text = "";//应付
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
        public void GridView2BindSP(shInfoList model,bool result)
        {
            model.YMPerson = comboBox4.Text.Trim();
            //ckmoney
            if (textBox12.Text.Trim() == "计次卡"&&result)
            {
                model.CiCount = Convert.ToInt32(Math.Ceiling(model.CountMoney / ckmoney));
            }
            int count = dataGridView2.Rows.Count + 1;
            model.Id = count;
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
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dataGridView3.Visible = false;
            string card=listSousuo[index].CardNo;
            memberInfoModel model = bll.SelectId(card);
            ckmoney = Convert.ToDouble(model.cardMoney) / Convert.ToDouble(model.toUpMoney);
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
                textBox9.Text = "0";
            }
            else if (model.cardType.Trim() == "储值卡")
            {
                textBox8.Text = "0";
                textBox9.Text = model.toUpMoney;
            }
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" && radioButton2.Checked == false)
            {
                MessageBox.Show("清先查找会员！");
                return;
            }
            jbfuCheckBoxFrom shouhuojb = jbfuCheckBoxFrom.CreateForm(jbFuWuCount);
            shouhuojb.ShowDialog();
            shouhuojb.Focus();
        }
        //计算基本服务的价格，将名称与价格进行显示
        public void jbFuWuCount(string model)
        {
            textBox13.Text = model;
            int money = 0;
            string type = textBox10.Text.Trim() == "" ? "无卡" : textBox10.Text.Trim();
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
            textBox17.Text = money.ToString();
        }
        public void qtfuwumoney(string name,int money,bool result)
        {
            huaka = result;
            textBox16.Text = name;
            textBox18.Text = money.ToString();
        }
        private void textBox16_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" && radioButton2.Checked == false)
            {
                MessageBox.Show("清先查找会员！");
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
                MessageBox.Show("清先查找会员！");
                return;
            }
            cjQuestion cjquest = cjQuestion.CreateForm(cjquestion);
            cjquest.ShowDialog();
            cjquest.Focus();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 6)
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
            int hjje = 0;
            int hjcs = 0;
            int yfje = 0;
            foreach (var iteam in list)
            {
                hjje += Convert.ToInt32(iteam.CountMoney);
                hjcs += Convert.ToInt32(iteam.CiCount);
                yfje += Convert.ToInt32(iteam.YMoney);
            }
            textBox14.Text = hjje.ToString();
            textBox21.Text = hjcs.ToString();
            textBox22.Text = yfje.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
            string sb = "";
            string[] ss = DateTime.Now.ToString("yyyy MM dd HH:mm:ss").Split(new char[] { '/', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in ss)
            {
                sb += s;
            }
            Random rad = new Random();
            sb += rad.Next(1000, 9999);
            List<shInfoList> listjieshu = (List<shInfoList>)dataGridView2.DataSource;
            if (listjieshu==null)
            {
                MessageBox.Show("无数据！");
                return;
            }
            List<LiShiConsumption> listLS = new List<LiShiConsumption>();
            LiShiConsumption model;
            foreach (var iteam in listjieshu)
            {
                model = new LiShiConsumption();
                model.IsJC = iteam.JiCun;
                model.LSName = textBox4.Text.Trim() == "" ? textBox1.Text.Trim() : textBox4.Text.Trim();
                model.LSDate = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");
                model.ImgUrl = iteam.ImgUrl;
                model.LSStaff = iteam.FuWuName;
                model.LSNumberCount = "0";
                model.LSMoney = iteam.CiCount.ToString();
                model.LSYMoney = iteam.YMoney.ToString();
                model.LSCount = iteam.Count.ToString();
                model.LSPinPai = iteam.PinPai;
                model.LSColor = iteam.Color;
                model.LSSalesman = iteam.YMPerson;
                model.LSCardNumber = textBox5.Text.Trim() == "" ? "散客" : textBox5.Text.Trim();
                int panduan=0;
                int.TryParse(iteam.ImgUrl,out panduan);
                if (panduan!=0)
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
                listLS.Add(model);
            }
            //需要减去卡上余额
            bool xiaofeiresult = false;
            if (!radioButton2.Checked)
            {
                int oldmoney = Convert.ToInt32(textBox9.Text.Trim());
                int Xmoney = oldmoney - (Convert.ToInt32(textBox14.Text.Trim()) - Convert.ToInt32(textBox22.Text.Trim()));
                //int Xmoney = oldmoney - Convert.ToInt32(textBox22.Text.Trim());
                int oldccount = Convert.ToInt32(textBox8.Text.Trim());
                int Scount = oldccount - Convert.ToInt32(textBox21.Text.Trim());
                string cardNumber = textBox5.Text.Trim();
                if (Xmoney < 0 || Scount < 0)
                {
                    MessageBox.Show("余额不足！");
                    return;
                }
                //减去消费金额
                if (oldmoney == 0)
                {
                    xiaofeiresult = bll.XFmoney(cardNumber, Scount.ToString());
                    textBox9.Text = Xmoney.ToString();
                }
                else if (oldccount == 0)
                {
                    xiaofeiresult = bll.XFmoney(cardNumber, Xmoney.ToString());
                    textBox8.Text = Scount.ToString();
                }
                if (!xiaofeiresult)
                {
                    MessageBox.Show("消费失败！");
                    return;
                }
                
            }
            
            //将寄存数据添加到寄存数据表中
            bool addjcresult = jcbll.addJCList(jclist, textBox5.Text.Trim(), textBox4.Text.Trim() == "" ? textBox1.Text.Trim() : textBox4.Text.Trim(), dateTimePicker1.Text.ToString(),sb);
            jclist = new List<shInfoList>();
            //将数据添加到消费记录里面
            bool resultls = lsbll.AddList(listLS);
            if (resultls)
            {
                //将刚刚消费的数据添加到消费记录里面
                dataBindgridview1(listLS);
                DYList = listLS;
            }
            string websb = "http://yhc19950315.imwork.net:28948?id=" + sb;
            Bitmap bitmap = writer.Write(websb);
            pictureBoxQr.Image = bitmap;
            PirentDocumentClass.PirentSH(textBox14.Text, textBox21.Text, textBox22.Text, DYList, pictureBoxQr.Image,sb);
            //printDocument1.Print();
            dataGridView2.DataSource=new List<shInfoList>();
            TJBBBuy(listjieshu);
            
        }
        /// <summary>
        /// 点完保存之后才执行
        /// </summary>
        /// <param name="list"></param>
        public void TJBBBuy(List<shInfoList> list)
        {
            List<shInfoList> list1 = new List<shInfoList>();
            foreach (var iteam in list)
            {
                int count = iteam.Count;
                string no = iteam.ImgUrl.Trim();
                if (iteam.FuWuName.Substring(0, 4) == "购买商品")
                {
                    PutHuo model = new PutHuo()
                    {
                        PutCardNo = textBox5.Text.Trim(),
                        PutCount = iteam.Count.ToString(),
                        PutDate = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日",
                        PutDianName = FilterClass.DianPu1.UserName.Trim(),
                        PutMoney = iteam.CountMoney.ToString(),
                        PutName = iteam.FuWuName.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)[1],
                        PutNo = iteam.ImgUrl.Trim(),
                        PutSale = comboBox4.Text.Trim(),
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
            TJBBBLL tjbb = new TJBBBLL();
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
        //打印小票

            
            //int i = 1;
            //Pen blackPen = new Pen(Color.Black, 3);
            ////使用的是57mm的纸，相当于190像素
            //Rectangle[] rects =
            // {
            //     new Rectangle( 30,50,30,50), //参数说明：左边距，上边距，右边距，底边距
            //     new Rectangle(35,55,35,55),
            // };
            ////e.Graphics.DrawRectangles(blackPen, rects);
            //e.Graphics.DrawString("一休皮革收据小票", new Font("Segoe UI", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(8, 30));//其中10为左边距，30为上边距
            //foreach (var iteam in DYList)
            //{
            //    e.Graphics.DrawString(iteam.LSStaff + "--X" + iteam.LSCount + "金额：" + iteam.LSMoney, new Font("Segoe UI",8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(5, 60+i*15));//其中10为左边距，30为上边距
            //    i++;
            //}
            //e.Graphics.DrawString("合计金额：" + textBox14.Text , new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(5, 60 + i * 15));//其中10为左边距，30为上边距
            //i++;
            //e.Graphics.DrawString("合计次数：" + textBox21.Text, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(5, 60 + i * 15));//其中10为左边距，30为上边距
            //i++;
            //e.Graphics.DrawString("应付金额：" + textBox22.Text, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(5, 60 + i * 15));//其中10为左边距，30为上边距
            //e.Graphics.DrawImage(pictureBoxQr.Image, new Rectangle(new System.Drawing.Point(0, i*15+100),new Size(250,250)));


        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.ToString().Trim() == "")
            {
                MessageBox.Show("请先查找会员！");
                return;
            }
            string name = FilterClass.DianPu1.UserName;
            dataGridView1.DataSource = lsbll.selectAllList(textBox5.Text.Trim(), name);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //}
            //dataGridView1.Rows[e.RowIndex].Selected = true;
            if (dataGridView1.Rows.Count > 0)
            {
                pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string cardno = textBox5.Text.Trim();
            //if (cardno == "")
            //{
            //    MessageBox.Show("请先选择会员！");
            //    return;
            //}
            bdpjFrom bdpj = bdpjFrom.Create();
            bdpj.Show();
            bdpj.Focus();
        }


        private void 删除本条ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int spid = 0;
            LiShiConsumption model = (LiShiConsumption)dataGridView1.SelectedRows[0].DataBoundItem;
            IsJC = model.IsJC;
            IsSP = model.IsSP;
            int.TryParse(model.ImgUrl, out spid);
            if (spid != 0)
            {
                spID = spid;
            }
            SPcount = Convert.ToInt32(model.LSCount);
            //将删除的数据当时小飞的金额或者次数提取出来
            if (textBox12.Text.Trim() == "储值卡")
            {
                delecount = Convert.ToInt32(model.LSMoney);
            }
            else if (textBox12.Text.Trim() == "计次卡")
            {
                delecount = Convert.ToInt32(model.LSMoney);
            }
            caocuofrom caozuo = caocuofrom.Create(deletePassword, model.ID.ToString());
            caozuo.Show();
        }
        public void deletePassword(string pas, string cardNo)
        {
            string name = FilterClass.DianPu1.UserName;
            if (pas.Trim() == "admin888")
            {
                LSConsumptionBLL infobll = new LSConsumptionBLL();
                bool result = infobll.deleteID(cardNo);
                dataGridView1.DataSource = lsbll.selectAllList(textBox5.Text.Trim(), name);
                if (result)
                {
                    MessageBox.Show("删除成功！");
                    if (textBox12.Text.Trim() == "储值卡")
                    {
                        string money=(Convert.ToInt32(textBox9.Text.Trim()) + delecount).ToString();
                        bll.XFmoney(textBox5.Text.Trim(), money);  
                        textBox9.Text = money;                     
                    }                                              
                    else if (textBox12.Text.Trim() == "计次卡")    
                    {                                              
                        string count=(Convert.ToInt32(textBox8.Text.Trim()) + delecount).ToString();
                        bll.XFmoney(textBox5.Text.Trim(), count);
                        textBox8.Text = count;
                    }
                    if (IsSP)
                    {
                        //如果是商品就把数量加回来
                        int count = SPcount;
                        int ID = spID;
                        gbbll.DeleteAdd(ID, count);
                    }
                    if (IsJC)
                    {
                        //如果是寄存就把寄存信息删除
                    }
                }
            }
            else
            {
                MessageBox.Show("密码错误，删除失败！");
            }
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
    }
}

