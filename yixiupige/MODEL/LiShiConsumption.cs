using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class LiShiConsumption
    {
        public int ID { get; set; }
        public string LSNo { get; set; }
        public string LSDanNumber { get; set; }
        public string LSName { get; set; }
        public string LSDate { get; set; }
        public string LSStaff { get; set; }
        public string LSNumberCount { get; set; }
        public string LSMoney { get; set; }
        public string LSYMoney { get; set; }
        public string LSCount { get; set; }
        public string LSPinPai { get; set; }
        public string LSColor { get; set; }
        public string LSSalesman { get; set; }
        public string LSMultipleName { get; set; }
        public string LSQuestion { get; set; }
        public string LSRemark { get; set; }        
        public string LSCardNumber { get; set; }
        public string ImgUrl { get; set; }
        //判断是不是商品，当撤销（删除记录）时将商品数量加回来
        public bool IsSP { get; set; }
        //判断是不是寄存，如属是的话，在寄存表中删除数据
        public bool IsJC { get; set; }
        //是否是现金
        public bool IsXMoney { get; set; }
    }
}
