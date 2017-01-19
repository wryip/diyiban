using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;
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
                   sql += " where Gno like @no";
                   listp.Add(new SqlParameter("@no", "%"+gd.Gno+"%"));
               }
               if (!string.IsNullOrEmpty(gd.Gname))
               {
                   sql += " where Gname like @name";
                   listp.Add(new SqlParameter("@name","%"+ gd.Gname+"%"));
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
           string sql = "insert into GoodInfo(Gname,Gbid,Gprice,Gsum,Gtype,Gno,Gremark,Gstock) values(@name,@bid,@price,@sum,@type,@no,@remark,@stock)";
           SqlParameter[] ps =
            {
               new SqlParameter("@name",gd.Gname),
               new SqlParameter("@bid",gd.Gbid),
               new SqlParameter("@price",gd.Gprice),
               new SqlParameter("@sum",gd.Gsum),
               new SqlParameter("@type",gd.Gtype),
               new SqlParameter("@no",gd.Gno),
               new SqlParameter("@remark",gd.Gremark),
               new SqlParameter("@stock",gd.Gstock)
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
           string sql = "update GoodInfo set Gname=@name,Gbid=@bid,Gsum=@sum,Gremark=@remark where Gno=@no";
           SqlParameter[] sp = { 
                                     new SqlParameter("@name",gd.Gname),
                                     new SqlParameter("@bid",gd.Gid),
                                     new SqlParameter("@price",gd.Gprice),
                                     new SqlParameter("@sum",gd.Gsum),
                                     new SqlParameter("@no",gd.Gno),
                                     new SqlParameter("@remark",gd.Gremark),
                                    
                                };
           return SqlHelper.ExecuteNonQuery(sql,sp);


       }
       public int Updates(int _add,GoodInfo gd)
       {
           int _a = gd.Gsum + _add;
           string sql = "update GoodInfo set Gsum=@sum,Gstock=@stock where Gno=@no";
           SqlParameter[] sp = { 
                                    new SqlParameter("@no",gd.Gno),
                                    new SqlParameter("@sum",_a),
                                    new SqlParameter("@stock",_a)
                                    
                                };
           return SqlHelper.ExecuteNonQuery(sql, sp);
       }
    }
}
