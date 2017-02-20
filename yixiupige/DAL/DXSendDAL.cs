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
    public class DXSendDAL
    {
        public void AddList(List<DXmemberModel> list)
        {
            string str = "";
            SqlParameter[] pms;
            foreach (var iteam in list)
            {
                str = "insert into DXSend(CardNumber,MemberName,TelPhone,Date,SaleMan,ContentNR,DianPu) values(@CardNumber,@MemberName,@TelPhone,@Date,@SaleMan,@ContentNR,@DianPu)";
                pms = new SqlParameter[] { 
                new SqlParameter("@CardNumber",iteam.CardNumber==null?"":iteam.CardNumber),
                new SqlParameter("@MemberName",iteam.MemberName==null?"":iteam.MemberName),
                new SqlParameter("@TelPhone",iteam.TelPhone),
                new SqlParameter("@Date",iteam.Date),
                new SqlParameter("@SaleMan",iteam.SaleMan),
                new SqlParameter("@ContentNR",iteam.Content),
                new SqlParameter("@DianPu",iteam.DianPu)
                };
                SqlHelper.ExecuteNonQuery(str, pms);
            }
        }
        public List<DXmemberModel> selectListTJ(string yginfo)
        {
            int i = 1;
            string dp=FilterClass.DianPu1.UserName.Trim();
            List<DXmemberModel> list = new List<DXmemberModel>();
            string str = "";
            SqlParameter[] pms;
            DXmemberModel model;
            if (dp == "admin")
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from DXSend";
                    pms = new SqlParameter[] { 
                    };
                }
                else
                {
                    str = "select * from DXSend where SaleMan=@SaleMan";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@DianPu",dp),
                    new SqlParameter("@SaleMan",yginfo.Trim())
                    };
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from DXSend where DianPu=@DianPu";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@DianPu",dp)
                    };
                }
                else
                {
                    str = "select * from DXSend where DianPu=@DianPu and SaleMan=@SaleMan";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@DianPu",dp),
                    new SqlParameter("@SaleMan",yginfo.Trim())
                    };
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new DXmemberModel();
                    model.No = i;
                    model.CardNumber = read["CardNumber"].ToString().Trim();
                    model.MemberName = read["MemberName"].ToString().Trim();
                    model.TelPhone = read["TelPhone"].ToString().Trim();
                    model.Date = read["Date"].ToString().Trim();
                    model.SaleMan = read["SaleMan"].ToString().Trim();
                    model.Content = read["ContentNR"].ToString().Trim();
                    model.DianPu = read["DianPu"].ToString().Trim();
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
    }
}
