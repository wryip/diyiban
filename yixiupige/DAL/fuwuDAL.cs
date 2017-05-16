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
        //添加服务类    基本服务
        //admin账户可设置此参数   添加服务的时候记录   店铺名称   在查询的时候去除名称
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
        //显示服务  查询功能
        public List<fuwuModel> selectAllList()
        {
            List<fuwuModel> list = new List<fuwuModel>();
            fuwuModel model;
            string str = "select * from fuwuInfo where DPName='" + FilterClass.DianPu1.UserName.Trim() + "'";
            //SqlParameter[] pms;
            //if (FilterClass.DianPu1.UserName.Trim()=="admin")
            //{
            //    str = "select * from fuwuInfo";
            
            //}
            //else
            //{
            //    str = "select * from fuwuInfo";
            ////    pms = new SqlParameter[] { 
            ////new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            ////};
            //}
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
        //通过服务名称查询数据
        public fuwuModel selectIteam(string name)
        {
            fuwuModel model = new fuwuModel();
            string str;
            SqlParameter[] pms;
            //if (FilterClass.DianPu1.UserName.Trim()=="admin")
            //{
            str = "select * from fuwuInfo where Name=@Name and DPName='" + FilterClass.DianPu1.UserName.Trim() + "' ";
                pms = new SqlParameter[] { 
            new SqlParameter("@Name",name.Trim())
            };
           // }
            //else
            //{
            //    str = "select * from fuwuInfo where Name=@Name and DPName=@DPName";
            //    pms = new SqlParameter[] { 
            //new SqlParameter("@Name",name.Trim()),
            //new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            //};
            //}
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
        //修改基本服务中的信息
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
        //删除基本服务中的信息
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
