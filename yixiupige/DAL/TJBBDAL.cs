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
        public void AddIteam(InHuoTJ jinhuo)
        {
            string str = "insert into InHuoTJ(HuoNumber,HuoName,HuoType,HuoMoney,HuoCount,HuoSum,HuoDate,HuoSale,HuoDianName) values(@HuoNumber,@HuoName,@HuoType,@HuoMoney,@HuoCount,@HuoSum,@HuoDate,@HuoSale,@HuoDianName)";
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
        public List<InHuoTJ> selectListTJ(string begindate,string enddate,string yginfo,string name)
        {
            int i = 1;
            string dianpu = FilterClass.DianPu1.UserName.Trim();
            List<InHuoTJ> list = new List<InHuoTJ>();
            InHuoTJ model;
            string str = "";
            SqlParameter[] pms;
            if (dianpu == "admin")
            {
                if (name == "全部")
                {
                     if (yginfo.Trim() == "全部")
                    {
                        str = "select * from InHuoTJ where HuoDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] {
                        };
                    }
                    else
                    {
                        str = "select * from InHuoTJ where HuoSale=@HuoSale and HuoDate between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] { 
                        new SqlParameter("@HuoSale",yginfo.Trim())
                        };
                    }
                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from InHuoTJ where HuoDate between '" + begindate + "' and '" + enddate + "' and HuoDianName=@HuoDianName";
                        pms = new SqlParameter[] {
                            new SqlParameter("@HuoDianName",name)
                        };
                    }
                    else
                    {
                        str = "select * from InHuoTJ where HuoSale=@HuoSale and HuoDate between '" + begindate + "' and '" + enddate + "' and HuoDianName=@HuoDianName";
                        pms = new SqlParameter[] { 
                        new SqlParameter("@HuoSale",yginfo.Trim()),
                        new SqlParameter("@HuoDianName",name)
                        };
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from InHuoTJ where HuoDianName=@HuoDianName and HuoDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@HuoDianName",dianpu)
                    };
                }
                else
                {
                    str = "select * from InHuoTJ where HuoDianName=@HuoDianName and HuoSale=@HuoSale and HuoDate between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@HuoDianName",dianpu),
                    new SqlParameter("@HuoSale",yginfo.Trim())
                    };
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
        public List<PutHuo> SelectListXS(string begindate, string enddate, string yginfo,string dpname)
        {
            int i = 1;
            string dianpu = FilterClass.DianPu1.UserName.Trim();
            List<PutHuo> list = new List<PutHuo>();
            PutHuo model;
            string str = "";
            SqlParameter[] pms;
            if (dianpu == "admin")
            {
                if (dpname == "全部")
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from PutHuo where PutDate  between '" + begindate + "' and '" + enddate + "'";
                        pms = new SqlParameter[] {
                    };
                    }
                    else
                    {
                        str = "select * from PutHuo where PutSale=@PutSale";
                        pms = new SqlParameter[] { 
                    new SqlParameter("@PutSale",yginfo.Trim())
                    };
                    }
                }
                else
                {
                    if (yginfo.Trim() == "全部")
                    {
                        str = "select * from PutHuo where PutDate  between '" + begindate + "' and '" + enddate + "' and PutDianName=@PutDianName";
                        pms = new SqlParameter[] {
                            new SqlParameter("@PutDianName",dpname)
                    };
                    }
                    else
                    {
                        str = "select * from PutHuo where PutSale=@PutSale and PutDate  between '" + begindate + "' and '" + enddate + "' and PutDianName=@PutDianName";
                        pms = new SqlParameter[] { 
                    new SqlParameter("@PutSale",yginfo.Trim()),
                     new SqlParameter("@PutDianName",dpname)
                    };
                    }
                }
            }
            else
            {
                if (yginfo.Trim() == "全部")
                {
                    str = "select * from PutHuo where PutDianName=@PutDianName and PutDate  between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@PutDianName",dianpu)
                    };
                }
                else
                {
                    str = "select * from PutHuo where PutDianName=@PutDianName and PutSale=@PutSale and PutDate  between '" + begindate + "' and '" + enddate + "'";
                    pms = new SqlParameter[] { 
                    new SqlParameter("@PutDianName",dianpu),
                    new SqlParameter("@PutSale",yginfo.Trim())
                    };
                }
            }
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
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
        public void AddIteam(PutHuo model)
        {
            string str = "insert into PutHuo(PutNo,PutName,PutType,PutMoney,PutCount,PutCardNo,PutPersonName,PutDate,PutSale,PutDianName) values(@PutNo,@PutName,@PutType,@PutMoney,@PutCount,@PutCardNo,@PutPersonName,@PutDate,@PutSale,@PutDianName)";
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
        public int getIteamId(string staff, string dianpu, string cardno, string date)
        {
            int id = 0;
            string str = "select ID from PutHuo where PutName=@PutName and PutDianName=@PutDianName and PutCardNo=@PutCardNo and PutDate=@PutDate";
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
        public void DeleteIteamID(int gid)
        {
            string str = "delete from PutHuo where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@ID",gid)
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        /// <summary>
        /// 以下三个代表送洗统计，接收统计，返工统计的三个添加方法0代表送洗1代表接收2代表反工
        /// </summary>
        /// <param name="list"></param>
        public bool AddSendXi(List<int> list)
        {
            bool result = false;
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string regx = "('{0}','{1}','{2}'),";
            string str = "insert into SendXI(jcID,DateTime,ZT) values";
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
        public void InDP(List<int> list)
        {
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string regx = "('{0}','{1}','{2}'),";
            string str = "insert into SendXI(jcID,DateTime,ZT) values";
            foreach (int jcid in list)
            {
                str = str + string.Format(regx, jcid, datetime, 1);
            }
            str = str.Substring(0, str.Length - 1);
            SqlHelper.ExecuteNonQuery(str);
        }
        public void AgainSend(List<int> list)
        {
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string regx = "('{0}','{1}','{2}'),";
            string str = "insert into SendXI(jcID,DateTime,ZT) values";
            foreach (int jcid in list)
            {
                str = str + string.Format(regx, jcid, datetime, 2);
            }
            str = str.Substring(0, str.Length - 1);
            SqlHelper.ExecuteNonQuery(str);
        }
    }
}
