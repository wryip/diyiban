using Commond;
using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CardExitMoneyBll
    {
        CardExitMoneyDal dal = new CardExitMoneyDal();
        public void AddList(List<shInfoList> list,string membername,string membernum,string cardname,string cardtype,string date)
        {
            List<CardExitMoney> list1 = new List<CardExitMoney>();
            CardExitMoney model;
            foreach (var iteam in list)
            {
                model = new CardExitMoney();
                model.cardname = cardname;
                model.cardtype = cardtype;
                model.dpname = FilterClass.DianPu1.UserName;
                model.membername = membername;
                model.membernum = membernum;
                model.LSStaff = iteam.Type + ":" + iteam.FuWuName;
                model.cardmoney = (Convert.ToDouble(iteam.CountMoney) - Convert.ToDouble(iteam.YMoney)).ToString();
                if (model.cardmoney.Trim() != "0")
                {
                    list1.Add(model);
                }                
            }
            dal.AddList(list1, date);
        }
        public List<CardExitMoney> selectTJ(string begindate,string enddate,string name)
        {
            List<CardExitMoney> list=dal.selectTJ(begindate, enddate, name);
            list=list.OrderByDescending(a=>a.ID).ToList();
            return list;
        }
        public bool deleteOnly(string membername,string membercard,string dpname,string staff,string datetime)
        {
            return dal.deleteOnly(membername, membercard, dpname, staff, datetime);
        }
    }
}
