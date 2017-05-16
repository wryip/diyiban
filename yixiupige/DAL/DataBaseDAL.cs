using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseDAL
    {
        public bool saveData(string data)
        {
            bool result = true;            
            string str = @"backup database kinyaoo123456 to disk='c:\database\" + data + ".bak'";
            SqlHelper.ExecuteNonQuery(str);
            return result;
        }
    }
}
