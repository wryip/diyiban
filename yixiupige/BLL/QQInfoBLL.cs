using Commond;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QQInfoBLL
    {
        QQInfoDAL dal = new QQInfoDAL();
        public string SelectInfo()
        {
            return dal.SelectInfo();
        }
        public void InsertIpAddress()
        {
            string dpname = FilterClass.DianPu1.UserName;
            System.Net.IPHostEntry myEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string ipAddress = myEntry.AddressList[6].ToString();
            dal.InsertIpAddress(dpname, ipAddress);
        }
    }
}
