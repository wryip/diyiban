using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class memberTypeCURD
    {
        memberTypeDAl memberdal = new memberTypeDAl();
        public bool AddMember(memberType model)
        {
            bool result = false;            
            result=memberdal.AddMemberType(model);
            return result;
        }
        //查询一个对象的详细信息
        public memberType EditMember(string name)
        {
            return memberdal.EditMember(name);
        }
        public bool EditMemberUp(memberType model)
        {
            bool result = false;
            result = memberdal.EditMemberUp(model);
            return result;
        }
        public bool deleteinfo(string name)
        {
            bool result = false;
            result = memberdal.deleteinfo(name);
            return result;
        }
        public List<string> selectNodes()
        {
            return memberdal.selectNodes();
        }
        public List<memberType> SelectAllList(string name)
        {
            return memberdal.SelectAllList(name);
        }
        public double selectBL(string bl)
        {
            return memberdal.selectBL(bl);
        }
        /// <summary>
        /// 返回折扣卡所对应的折扣
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int selectZK(string name)
        {
            return memberdal.selectZK(name);
        }
    }
}
