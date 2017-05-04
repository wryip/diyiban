using Commond;
using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class LSConsumptionBLL
    {
        LSConsumptionDAL dal = new LSConsumptionDAL();
        memberInfoDAL dalm = new memberInfoDAL();
        memberCZMoneyDAL dalcz = new memberCZMoneyDAL();
        memberTypeDAl bldal = new memberTypeDAl();
        public bool AddList(List<LiShiConsumption> listLS)
        {
            return dal.AddList(listLS);
        }
        public List<LiShiConsumption> selectAllList(string cardNo,string name)
        {
            return dal.selectAllList(cardNo, name);
        }
        public List<LiShiConsumption> selectAllListSK(string skname,string sktel, string name)
        {
            return dal.selectAllListSK(skname, sktel, name);
        }
        //返回不大票据的信息
        public List<bdpjModel> selectBDPJ(string name, string cardno, string tel)
        {
            return dal.selectBDPJ(name, cardno, tel);
        }
        public List<LiShiConsumption> selectTJ(string begindate,string enddate,string yginfo,string dpname)
        {
            //LiShiConsumption model;
            //此list是将上篇消费合寄存消费等历史纪录添加了进来，还需要添加，办卡合充值卡，此为所有的消费
            List<LiShiConsumption> list1 = dal.selectTJ(begindate, enddate, yginfo, dpname);            
            //办卡集合
            //int count=list1.Count;
            #region //办卡的集合加入
            //List<memberInfoModel> list = dalm.tjbbOfbk(begindate, enddate, dpname);
            //foreach (var iteam in list)
            //{
            //    model = new LiShiConsumption();
            //    model.ID = iteam.ID;
            //    model.LSNo = (++count).ToString();
            //    model.LSName = iteam.memberName;
            //    model.LSDate = iteam.cardDate;
            //    model.LSStaff = "会员办卡";
            //    model.LSCardNumber = iteam.memberCardNo;
            //    model.LSMoney = iteam.cardMoney;
            //    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    model.LSYMoney = iteam.cardMoney;
            //    model.LSCount = "1";
            //    model.LSPinPai = iteam.cardType;
            //    model.LSColor = "";
            //    model.LSSalesman = iteam.saleMan;
            //    model.LSMultipleName = iteam.dianName;
            //    model.LSQuestion = "";
            //    model.LSRemark = iteam.remark;
            //    model.LSDanNumber = "";
            //    model.LSNumberCount = "";
            //    model.ImgUrl = "";
            //    model.IsSP = false;
            //    model.IsJC = false;
            //    list1.Add(model);
            //} 
            //#endregion
            ////充值加入集合
            //#region //充值统计
            //List<memberToUpModel> listcz = dalcz.selectTJ(begindate, enddate, yginfo);
            //foreach (var iteam in listcz)
            //{
            //    //double bate = 0;
            //    model = new LiShiConsumption();
            //    model.ID = iteam.czId;
            //    model.LSNo = (++count).ToString();
            //    model.LSName = iteam.czName;
            //    model.LSDate = iteam.czDate;
            //    model.LSStaff = "会员充值";
            //    model.LSCardNumber = iteam.czNo;
            //    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    model.LSYMoney = iteam.czMoney;
            //    model.LSMoney = iteam.czMoney;
            //    //if (bate == 0)
            //    //{
            //    //    bate = Convert.ToDouble(bldal.selectBL(iteam.czType.Trim()));
            //    //    model.LSMoney = (Convert.ToInt32(iteam.czMoney) / bate).ToString();
            //    //}                
            //    model.LSCount = "1";
            //    model.LSPinPai = iteam.czType;
            //    model.LSColor = "";
            //    model.LSSalesman = iteam.czSaleman;
            //    model.LSMultipleName = iteam.dianpu;
            //    model.LSQuestion = "";
            //    model.LSRemark = "";
            //    model.LSDanNumber = "";
            //    model.LSNumberCount = "";
            //    model.ImgUrl = "";
            //    model.IsSP = false;
            //    model.IsJC = false;
            //    list1.Add(model);
            //} 
            #endregion
            return list1;
        }
        public List<LiShiConsumption> SelectForDanNumber(string dannumber)
        {
            return dal.SelectForDanNumber(dannumber);
        }
        public bool deleteID(string id)
        {
            return dal.deleteID(id);
        }
    }
}
