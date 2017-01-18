﻿using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class memberTypeDAl
    {
        public bool AddMemberType(memberType user)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",user.memberName),
            new SqlParameter("@memberType",user.memberTypechild),
            new SqlParameter("@memberCardMoney",user.memberCardMoney),
            new SqlParameter("@memberRebate",user.memberRebate),
            new SqlParameter("@memberTopUp",user.memberTopUp)
            };
            if (SqlHelper.ExecuteNonQuery("insert into memberType(memberName,memberType,memberCardMoney,memberRebate,memberTopUp) values(@memberName,@memberType,@memberCardMoney,@memberRebate,@memberTopUp)", pms) > 0)
            {
                result=true;
            }
            return result;
        }
        //查询一个对象的详细信息
        public memberType EditMember(string name)
        {
            memberType result = new memberType();
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",name)
            };
            var read= SqlHelper.ExecuteReader("select * from memberType where memberName=@memberName", pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    result.memberName = read[0].ToString();
                    result.memberTypechild = read[1].ToString();
                    result.memberCardMoney = read[2].ToString();
                    result.memberRebate = read[3].ToString();
                    result.memberTopUp = read[4].ToString();
                }
            }
            return result;
        }
        public bool EditMemberUp(memberType user)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",user.memberName),
            new SqlParameter("@memberType",user.memberTypechild),
            new SqlParameter("@memberCardMoney",user.memberCardMoney),
            new SqlParameter("@memberRebate",user.memberRebate),
            new SqlParameter("@memberTopUp",user.memberTopUp)
            };
            if (SqlHelper.ExecuteNonQuery("update memberType set memberType=@memberType,memberCardMoney=@memberCardMoney,memberRebate=@memberRebate,memberTopUp=@memberTopUp where memberName=@memberName", pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteinfo(string name)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",name)
            };
            if (SqlHelper.ExecuteNonQuery("delete from memberType where memberName=@memberName", pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<string> selectNodes()
        {
            var read = SqlHelper.ExecuteReader("select memberName from memberType");
            List<string> List = new List<string>();
            while (read.Read())
            {
                if (read.HasRows)
                {
                    List.Add(read[0].ToString());
                }
            }
            return List;
        }
    }
}