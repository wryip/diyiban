using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.International.Converters.PinYinConverter;
namespace Commond
{
    public static  class PinYinZHClass
    {
        public static string PinYinZH(string name)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (ChineseChar.IsValidChar(name[i]))
                {
                    ChineseChar chn = new ChineseChar(name[i]);
                    if (chn.Pinyins.Count > 0)
                    {
                        string py = chn.Pinyins[0].Substring(0,1);
                        sb.Append(py);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
