﻿using MODEL;
using System;
using System.Collections.Generic;
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
            new SqlParameter("@birDate",model.birDate),
            new SqlParameter("@cardDate",model.cardDate),
            new SqlParameter("@memberSex",model.memberSex),
            new SqlParameter("@rebate",model.rebate),
            new SqlParameter("@endDate",model.endDate),
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
            new SqlParameter("@zhuangtai",model.zhuangtai)
            };
            string str = "insert into memberInfo(membercardNo,memberName,memberTel,memberDocument,birDate,cardDate,memberSex,rebate,endDate,fuwuBate,toUpMoney,cardMoney,dianName,cardType,salesMan,memberType,address,remark,imgUrl,password,zhuangtai) values(@membercardNo,@memberName,@memberTel,@memberDocument,@birDate,@cardDate,@memberSex,@rebate,@endDate,@fuwuBate,@toUpMoney,@cardMoney,@dianName,@cardType,@salesMan,@memberType,@address,@remark,@imgUrl,@password,@zhuangtai)";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<memberInfoModel> selectInfoCollect(string cardTepe)
        {
            int i = 1;
            List<memberInfoModel> list = new List<memberInfoModel>();
            memberInfoModel model;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberType",cardTepe)
            };
            string str = "select * from memberInfo where memberType=@memberType";
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberInfoModel();
                    model.memberCardNo = read[0].ToString();
                    model.memberName = read[1].ToString();
                    model.memberTel = read[2].ToString();
                    model.memberDocument = read[3].ToString();
                    model.birDate = read[4].ToString();
                    model.cardDate = read[5].ToString();
                    model.memberSex = read[6].ToString();
                    model.rebate = read[7].ToString();
                    model.endDate = read[8].ToString();
                    model.fuwuBate = read[9].ToString();
                    model.toUpMoney = read[10].ToString();
                    model.cardMoney = read[11].ToString();
                    model.dianName = read[12].ToString();
                    model.cardType = read[13].ToString();
                    model.saleMan = read[14].ToString();
                    model.memberType = read[15].ToString();
                    model.address = read[16].ToString();
                    model.remark = read[17].ToString();
                    model.imageUrl = read[18].ToString();
                    model.password = read[19].ToString();
                    model.zhuangtai = read[20].ToString();
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
            string str = "update memberInfo set memberName=@memberName,memberTel=@memberTel,memberDocument=@memberDocument,birDate=@birDate,cardDate=@cardDate,memberSex=@memberSex,rebate=@rebate,endDate=@endDate,fuwuBate=@fuwuBate,cardMoney=@cardMoney,dianName=@dianName,cardType=@cardType,salesMan=@salesMan,memberType=@memberType,address=@address,remark=@remark,imgUrl=@imgUrl,password=@password,zhuangtai=@zhuangtai where membercardNo=@membercardNo";
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
            new SqlParameter("@dianName",model.dianName),
            new SqlParameter("@cardType",model.cardType),
            new SqlParameter("@salesMan",model.saleMan),
            new SqlParameter("@memberType",model.memberType),
            new SqlParameter("@address",model.address==null?DBNull.Value.ToString():model.address),
            new SqlParameter("@remark",model.remark==null?DBNull.Value.ToString():model.remark),
            new SqlParameter("@imgUrl",model.imageUrl),
            new SqlParameter("@password",model.password==null?DBNull.Value.ToString():model.password),
            new SqlParameter("@zhuangtai",model.zhuangtai)
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
            int i = 1;
            List<memberInfoModel> list = new List<memberInfoModel>();
            memberInfoModel model;
            SqlParameter[] pms;
            string str = "";
            switch (tiaojian)
            {
                case "姓名":
                    pms = new SqlParameter[] { 
                    new SqlParameter("@memberName", neirong)
                    };                    
                    if (mouhu == 1)
                    {
                        str = "select * from memberInfo where memberName like '%'+@memberName+'%'";
                    }
                    else
                    {
                        str = "select * from memberInfo where memberName=@memberName";
                    }
                    break;
                case "卡号":
                    pms = new SqlParameter[] { 
                    new SqlParameter("@memberCardNo", neirong)
                    };
                    if (mouhu == 1)
                    {
                        str = "select * from memberInfo where memberCardNo like '%'+@memberCardNo+'%'";
                    }
                    else
                    {
                        str = "select * from memberInfo where memberCardNo=@memberCardNo";
                    }
                    break;
                case "电话":
                    pms = new SqlParameter[] { 
                    new SqlParameter("@memberTel", neirong)
                    };
                    if (mouhu == 1)
                    {
                        str = "select * from memberInfo where memberTel like '%'+@memberTel+'%'";
                    }
                    else
                    {
                        str = "select * from memberInfo where memberTel=@memberTel";
                    }
                    break;
                case "备注":
                    pms = new SqlParameter[] { 
                    new SqlParameter("@remark", neirong)
                    };
                    if (mouhu == 1)
                    {
                        str = "select * from memberInfo where remark like '%'+@remark+'%'";
                    }
                    else
                    {
                        str = "select * from memberInfo where remark=@remark";
                    }
                    break;
                case "业务员":
                    pms = new SqlParameter[] { 
                    new SqlParameter("@salesMan", neirong)
                    };
                    if (mouhu == 1)
                    {
                        str = "select * from memberInfo where salesMan like '%'+@salesMan+'%'";
                    }
                    else
                    {
                        str = "select * from memberInfo where salesMan=@salesMan";
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
                    model.memberCardNo = read[0].ToString();
                    model.memberName = read[1].ToString();
                    model.memberTel = read[2].ToString();
                    model.memberDocument = read[3].ToString();
                    model.birDate = read[4].ToString();
                    model.cardDate = read[5].ToString();
                    model.memberSex = read[6].ToString();
                    model.rebate = read[7].ToString();
                    model.endDate = read[8].ToString();
                    model.fuwuBate = read[9].ToString();
                    model.toUpMoney = read[10].ToString();
                    model.cardMoney = read[11].ToString();
                    model.dianName = read[12].ToString();
                    model.cardType = read[13].ToString();
                    model.saleMan = read[14].ToString();
                    model.memberType = read[15].ToString();
                    model.address = read[16].ToString();
                    model.remark = read[17].ToString();
                    model.imageUrl = read[18].ToString();
                    model.password = read[19].ToString();
                    model.zhuangtai = read[20].ToString();
                    model.id = i;
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
        #endregion
    }
}