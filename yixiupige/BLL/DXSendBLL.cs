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
            DateTime bigdate = new DateTime(dyear, dmonth, dday);
            DateTime smalldate = new DateTime(xyear, xmonth, xday);
            foreach (var iteam in list1)
            {
                int year = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[2].Value);
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
