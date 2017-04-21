using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class QQInfoDAL
    {
       public string SelectInfo()
       {
           string str = "select IpAddress from QQInfo where Name='工厂'";
           object oo = SqlHelper.ExecuteScalar(str);
           if (oo == null)
           {
               return "0";
           }
           else
           {
               return oo.ToString();
           }
       }
       public void InsertIpAddress(string dpname,string ipaddress)
       {
           int result = SelectIp(dpname, ipaddress);
           if (result == 0)
           {
               string str = "insert into QQInfo(Name,IpAddress) values('" + dpname + "','" + ipaddress + "')";
               SqlHelper.ExecuteNonQuery(str);
           }
           if (result == 1)
           {
               string str = "update QQInfo set IpAddress='" + ipaddress + "' where Name='" + dpname + "'";
               SqlHelper.ExecuteNonQuery(str);
           }
       }
       public int SelectIp(string name, string ipaddress)
       {
           string str = "select * from QQInfo where Name=@Name";
           SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@Name",name)
            };
           object oo = SqlHelper.ExecuteScalar(str, pms);
           if (oo == null)
           {
               return 0;
           }
           if (oo.ToString().Trim() == ipaddress)
           {
               return 2;
           }
           else
           {
               return 1;
           }
       }
    }
}
