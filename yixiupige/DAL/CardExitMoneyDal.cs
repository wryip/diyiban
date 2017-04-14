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
       public void AddList(List<CardExitMoney> list)
       {
           string str = "insert into CardExitMoney(membername,membernum,cardname,cardtype,cardmoney,dpname,DateTime) values";
           string regx = "('{0}','{1}','{2}','{3}','{4}','{5}','{6}'),";
           string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           foreach (var iteam in list)
           {
               str += string.Format(regx, iteam.membername, iteam.membernum, iteam.cardname, iteam.cardtype, iteam.cardmoney, iteam.dpname, datetime);
           }
           str = str.Substring(0, str.Length - 1);
           SqlHelper.ExecuteNonQuery(str);
       }
       public List<CardExitMoney> selectTJ(string begindate, string enddate, string name)
       {
           List<CardExitMoney> list = new List<CardExitMoney>();
           CardExitMoney model;
           string dpnam = FilterClass.DianPu1.UserName;
           string str = "";
           SqlParameter[] pms;
           if (name == "")
           {
               str = "select * from CardExitMoney where DateTime between '"+begindate+"' and '"+enddate+"' and dpname=@dpname";
               pms = new SqlParameter[] { 
               new SqlParameter("@dpname",dpnam)
               };
           }
           else if (name == "全部")
           {
               str = "select * from CardExitMoney where DateTime between '" + begindate + "' and '" + enddate + "'";
               pms = new SqlParameter[] {
               };
           }
           else
           {
               str = "select * from CardExitMoney where DateTime between '" + begindate + "' and '" + enddate + "' and dpname=@dpname";
               pms = new SqlParameter[] { 
               new SqlParameter("@dpname",name)
               };
           }
           SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
                   list.Add(model);
               }
           }
           return list;
       }
    }
}
