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
            //new FilterInfo(videoDevices[0].MonikerString);
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
                //dataGridView1.Rows[j].ContextMenuStrip = null;
            }
            try
            {
                dataGridView2.Rows[e.RowIndex].Selected = true;
                //id = e.RowIndex;
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
                model.LSName = textBox4.Text.Trim() == "" ? textBox1.Text.Trim() : textBox4.Text.Trim();
                model.LSDate = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");
                model.ImgUrl = iteam.ImgUrl;
                model.LSStaff = iteam.FuWuName;
                model.LSNumberCount = "0";
                model.LSMoney = iteam.CountMoney.ToString();
                model.LSYMoney = iteam.YMoney.ToString();
                model.LSCount = iteam.Count.ToString();
                model.LSPinPai = iteam.PinPai;
                model.LSColor = iteam.Color;
                model.LSSalesman = iteam.YMPerson;
                model.LSCardNumber = textBox5.Text.Trim() == "" ? "散客" : textBox5.Text.Trim();
                //
                //
                //
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
                int Xmoney = oldmoney - Convert.ToInt32(textBox22.Text.Trim());
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
                }
                else if (oldccount == 0)
                {
                    xiaofeiresult = bll.XFmoney(cardNumber, Xmoney.ToString());
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
            GoodInfoBLL gbbll = new GoodInfoBLL();
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
            pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lable = new System.Windows.Forms.Label();
            this.pictureBoxQr = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.shId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shJiCun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shFuWuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shCiCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shOuntMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shYMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shFuKuan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shPaiNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YMPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shPinPai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shImgUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除本条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.cardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kinyaoo123456DataSet1 = new yixiupige.kinyaoo123456DataSet();
            this.lsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsSuperMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSNO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imgurl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQr)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinyaoo123456DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pictureBoxQr);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1820, 676);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1019, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Location = new System.Drawing.Point(560, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 136);
            this.panel3.TabIndex = 17;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(110, 94);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(258, 25);
            this.textBox3.TabIndex = 2;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(287, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "模糊查找";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(59, 71);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(262, 15);
            this.label26.TabIndex = 0;
            this.label26.Text = "请输入姓名，卡号，电话等信息回车！";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(26, 98);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 15);
            this.label27.TabIndex = 0;
            this.label27.Text = "查找内容";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(26, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 15);
            this.label25.TabIndex = 0;
            this.label25.Text = "查找顾客";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(227, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 136);
            this.panel2.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 79);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(168, 25);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "散客电话";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "散客姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "散客信息";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.lable);
            this.panel4.Location = new System.Drawing.Point(7, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 136);
            this.panel4.TabIndex = 19;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(26, 78);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "散客";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "会员";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(51, 12);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(67, 15);
            this.lable.TabIndex = 0;
            this.lable.Text = "顾客类型";
            // 
            // pictureBoxQr
            // 
            this.pictureBoxQr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxQr.Location = new System.Drawing.Point(1475, 581);
            this.pictureBoxQr.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxQr.Name = "pictureBoxQr";
            this.pictureBoxQr.Size = new System.Drawing.Size(341, 92);
            this.pictureBoxQr.TabIndex = 16;
            this.pictureBoxQr.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBox22);
            this.groupBox5.Controls.Add(this.textBox21);
            this.groupBox5.Controls.Add(this.textBox14);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.dateTimePicker1);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(1474, 373);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(343, 200);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "票据";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(106, 162);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(200, 25);
            this.textBox22.TabIndex = 4;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(106, 126);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(200, 25);
            this.textBox21.TabIndex = 4;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(106, 89);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(200, 25);
            this.textBox14.TabIndex = 4;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(19, 169);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 15);
            this.label31.TabIndex = 3;
            this.label31.Text = "应付金额";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(19, 133);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 15);
            this.label30.TabIndex = 3;
            this.label30.Text = "合计次数";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(19, 96);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(67, 15);
            this.label29.TabIndex = 3;
            this.label29.Text = "合计金额";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(19, 59);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 15);
            this.label28.TabIndex = 3;
            this.label28.Text = "取活日期";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(106, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(196, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 30);
            this.button4.TabIndex = 1;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(46, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "补打票据";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(7, 373);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1459, 300);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "收活信息列表";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shId,
            this.TCMoney,
            this.shJiCun,
            this.shFuWuName,
            this.shCiCount,
            this.shOuntMoney,
            this.shYMoney,
            this.shFuKuan,
            this.shCount,
            this.shPaiNumber,
            this.YMPerson,
            this.shQuestion,
            this.shRemark,
            this.shPinPai,
            this.shColor,
            this.shType,
            this.shImgUrl});
            this.dataGridView2.Location = new System.Drawing.Point(0, 25);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView2.Size = new System.Drawing.Size(1451, 267);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dataGridView2_RowContextMenuStripNeeded);
            this.dataGridView2.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView2_RowsAdded);
            this.dataGridView2.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView2_RowsRemoved);
            // 
            // shId
            // 
            this.shId.DataPropertyName = "Id";
            this.shId.HeaderText = "编号";
            this.shId.Name = "shId";
            this.shId.ReadOnly = true;
            this.shId.Width = 70;
            // 
            // TCMoney
            // 
            this.TCMoney.DataPropertyName = "TCMoney";
            this.TCMoney.HeaderText = "TCMoney";
            this.TCMoney.Name = "TCMoney";
            this.TCMoney.ReadOnly = true;
            this.TCMoney.Visible = false;
            // 
            // shJiCun
            // 
            this.shJiCun.DataPropertyName = "JiCun";
            this.shJiCun.HeaderText = "寄存";
            this.shJiCun.Name = "shJiCun";
            this.shJiCun.ReadOnly = true;
            this.shJiCun.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shJiCun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // shFuWuName
            // 
            this.shFuWuName.DataPropertyName = "FuWuName";
            this.shFuWuName.HeaderText = "服务项目";
            this.shFuWuName.Name = "shFuWuName";
            this.shFuWuName.ReadOnly = true;
            this.shFuWuName.Width = 300;
            // 
            // shCiCount
            // 
            this.shCiCount.DataPropertyName = "CiCount";
            this.shCiCount.HeaderText = "次数";
            this.shCiCount.Name = "shCiCount";
            this.shCiCount.ReadOnly = true;
            // 
            // shOuntMoney
            // 
            this.shOuntMoney.DataPropertyName = "CountMoney";
            this.shOuntMoney.HeaderText = "小计";
            this.shOuntMoney.Name = "shOuntMoney";
            this.shOuntMoney.ReadOnly = true;
            this.shOuntMoney.Width = 70;
            // 
            // shYMoney
            // 
            this.shYMoney.DataPropertyName = "YMoney";
            this.shYMoney.HeaderText = "应付";
            this.shYMoney.Name = "shYMoney";
            this.shYMoney.ReadOnly = true;
            this.shYMoney.Width = 70;
            // 
            // shFuKuan
            // 
            this.shFuKuan.DataPropertyName = "FuKuan";
            this.shFuKuan.HeaderText = "付款";
            this.shFuKuan.Name = "shFuKuan";
            this.shFuKuan.ReadOnly = true;
            this.shFuKuan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shFuKuan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.shFuKuan.Width = 70;
            // 
            // shCount
            // 
            this.shCount.DataPropertyName = "Count";
            this.shCount.HeaderText = "数量";
            this.shCount.Name = "shCount";
            this.shCount.ReadOnly = true;
            // 
            // shPaiNumber
            // 
            this.shPaiNumber.DataPropertyName = "PaiNumber";
            this.shPaiNumber.HeaderText = "牌号";
            this.shPaiNumber.Name = "shPaiNumber";
            this.shPaiNumber.ReadOnly = true;
            // 
            // YMPerson
            // 
            this.YMPerson.DataPropertyName = "YMPerson";
            this.YMPerson.HeaderText = "业务员";
            this.YMPerson.Name = "YMPerson";
            this.YMPerson.ReadOnly = true;
            // 
            // shQuestion
            // 
            this.shQuestion.DataPropertyName = "CJQuestion";
            this.shQuestion.HeaderText = "常见问题";
            this.shQuestion.Name = "shQuestion";
            this.shQuestion.ReadOnly = true;
            this.shQuestion.Width = 300;
            // 
            // shRemark
            // 
            this.shRemark.DataPropertyName = "Remark";
            this.shRemark.HeaderText = "备注信息";
            this.shRemark.Name = "shRemark";
            this.shRemark.ReadOnly = true;
            // 
            // shPinPai
            // 
            this.shPinPai.DataPropertyName = "PinPai";
            this.shPinPai.HeaderText = "品牌";
            this.shPinPai.Name = "shPinPai";
            this.shPinPai.ReadOnly = true;
            // 
            // shColor
            // 
            this.shColor.DataPropertyName = "Color";
            this.shColor.HeaderText = "颜色";
            this.shColor.Name = "shColor";
            this.shColor.ReadOnly = true;
            this.shColor.Width = 70;
            // 
            // shType
            // 
            this.shType.DataPropertyName = "Type";
            this.shType.HeaderText = "类别";
            this.shType.Name = "shType";
            this.shType.ReadOnly = true;
            // 
            // shImgUrl
            // 
            this.shImgUrl.DataPropertyName = "ImgUrl";
            this.shImgUrl.HeaderText = "图片路径";
            this.shImgUrl.Name = "shImgUrl";
            this.shImgUrl.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除本条ToolStripMenuItem,
            this.删除全部ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 56);
            // 
            // 删除本条ToolStripMenuItem
            // 
            this.删除本条ToolStripMenuItem.Name = "删除本条ToolStripMenuItem";
            this.删除本条ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.删除本条ToolStripMenuItem.Text = "删除本条";
            this.删除本条ToolStripMenuItem.Click += new System.EventHandler(this.删除本条ToolStripMenuItem_Click);
            // 
            // 删除全部ToolStripMenuItem
            // 
            this.删除全部ToolStripMenuItem.Name = "删除全部ToolStripMenuItem";
            this.删除全部ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.删除全部ToolStripMenuItem.Text = "删除全部";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.textBox20);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.textBox19);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.textBox16);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Controls.Add(this.textBox17);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.textBox15);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.comboBox4);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(1291, 165);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(523, 199);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "收活信息";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(55, 48);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(114, 25);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(340, 129);
            this.textBox20.Margin = new System.Windows.Forms.Padding(4);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(173, 25);
            this.textBox20.TabIndex = 8;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(267, 135);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 15);
            this.label24.TabIndex = 7;
            this.label24.Text = "备注信息";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(84, 131);
            this.textBox19.Margin = new System.Windows.Forms.Padding(4);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(177, 25);
            this.textBox19.TabIndex = 8;
            this.textBox19.Click += new System.EventHandler(this.textBox19_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(5, 136);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 15);
            this.label23.TabIndex = 7;
            this.label23.Text = "常见问题";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(84, 84);
            this.textBox13.Margin = new System.Windows.Forms.Padding(4);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox13.Size = new System.Drawing.Size(309, 20);
            this.textBox13.TabIndex = 6;
            this.textBox13.Click += new System.EventHandler(this.textBox13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 89);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "基本服务";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(84, 108);
            this.textBox16.Margin = new System.Windows.Forms.Padding(4);
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox16.Size = new System.Drawing.Size(309, 20);
            this.textBox16.TabIndex = 6;
            this.textBox16.Click += new System.EventHandler(this.textBox16_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 113);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 15);
            this.label20.TabIndex = 5;
            this.label20.Text = "其他服务";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 15);
            this.label17.TabIndex = 3;
            this.label17.Text = "数 量";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(444, 104);
            this.textBox18.Margin = new System.Windows.Forms.Padding(4);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(69, 25);
            this.textBox18.TabIndex = 4;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(444, 78);
            this.textBox17.Margin = new System.Windows.Forms.Padding(4);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(69, 25);
            this.textBox17.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(407, 108);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 15);
            this.label22.TabIndex = 3;
            this.label22.Text = "应付";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(401, 50);
            this.textBox15.Margin = new System.Windows.Forms.Padding(4);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(114, 25);
            this.textBox15.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(407, 82);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 15);
            this.label21.TabIndex = 3;
            this.label21.Text = "金额";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(356, 54);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 3;
            this.label19.Text = "牌号";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(401, 19);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(112, 23);
            this.comboBox3.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(356, 22);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "颜色";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(229, 19);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(105, 23);
            this.comboBox2.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(184, 21);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "品牌";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(229, 50);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(108, 23);
            this.comboBox4.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(184, 54);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 1;
            this.label18.Text = "员工";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(55, 18);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 21);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "类别";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(69, 162);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 0;
            this.button2.Text = "购买商品";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 162);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(1291, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(523, 154);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会员信息";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(428, 110);
            this.textBox12.Margin = new System.Windows.Forms.Padding(4);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(85, 25);
            this.textBox12.TabIndex = 1;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(252, 111);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(85, 25);
            this.textBox9.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(84, 110);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(85, 25);
            this.textBox6.TabIndex = 1;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(428, 71);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(85, 25);
            this.textBox11.TabIndex = 1;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(252, 72);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(85, 25);
            this.textBox8.TabIndex = 1;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(428, 32);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(85, 25);
            this.textBox10.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(84, 71);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(85, 25);
            this.textBox5.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(352, 38);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "会员类别";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(252, 34);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(85, 25);
            this.textBox7.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(176, 39);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "商品折扣";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 115);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "卡类型";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(84, 32);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(85, 25);
            this.textBox4.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "剩余金额";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "办卡日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "会员姓名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "剩余次数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "会员电话";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "会员卡号";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(1019, 146);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(264, 222);
            this.tabControl2.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.videoSourcePlayer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(256, 193);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "视频预览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.Location = new System.Drawing.Point(9, 9);
            this.videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(236, 173);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.dataGridView3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 146);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1012, 244);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "历史消费记录";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(119, -2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 29);
            this.button5.TabIndex = 2;
            this.button5.Text = "更多";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardNo,
            this.name,
            this.tel});
            this.dataGridView3.Location = new System.Drawing.Point(444, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 27;
            this.dataGridView3.Size = new System.Drawing.Size(560, 150);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // cardNo
            // 
            this.cardNo.DataPropertyName = "CardNo";
            this.cardNo.HeaderText = "卡号";
            this.cardNo.Name = "cardNo";
            this.cardNo.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // tel
            // 
            this.tel.DataPropertyName = "Tel";
            this.tel.HeaderText = "电话";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lsName,
            this.lsTime,
            this.lsDemo,
            this.lsCount,
            this.lsMoney,
            this.lsPay,
            this.lsNumber,
            this.lsType,
            this.lsColor,
            this.lsQuestion,
            this.lsMark,
            this.lsPerson,
            this.lsSuperMark,
            this.lsNo,
            this.LSNO1,
            this.lsCardNo,
            this.Imgurl});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(4, 34);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(992, 184);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // kinyaoo123456DataSet1
            // 
            this.kinyaoo123456DataSet1.DataSetName = "kinyaoo123456DataSet";
            this.kinyaoo123456DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lsName
            // 
            this.lsName.DataPropertyName = "LSName";
            this.lsName.HeaderText = "姓名";
            this.lsName.Name = "lsName";
            this.lsName.ReadOnly = true;
            // 
            // lsTime
            // 
            this.lsTime.DataPropertyName = "LSDate";
            this.lsTime.HeaderText = "时间";
            this.lsTime.Name = "lsTime";
            this.lsTime.ReadOnly = true;
            // 
            // lsDemo
            // 
            this.lsDemo.DataPropertyName = "LSStaff";
            this.lsDemo.HeaderText = "服务项目";
            this.lsDemo.Name = "lsDemo";
            this.lsDemo.ReadOnly = true;
            // 
            // lsCount
            // 
            this.lsCount.DataPropertyName = "LSNumberCount";
            this.lsCount.HeaderText = "点数";
            this.lsCount.Name = "lsCount";
            this.lsCount.ReadOnly = true;
            // 
            // lsMoney
            // 
            this.lsMoney.DataPropertyName = "LSMoney";
            this.lsMoney.HeaderText = "金额";
            this.lsMoney.Name = "lsMoney";
            this.lsMoney.ReadOnly = true;
            // 
            // lsPay
            // 
            this.lsPay.DataPropertyName = "LSYMoney";
            this.lsPay.HeaderText = "应付";
            this.lsPay.Name = "lsPay";
            this.lsPay.ReadOnly = true;
            // 
            // lsNumber
            // 
            this.lsNumber.DataPropertyName = "LSCount";
            this.lsNumber.HeaderText = "数量";
            this.lsNumber.Name = "lsNumber";
            this.lsNumber.ReadOnly = true;
            // 
            // lsType
            // 
            this.lsType.DataPropertyName = "LSPinPai";
            this.lsType.HeaderText = "品牌";
            this.lsType.Name = "lsType";
            this.lsType.ReadOnly = true;
            // 
            // lsColor
            // 
            this.lsColor.DataPropertyName = "LSColor";
            this.lsColor.HeaderText = "颜色";
            this.lsColor.Name = "lsColor";
            this.lsColor.ReadOnly = true;
            // 
            // lsQuestion
            // 
            this.lsQuestion.DataPropertyName = "LSQuestion";
            this.lsQuestion.HeaderText = "问题";
            this.lsQuestion.Name = "lsQuestion";
            this.lsQuestion.ReadOnly = true;
            // 
            // lsMark
            // 
            this.lsMark.DataPropertyName = "LSRemark";
            this.lsMark.HeaderText = "备注";
            this.lsMark.Name = "lsMark";
            this.lsMark.ReadOnly = true;
            // 
            // lsPerson
            // 
            this.lsPerson.DataPropertyName = "LSSalesman";
            this.lsPerson.HeaderText = "业务员";
            this.lsPerson.Name = "lsPerson";
            this.lsPerson.ReadOnly = true;
            // 
            // lsSuperMark
            // 
            this.lsSuperMark.DataPropertyName = "LSMultipleName";
            this.lsSuperMark.HeaderText = "连锁店";
            this.lsSuperMark.Name = "lsSuperMark";
            this.lsSuperMark.ReadOnly = true;
            // 
            // lsNo
            // 
            this.lsNo.DataPropertyName = "LSDanNumber";
            this.lsNo.HeaderText = "单号";
            this.lsNo.Name = "lsNo";
            this.lsNo.ReadOnly = true;
            // 
            // LSNO1
            // 
            this.LSNO1.DataPropertyName = "LSNo";
            this.LSNO1.HeaderText = "编号";
            this.LSNO1.Name = "LSNO1";
            this.LSNO1.ReadOnly = true;
            this.LSNO1.Visible = false;
            // 
            // lsCardNo
            // 
            this.lsCardNo.DataPropertyName = "LSCardNumber";
            this.lsCardNo.HeaderText = "卡号";
            this.lsCardNo.Name = "lsCardNo";
            this.lsCardNo.ReadOnly = true;
            // 
            // Imgurl
            // 
            this.Imgurl.DataPropertyName = "ImgUrl";
            this.Imgurl.HeaderText = "图片路径";
            this.Imgurl.Name = "Imgurl";
            this.Imgurl.ReadOnly = true;
            // 
            // shglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1845, 701);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1861, 738);
            this.Name = "shglform";
            this.Text = "收活管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shglform_FormClosing);
            this.Load += new System.EventHandler(this.shglform_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQr)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinyaoo123456DataSet1)).EndInit();
            this.ResumeLayout(false);

        }
        #region
        //        private DataTable m_Code128 = new DataTable();

        //        private uint m_Height = 40;

        //        /// <summary>
        //        /// 高度
        //        /// </summary>
        //        public uint Height { get { return m_Height; } set { m_Height = value; } }

        //        private Font m_ValueFont = null;
        //        /// <summary>
        //        /// 是否显示可见号码  若是为NULL不显示号码
        //        /// </summary>
        //        public Font ValueFont { get { return m_ValueFont; } set { m_ValueFont = value; } }
        //        private byte m_Magnify = 0;
        //        /// <summary>
        //        /// 放大倍数
        //        /// </summary>
        //        public byte Magnify { get { return m_Magnify; } set { m_Magnify = value; } }
        //        /// <summary>
        //        /// 条码类别
        //        /// </summary>
        //        public enum Encode
        //        {

        //            Code128A,

        //            Code128B,

        //            Code128C,

        //            EAN128

        //        }

        //        public void Code128()
        //        {

        //            m_Code128.Columns.Add("ID");

        //            m_Code128.Columns.Add("Code128A");

        //            m_Code128.Columns.Add("Code128B");

        //            m_Code128.Columns.Add("Code128C");

        //            m_Code128.Columns.Add("BandCode");

        //            m_Code128.CaseSensitive = true;

        //            #region 数据表

        //            m_Code128.Rows.Add("0", " ", " ", "00", "212222");

        //            m_Code128.Rows.Add("1", "!", "!", "01", "222122");

        //            m_Code128.Rows.Add("2", "\"", "\"", "02", "222221");

        //            m_Code128.Rows.Add("3", "＃", "＃", "03", "121223");

        //            m_Code128.Rows.Add("4", "￥", "￥", "04", "121322");

        //            m_Code128.Rows.Add("5", "％", "％", "05", "131222");

        //            m_Code128.Rows.Add("6", "&", "&", "06", "122213");

        //            m_Code128.Rows.Add("7", "\"", "\"", "07", "122312");

        //            m_Code128.Rows.Add("8", "(", "(", "08", "132212");

        //            m_Code128.Rows.Add("9", ")", ")", "09", "221213");

        //            m_Code128.Rows.Add("10", "*", "*", "10", "221312");

        //            m_Code128.Rows.Add("11", "+", "+", "11", "231212");

        //            m_Code128.Rows.Add("12", ",", ",", "12", "112232");

        //            m_Code128.Rows.Add("13", "-", "-", "13", "122132");

        //            m_Code128.Rows.Add("14", ".", ".", "14", "122231");

        //            m_Code128.Rows.Add("15", "/", "/", "15", "113222");

        //            m_Code128.Rows.Add("16", "0", "0", "16", "123122");

        //            m_Code128.Rows.Add("17", "1", "1", "17", "123221");

        //            m_Code128.Rows.Add("18", "2", "2", "18", "223211");

        //            m_Code128.Rows.Add("19", "3", "3", "19", "221132");

        //            m_Code128.Rows.Add("20", "4", "4", "20", "221231");

        //            m_Code128.Rows.Add("21", "5", "5", "21", "213212");

        //            m_Code128.Rows.Add("22", "6", "6", "22", "223112");

        //            m_Code128.Rows.Add("23", "7", "7", "23", "312131");

        //            m_Code128.Rows.Add("24", "8", "8", "24", "311222");

        //            m_Code128.Rows.Add("25", "9", "9", "25", "321122");

        //            m_Code128.Rows.Add("26", ":", ":", "26", "321221");

        //            m_Code128.Rows.Add("27", ";", ";", "27", "312212");

        //            m_Code128.Rows.Add("28", "<", "<", "28", "322112");

        //            m_Code128.Rows.Add("29", "=", "=", "29", "322211");

        //            m_Code128.Rows.Add("30", ">", ">", "30", "212123");

        //            m_Code128.Rows.Add("31", "？", "？", "31", "212321");

        //            m_Code128.Rows.Add("32", "＠", "＠", "32", "232121");

        //            m_Code128.Rows.Add("33", "A", "A", "33", "111323");

        //            m_Code128.Rows.Add("34", "B", "B", "34", "131123");

        //            m_Code128.Rows.Add("35", "C", "C", "35", "131321");

        //            m_Code128.Rows.Add("36", "D", "D", "36", "112313");

        //            m_Code128.Rows.Add("37", "E", "E", "37", "132113");

        //            m_Code128.Rows.Add("38", "F", "F", "38", "132311");

        //            m_Code128.Rows.Add("39", "G", "G", "39", "211313");

        //            m_Code128.Rows.Add("40", "H", "H", "40", "231113");

        //            m_Code128.Rows.Add("41", "I", "I", "41", "231311");

        //            m_Code128.Rows.Add("42", "J", "J", "42", "112133");

        //            m_Code128.Rows.Add("43", "K", "K", "43", "112331");

        //            m_Code128.Rows.Add("44", "L", "L", "44", "132131");

        //            m_Code128.Rows.Add("45", "M", "M", "45", "113123");

        //            m_Code128.Rows.Add("46", "N", "N", "46", "113321");

        //            m_Code128.Rows.Add("47", "O", "O", "47", "133121");

        //            m_Code128.Rows.Add("48", "P", "P", "48", "313121");

        //            m_Code128.Rows.Add("49", "Q", "Q", "49", "211331");

        //            m_Code128.Rows.Add("50", "R", "R", "50", "231131");

        //            m_Code128.Rows.Add("51", "S", "S", "51", "213113");

        //            m_Code128.Rows.Add("52", "T", "T", "52", "213311");

        //            m_Code128.Rows.Add("53", "U", "U", "53", "213131");

        //            m_Code128.Rows.Add("54", "V", "V", "54", "311123");

        //            m_Code128.Rows.Add("55", "W", "W", "55", "311321");

        //            m_Code128.Rows.Add("56", "X", "X", "56", "331121");

        //            m_Code128.Rows.Add("57", "Y", "Y", "57", "312113");

        //            m_Code128.Rows.Add("58", "Z", "Z", "58", "312311");

        //            m_Code128.Rows.Add("59", "[", "[", "59", "332111");

        //            m_Code128.Rows.Add("60", "\\", "\\", "60", "314111");

        //            m_Code128.Rows.Add("61", "]", "]", "61", "221411");

        //            m_Code128.Rows.Add("62", "^", "^", "62", "431111");

        //            m_Code128.Rows.Add("63", "_", "_", "63", "111224");

        //            m_Code128.Rows.Add("64", "NUL", "`", "64", "111422");

        //            m_Code128.Rows.Add("65", "SOH", "a", "65", "121124");

        //            m_Code128.Rows.Add("66", "STX", "b", "66", "121421");

        //            m_Code128.Rows.Add("67", "ETX", "c", "67", "141122");

        //            m_Code128.Rows.Add("68", "EOT", "d", "68", "141221");

        //            m_Code128.Rows.Add("69", "ENQ", "e", "69", "112214");

        //            m_Code128.Rows.Add("70", "ACK", "f", "70", "112412");

        //            m_Code128.Rows.Add("71", "BEL", "g", "71", "122114");

        //            m_Code128.Rows.Add("72", "BS", "h", "72", "122411");

        //            m_Code128.Rows.Add("73", "HT", "i", "73", "142112");

        //            m_Code128.Rows.Add("74", "LF", "j", "74", "142211");

        //            m_Code128.Rows.Add("75", "VT", "k", "75", "241211");

        //            m_Code128.Rows.Add("76", "FF", "I", "76", "221114");

        //            m_Code128.Rows.Add("77", "CR", "m", "77", "413111");

        //            m_Code128.Rows.Add("78", "SO", "n", "78", "241112");

        //            m_Code128.Rows.Add("79", "SI", "o", "79", "134111");

        //            m_Code128.Rows.Add("80", "DLE", "p", "80", "111242");

        //            m_Code128.Rows.Add("81", "DC1", "q", "81", "121142");

        //            m_Code128.Rows.Add("82", "DC2", "r", "82", "121241");

        //            m_Code128.Rows.Add("83", "DC3", "s", "83", "114212");

        //            m_Code128.Rows.Add("84", "DC4", "t", "84", "124112");

        //            m_Code128.Rows.Add("85", "NAK", "u", "85", "124211");

        //            m_Code128.Rows.Add("86", "SYN", "v", "86", "411212");

        //            m_Code128.Rows.Add("87", "ETB", "w", "87", "421112");

        //            m_Code128.Rows.Add("88", "CAN", "x", "88", "421211");

        //            m_Code128.Rows.Add("89", "EM", "y", "89", "212141");

        //            m_Code128.Rows.Add("90", "SUB", "z", "90", "214121");

        //            m_Code128.Rows.Add("91", "ESC", "{", "91", "412121");

        //            m_Code128.Rows.Add("92", "FS", "|", "92", "111143");

        //            m_Code128.Rows.Add("93", "GS", "}", "93", "111341");

        //            m_Code128.Rows.Add("94", "RS", "~", "94", "131141");

        //            m_Code128.Rows.Add("95", "US", "DEL", "95", "114113");

        //            m_Code128.Rows.Add("96", "FNC3", "FNC3", "96", "114311");

        //            m_Code128.Rows.Add("97", "FNC2", "FNC2", "97", "411113");

        //            m_Code128.Rows.Add("98", "SHIFT", "SHIFT", "98", "411311");

        //            m_Code128.Rows.Add("99", "CODEC", "CODEC", "99", "113141");

        //            m_Code128.Rows.Add("100", "CODEB", "FNC4", "CODEB", "114131");

        //            m_Code128.Rows.Add("101", "FNC4", "CODEA", "CODEA", "311141");

        //            m_Code128.Rows.Add("102", "FNC1", "FNC1", "FNC1", "411131");

        //            m_Code128.Rows.Add("103", "StartA", "StartA", "StartA", "211412");

        //            m_Code128.Rows.Add("104", "StartB", "StartB", "StartB", "211214");

        //            m_Code128.Rows.Add("105", "StartC", "StartC", "StartC", "211232");

        //            m_Code128.Rows.Add("106", "Stop", "Stop", "Stop", "2331112");

        //            #endregion

        //        }

        //        /// <summary>
        //        /// 获取128图形
        //        /// </summary>
        //        /// <param name="p_Text">文字</param>
        //        /// <param name="p_Code">编码</param>      
        //        /// <returns>图形</returns>
        //        public Bitmap GetCodeImage(string p_Text, Encode p_Code)
        //        {

        //            string _ViewText = p_Text;

        //            string _Text = "";

        //            IList<int> _TextNumb = new List<int>();

        //            int _Examine = 0;  //首位

        //            switch (p_Code)
        //            {

        //                case Encode.Code128C:

        //                    _Examine = 105;

        //                    if (!((p_Text.Length & 1) == 0)) throw new Exception("128C长度必须是偶数");

        //                    while (p_Text.Length != 0)
        //                    {

        //                        int _Temp = 0;

        //                        try
        //                        {

        //                            int _CodeNumb128 = Int32.Parse(p_Text.Substring(0, 2));

        //                        }

        //                        catch
        //                        {

        //                            throw new Exception("128C必须是数字！");

        //                        }

        //                        _Text += GetValue(p_Code, p_Text.Substring(0, 2), ref _Temp);

        //                        _TextNumb.Add(_Temp);

        //                        p_Text = p_Text.Remove(0, 2);

        //                    }

        //                    break;

        //                case Encode.EAN128:

        //                    _Examine = 105;

        //                    if (!((p_Text.Length & 1) == 0)) throw new Exception("EAN128长度必须是偶数");

        //                    _TextNumb.Add(102);

        //                    _Text += "411131";

        //                    while (p_Text.Length != 0)
        //                    {

        //                        int _Temp = 0;

        //                        try
        //                        {

        //                            int _CodeNumb128 = Int32.Parse(p_Text.Substring(0, 2));

        //                        }

        //                        catch
        //                        {

        //                            throw new Exception("128C必须是数字！");

        //                        }

        //                        _Text += GetValue(Encode.Code128C, p_Text.Substring(0, 2), ref _Temp);

        //                        _TextNumb.Add(_Temp);

        //                        p_Text = p_Text.Remove(0, 2);

        //                    }
        //                    break;
        //                default:
        //                    if (p_Code == Encode.Code128A)
        //                    {
        //                        _Examine = 103;
        //                    }
        //                    else
        //                    {
        //                        _Examine = 104;
        //                    }

        //                    while (p_Text.Length != 0)
        //                    {

        //                        int _Temp = 0;

        //                        string _ValueCode = GetValue(p_Code, p_Text.Substring(0, 1), ref _Temp);

        //                        if (_ValueCode.Length == 0) throw new Exception("无效的字符集!" + p_Text.Substring(0, 1).ToString());

        //                        _Text += _ValueCode;

        //                        _TextNumb.Add(_Temp);

        //                        p_Text = p_Text.Remove(0, 1);

        //                    }
        //                    break;

        //            }

        //            if (_TextNumb.Count == 0) throw new Exception("错误的编码,无数据");

        //            _Text = _Text.Insert(0, GetValue(_Examine)); //获取开端位

        //            for (int i = 0; i != _TextNumb.Count; i++)
        //            {

        //                _Examine += _TextNumb[i] * (i + 1);

        //            }

        //            _Examine = _Examine % 103;           //获得严效位

        //            _Text += GetValue(_Examine);  //获取严效位

        //            _Text += "2331112"; //停止位

        //            Bitmap _CodeImage = GetImage(_Text);

        //            GetViewText(_CodeImage, _ViewText);

        //            return _CodeImage;

        //        }

        //        /// <summary>
        //        /// 获取目标对应的数据
        //        /// </summary>
        //        /// <param name="p_Code">编码</param>
        //        /// <param name="p_Value">数值 A b  30</param>
        //        /// <param name="p_SetID">返回编号</param>
        //        /// <returns>编码</returns>
        //        private string GetValue(Encode p_Code, string p_Value, ref int p_SetID)
        //        {

        //            if (m_Code128 == null) return "";

        //            DataRow[] _Row = m_Code128.Select(p_Code.ToString() + "=\"" + p_Value + "\"");

        //            if (_Row.Length != 1) throw new Exception("错误的编码" + p_Value.ToString());

        //            p_SetID = Int32.Parse(_Row[0]["ID"].ToString());

        //            return _Row[0]["BandCode"].ToString();

        //        }

        //        /// <summary>
        //        /// 按照编号获得条纹
        //        /// </summary>
        //        /// <param name="p_CodeId"></param>
        //        /// <returns></returns>
        //        private string GetValue(int p_CodeId)
        //        {

        //            DataRow[] _Row = m_Code128.Select("ID=\"" + p_CodeId.ToString() + "\"");

        //            if (_Row.Length != 1) throw new Exception("验效位的编码错误" + p_CodeId.ToString());

        //            return _Row[0]["BandCode"].ToString();

        //        }
        //        /// <summary>
        //        /// 获得条码图形
        //        /// </summary>
        //        /// <param name="p_Text">文字</param>
        //        /// <returns>图形</returns>
        //        private Bitmap GetImage(string p_Text)
        //        {
        //            char[] _Value = p_Text.ToCharArray();
        //            int _Width = 0;
        //            for (int i = 0; i != _Value.Length; i++)
        //            {
        //                _Width += Int32.Parse(_Value.ToString()) * (m_Magnify + 1);
        //            }
        //            Bitmap _CodeImage = new Bitmap(_Width, (int)m_Height);
        //            Graphics _Garphics = Graphics.FromImage(_CodeImage);
        //            //Pen _Pen;
        //            int _LenEx = 0;
        //            for (int i = 0; i != _Value.Length; i++)
        //            {
        //                int _ValueNumb = Int32.Parse(_Value.ToString()) * (m_Magnify + 1);  //获取宽和放大系数
        //                if (!((i & 1) == 0))
        //                {
        //                    //_Pen = new Pen(Brushes.White, _ValueNumb);
        //                    _Garphics.FillRectangle(Brushes.White, new Rectangle(_LenEx, 0, _ValueNumb, (int)m_Height));
        //                }
        //                else
        //                {
        //                    //_Pen = new Pen(Brushes.Black, _ValueNumb);
        //                    _Garphics.FillRectangle(Brushes.Black, new Rectangle(_LenEx, 0, _ValueNumb, (int)m_Height));
        //                }
        //                //_Garphics.(_Pen, new Point(_LenEx, 0), new Point(_LenEx, m_Height));
        //                _LenEx += _ValueNumb;
        //            }
        //            _Garphics.Dispose();
        //            return _CodeImage;
        //        }

        //        /// <summary>
        //        /// 显示可见条码文字 若是小于40 不显示文字
        //        /// </summary>
        //        /// <param name="p_Bitmap">图形</param>           
        //        private void GetViewText(Bitmap p_Bitmap, string p_ViewText)
        //        {
        //            if (m_ValueFont == null) return;

        //            Graphics _Graphics = Graphics.FromImage(p_Bitmap);

        //            SizeF _DrawSize = _Graphics.MeasureString(p_ViewText, m_ValueFont);

        //            if (_DrawSize.Height > p_Bitmap.Height - 10 || _DrawSize.Width > p_Bitmap.Width)
        //            {
        //                _Graphics.Dispose();
        //                return;
        //            }
        //            int _StarY = p_Bitmap.Height - (int)_DrawSize.Height;
        //            _Graphics.FillRectangle(Brushes.White, new Rectangle(0, _StarY, p_Bitmap.Width, (int)_DrawSize.Height));
        //            _Graphics.DrawString(p_ViewText, m_ValueFont, Brushes.Black, 0, _StarY);
        //        }

        //        //12345678

        //        //(105 + (1 * 12 + 2 * 34 + 3 * 56 + 4 *78)) ％ 103 = 47

        //        //成果为starc +12 +34 +56 +78 +47 +end

        //        internal System.Drawing.Image GetCodeImage(string p)
        //        {
        //            throw new NotImplementedException();
        //        }

        //    }
        #endregion//条形码，测试1
    }
}


//Code128 _Code = new Code128（）;
//        _Code.ValueFont = new Font（"宋体"， 20）;
//        System.Drawing.Bitmap imgTemp = _Code.GetCodeImage（"T26200-1900-123-1-0900"，Code128.Encode.Code128A）;
//        imgTemp.Save（System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCode.gif"， System.Drawing.Imaging.ImageFormat.Gif）;[/code]

