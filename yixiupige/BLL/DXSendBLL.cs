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
        public List<DXmemberModel> selectListTJ(string begindate,string enddate,string dpname)
        {
            List<DXmemberModel> list1 = dal.selectListTJ(begindate, enddate, dpname);    
            return list1;
        }
    }
}
