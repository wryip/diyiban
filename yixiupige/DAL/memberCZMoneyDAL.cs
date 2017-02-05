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
            new SqlParameter("@czNo",model.czNo)
            };
            string str = "insert into memberToUpMoney(czName,czMoney,czCount,czyMoney,czyCount,czType,czDate,czSaleman,czNo) values(@czName,@czMoney,@czCount,@czyMoney,@czyCount,@czType,@czDate,@czSaleman,@czNo)";
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
            new SqlParameter("@czNo",cardNo)
            };
            int i = 1;
            string str="select * from memberToUpMoney where czNo=@czNo";
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberToUpModel();
                    model.czName = read[0].ToString().Trim();
                    model.czMoney = read[1].ToString().Trim();
                    model.czCount = read[2].ToString().Trim();
                    model.czyMoney = read[3].ToString().Trim();
                    model.czyCount = read[4].ToString().Trim();
                    model.czType = read[5].ToString().Trim();
                    model.czDate = read[6].ToString().Trim();
                    model.czSaleman = read[7].ToString().Trim();
                    model.czId = Convert.ToInt32(read[9].ToString().Trim());
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
            };
            string str = "delete from memberToUpMoney where czId=@czId";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
