using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class jbcsDAL
    {
        public bool addIteam(string neirong, string type)
        {
            int typeclass=0;
            bool result = false;
            switch (type.Trim())
            {
                case "品牌分类": typeclass = 1;
                    break;
                case "颜色分类": typeclass = 2;
                    break;
                case "常见问题": typeclass = 3;
                    break;
                case "商品分类": typeclass = 4;
                    break;
                case "寄存分类": typeclass = 5;
                    break;
                case "员工分类": typeclass = 6;
                    break;
            }
            string str = "insert into jbcstable(text,type) values(@text,@type)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@text",neirong),
            new SqlParameter("@type",typeclass)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<jbcs> selectList(int type)
        {
            List<jbcs> list = new List<jbcs>();
            jbcs model;
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@type",type)
            };
            string str = "select text from jbcstable where type=@type";
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new jbcs();
                    model.AllType = read["text"].ToString().Trim();
                    list.Add(model);
                }
            }
            return list;
        }
        public bool updateIteam(string old, string xin)
        {
            bool result = false;
            string str = "update jbcstable set text='" + xin.Trim() + "' where text='" + old .Trim()+ "'";
            if (SqlHelper.ExecuteNonQuery(str) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool seleteIteam(string neirong)
        {
            bool result = false;
            string str = "delete jbcstable where text=@text";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@text",neirong.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str,pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
