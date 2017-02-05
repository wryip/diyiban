using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class staffTableDAL
    {
        public bool AddInfoModel(staffTable model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@stName",model.stName),
            new SqlParameter("@stDocument",model.stDocument),
            new SqlParameter("@stSex",model.stSex),
            new SqlParameter("@stTel",model.stTel),
            new SqlParameter("@stType",model.stType),
            new SqlParameter("@stAdd",model.stAdd),
            new SqlParameter("@stRemark",model.stRemark)
            };
            string str = "insert into staffTable(stName,stDocument,stSex,stTel,stType,stAdd,stRemark) values(@stName,@stDocument,@stSex,@stTel,@stType,@stAdd,@stRemark)";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<staffTable> selectAllList()
        {
            List<staffTable> list = new List<staffTable>();
            staffTable model;
            string str = "select * from staffTable";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new staffTable();
                    model.Id = Convert.ToInt32(read["Id"]);
                    model.stName = read["stName"].ToString();
                    model.stDocument = read["stDocument"].ToString();
                    model.stSex = read["stSex"].ToString();
                    model.stTel = read["stTel"].ToString();
                    model.stType = read["stType"].ToString();
                    model.stAdd = read["stAdd"].ToString();
                    model.stRemark = read["stRemark"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public bool updateModel(staffTable model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@stName",model.stName),
            new SqlParameter("@stDocument",model.stDocument),
            new SqlParameter("@stSex",model.stSex),
            new SqlParameter("@stTel",model.stTel),
            new SqlParameter("@stAdd",model.stAdd),
            new SqlParameter("@stRemark",model.stRemark),
            new SqlParameter("@Id",model.Id),
            new SqlParameter("@stType",model.stType)
            };
            string str = "update staffTable set stName=@stName,stDocument=@stDocument,stSex=@stSex,stTel=@stTel,stType=@stType,stAdd=@stAdd,stRemark=@stRemark where Id=@Id";
            if (SqlHelper.ExecuteNonQuery(str, pms)>0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteIteam(int id)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@Id",id)
            };
            string str = "delete from staffTable where Id=@Id";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 给收活管理的页面上返回数据
        /// </summary>
        /// <returns></returns>
        public List<jbcs> selectSH()
        {
            List<jbcs> list = new List<jbcs>();
            jbcs model;
            string str = "select stName from staffTable";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new jbcs();
                    model.AllType = read["stName"].ToString().Trim();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
