using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class memberTypeDAl
    {
        public bool AddMemberType(memberType user)
        {
            bool result = false;
            SqlParameter[] pms=new SqlParameter[]{};
            if (SqlHelper.ExecuteNonQuery("",pms)>0)
            {
                result=true;
            }
            return result;
        }
    }
}
