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
        //此类是唯一的只有admin能访问



        //店铺信息DAL
        //插入店铺信息
        public int AddModel(DianPu model)
        {
            //首先判断  当前的店铺名字是否唯一   唯一之后才可添加新店铺
            string dpname = model.DPName.Trim();
            bool isweiyi = DpnameWY(dpname);
            if (!isweiyi)
            {
                return 0;
            }
            string str = "insert into DPInfo(DPName,DPPerson,DPTel,DPAddress,DPRemark,DPContent,DPPicture,DPNo,DPDay,DPNumber,MemberPrint,BGJPrint) values(@DPName,@DPPerson,@DPTel,@DPAddress,@DPRemark,@DPContent,@DPPicture,@DPNo,@DPDay,@DPNumber,@MemberPrint,@BGJPrint);select @@Identity";
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
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(oo);
            }
        }
        //判断店铺是否唯一
        public bool DpnameWY(string dpanme)
        {
            bool result = false;
            string str = "select * from DPInfo where DPName='" + dpanme + "'";
            object oo = SqlHelper.ExecuteScalar(str);
            if (oo == null)
            {
                result= true;
            }
            return result;
        }
        //查询所有店铺的信息
        public List<DianPu> selectAllList()
        {
            List<DianPu> list = new List<DianPu>();
            DianPu model;
            string str = "";
            if (FilterClass.DianPu1.UserName == "admin")
            {
                str = "select * from DPInfo";
            }
            else
            {
                str = "select * from DPInfo where DPName='"+FilterClass.DianPu1.UserName.Trim()+"'";
            }
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
                    model.ID = Convert.ToInt32(read["ID"]);
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
        public bool deleteIteam(int id)
        {
            bool result = false;
            string str = "delete from DPInfo where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@ID",id)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                DeleteTable(id);
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
        //返回一些参数，进行系统登陆之后的保存
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
            string str = "Update DPInfo set DPDay=@DPDay,DPNumber=@DPNumber,DPDan=@DPDan";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPDay",DateTime.Now.Day),
            new SqlParameter("@DPNumber","1"),
            new SqlParameter("@DPDan","1")
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
        public string[] selectDanNumber(string dpname)
        {
            string[] strarry = new string[2];
            string str = "select DPDan,ID from DPInfo where DPName=@DPName";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@DPName",dpname)
            };
            SqlDataReader read = SqlHelper.ExecuteReader(str, pms);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    strarry[0] = read["DPDan"].ToString();
                    strarry[1] = read["ID"].ToString();
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
        public bool uodateDanNumber(string dpID, int j)
        {
            bool result = false;
            string str = "update DPInfo set DPDan=@DPDan where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@ID",dpID),
            new SqlParameter("@DPDan",++j)
            };
            if (SqlHelper.ExecuteNonQuery(str, pms) > 0)
            {
                result = true;
            }
            return result;
        }
        //添加新表
        public void AddTable(int id)
        {
            string str = "create Table CardExitMoney" + id + " (ID int primary key identity(1,1),membername nvarchar(50),membernum nvarchar(50),cardname nvarchar(50),cardtype nvarchar(50),cardmoney nvarchar(50),dpname nvarchar(50),DateTime smalldatetime,LSStaff nvarchar(50))";
            str += "create Table DXSend" + id + " (id int primary key identity(1,1),CardNumber nvarchar(50),MemberName nvarchar(50),TelPhone nvarchar(50),SaleMan nvarchar(50),ContentNR nvarchar(50),DianPu nvarchar(50),Date smalldatetime)";
            str += "create Table ExitCard" + id + " (ID int primary key identity(1,1),memberName nchar(10),saleMen nchar(10),CardMoney nchar(10),CardType nvarchar(50),DPName nvarchar(50),DateTimeCard smalldatetime)";
            str += "create Table ExitDan" + id + " (ID int primary key identity(1,1),memberName nchar(50),memberCardNo nchar(50),saleMen nchar(50),DPName nvarchar(50),DanMoney nvarchar(50),StaffName nvarchar(50),IsMoney nvarchar(50),ExitDanTime smalldatetime)";
            str += "create Table GoodInfo" + id + " (Gid int primary key identity(1,1),Gno nvarchar(50),Gname nvarchar(50),Gtype nvarchar(50),Gremark nvarchar(50),DPName nvarchar(50),Gprice decimal(5, 2),Gbid decimal(5, 2),Gstock int,Gsum int)";
            str += "create Table InHuoTJ" + id + " (ID int primary key identity(1,1),HuoNumber nvarchar(50),HuoName nvarchar(50),HuoType nvarchar(50),HuoMoney nvarchar(50),HuoCount nvarchar(50),HuoSum nvarchar(50),HuoDate smalldatetime,HuoSale nvarchar(50),HuoDianName nvarchar(50))";
            str += "create Table JCInfoTable" + id + " (jcID int primary key identity(1,1),jcCardNumber nvarchar(50),jcName nvarchar(50),jcQMoney nvarchar(50),jcType nvarchar(50),jcPinPai nvarchar(50),jcColor nvarchar(50),jcStaff nvarchar(50),jcBeginDate smalldatetime,jcEndDate smalldatetime,jcZT nchar(10),jcAddress nvarchar(50),jcImgUrl nvarchar(50),jcDanNumber nvarchar(50),jcPaiNumber nvarchar(50),jcRemark nvarchar(50),jcQuestion nvarchar(50),jcPression nvarchar(50),DPName nvarchar(50),XYF nvarchar(50),YYF nvarchar(50))";
            str += "create Table LSConsumption" + id + " (ID int primary key identity(1,1),IsJC bit,IsSP bit,IsXMoney bit,LSName nvarchar(50),LSStaff nvarchar(50),LSNumberCount nvarchar(50),LSMoney nvarchar(50),LSYMoney nvarchar(50),LSCount nvarchar(50),LSPinPai nvarchar(50),LSDate smalldatetime,LSColor nvarchar(50),LSSalesman nvarchar(50),LSMultipleName nvarchar(50),LSQuestion nvarchar(50),LSRemark nvarchar(50),LSDanNumber nvarchar(50),LSCardNumber nvarchar(50),ImgUrl nvarchar(50),FUKUAN bit)";
            str += "create Table memberToUpMoney" + id + " (czId int primary key identity(1,1),czNo nvarchar(50),czSaleman nvarchar(50),czType nvarchar(50),czyCount nvarchar(50),DPName nvarchar(50),czDate smalldatetime,czyMoney nvarchar(50),czCount nvarchar(50),czMoney nvarchar(50),czName nvarchar(50))";
            str += "create Table PutHuo-" + id + " (ID int primary key identity(1,1),PutNo nvarchar(50),PutName nvarchar(50),PutType nvarchar(50),PutMoney nvarchar(50),PutCount nvarchar(50),PutCardNo nvarchar(50),PutDate smalldatetime,PutPersonName nvarchar(50),PutSale nvarchar(50),PutDianName nvarchar(50))";
            str += "create Table WPEnd" + id + " (ID int primary key identity(1,1),Name nvarchar(50),TelPhon nvarchar(50),DanNumber nvarchar(50),DPName nvarchar(50),DateTime smalldatetime,JCID int)";
            str += "create Table SendXI" + id + " (ID int primary key identity(1,1),ZT int,DateTime smalldatetime,JCID nvarchar(50))";
            str += "create Table YGFinish" + id + " (ID int primary key identity(1,1),Name nvarchar(50),DateTime smalldatetime,JCID int)";
            SqlHelper.ExecuteNonQuery(str);
        }
        //删除店铺所对应的表
        public void DeleteTable(int id)
        {
            string str = "drop table CardExitMoney" + id + ";";
            str += "drop Table DXSend" + id + ";";
            str += "drop Table ExitCard" + id + ";";
            str += "drop Table GoodInfo" + id + ";";
            str += "drop Table InHuoTJ" + id + ";";
            str += "drop Table JCInfoTable" + id + ";";
            str += "drop Table LSConsumption" + id + ";";
            str += "drop Table memberToUpMoney" + id + ";";
            str += "drop Table PutHuoTJ" + id + ";";
            str += "drop Table WPEnd" + id + ";";
            str += "drop Table SendXI" + id + ";";
            str += "drop Table ExitDan" + id + ";";
            SqlHelper.ExecuteNonQuery(str);
        }
        //将所有店铺的信息   进行字典类型的返回   
        public Dictionary<string, int> SelectAllDictionary()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
             string str = "select DPName,ID from DPInfo";
            SqlDataReader read = SqlHelper.ExecuteReader(str);
            while (read.Read())
            {
                if (read.HasRows)
                {
                    dic.Add(read["DPName"].ToString().Trim(), Convert.ToInt32(read["ID"]));
                }
            }
            return dic;
        }
        //将没vi登陆的信息保存，以便下次登陆时自动填充
        public void AddDPAndUser(string id, string dpname, string username,string ipaddress)
        {
            if (id == null)
            {
                return;
            }
            string str = "update DPInfo set LoginInfo=@LoginInfo,IpAddress=@IpAddress where ID=@ID";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@LoginInfo",dpname.Trim()+","+username.Trim()),
            new SqlParameter("@IpAddress",ipaddress),
            new SqlParameter("@ID",id)
            };
            SqlHelper.ExecuteNonQuery(str, pms);
        }
        public string selectLoginInfo(string ipaddress)
        {
            string str = "select LoginInfo from DPInfo where IpAddress=@IpAddress";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@IpAddress",ipaddress)
            };
            object oo = SqlHelper.ExecuteScalar(str, pms);
            if (oo != null)
            {
                return oo.ToString();
            }
            return "";
        }
    }
}
