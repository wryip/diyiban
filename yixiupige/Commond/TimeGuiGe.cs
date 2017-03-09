using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commond
{
    public static class TimeGuiGe
    {
        public static string TimePicter(string str)
        {
            string pattern = @"[\d]+";
            Regex regex = new Regex(pattern, RegexOptions.None);
            string year;
            string month;
            string day;
            string sum;
            year = regex.Matches(str)[0].Value;
            month = regex.Matches(str)[1].Value;
            day = regex.Matches(str)[2].Value;
            //if (month.Length == 1)
            //{
            //    month = "0" + month;
            //}
            //if (day.Length == 1)
            //{
            //    day = "0" + day;
            //}
            sum = year + "-" + month + "-" + day + " 00:00:00";
            return sum;
        }
    }
}
