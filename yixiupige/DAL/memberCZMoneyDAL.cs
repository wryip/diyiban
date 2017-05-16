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
    public class memberCZMoneyDAL
    {
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加消费记录
        public bool addModel(memberToUpModel model)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@czName",model.czName),
            new SqlParameter("@czMoney",model.czMoney),
            new SqlParameter("@czCount",model.czCount),
            new SqlParameter("@czyMoney",model.czyMoney),
            new SqlParameter("@czyCount",model.czyCount),
            new SqlParameter("@czType",model.czType),
            new SqlParameter("@czDate",SqlDbType.SmallDateTime){Value=model.czDate},
            new SqlParameter("@czSaleman",model.czSaleman),
            new SqlParameter("@czNo",model.czNo),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            string str = "insert into memberToUpMoney"+ID+"(czName,czMoney,czCount,czyMoney,czyCount,czType,czDate,czSaleman,czNo,DPName) values(@czName,@czMoney,@czCount,@czyMoney,@czyCount,@czType,@czDate,@czSaleman,@czNo,@DPName)";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //根据卡号查询所有的充值记录   应该是在查看会员信息的时候，在下面显示的充值信息
        public List<memberToUpModel> selectAllList(string cardNo)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<memberToUpModel> list = new List<memberToUpModel>();
            if (ID == null)
            {
                return list;
            }
            memberToUpModel model;
            SqlParameter[] pms;
            int i = 1;
            string str;
            //if (dpname == "admin")
            //{
                pms = new SqlParameter[]{
            new SqlParameter("@czNo",cardNo)
            };
                str = "select * from memberToUpMoney" + ID + " where czNo=@czNo order by czDate";
            //}
            //else
            //{
            //    pms = new SqlParameter[]{
            //new SqlParameter("@czNo",cardNo),
            //new SqlParameter("@DPName",dpname)
            //};
            //    str = "select * from memberToUpMoney where czNo=@czNo and DPName=@DPName";
            //}
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberToUpModel();
                    model.czName = read["czName"].ToString().Trim();
                    model.czMoney = read["czMoney"].ToString().Trim();
                    model.czCount = read["czCount"].ToString().Trim();
                    model.czyMoney = read["czyMoney"].ToString().Trim();
                    model.czyCount = read["czyCount"].ToString().Trim();
                    model.czType = read["czType"].ToString().Trim();
                    model.czDate = read["czDate"].ToString().Trim();
                    model.czSaleman = read["czSaleman"].ToString().Trim();
                    model.czId = Convert.ToInt32(read["czId"].ToString().Trim());
                    model.dianpu = read["DPName"].ToString().Trim();
                    model.czXH = i;
                    list.Add(model);
                }
                i++;
            }
            return list;
        }
        //根据ID删除一条充值记录
        public bool deleteInfoModel(string cardNo)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@czId",cardNo)
            };
            string str = "delete from memberToUpMoney"+ID+" where czId=@czId";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //统计报表中的充值记录
        public List<memberToUpModel> selectTJ(string begindate, string enddate, string yginfo,string dpna)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<memberToUpModel> list = new List<memberToUpModel>();
            memberToUpModel model;
            string str = "";
            //SqlParameter[] pms;
            if (dpname == "admin")
            {
                if (dpna == "全部")
                {
                    if (yginfo.Trim() != "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "memberToUpMoney" + iteam.Value + "";
                            str += " where czDate between '" + begindate + "' and '" + enddate + "' and czSaleman='" + yginfo .Trim()+ "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
            //            str = "select * from memberToUpMoney where czSaleman=@czSaleman and czDate between '" + begindate + "' and '" + enddate + "'";
            //            pms = new SqlParameter[]{
            //new SqlParameter("@czSaleman",yginfo)
            //};
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "memberToUpMoney" + iteam.Value + "";
                            str += " where czDate between '" + begindate + "' and '" + enddate + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                    }
                }
                else
                {
                    int id = FilterClass.dic[dpna.Trim()];
                    if (yginfo.Trim() != "全部")
                    {
                        str = "select * from memberToUpMoney" + id + " where czSaleman='" + yginfo.Trim() + "' and czDate between '" + begindate + "' and '" + enddate + "'";
                    }
                    else
                    {
                        str = "select * from memberToUpMoney" + id + " where czDate between '" + begindate + "' and '" + enddate + "'";
                    }
                }
            }
            else
            {
                if (yginfo.Trim() != "全部")
                {
                    str = "select * from memberToUpMoney" + ID + " where czSaleman='" + yginfo.Trim() + "' and czDate between '" + begindate + "' and '" + enddate + "'";
                }
                else
                {
                    str = "select * from memberToUpMoney"+ID+" where czDate between '" + begindate + "' and '" + enddate + "'";
                }
            }
            
            int i = 1;
            SqlDataReader  read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberToUpModel();
                    model.czName = read["czName"].ToString().Trim();
                    model.czMoney = read["czMoney"].ToString().Trim();
                    model.czCount = read["czCount"].ToString().Trim();
                    model.czyMoney = read["czyMoney"].ToString().Trim();
                    model.czyCount = read["czyCount"].ToString().Trim();
                    model.czType = read["czType"].ToString().Trim();
                    model.czDate = read["czDate"].ToString().Trim();
                    model.czSaleman = read["czSaleman"].ToString().Trim();
                    model.czNo = read["czNo"].ToString().Trim();
                    model.czId = Convert.ToInt32(read["czId"].ToString().Trim());
                    model.czXH = i;
                    list.Add(model);
                }
                i++;
            }
            return list;
        }
    }
}
