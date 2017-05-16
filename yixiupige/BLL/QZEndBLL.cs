using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QZEndBLL
    {
        QZDAL dal = new QZDAL();
        public bool AddIteam(WPEnd model)
        {
            return dal.AddIteam(model);
        }
        public List<WPEnd> SelectAll(string begindate, string enddate,string dpname)
        {
            return dal.SelectAll(begindate, enddate, dpname);
        }
    }
}
