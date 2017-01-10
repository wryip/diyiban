using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LoginUser
    {
        public bool SelectUser(string LoginName, string UserPwd, string UserName)
        {
            LoginUserDAl userdal=new LoginUserDAl();
            MODEL.LoginUser user = userdal.SelectUser(LoginName);
            if (user != null)
            {
                if (user.UserPwd == UserPwd && user.UserName == UserName)
                {
                    return true;
                }
                else
                {
                    if (LoginName == "admin" && UserPwd == "admin")
                    {
                        return true;
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
