using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public  class GoodTypeInfoDal
    {
       public List<string> selectNodes()
       {
           var read = SqlHelper.ExecuteReader("select GoodType from GoodTypeInfo");
           List<string> List = new List<string>();
           while (read.Read())
           {
               if (read.HasRows)
               {
                   List.Add(read[0].ToString());
               }
           }
           return List;
       }
    }
}
