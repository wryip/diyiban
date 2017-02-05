using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QtFuWuBLL
    {
        QtFuWuDAL dal = new QtFuWuDAL();
        public bool AddModel(qtFuWuModel model)
        {
            return dal.AddModel(model);
        }
        public List<qtFuWuModel> SelectAllList()
        {
            return dal.SelectAllList();
        }
        public bool EditModel(qtFuWuModel model)
        {
            return dal.EditModel(model);
        }
        public bool deleteModel(string name)
        {
            return dal.deleteModel(name);
        }
        public List<string> selectAllName()
        {
            return dal.selectAllName();
        }
    }
}
