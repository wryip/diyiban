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
    public class QZDAL
    {
        public bool AddIteam(WPEnd model)
        {
            bool result = false;
            string dpname = FilterClass.DianPu1.UserName;
            string str = "insert into WPEnd(JCID,Name,TelPhon,DateTime,DanNumber,DPName) values(@JCID,@Name,@TelPhon,@DateTime,@DanNumber,@DPName)";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@JCID",model.JCID),
            new SqlParameter("@Name",model.Name),
            new SqlParameter("@TelPhon",model.TelPhon),
            new SqlParameter("@DateTime",model.DateTime),
            new SqlParameter("@DanNumber",model.DanNumber),
            new SqlParameter("@DPName",dpname)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<WPEnd> SelectAll(string begindate, string enddate, string dpname)
        {
            string dpna=FilterClass.DianPu1.UserName;
            List<WPEnd> list = new List<WPEnd>();
            WPEnd model;
            string str;
            if (dpname == "全部")
            {
                str = "select a.*,b.XYF from WPEnd as a join JCInfoTable as b on b.jcID=a.JCID where a.DateTime BETWEEN '" + begindate + "' and '" + enddate + "'";
            }
            else if (dpname == "")
            {
                str = "select a.*,b.XYF from WPEnd as a join JCInfoTable as b on b.jcID=a.JCID where a.DateTime BETWEEN '" + begindate + "' and '" + enddate + "' and a.DPName='" + dpna + "'";
            }
            else
            {
                str = "select a.*,b.XYF from WPEnd as a join JCInfoTable as b on b.jcID=a.JCID where a.DateTime BETWEEN '" + begindate + "' and '" + enddate + "' and DPName='" + dpname + "'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new WPEnd();
                    model.DPName = read["DPName"].ToString();
                    model.DanNumber = read["DanNumber"].ToString();
                    model.DateTime = read["DateTime"].ToString();
                    model.ID = Convert.ToInt32(read["XYF"]);
                    model.JCID = Convert.ToInt32(read["JCID"]);
                    model.Name = read["Name"].ToString();
                    model.TelPhon = read["TelPhon"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
