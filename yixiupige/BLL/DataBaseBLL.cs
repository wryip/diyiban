using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataBaseBLL
    {
        DataBaseDAL dal = new DataBaseDAL();
        public bool saveData()
        {
            //首先先发出命令进行数据的备份
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            //return dal.saveData(data);
            //当点击退出的时候   自动保存   并保存到本地
            //创建一个连接远程服务器的连接对象
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            //p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            //p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            //p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            //p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            //p.Start();//启动程序
            ////祥cmd中输入信息
            //string ip = ConfigurationManager.AppSettings["ip"].ToString();
            //string pwd = ConfigurationManager.AppSettings["pwd"].ToString();
            //string user = ConfigurationManager.AppSettings["user"].ToString();
            ////MessageBox.Show("net use z: \\\\59.110.172.193\\ " + "YiXiu0532" + " /user:59.110.172.193\\Administrator");
            //string ss = "ftp 59.110.172.193";
            //ss = ss.TrimEnd('&') + "&exit";
            //p.StandardInput.WriteLine(ss);
            //p.StandardInput.AutoFlush = true;
            //ss = "yixiuftp";
            ////ss = ss.Trim().TrimEnd('&') + "&exit";
            //p.StandardInput.WriteLine(ss);
            //p.StandardInput.AutoFlush = true;
            //ss = "YiXiu0532";
            ////ss = ss.Trim().TrimEnd('&') + "&exit";
            //p.StandardInput.WriteLine(ss);
            //p.StandardInput.AutoFlush = true;
            //ss = "dir";
            //ss = ss.Trim().TrimEnd('&') + "&exit";
            //p.StandardInput.WriteLine(ss);
            //p.StandardInput.AutoFlush = true;
            //string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();
            //p.Close();
            //p.StandardInput.WriteLine("yixiuftp");
            //p.StandardInput.WriteLine("YiXiu0532");
            //output = p.StandardOutput.ReadToEnd();
            //p.StandardInput.WriteLine("dir&exit");
            //output = p.StandardOutput.ReadToEnd();
            //return true;
            return dal.saveData(data);
        }
    }
}
