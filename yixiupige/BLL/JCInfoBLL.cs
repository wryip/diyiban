using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //寄存管理的业务处理曾
    public class JCInfoBLL
    {
        JCInfoDAL dal = new JCInfoDAL();
        public bool addJCList(List<shInfoList> list,string cardno,string name,string enddate)
        {
            List<JCInfoModel> list1 = new List<JCInfoModel>();
            JCInfoModel model;
            foreach (var iteam in list)
            {
                model = new JCInfoModel();
                model.jcCardNumber = cardno;
                model.jcName = name;
                model.jcQMoney = iteam.YMoney.ToString();
                model.jcType = iteam.Type;
                model.jcPinPai = iteam.PinPai;
                model.jcColor = iteam.Color;
                model.jcStaff = iteam.FuWuName;
                model.jcBeginDate = DateTime.Now.ToString("yyyy MM dd");
                model.jcEndDate = enddate;
                model.jcZT = "未取走";
                model.jcAddress = "在店中";
                model.jcImgUrl = iteam.ImgUrl;
                list1.Add(model);
            }
            return dal.addJCList(list1);
        }
        public List<JCInfoModel> selectAllList(string type)
        {
            return dal.selectAllList(type);
        }
    }
}
