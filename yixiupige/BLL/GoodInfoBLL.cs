using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BLL
{
   public class GoodInfoBLL
    {
       GoodsInfoDal gddal = new GoodsInfoDal();
       public List<GoodInfo> Getlist(GoodInfo gd)
       {
           return gddal.Getlist(gd);
       }
       public bool Add(GoodInfo gd)
       {
           return gddal.Insert(gd) > 0;
       }
       public bool Move(int id)
       {
           return gddal.Delete(id)>0;
       }
       public bool Alter(GoodInfo gd)
       {
           return gddal.Update(gd) > 0;
       }
       public bool Adds(int _add,GoodInfo gd)
       {
           return gddal.Updates(_add,gd) > 0;
       }
    }
}
