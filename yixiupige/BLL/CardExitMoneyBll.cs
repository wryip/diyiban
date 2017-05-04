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
        public void AddList(List<shInfoList> list,string membername,string membernum,string cardname,string cardtype)
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
                model.cardmoney = (Convert.ToDouble(iteam.CountMoney) - Convert.ToDouble(iteam.YMoney)).ToString();
                list1.Add(model);
            }
            dal.AddList(list1);
        }
        public List<CardExitMoney> selectTJ(string begindate,string enddate,string name)
        {
            return dal.selectTJ(begindate, enddate, name);
        }
    }
}
