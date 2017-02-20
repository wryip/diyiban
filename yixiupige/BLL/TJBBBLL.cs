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
            foreach (var iteam in list1)
            {
                iteam.No = i.ToString();
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
                i++;
            }
            #endregion
            return list;
        }
    }
}
