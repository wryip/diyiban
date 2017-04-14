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
    public class ExitDanDAL
    {
        public void AddExitDan(ExitDanModel model)
        {
            string str = "insert into ExitDan(memberName,memberCardNo,saleMen,DPName,DanMoney,StaffName,ExitDanTime) values(@memberName,@memberCardNo,@saleMen,@DPName,@DanMoney,@StaffName,@ExitDanTime)";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@memberName",model.memberName),
            new SqlParameter("@memberCardNo",model.memberCardNo),
            new SqlParameter("@saleMen",model.saleMen),
            new SqlParameter("@DPName",model.DPName),
            new SqlParameter("@DanMoney",model.DanMoney),
            new SqlParameter("@StaffName",model.StaffName),
            new SqlParameter("@ExitDanTime",model.ExitDanTime)
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        public List<ExitDanModel> SelectAllList(string begindate, string enddate, string dpname)
        {
            string dpna=FilterClass.DianPu1.UserName;
            List<ExitDanModel> list = new List<ExitDanModel>();
            ExitDanModel model;
            string str;
            if (dpname == "全部")
            {
                str = "select * from ExitDan where ExitDanTime BETWEEN '" + begindate + "' and '" + enddate + "'";
            }
            else if (dpname == "")
            {
                str = "select * from ExitDan where ExitDanTime BETWEEN '" + begindate + "' and '" + enddate + "' and DPName='" + dpna + "'";
            }
            else
            {
                str = "select * from ExitDan where ExitDanTime BETWEEN '" + begindate + "' and '" + enddate + "' and DPName='" + dpname + "'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new ExitDanModel();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.memberName = read["memberName"].ToString().Trim();
                    model.memberCardNo = read["memberCardNo"].ToString().Trim();
                    model.saleMen = read["saleMen"].ToString().Trim();
                    model.DPName = read["DPName"].ToString().Trim();
                    model.DanMoney = read["DanMoney"].ToString().Trim();
                    model.StaffName = read["StaffName"].ToString().Trim();
                    model.ExitDanTime = read["ExitDanTime"].ToString().Trim();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
