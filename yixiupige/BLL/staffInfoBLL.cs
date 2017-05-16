using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class staffInfoBLL
    {
        staffTableDAL dal=new staffTableDAL();
        public bool AddInfoModel(staffTable model)
        {
            return dal.AddInfoModel(model);
        }
        public List<staffTable> selectAllList()
        {
            return dal.selectAllList();
        }
        public bool updateModel(staffTable model)
        {
            return dal.updateModel(model);
        }
        public bool deleteIteam(int id)
        {
            return dal.deleteIteam(id);
        }
        public List<jbcs> selectSH()
        {
            return dal.selectSH();
        }
        public List<jbcs> selectDNWC(string dpname)
        {
            return dal.selectDNWC(dpname);
        }
    }
}
