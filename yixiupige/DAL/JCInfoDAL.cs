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
            string str = "insert into JCInfoTable(jcCardNumber,jcName,jcQMoney,jcType,jcPinPai,jcColor,jcStaff,jcBeginDate,jcEndDate,jcZT,jcAddress,jcImgUrl,jcDanNumber,jcPaiNumber,jcRemark) values(@jcCardNumber,@jcName,@jcQMoney,@jcType,@jcPinPai,@jcColor,@jcStaff,@jcBeginDate,@jcEndDate,@jcZT,@jcAddress,@jcImgUrl,@jcDanNumber,@jcPaiNumber,@jcRemark)";
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
                new SqlParameter("@jcRemark",iteam.jcRemark)
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
            string str = "select * from JCInfoTable where jcType=@jcType and jcZT=@jcZT";
            if (type.Trim() == "全部")
            {
                str = "select * from JCInfoTable where jcZT=@jcZT";
            }
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcType",type.Trim()),
            new SqlParameter("@jcZT","未取走")
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
                case "牌号": type1 = "jcPaiNumber";
                    break;
                case "品牌": type1 = "jcPinPai";
                    break;
                case "颜色": type1 = "jcColor";
                    break;
                case "单号": type1 = "jcDanNumber";
                    break;
            }
            string str="";
            string zt = "";
            SqlParameter[] pms;
            if (mohu)
            {
                //模糊查找
                if (jc && qz)
                {
                    //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                    str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%'";
                    string pmstype = "@" + type1;
                    pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong)
                    };
                }
                else if (jc)
                {
                    str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and jcZT=@jcZT";
                    string pmstype = "@" + type1;
                    pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","未取走")
                    };
                }
                else if (qz)
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
                    pms = new SqlParameter[] { };
                }
            }
            else
            {
                //精确查找
                if (jc && qz)
                {
                    //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                    str = "select * from JCInfoTable where " + type1 + "=@"+type1;
                    string pmstype = "@" + type1;
                    pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong)
                    };
                }
                else if (jc)
                {
                    str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and jcZT=@jcZT";
                    string pmstype = "@" + type1;
                    pms = new SqlParameter[] { 
                    new SqlParameter(pmstype,neirong),
                    new SqlParameter("@jcZT","未取走")
                    };
                }
                else if (qz)
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
                    pms = new SqlParameter[] { };
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
                }
            }
            return model;
        }
        public bool QZInfo(int id)
        {
            bool result = false;
            string date = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日";
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
    }
}
