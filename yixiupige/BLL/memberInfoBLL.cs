﻿using DAL;
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
        public bool AddMemberInfo(memberInfoModel model)
        {
            bool result = false;
            result=dal.AddMemberInfo(model);
            return result;
        }
        //返回莫中卡类型的所有集合，例如所有金卡或者银卡
        public List<memberInfoModel> selectInfoCollect(string cardTepe)
        {
            return dal.selectInfoCollect(cardTepe);
        }
        public bool EditMemberInfo(memberInfoModel model)
        {
            bool result = false;
            result = dal.EditMemberInfo(model);
            return result;
        }
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
                foreach (var iteam in list1)
                {
                    int year = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[0].Value);
                    int month = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[1].Value);
                    int day = Convert.ToInt32(regex.Matches(iteam.cardDate.Trim())[2].Value);
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
            }
            return list;
        }
    }
}