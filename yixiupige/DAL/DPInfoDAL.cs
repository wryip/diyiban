using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DPInfoDAL
    {
        public bool AddModel(DianPu model)
        {
            bool result = false;
            string str = "insert into DPInfo(DPName,DPPerson,DPTel,DPAddress,DPRemark,DPContent,DPPicture) values(@DPName,@DPPerson,@DPTel,@DPAddress,@DPRemark,@DPContent,@DPPicture)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",model.DPName),
            new SqlParameter("@DPPerson",model.DPPerson),
            new SqlParameter("@DPTel",model.DPTel),
            new SqlParameter("@DPAddress",model.DPAddress),
            new SqlParameter("@DPRemark",model.DPRemark),
            new SqlParameter("@DPContent",model.DPContent),
            new SqlParameter("@DPPicture",model.DPPicture)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<DianPu> selectAllList()
        {
            List<DianPu> list = new List<DianPu>();
            DianPu model;
            string str = "select * from DPInfo";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new DianPu();
                    model.DPName = read["DPName"].ToString();
                    model.DPContent = read["DPContent"].ToString();
                    model.DPAddress = read["DPAddress"].ToString();
                    model.DPPerson = read["DPPerson"].ToString();
                    model.DPPicture = read["DPPicture"].ToString();
                    model.DPRemark = read["DPRemark"].ToString();
                    model.DPTel = read["DPTel"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public bool UpdateModel(DianPu model)
        {
            bool result = false;
            string str = "update DPInfo set DPPerson=@DPPerson,DPTel=@DPTel,DPAddress=@DPAddress,DPRemark=@DPRemark,DPContent=@DPContent,DPPicture=@DPPicture where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",model.DPName),
            new SqlParameter("@DPPerson",model.DPPerson),
            new SqlParameter("@DPTel",model.DPTel),
            new SqlParameter("@DPAddress",model.DPAddress),
            new SqlParameter("@DPRemark",model.DPRemark),
            new SqlParameter("@DPContent",model.DPContent),
            new SqlParameter("@DPPicture",model.DPPicture)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool deleteIteam(string name)
        {
            bool result = false;
            string str = "delete from DPInfo where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",name)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        public List<string> selectDPName()
        {
            List<string> list = new List<string>();
            string str = "select DPName from DPInfo group by DPName";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    list.Add(read["DPName"].ToString());
                }
            }
            return list;
        }
    }
}
