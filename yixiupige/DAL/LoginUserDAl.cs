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
        public LoginUser SelectUser(string name)
        {
            LoginUser user=new LoginUser();           
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",name)
            };
            SqlDataReader read = SqlHelper.ExecuteReader("select * from LoginUser where UserName=@name", pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    user.LoginName = read["LoginName"].ToString();
                    user.UserPwd = read["UserPwd"].ToString();
                    user.UserName = read["UserName"].ToString();
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
            SqlParameter[] pms = new SqlParameter[] { };
            return result;
        }
    }
}
