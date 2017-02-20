﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public class GoodInfo
    {
       public int Gid { get; set; }
       public string Gno { get; set; }
       public string Gname { get; set; }
       public string Gtype { get; set; }
       //售价
       public decimal Gprice { get; set; }
       //库存
       public int Gstock { get; set; }
       //总数
       public int Gsum { get; set; }
       public string Gremark { get; set; }
       //进价
       public decimal Gbid { get; set; }
       public int Gtypeid { get; set; }
    }
}
