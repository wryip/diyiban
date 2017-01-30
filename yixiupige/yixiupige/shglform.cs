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
//[code=csharp]using System;
namespace yixiupige
{
    public partial class shglform : Form
    {
        EncodingOptions options = null;
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
            options = new EncodingOptions
            {
                //DisableECI = true,  
                //CharacterSet = "UTF-8",  
                Width = pictureBoxQr.Width,
                Height = pictureBoxQr.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.ITF;//改变条形码
            writer.Options = options;  
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
            string sb = "";
            string[] ss = DateTime.Now.ToString("yyyy MM dd HH:mm:ss").Split(new char[] { '/', ':',' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in ss)
            {
                sb += s;
            }
            Bitmap bitmap = writer.Write(sb);
            pictureBoxQr.Image = bitmap;
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
            string type = textBox10.Text.Trim();
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

        private void textBox16_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" && radioButton2.Checked == false)
            {
                MessageBox.Show("清先查找会员！");
                return;
            }
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

