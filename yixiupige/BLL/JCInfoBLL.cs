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
        public bool addJCList(List<shInfoList> list,string cardno,string name,string enddate,string danNumber)
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
                model.jcDanNumber = danNumber;
                model.jcPaiNumber = iteam.PaiNumber;
                model.jcRemark = iteam.Remark;
                list1.Add(model);
            }
            return dal.addJCList(list1);
        }
        public List<JCInfoModel> selectAllList(string type)
        {
            return dal.selectAllList(type);
        }
        public List<JCInfoModel> jcDateSelect(string date, bool BeginOrEnd)
        {
            List<JCInfoModel> beginlist=dal.selectAllList("全部");
            List<JCInfoModel> endlist=new List<JCInfoModel>();
            string pattern = @"[\d]+";
            Regex regex = new Regex(pattern, RegexOptions.None);
            int xyear = Convert.ToInt32(regex.Matches(date)[0].Value);
            int xmonth = Convert.ToInt32(regex.Matches(date)[1].Value);
            int xday = Convert.ToInt32(regex.Matches(date)[2].Value);
            if (BeginOrEnd)
            {                
                //结束时间
                foreach (var iteam in beginlist)
                {
                    int dyear = Convert.ToInt32(regex.Matches(iteam.jcEndDate)[0].Value);
                    int dmonth = Convert.ToInt32(regex.Matches(iteam.jcEndDate)[1].Value);
                    int dday = Convert.ToInt32(regex.Matches(iteam.jcEndDate)[2].Value);
                    if (xyear == dyear && xmonth == dmonth && xday == dday)
                    {
                        endlist.Add(iteam);
                    }
                }
            }
            else 
            {
                //开始时间
                foreach (var iteam in beginlist)
                {
                    int dyear = Convert.ToInt32(iteam.jcBeginDate.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)[0]);
                    int dmonth = Convert.ToInt32(iteam.jcBeginDate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    int dday = Convert.ToInt32(iteam.jcBeginDate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2]);
                    if (xyear == dyear && xmonth == dmonth && xday == dday)
                    {
                        endlist.Add(iteam);
                    }
                }
            }
            return endlist;
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
    }
}
