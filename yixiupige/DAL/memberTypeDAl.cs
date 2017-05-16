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
    public class memberTypeDAl
    {
        //添加会员类别
        public bool AddMemberType(memberType user)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",user.memberName),
            new SqlParameter("@memberType",user.memberTypechild),
            new SqlParameter("@memberCardMoney",user.memberCardMoney),
            new SqlParameter("@memberRebate",user.memberRebate),
            new SqlParameter("@memberTopUp",user.memberTopUp),
            new SqlParameter("@memberSend",user.memberSend),
             new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery("insert into memberType(memberName,memberType,memberCardMoney,memberRebate,memberTopUp,DPName,memberSend) values(@memberName,@memberType,@memberCardMoney,@memberRebate,@memberTopUp,@DPName,@memberSend)", pms) > 0)
            {
                result=true;
            }
            return result;
        }
        //查询一个对象的详细信息
        public memberType EditMember(string name)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            memberType result = new memberType();
            SqlParameter[] pms;
            string str;
            //if (dpname == "admin")
            //{
            //    pms = new SqlParameter[] { 
            //new SqlParameter("@memberName",name)
            //};
            //    str = "select * from memberType where memberName=@memberName";
            //}
            //else
            //{
                pms = new SqlParameter[] { 
            new SqlParameter("@memberName",name),
            new SqlParameter("@DPName",dpname)
            };
                str = "select * from memberType where memberName=@memberName and DPName=@DPName";
            //}
            var read = SqlHelper.ExecuteReader(str, pms);
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
        //修改一个会员信息类别
        public bool EditMemberUp(memberType user)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",user.memberName),
            new SqlParameter("@memberType",user.memberTypechild),
            new SqlParameter("@memberCardMoney",user.memberCardMoney),
            new SqlParameter("@memberRebate",user.memberRebate),
            new SqlParameter("@memberTopUp",user.memberTopUp),
            new SqlParameter("@memberSend",user.memberSend),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery("update memberType set memberType=@memberType,memberCardMoney=@memberCardMoney,memberRebate=@memberRebate,memberTopUp=@memberTopUp,memberSend=@memberSend where memberName=@memberName and DPName=@DPName", pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //删除某一条记录
        public bool deleteinfo(string name)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",name),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery("delete from memberType where memberName=@memberName and DPName=@DPName", pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //查询一共有多少种会员卡的类别
        public List<string> selectNodes()
        {
            List<string> list = new List<string>();
            string dpname = FilterClass.DianPu1.UserName.Trim();
            if (dpname == "admin")
            {
                return list;
            }
            string str;
            SqlParameter[] pms;
            str = "select memberName from memberType where DPName=@DPName";
            pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname)
            };
            var read = SqlHelper.ExecuteReader(str, pms);
            
            while (read.Read())
            {
                if (read.HasRows)
                {
                    list.Add(read[0].ToString());
                }
            }
            return list;
        }
        //查询所有的会员 类型   合会员类型所带的书数量
        public List<string> selectNodesAddCount()
        {
            List<string> list = new List<string>();
            string dpname = FilterClass.DianPu1.UserName.Trim();
            if (dpname == "admin")
            {
                return list;
            }
            string str;
            SqlParameter[] pms;
            str = "select a.memberName,count(b.memberType) as aa from memberType as a join memberInfo as b on a.memberName=b.memberType where a.DPName=@DPName group by a.memberName,b.memberType";
            pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname)
            };
            var read = SqlHelper.ExecuteReader(str, pms);

            while (read.Read())
            {
                if (read.HasRows)
                {
                    list.Add(read["memberName"].ToString().Trim() + "[" + read["aa"].ToString().Trim() + "]");
                }
            }
            return list;
        }
        //查询所有的信息
        public List<memberType> SelectAllList(string name)
        {
            List<memberType> list = new List<memberType>();
            memberType model;
            string str = "select * from memberType where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",name)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new memberType();
                    model.memberCardMoney = read["memberCardMoney"].ToString();
                    model.memberRebate = read["memberRebate"].ToString();
                    model.memberTopUp = read["memberTopUp"].ToString();
                    model.memberTypechild = read["memberType"].ToString();
                    model.memberName = read["memberName"].ToString();
                    model.memberSend = Convert.ToDouble(read["memberSend"].ToString().Trim());
                    list.Add(model);
                }
            }
            return list;
        }
        //查询某张卡  对应的比例
        public double selectBL(string bl)
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            string str = "select memberSend from memberType where DPName=@DPName and memberName=@memberName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname),
            new SqlParameter("@memberName",bl)
            };
            //if (dpname == "admin")
            //{
            //    str = "select memberSend from memberType where memberName=@memberName";
            //    pms = new SqlParameter[] { 
            //new SqlParameter("@memberName",bl)
            //};
            //}
            
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo != null)
            {
                return Convert.ToDouble(oo);
            }
            return 1.0;
        }
        //返回折扣卡的折扣
        public int selectZK(string name)
        {
            string dpname = FilterClass.DianPu1.UserName;
            string str = "select memberRebate from memberType where memberName=@memberName and DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@memberName",name),
            new SqlParameter("@DPName",dpname)
            };
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo != null)
            {
                return Convert.ToInt32(oo);
            }
            return 0;
        }
    }
}
