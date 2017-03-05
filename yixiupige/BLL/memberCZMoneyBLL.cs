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
        public List<memberToUpModel> selectTJ(string begindate, string enddate, string yginfo)
        {
            List<memberToUpModel> list1 = dal.selectTJ(yginfo);
            List<memberToUpModel> list = new List<memberToUpModel>();
            string pattern = @"[\d]+";
            Regex regex = new Regex(pattern, RegexOptions.None);
            int dyear = Convert.ToInt32(regex.Matches(enddate)[0].Value);
            int dmonth = Convert.ToInt32(regex.Matches(enddate)[1].Value);
            int dday = Convert.ToInt32(regex.Matches(enddate)[2].Value);
            int xyear = Convert.ToInt32(regex.Matches(begindate)[0].Value);
            int xmonth = Convert.ToInt32(regex.Matches(begindate)[1].Value);
            int xday = Convert.ToInt32(regex.Matches(begindate)[2].Value);
            DateTime bigdate = new DateTime(dyear, dmonth, dday);
            DateTime smalldate = new DateTime(xyear, xmonth, xday);
            foreach (var iteam in list1)
            {
                int year = Convert.ToInt32(regex.Matches(iteam.czDate.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.czDate.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.czDate.Trim())[2].Value);
                DateTime nowdate = new DateTime(year, month, day);
                if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
                {
                    list.Add(iteam);
                }
            }         
            return list;
        }
    }
}
