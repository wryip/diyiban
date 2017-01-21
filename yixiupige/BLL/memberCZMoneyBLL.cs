using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class memberCZMoneyBLL
    {
        memberCZMoneyDAL dal = new memberCZMoneyDAL();
        public bool addModel(memberToUpModel model)
        {
            return dal.addModel(model);
        }
        public List<memberToUpModel> selectAllList(string cardNo)
        {
            return dal.selectAllList(cardNo);
        }
        public bool deleteInfoModel(string cardNo)
        {
            return dal.deleteInfoModel(cardNo);
        }
    }
}
