using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using Commond;
namespace DAL
{
    public class GoodsInfoDal
    {
    
       //查询
       public List<GoodInfo> Getlist(GoodInfo gd)
       {
           List<SqlParameter> listp = new List<SqlParameter>();
           List<GoodInfo> list = new List<GoodInfo>();
           string sql = "select * from GoodInfo";
           if (gd!=null)
           {
               if (!string.IsNullOrEmpty(gd.Gno))
               {
                   sql += " where Gno like @no and DPName=@DPName";
                   listp.Add(new SqlParameter("@no", "%"+gd.Gno+"%"));
                   listp.Add(new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim()));
               }
               if (!string.IsNullOrEmpty(gd.Gname))
               {
                   sql += " where Gname like @name and DPName=@DPName";
                   listp.Add(new SqlParameter("@name","%"+ gd.Gname+"%"));
                   listp.Add(new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim()));
               }
               if (!string.IsNullOrEmpty(gd.Gtype))
               {

                   if (gd.Gtype != "全部")
                   {
                       sql += " where Gtype=@type and DPName=@DPName";
                       listp.Add(new SqlParameter("@type", gd.Gtype));
                       listp.Add(new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim()));
                   }
                   else
                   {
                       sql += " where DPName=@DPName";
                       listp.Add(new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim()));
                   }
                  
               }
           }
           DataSet ds= SqlHelper.GetDataSet(sql,listp.ToArray());
           DataTable dt = ds.Tables[0];
           foreach (DataRow row in dt.Rows)
           {
               list.Add(
                   new GoodInfo()
                   {
                       Gid=Convert.ToInt32(row["Gid"]),
                       Gname=row["Gname"].ToString(),
                       Gno=row["Gno"].ToString(),
                       Gprice=Convert.ToDecimal(row["Gprice"]),
                       Gremark=row["Gremark"].ToString(),
                       Gstock=Convert.ToInt32(row["Gstock"]),
                       Gsum=Convert.ToInt32(row["Gsum"]),
                       Gtype=row["Gtype"].ToString(),
                       Gbid = Convert.ToDecimal(row["Gbid"])
                    
                   }
                   );
           }
           return list;
           
          
       }
        //增加
       public int Insert(GoodInfo gd)
       {
           string sql = "insert into GoodInfo(Gname,Gbid,Gprice,Gsum,Gtype,Gno,Gremark,Gstock,DPName) values(@name,@bid,@price,@sum,@type,@no,@remark,@stock,@DPName)";
           SqlParameter[] ps =
            {
               new SqlParameter("@name",gd.Gname),
               new SqlParameter("@bid",gd.Gbid),
               new SqlParameter("@price",gd.Gprice),
               new SqlParameter("@sum",gd.Gsum),
               new SqlParameter("@type",gd.Gtype),
               new SqlParameter("@no",gd.Gno),
               new SqlParameter("@remark",gd.Gremark),
               new SqlParameter("@stock",gd.Gstock),
               new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
            };
           return SqlHelper.ExecuteNonQuery(sql, ps);
       }
       //删除操作
       public int Delete(int id)
       {
           string sql = "delete from GoodInfo where Gid=@id";
           SqlParameter[] ps =
           {
               new SqlParameter("@id",id)
           };
           return SqlHelper.ExecuteNonQuery(sql,ps);
       }
       public int Update(GoodInfo gd)
       {
           string sql = "update GoodInfo set Gname=@name,Gbid=@bid,Gtype=@type,Gremark=@remark where Gno=@no and DPName=@DPName";
           SqlParameter[] sp = { 
                                     new SqlParameter("@name",gd.Gname),
                                     new SqlParameter("@bid",gd.Gbid),
                                     new SqlParameter("@price",gd.Gprice),
                                     new SqlParameter("@type",gd.Gtype),
                                     new SqlParameter("@no",gd.Gno),
                                     new SqlParameter("@remark",gd.Gremark),
                                     new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim())
                                    
                                };
           return SqlHelper.ExecuteNonQuery(sql,sp);


       }
       public int Updates(int _add,GoodInfo gd)
       {
           int _a = gd.Gstock + _add;
           int _b = gd.Gsum + _add;
           string sql = "update GoodInfo set Gsum=@sum,Gstock=@stock where Gno=@no and DPName=@DPName";
           SqlParameter[] sp = { 
                                    new SqlParameter("@no",gd.Gno),
                                    new SqlParameter("@sum",_b),
                                    new SqlParameter("@stock",_a),
                                    new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim())
                                    
                                };
           return SqlHelper.ExecuteNonQuery(sql, sp);
       }
       public List<GoodInfo> GetlistJQ(GoodInfo gd)
       {
           List<SqlParameter> listp = new List<SqlParameter>();
           List<GoodInfo> list = new List<GoodInfo>();
           string sql = "select * from GoodInfo";
           if (!string.IsNullOrEmpty(gd.Gno))
           {
               sql += " where Gno=@no and DPName=@DPName";
               listp.Add(new SqlParameter("@no", gd.Gno.Trim()));
               listp.Add(new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim()));
           }
           if (!string.IsNullOrEmpty(gd.Gname))
           {
               sql += " where Gname=@name and DPName=@DPName";
               listp.Add(new SqlParameter("@name", gd.Gname.Trim()));
               listp.Add(new SqlParameter("@DPName", FilterClass.DianPu1.UserName.Trim()));
           }
           DataSet ds = SqlHelper.GetDataSet(sql, listp.ToArray());
           DataTable dt = ds.Tables[0];
           foreach (DataRow row in dt.Rows)
           {
               list.Add(
                   new GoodInfo()
                   {
                       Gid = Convert.ToInt32(row["Gid"]),
                       Gname = row["Gname"].ToString(),
                       Gno = row["Gno"].ToString(),
                       Gprice = Convert.ToDecimal(row["Gprice"]),
                       Gremark = row["Gremark"].ToString(),
                       Gstock = Convert.ToInt32(row["Gstock"]),
                       Gsum = Convert.ToInt32(row["Gsum"]),
                       Gtype = row["Gtype"].ToString(),
                       Gbid = Convert.ToDecimal(row["Gbid"])

                   }
                   );
           }
           return list;
       }
       public void UpdateXF(string no, int count)
       {
           string str = "update GoodInfo set Gstock=Gstock-" + count + "";
           SqlHelper.ExecuteNonQuery(str);
       }
    }
}
