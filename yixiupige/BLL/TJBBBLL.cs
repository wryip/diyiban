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
        LSConsumptionDAL lidal = new LSConsumptionDAL();
        public List<TJBBSR> selectTJBB(string begindate, string enddate, string yginfo,string lbtype,string name)
        {
            List<TJBBSR> list = new List<TJBBSR>();
            List<TJBBSR> list1 = new List<TJBBSR>();
            TJBBSR model;
            //充值的钱
            List<memberToUpModel> listcz = czdal.selectTJ(begindate,enddate,yginfo);
            //办卡的钱
            List<memberInfoModel> listbk = hybkdal.tjbbOfbk(begindate, enddate, name);
            //取走寄存的时候给的钱
            //改为查询历史检查记录，将有应付金额的加进来
            List<JCInfoModel> listjc = jcdal.selectQZTJ(begindate, enddate,yginfo, lbtype);
            //还要统计，在收活处，点了付款之后的当时就付了先进的应付金额
            List<LiShiConsumption> listls = lidal.selectTJMoney(begindate, enddate, yginfo, name);
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
                model.Money = iteam.cardMoney;
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
            foreach (var iteam in listls)
            {
                model = new TJBBSR();
                model.Name = iteam.LSName.Trim() + "," + iteam.LSCardNumber.Trim() + "," + iteam.LSStaff.Trim();
                model.Date = iteam.LSDate;
                model.Money = iteam.LSYMoney;
                model.SaleMan = iteam.LSSalesman;
                model.DianPu = iteam.LSMultipleName;
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
        public List<InHuoTJ> selectListTJ(string begindate,string enddate,string yginfo,string name)
        {
            List<InHuoTJ> list1 = dal.selectListTJ(begindate, enddate,yginfo,name);
            //List<InHuoTJ> list = new List<InHuoTJ>();
            //string pattern = @"[\d]+";
            //Regex regex = new Regex(pattern, RegexOptions.None);
            //int dyear = Convert.ToInt32(regex.Matches(enddate)[0].Value);
            //int dmonth = Convert.ToInt32(regex.Matches(enddate)[1].Value);
            //int dday = Convert.ToInt32(regex.Matches(enddate)[2].Value);
            //int xyear = Convert.ToInt32(regex.Matches(begindate)[0].Value);
            //int xmonth = Convert.ToInt32(regex.Matches(begindate)[1].Value);
            //int xday = Convert.ToInt32(regex.Matches(begindate)[2].Value);
            //DateTime bigdate = new DateTime(dyear, dmonth, dday);
            //DateTime smalldate = new DateTime(xyear, xmonth, xday);
            //foreach (var iteam in list1)
            //{
            //    int year = Convert.ToInt32(regex.Matches(iteam.HuoDate.Trim())[0].Value);
            //    int month = Convert.ToInt32(regex.Matches(iteam.HuoDate.Trim())[1].Value);
            //    int day = Convert.ToInt32(regex.Matches(iteam.HuoDate.Trim())[2].Value);
            //    DateTime nowdate = new DateTime(year, month, day);
            //    if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
            //    {
            //        list.Add(iteam);
            //    }
            //}      
            return list1;
        }
        public void AddIteam(PutHuo model)
        {
            dal.AddIteam(model);
        }
        public List<PutHuo> SelectListXS(string begindate, string enddate, string yginfo,string name)
        {
            List<PutHuo> list1 = dal.SelectListXS(begindate, enddate, yginfo.Trim(), name);
            //List<PutHuo> list = new List<PutHuo>();
            //string pattern = @"[\d]+";
            //Regex regex = new Regex(pattern, RegexOptions.None);
            //int dyear = Convert.ToInt32(regex.Matches(enddate)[0].Value);
            //int dmonth = Convert.ToInt32(regex.Matches(enddate)[1].Value);
            //int dday = Convert.ToInt32(regex.Matches(enddate)[2].Value);
            //int xyear = Convert.ToInt32(regex.Matches(begindate)[0].Value);
            //int xmonth = Convert.ToInt32(regex.Matches(begindate)[1].Value);
            //int xday = Convert.ToInt32(regex.Matches(begindate)[2].Value);
            //DateTime bigdate = new DateTime(dyear, dmonth, dday);
            //DateTime smalldate = new DateTime(xyear, xmonth, xday);
            //foreach (var iteam in list1)
            //{
            //    int year = Convert.ToInt32(regex.Matches(iteam.PutDate.Trim())[0].Value);
            //    int month = Convert.ToInt32(regex.Matches(iteam.PutDate.Trim())[1].Value);
            //    int day = Convert.ToInt32(regex.Matches(iteam.PutDate.Trim())[2].Value);
            //    DateTime nowdate = new DateTime(year, month, day);
            //    if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
            //    {
            //        list.Add(iteam);
            //    }
            //}      
            return list1;
        }
        public int getIteamId(string staff, string dianpu, string cardno, string date)
        {
            return dal.getIteamId(staff, dianpu, cardno, date);
        }
        public void DeleteIteamID(int gid)
        {
            dal.DeleteIteamID(gid);
        }
        //添加送洗统计的添加
        public bool AddSendXi(List<int> list)
        {
            return dal.AddSendXi(list);
        }
        //添加店面接收统计的添加AgainSend  
        public void InDP(List<int> list)
        {
            dal.InDP(list);
        }
        public void AgainSend(List<int> list)
        {
            dal.AgainSend(list);
        }
    }
}
