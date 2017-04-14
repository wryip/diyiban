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
        public string memberName
        {
            get { return _name; }
            set { _name = value; }
        }
        //卡类型
        private string _type;
        public string memberTypechild
        {
            get { return _type; }
            set { _type = value; }
        }
        //办卡金额
        private string _cardMoney;
        public string memberCardMoney
        {
            get { return _cardMoney; }
            set { _cardMoney = value; }
        }
        //折扣
        private string _rebate;
        public string memberRebate
        {
            get { return _rebate; }
            set { _rebate = value; }
        }
        //充值金额
        private string _topUp;
        public string memberTopUp
        {
            get { return _topUp; }
            set { _topUp = value; }
        }
        //赠送比例
        private double _send;
        public double memberSend
        {
            get { return _send; }
            set { _send = value; }
        }
    }
}
