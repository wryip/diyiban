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
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加寄存信息表
        public bool addJCList(List<JCInfoModel> list)
        {
            if (ID == null)
            {
                //当不是正确账户登陆的时候，不能添加数据
                return false;
            }
            bool result = true;
            string str = "insert into JCInfoTable"+ID+"(jcCardNumber,jcName,jcQMoney,jcType,jcPinPai,jcColor,jcStaff,jcBeginDate,jcEndDate,jcZT,jcAddress,jcImgUrl,jcDanNumber,jcPaiNumber,jcRemark,jcQuestion,jcPression,DPName,XYF,YYF) values(@jcCardNumber,@jcName,@jcQMoney,@jcType,@jcPinPai,@jcColor,@jcStaff,@jcBeginDate,@jcEndDate,@jcZT,@jcAddress,@jcImgUrl,@jcDanNumber,@jcPaiNumber,@jcRemark,@jcQuestion,@jcPression,@DPName,@XYF,@YYF)";
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
        //寄存管理里面的点击tree的时候加载改成分页加载
        public List<JCInfoModel> selectAllPageList(string name, int pageindex, out int count)
        {
            count = 0;
            int i = 1;
            string str = "";
            string dpname = FilterClass.DianPu1.UserName.Trim();
            if (dpname == "admin")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select count(*) from ";
                    str += "JCInfoTable" + iteam.Value + "";
                    str += " where jcZT='未取走'";
                    if (name != "全部")
                    {
                        str += " and jcType='" + name + "'";
                    }
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
                SqlDataReader read1 = SqlHelper.ExecuteReader(str);
                while (read1.Read())
                {
                    if (read1.HasRows)
                    {
                        count += Convert.ToInt32(read1[0]);
                    }
                }
            }
            else
            {
                str = "select count(*) from JCInfoTable" + ID + " where jcZT='未取走'";
                if (name != "全部")
                {
                    str += " and jcType='" + name + "'";
                }
                object oo = SqlHelper.ExecuteScalar(str);
                count = Convert.ToInt32(oo);
            }
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            str = "";
            //SqlParameter[] pms;             
            //类型为全部
            if (name.Trim() == "全部")
            {
                if (dpname == "admin")
                {
                    foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                    {
                        str += "select top 300 * from ";
                        str += "JCInfoTable" + iteam.Value + "";
                        str += " where  jcZT='未取走' and jcID NOT IN(select TOP " + (pageindex - 1) * 300 + " jcID from JCInfoTable" + iteam.Value + " order by jcID DESC)";
                        str += " union all ";
                    }
                    str = str.Substring(0, str.Length - 10);
                }
                else
                {
                    str = "select top 300 * from JCInfoTable" + ID + " where jcZT='未取走' and jcID NOT IN(select TOP " + (pageindex - 1) * 300 + " jcID from JCInfoTable" + ID + " order by jcID DESC)";
                }
            }
            //类型为其中一个
            else
            {
                if (dpname == "admin")
                {
                    foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                    {
                        str += "select top 300 * from ";
                        str += "JCInfoTable" + iteam.Value + "";
                        str += " where jcZT='未取走' and jcType='" + name + "' and jcID NOT IN(select TOP " + (pageindex - 1) * 300 + " jcID from JCInfoTable" + iteam.Value + " order by jcID DESC)";
                        str += " union all ";
                    }
                    str = str.Substring(0, str.Length - 10);
                }
                else
                {
                    str = "select top 300 * from JCInfoTable" + ID + " where jcZT='未取走' and jcType='" + name + "' and jcID NOT IN(select TOP " + (pageindex - 1) * 300 + " jcID from JCInfoTable" + ID + " order by jcID DESC)";
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
            return list.OrderByDescending(a=>Convert.ToDateTime(a.jcBeginDate)).ToList();
        }
        public int selectAllCount()
        {
            int count = 0;
            string str = "";
            string dpname = FilterClass.DianPu1.UserName.Trim();
            if (dpname == "admin")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select count(*) from ";
                    str += "JCInfoTable" + iteam.Value + "";
                    str += " where jcZT='未取走'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
                SqlDataReader read1 = SqlHelper.ExecuteReader(str);
                while (read1.Read())
                {
                    if (read1.HasRows)
                    {
                        count += Convert.ToInt32(read1[0]);
                    }
                }
            }
            else
            {
                str = "select count(*) from JCInfoTable" + ID + " where jcZT='未取走'";
                object oo = SqlHelper.ExecuteScalar(str);
                count = Convert.ToInt32(oo);
            }
            return count;
        }
        //在寄存管理里面显示的   当点击左边节点的时候   展示的信息
        public List<JCInfoModel> selectAllList(string type)
        {
            int i = 1;
            string str="";
            List<JCInfoModel> list=new List<JCInfoModel>();
            JCInfoModel model;
            //SqlParameter[] pms; 
            string dpname=FilterClass.DianPu1.UserName.Trim();
            //类型为全部
            if (type.Trim() == "全部")
            {
                if (dpname == "admin")
                {
                    foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                    {
                        str += "select * from ";
                        str += "JCInfoTable" + iteam.Value + "";
                        str += " where jcZT='未取走'";
                        str += " union all ";
                    }
                    str = str.Substring(0, str.Length - 10);
                }
                else
                {
                    str = "select * from JCInfoTable" + ID + " where jcZT='未取走'";
                }
            }
                //类型为其中一个
            else
            {
                if (dpname == "admin")
                {
                    foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                    {
                        str += "select * from ";
                        str += "JCInfoTable" + iteam.Value + "";
                        str += " where jcType='" + type + "' and jcZT='未取走'";
                        str += " union all ";
                    }
                    str = str.Substring(0, str.Length - 10);                 
                }
                else
                {
                    str = "select * from JCInfoTable" + ID + " where jcType='" + type + "' and jcZT='未取走'";
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        /// 寄存查找的普通查找
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
            //SqlParameter[] pms;
            if (mohu)
            {
                //模糊查找
                if (jc && qz)
                {
                    if (dpname == "admin")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "JCInfoTable" + iteam.Value + "";
                            str += " where " + type1 + " like '%" + neirong + "%'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                    }
                    else
                    {
                        str = "select * from JCInfoTable"+ID+" where " + type1 + " like '%" + neirong + "%'";                       
                    }
                }
                else if (jc)
                {
                    if (dpname == "admin")                        
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "JCInfoTable" + iteam.Value + "";
                            str += " where " + type1 + " like '%" + neirong + "%' and jcZT='未取走'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                        str = "select * from JCInfoTable" + ID + " where " + type1 + " like '%" + neirong + "%' and jcZT=@jcZT";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","未取走")
                    //};
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where " + type1 + " like '%" + neirong + "%' and jcZT='未取走'";
                    //string pmstype = "@" + type1;
                    //pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","未取走"),
                    //new SqlParameter("@DPName",dpname)
                    //};
                    }
                }
                else if (qz)
                {
                    if (dpname == "admin")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "JCInfoTable" + iteam.Value + "";
                            str += " where " + type1 + " like '%" + type1 + "%' and jcZT='已取走'";
                            str += " union all ";
                        }
                        //str = str.Substring(0, str.Length - 10);
                        //str = "select * from JCInfoTable where " + type1 + " like '%'+@" + type1 + "+'%' and jcZT=@jcZT";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","已取走")
                    //};
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where " + type1 + " like '%" + neirong + "%' and jcZT='已取走'";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","已取走"),
                    //new SqlParameter("@DPName",dpname)
                    //};
                    }
                }
                //else
                //{
                    //if (dpname == "admin")
                    //{
                    //    //pms = new SqlParameter[] { };
                    //}
                    //else
                    //{
                    ////    pms = new SqlParameter[] { 
                    ////new SqlParameter("@DPName",dpname)
                    ////};
                    //}
                //}
            }
            else
            {
                //精确查找
                if (jc && qz)
                {
                    if (dpname == "admin")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "JCInfoTable" + iteam.Value + "";
                            str += " where " + type1 + "='" + neirong + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                        //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                        //str = "select * from JCInfoTable where " + type1 + "='" + neirong + "'";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong)
                    //};
                    }
                    else
                    {
                        //str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                        str = "select * from JCInfoTable"+ID+" where " + type1 + "='" + neirong + "'";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    // new SqlParameter("@DPName",dpname)
                    //};
                    }
                }
                else if (jc)
                {
                    if (dpname == "admin")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "JCInfoTable" + iteam.Value + "";
                            str += " where " + type1 + "='" + neirong + "' and jcZT='未取走'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                        //str = "select * from JCInfoTable where " + type1 + "=" + type1 + " and jcZT=@jcZT";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","未取走")
                    //};
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where " + type1 + "='" + neirong + "' and jcZT='未取走'";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","未取走"),
                    // new SqlParameter("@DPName",dpname)
                    //};
                    }
                }
                else if (qz)
                {
                    if (dpname == "admin")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "JCInfoTable" + iteam.Value + "";
                            str += " where " + type1 + "='" + neirong + "' and jcZT='已取走'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                        //str = "select * from JCInfoTable where " + type1 + "=@" + type1 + " and jcZT=@jcZT";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","已取走")
                    //};
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where " + type1 + "='" + neirong + "' and jcZT='已取走'";
                        //string pmstype = "@" + type1;
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter(pmstype,neirong),
                    //new SqlParameter("@jcZT","已取走"),
                    // new SqlParameter("@DPName",dpname)
                    //};
                    }
                }
                //else
                //{
                //    //pms = new SqlParameter[] { 
                //    //};
                //}
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        //通过id查找  数据
        public JCInfoModel SelectID(int id)
        {
            int i = 1;
            JCInfoModel model = new JCInfoModel();
            string str = "select * from JCInfoTable"+ID+" where jcID=@jcID";
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
        //在寄存管理里面的   物品取走的  
        public bool QZInfo(int id)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string str = "update JCInfoTable"+ID+" set jcZT=@jcZT,jcEndDate=@jcEndDate where jcID=@jcID";
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
        //在寄存管理里面的   修改寄存的选项
        public bool UpdateInfoModel(JCInfoModel model)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "update JCInfoTable"+ID+" set jcName=@jcName,jcCardNumber=@jcCardNumber,jcPinPai=@jcPinPai,jcColor=@jcColor,jcQMoney=@jcQMoney,jcType=@jcType,jcStaff=@jcStaff,jcRemark=@jcRemark,jcImgUrl=@jcImgUrl where jcID=@jcID";
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
        /// 删除一条记录   在寄存管理里面的   删除寄存信息
        public bool deleteIDIteam(int id)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "delete from JCInfoTable"+ID+" where jcID=@jcID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcID",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //在寄存管理中   取走寄存
        public bool UpdateIDIteam(int id)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "update JCInfoTable"+ID+" set jcZT=@jcZT where jcID=@jcID";
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
        //寄存信息在统计报表中显示
        public List<JCInfoModel> selectTJ(string begindate,string enddate,string yginfo,string jctype,string dpname)
        {
            string str="";
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            //SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (dpname == "全部")
                {
                    if (jctype.Trim() == "全部")
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcBeginDate between '" + begindate + "' and '" + enddate + "' and jcZT='未取走'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcBeginDate between '" + begindate + "' and '" + enddate + "' and jcZT='未取走' and jcPression='" + yginfo.Trim() + "'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }

                    }
                    else
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcBeginDate between '" + begindate + "' and '" + enddate + "' and jcZT='未取走' and jcType='" + jctype.Trim() + "'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcBeginDate between '" + begindate + "' and '" + enddate + "' and jcZT='未取走' and jcType='" + jctype.Trim() + "' and jcPression='" + yginfo.Trim() + "'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }
                    }
                }
                else
                {
                    int id = FilterClass.dic[dpname];
                    if (jctype.Trim() == "全部")
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='未取走' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        }
                        else
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='未取走' and jcPression='" + yginfo.Trim() + "' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        }

                    }
                    else
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='未取走' and jcType='" + jctype.Trim() + "' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        }
                        else
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='未取走' and jcPression='" + yginfo.Trim() + "' and jcType='" + jctype.Trim() + "' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                        }
                    }
                }
            }
                //不是admin的时候
            else
            {
                if (jctype.Trim() == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='未取走' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                    }
                    else 
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='未取走' and jcPression='" + yginfo.Trim() + "' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                    }
                   
                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='未取走' and jcType='" + jctype.Trim() + "' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='未取走' and jcPression='" + yginfo.Trim() + "' and jcType='" + jctype.Trim() + "' and jcBeginDate between '" + begindate + "' and '" + enddate + "'";
                    }
                }
            }
            
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToDouble(read["XYF"]);
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
        //寄存取走在统计报表中显示
        public List<JCInfoModel> selectQZTJ(string begindate, string enddate, string yginfo, string jctype, string dpname)
        {
            string str = "";
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            //SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName.Trim() == "admin")
            {
                if (dpname == "全部")
                {
                    if (jctype.Trim() == "全部")
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcEndDate between '" + begindate + "' and '" + enddate + "' and jcZT='已取走'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcEndDate between '" + begindate + "' and '" + enddate + "' and jcZT='已取走' and jcPression='" + yginfo.Trim() + "'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }

                    }
                    else
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcEndDate between '" + begindate + "' and '" + enddate + "' and jcZT='已取走' and jcType='" + jctype.Trim() + "'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                            {
                                str += "select * from ";
                                str += "JCInfoTable" + iteam.Value + "";
                                str += " where jcEndDate between '" + begindate + "' and '" + enddate + "' and jcZT='已取走' and jcType='" + jctype.Trim() + "' and jcPression='" + yginfo.Trim() + "'";
                                str += " union all ";
                            }
                            str = str.Substring(0, str.Length - 10);
                        }
                    }
                }
                else
                {
                    int id = FilterClass.dic[dpname];
                    if (jctype.Trim() == "全部")
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='已取走' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        }
                        else
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='已取走' and jcPression='" + yginfo.Trim() + "' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        }

                    }
                    else
                    {
                        if (yginfo.Trim() == "全部")
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='已取走' and jcType='" + jctype.Trim() + "' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        }
                        else
                        {
                            str = "select * from JCInfoTable" + id + " where jcZT='已取走' and jcPression='" + yginfo.Trim() + "' and jcType='" + jctype.Trim() + "' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                        }
                    }
                }
            }
            //不是admin的时候
            else
            {
                if (jctype.Trim() == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='已取走' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='已取走' and jcPression='" + yginfo.Trim() + "' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                    }

                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='已取走' and jcType='" + jctype.Trim() + "' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                    }
                    else
                    {
                        str = "select * from JCInfoTable" + ID + " where jcZT='已取走' and jcPression='" + yginfo.Trim() + "' and jcType='" + jctype.Trim() + "' and jcEndDate between '" + begindate + "' and '" + enddate + "'";
                    }
                }
            }

            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToDouble(read["XYF"]);
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
        //不记得是那个调用的此方法了....   以后知道在写上
        public int seleDelete(string dianpu, string cardno, string date, string money, string staff, string pinpai, string color)
        {
            int id = 0;
            string str = "select jcID from  JCInfoTable" + ID + " where jcCardNumber=@jcCardNumber and DPName=@DPName and jcBeginDate=@jcBeginDate and XYF=@XYF and jcStaff=@jcStaff and jcPinPai=@jcPinPai and jcColor=@jcColor";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcCardNumber",cardno),
            new SqlParameter("@DPName",dianpu),
            new SqlParameter("@jcBeginDate",date),
            new SqlParameter("@XYF",money),
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
        //统计报表中的   欠款统计方法
        public List<JCInfoModel> selectQMoney(string begindate, string enddate, string name)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str="";
            //SqlParameter[] pms;
            if (name == "全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select * from ";
                    str += "JCInfoTable" + iteam.Value + "";
                    str += " where jcBeginDate between '" + begindate + "' and '" + enddate + "' and jcQMoney<>'0' and jcZT='未取走'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
            }
            else if (name == "")
            {
                str = "select * from JCInfoTable" + ID + " where jcBeginDate BETWEEN '" + begindate + "' and '" + enddate + "' and jcQMoney<>'0' and jcZT='未取走'";
            }
            else
            {
                int id = FilterClass.dic[name];
                str = "select * from JCInfoTable where jcBeginDate" + id + " BETWEEN '" + begindate + "' and '" + enddate + "' and jcQMoney<>'0' and jcZT='未取走'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
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
        //寄存查找    按时间查找
        public List<JCInfoModel> selectBeginAndEnd(string date, string date1, bool BeginOrEnd)
        {
            int i = 1;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "";
            if (!BeginOrEnd)
            {
                str = "select * from JCInfoTable" + ID + " where jcBeginDate BETWEEN '" + date + "' and '" + date1 + "'";
            }
            else
            {
                str = "select * from JCInfoTable" + ID + " where jcEndDate BETWEEN '" + date + "' and '" + date1 + "'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        //物品送洗窗口中的   load加载的方法
        public List<JCInfoModel> SelectSongXi(string dpname)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            if (ID == null)
            {
                return list;
            }
            int i = 1;            
            JCInfoModel model;
            string str = "select * from JCInfoTable" + ID + " where jcAddress='在店中'";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        //物品送洗窗口中的   点击送洗按钮之后方法
        public bool UpdateSXZT(List<int> ID1)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string regx = "jcID='{0}'";
            string str = "update JCInfoTable"+ID+" set jcAddress=@jcAddress where ";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcAddress","送洗中")
            };
            foreach(int j in ID1)
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
        //物品送洗窗口中的   点击送洗按钮之后将生成的唯一条形码更改到物品信息中
        public bool UpdatePaiNumber(string ID, string bgjtm)
        {
            bool result = false;
            string str = "update JCInfoTable"+ID+" set jcPaiNumber=@jcPaiNumber where jcID=@jcID";
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
        //该方法   不知道是在哪里调用的
        public List<JCInfoModel> selectExitJC(string name)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            if (ID == null)
            {
                return list;
            }
            int i = 1;
            JCInfoModel model;
            string str = "select * from JCInfoTable"+ID+" where jcAddress=@jcAddress";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@jcAddress","工厂退回")
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
            List<JCInfoModel> list = new List<JCInfoModel>();
            if (ID == null)
            {
                return list;
            }         
            JCInfoModel model;
            string str = "select * from JCInfoTable" + ID + " where (jcAddress=@jcAddress or jcAddress=@jcAddress1) and jcZT=@jcZT order by jcBeginDate";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@jcAddress","送回店中"),
            //new SqlParameter("@DPName",name.Trim()),
            new SqlParameter("@jcAddress1","退回店中"),
            //new SqlParameter("@jcAddress2","店铺完工"),
            new SqlParameter("@jcZT","未取走")
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
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
                    list.Add(model);
                }
            }
            return list;
        }
        //工厂退回的信息查询
        public List<JCInfoModel> FactoryExit(string name)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            if (ID == null)
            {
                return list;
            }
            int i = 1;
            JCInfoModel model;
            string str = "select * from JCInfoTable" + ID + " where jcAddress=@jcAddress1 and jcZT=@jcZT order by jcBeginDate";
            SqlParameter[] pms = new SqlParameter[] {
            //new SqlParameter("@DPName",name.Trim()),
            new SqlParameter("@jcAddress1","退回待处理"),
            //new SqlParameter("@jcAddress2","店铺完工"),
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
        //物品取走的信息查询
        public List<JCInfoModel> selectQZ(string type, string neirong,bool mh)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            if (ID == null)
            {
                return list;
            }
            string type11 = "";
            switch (type)
            {
                case "姓名": type11 = "jcName"; break;
                case "电话": type11 = "YYF"; break;
                case "卡号": type11 = "jcCardNumber"; break;
                case "单号": type11 = "jcDanNumber"; break;
                default: type11 = "jcPaiNumber"; break;
            }
            int i = 1;
            string str = "";
            string dpname = FilterClass.DianPu1.UserName.Trim();
            JCInfoModel model;
            if (mh)
            {
                str = "select * from JCInfoTable" + ID + " where jcZT=@jcZT and " + type11 + " like '%'+@typ11+'%'";
            }
            else
            {
                str = "select * from JCInfoTable" + ID + " where jcZT=@jcZT and " + type11 + " =@typ11";
            }
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@jcZT","未取走"),
                new SqlParameter("@typ11",neirong)
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
        //店面接收
        public bool UpdateEnd(Dictionary<int, string> list)
        {
            bool result = false;
            string str = "";
            foreach (KeyValuePair<int, string> id in list)
            {
                if (id.Value.Trim() == "退回店中")
                {
                    str += "update JCInfoTable" + ID + " set jcAddress='退回待处理' where jcID='" + id.Key + "';";
                }
                else
                {
                    str += "update JCInfoTable" + ID + " set jcAddress='店铺已收' where jcID='" + id.Key + "';";
                }
            }
            //str = "update JCInfoTable"+ID+" set jcAddress=@jcAddress where ";
            //string fromat = "jcID='{0}'";
            //SqlParameter[] pms = new SqlParameter[] { 
            //new SqlParameter("@jcAddress","店铺已收")
            //};
            //foreach (KeyValuePair<int,string> id in list)
            //{
            //    str = str + string.Format(fromat, id) + " or ";
            //}
            //str = str.Substring(0, str.Length - 4);
            if (SqlHelper.ExecuteNonQuery(str) > 0)
            {
                result = true;
            }
            return result;
        }
        //查根据条码查询寄存物品  然后进行打印
        public List<JCInfoModel> SelectTM(string number)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable"+ID+" where jcPaiNumber=@jcPaiNumber";
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
        /// 店铺接受到不合格的继续送回
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateEndSend(List<int> list)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "update JCInfoTable"+ID+" set jcAddress=@jcAddress where ";
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
        //统计报表中的   送洗统计
        public List<JCInfoModel> selectTJSendXi(string begindate, string enddate,string dpname)
        {
            string dpna = FilterClass.DianPu1.UserName;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str="";            
            if (dpname == "全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select a.* from ";
                    str += "JCInfoTable" + iteam.Value + " as a join SendXI" + iteam.Value + " as b on a.jcID=b.jcID";
                    str += " where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='0'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
            }
            else if (dpname == "")
            {
                str = "select a.* from JCInfoTable"+ID+" as a join SendXI"+ID+" as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='0'";                
            }
            else
            {
                int id = FilterClass.dic[dpname];
                str = "select a.* from JCInfoTable"+id+" as a join SendXI"+id+" as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='0'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
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
        //统计报表中的返工
        public List<JCInfoModel> selectTJagainSend(string begindate, string enddate,string dpname)
        {
            string dpna = FilterClass.DianPu1.UserName;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "";
            if (dpname == "全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select a.* from ";
                    str += "JCInfoTable" + iteam.Value + " as a join SendXI" + iteam.Value + " as b on a.jcID=b.jcID";
                    str += " where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='2'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
            }
            else if (dpname == "")
            {
                str = "select a.* from JCInfoTable" + ID + " as a join SendXI" + ID + " as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='2'";
            }
            else
            {
                int id = FilterClass.dic[dpname];
                str = "select a.* from JCInfoTable" + id + " as a join SendXI" + id + " as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='2'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToDouble(read["XYF"]);
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
        //店铺接收统计
        public List<JCInfoModel> selectTJInDP(string begindate, string enddate, string dpname)
        {
            string dpna = FilterClass.DianPu1.UserName;
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "";
            if (dpname == "全部")
            {
                foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                {
                    str += "select a.* from ";
                    str += "JCInfoTable" + iteam.Value + " as a join SendXI" + iteam.Value + " as b on a.jcID=b.jcID";
                    str += " where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='1'";
                    str += " union all ";
                }
                str = str.Substring(0, str.Length - 10);
            }
            else if (dpname == "")
            {
                str = "select a.* from JCInfoTable" + ID + " as a join SendXI" + ID + " as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='1'";
            }
            else
            {
                int id = FilterClass.dic[dpname];
                str = "select a.* from JCInfoTable" + id + " as a join SendXI" + id + " as b on a.jcID=b.jcID where b.DateTime between '" + begindate + "' and '" + enddate + "' and b.ZT='1'";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new JCInfoModel();
                    model.jcNo = Convert.ToDouble(read["XYF"]);
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
        //送洗页面中的店内完成
        public bool UpdateDPFinsh(List<int> list)
        {
            if (ID == null)
            {
                return false;
            }
            bool result = false;
            string str = "update JCInfoTable"+ID+" set jcAddress=@jcAddress where ";
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
        /// <summary>
        /// 根据单号查询某些数据返回list
        /// </summary>
        /// <param name="dannumber"></param>
        /// <returns></returns>
        public List<JCInfoModel> SelectJCListForDAN(string dannumber)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            JCInfoModel model;
            string str = "select * from JCInfoTable" + ID + " where jcDanNumber=@jcDanNumber";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@jcDanNumber",dannumber)
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
    }
}
