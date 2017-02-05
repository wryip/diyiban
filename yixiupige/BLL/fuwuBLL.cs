using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class fuwuBLL
    {
        fuwuDAL dal = new fuwuDAL();
        public bool AddModel(fuwuModel model)
        {
            return dal.AddModel(model);
        }
        public List<fuwuModel> selectAllList()
        {
            return dal.selectAllList();
        }
        public fuwuModel selectIteam(string name)
        {
            return dal.selectIteam(name);
        }
        public bool EditModel(fuwuModel model)
        {
            return dal.EditModel(model);
        }
        public bool deleteIteam(string name)
        {
            return dal.deleteIteam(name);
        }
    }
}
