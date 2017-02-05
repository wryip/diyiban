using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;

namespace BLL
{
   public  class GoodTypeInfoBll
    {
       GoodTypeInfoDal gtDal = new GoodTypeInfoDal();
       public List<string> SelecNode()
       {
           return gtDal.selectNodes();
       }
    }
}
