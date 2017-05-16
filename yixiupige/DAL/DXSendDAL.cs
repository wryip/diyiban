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
    public class DXSendDAL
    {
        //此类需要改，每个店铺存储属于自己店铺的信息
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //短信发送DAL
        public void AddList(List<DXmemberModel> list)
        {
            //判断是否是店铺的信息。。。
            if (ID == null)
            {
                return;
            }
            string str = "";
            SqlParameter[] pms;
            foreach (var iteam in list)
            {
                str = "insert into DXSend"+ID+"(CardNumber,MemberName,TelPhone,Date,SaleMan,ContentNR,DianPu) values(@CardNumber,@MemberName,@TelPhone,@Date,@SaleMan,@ContentNR,@DianPu)";
                pms = new SqlParameter[] { 
                new SqlParameter("@CardNumber",iteam.CardNumber==null?"":iteam.CardNumber),
                new SqlParameter("@MemberName",iteam.MemberName==null?"":iteam.MemberName),
                new SqlParameter("@TelPhone",iteam.TelPhone),
                new SqlParameter("@Date",SqlDbType.SmallDateTime){Value=iteam.Date},
                new SqlParameter("@SaleMan",iteam.SaleMan),
                new SqlParameter("@ContentNR",iteam.Content),
                new SqlParameter("@DianPu",iteam.DianPu)
                };
                SqlHelper.ExecuteNonQuery(str, pms);
            }
        }
        //在寄存信息中显示的   显示已经发送的短信的内容
        public List<DXmemberModel> selectListTJ(string begindate, string enddate, string dpname)
        {
            List<DXmemberModel> list = new List<DXmemberModel>();
            int i = 1;
            string dp=FilterClass.DianPu1.UserName.Trim();           
            string str = "";
            //SqlParameter[] pms;
            DXmemberModel model;
            if (dp == "admin")
            {
                if (dpname.Trim() == "全部")
                {
                    foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                    {
                        str += "select * from ";
                        str += "DXSend" + iteam.Value + "";
                        str += " where Date between '" + begindate + "' and '" + enddate + "'";
                        str += " union all ";
                    }
                    str = str.Substring(0, str.Length - 10);
                    //pms = new SqlParameter[] { 
                    //};
                }
                else
                {
                    int id = FilterClass.dic[dpname.Trim()];
                    str = "select * from DXSend" + id + " where Date between '" + begindate + "' and '" + enddate + "'";
                    //pms = new SqlParameter[] { 
                    //};
                }
            }
            else
            {
                str = "select * from DXSend" + ID + " where Date between '" + begindate + "' and '" + enddate + "'";
                    //pms = new SqlParameter[] { 
                    //};
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
