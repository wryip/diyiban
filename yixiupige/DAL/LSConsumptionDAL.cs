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
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加历史消费记录
        public bool AddList(List<LiShiConsumption> listLS)
        {
            bool result = false;
            string str = "";
            SqlParameter[] pms;
            foreach (var iteam in listLS)
            {
                str = "insert into LSConsumption"+ID+"(LSName,LSDate,LSStaff,LSNumberCount,LSMoney,LSYMoney,LSCount,LSPinPai,LSColor,LSSalesman,LSMultipleName,LSQuestion,LSRemark,LSDanNumber,LSCardNumber,ImgUrl,IsJC,IsSP,IsXMoney) values(@LSName,@LSDate,@LSStaff,@LSNumberCount,@LSMoney,@LSYMoney,@LSCount,@LSPinPai,@LSColor,@LSSalesman,@LSMultipleName,@LSQuestion,@LSRemark,@LSDanNumber,@LSCardNumber,@ImgUrl,@IsJC,@IsSP,@IsXMoney)";
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
        //通过卡号去查找消费记录信息   收活管理处的更多按钮   查询出所有符合当前卡号的消费记录
        public List<LiShiConsumption> selectAllList(string cardNo,string name)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            if (ID == null)
            {
                return list;
            }            
            LiShiConsumption model;
            string str ;
            SqlParameter[] pms;
                str = "select * from LSConsumption"+ID+" where LSCardNumber=@LSCardNumber";
                pms = new SqlParameter[] { 
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
                    model.LSDanNumber = read["LSDanNumber"].ToString().Trim();
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
                    model.LSCardNumber = read["LSCardNumber"].ToString().Trim();
                    model.ImgUrl = read["ImgUrl"].ToString().Trim();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.IsSP = Convert.ToBoolean(read["IsSP"]);
                    model.IsJC = Convert.ToBoolean(read["IsJC"]);
                    model.IsXMoney = Convert.ToBoolean(read["IsXMoney"]);
                    list.Add(model);
                }
            }
            return list.OrderByDescending(a=>a.LSDate).ToList();
        }
        //散客的消费消费
        public List<LiShiConsumption> selectAllListSK(string skname, string sktel, string name)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            if (ID == null)
            {
                return list;
            }
            LiShiConsumption model;
            string str;
            SqlParameter[] pms;
            str = "select * from LSConsumption" + ID + " where LSName=@LSName or LSNumberCount=@LSNumberCount";
            pms = new SqlParameter[] { 
            new SqlParameter("@LSName",skname),
            new SqlParameter("@LSNumberCount",sktel)
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
            return list.OrderByDescending(a => a.LSDate).ToList();
        }
        /// <summary>
        /// 返回补打票据的信息   收活管理处的补打票据
        /// </summary>
        /// <param name="cardno"></param>
        /// <returns></returns>
        public List<bdpjModel> selectBDPJ(string name, string cardno, string tel)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<bdpjModel> list = new List<bdpjModel>();
            bdpjModel model;
            string str;
            SqlParameter[] pms;
            //if (dpname == "admin")
            //{
            str = "select LSDanNumber,LSName,LSCardNumber,LSDate from LSConsumption" + ID + " where LSNumberCount=@LSNumberCount or LSName=@LSName or LSCardNumber=@LSCardNumber  group by LSDanNumber,LSName,LSCardNumber,LSDate order by LSDate desc";
                pms = new SqlParameter[] { 
                new SqlParameter("@LSNumberCount",tel),
                new SqlParameter("@LSName",name),
                new SqlParameter("@LSCardNumber",cardno)
                };
            //}
            //else
            //{
            //    str = "select LSDanNumber,LSName,LSCardNumber from LSConsumption where LSMultipleName=@LSMultipleName group by LSDanNumber,LSName,LSCardNumber";
            //    pms = new SqlParameter[] { 
            //new SqlParameter("@LSMultipleName",dpname)
            //};
            //}
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
        /// <summary>
        /// 消费信息的统计
        /// </summary>
        /// <param name="begindate"></param>
        /// <param name="enddate"></param>
        /// <param name="yginfo"></param>
        /// <param name="dpname"></param>
        /// <returns></returns>
        public List<LiShiConsumption> selectTJ(string begindate, string enddate, string yginfo, string dpname)
        {
            int i = 1;
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            //SqlParameter[] pms;
            string str = "";
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (yginfo.Trim() == "全部")
                {
                    if (dpname == "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "LSConsumption" + iteam.Value + "";
                            str += " where LSDate between '" + begindate + "' and '" + enddate + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                    }
                    else 
                    {
                        int id = FilterClass.dic[dpname];
                        str = "select * from LSConsumption"+id+" where LSDate between '" + begindate + "' and '" + enddate + "'";
                    }                    
                }
                else
                {
                    if (dpname == "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "LSConsumption" + iteam.Value + "";
                            str += " where LSDate between '" + begindate + "' and '" + enddate + "' and LSSalesman='" + yginfo.Trim() + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                     }
                    else
                    {
                        int id = FilterClass.dic[dpname];
                        str = "select * from LSConsumption"+id+" where LSSalesman='" + yginfo.Trim() + "' and LSDate between '" + begindate + "' and '" + enddate + "'";
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from LSConsumption"+ID+" where LSDate between '" + begindate + "' and '" + enddate + "'";
                }
                else
                {
                    str = "select * from LSConsumption" + ID + " where LSSalesman='" + yginfo.Trim() + "' and LSDate between '" + begindate + "' and '" + enddate + "'";
                }
            }            
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        //还要统计，在收活处，点了付款之后的当时就付了先进的应付金额（收入统计处的一部分）
        public List<LiShiConsumption> selectTJMoney(string begindate, string enddate, string yginfo, string dpname)
        {
            int i = 1;
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            LiShiConsumption model;
            //SqlParameter[] pms;
            string str = "";
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (yginfo.Trim() == "全部")
                {
                    if (dpname == "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "LSConsumption" + iteam.Value + "";
                            str += " where LSDate between '" + begindate + "' and '" + enddate + "' and IsXMoney='true'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);                 
                    }
                    else
                    {
                        int id = FilterClass.dic[dpname];
                        str = "select * from LSConsumption"+id+" where and IsXMoney='true' and LSDate between '" + begindate + "' and '" + enddate + "'";                        
                    }
                }
                else
                {
                    if (dpname == "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "LSConsumption" + iteam.Value + "";
                            str += " where LSDate between '" + begindate + "' and '" + enddate + "' and IsXMoney='true' and LSSalesman='" + yginfo.Trim() + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                    }
                    else
                    {
                        int id = FilterClass.dic[dpname];
                        str = "select * from LSConsumption" + id + " where and IsXMoney='true' and LSDate between '" + begindate + "' and '" + enddate + "' and LSSalesman='" + yginfo.Trim() + "'";
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from LSConsumption"+ID+" where IsXMoney='true' and LSDate between '" + begindate + "' and '" + enddate + "'";
                }
                else
                {
                    str = "select * from LSConsumption" + ID + " where and LSSalesman='" + yginfo.Trim() + "' and IsXMoney='true' and LSDate between '" + begindate + "' and '" + enddate + "'";                    
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        //删除一个历史纪录
        public bool deleteID(string id)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "delete from LSConsumption"+ID+" where ID=@id";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@id",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //根据单号查询信息   目的应该是为了补打票据
        public List<LiShiConsumption> SelectForDanNumber(string dannumber)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            if (ID == null)
            {
                return list;
            }
            LiShiConsumption model;
            //string name = FilterClass.DianPu1.UserName;
            SqlParameter[] pms;
            string str = "select * from LSConsumption"+ID+" where LSDanNumber=@LSDanNumber";
            pms = new SqlParameter[] { 
            new SqlParameter("@LSDanNumber",dannumber)
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
