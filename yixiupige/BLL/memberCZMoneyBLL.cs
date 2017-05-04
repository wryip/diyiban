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
            List<memberToUpModel> list1 = dal.selectTJ(begindate, enddate, yginfo);
            List<memberToUpModel> list = new List<memberToUpModel>();
            if (dpname == "")
            {
                return list1;
            }
            else
            {
                foreach (var iteam in list1)
                {
                    if (iteam.dianpu.Trim() == dpname)
                    {
                        list.Add(iteam); 
                    }
                }
            }
            return list;
        }
    }
}
