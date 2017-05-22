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
    //寄存管理的业务处理曾
    public class JCInfoBLL
    {
        JCInfoDAL dal = new JCInfoDAL();
        public bool addJCList(List<shInfoList> list,string cardno,string name,string enddate,string danNumber,string Tel,string nowdate)
        {
            List<JCInfoModel> list1 = new List<JCInfoModel>();
            JCInfoModel model;
            foreach (var iteam in list)
            {
                model = new JCInfoModel();
                model.jcCardNumber = cardno;
                model.jcName = name;
                if (iteam.FuKuan)
                {
                    model.jcQMoney = "0";
                }
                else
                {
                    model.jcQMoney = iteam.YMoney.ToString();
                }
                model.Tel = Tel;
                model.jcType = iteam.Type;
                model.jcNo = Convert.ToInt32(iteam.CountMoney);
                model.jcPinPai = iteam.PinPai;
                model.jcColor = iteam.Color;
                model.jcStaff = iteam.Type + ":" + iteam.FuWuName;
                model.jcBeginDate = nowdate;
                model.jcEndDate = enddate;
                model.jcZT = "未取走";
                model.jcAddress = "在店中";
                model.jcImgUrl = iteam.ImgUrl == null ? "" : iteam.ImgUrl;
                model.jcDanNumber = danNumber;
                model.jcPaiNumber = iteam.PaiNumber;
                model.jcRemark = iteam.Remark;
                model.jcQuestion = iteam.CJQuestion;
                model.jcPression = iteam.YMPerson;
                list1.Add(model);
            }
            return dal.addJCList(list1);
        }
        public List<JCInfoModel> selectAllList(string type)
        {
            return dal.selectAllList(type);
        }
        public List<JCInfoModel> jcDateSelect(string date,string date1, bool BeginOrEnd)
        {
            //false    为按寄存日期查询
            List<JCInfoModel> beginlist = dal.selectBeginAndEnd(date,date1,BeginOrEnd);
            return beginlist;
        }
        public List<JCInfoModel> jcContentSelect(bool mohu,bool jc,bool qz,string type,string neirong)
        {
            return dal.jcContentSelect(mohu, jc, qz, type, neirong);
        }
        public JCInfoModel SelectID(int id)
        {
            return dal.SelectID(id);
        }
        public bool QZInfo(int id)
        {
            return dal.QZInfo(id);
        }
        public bool UpdateInfoModel(JCInfoModel model)
        {
            return dal.UpdateInfoModel(model);
        }
        public bool deleteIDIteam(string id)
        {
            return dal.deleteIDIteam(Convert.ToInt32(id.Trim()));
        }

        /// <summary>
        /// 取消取走
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateIDIteam(string id)
        {
            return dal.UpdateIDIteam(Convert.ToInt32(id.Trim()));
        }
        public List<JCInfoModel> selectTJ(string begindate, string enddate, string yginfo,string jctype,string dpname)
        {
            List<JCInfoModel> list1 = dal.selectTJ(begindate, enddate, yginfo, jctype, dpname);
            return list1;
        }
        public List<JCInfoModel> selectQZTJ(string begindate, string enddate, string yginfo, string jctype,string dpname)
        {
            List<JCInfoModel> list1 = dal.selectQZTJ(begindate, enddate, yginfo, jctype, dpname);
            return list1;
        }
        public int seleDelete(string dianpu,string cardno,string date,string money,string staff,string pinpai,string color)
        {
            return dal.seleDelete(dianpu, cardno, date, money, staff, pinpai, color);
        }
        public List<JCInfoModel> selectQMoney(string begindate, string enddate,string name)
        {
            return dal.selectQMoney(begindate, enddate,name);
        }
        public List<JCInfoModel> SelectSongXi(string dpname)
        {
            return dal.SelectSongXi(dpname);
        }
        public bool UpdateSXZT(List<int> ID)
        {
            return dal.UpdateSXZT(ID);
        }
        public bool UpdatePaiNumber(string ID,string bgjtm)
        {
            return dal.UpdatePaiNumber(ID, bgjtm);
        }
        public List<JCInfoModel> selectExitJC(string name)
        {
            return dal.selectExitJC(name);
        }
        public List<JCInfoModel> selectFinishJC(string name)
        {
            return dal.selectFinishJC(name);
        }
        public List<JCInfoModel> selectQZ(string type, string neirong,bool mh)
        {
            return dal.selectQZ(type, neirong, mh);
        }
        /// <summary>
        /// 从工厂接受到的合格的将状态改为店铺已经接收
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateEnd(List<int> list)
        {
            return dal.UpdateEnd(list);
        }
        /// <summary>
        /// 根据条码找到物品
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<JCInfoModel> SelectTM(string number)
        {
            return dal.SelectTM(number);
        }
        /// <summary>
        /// 从工厂接受到的，不合格的继续送回工厂
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateEndSend(List<int> list)
        {
            return dal.UpdateEndSend(list);
        }
        public List<JCInfoModel> selectTJSendXi(string begindate, string enddate,string dpname)
        {
            return dal.selectTJSendXi(begindate, enddate,dpname);
        }
        public List<JCInfoModel> selectTJagainSend(string begindate, string enddate,string dpname)
        {
            return dal.selectTJagainSend(begindate, enddate, dpname);
        }
        public List<JCInfoModel> selectTJInDP(string begindate, string enddate,string dpname)
        {
            return dal.selectTJInDP(begindate, enddate, dpname);
        }
        public bool UpdateDPFinsh(List<int> list)
        {
            return dal.UpdateDPFinsh(list);
        }
        public List<JCInfoModel> SelectJCListForDAN(string dannumber)
        {
            return dal.SelectJCListForDAN(dannumber);
        }
        public List<JCInfoModel> FactoryExit(string name)
        {
            return dal.FactoryExit(name);
        }
        public List<JCInfoModel> selectAllPageList(string name,int pageindex, out int count)
        {
            return dal.selectAllPageList(name, pageindex, out count);
        }
        public int selectAllCount()
        {
            return dal.selectAllCount();
        }
    }
}
