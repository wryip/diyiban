using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Commond
{
    public static class SendInfo
    {
        public static bool Send(string[] str1, string neirong)
        {
            string url = "";
            string str = "0";
            for (int i = 0; i < str1.Length; i++)
            {
                url = "http://utf8.sms.webchinese.cn/?Uid=yixiupige&Key=de1157fdcfabd65571f7&smsMob=" + str1[i].ToString() + "&smsText=" + neirong;
                str = GetHtmlFromUrl(url);
            }               
            if (Convert.ToInt32(str) >0)
            {
                return true;
            }
            return false;
        }
        public static string GetHtmlFromUrl(string url)
        {
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }
    }
}
