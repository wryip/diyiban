using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class memberCZMoneyBLL
    {
        memberCZMoneyDAL dal = new memberCZMoneyDAL();
        public bool addModel(memberToUpModel model)
        {
            return dal.addModel(model);
        }
        public List<memberToUpModel> selectAllList(string cardNo)
        {
            return dal.selectAllList(cardNo);
        }
        public bool deleteInfoModel(string cardNo)
        {
            return dal.deleteInfoModel(cardNo);
        }
        public List<memberToUpModel> selectTJ(string begindate, string enddate, string yginfo,string dpname)
        {
            List<memberToUpModel> list1 = dal.selectTJ(begindate, enddate, yginfo,dpname);
            list1 = list1.OrderByDescending(a => Convert.ToDateTime(a.czDate)).ToList();
            int count = list1.Count();
            foreach (var iteam in list1)
            {
                iteam.czXH = count--;
            }
            return list1;
        }
    }
}
