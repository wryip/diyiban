using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExitDanBLL
    {
        ExitDanDAL dal = new ExitDanDAL();
        public void AddExitDan(ExitDanModel model)
        {
            dal.AddExitDan(model);
        }
        public List<ExitDanModel> SelectAllList(string begindate,string enddate,string dpname)
        {
            List<ExitDanModel> list=dal.SelectAllList(begindate, enddate, dpname);
            list=list.OrderByDescending(a=>Convert.ToDateTime(a.ExitDanTime)).ToList();
            return list;
        }
    }
}
