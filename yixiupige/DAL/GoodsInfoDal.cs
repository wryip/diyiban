﻿using System;
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
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
       //查询商品信息
       public List<GoodInfo> Getlist(GoodInfo gd)
       {
            List<GoodInfo> list = new List<GoodInfo>();
           if (ID == null)
           {
               return list;
           }
           List<SqlParameter> listp = new List<SqlParameter>();          
           string sql = "select * from GoodInfo"+ID+"";
           string dpname = FilterClass.DianPu1.UserName.Trim();
           if (gd != null)
           {
               if (!string.IsNullOrEmpty(gd.Gno))
               {
                   //if (dpname == "admin")
                   //{
                       sql += " where Gno like @no";
                       listp.Add(new SqlParameter("@no", "%" + gd.Gno + "%"));
                   //}
                   //else
                   //{
                   //    sql += " where Gno like @no and DPName=@DPName";
                   //    listp.Add(new SqlParameter("@no", "%" + gd.Gno + "%"));
                   //    listp.Add(new SqlParameter("@DPName", dpname));
                   //}
               }
               if (!string.IsNullOrEmpty(gd.Gname))
               {
                   //if (dpname == "admin")
                   //{
                       sql += " where Gname like @name";
                       listp.Add(new SqlParameter("@name", "%" + gd.Gname + "%"));
                   //}
                   //else
                   //{
                   //    sql += " where Gname like @name and DPName=@DPName";
                   //    listp.Add(new SqlParameter("@name", "%" + gd.Gname + "%"));
                   //    listp.Add(new SqlParameter("@DPName", dpname));
                   //}
               }
               if (!string.IsNullOrEmpty(gd.Gtype))
               {

                   if (gd.Gtype != "全部")
                   {
                       //if (dpname == "admin")
                       //{
                           sql += " where Gtype=@type";
                           listp.Add(new SqlParameter("@type", gd.Gtype));
                       //}
                       //else
                       //{
                       //    sql += " where Gtype=@type and DPName=@DPName";
                       //    listp.Add(new SqlParameter("@type", gd.Gtype));
                       //    listp.Add(new SqlParameter("@DPName", dpname));
                       //}
                   }
                   else
                   {
                       //if (dpname == "admin")
                       //{

                       //}
                       //else
                       //{
                       //    sql += " where DPName=@DPName";
                       //    listp.Add(new SqlParameter("@DPName", dpname));
                       //}
                   }

               }
           }
           else
           {
               //sql += " where DPName=@DPName";
               //listp.Add(new SqlParameter("@DPName", dpname));
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
        //增加商品信息
       public int Insert(GoodInfo gd)
       {
           if (ID == null)
           {
               return 0;
           }
           string sql = "insert into GoodInfo"+ID+"(Gname,Gbid,Gprice,Gsum,Gtype,Gno,Gremark,Gstock,DPName) values(@name,@bid,@price,@sum,@type,@no,@remark,@stock,@DPName)";
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
           if (ID == null)
           {
               return 0;
           }
           string sql = "delete from GoodInfo"+ID+" where Gid=@id";
           SqlParameter[] ps =
           {
               new SqlParameter("@id",id)
           };
           return SqlHelper.ExecuteNonQuery(sql,ps);
       }
        //修改信息
       public int Update(GoodInfo gd)
       {
           if (ID == null)
           {
               return 0;
           }
           string sql = "update GoodInfo"+ID+" set Gname=@name,Gbid=@bid,Gtype=@type,Gremark=@remark where Gno=@no and DPName=@DPName";
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
        //进货修改
       public int Updates(int _add,GoodInfo gd)
       {
           if (ID == null)
           {
               return 0;
           }
           int _a = gd.Gstock + _add;
           int _b = gd.Gsum + _add;
           string sql = "update GoodInfo"+ID+" set Gsum=@sum,Gstock=@stock where Gno=@no and DPName=@DPName";
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
           List<GoodInfo> list = new List<GoodInfo>();
           if (ID == null)
           {
               return list;
           }
           List<SqlParameter> listp = new List<SqlParameter>();           
           string sql = "select * from GoodInfo"+ID+"";
           string dpname=FilterClass.DianPu1.UserName.Trim();
           if (!string.IsNullOrEmpty(gd.Gno))
           {
               //if (dpname == "admin")
               //{
                   sql += " where Gno=@no";
                   listp.Add(new SqlParameter("@no", gd.Gno.Trim()));
               //}
               //else
               //{
               //    sql += " where Gno=@no and DPName=@DPName";
               //    listp.Add(new SqlParameter("@no", gd.Gno.Trim()));
               //    listp.Add(new SqlParameter("@DPName", dpname));
               //}
           }
           if (!string.IsNullOrEmpty(gd.Gname))
           {
               //if (dpname == "admin")
               //{
                   sql += " where Gname=@name";
                   listp.Add(new SqlParameter("@name", gd.Gname.Trim()));
               //}
               //else
               //{
               //    sql += " where Gname=@name and DPName=@DPName";
               //    listp.Add(new SqlParameter("@name", gd.Gname.Trim()));
               //    listp.Add(new SqlParameter("@DPName", dpname));
               //}
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
        //消费之后减去数量
       public void UpdateXF(string no, int count)
       {
           if (ID == null)
           {
               return;
           }
           string str = "update GoodInfo"+ID+" set Gstock=Gstock-" + count + " where Gid=@gid";
           SqlParameter[] pms = new SqlParameter[] { 
           new SqlParameter("@gid",no)
           };
           SqlHelper.ExecuteNonQuery(str,pms);
       }
        //退单之后添加会数量
       public void DeleteAdd(int id, int count)
       {
           if (ID == null)
           {
               return;
           }
           string str = "update GoodInfo"+ID+" set Gstock=Gstock+" + count + " where Gid=@gid";
           SqlParameter[] pms = new SqlParameter[] { 
           new SqlParameter("@gid",id)
           };
           SqlHelper.ExecuteNonQuery(str,pms);
       }
        //添加新的商品的时候，获取现在商品  编号最大的
       public int getNumber()
       {
           if (ID == null)
           {
               return -1;
           }
           int result = 0;
           string str = "select Gno from GoodInfo"+ID+" where DPName=@DPName order by Gno DESC";
           SqlParameter[] pms = new SqlParameter[] { 
           new SqlParameter("@DPName",FilterClass.DianPu1.UserName.Trim())
           };
           object oo=SqlHelper.ExecuteScalar(str, pms);
           if ( oo!=null)
           {
               result = Convert.ToInt32(oo);
           }
           return result;
       }
    }
}
