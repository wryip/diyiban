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
    public class memberCZMoneyDAL
    {
        public bool addModel(memberToUpModel model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@czName",model.czName),
            new SqlParameter("@czMoney",model.czMoney),
            new SqlParameter("@czCount",model.czCount),
            new SqlParameter("@czyMoney",model.czyMoney),
            new SqlParameter("@czyCount",model.czyCount),
            new SqlParameter("@czType",model.czType),
            new SqlParameter("@czDate",model.czDate),
            new SqlParameter("@czSaleman",model.czSaleman),
            new SqlParameter("@czNo",model.czNo),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            string str = "insert into memberToUpMoney(czName,czMoney,czCount,czyMoney,czyCount,czType,czDate,czSaleman,czNo,DPName) values(@czName,@czMoney,@czCount,@czyMoney,@czyCount,@czType,@czDate,@czSaleman,@czNo,@DPName)";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<memberToUpModel> selectAllList(string cardNo)
        {
            List<memberToUpModel> list = new List<memberToUpModel>();
            memberToUpModel model;
            SqlParameter[] pms=new SqlParameter[]{
            new SqlParameter("@czNo",cardNo),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            int i = 1;
            string str = "select * from memberToUpMoney where czNo=@czNo and DPName=@DPName";
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
        public bool deleteInfoModel(string cardNo)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@czId",cardNo),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            string str = "delete from memberToUpMoney where czId=@czId and DPName=@DPName";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<memberToUpModel> selectTJ(string yginfo)
        {
            List<memberToUpModel> list = new List<memberToUpModel>();
            memberToUpModel model;
            string str = "";
            SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName == "admin")
            {
                if (yginfo.Trim() != "全部")
                {
                    str = "select * from memberToUpMoney where czSaleman=@czSaleman";
                    pms = new SqlParameter[]{
            new SqlParameter("@czSaleman",yginfo)
            };
                }
                else
                {
                    str = "select * from memberToUpMoney";
                    pms = new SqlParameter[]{};
                }
            }
            else
            {
                if (yginfo.Trim() != "全部")
                {
                    str = "select * from memberToUpMoney where czSaleman=@czSaleman and DPName=@DPName";
                    pms = new SqlParameter[]{
            new SqlParameter("@czSaleman",yginfo),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
                }
                else
                {
                    str = "select * from memberToUpMoney where DPName=@DPName";
                    pms = new SqlParameter[]{
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
                }
            }
            
            int i = 1;
            SqlDataReader read ;
            if (pms.Length == 0)
            {
                read = SqlHelper.ExecuteReader(str);
            }
            else
            {
                read = SqlHelper.ExecuteReader(str,pms);
            }
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
