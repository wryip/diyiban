using Commond;
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
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //基本参数类   要实现   admin账户设置之后   所有店铺均能显示
        //添加基本参数
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
            string str = "insert into jbcstable(text,type,DPName) values(@text,@type,@DPName)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@text",neirong),
            new SqlParameter("@type",typeclass),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //根据类型查询莫一种类型的基本参数都有什么
        public List<jbcs> selectList(int type)
        {
            List<jbcs> list = new List<jbcs>();
            jbcs model;
            string dpname=FilterClass.DianPu1.UserName.Trim();
            SqlParameter[] pms;
            string str;
                pms = new SqlParameter[] {
                 new SqlParameter("@type",type),
                  new SqlParameter("@DPName",dpname)
                 };
                str = "select text from jbcstable where type=@type and DPName=@DPName";
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
        //返回都有什么类型   寄存管理的   并且加上数量
        public List<jbcs> selectListAndCount(int type)
        {
            List<jbcs> list = new List<jbcs>();
            jbcs model;
            string dpname = FilterClass.DianPu1.UserName.Trim();
            SqlParameter[] pms;
            string str;
            pms = new SqlParameter[] {
                 new SqlParameter("@type",type),
                  new SqlParameter("@DPName",dpname)
                 };
            str = "select b.text,count(a.jcType) as aa from jbcstable as b join JCInfoTable" + ID + " as a on b.text=a.jcType where b.type=@type and b.DPName=@DPName and a.jcZT='未取走' group by a.jcType,b.text";
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new jbcs();
                    model.AllType = read["text"].ToString().Trim()+"["+read["aa"].ToString().Trim()+"]";
                    list.Add(model);
                }
            }
            return list;
        }
        public List<jbcs> selectListAndCount1(int type)
        {
            List<jbcs> list = new List<jbcs>();
            jbcs model;
            string dpname = FilterClass.DianPu1.UserName.Trim();
            SqlParameter[] pms;
            string str;
            pms = new SqlParameter[] {
                 new SqlParameter("@type",type),
                  new SqlParameter("@DPName",dpname)
                 };
            str = "select b.text,count(a.Gtype) as aa from jbcstable as b join GoodInfo" + ID + " as a on b.text=a.Gtype where b.type=@type and b.DPName=@DPName and a.DPName=@DPName group by a.Gtype,b.text";
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new jbcs();
                    model.AllType = read["text"].ToString().Trim() + "[" + read["aa"].ToString().Trim() + "]";
                    list.Add(model);
                }
            }
            return list;
        }
        public bool updateIteam(string old, string xin)
        {
            bool result = false;
            string str = "update jbcstable set text='" + xin.Trim() + "' where text='" + old.Trim() + "' and DPName='" + FilterClass.DianPu1.UserName.Trim() + "'";
            if (SqlHelper.ExecuteNonQuery(str) > 0)
            {
                result = true;
            }
            return result;
        }
        //删除莫一项基本参数
        public bool seleteIteam(string neirong)
        {
            bool result = false;
            string str = "delete jbcstable where text=@text and DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@text",neirong.Trim()),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str,pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public int CountNumber()
        {
            if (ID == null)
            {
                return 0;
            }
            string str = "select count(*) from GoodInfo" + ID + "";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(str));
        }
    }
}
