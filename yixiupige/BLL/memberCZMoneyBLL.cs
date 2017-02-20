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
            foreach (var iteam in list1)
            {
                int year = Convert.ToInt32(regex.Matches(iteam.czDate.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.czDate.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.czDate.Trim())[2].Value);
                if (year < xyear || year > dyear)
                {
                    continue;
                }
                else
                {
                    if (dyear == xyear)
                    {
                        if (month > dmonth || month < xmonth)
                        {
                            continue;
                        }
                        if (day > dday || day < xday)
                        {
                            continue;
                        }
                        list.Add(iteam);
                        continue;
                    }
                    if (year == dyear)
                    {
                        if (month > dmonth)
                        {
                            continue;
                        }
                        else if (month < dmonth)
                        {
                            list.Add(iteam);
                        }
                        else
                        {
                            if (day > dday)
                            {
                                continue;
                            }
                            else
                            {
                                list.Add(iteam);
                            }
                        }
                    }
                    else
                    {
                        if (month < xmonth)
                        {
                            continue;
                        }
                        else if (month > xmonth)
                        {
                            list.Add(iteam);
                        }
                        else
                        {
                            if (day < xday)
                            {
                                continue;
                            }
                            else
                            {
                                list.Add(iteam);
                            }
                        }
                    }
                }
            }         
            return list;
        }
    }
}
