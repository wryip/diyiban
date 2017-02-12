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
        /// <summary>
        /// 登陆用户名，店铺名，密码
        /// </summary>
        /// 
        public string LoginName { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int ID { get; set; }
        //相对应个各种权限
        public bool shgl { get; set; }
        public bool hygl { get; set; }
        public bool jcsj { get; set; }
        public bool jcgl { get; set; }
        public bool spgl { get; set; }
        public bool tjbb { get; set; }
        public bool dxgl { get; set; }
        public bool tcgl { get; set; }
        public bool glysz { get; set; }
        public bool lsdsz { get; set; }
        public bool sjkgl { get; set; }
        public bool jbcs { get; set; }
        public bool qtfw { get; set; }
        public bool flgl { get; set; }
        public bool yggl { get; set; }
    }
}
