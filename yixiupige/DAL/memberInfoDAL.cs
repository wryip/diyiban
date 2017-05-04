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
    public class memberInfoDAL
    {
        public bool AddMemberInfo(memberInfoModel model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@membercardNo",model.memberCardNo),
            new SqlParameter("@memberName",model.memberName),
            new SqlParameter("@memberTel",model.memberTel),
            new SqlParameter("@memberDocument",model.memberDocument),
            new SqlParameter("@birDate",SqlDbType.SmallDateTime){Value=model.birDate},
            new SqlParameter("@cardDate",SqlDbType.SmallDateTime){Value=model.cardDate},
            new SqlParameter("@memberSex",model.memberSex),
            new SqlParameter("@rebate",model.rebate),
            new SqlParameter("@endDate",SqlDbType.SmallDateTime){Value=model.endDate},
            new SqlParameter("@fuwuBate",model.fuwuBate),
            new SqlParameter("@toUpMoney",model.toUpMoney),
            new SqlParameter("@cardMoney",model.cardMoney),
            new SqlParameter("@dianName",model.dianName),
            new SqlParameter("@cardType",model.cardType),
            new SqlParameter("@salesMan",model.saleMan),
            new SqlParameter("@memberType",model.memberType),
            new SqlParameter("@address",model.address),
            new SqlParameter("@remark",model.remark),
            new SqlParameter("@imgUrl",model.imageUrl),
            new SqlParameter("@password",model.password==null?DBNull.Value.ToString():model.password),
            new SqlParameter("@zhuangtai",model.zhuangtai),
            new SqlParameter("@PY",model.PY)
            };
            string str = "insert into memberInfo(membercardNo,memberName,memberTel,memberDocument,birDate,cardDate,memberSex,rebate,endDate,fuwuBate,toUpMoney,cardMoney,dianName,cardType,salesMan,memberType,address,remark,imgUrl,password,zhuangtai,PY) values(@membercardNo,@memberName,@memberTel,@memberDocument,@birDate,@cardDate,@memberSex,@rebate,@endDate,@fuwuBate,@toUpMoney,@cardMoney,@dianName,@cardType,@salesMan,@memberType,@address,@remark,@imgUrl,@password,@zhuangtai,@PY)";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<memberInfoModel> selectInfoCollect(string cardTepe)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            int i = 1;
            List<memberInfoModel> list = new List<memberInfoModel>();
            memberInfoModel model;
            SqlDataReader read;
            SqlParameter[] pms;
            string str;
            if (cardTepe.Trim() == "全部")
            {
                if (dpname == "admin")
                {                    
                    str = "select * from memberInfo";
                    read = SqlHelper.ExecuteReader(str);
                }
                else
                {
                    pms = new SqlParameter[] { 
                    new SqlParameter("@dianName",dpname)
                };
                    str = "select * from memberInfo where dianName=@dianName";
                    read = SqlHelper.ExecuteReader(str, pms);
                }
            }
            else
            {
                if (dpname == "admin")
                {
                    pms = new SqlParameter[] { 
            new SqlParameter("@memberType",cardTepe)
            };
                    str = "select * from memberInfo where memberType=@memberType";
                    read = SqlHelper.ExecuteReader(str, pms);
                }
                else
                {
                    pms = new SqlParameter[] { 
            new SqlParameter("@memberType",cardTepe),
            new SqlParameter("@dianName",dpname)
            };
                    str = "select * from memberInfo where memberType=@memberType and dianName=@dianName";
                    read = SqlHelper.ExecuteReader(str, pms);
                }
            }           
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberInfoModel();
                    model.memberCardNo = read["memberCardNo"].ToString();
                    model.memberName = read["memberName"].ToString();
                    model.memberTel = read["memberTel"].ToString();
                    model.memberDocument = read["memberDocument"].ToString();
                    model.birDate = read["birDate"].ToString();
                    model.cardDate = read["cardDate"].ToString();
                    model.memberSex = read["memberSex"].ToString();
                    model.rebate = read["rebate"].ToString();
                    model.endDate = read["endDate"].ToString();
                    model.fuwuBate = read["fuwuBate"].ToString();
                    model.toUpMoney = read["toUpMoney"].ToString();
                    model.cardMoney = read["cardMoney"].ToString();
                    model.dianName = read["dianName"].ToString();
                    model.cardType = read["cardType"].ToString();
                    model.saleMan = read["salesMan"].ToString();
                    model.memberType = read["memberType"].ToString();
                    model.address = read["address"].ToString();
                    model.remark = read["remark"].ToString();
                    model.imageUrl = read["imgUrl"].ToString();
                    model.password = read["password"].ToString();
                    model.zhuangtai = read["zhuangtai"].ToString();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.id = i;
                    list.Add(model);
                    i++;
                }               
            }
            return list;
        }
        public bool EditMemberInfo(memberInfoModel model)
        {
            bool result = false;
            string str = "update memberInfo set memberName=@memberName,memberTel=@memberTel,memberDocument=@memberDocument,birDate=@birDate,cardDate=@cardDate,memberSex=@memberSex,rebate=@rebate,endDate=@endDate,fuwuBate=@fuwuBate,cardMoney=@cardMoney,dianName=@dianName,cardType=@cardType,salesMan=@salesMan,memberType=@memberType,address=@address,remark=@remark,imgUrl=@imgUrl,password=@password,zhuangtai=@zhuangtai where membercardNo=@membercardNo and dianName=@dianName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@membercardNo",model.memberCardNo),
            new SqlParameter("@memberName",model.memberName),
            new SqlParameter("@memberTel",model.memberTel),
            new SqlParameter("@memberDocument",model.memberDocument),
            new SqlParameter("@birDate",model.birDate),
            new SqlParameter("@cardDate",model.cardDate),
            new SqlParameter("@memberSex",model.memberSex),
            new SqlParameter("@rebate",model.rebate),
            new SqlParameter("@endDate",model.endDate),
            new SqlParameter("@fuwuBate",model.fuwuBate),
            new SqlParameter("@toUpMoney",model.toUpMoney),
            new SqlParameter("@cardMoney",model.cardMoney),
            new SqlParameter("@cardType",model.cardType),
            new SqlParameter("@salesMan",model.saleMan),
            new SqlParameter("@memberType",model.memberType),
            new SqlParameter("@address",model.address==null?DBNull.Value.ToString():model.address),
            new SqlParameter("@remark",model.remark==null?DBNull.Value.ToString():model.remark),
            new SqlParameter("@imgUrl",model.imageUrl),
            new SqlParameter("@password",model.password==null?DBNull.Value.ToString():model.password),
            new SqlParameter("@zhuangtai",model.zhuangtai),
            new SqlParameter("@dianName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        #region//会员查找
        public List<memberInfoModel> hyczModel(string neirong, string tiaojian, int mouhu)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            int i = 1;
            List<memberInfoModel> list = new List<memberInfoModel>();
            memberInfoModel model;
            SqlParameter[] pms;
            string str = "";
            switch (tiaojian)
            {
                case "姓名":
                    if (dpname == "admin")
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@memberName", neirong)
                    };
                    }
                    else
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@memberName", neirong),
                    new SqlParameter("@dianName",dpname)
                    }; 
                    }
                    if (mouhu == 1)
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                        }
                        else
                        {
                            str = "select * from memberInfo where memberName like '%'+@memberName+'%' and dianName=@dianName";
                        }
                    }
                    else
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where memberName=@memberName";
                        }
                        else
                        {
                            str = "select * from memberInfo where memberName=@memberName and dianName=@dianName";
                        }
                    }
                    break;
                case "卡号":
                    if (dpname == "admin")
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@memberCardNo", neirong)
                    };
                    }
                    else
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@memberCardNo", neirong),
                    new SqlParameter("@dianName",dpname)
                    };
                    }
                    if (mouhu == 1)
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where memberCardNo like '%'+@memberCardNo+'%'";
                        }
                        else
                        {
                            str = "select * from memberInfo where memberCardNo like '%'+@memberCardNo+'%' and dianName=@dianName";
                        }
                    }
                    else
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where memberCardNo=@memberCardNo";
                        }
                        else
                        {
                            str = "select * from memberInfo where memberCardNo=@memberCardNo and dianName=@dianName";
                        }
                    }
                    break;
                case "电话":
                    if (dpname == "admin")
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@memberTel", neirong)
                    };
                    }
                    else
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@memberTel", neirong),
                    new SqlParameter("@dianName",dpname)
                    };
                        }
                    if (mouhu == 1)
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where memberTel like '%'+@memberTel+'%'";
                        }
                        else
                        {
                            str = "select * from memberInfo where memberTel like '%'+@memberTel+'%' and dianName=@dianName";
                        }
                    }
                    else
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where memberTel=@memberTel";
                        }
                        else
                        {
                            str = "select * from memberInfo where memberTel=@memberTel and dianName=@dianName";
                        }
                    }
                    break;
                case "备注":
                    if (dpname == "admin")
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@remark", neirong)
                    };
                    }
                    else
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@remark", neirong),
                    new SqlParameter("@dianName",dpname)
                    };
                    }
                    if (mouhu == 1)
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where remark like '%'+@remark+'%'";
                        }
                        else
                        {
                            str = "select * from memberInfo where remark like '%'+@remark+'%' and dianName=@dianName";
                        }
                    }
                    else
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where remark=@remark";
                        }
                        else
                        {
                            str = "select * from memberInfo where remark=@remark and dianName=@dianName";
                        }
                    }
                    break;
                case "业务员":
                    if (dpname == "admin")
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@salesMan", neirong)
                    };
                    }
                    else
                    {
                        pms = new SqlParameter[] { 
                    new SqlParameter("@salesMan", neirong),
                    new SqlParameter("@dianName",dpname)
                    };
                    }
                    if (mouhu == 1)
                    {
                        if(dpname=="admin")
                        {
                            str = "select * from memberInfo where salesMan like '%'+@salesMan+'%'";
                        }
                        else
                        {
                            str = "select * from memberInfo where salesMan like '%'+@salesMan+'%' and dianName=@dianName";
                        }
                    }
                    else
                    {
                        if (dpname == "admin")
                        {
                            str = "select * from memberInfo where salesMan=@salesMan";
                        }
                        else
                        {
                            str = "select * from memberInfo where salesMan=@salesMan and dianName=@dianName";
                        }
                    }
                    break;
                default: pms = new SqlParameter[] { 
                    };
                    break;
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberInfoModel();
                    model.memberCardNo = read["memberCardNo"].ToString();
                    model.memberName = read["memberName"].ToString();
                    model.memberTel = read["memberTel"].ToString();
                    model.memberDocument = read["memberDocument"].ToString();
                    model.birDate = read["birDate"].ToString();
                    model.cardDate = read["cardDate"].ToString();
                    model.memberSex = read["memberSex"].ToString();
                    model.rebate = read["rebate"].ToString();
                    model.endDate = read["endDate"].ToString();
                    model.fuwuBate = read["fuwuBate"].ToString();
                    model.toUpMoney = read["toUpMoney"].ToString();
                    model.cardMoney = read["cardMoney"].ToString();
                    model.dianName = read["dianName"].ToString();
                    model.cardType = read["cardType"].ToString();
                    model.saleMan = read["salesMan"].ToString();
                    model.memberType = read["memberType"].ToString();
                    model.address = read["address"].ToString();
                    model.remark = read["remark"].ToString();
                    model.imageUrl = read["imgUrl"].ToString();
                    model.password = read["password"].ToString();
                    model.zhuangtai = read["zhuangtai"].ToString();
                    model.id = i;
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
        #endregion
        public bool hyczMoney(string cardno,int money)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@membercardNo",cardno),
            new SqlParameter("@toUpMoney",money),
            new SqlParameter("@dianName",FilterClass.DianPu1.UserName.Trim())
            };
            string str = "update memberInfo set toUpMoney=@toUpMoney where membercardNo=@membercardNo and dianName=@dianName";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteInfoModel(string scardNo)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@ID",scardNo)
            };
            string str = "delete from memberInfo where ID=@ID";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<shMemberInfo> selectForIdList(string sousuo, bool mohu)
        {
            //string dpname=FilterClass.DianPu1.UserName.Trim();
            List<shMemberInfo> list = new List<shMemberInfo>();
            string str = "";
            shMemberInfo model;
            SqlParameter[] pms;
            //if (dpname == "admin")
            //{
                pms = new SqlParameter[] { 
            new SqlParameter("@membercardNo",sousuo),
            new SqlParameter("@memberName",sousuo),
             new SqlParameter("@PY",sousuo),
            new SqlParameter("@memberTel",sousuo)
            };
            //}
            //else
            //{
            //    pms = new SqlParameter[] { 
            //new SqlParameter("@membercardNo",sousuo),
            //new SqlParameter("@memberName",sousuo),
            //new SqlParameter("@memberTel",sousuo),
            //new SqlParameter("@PY",sousuo),
            //new SqlParameter("@dianName",dpname)
            //};
            //}
            //if (mohu)
            //{
                //if (dpname == "admin")
                //{
                    str = "select * from memberInfo where membercardNo like '%'+@membercardNo+'%' or memberName like '%'+@memberName+'%' or  memberTel like '%'+@memberTel+'%' or PY like '%'+@PY+'%'";
                //}
                //else
                //{
                //    str = "select * from memberInfo where (membercardNo like '%'+@membercardNo+'%' or memberName like '%'+@memberName+'%' or  memberTel like '%'+@memberTel+'%' or PY like '%'+@PY+'%') and dianName=@dianName";
                //}
            //}
            //else
            //{
            //    if (dpname == "admin")
            //    {
            //        str = "select * from memberInfo where membercardNo=@membercardNo or memberName=@memberName or memberTel=@memberTel";
            //    }
            //    else
            //    {
            //        str = "select * from memberInfo where (membercardNo=@membercardNo or memberName=@memberName or memberTel=@memberTel) and dianName=@dianName";
            //    }
            //}
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new shMemberInfo();
                    model.Name = read["memberName"].ToString().Trim();
                    model.CardNo = read["membercardNo"].ToString().Trim();
                    model.Tel = read["memberTel"].ToString().Trim();
                    model.ID = Convert.ToInt32(read["ID"]);
                    list.Add(model);
                }
            }
            return list;
        }
        public memberInfoModel SelectId(string card)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            memberInfoModel model=new memberInfoModel();
            SqlParameter[] pms;
            if (dpname == "admin")
            {
                    pms = new SqlParameter[] { 
                new SqlParameter("@ID",card)
                };
                }
            else
            {
                    pms = new SqlParameter[] { 
                new SqlParameter("@ID",card),
                new SqlParameter("@dianName",dpname)
                };
            }
            string str;
            if (dpname == "admin")
            {
                str = "select * from memberInfo where ID=@ID";
            }
            else
                str = "select * from memberInfo where ID=@ID and dianName=@dianName";
            { 
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model.memberCardNo = read["memberCardNo"].ToString();
                    model.memberName = read["memberName"].ToString();
                    model.memberTel = read["memberTel"].ToString();
                    model.memberDocument = read["memberDocument"].ToString();
                    model.birDate = read["birDate"].ToString();
                    model.cardDate = read["cardDate"].ToString();
                    model.memberSex = read["memberSex"].ToString();
                    model.rebate = read["rebate"].ToString();
                    model.endDate = read["endDate"].ToString();
                    model.fuwuBate = read["fuwuBate"].ToString();
                    model.toUpMoney = read["toUpMoney"].ToString();
                    model.cardMoney = read["cardMoney"].ToString();
                    model.dianName = read["dianName"].ToString();
                    model.cardType = read["cardType"].ToString();
                    model.saleMan = read["salesMan"].ToString();
                    model.memberType = read["memberType"].ToString();
                    model.address = read["address"].ToString();
                    model.remark = read["remark"].ToString();
                    model.imageUrl = read["imgUrl"].ToString();
                    model.password = read["password"].ToString();
                    model.zhuangtai = read["zhuangtai"].ToString();
                }
            }
            return model;
        }
        public bool XFmoney(string cardNumber, string Xmoney)
        {
            bool result = false;
            string str = "update memberInfo set toUpMoney=@toUpMoney where membercardNo=@membercardNo and dianName=@dianName"; 
            SqlParameter[] pms=new SqlParameter[]{
            new SqlParameter("@toUpMoney",Xmoney),
            new SqlParameter("@membercardNo",cardNumber),
            new SqlParameter("@dianName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public string selectType(string cardno)
        {
            string dpname = FilterClass.DianPu1.UserName.Trim();
            SqlParameter[] pms;
            if (dpname == "admin")
            {
                pms = new SqlParameter[] { 
            new SqlParameter("@memberCardNo",cardno)
            };
            }
            else
            {
                pms = new SqlParameter[] { 
            new SqlParameter("@memberCardNo",cardno),
            new SqlParameter("@dianName",dpname)
            };
            }
            string str;
            if (dpname == "admin")
            {
                str = "select memberType from memberInfo where memberCardNo=@memberCardNo";
            }
            else
            {
                str = "select memberType from memberInfo where memberCardNo=@memberCardNo and dianName=@dianName";
            }
            object obj=SqlHelper.ExecuteScalar(str, pms);
            string read = obj == null ? "无卡" : obj.ToString();
            return read;
        }
        public List<DXmemberModel> SelectDXList()
        {
            string dpname = FilterClass.DianPu1.UserName.Trim();
            int i = 1;
            List<DXmemberModel> list = new List<DXmemberModel>();
            DXmemberModel model;
            string str;
            SqlParameter[] pms;
            if (dpname == "admin")
            {
                str = "select memberCardNo,memberName,memberTel from memberInfo";
                pms = new SqlParameter[] {  };
            }
            else
            {
                str = "select memberCardNo,memberName,memberTel from memberInfo where dianName=@dianName";
                pms = new SqlParameter[] { 
            new SqlParameter("@dianName",dpname)
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new DXmemberModel();
                    model.No = i;
                    model.CardNumber = read["memberCardNo"].ToString();
                    model.MemberName = read["MemberName"].ToString();
                    model.TelPhone = read["memberTel"].ToString();
                    model.SendInfo = false;
                    i++;
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 统计报表中的办卡统计方法
        /// </summary>
        /// <param name="yginfo">查看某一个员工还是所有员工如果admin登陆则所有的店铺的信息均能看到
        /// <returns></returns>
        public List<memberInfoModel> tjbbOfbk(string begindate, string enddate, string dpname)
        {
            int i = 1;
            List<memberInfoModel> list = new List<memberInfoModel>();
            memberInfoModel model;
            string dpinfo = FilterClass.DianPu1.UserName.Trim();
            string str = "";
            SqlParameter[] pms;
            if (dpinfo == "admin")
            {
                if (dpname == "全部")
                {
                    str = "select * from memberInfo cardDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { };
                }
                else
                {
                    str = "select * from memberInfo where dianName=@dianName and  cardDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@dianName",dpname)
                    };
                }
            }
            else
            {
                str = "select * from memberInfo where dianName=@dianName and  cardDate between '" + begindate + "' and '" + enddate + "'";
                pms = new SqlParameter[] { 
                    new SqlParameter("@dianName",dpinfo)
                    };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberInfoModel();
                    model.id = i;
                    model.memberCardNo = read["memberCardNo"].ToString();
                    model.memberName = read["memberName"].ToString();
                    model.memberTel = read["memberTel"].ToString();
                    model.memberDocument = read["memberDocument"].ToString();
                    model.birDate = read["birDate"].ToString();
                    model.cardDate = read["cardDate"].ToString();
                    model.memberSex = read["memberSex"].ToString();
                    model.rebate = read["rebate"].ToString();
                    model.endDate = read["endDate"].ToString();
                    model.fuwuBate = read["fuwuBate"].ToString();
                    model.toUpMoney = read["toUpMoney"].ToString();
                    model.cardMoney = read["cardMoney"].ToString();
                    model.dianName = read["dianName"].ToString();
                    model.cardType = read["cardType"].ToString();
                    model.saleMan = read["salesMan"].ToString();
                    model.memberType = read["memberType"].ToString();
                    model.address = read["address"].ToString();
                    model.remark = read["remark"].ToString();
                    model.imageUrl = read["imgUrl"].ToString();
                    model.password = read["password"].ToString();
                    model.zhuangtai = read["zhuangtai"].ToString();
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
    }
}
