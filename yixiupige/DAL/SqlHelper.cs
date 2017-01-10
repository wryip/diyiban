using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlHelper
    {
        public static string sqlconn = ConfigurationManager.ConnectionStrings["sql"].ToString();
        static public int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    com.Parameters.AddRange(pms);
                    conn.Open();
                    return com.ExecuteNonQuery();
                }
            }
        }
        static public object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    com.Parameters.AddRange(pms);
                    conn.Open();
                    return com.ExecuteScalar();
                }
            }
        }
        static public SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection conn = new SqlConnection(sqlconn);
            try
            {
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    com.Parameters.AddRange(pms);
                    conn.Open();
                    return com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw ex;
            }

        }
        static public DataSet GetDataSet(string sql, params SqlParameter[] pms)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, sqlconn))
            {
                da.SelectCommand.Parameters.AddRange(pms);
                da.Fill(ds);
            }
            return ds;
        }
    }
}
