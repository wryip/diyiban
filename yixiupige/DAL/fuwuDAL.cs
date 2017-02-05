using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class fuwuDAL
    {
        public bool AddModel(fuwuModel model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@Name",model.Name),
            new SqlParameter("@neirong",model.neirong)
            };
            string str = "insert into fuwuInfo(Name,neirong) values(@Name,@neirong)";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<fuwuModel> selectAllList()
        {
            List<fuwuModel> list = new List<fuwuModel>();
            fuwuModel model;
            string str = "select * from fuwuInfo";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new fuwuModel();
                    model.Name = read["Name"].ToString();
                    model.neirong = read["neirong"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public fuwuModel selectIteam(string name)
        {
            fuwuModel model = new fuwuModel();
            string str = "select * from fuwuInfo where Name=@Name";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@Name",name.Trim())
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model.Name = read["Name"].ToString().Trim();
                    model.neirong = read["neirong"].ToString().Trim();
                }
            }
            return model;
        }
        public bool EditModel(fuwuModel model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@neirong",model.neirong),
            new SqlParameter("@Name",model.Name)
            };
            string str = "update fuwuInfo set neirong=@neirong where Name=@Name";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteIteam(string name)
        {
            bool result = false;
            string str = "delete from fuwuInfo where Name=@Name";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@Name",name)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
