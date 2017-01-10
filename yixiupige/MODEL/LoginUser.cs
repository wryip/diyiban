using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    //用户登录类
    public class LoginUser
    {
        private string _loginName;
        private string _userName;
        private string _userPwd;
        public string LoginName {
            get { return _loginName; }
            set { _loginName = value; }
            }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
    }
}
