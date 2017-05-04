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
    public class JCInfoDAL
    {
        public bool addJCList(List<JCInfoModel> list)
        {
            bool result = true;
            string str = "insert into JCInfoTable(jcCardNumber,jcName,jcQMoney,jcType,jcPinPai,jcColor,jcStaff,jcBeginDate,jcEndDate,jcZT,jcAddress,jcImgUrl,jcDanNumber,jcPaiNumber,jcRemark,jcQuestion,jcPression,DPName,XYF,YYF) values(@jcCardNumber,@jcName,@jcQMoney,@jcType,@jcPinPai,@jcColor,@jcStaff,@jcBeginDate,@jcEndDate,@jcZT,@jcAddress,@jcImgUrl,@jcDanNumber,@jcPaiNumber,@jcRemark,@jcQuestion,@jcPression,@DPName,@XYF,@YYF)";
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
                new SqlParameter("@jcImgUrl",iteam.jcImgUrl),
                new SqlParameter("@jcDanNumber",iteam.jcDanNumber),
                new SqlParameter("@jcPaiNumber",iteam.jcPaiNumber),
                new SqlParameter("@jcRemark",iteam.jcRemark),
                new SqlParameter("@jcQuestion",iteam.jcQuestion),
                new SqlParameter("@jcPression",iteam.jcPression),
                new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim()),
                new SqlParameter("@XYF",iteam.jcNo),
                new SqlParameter("@YYF",iteam.Tel)
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
            string str;
            List<JCInfoModel> list=new List<JCInfoModel>();
            JCInfoModel model;
            SqlParameter[] pms; 
            string dpname=FilterClass.DianPu1.UserName.Trim();
            if (type.Trim() == "全部")
            {
                if (dpname == "admin")
                {
                    str = "select * from JCInfoTable where jcZT=@jcZT";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@jcZT","未取走")
                    };
                }
                else
                {
                    str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName";
                    pms = new SqlParameter[] { 
                     new SqlParameter("@jcZT","未取走"),
                     new SqlParameter("@DPName",dpname)
                     };
                }
            }
            else
            {
                if (dpname == "admin")
                {
                    str = "select * from JCInfoTable where jcType=@jcType and jcZT=@jcZT";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@jcType",type.Trim()),
                    new SqlParameter("@jcZT","未取走")
                    };
                }
                else
                {
                    str = "select * from JCInfoTable where jcType=@jcType and jcZT=@jcZT and DPName=@DPName";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@jcType",type.Trim()),
                    new SqlParameter("@jcZT","未取走"),
                    new SqlParameter("@DPName",dpname)
                    };
                }
            }
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 寄存查找的普通查找
        /// </summary>
        /// <param name="mohu"></param>
        /// <param name="jc"></param>
        /// <param name="qz"></param>
        /// <param name="type"></param>
        /// <param name="neirong"></param>
        /// <returns></returns>
        public List<JCInfoModel> jcContentSelect(bool mohu, bool jc, bool qz, string type, string neirong)
        {            
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            int i = 1;
            if (!jc && !qz)
            {
                return list;
            }
            string type1="";
            switch (type.Trim())
            {
                case "姓名": type1 = "jcName";
                    break;
                case "卡号": type1 = "jcCardNumber";
                    break;
                //case "架号": type1 = 3;
                //    break;
                case "电话": type1 = "YYF";
                    break;
                case "品牌": type1 = "jcPinPai";
                    break;
                case "颜色": type1 = "jcColor";
                    break;
                case "单号": type1 = "jcDanNumber";
                    break;
            }
            string str="";
            SqlParameter[] pms;
            if (mohu)
            {
                //模糊查找
                if (jc && qz)
                {
                    //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                    if (dpname == "admin")
                    {
                        str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%'";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong)
                    };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and DPName=@DPName";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@DPName",dpname)
                    };
                    }
                }
                else if (jc)
                {
                    if (dpname == "admin")                        
                    {
                        str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and jcZT=@jcZT";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","未取走")
                    };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and jcZT=@jcZT and DPName=@DPName";
                    string pmstype = "@" + type1;
                    pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","未取走"),
                    new SqlParameter("@DPName",dpname)
                    };
                    }
                }
                else if (qz)
                {
                    if (dpname == "admin")
                    {
                        str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and jcZT=@jcZT";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","已取走")
                    };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and jcZT=@jcZT and DPName=@DPName";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","已取走"),
                    new SqlParameter("@DPName",dpname)
                    };
                    }
                }
                else
                {
                    if (dpname == "admin")
                    {
                        pms = new SqlParameter[] { };
                    }
                    else
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@DPName",dpname)
                    };
                    }
                }
            }
            else
            {
                //精确查找
                if (jc && qz)
                {
                    if (dpname == "admin")
                    {
                        //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                        str = "select * from JCInfoTable where " + type1 + "=@" + type1 + "";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong)
                    };
                    }
                    else
                    {
                        //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                        str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and DPName=@DPName";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                     new SqlParameter("@DPName",dpname)
                    };
                    }
                }
                else if (jc)
                {
                    if (dpname == "admin")
                    {
                        str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and jcZT=@jcZT";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","未取走")
                    };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and jcZT=@jcZT and DPName=@DPName";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","未取走"),
                     new SqlParameter("@DPName",dpname)
                    };
                    }
                }
                else if (qz)
                {
                    if (dpname == "admin")
                    {
                        str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and jcZT=@jcZT";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","已取走")
                    };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and jcZT=@jcZT and DPName=@DPName";
                        string pmstype = "@" + type1;
                        pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","已取走"),
                     new SqlParameter("@DPName",dpname)
                    };
                    }
                }
                else
                {
                    pms = new SqlParameter[] { 
                    };
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.Tel = read["YYF"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        public JCInfoModel SelectID(int id)
        {
            int i = 1;
            JCInfoModel model = new JCInfoModel();
            string str = "select * from JCInfoTable where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcID",id)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.Tel = read["YYF"].ToString();
                }
            }
            return model;
        }
        public bool QZInfo(int id)
        {
            bool result = false;
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string str = "update JCInfoTable set jcZT=@jcZT,jcEndDate=@jcEndDate where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@jcEndDate",date),
            new SqlParameter("@jcID",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateInfoModel(JCInfoModel model)
        {
            bool result = false;
            string str = "update JCInfoTable set jcName=@jcName,jcCardNumber=@jcCardNumber,jcPinPai=@jcPinPai,jcColor=@jcColor,jcQMoney=@jcQMoney,jcType=@jcType,jcStaff=@jcStaff,jcRemark=@jcRemark,jcImgUrl=@jcImgUrl where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcName",model.jcName),
            new SqlParameter("@jcCardNumber",model.jcCardNumber),
            new SqlParameter("@jcPinPai",model.jcPinPai),
            new SqlParameter("@jcColor",model.jcColor),
            new SqlParameter("@jcQMoney",model.jcQMoney),
            new SqlParameter("@jcType",model.jcType),
            new SqlParameter("@jcStaff",model.jcStaff),
            new SqlParameter("@jcRemark",model.jcRemark),
            new SqlParameter("@jcImgUrl",model.jcImgUrl),
            new SqlParameter("@jcID",model.jcID)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteIDIteam(int id)
        {
            bool result = false;
            string str = "delete from JCInfoTable where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcID",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateIDIteam(int id)
        {
            bool result = false;
            string str = "update JCInfoTable set jcZT=@jcZT where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcID",id),
            new SqlParameter("@jcZT","未取走")
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //寄存信息在统计列表中显示
        public List<JCInfoModel> selectTJ(string begindate,string enddate,string yginfo,string jctype)
        {
            string str;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (jctype.Trim() == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","未取走")
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcPression=@jcPression and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }

                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcType=@jcType and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","未取走")
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcPression=@jcPression and jcType=@jcType and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }
                }
            }
            else
            {
                if (jctype.Trim() == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
                    }
                    else 
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcPression=@jcPression and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim()),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }
                   
                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcType=@jcType and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcPression=@jcPression and jcType=@jcType and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim()),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }
                }
            }
            
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToInt32(read["XYF"]);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        //寄存取走在统计列表中显示
        public List<JCInfoModel> selectQZTJ(string begindate, string enddate, string yginfo, string jctype)
        {
            string str;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (jctype.Trim() == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","已取走")
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcPression=@jcPression and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }

                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcType=@jcType and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","已取走")
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and jcPression=@jcPression and jcType=@jcType and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }
                }
            }
            else
            {
                if (jctype.Trim() == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcPression=@jcPression and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            //new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim()),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }

                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcType=@jcType and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
                    }
                    else
                    {
                        str = "select * from JCInfoTable where jcZT=@jcZT and DPName=@DPName and jcPression=@jcPression and jcType=@jcType and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
            new SqlParameter("@jcType",jctype.Trim()),
            new SqlParameter("@jcZT","已取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim()),
            new SqlParameter("@jcPression",yginfo.Trim())
            };
                    }
                }
            }

            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToInt32(read["XYF"]);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public int seleDelete(string dianpu, string cardno, string date, string money, string staff, string pinpai, string color)
        {
            int id = 0;
            string str = "select jcID from  JCInfoTable where jcCardNumber=@jcCardNumber and DPName=@DPName and jcBeginDate=@jcBeginDate and jcQMoney=@jcQMoney and jcStaff=@jcStaff and jcPinPai=@jcPinPai and jcColor=@jcColor";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcCardNumber",cardno),
            new SqlParameter("@DPName",dianpu),
            new SqlParameter("@jcBeginDate",date),
            new SqlParameter("@jcQMoney",money),
            new SqlParameter("@jcStaff",staff),
            new SqlParameter("@jcPinPai",pinpai),
            new SqlParameter("@jcColor",color)
            };
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo != null)
            {
                id = Convert.ToInt32(oo);
            }
            return id;
        }
        public List<JCInfoModel> selectQMoney(string begindate, string enddate, string name)
        {
            int i = 1;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str;
            SqlParameter[] pms;
            if (name == "全部")
            {
                str = "select * from JCInfoTable where jcBeginDate BETWEEN '" + begindate + "' and '" + enddate + "' and jcQMoney<>@jcQMoney and jcZT=@jcZT";
                pms = new SqlParameter[] { 
            new SqlParameter("@jcQMoney","0"),
            new SqlParameter("@jcZT","未取走")
            };
            }
            else if (name == "")
            {
                str = "select * from JCInfoTable where jcBeginDate BETWEEN '" + begindate + "' and '" + enddate + "' and jcQMoney<>@jcQMoney and jcZT=@jcZT and DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@jcQMoney","0"),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName)
            };
            }
            else
            {
                str = "select * from JCInfoTable where jcBeginDate BETWEEN '" + begindate + "' and '" + enddate + "' and jcQMoney<>@jcQMoney and jcZT=@jcZT and DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@jcQMoney","0"),
            new SqlParameter("@jcZT","未取走"),
            new SqlParameter("@DPName",name)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        public List<JCInfoModel> SelectSongXi(string dpname)
        {
            int i = 1;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable where DPName=@DPName and jcAddress=@jcAddress";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname),
            new SqlParameter("@jcAddress","在店中")
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        public bool UpdateSXZT(List<int> ID)
        {
            bool result = false;
            string regx = "jcID='{0}'";
            string str = "update JCInfoTable set jcAddress=@jcAddress where ";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcAddress","送洗中")
            };
            foreach(int j in ID)
            {
                str = str + string.Format(regx, j);
                str = str + "or ";
            }
            str = str.Substring(0, str.Length - 3);
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdatePaiNumber(string ID, string bgjtm)
        {
            bool result = false;
            string str = "update JCInfoTable set jcPaiNumber=@jcPaiNumber where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcID",ID),
            new SqlParameter("@jcPaiNumber",bgjtm)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<JCInfoModel> selectExitJC(string name)
        {
            int i = 1;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable where jcAddress=@jcAddress and DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@jcAddress","工厂退回"),
            new SqlParameter("@DPName",name.Trim())
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 店面接收处加载的函数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<JCInfoModel> selectFinishJC(string name)
        {
            int i = 1;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable where (jcAddress=@jcAddress or jcAddress=@jcAddress1 or jcAddress=@jcAddress2) and DPName=@DPName and jcZT=@jcZT";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@jcAddress","送回店中"),
            new SqlParameter("@DPName",name.Trim()),
            new SqlParameter("@jcAddress1","工厂退回"),
            new SqlParameter("@jcAddress2","店铺完工"),
            new SqlParameter("@jcZT","未取走")
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.Tel = read["YYF"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        public List<JCInfoModel> selectQZ(string type, string neirong, string begindate, string enddate)
        {
            int i = 1;
            string dpname = FilterClass.DianPu1.UserName.Trim();
            List<JCInfoModel> list = new List<JCInfoModel>();
            List<JCInfoModel> list1 = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable where jcBeginDate between '" + begindate + "' and '" + enddate + "' and DPName=@DPName";
            SqlParameter[] pms=new SqlParameter[]{
            new SqlParameter("@DPName",dpname)
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    i++;
                    list.Add(model);
                }
            }
            if (type == "会员姓名")
            {
                list1 = list.Where(m => m.jcName.Trim().Contains(neirong)).ToList();
            }
            else if (type == "会员卡号")
            {
                list1 = list.Where(m => m.jcCardNumber.Trim().Contains(neirong)).ToList();
            }
            else if (type == "消费单号")
            {
                list1 = list.Where(m => m.jcDanNumber.Trim().Contains(neirong)).ToList();
            }
            else
            {
                list1 = list.Where(m => m.jcPaiNumber.Trim().Contains(neirong)).ToList();
            }
            return list1;
        }
        public bool UpdateEnd(List<int> list)
        {
            bool result = false;
            string str = "update JCInfoTable set jcAddress=@jcAddress where ";
            string fromat = "jcID='{0}'";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcAddress","店铺已收")
            };
            foreach (int id in list)
            {
                str = str + string.Format(fromat, id) + " or ";
            }
            str = str.Substring(0, str.Length - 4);
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<JCInfoModel> SelectTM(string number)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable where jcPaiNumber=@jcPaiNumber";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcPaiNumber",number)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = 1;
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 点补接受到不和个的继续送回
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateEndSend(List<int> list)
        {
            bool result = false;
            string str = "update JCInfoTable set jcAddress=@jcAddress where ";
            string fromat = "jcID='{0}'";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcAddress","在店中")
            };
            foreach (int id in list)
            {
                str = str + string.Format(fromat, id) + " or ";
            }
            str = str.Substring(0, str.Length - 4);
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<JCInfoModel> selectTJSendXi(string begindate, string enddate,string dpname)
        {
            string dpna = FilterClass.DianPu1.UserName;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str;
            SqlParameter[] pms;
            if (dpname == "全部")
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","0")
            };
            }
            else if (dpname == "")
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT and a.DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","0"),
            new SqlParameter("@DPName",dpna)
            };
            }
            else
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT and a.DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","0"),
            new SqlParameter("@DPName",dpname)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToInt32(read["XYF"]);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public List<JCInfoModel> selectTJagainSend(string begindate, string enddate,string dpname)
        {
            string dpna = FilterClass.DianPu1.UserName;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str;
            SqlParameter[] pms;
            if (dpname == "全部")
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","2")
            };
            }
            else if (dpname == "")
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT and a.DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","2"),
            new SqlParameter("@DPName",dpna)
            };
            }
            else
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT and a.DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","2"),
            new SqlParameter("@DPName",dpname)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToInt32(read["XYF"]);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public List<JCInfoModel> selectTJInDP(string begindate, string enddate, string dpname)
        {
            string dpna = FilterClass.DianPu1.UserName;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str;
            SqlParameter[] pms;
            if (dpname == "全部")
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","1")
            };
            }
            else if (dpname == "")
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT and a.DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","1"),
            new SqlParameter("@DPName",dpname)
            };
            }
            else
            {
                str = "select a.* from JCInfoTable as a join SendXI as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT=@ZT and a.DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@ZT","1"),
            new SqlParameter("@DPName",dpna)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToInt32(read["XYF"]);
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
                    model.jcDanNumber = read["jcDanNumber"].ToString();
                    model.jcPaiNumber = read["jcPaiNumber"].ToString();
                    model.jcRemark = read["jcRemark"].ToString();
                    model.jcPression = read["jcPression"].ToString();
                    model.jcQuestion = read["jcQuestion"].ToString();
                    model.lsdm = read["DPName"].ToString();
                    model.Tel = read["YYF"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public bool UpdateDPFinsh(List<int> list)
        {
            bool result = false;
            string str = "update JCInfoTable set jcAddress=@jcAddress where ";
            string fromat = "jcID='{0}'";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcAddress","店铺完工")
            };
            foreach (int id in list)
            {
                str = str + string.Format(fromat, id) + " or ";
            }
            str = str.Substring(0, str.Length - 4);
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
