﻿using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DPInfoBLL
    {
        DPInfoDAL dal = new DPInfoDAL();
        public int AddModel(DianPu model)
        {
            return dal.AddModel(model);
        }
        public List<DianPu> selectAllList()
        {
            return dal.selectAllList();
        }
        public bool UpdateModel(DianPu model)
        {
            return dal.UpdateModel(model);
        }
        public bool deleteIteam(int id)
        {
            return dal.deleteIteam(id);
        }
        public List<string> selectDPName()
        {
            return dal.selectDPName();
        }
        public string[] selectPicImg(string name)
        {
            return dal.selectPicImg(name);
        }
        public void UpdateDay(int day)
        {
            dal.UpdateDay(day);
        }
        public string[] selectNumberAndNo(string dpname)
        {
            return dal.selectNumberAndNo(dpname);
        }
        public bool uodateNumber(string dpID, int j)
        {
            return dal.uodateNumber(dpID, j);
        }
        //当添加新的店铺的时候,添加相对应要用到的表
        public void AddTable(int id)
        {
            dal.AddTable(id);
        }
        public Dictionary<string, int> SelectAllDictionary()
        {
            return dal.SelectAllDictionary();
        }
    }
}
