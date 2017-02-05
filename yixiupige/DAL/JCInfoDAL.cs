using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JCInfoDAL
    {
        public bool addJCList(List<JCInfoModel> list)
        {
            bool result = false;
            string str = "insert into JCInfoTable(jcCardNumber,jcName,jcQMoney,jcType,jcPinPai,jcColor,jcStaff,jcBeginDate,jcEndDate,jcZT,jcAddress,jcImgUrl) values(@jcCardNumber,@jcName,@jcQMoney,@jcType,@jcPinPai,@jcColor,@jcStaff,@jcBeginDate,@jcEndDate,@jcZT,@jcAddress,@jcImgUrl)";
            SqlParameter[] pms;
            foreach (var iteam in list)
            { 
                pms=new SqlParameter[]{
                new SqlParameter("@jcCardNumber",iteam.jcCardNumber),
                new SqlParameter("@jcName",iteam.jcName),
                new SqlParameter("@jcQMoney",iteam.jcQMoney),
                new SqlParameter("@jcType",iteam.jcType),
                new SqlParameter("@jcPinPai",iteam.jcPinPai),
                new SqlParameter("@jcColor",iteam.jcColor),
                new SqlParameter("@jcStaff",iteam.jcStaff),
                new SqlParameter("@jcBeginDate",iteam.jcBeginDate),
                new SqlParameter("@jcEndDate",iteam.jcEndDate),
                new SqlParameter("@jcZT",iteam.jcZT),
                new SqlParameter("@jcAddress",iteam.jcAddress),
                new SqlParameter("@jcImgUrl",iteam.jcImgUrl)
                };
                if (!(SqlHelper.ExecuteNonQuery(str, pms) > 0))
                {
                    result = false;
                    return result;
                }
            }
            return result;
        }
        public List<JCInfoModel> selectAllList(string type)
        {
            int i = 1;
            List<JCInfoModel> list=new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable where jcType=@jcType";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcType",type.Trim())
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str,pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = i;
                    model.jcID = Convert.ToInt32(read["jcID"]);
                    model.jcCardNumber = read["jcCardNumber"].ToString();
                    model.jcName = read["jcName"].ToString();
                    model.jcQMoney = read["jcQMoney"].ToString();
                    model.jcType = read["jcType"].ToString();
                    model.jcPinPai = read["jcPinPai"].ToString();
                    model.jcColor = read["jcColor"].ToString();
                    model.jcStaff = read["jcStaff"].ToString();
                    model.jcBeginDate = read["jcBeginDate"].ToString();
                    model.jcEndDate = read["jcEndDate"].ToString();
                    model.jcZT = read["jcZT"].ToString();
                    model.jcAddress = read["jcAddress"].ToString();
                    model.jcImgUrl = read["jcImgUrl"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
