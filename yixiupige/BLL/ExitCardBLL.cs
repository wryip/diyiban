using Commond;
using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 要编写退卡记录的添加
    /// </summary>
    public class ExitCardBLL
    {
        ExitCardDAL dal = new ExitCardDAL();
        public bool ExitCard(ExitCardModel model)
        {
            string dpname = FilterClass.DianPu1.UserName.Trim();
            model.DPName = dpname;
            return dal.ExitCard(model);
        }
        public List<ExitCardModel> SelectAllList(string begindate,string enddate,string dpname)
        {
            return dal.SelectAllList(begindate, enddate, dpname);
        }
    }
}
