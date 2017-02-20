using Commond;
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
    public class DXSendBLL
    {
        DXSendDAL dal = new DXSendDAL();
        public void AddList(List<DXmemberModel> list,string str)
        {
            string dianpu = FilterClass.DianPu1.UserName.Trim();
            string person=FilterClass.DianPu1.LoginName.Trim();
            foreach (var iteam in list)
            {
                iteam.Content = str;
                iteam.Date = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日";
                iteam.DianPu = dianpu;
                iteam.SaleMan = person;
            }
            dal.AddList(list);
        }
        public List<DXmemberModel> selectListTJ(string begindate,string enddate,string yginfo)
        {
            List<DXmemberModel> list1 = dal.selectListTJ(yginfo);
            List<DXmemberModel> list = new List<DXmemberModel>();
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
                int year = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[2].Value);
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
