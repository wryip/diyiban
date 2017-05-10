using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Commond
{
    public static class PirentDocumentClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hije">合计金额</param>
        /// <param name="hjch">合计次数</param>
        /// <param name="yfje">应付金额</param>
        /// <param name="list"></param>
        /// <param name="ibmap"></param>
        public static string wulizt { get; set; }
        public static string _hije { get; set; }
        public static string _hjch { get; set; }
        public static string _yfje { get; set; }
        public static string _sb { get; set; }
        public static List<shInfoList> _list { get; set; }
        public static List<JCInfoModel> _listwl { get; set; }
        public static Image _ibmap { get; set; }
        public static string _name { get; set; }
        public static string _time { get; set; }
        public static string _gksy { get; set; }
        public static int _beginy { get; set; }
        public static double _QKMoney { get; set; }
        public static string _cardnumber { get; set; }
        public static memberToUpModel toupmoney { get; set; }
        /// <summary>
        /// 给顾卡打印收费小票
        /// </summary>
        /// <param name="hije"></param>
        /// <param name="hjch"></param>
        /// <param name="yfje"></param>
        /// <param name="list"></param>
        /// <param name="ibmap"></param>
        /// <param name="sb"></param>
        /// <param name="name"></param>
        /// <param name="cardnumber"></param>
        /// <param name="time"></param>
        public static void PirentSH(string hije, string hjch, string yfje, List<shInfoList> list, Image ibmap, string sb, string name, string cardnumber, string time, string gksy)
        {
            _beginy = 0;
            _gksy = gksy;
            _time = time;
            _name = name;
            _cardnumber = cardnumber;
            _hije = hije;
            _hjch = hjch;
            _yfje = yfje;
            _sb = sb;
            _list = list;
            _ibmap = ibmap;
            //打印预览
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(20, 20, 20, 20);
            pd.PrinterSettings.PrinterName = FilterClass.MemberXF;
            pd.DefaultPageSettings.Margins = margin;
            //默认纸张
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 5000);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppd.Document = pd;
            ppd.ShowDialog();
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
            }
        }
        public static void SendWuLiu(List<JCInfoModel> list,string str)
        {
            wulizt = str;
            //打印预览
            _listwl = list;
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(20, 20, 20, 20);
            pd.PrinterSettings.PrinterName = FilterClass.MemberXF;
            pd.DefaultPageSettings.Margins = margin;
            //默认纸张
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 5000);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPagewl);
            ppd.Document = pd;
            ppd.ShowDialog();
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
            }
        }
        /// <summary>
        /// 打印物流送洗的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void pd_PrintPagewl(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(0, 0), new Size(200,100)));
            //return;
            #region //重写
            int jccount = 0;
            int i = 1;
            int j = 1;
            string dpname=FilterClass.DianPu1.UserName;
            StringBuilder sb = new StringBuilder();
            string tou = "物流配送小票";
            sb.Append("            " + tou + "       \r\n");
            sb.Append("---------------------------------------------\r\n");
            sb.Append("日期:" + DateTime.Now.ToShortDateString() + " \r\n" + "说明:" + wulizt + "\r\n");
            sb.Append("店铺:" + dpname + "\r\n");
            sb.Append("_____________________________________________\r\n");
            e.Graphics.DrawString("号", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 100));
            e.Graphics.DrawString("内容", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(65, 100));
            e.Graphics.DrawString("数量", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, 100));
            e.Graphics.DrawString("确认", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, 100));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115), new Point(185, 115));
            foreach (var iteam in _listwl)
            {
                jccount++;
                string nleng = iteam.jcStaff;
                e.Graphics.DrawString(j.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
                e.Graphics.DrawString("1", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, (100 + i * 15)));
                e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, (100 + i * 15)));
                if (nleng.Length < 9)
                {
                    e.Graphics.DrawString(nleng, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));
                    e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115 + i * 15), new Point(185, 115 + i * 15));
                    i++;
                    j++;
                    continue;
                }
                while (nleng.Length > 9)
                {
                    e.Graphics.DrawString(nleng.Substring(0, 9), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));
                    nleng = nleng.Substring(9, nleng.Length - 9);
                    i++;
                }
                e.Graphics.DrawString(nleng, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115 + i * 15), new Point(185, 115 + i * 15));
                i++;
                j++;
            }
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 100), new Point(0, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(20, 100), new Point(20, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(125, 100), new Point(125, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(155, 100), new Point(155, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(185, 100), new Point(185, (100 + i * 15)));
            e.Graphics.DrawString("数量:" + _listwl.Count , new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            //e.Graphics.DrawString("应付金额:" + _yfje, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            //i++;
            //e.Graphics.DrawString("寄存件数:" + jccount, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            //i++;
            //e.Graphics.DrawString("取活日期:" + _time, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            //i++;
            //while (jiewei.Length > 16)
            //{
                e.Graphics.DrawString("物流签字：", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            //    jiewei = jiewei.Substring(16, jiewei.Length - 16);
                i++;
            //}
                e.Graphics.DrawString("店主签字：", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            //i++;
            e.Graphics.DrawString(sb.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(0, 0));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            ////e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(-100, 200), new Size(400,400)));
            //e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(0, (100 + i * 15)), new Size(250, 250)));
            #endregion

        }
        /// <summary>
        /// 测试用
        /// </summary>
        /// <param name="bitma"></param>
        
        /// <summary>
        /// 打印顾客小票用的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(0, 0), new Size(200, 100)));
            //return;
#region //重写
            string DPTel = FilterClass.DPTel;
            string jiewei = FilterClass.DXInfo;
            int jccount = 0;
            int i = 1;
            int j = 0;
            StringBuilder sb = new StringBuilder();
            string tou = "青岛一休皮革小票";
            sb.Append("            " + tou + "       \r\n");
            sb.Append("---------------------------------------------\r\n");
            sb.Append("日期:" + DateTime.Now.ToShortDateString() + " \r\n" + "单号:" + _sb + "\r\n");
            sb.Append("姓名:" + (_name == "" ? "散客" : _name) + "   " + _gksy + "  \r\n" + "卡号:" + (_cardnumber == "" ? "无卡" : _cardnumber) + "\r\n");
            sb.Append("_____________________________________________\r\n");
            e.Graphics.DrawString("号", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 100));
            e.Graphics.DrawString("内容", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(65, 100));
            e.Graphics.DrawString("数量", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, 100));
            e.Graphics.DrawString("金额", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, 100));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115), new Point(185, 115));
            foreach (var iteam in _list)
            {
                if (iteam.JiCun)
                {
                    jccount+=iteam.Count;
                }
                //计算欠款余额
                if (!iteam.FuKuan)
                {
                    if (iteam.YMoney != 0)
                    {
                        _QKMoney += iteam.YMoney;
                    }
                }
                string nleng = "";
                //string[] str = iteam.Type.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (iteam.Type != "")
                {
                    nleng += "类别：" + iteam.Type;
                }
                if (iteam.PinPai!="")
                {
                    nleng += "品牌：" + iteam.PinPai;
                }
                if (iteam.Color != "")
                {
                    nleng += "颜色：" + iteam.Color;
                }
                //if (str.Length > 1)
                //{
                if (iteam.FuWuName != "")
                    {
                        nleng += "服务项目：" + iteam.FuWuName;
                    }
                nleng.Replace(",","，");
                nleng.Replace("[", "【");
                nleng.Replace("]", "】");
                //}                
                //e.Graphics.DrawString(j.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
                //e.Graphics.DrawString(iteam.LSCount, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, (100 + i * 15)));
                //e.Graphics.DrawString(iteam.LSMoney, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, (100 + i * 15)));
                if (nleng.Length < 9)
                {
                    e.Graphics.DrawString(nleng, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));          
                    e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115+i*15), new Point(185, 115+i*15));
                    i++;
                    j++;
                    e.Graphics.DrawString(" " + j.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 100 + i * 15 - (i * 15 - _beginy) / 2));
                    e.Graphics.DrawString(" " + iteam.Count, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, 100 + i * 15 - (i * 15 - _beginy) / 2));
                    e.Graphics.DrawString(" " + iteam.CountMoney, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, 100 + i * 15 - (i * 15 - _beginy) / 2));
                    continue;
                }
                while (nleng.Length > 9)
                {
                    e.Graphics.DrawString(nleng.Substring(0, 9), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));
                    nleng = nleng.Substring(9, nleng.Length-9);
                    i++;
                }
                e.Graphics.DrawString(nleng, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115 + i * 15), new Point(185, 115 + i * 15));             
                i++;
                j++;
                e.Graphics.DrawString(" " + j.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 100 + i * 15 - (i * 15 - _beginy) / 2));
                e.Graphics.DrawString(" " + iteam.Count, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, 100 + i * 15 - (i * 15 - _beginy) / 2));
                e.Graphics.DrawString(" " + iteam.CountMoney, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, 100 + i * 15 - (i * 15 - _beginy) / 2));
                _beginy = i * 15;
            }         
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 100), new Point(0, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(20, 100), new Point(20, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(125, 100), new Point(125, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(155, 100), new Point(155, (100 + i * 15)));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(185, 100), new Point(185, (100 + i * 15)));
            e.Graphics.DrawString("数量:" + _list.Count + "  合计金额:" + _hije, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("应付金额:" + _yfje, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("寄存件数:" + jccount, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("欠款金额:" + _QKMoney, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("取活日期:" + _time.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)[0], new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;          
            while (jiewei.Length > 16)
            {
                e.Graphics.DrawString(jiewei.Substring(0, 16), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));                
                jiewei = jiewei.Substring(16, jiewei.Length - 16);
                i++;
            }
            e.Graphics.DrawString(jiewei, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("店铺电话：" + DPTel, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString(sb.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(0,0));
            ////e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(-100, 200), new Size(400,400)));
            e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(-10, (100 + i * 15)), new Size(200, 200)));
            e.Graphics.DrawString("扫描二维码，即可查看订单信息！", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)+200));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString("", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            _beginy = 0;
            _QKMoney = 0;
	#endregion
            
        }
        public static int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }
        public static void PrintToUpMoney(memberToUpModel model)
        {
            toupmoney = model;
            //打印预览
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(20, 20, 20, 20);
            pd.PrinterSettings.PrinterName = FilterClass.MemberXF;
            pd.DefaultPageSettings.Margins = margin;
            //默认纸张
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 600);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage2);
            ppd.Document = pd;
            ppd.ShowDialog();
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
            }
        }
        private static void pd_PrintPage2(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(0, 0), new Size(200, 100)));
            //return;
            string DPTel = FilterClass.DPTel;
            string jiewei = FilterClass.DXInfo;
            int i = 1;
            int j = 0;
            StringBuilder sb = new StringBuilder();
            string tou = "顾客充值小票";
            sb.Append("            " + tou + "       \r\n");
            sb.Append("---------------------------------------------\r\n");
            sb.Append("日期:" + DateTime.Now.ToShortDateString() + " \r\n");
            sb.Append("姓名:" + toupmoney.czName + "\r\n" + "卡号:" + toupmoney.czNo + "\r\n");
            sb.Append("卡类型:" + toupmoney.czType + "\r\n");
            sb.Append("本次充值:" + toupmoney.czMoney + "\r\n");
            sb.Append("剩余次数:" + toupmoney.czyCount + "\r\n");
            sb.Append("本次充值:" + toupmoney.czyMoney + "\r\n");
            e.Graphics.DrawString(sb.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 0));
        }
    }
}
