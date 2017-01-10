using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class memberType
    {
        //名字
        private string _name;
        public string Name { get; set; }
        //卡类型
        private string _type;
        public string Type { get; set; }
        //办卡金额
        private string _cardMoney;
        public string CardMoney { get; set; }
        //折扣
        private string _rebate;
        public string Rebate { get; set; }
        //充值金额
        private string _topUp;
        public string TopUp { get; set; }
    }
}
