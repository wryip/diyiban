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
        public bool AddMember(memberType model)
        {
            bool result = false;
            memberTypeDAl memberdal = new memberTypeDAl();
            result=memberdal.AddMemberType(model);
            return result;
        }
    }
}
