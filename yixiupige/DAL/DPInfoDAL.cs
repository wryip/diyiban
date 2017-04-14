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
    public class DPInfoDAL
    {
        //店铺信息DAL
        public bool AddModel(DianPu model)
        {
            bool result = false;
            string str = "insert into DPInfo(DPName,DPPerson,DPTel,DPAddress,DPRemark,DPContent,DPPicture,DPNo,DPDay,DPNumber,MemberPrint,BGJPrint) values(@DPName,@DPPerson,@DPTel,@DPAddress,@DPRemark,@DPContent,@DPPicture,@DPNo,@DPDay,@DPNumber,@MemberPrint,@BGJPrint)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",model.DPName),
            new SqlParameter("@DPPerson",model.DPPerson),
            new SqlParameter("@DPTel",model.DPTel),
            new SqlParameter("@DPAddress",model.DPAddress),
            new SqlParameter("@DPRemark",model.DPRemark),
            new SqlParameter("@DPContent",model.DPContent),
            new SqlParameter("@DPPicture",model.DPPicture),
            new SqlParameter("@DPNo",model.DPNo),
            new SqlParameter("@DPDay",model.DPDay),
            new SqlParameter("@DPNumber",model.DPNumber),
            new SqlParameter("@MemberPrint",model.MemberPrint),
            new SqlParameter("@BGJPrint",model.BGJPrint)
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
                    model.DPNo = read["DPNo"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        public bool UpdateModel(DianPu model)
        {
            bool result = false;
            string str = "update DPInfo set DPPerson=@DPPerson,DPTel=@DPTel,DPAddress=@DPAddress,DPRemark=@DPRemark,DPContent=@DPContent,DPPicture=@DPPicture,DPNo=@DPNo,MemberPrint=@MemberPrint,BGJPrint=@BGJPrint where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",model.DPName),
            new SqlParameter("@DPPerson",model.DPPerson),
            new SqlParameter("@DPTel",model.DPTel),
            new SqlParameter("@DPAddress",model.DPAddress),
            new SqlParameter("@DPRemark",model.DPRemark),
            new SqlParameter("@DPContent",model.DPContent),
            new SqlParameter("@DPPicture",model.DPPicture),
            new SqlParameter("@MemberPrint",model.MemberPrint),
            new SqlParameter("@BGJPrint",model.BGJPrint),
            new SqlParameter("@DPNo",model.DPNo)
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
        public string[] selectPicImg(string name)
        {
            string[] str1 = new string[6];
            string str = "select DPPicture,DPContent,ID,MemberPrint,BGJPrint,DPTel from DPInfo where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",name)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    str1[0] = read["DPPicture"].ToString();
                    str1[1] = read["DPContent"].ToString();
                    str1[2] = read["ID"].ToString();
                    str1[3] = read["MemberPrint"].ToString();
                    str1[4] = read["BGJPrint"].ToString();
                    str1[5] = read["DPTel"].ToString();
                }
            }
            return str1;
        }
        //判断是不是新的一天
        public void UpdateDay(int day)
        {
            string ID = FilterClass.ID;
            if (ID == null)
            {
                return;
            }
            string str = "select DPDay from DPInfo where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@ID",ID)
            };
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo != null)
            {
                if (Convert.ToInt32(oo) != day)
                {
                    UpdateNewDay();
                }
            }
        }
        //更新最新一天的数据
        public void UpdateNewDay()
        {
            string ID = FilterClass.ID;
            string str = "Update DPInfo set DPDay=@DPDay,DPNumber=@DPNumber";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPDay",DateTime.Now.Day),
            new SqlParameter("@DPNumber","1")
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        public string[] selectNumberAndNo(string dpname)
        {
            string[] strarry = new string[3];
            string str = "select DPNo,DPNumber,ID from DPInfo where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while(read.Read())
            {
                if (read.HasRows)
                {
                    strarry[0] = read["DPNo"].ToString();
                    strarry[1] = read["DPNumber"].ToString();
                    strarry[2] = read["ID"].ToString();
                }
            }
            return strarry;
        }
        public bool uodateNumber(string dpID, int j)
        {
            bool result = false;
            string str = "update DPInfo set DPNumber=@DPNumber where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@ID",dpID),
            new SqlParameter("@DPNumber",j)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
