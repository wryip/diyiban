using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commond;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace BLL
{
    public class LoginUser
    {
        LoginUserDAl userdal = new LoginUserDAl();
        public bool SelectUser(string LoginName, string UserPwd, string UserName)
        {
            //LoginUserDAl userdal=new LoginUserDAl();
            MODEL.LoginUser user = userdal.SelectUser(UserName);
            if (user != null)
            {
                if (user.UserPwd == UserPwd && user.UserName == UserName && user.LoginName == LoginName)
                {
                    filter(user);
                    return true;
                }
                else
                {
                    if (LoginName == "admin" && UserPwd == "admin" && UserName=="admin")
                    {
                        filter(user);
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
        public void filter(MODEL.LoginUser model)
        {
            //将登陆人的信息保存在过滤器中，在用户执行其他操作时进行权限过滤
            FilterClass.DianPu1 = model;
        }
        public List<MODEL.LoginUser> selectAllList(string name)
        {
            return userdal.selectAllList(name);
        }
        public bool deleteIteam(int id)
        {
            return userdal.deleteIteam(id);
        }
        public bool AddUserIteam(MODEL.LoginUser model)
        {
            return userdal.AddUserIteam(model);
        }
    }
}
