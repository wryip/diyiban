using Commond;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TJBBDAL
    {
        public string ID = FilterClass.ID == null ? null : FilterClass.ID.Trim();
        //添加进货信息
        public void AddIteam(InHuoTJ jinhuo)
        {
            if (ID == null)
            {
                return;
            }
            string str = "insert into InHuoTJ"+ID+"(HuoNumber,HuoName,HuoType,HuoMoney,HuoCount,HuoSum,HuoDate,HuoSale,HuoDianName) values(@HuoNumber,@HuoName,@HuoType,@HuoMoney,@HuoCount,@HuoSum,@HuoDate,@HuoSale,@HuoDianName)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@HuoNumber",jinhuo.HuoNumber),
            new SqlParameter("@HuoName",jinhuo.HuoName),
            new SqlParameter("@HuoType",jinhuo.HuoType),
            new SqlParameter("@HuoMoney",jinhuo.HuoMoney),
            new SqlParameter("@HuoCount",jinhuo.HuoCount),
            new SqlParameter("@HuoSum",jinhuo.HuoSum),
            new SqlParameter("@HuoDate",SqlDbType.SmallDateTime){Value=jinhuo.HuoDate},
            new SqlParameter("@HuoSale",jinhuo.HuoSale),
            new SqlParameter("@HuoDianName",jinhuo.HuoDianName)
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        //统计报表中的进货统计
        public List<InHuoTJ> selectListTJ(string begindate,string enddate,string yginfo,string name)
        {
            int i = 1;
            string dianpu = FilterClass.DianPu1.UserName.Trim();
            List<InHuoTJ> list = new List<InHuoTJ>();
            InHuoTJ model;
            string str = "";
            //SqlParameter[] pms;
            if (dianpu == "admin")
            {
                if (name == "全部")
                {
                     if (yginfo.Trim() == "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "InHuoTJ" + iteam.Value + "";
                            str += " where HuoDate between '" + begindate + "' and '" + enddate + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                        //str = "select * from InHuoTJ where HuoDate between '" + begindate + "' and '" + enddate + "'";
                        //pms = new SqlParameter[] {
                        //};
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "InHuoTJ" + iteam.Value + "";
                            str += " where HuoDate between '" + begindate + "' and '" + enddate + "' and HuoSale='" + yginfo.Trim() + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                        //str = "select * from InHuoTJ where HuoSale=@HuoSale and HuoDate between '" + begindate + "' and '" + enddate + "'";
                        //pms = new SqlParameter[] { 
                        //new SqlParameter("@HuoSale",yginfo.Trim())
                        //};
                    }
                }
                else
                {
                    int id = FilterClass.dic[name];
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from InHuoTJ"+id+" where HuoDate between '" + begindate + "' and '" + enddate + "'";
                        //pms = new SqlParameter[] {
                        //    new SqlParameter("@HuoDianName",name)
                        //};
                    }
                    else
                    {
                        str = "select * from InHuoTJ" + id + " where HuoSale='" + yginfo.Trim() + "' and HuoDate between '" + begindate + "' and '" + enddate + "'";
                        //pms = new SqlParameter[] { 
                        //new SqlParameter("@HuoSale",yginfo.Trim()),
                        //new SqlParameter("@HuoDianName",name)
                        //};
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from InHuoTJ"+ID+" where HuoDate between '" + begindate + "' and '" + enddate + "'";
                    //pms = new SqlParameter[] { 
                    //new SqlParameter("@HuoDianName",dianpu)
                    //};
                }
                else
                {
                    str = "select * from InHuoTJ" + ID + " where HuoSale='" + yginfo.Trim() + "' and HuoDate between '" + begindate + "' and '" + enddate + "'";
                    //pms = new SqlParameter[] { 
                    //new SqlParameter("@HuoDianName",dianpu),
                    //new SqlParameter("@HuoSale",yginfo.Trim())
                    //};
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new InHuoTJ();
                    model.BH = i;
                    model.HuoCount = read["HuoCount"].ToString().Trim();
                    model.HuoDate = read["HuoDate"].ToString().Trim();
                    model.HuoDianName = read["HuoDianName"].ToString().Trim();
                    model.HuoMoney = read["HuoMoney"].ToString().Trim();
                    model.HuoName = read["HuoName"].ToString().Trim();
                    model.HuoNumber = read["HuoNumber"].ToString().Trim();
                    model.HuoSale = read["HuoSale"].ToString().Trim();
                    model.HuoSum = read["HuoSum"].ToString().Trim();
                    model.HuoType = read["HuoType"].ToString().Trim();
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
        //统计报表中的   统计销售商品的统计
        public List<PutHuo> SelectListXS(string begindate, string enddate, string yginfo,string dpname)
        {
            int i = 1;
            string dianpu = FilterClass.DianPu1.UserName.Trim();
            List<PutHuo> list = new List<PutHuo>();
            PutHuo model;
            string str = "";
            //SqlParameter[] pms;
            if (dianpu == "admin")
            {
                if (dpname == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "PutHuo" + iteam.Value + "";
                            str += " where PutDate between '" + begindate + "' and '" + enddate + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                    //    str = "select * from PutHuo where PutDate  between '" + begindate + "' and '" + enddate + "'";
                    //    pms = new SqlParameter[] {
                    //};
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> iteam in FilterClass.dic)
                        {
                            str += "select * from ";
                            str += "PutHuo" + iteam.Value + "";
                            str += " where PutDate between '" + begindate + "' and '" + enddate + "' and PutSale='" + yginfo.Trim() + "'";
                            str += " union all ";
                        }
                        str = str.Substring(0, str.Length - 10);
                       // str = "select * from PutHuo where PutSale=@PutSale";
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter("@PutSale",yginfo.Trim())
                    //};
                    }
                }
                else
                {
                    int id = FilterClass.dic[dpname];
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from PutHuo"+id+" where PutDate  between '" + begindate + "' and '" + enddate + "'";
                    //    pms = new SqlParameter[] {
                    //        new SqlParameter("@PutDianName",dpname)
                    //};
                    }
                    else
                    {
                        str = "select * from PutHuo" + id + " where PutSale='" + yginfo.Trim() + "' and PutDate  between '" + begindate + "' and '" + enddate + "'";
                    //    pms = new SqlParameter[] { 
                    //new SqlParameter("@PutSale",yginfo.Trim()),
                    // new SqlParameter("@PutDianName",dpname)
                    //};
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from PutHuo"+ID+" where PutDate  between '" + begindate + "' and '" + enddate + "'";
                    //pms = new SqlParameter[] { 
                    //new SqlParameter("@PutDianName",dianpu)
                    //};
                }
                else
                {
                    str = "select * from PutHuo" + ID + " where PutSale='" + yginfo.Trim() + "' and PutDate  between '" + begindate + "' and '" + enddate + "'";
                    //pms = new SqlParameter[] { 
                    //new SqlParameter("@PutDianName",dianpu),
                    //new SqlParameter("@PutSale",yginfo.Trim())
                    //};
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    model = new PutHuo();
                    model.PutBH = i;
                    model.PutNo = read["PutNo"].ToString().Trim();
                    model.PutName = read["PutName"].ToString().Trim();
                    model.PutType = read["PutType"].ToString().Trim();
                    model.PutMoney = read["PutMoney"].ToString().Trim();
                    model.PutCount = read["PutCount"].ToString().Trim();
                    model.PutCardNo = read["PutCardNo"].ToString().Trim();
                    model.PubPersonName = read["PutPersonName"].ToString().Trim();
                    model.PutDate = read["PutDate"].ToString().Trim();
                    model.PutSale = read["PutSale"].ToString().Trim();
                    model.PutDianName = read["PutDianName"].ToString().Trim();
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
        //统计报表中的添加商品销售的 记录
        public void AddIteam(PutHuo model)
        {
            if (ID == null)
            {
                return;
            }
            string str = "insert into PutHuo"+ID+"(PutNo,PutName,PutType,PutMoney,PutCount,PutCardNo,PutPersonName,PutDate,PutSale,PutDianName) values(@PutNo,@PutName,@PutType,@PutMoney,@PutCount,@PutCardNo,@PutPersonName,@PutDate,@PutSale,@PutDianName)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@PutNo",model.PutNo.Trim()),
            new SqlParameter("@PutName",model.PutName.Trim()),
            new SqlParameter("@PutType",model.PutType.Trim()),
            new SqlParameter("@PutMoney",model.PutMoney.Trim()),
            new SqlParameter("@PutCardNo",model.PutCardNo.Trim()),
            new SqlParameter("@PutCount",model.PutCount.Trim()),
            new SqlParameter("@PutPersonName",model.PubPersonName.Trim()),
            new SqlParameter("@PutDate",SqlDbType.SmallDateTime){Value=model.PutDate.Trim()},
            new SqlParameter("@PutSale",model.PutSale.Trim()),
            new SqlParameter("@PutDianName",model.PutDianName.Trim())
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        //根据一些条件   查询某一条商品消费信息的唯一ID
        public int getIteamId(string staff, string dianpu, string cardno, string date)
        {
            int id = 0;
            string str = "select ID from PutHuo"+ID+" where PutName=@PutName and PutDianName=@PutDianName and PutCardNo=@PutCardNo and PutDate=@PutDate";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@PutCardNo",cardno),
            new SqlParameter("@PutDianName",dianpu),
            new SqlParameter("@PutDate",date),
            new SqlParameter("@PutName",staff)
            };
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo != null)
            {
                id = Convert.ToInt32(oo);
            }
            return id;
        }
        //根据唯一id删除一条记录
        public void DeleteIteamID(int gid)
        {
            if (ID == null)
            {
                return;
            }
            string str = "delete from PutHuo"+ID+" where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@ID",gid)
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        /// <summary>
        /// 以下三个代表送洗统计，接收统计，返工统计的三个添加方法0代表送洗1代表接收2代表反工
        /// </summary>
        /// <param name="list"></param>
        /// //送洗统计   统计报表中的
        public bool AddSendXi(List<int> list)
        {
            bool result = false;
            if (ID == null)
            {
                return false;
            }
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string regx = "('{0}','{1}','{2}'),";
            string str = "insert into SendXI"+ID+"(jcID,DateTime,ZT) values";
            foreach (int jcid in list)
            {
                str = str + string.Format(regx, jcid, datetime,0);
            }
            str = str.Substring(0, str.Length - 1);
            if (SqlHelper.ExecuteNonQuery(str) > 0)
            {
                result = true;
            }
            return result;
        }
        //接收统计    统计报表中的
        public void InDP(List<int> list)
        {
            if (ID == null)
            {
                return ;
            }
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string regx = "('{0}','{1}','{2}'),";
            string str = "insert into SendXI"+ID+"(jcID,DateTime,ZT) values";
            foreach (int jcid in list)
            {
                str = str + string.Format(regx, jcid, datetime, 1);
            }
            str = str.Substring(0, str.Length - 1);
            SqlHelper.ExecuteNonQuery(str);
        }
        //返工统计    统计报表中的
        public void AgainSend(List<int> list)
        {
            if (ID == null)
            {
                return;
            }
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string regx = "('{0}','{1}','{2}'),";
            string str = "insert into SendXI"+ID+"(jcID,DateTime,ZT) values";
            foreach (int jcid in list)
            {
                str = str + string.Format(regx, jcid, datetime, 2);
            }
            str = str.Substring(0, str.Length - 1);
            SqlHelper.ExecuteNonQuery(str);
        }
    }
}
