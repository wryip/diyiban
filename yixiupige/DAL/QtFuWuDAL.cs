using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QtFuWuDAL
    {
        public bool AddModel(qtFuWuModel model)
        {
            bool result = false;
            string str = "insert into QtFuWu(QtName,QtTc) values(@QtName,@QtTc)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@QtName",model.QtName),
            new SqlParameter("@QtTc",model.QtTc)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<qtFuWuModel> SelectAllList()
        {
            List<qtFuWuModel> list = new List<qtFuWuModel>();
            qtFuWuModel model;
            string str = "select * from QtFuWu";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new qtFuWuModel();
                    model.QtName = read["QtName"].ToString();
                    model.QtTc = Convert.ToInt32(read["QtTc"]);
                    list.Add(model);
                }
            }
            return list;
        }
        public bool EditModel(qtFuWuModel model)
        {
            bool result = false;
            string str = "update QtFuWu set QtTc=@QtTc where QtName=@QtName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@QtName",model.QtName),
            new SqlParameter("@QtTc",model.QtTc)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteModel(string name)
        {
            bool result = false;
            string str = "delete from QtFuWu where QtName=@QtName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@QtName",name.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<string> selectAllName()
        {
            List<string> list = new List<string>();
            string name;
            string str = "select QtName from QtFuWu";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    name = read[0].ToString().Trim();
                    list.Add(name);
                }
            }
            return list;
        }
    }
}
