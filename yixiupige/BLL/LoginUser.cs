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
            MODEL.LoginUser user = userdal.SelectUser(LoginName, UserPwd,UserName);
            if (user.LoginName != null)
            {
                //if (user.LoginName.Trim() == "admin" && user.UserPwd.Trim() == "admin" && user.UserName.Trim() == "admin")
                //    {
                filter(user,user.UserName);
                return true;
                //}
                //filter(user);
                //return true;
                //return false;
                
            }
            else
            {
                if (LoginName == "admin" && UserPwd == "admin" && UserName == "admin")
                {
                    user.LoginName = "admin";
                    user.UserName = "admin";
                    user.UserPwd = "admin";
                    filter(user, user.UserName);
                    return true;
                }
                return false;
            }
        }
        public void filter(MODEL.LoginUser model,string dpname)
        {
            DPInfoBLL bll = new DPInfoBLL();
            string[] pict = bll.selectPicImg(dpname);
            FilterClass.PicImg = pict[0];
            FilterClass.DXInfo = pict[1];
            FilterClass.ID = pict[2];
            FilterClass.MemberXF = pict[3];
            FilterClass.BGJPrinter = pict[4];
            FilterClass.DPTel = pict[5];
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
        public bool UpdateIteam(MODEL.LoginUser model)
        {
            return userdal.UpdateIteam(model);
        }
        public List<YGUser> SelectUserName(string dpname)
        {
            return userdal.SelectUserName(dpname);
        }
        public bool AddUserFinish(string name, List<int> list)
        {
            return userdal.AddUserFinish(name,list);
        }
        public List<JCInfoModel> YGFinish(string begindate, string enddate, string dpname)
        {
            return userdal.YGFinish(begindate, enddate, dpname);
        }
    }
}
