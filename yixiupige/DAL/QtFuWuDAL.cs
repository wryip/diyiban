﻿using Commond;
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
        /// <summary>
        /// 添加其他服务类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddModel(qtFuWuModel model)
        {
            bool result = false;
            string str = "insert into QtFuWu(QtName,DPName) values(@QtName,@DPName)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@QtName",model.QtName),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<qtFuWuModel> SelectAllList()
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<qtFuWuModel> list = new List<qtFuWuModel>();
            qtFuWuModel model;
            SqlParameter[] pms;
            string str;
            if (dpname == "admin")
            {
                pms = new SqlParameter[] { };
                str = "select * from QtFuWu";
            }
            else
            {
                pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname)
            };
                str = "select * from QtFuWu where DPName=@DPName";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str,pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new qtFuWuModel();
                    model.QtName = read["QtName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public bool EditModel(qtFuWuModel model)
        {
            bool result = false;
            string str = "update QtFuWu set QtName=@QtName1 where QtName=@QtName and DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@QtName",model.QtName),
            new SqlParameter("@QtName1",model.QtName),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
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
            string str = "delete from QtFuWu where QtName=@QtName and DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@QtName",name.Trim()),
            new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<string> selectAllName()
        {
            string dpname=FilterClass.DianPu1.UserName.Trim();
            List<string> list = new List<string>();
            string name;
            SqlParameter[] pms;
            string str;
            if (dpname == "admin")
            {
                pms = new SqlParameter[] { };
                str = "select QtName from QtFuWu";
            }
            else
            {
                pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname)
            };
                str = "select QtName from QtFuWu where DPName=@DPName";
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str,pms);
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
