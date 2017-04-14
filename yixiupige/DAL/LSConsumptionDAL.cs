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
    public class LSConsumptionDAL
    {
        public bool AddList(List<LiShiConsumption> listLS)
        {
            bool result = false;
            string str = "";
            SqlParameter[] pms;
            foreach (var iteam in listLS)
            {
                str = "insert into LSConsumption(LSName,LSDate,LSStaff,LSNumberCount,LSMoney,LSYMoney,LSCount,LSPinPai,LSColor,LSSalesman,LSMultipleName,LSQuestion,LSRemark,LSDanNumber,LSCardNumber,ImgUrl,IsJC,IsSP,IsXMoney) values(@LSName,@LSDate,@LSStaff,@LSNumberCount,@LSMoney,@LSYMoney,@LSCount,@LSPinPai,@LSColor,@LSSalesman,@LSMultipleName,@LSQuestion,@LSRemark,@LSDanNumber,@LSCardNumber,@ImgUrl,@IsJC,@IsSP,@IsXMoney)";
                pms = new SqlParameter[] { 
                new SqlParameter("@LSName",iteam.LSName),
                new SqlParameter("@LSDate",SqlDbType.SmallDateTime){Value=iteam.LSDate},
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
                new SqlParameter("@ImgUrl",iteam.ImgUrl),
                new SqlParameter("@IsJC",iteam.IsJC),
                new SqlParameter("@IsSP",iteam.IsSP),
                new SqlParameter("@IsXMoney",iteam.IsXMoney)
                };
                result = SqlHelper.ExecuteNonQuery(str, pms)>0;
                if (!result)
                {
                    return result;
                }
            }
            return result;
        }
        public List<LiShiConsumption> selectAllList(string cardNo,string name)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            string str ;
            SqlParameter[] pms;
            if (name.Trim() == "admin")
            {
                str = "select * from LSConsumption where LSCardNumber=@LSCardNumber";
                pms = new SqlParameter[] { 
            new SqlParameter("@LSCardNumber",cardNo)
            };
            }
            else
            {
                str = "select * from LSConsumption where LSCardNumber=@LSCardNumber and LSMultipleName=@LSMultipleName";
                pms = new SqlParameter[] { 
            new SqlParameter("@LSCardNumber",cardNo),
            new SqlParameter("@LSMultipleName",name)
            };
            }
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
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.IsSP = Convert.ToBoolean(read["IsSP"]);
                    model.IsJC = Convert.ToBoolean(read["IsJC"]);
                    model.IsXMoney = Convert.ToBoolean(read["IsXMoney"]);
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 返回补打票据的信息
        /// </summary>
        /// <param name="cardno"></param>
        /// <returns></returns>
        public List<bdpjModel> selectBDPJ()
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<bdpjModel> list = new List<bdpjModel>();
            bdpjModel model;
            string str;
            SqlParameter[] pms;
            if (dpname == "admin")
            {
                str = "select LSDanNumber,LSName,LSCardNumber from LSConsumption group by LSDanNumber,LSName,LSCardNumber";
                pms = new SqlParameter[] {  };
            }
            else
            {
                str = "select LSDanNumber,LSName,LSCardNumber from LSConsumption where LSMultipleName=@LSMultipleName group by LSDanNumber,LSName,LSCardNumber";
                pms = new SqlParameter[] { 
            new SqlParameter("@LSMultipleName",dpname)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str,pms);
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
        public List<LiShiConsumption> selectTJ(string begindate, string enddate, string yginfo, string dpname)
        {
            int i = 1;
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            SqlParameter[] pms;
            string str = "";
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (yginfo.Trim() == "全部")
                {
                    if (dpname == "全部")
                    {
                        str = "select * from LSConsumption where LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                    };
                    }
                    else 
                    {
                        str = "select * from LSConsumption where LSMultipleName=@LSMultipleName and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                            new SqlParameter("@LSMultipleName",dpname.Trim())
                    };
                    }                    
                }
                else
                {
                    if (dpname == "全部")
                    {
                        str = "select * from LSConsumption where LSSalesman=@LSSalesman and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                    new SqlParameter("@LSSalesman",yginfo.Trim())
                    };
                    }
                    else
                    {
                        str = "select * from LSConsumption where LSSalesman=@LSSalesman and LSMultipleName=@LSMultipleName and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                    new SqlParameter("@LSSalesman",yginfo.Trim()),
                    new SqlParameter("@LSMultipleName",dpname.Trim())
                    };
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from LSConsumption where LSMultipleName=@LSMultipleName and LSDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@LSMultipleName",FilterClass.DianPu1.UserName.Trim())
                    };
                }
                else
                {
                    str = "select * from LSConsumption where LSMultipleName=@LSMultipleName and LSSalesman=@LSSalesman and LSDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@LSMultipleName",FilterClass.DianPu1.UserName.Trim()),
                    new SqlParameter("@LSSalesman",yginfo.Trim())
                    };
                }
            }            
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new LiShiConsumption();
                    model.LSNo = i.ToString();
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
                    model.IsSP=Convert.ToBoolean(read["IsSP"]);
                    model.IsJC = Convert.ToBoolean(read["IsJC"]);
                    model.IsXMoney = Convert.ToBoolean(read["IsXMoney"]);
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
        public List<LiShiConsumption> selectTJMoney(string begindate, string enddate, string yginfo, string dpname)
        {
            int i = 1;
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            SqlParameter[] pms;
            string str = "";
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (yginfo.Trim() == "全部")
                {
                    if (dpname == "全部")
                    {
                        str = "select * from LSConsumption where IsXMoney=@IsXMoney and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                            new SqlParameter("@IsXMoney","true")
                    };
                    }
                    else
                    {
                        str = "select * from LSConsumption where LSMultipleName=@LSMultipleName and IsXMoney=@IsXMoney and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                            new SqlParameter("@LSMultipleName",dpname.Trim()),
                            new SqlParameter("@IsXMoney","true")
                    };
                    }
                }
                else
                {
                    if (dpname == "全部")
                    {
                        str = "select * from LSConsumption where LSSalesman=@LSSalesman and IsXMoney=@IsXMoney and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                    new SqlParameter("@LSSalesman",yginfo.Trim()),
                    new SqlParameter("@IsXMoney","true")
                    };
                    }
                    else
                    {
                        str = "select * from LSConsumption where LSSalesman=@LSSalesman and LSMultipleName=@LSMultipleName and IsXMoney=@IsXMoney and LSDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                    new SqlParameter("@LSSalesman",yginfo.Trim()),
                    new SqlParameter("@LSMultipleName",dpname.Trim()),
                    new SqlParameter("@IsXMoney","true")
                    };
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from LSConsumption where LSMultipleName=@LSMultipleName and IsXMoney=@IsXMoney and LSDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@LSMultipleName",FilterClass.DianPu1.UserName.Trim()),
                    new SqlParameter("@IsXMoney","true")
                    };
                }
                else
                {
                    str = "select * from LSConsumption where LSMultipleName=@LSMultipleName and LSSalesman=@LSSalesman and IsXMoney=@IsXMoney and LSDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@LSMultipleName",FilterClass.DianPu1.UserName.Trim()),
                    new SqlParameter("@LSSalesman",yginfo.Trim()),
                    new SqlParameter("@IsXMoney","true")
                    };
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new LiShiConsumption();
                    model.LSNo = i.ToString();
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
                    model.IsSP = Convert.ToBoolean(read["IsSP"]);
                    model.IsJC = Convert.ToBoolean(read["IsJC"]);
                    model.IsXMoney = Convert.ToBoolean(read["IsXMoney"]);
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
        public bool deleteID(string id)
        {
            bool result = false;
            string str = "delete from LSConsumption where ID=@id";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@id",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<LiShiConsumption> SelectForDanNumber(string dannumber)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            string name = FilterClass.DianPu1.UserName;
            SqlParameter[] pms;
            string str = "select * from LSConsumption where LSDanNumber=@LSDanNumber and LSMultipleName=@LSMultipleName";
            pms = new SqlParameter[] { 
            new SqlParameter("@LSDanNumber",dannumber),
            new SqlParameter("@LSMultipleName",name)
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
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.IsSP = Convert.ToBoolean(read["IsSP"]);
                    model.IsJC = Convert.ToBoolean(read["IsJC"]);
                    model.IsXMoney = Convert.ToBoolean(read["IsXMoney"]);
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
