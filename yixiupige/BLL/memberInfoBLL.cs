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
    public class memberInfoBLL
    {
        memberInfoDAL dal = new memberInfoDAL();
        //添加
        public bool AddMemberInfo(memberInfoModel model)
        {
            bool result = false;
            result=dal.AddMemberInfo(model);
            return result;
        }
        //返回某种卡类型的所有集合，例如所有金卡或者银卡
        public List<memberInfoModel> selectInfoCollect(string cardTepe)
        {
            return dal.selectInfoCollect(cardTepe);
        }
        //修改的时候进行提交
        public bool EditMemberInfo(memberInfoModel model)
        {
            bool result = false;
            result = dal.EditMemberInfo(model);
            return result;
        }
        //会员查找
        public List<memberInfoModel> hyczModel(string neirong, string tiaojian, int mouhu, string xiaodate, string dadate)
        {
            List<memberInfoModel> list = new List<memberInfoModel>();
            List<memberInfoModel> list1 = new List<memberInfoModel>();
            list1=dal.hyczModel(neirong, tiaojian, mouhu);
            if (list1.Count() == 0)
            {
                return list1;
            }
            if (xiaodate == "0" && dadate == "0")
            {
                list = list1;
            }
            else if (xiaodate != "0" && dadate == "0")
            {
                string pattern=@"[\d]+";
                Regex regex=new Regex(pattern,RegexOptions.None);
                int xyear = Convert.ToInt32(regex.Matches(xiaodate)[0].Value);
                int xmonth = Convert.ToInt32(regex.Matches(xiaodate)[1].Value);
                int xday = Convert.ToInt32(regex.Matches(xiaodate)[2].Value);
                //int xyear = Convert.ToInt32(xiaodate.Split(new char['年'], StringSplitOptions.RemoveEmptyEntries)[0]);
                //int xmonth = Convert.ToInt32(xiaodate.Split(new char['年'], StringSplitOptions.RemoveEmptyEntries)[1].Split(new char['月'], StringSplitOptions.RemoveEmptyEntries)[0]);
                //int xday = Convert.ToInt32(xiaodate.Split(new char['年'], StringSplitOptions.RemoveEmptyEntries)[1].Split(new char['月'], StringSplitOptions.RemoveEmptyEntries)[1].Split(new char['日'], StringSplitOptions.RemoveEmptyEntries)[0]);
                foreach (var iteam in list1)
                {
                    int year = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[0].Value);
                    int month = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[1].Value);
                    int day = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[2].Value);
                    if (year < xyear)
                    {
                        continue;
                    }
                    else if (year > xyear)
                    {
                        list.Add(iteam);
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
            else if (xiaodate == "0" && dadate != "0")
            {
                string pattern = @"[\d]+";
                Regex regex = new Regex(pattern, RegexOptions.None);
                int dyear = Convert.ToInt32(regex.Matches(dadate)[0].Value);
                int dmonth = Convert.ToInt32(regex.Matches(dadate)[1].Value);
                int dday = Convert.ToInt32(regex.Matches(dadate)[2].Value);
                foreach (var iteam in list1)
                {
                    int year = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[0].Value);
                    int month = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[1].Value);
                    int day = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[2].Value);
                    if (year > dyear)
                    {
                        continue;
                    }
                    else if (year < dyear)
                    {
                        list.Add(iteam);
                    }
                    else
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

                }
            }
            else
            {
                string pattern = @"[\d]+";
                Regex regex = new Regex(pattern, RegexOptions.None);
                int dyear = Convert.ToInt32(regex.Matches(dadate)[0].Value);
                int dmonth = Convert.ToInt32(regex.Matches(dadate)[1].Value);
                int dday = Convert.ToInt32(regex.Matches(dadate)[2].Value);
                int xyear = Convert.ToInt32(regex.Matches(xiaodate)[0].Value);
                int xmonth = Convert.ToInt32(regex.Matches(xiaodate)[1].Value);
                int xday = Convert.ToInt32(regex.Matches(xiaodate)[2].Value);
                DateTime bigdate = new DateTime(dyear, dmonth, dday);
                DateTime smalldate = new DateTime(xyear, xmonth, xday);
                foreach (var iteam in list1)
                {
                    int year = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[0].Value);
                    int month = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[1].Value);
                    int day = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[2].Value);
                    DateTime nowdate = new DateTime(year, month, day);
                    if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
                    {
                        list.Add(iteam);
                    }
                }
            }
            return list;
        }
        public List<memberInfoModel> tjbbOfbk(string begindate, string enddate, string yginfo)
        {
            List<memberInfoModel> list1 = dal.tjbbOfbk(yginfo);
            List<memberInfoModel> list = new List<memberInfoModel>();  
            string pattern = @"[\d]+";
            Regex regex = new Regex(pattern, RegexOptions.None);
            int dyear = Convert.ToInt32(regex.Matches(enddate)[0].Value);
            int dmonth = Convert.ToInt32(regex.Matches(enddate)[1].Value);
            int dday = Convert.ToInt32(regex.Matches(enddate)[2].Value);
            int xyear = Convert.ToInt32(regex.Matches(begindate)[0].Value);
            int xmonth = Convert.ToInt32(regex.Matches(begindate)[1].Value);
            int xday = Convert.ToInt32(regex.Matches(begindate)[2].Value);
            DateTime bigdate = new DateTime(dyear,dmonth,dday);
            DateTime smalldate = new DateTime(xyear, xmonth, xday);
            foreach (var iteam in list1)
            {
                int year = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[0].Value);
                int month = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[1].Value);
                int day = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[2].Value);
                DateTime nowdate = new DateTime(year, month, day);
                if (DateTime.Compare(smalldate, nowdate) <= 0 && DateTime.Compare(bigdate, nowdate) >= 0)
                {
                    list.Add(iteam);
                }
            }         
            return list;
        }
        //会员充值
        public bool hyczMoney(string cardno, int money)
        {
            bool result = false;
            result = dal.hyczMoney(cardno,money);
            return result;
        }
        //会员删除
        public bool deleteInfoModel(string cardNo)
        {
            return dal.deleteInfoModel(cardNo);
        }
        public List<shMemberInfo> selectForIdList(string sousuo,bool mohu)
        {
            return dal.selectForIdList(sousuo, mohu);
        }
        public memberInfoModel SelectId(string card)
        {
            return dal.SelectId(card);
        }
        //消费
        public bool XFmoney(string cardNumber, string Xmoney)
        {
            return dal.XFmoney(cardNumber, Xmoney);            
        }
        public string selectType(string cardno)
        {
            return dal.selectType(cardno);
        }
        /// <summary>
        /// 返回发送短信的内容
        /// </summary>
        /// <returns></returns>
        public List<DXmemberModel> SelectDXList()
        {
            return dal.SelectDXList();
        }
    }
}
