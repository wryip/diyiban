using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commond
{
    public static  class FilterClass
    {
        public static LoginUser DianPu1 { get; set; }
        public static bool isadmin()
        {
            if (DianPu1.UserName == "admin" && DianPu1.UserPwd == "admin" && DianPu1.LoginName=="admin")
            {
                return true;
            }
            return false;
        }
        public static bool shgl()
        {
            if (DianPu1.shgl)
            {
                return true;
            }
            return false;
        }
        public static bool hygl()
        {
            if (DianPu1.hygl)
            {
                return true;
            }
            return false;
        }
        public static bool jcsj()
        {
            if (DianPu1.jcsj)
            {
                return true;
            }
            return false;
        }
        public static bool jcgl()
        {
            if (DianPu1.jcgl)
            {
                return true;
            }
            return false;
        }
        public static bool spgl()
        {
            if (DianPu1.spgl)
            {
                return true;
            }
            return false;
        }
        public static bool tjbb()
        {
            if (DianPu1.tjbb)
            {
                return true;
            }
            return false;
        }
        public static bool dxgl()
        {
            if (DianPu1.dxgl)
            {
                return true;
            }
            return false;
        }
        public static bool tcgl()
        {
            if (DianPu1.tcgl)
            {
                return true;
            }
            return false;
        }
        public static bool glysz()
        {
            if (DianPu1.glysz)
            {
                return true;
            }
            return false;
        }
        public static bool lsdsz()
        {
            if (DianPu1.lsdsz)
            {
                return true;
            }
            return false;
        }
        public static bool sjkgl()
        {
            if (DianPu1.sjkgl)
            {
                return true;
            }
            return false;
        }
        public static bool jbcs()
        {
            if (DianPu1.jbcs)
            {
                return true;
            }
            return false;
        }
        public static bool qtfw()
        {
            if (DianPu1.qtfw)
            {
                return true;
            }
            return false;
        }
        public static bool flgl()
        {
            if (DianPu1.flgl)
            {
                return true;
            }
            return false;
        }
        public static bool yggl()
        {
            if (DianPu1.yggl)
            {
                return true;
            }
            return false;
        }
    }
}
