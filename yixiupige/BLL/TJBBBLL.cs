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
    public class TJBBBLL
    {
        TJBBDAL dal = new TJBBDAL();
        memberCZMoneyDAL czdal = new memberCZMoneyDAL();
        memberInfoDAL hybkdal = new memberInfoDAL();
        JCInfoDAL jcdal = new JCInfoDAL();
        public List<TJBBSR> selectTJBB(string begindate, string enddate, string yginfo,string lbtype)
        {
            List<TJBBSR> list = new List<TJBBSR>();
            List<TJBBSR> list1 = new List<TJBBSR>();
            TJBBSR model;
            List<memberToUpModel> listcz = czdal.selectTJ(yginfo);
            List<memberInfoModel> listbk = hybkdal.tjbbOfbk(yginfo);
            List<JCInfoModel> listjc = jcdal.selectQZTJ(yginfo, lbtype);
            #region//将数据首先存放在list1中
            foreach (var iteam in listcz)
            {
                model = new TJBBSR();
                model.Name = "会员充值，姓名[" + iteam.czName.Trim() + "],卡号[" + iteam.czNo.Trim() + "]";
                model.Date = iteam.czDate;
                model.Money = iteam.czMoney;
                model.SaleMan = iteam.czSaleman;
                model.DianPu = iteam.dianpu;
                list1.Add(model);
            }
            foreach (var iteam in listbk)
            {
                model = new TJBBSR();
                model.Name = "会员办卡，姓名[" + iteam.memberName.Trim() + "],卡号[" + iteam.memberCardNo.Trim() + "]";
                model.Date = iteam.cardDate;
                model.Money = iteam.toUpMoney;
                model.SaleMan = iteam.saleMan;
                model.DianPu = iteam.dianName;
                list1.Add(model);
            }
            foreach (var iteam in listjc)
            {
                model = new TJBBSR();
                model.Name = iteam.jcName.Trim() + "," + iteam.jcCardNumber.Trim() + "," + iteam.jcStaff.Trim();
                model.Date = iteam.jcBeginDate;
                model.Money = iteam.jcQMoney;
                model.SaleMan = iteam.jcPression;
                model.DianPu = iteam.lsdm;
                list1.Add(model);
            }
            #endregion
            #region//时间过滤
            string pattern = @"[\d]+";
            int i = 1;
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
                iteam.No = i.ToString();
                int year = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.Date.Trim())[2].Value);
                DateTime nowdate = new DateTime(year, month, day);
                if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
                {
                    list.Add(iteam);
                }                
                i++;
            }
            #endregion
            return list;
        }
        public void AddIteam(InHuoTJ jinhuo)
        {
            dal.AddIteam(jinhuo);
        }
        public List<InHuoTJ> selectListTJ(string begindate,string enddate,string yginfo)
        {
            List<InHuoTJ> list1 = dal.selectListTJ(yginfo);
            List<InHuoTJ> list = new List<InHuoTJ>();
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
                int year = Convert.ToInt32(regex.Matches(iteam.HuoDate.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.HuoDate.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.HuoDate.Trim())[2].Value);
                DateTime nowdate = new DateTime(year, month, day);
                if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
                {
                    list.Add(iteam);
                }
            }      
            return list;
        }
        public void AddIteam(PutHuo model)
        {
            dal.AddIteam(model);
        }
        public List<PutHuo> SelectListXS(string begindate, string enddate, string yginfo)
        {
            List<PutHuo> list1 = dal.SelectListXS(yginfo.Trim());
            List<PutHuo> list = new List<PutHuo>();
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
                int year = Convert.ToInt32(regex.Matches(iteam.PutDate.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.PutDate.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.PutDate.Trim())[2].Value);
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
