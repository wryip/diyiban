using DAL;
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
        public bool AddModel(DianPu model)
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
        public bool deleteIteam(string name)
        {
            return dal.deleteIteam(name);
        }
        public List<string> selectDPName()
        {
            return dal.selectDPName();
        }
    }
}
