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
        public static string _hije { get; set; }
        public static string _hjch { get; set; }
        public static string _yfje { get; set; }
        public static string _sb { get; set; }
        public static List<LiShiConsumption> _list { get; set; }
        public static Image _ibmap { get; set; }
        public static string _name { get; set; }
        public static string _time { get; set; }
        public static string _cardnumber { get; set; }
        public static void PirentSH(string hije, string hjch, string yfje, List<LiShiConsumption> list, Image ibmap,string sb,string name,string cardnumber,string time)
        {
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
            pd.DefaultPageSettings.Margins = margin;
            //默认纸张
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 600);
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
        public static void ceshi()
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(20, 20, 20, 20);
            pd.DefaultPageSettings.Margins = margin;
            //默认纸张
            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 600);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppd.Document = pd;
            pd.Print();
        }
        private static void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
#region //重写
            string jiewei = FilterClass.DXInfo;
            int jccount = 0;
            int i = 1;
            int j = 1;
            StringBuilder sb = new StringBuilder();
            string tou = "青岛一休皮革小票";
            sb.Append("            " + tou + "       \r\n");
            sb.Append("---------------------------------------------\r\n");
            sb.Append("日期:" + DateTime.Now.ToShortDateString() + " \r\n" + "单号:" + _sb + "\r\n");
            sb.Append("姓名:" + (_name == "" ? "散客" : _name) + " \r\n" + "卡号:" + (_cardnumber == "" ? "无卡" : _cardnumber) + "\r\n");
            sb.Append("_____________________________________________\r\n");
                        e.Graphics.DrawString("号", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 100));
            e.Graphics.DrawString("内容", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(65, 100));
            e.Graphics.DrawString("数量", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, 100));
            e.Graphics.DrawString("金额", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, 100));
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115), new Point(185, 115));
            foreach (var iteam in _list)
            {
                if (iteam.IsJC)
                {
                    jccount++;
                }
                string nleng = iteam.LSStaff;
                e.Graphics.DrawString(j.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
                e.Graphics.DrawString(iteam.LSCount, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(125, (100 + i * 15)));
                e.Graphics.DrawString(iteam.LSMoney, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(155, (100 + i * 15)));
                if (nleng.Length < 9)
                {
                    e.Graphics.DrawString(nleng, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(20, (100 + i * 15)));          
                    e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, 115+i*15), new Point(185, 115+i*15));
                    i++;
                    j++;
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
            e.Graphics.DrawString("取活日期:" + TimeGuiGe.TimePicter(_time), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            while (jiewei.Length > 16)
            {
                e.Graphics.DrawString(jiewei.Substring(0, 16), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));                
                jiewei = jiewei.Substring(16, jiewei.Length - 16);
                i++;
            }
            e.Graphics.DrawString(jiewei.Substring(0, 16), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (100 + i * 15)));
            i++;
            e.Graphics.DrawString(sb.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(0,0));
            ////e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(-100, 200), new Size(400,400)));
            e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(0, (100 + i * 15)), new Size(250, 250))); 
	#endregion
            
        }
        public static int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }
        public static void StaffGuiGe(string str, StringBuilder sb)
        {
            string kg = "_";
            if (str.Length > 9)
            {
                //sb.Append("|___|____________________________|____|_____ |\r\n");
                sb.Append("|   |" + str.Substring(0, 9) + "|    |      |\r\n");
                StaffGuiGe(str.Substring(9, str.Length - 9), sb);
            }
            else
            {
                int count = 9 - str.Length;
                for (int j = 0; j < count; j++)
                {
                    kg += " ";
                }
                str = kg+ kg+ str+kg+kg;
                sb.Append("|___|" + str + "|____|_____ |\r\n");
                //sb.Append("|   ||    |      |\r\n");
            }
        }
        //public static string CountGuiGe(string str)
        //{ }
    }
}
