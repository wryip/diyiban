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
        public bool ExitCard(ExitCardModel model)
        {
            bool result = false;
            string str = "insert into ExitCard(memberName,DateTimeCard,saleMen,CardMoney,CardType,DPName) values(@memberName,@DateTimeCard,@saleMen,@CardMoney,@CardType,@DPName)";
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
        public List<ExitCardModel> SelectAllList(string begindate, string enddate, string dpname)
        {
            List<ExitCardModel> list = new List<ExitCardModel>();
            ExitCardModel model;
            string str;
            SqlParameter[] pms;
            if (dpname =="全部")
            {
                str = "select * from ExitCard where DateTimeCard BETWEEN '" + begindate + "' and '" + enddate + "'";
                pms = new SqlParameter[] {           
            };
            }
            else if (dpname == "")
            {
                string dpna = FilterClass.DianPu1.UserName;
                str = "select * from ExitCard where DateTimeCard BETWEEN '" + begindate + "' and '" + enddate + "' and DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpna)
            };
            }
            else
            {
                str = "select * from ExitCard where DateTimeCard BETWEEN '" + begindate + "' and '" + enddate + "' and DPName=@DPName";
                pms = new SqlParameter[] {             
            new SqlParameter("@DPName",dpname)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str,pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new ExitCardModel();
                    model.DPName = read["memberName"].ToString().Trim();
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
