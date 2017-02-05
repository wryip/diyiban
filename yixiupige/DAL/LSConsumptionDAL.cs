using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LSConsumptionDAL
    {
        public bool AddList(List<LiShiConsumption> listLS)
        {
            bool result = false;
            string str = "";
            SqlParameter[] pms;
            foreach (var iteam in listLS)
            {
                str = "insert into LSConsumption(LSName,LSDate,LSStaff,LSNumberCount,LSMoney,LSYMoney,LSCount,LSPinPai,LSColor,LSSalesman,LSMultipleName,LSQuestion,LSRemark,LSDanNumber,LSCardNumber,ImgUrl) values(@LSName,@LSDate,@LSStaff,@LSNumberCount,@LSMoney,@LSYMoney,@LSCount,@LSPinPai,@LSColor,@LSSalesman,@LSMultipleName,@LSQuestion,@LSRemark,@LSDanNumber,@LSCardNumber,@ImgUrl)";
                pms = new SqlParameter[] { 
                new SqlParameter("@LSName",iteam.LSName),
                new SqlParameter("@LSDate",iteam.LSDate),
                new SqlParameter("@LSStaff",iteam.LSStaff),
                new SqlParameter("@LSNumberCount",iteam.LSNumberCount),
                new SqlParameter("@LSMoney",iteam.LSMoney),
                new SqlParameter("@LSYMoney",iteam.LSYMoney),
                new SqlParameter("@LSCount",iteam.LSCount),
                new SqlParameter("@LSPinPai",iteam.LSPinPai),
                new SqlParameter("@LSColor",iteam.LSColor),
                new SqlParameter("@LSSalesman",iteam.LSSalesman),
                new SqlParameter("@LSMultipleName",iteam.LSMultipleName),
                new SqlParameter("@LSQuestion",iteam.LSQuestion),
                new SqlParameter("@LSRemark",iteam.LSRemark),
                new SqlParameter("@LSDanNumber",iteam.LSDanNumber),
                new SqlParameter("@LSCardNumber",iteam.LSCardNumber),
                new SqlParameter("@ImgUrl",iteam.ImgUrl)
                };
                result = SqlHelper.ExecuteNonQuery(str, pms)>0;
                if (!result)
                {
                    return result;
                }
            }
            return result;
        }
        public List<LiShiConsumption> selectAllList(string cardNo)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            string str = "select * from LSConsumption where LSCardNumber=@LSCardNumber";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@LSCardNumber",cardNo)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new LiShiConsumption();
                    model.LSName = read["LSName"].ToString().Trim();
                    model.LSDate = read["LSDate"].ToString().Trim();
                    model.LSStaff = read["LSStaff"].ToString().Trim();
                    model.LSNumberCount = read["LSNumberCount"].ToString().Trim();
                    model.LSMoney = read["LSMoney"].ToString().Trim();
                    model.LSYMoney = read["LSYMoney"].ToString().Trim();
                    model.LSCount = read["LSCount"].ToString().Trim();
                    model.LSPinPai = read["LSPinPai"].ToString().Trim();
                    model.LSColor = read["LSColor"].ToString().Trim();
                    model.LSSalesman = read["LSSalesman"].ToString().Trim();
                    model.LSMultipleName = read["LSMultipleName"].ToString().Trim();
                    model.LSQuestion = read["LSQuestion"].ToString().Trim();
                    model.LSRemark = read["LSRemark"].ToString().Trim();
                    model.LSDanNumber = read["LSDanNumber"].ToString().Trim();
                    model.LSCardNumber = read["LSCardNumber"].ToString().Trim();
                    model.ImgUrl = read["ImgUrl"].ToString().Trim();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 返回不大票据的信息
        /// </summary>
        /// <param name="cardno"></param>
        /// <returns></returns>
        public List<bdpjModel> selectBDPJ()
        {
            List<bdpjModel> list = new List<bdpjModel>();
            bdpjModel model;
            string str = "select LSDanNumber,LSName,LSCardNumber from LSConsumption group by LSDanNumber,LSName,LSCardNumber";
            //SqlParameter[] pms = new SqlParameter[] { };
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new bdpjModel();
                    model.memberName = read["LSName"].ToString().Trim();
                    model.cardNumber = read["LSCardNumber"].ToString().Trim();
                    model.danNumber = read["LSDanNumber"].ToString().Trim();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
