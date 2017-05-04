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
        //店内完成类
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加无票取走
        public bool AddIteam(WPEnd model)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string dpname = FilterClass.DianPu1.UserName;
            string str = "insert into WPEnd"+ID+"(JCID,Name,TelPhon,DateTime,DanNumber,DPName) values(@JCID,@Name,@TelPhon,@DateTime,@DanNumber,@DPName)";
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
        //应该是统计报表中的物品无票取走的统计！！！！！！！！！！！！！！！！！！！！！！
        public List<WPEnd> SelectAll(string begindate, string enddate, string dpname)
        {
            string dpna=FilterClass.DianPu1.UserName;
            List<WPEnd> list = new List<WPEnd>();
            WPEnd model;
            string str="";
            if (dpname == "全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select a.*,b.XYF from ";
                    str += "WPEnd" + iteam.Value + " as a join JCInfoTable" + iteam.Value + " as b on b.jcID=a.JCID";
                    str += " where a.DateTime between '" + begindate + "' and '" + enddate + "'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
                //str = "select a.*,b.XYF from WPEnd as a join JCInfoTable as b on b.jcID=a.JCID where a.DateTime BETWEEN '" + begindate + "' and '" + enddate + "'";
            }
            else if (dpname == "")
            {
                str = "select a.*,b.XYF from WPEnd"+ID+" as a join JCInfoTable"+ID+" as b on b.jcID=a.JCID where a.DateTime BETWEEN '" + begindate + "' and '" + enddate + "'";
            }
            else
            {
                int id = FilterClass.dic[dpname];
                str = "select a.*,b.XYF from WPEnd"+id+" as a join JCInfoTable"+id+" as b on b.jcID=a.JCID where a.DateTime BETWEEN '" + begindate + "' and '" + enddate + "' and DPName='" + dpname + "'";
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
