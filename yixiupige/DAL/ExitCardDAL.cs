using Commond;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExitCardDAL
    {
        //退卡信息   此信息也需要单独来统计
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加退卡信息
        public bool ExitCard(ExitCardModel model)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "insert into ExitCard"+ID+"(memberName,DateTimeCard,saleMen,CardMoney,CardType,DPName) values(@memberName,@DateTimeCard,@saleMen,@CardMoney,@CardType,@DPName)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",model.memberName),
            new SqlParameter("@DateTimeCard",model.DateTimeCard),
            new SqlParameter("@saleMen",model.saleMen),
            new SqlParameter("@CardMoney",model.CardMoney),
            new SqlParameter("@CardType",model.CardType),
            new SqlParameter("@DPName",model.DPName)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //在统计报表中显示的信息   显示的退卡信息
        public List<ExitCardModel> SelectAllList(string begindate, string enddate, string dpname)
        {
            List<ExitCardModel> list = new List<ExitCardModel>();
            ExitCardModel model;
            string str="";
            //SqlParameter[] pms;
            if (dpname =="全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select * from ";
                    str += "ExitCard" + iteam.Value + "";
                    str += " where DateTimeCard between '" + begindate + "' and '" + enddate + "'";
                    str += " union all ";
                }
            }
            else if (dpname == "")
            {
                string dpna = FilterClass.DianPu1.UserName;
                str = "select * from ExitCard"+ID+" where DateTimeCard BETWEEN '" + begindate + "' and '" + enddate + "'";              
            }
            else
            {
                int id = FilterClass.dic[dpname.Trim()];
                str = "select * from ExitCard where DateTimeCard"+id+" BETWEEN '" + begindate + "' and '" + enddate + "'";               
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new ExitCardModel();
                    model.memberName = read["memberName"].ToString().Trim();
                    model.DateTimeCard = read["DateTimeCard"].ToString().Trim();
                    model.saleMen = read["saleMen"].ToString().Trim();
                    model.CardMoney = read["CardMoney"].ToString().Trim();
                    model.CardType = read["CardType"].ToString().Trim();
                    model.DPName = read["DPName"].ToString().Trim();
                    model.ID = Convert.ToInt32(read["ID"]);
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
