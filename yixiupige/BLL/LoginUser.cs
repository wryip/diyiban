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
        QQInfoBLL blls = new QQInfoBLL();
        DPInfoBLL bll = new DPInfoBLL();
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
            //在此处，将登陆的店铺合用户名存入数据可下次登陆的时候，自动选择上
            
            string[] pict = bll.selectPicImg(dpname);
            FilterClass.dic = bll.SelectAllDictionary();
            FilterClass.PicImg = pict[0];
            FilterClass.DXInfo = pict[1];
            FilterClass.ID = pict[2];
            FilterClass.MemberXF = pict[3];
            FilterClass.BGJPrinter = pict[4];
            FilterClass.DPTel = pict[5];
            //将登陆人的信息保存在过滤器中，在用户执行其他操作时进行权限过滤
            AddDPAndUser(pict[2],dpname,model.LoginName);
            FilterClass.DianPu1 = model;
            blls.InsertIpAddress();
        }
        private void AddDPAndUser(string id,string dpname,string username)
        {
            bll.AddDPAndUser(id, dpname, username);
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
