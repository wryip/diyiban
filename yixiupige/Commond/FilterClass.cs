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
        public static string PicImg { get; set; }
        public static string DXInfo { get; set; }
        public static string ID { get; set; }
        public static string DPTel { get; set; }
        public static string MemberXF { get; set; }
        public static string BGJPrinter { get; set; }
        public static bool isadmin()
        {
            if (DianPu1.UserName.Trim() == "admin" && DianPu1.UserPwd.Trim() == "admin" && DianPu1.LoginName.Trim()=="admin")
            {
                return true;
            }
            return false;
        }
        public static bool shgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.shgl)
            {
                return true;
            }
            return false;
        }
        public static bool hygl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.hygl)
            {
                return true;
            }
            return false;
        }
        public static bool jcsj()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.jcsj)
            {
                return true;
            }
            return false;
        }
        public static bool jcgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.jcgl)
            {
                return true;
            }
            return false;
        }
        public static bool spgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.spgl)
            {
                return true;
            }
            return false;
        }
        public static bool dmjs()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.dmjs)
            {
                return true;
            }
            return false;
        }
        public static bool tjbb()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.tjbb)
            {
                return true;
            }
            return false;
        }
        public static bool dxgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.dxgl)
            {
                return true;
            }
            return false;
        }
        public static bool tcgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.tcgl)
            {
                return true;
            }
            return false;
        }
        public static bool glysz()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.glysz)
            {
                return true;
            }
            return false;
        }
        public static bool lsdsz()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.lsdsz)
            {
                return true;
            }
            return false;
        }
        public static bool sjkgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.sjkgl)
            {
                return true;
            }
            return false;
        }
        public static bool jbcs()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.jbcs)
            {
                return true;
            }
            return false;
        }
        public static bool qtfw()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.qtfw)
            {
                return true;
            }
            return false;
        }
        public static bool flgl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.flgl)
            {
                return true;
            }
            return false;
        }
        public static bool yggl()
        {
            if (isadmin())
            {
                return true;
            }
            if (DianPu1.yggl)
            {
                return true;
            }
            return false;
        }
    }
}
