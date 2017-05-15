using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class jbcsBLL
    {
        jbcsDAL dal = new jbcsDAL();
        public bool addIteam(string neirong, string type)
        {
            return dal.addIteam(neirong, type);
        }
        public List<jbcs> selectList(int type)
        {
            return dal.selectList(type);
        }
        public List<jbcs> selectListAndCount(int type)
        {
            return dal.selectListAndCount(type);
        }
        public List<jbcs> selectListAndCount1(int type)
        {
            return dal.selectListAndCount1(type);
        }
        public bool updateIteam(string old, string xin)
        {
            return dal.updateIteam(old, xin);
        }
        public bool seleteIteam(string neirong)
        {
            return dal.seleteIteam(neirong);
        }
        public int CountNumber()
        {
            return dal.CountNumber();
        }
        //public List<string> selectnode()
        //{
        //    return dal.selectNodes();
        //}
    }
}
