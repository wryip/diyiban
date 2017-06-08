using Commond;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class CardExitMoneyDal
    {
       //添加卡消费的信息（在数据统计中，根据需求做的卡消费的消费统计）
       public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
       public void AddList(List<CardExitMoney> list,string date)
       {
           if (ID ==null)
           {
               //当不是正确账户登陆的时候，不能添加数据
               return;
           }
           if (list.Count == 0)
           {
               return;
           }
           string str = "insert into CardExitMoney" + ID + "(membername,membernum,cardname,cardtype,cardmoney,dpname,DateTime,LSStaff) values";
           string regx = "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'),";
           string datetime = date;
           foreach (var iteam in list)
           {
               str += string.Format(regx, iteam.membername, iteam.membernum, iteam.cardname, iteam.cardtype, iteam.cardmoney, iteam.dpname, datetime,iteam.LSStaff);
           }
           str = str.Substring(0, str.Length - 1);
           SqlHelper.ExecuteNonQuery(str);
       }
       //在统计报表中显示的    查询卡的消费信息
       public List<CardExitMoney> selectTJ(string begindate, string enddate, string name)
       {
           List<CardExitMoney> list = new List<CardExitMoney>();                   
           CardExitMoney model;
           string dpnam = FilterClass.DianPu1.UserName;
           string str = "";
           //SqlParameter[] pms;
           if (name == "")
           {
               str = "select * from CardExitMoney" + ID + " where DateTime between '" + begindate + "' and '" + enddate + "'";
               //pms = new SqlParameter[] { 
               //new SqlParameter("@dpname",dpnam)
               //};
           }
           else if (name == "全部")
           {
               foreach(KeyValuePair<string,int> iteam in FilterClass.dic)
               {
                   str += "select * from "; 
                   str+="CardExitMoney"+iteam.Value+"";
                   str += " where DateTime between '" + begindate + "' and '" + enddate + "'";
                   str += " union all ";
               }
               str = str.Substring(0, str.Length - 10);
               //str += " where " + wherestr;
               //str = str.Substring(0,str.Length-4);
               //pms = new SqlParameter[] {
               //};
           }
           else
           {
               int id = FilterClass.dic[name];
               str = "select * from CardExitMoney"+id+" where DateTime between '" + begindate + "' and '" + enddate + "'";
               //pms = new SqlParameter[] { 
               //new SqlParameter("@dpname",name)
               //};
           }
           SqlDataReader read = SqlHelper.ExecuteReader(str);
           while (read.Read())
           {
               if (read.HasRows)
               {
                   model = new CardExitMoney();
                   model.ID = Convert.ToInt32(read["ID"]);
                   model.membername = read["membername"].ToString();
                   model.membernum = read["membernum"].ToString();
                   model.cardname = read["cardname"].ToString();
                   model.cardtype = read["cardtype"].ToString();
                   model.cardmoney = read["cardmoney"].ToString();
                   model.dpname = read["dpname"].ToString();
                   model.LSStaff = read["LSStaff"].ToString();
                   model.ExitDate = read["DateTime"].ToString();
                   list.Add(model);
               }
           }
           return list;
       }
       public bool deleteOnly(string membername, string membercard, string dpname, string staff, string datetime)
       {
           bool result = false;
           string str = "delete from CardExitMoney" + ID + " where membername=@membername and membernum=@membernum and dpname=@dpname and LSStaff=@LSStaff and DateTime=@DateTime";
           SqlParameter[] pms = new SqlParameter[] { 
           new SqlParameter("@membername",membername),
           new SqlParameter("@membernum",membercard),
           new SqlParameter("@dpname",dpname),
           new SqlParameter("@LSStaff",staff),
           new SqlParameter("@DateTime",datetime)
           };
           if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
           {
               result = true;
           }
           return result;
       }
    }
}
