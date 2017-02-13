using MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginUserDAl
    {       
        //登陆的业务处理
        public LoginUser SelectUser(string loginuser,string pwd,string name)
        {
            LoginUser user=new LoginUser();           
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",name),
            new SqlParameter("@LoginName",loginuser),
            new SqlParameter("@UserPwd",pwd)
            };
            SqlDataReader read = SqlHelper.ExecuteReader("select * from LoginUser where UserName=@name and LoginName=@LoginName and UserPwd=@UserPwd", pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    user.LoginName = read["LoginName"].ToString();
                    user.UserPwd = read["UserPwd"].ToString();
                    user.UserName = read["UserName"].ToString();
                    user.shgl = Convert.ToBoolean(read["shgl"]);
                    user.hygl = Convert.ToBoolean(read["hygl"]);
                    user.jcgl = Convert.ToBoolean(read["jcgl"]);
                    user.jcsj = Convert.ToBoolean(read["jcsj"]);
                    user.spgl = Convert.ToBoolean(read["spgl"]);
                    user.tjbb = Convert.ToBoolean(read["tjbb"]);
                    user.dxgl = Convert.ToBoolean(read["dxgl"]);
                    user.tcgl = Convert.ToBoolean(read["tcgl"]);
                    user.glysz = Convert.ToBoolean(read["glysz"]);
                    user.lsdsz = Convert.ToBoolean(read["lsdsz"]);
                    user.sjkgl = Convert.ToBoolean(read["sjkgl"]);
                    user.jbcs = Convert.ToBoolean(read["jbcs"]);
                    user.qtfw = Convert.ToBoolean(read["qtfw"]);
                    user.flgl = Convert.ToBoolean(read["flgl"]);
                    user.yggl = Convert.ToBoolean(read["yggl"]);
                }
            }
            return user;
        }
        public List<LoginUser> selectAllList(string name)
        {
            List<LoginUser> list = new List<LoginUser>();
            LoginUser model;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",name)
            };
            SqlDataReader read = SqlHelper.ExecuteReader("select * from LoginUser where UserName=@name", pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new LoginUser();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.UserPwd = read["UserPwd"].ToString();
                    model.LoginName = read["LoginName"].ToString();
                    model.UserName = read["UserName"].ToString();
                    model.shgl = Convert.ToBoolean(read["shgl"]);
                    model.hygl = Convert.ToBoolean(read["hygl"]);
                    model.jcgl = Convert.ToBoolean(read["jcgl"]);
                    model.jcsj = Convert.ToBoolean(read["jcsj"]);
                    model.spgl = Convert.ToBoolean(read["spgl"]);
                    model.tjbb = Convert.ToBoolean(read["tjbb"]);
                    model.dxgl = Convert.ToBoolean(read["dxgl"]);
                    model.tcgl = Convert.ToBoolean(read["tcgl"]);
                    model.glysz = Convert.ToBoolean(read["glysz"]);
                    model.lsdsz = Convert.ToBoolean(read["lsdsz"]);
                    model.sjkgl = Convert.ToBoolean(read["sjkgl"]);
                    model.jbcs = Convert.ToBoolean(read["jbcs"]);
                    model.qtfw = Convert.ToBoolean(read["qtfw"]);
                    model.flgl = Convert.ToBoolean(read["flgl"]);
                    model.yggl = Convert.ToBoolean(read["yggl"]);
                    list.Add(model);
                }
            }
            return list;
        }
        public bool deleteIteam(int id)
        {
            bool result = false;
            string str = "delete from LoginUser where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@ID",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms)>0)
            {
                result = true;
            }
            return result;
        }
        public bool AddUserIteam(MODEL.LoginUser model)
        {
            bool result = false;
            string str = "insert into LoginUser(LoginName,UserPwd,UserName,shgl,hygl,jcsj,jcgl,spgl,tjbb,dxgl,tcgl,glysz,lsdsz,sjkgl,jbcs,qtfw,flgl,yggl) values(@LoginName,@UserPwd,@UserName,@shgl,@hygl,@jcsj,@jcgl,@spgl,@tjbb,@dxgl,@tcgl,@glysz,@lsdsz,@sjkgl,@jbcs,@qtfw,@flgl,@yggl)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@LoginName",model.LoginName),
            new SqlParameter("@UserPwd",model.UserPwd),
            new SqlParameter("@UserName",model.UserName),
            new SqlParameter("@shgl",model.shgl),
            new SqlParameter("@hygl",model.hygl),
            new SqlParameter("@jcsj",model.jcsj),
            new SqlParameter("@jcgl",model.jcgl),
            new SqlParameter("@spgl",model.spgl),
            new SqlParameter("@tjbb",model.tjbb),
            new SqlParameter("@dxgl",model.dxgl),
            new SqlParameter("@tcgl",model.tcgl),
            new SqlParameter("@glysz",model.glysz),
            new SqlParameter("@lsdsz",model.lsdsz),
            new SqlParameter("@sjkgl",model.sjkgl),
            new SqlParameter("@jbcs",model.jbcs),
            new SqlParameter("@qtfw",model.qtfw),
            new SqlParameter("@flgl",model.flgl),
            new SqlParameter("@yggl",model.yggl)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateIteam(MODEL.LoginUser model)
        {
            bool result = false;
            string str = "update LoginUser set LoginName=@LoginName,UserPwd=@UserPwd,UserName=@UserName,shgl=@shgl,hygl=@hygl,jcsj=@jcsj,jcgl=@jcgl,spgl=@spgl,tjbb=@tjbb,dxgl=@dxgl,tcgl=@tcgl,glysz=@glysz,lsdsz=@lsdsz,sjkgl=@sjkgl,jbcs=@jbcs,qtfw=@qtfw,flgl=@flgl,yggl=@yggl where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@LoginName",model.LoginName),
            new SqlParameter("@UserPwd",model.UserPwd),
            new SqlParameter("@UserName",model.UserName),
            new SqlParameter("@shgl",model.shgl),
            new SqlParameter("@hygl",model.hygl),
            new SqlParameter("@jcsj",model.jcsj),
            new SqlParameter("@jcgl",model.jcgl),
            new SqlParameter("@spgl",model.spgl),
            new SqlParameter("@tjbb",model.tjbb),
            new SqlParameter("@dxgl",model.dxgl),
            new SqlParameter("@tcgl",model.tcgl),
            new SqlParameter("@glysz",model.glysz),
            new SqlParameter("@lsdsz",model.lsdsz),
            new SqlParameter("@sjkgl",model.sjkgl),
            new SqlParameter("@jbcs",model.jbcs),
            new SqlParameter("@qtfw",model.qtfw),
            new SqlParameter("@flgl",model.flgl),
            new SqlParameter("@yggl",model.yggl),
            new SqlParameter("@ID",model.ID)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
