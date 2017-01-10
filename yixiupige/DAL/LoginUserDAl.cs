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
            SqlDataReader read = SqlHelper.ExecuteReader("select * from LoginUser where LoginName=@name",pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    user.LoginName = read[0].ToString();
                    user.UserPwd = read[1].ToString();
                    user.UserName = read[2].ToString();
                }
            }
            return user;
        }
    }
}
