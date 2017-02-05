using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LSConsumptionBLL
    {
        LSConsumptionDAL dal = new LSConsumptionDAL();
        public bool AddList(List<LiShiConsumption> listLS)
        {
            return dal.AddList(listLS);
        }
        public List<LiShiConsumption> selectAllList(string cardNo)
        {
            return dal.selectAllList(cardNo);
        }
        //返回不大票据的信息
        public List<bdpjModel> selectBDPJ()
        {
            return dal.selectBDPJ();
        }
    }
}
