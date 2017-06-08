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
        //此类是退单类   各店也需要单独显示自己的
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加退单信息   
        public void AddExitDan(ExitDanModel model)
        {
            if (ID == null)
            {
                return;
            }
            string str = "insert into ExitDan" + ID + "(memberName,memberCardNo,saleMen,DPName,DanMoney,StaffName,ExitDanTime,IsMoney) values(@memberName,@memberCardNo,@saleMen,@DPName,@DanMoney,@StaffName,@ExitDanTime,@IsMoney)";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@memberName",model.memberName),
            new SqlParameter("@memberCardNo",model.memberCardNo),
            new SqlParameter("@saleMen",model.saleMen),
            new SqlParameter("@DPName",model.DPName),
            new SqlParameter("@DanMoney",model.DanMoney),
            new SqlParameter("@StaffName",model.StaffName),
            new SqlParameter("@ExitDanTime",model.ExitDanTime),
            new SqlParameter("@IsMoney",model.IsMoney)
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        //查询退弹信息   在统计报表中显示
        public List<ExitDanModel> SelectAllList(string begindate, string enddate, string dpname)
        {
            List<ExitDanModel> list = new List<ExitDanModel>();
            string dpna=FilterClass.DianPu1.UserName;           
            ExitDanModel model;
            string str="";
            if (dpname == "全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select * from ";
                    str += "ExitDan" + iteam.Value + "";
                    str += " where ExitDanTime between '" + begindate + "' and '" + enddate + "'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
            }
            else if (dpname == "")
            {
                str = "select * from ExitDan"+ID+" where ExitDanTime BETWEEN '" + begindate + "' and '" + enddate + "'";
            }
            else
            {
                int id = FilterClass.dic[dpname.Trim()];
                str = "select * from ExitDan"+id+" where ExitDanTime BETWEEN '" + begindate + "' and '" + enddate + "'";
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
                    model.IsMoney = read["IsMoney"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
