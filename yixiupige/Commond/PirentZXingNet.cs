using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Rendering;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Commond
{
    public static class PirentZXingNet
    {
        public static Bitmap _ibmap { get; set; }
        public static string _fuwuname { get; set; }
        public static string _dannumber { get; set; }
        public static string _datetime { get; set; }
        public static string _question { get; set; }
        public static int _sumcount { get; set; }
        public static int _sumindex { get; set; }
        public static string _type { get; set; }
        public static string _pinpai { get; set; }
        public static string _color { get; set; }
        public static string _remark { get; set; }
        public static bool PirentTM(string str,string fuwuame,string dannumber,string datetime,int suncount,int index,string question,string type,string pinpai,string color,string remark)
        {
            _remark = remark;
            _color = color;
            _type = type;
            _pinpai = pinpai;
            _question = question;
            _sumcount = suncount;
            _sumindex = index;
            _datetime = datetime;
            _fuwuname = fuwuame;
            _dannumber = dannumber;
            QrCodeEncodingOptions option;
            BarcodeWriter writer = null; 
            option = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 200,
                Height = 100
            };
            writer = new BarcodeWriter();
            //writer.Format = BarcodeFormat.QR_CODE;//二维码
            writer.Format = BarcodeFormat.ITF;//改变条形码条形码
            writer.Options = option;
            //str = str.Substring(0,str.Length-1);
            Bitmap bitmap = writer.Write(str);
            try
            {
                ceshi(bitmap);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void ceshi(Bitmap bitma)
        {
            _ibmap = bitma;
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            //Margins margin = new Margins(0, 0, 0, 0);
            pd.PrinterSettings.PrinterName = FilterClass.BGJPrinter;
            pd.DefaultPageSettings.Margins = new Margins(20,20,20,20);
            //默认纸张
            PaperSize pageSize = new PaperSize("First custom size", getYc(50),600);
            pd.DefaultPageSettings.PaperSize = pageSize;
            //pd.DefaultPageSettings.Landscape = true;
            //打印事件设置            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppd.Document = pd;
            pd.Print();
        }
        public static int getYc(double cm)
        {
            return (int)Math.Ceiling((cm / 25.4)) * 100;
        }
        private static void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string nlen="";
            if (_type != "")
            {
                nlen += "类别：" + _type;
            }
            if (_pinpai != "")
            {
                nlen += "  品牌：" + _pinpai;
            }
            if (_color != "")
            {
                nlen += "  颜色：" + _color;
            }
            string nlentfw = "服务项目：" + _fuwuname;
            int i = 1;
            e.Graphics.DrawString("     " + FilterClass.DianPu1.UserName, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 0));
            e.Graphics.DrawString("---------------------------------------------", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, i * 15));
            i++;
            e.Graphics.DrawImage(_ibmap, new Rectangle(new System.Drawing.Point(-18, i*15), new Size(230,50)));
            i++;
            e.Graphics.DrawString("---------------------------------------------", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
            i++;
            e.Graphics.DrawString("单号：" + _dannumber + "-" + _sumcount.ToString() + "-" + _sumindex.ToString(), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
            i++;
            e.Graphics.DrawString("取活日期：" + _datetime, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
            i++;
            e.Graphics.DrawString("---------------------------------------------", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
            i++;
            if (nlen.Length < 16)
            {
                e.Graphics.DrawString(nlen, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                i++;
            }
            else
            {
                while (nlen.Length > 16)
                {
                    e.Graphics.DrawString(nlen.Substring(0, 16), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                    nlen = nlen.Substring(16, nlen.Length - 16);
                    i++;
                }
                e.Graphics.DrawString(nlen, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                i++;
            }
            if (nlentfw.Length < 16)
            {
                e.Graphics.DrawString(nlentfw, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                i++;
            }
            else
            {
                while (nlentfw.Length > 16)
                {
                    e.Graphics.DrawString(nlentfw.Substring(0, 16), new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                    nlentfw = nlentfw.Substring(16, nlentfw.Length - 16);
                    i++;
                }
                e.Graphics.DrawString(nlentfw, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                i++;
            }
            if (_question != "")
            {
                e.Graphics.DrawString("瑕疵：" + _question, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));
                i++;
            }
            if (_remark != "")
            {
                e.Graphics.DrawString("备注：" + _remark, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, (i * 15 + 50)));    
            }
            _type = "";
          _pinpai="";
           _color="";
            //e.Graphics.DrawString("店铺："+FilterClass.DianPu1.UserName, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, new Point(0, 85));
        }
    }
}
