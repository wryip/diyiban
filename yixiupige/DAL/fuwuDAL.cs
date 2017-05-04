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
    public class fuwuDAL
    {
        //服务的DAL
        public bool AddModel(fuwuModel model)
        {
            bool result = false;
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@Name",model.Name),
            new SqlParameter("@neirong",model.neirong),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            string str = "insert into fuwuInfo(Name,neirong,DPName) values(@Name,@neirong,@DPName)";
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
            string str;
            SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName.Trim()=="admin")
            {
                str = "select * from fuwuInfo";
                pms = new SqlParameter[] { };
            }
            else
            {
                str = "select * from fuwuInfo where DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str,pms);
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
            string str;
            SqlParameter[] pms;
            if (FilterClass.DianPu1.UserName.Trim()=="admin")
            {
                str = "select * from fuwuInfo where Name=@Name";
                pms = new SqlParameter[] { 
            new SqlParameter("@Name",name.Trim())
            };
            }
            else
            {
                str = "select * from fuwuInfo where Name=@Name and DPName=@DPName";
                pms = new SqlParameter[] { 
            new SqlParameter("@Name",name.Trim()),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            }
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
            new SqlParameter("@Name",model.Name),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            string str = "update fuwuInfo set neirong=@neirong where Name=@Name and DPName=@DPName";
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteIteam(string name)
        {
            bool result = false;
            string str = "delete from fuwuInfo where Name=@Name and DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@Name",name),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
