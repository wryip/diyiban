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
        public static void PirentSH(string hije, string hjch, string yfje, List<LiShiConsumption> list, Image ibmap,string sb)
        {
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

        private static void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string tou = "青岛一休皮革小票";
            sb.Append("            " + tou + "       \r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("日期:" + DateTime.Now.ToShortDateString() + "  " + "单号:" + _sb + "\r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("项目" + "\t\t" + "数量" + "\t" +  "小计" + "\r\n");
            foreach (var iteam in _list)
            {
                sb.Append(iteam.LSStaff + "\t" + iteam.LSCount + "\t" + iteam.LSMoney);
                sb.Append("\r\n");
            }
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("数量: " + _list.Count + " 合计金额:   " + _hije + "合计次数:" + _hjch + "\r\n");
            sb.Append("应付金额" + "    " + _yfje + "\r\n");
            //sb.Append("         现金找零:" + "   " + (fukuan - total) + "\r\n");
            //sb.Append("-----------------------------------------------------------------\r\n");
            //sb.Append("地址：" + address + "\r\n");
            //sb.Append("电话：123456789   123456789\r\n");
            //e.Graphics.DrawString("一休皮革收据小票", new Font("Segoe UI", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(8, 30));//其中10为左边距，30为上边距
            sb.Append("                 谢谢惠顾欢迎下次光临                    \r\n");
            sb.Append(FilterClass.DXInfo + "\r\n");
            e.Graphics.DrawString(sb.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(0,0));
            e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(-100, 200), new Size(400,400)));
            //e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(0, 50), new Size(250, 250)));
        }
        public static int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }
    }
}
