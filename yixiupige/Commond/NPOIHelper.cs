using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using MODEL;

namespace Commond
{
    public static class NPOIHelper
    {
        public static bool PrintDocument<T>(List<T> list,string name)
        {
            //创建一个集合
            //List<Person> list = new List<Person>() { 
            //new Person(){ Name="张楠", Age=18, Email="zhangnan@163.com"},
            //new Person(){ Name="王鑫", Age=19, Email="wangxin@yahoo.com"},
            //new Person(){ Name="刘翰", Age=17, Email="liuhan@sohu.com"}
            //};

            //Excel导出数据的步骤
            //1.创建一个空的Workbook对象（工作簿）
            IWorkbook wk = new HSSFWorkbook();

            //2.创建一个工作表Sheet
            ISheet sheet = wk.CreateSheet(name);
            //3.创建sheet中的行
            //遍历list
            #region MyRegion//利用工厂看为什么模型
            //int rowIndex = 0;
            //foreach (T item in list)
            //{
            //    //每遍历一条数据创建一行
            //    IRow row = sheet.CreateRow(rowIndex);
            //    //创建行中的单元格
            //    row.CreateCell(0).SetCellValue(item.Name);
            //    row.CreateCell(1).SetCellValue(item.Age);
            //    row.CreateCell(2).SetCellValue(item.Email);
            //    rowIndex++;
            //} 
            #endregion
            wk=FactoryModel(list, sheet);
            string dirpath = "..\\..\\memberInfo";
            string path = dirpath + "\\" + name+DateTime.Now.ToString("yyyy MM dd") + ".xls";
            //4.把内存当中的workbook写入到磁盘中
            using (FileStream fsWrite = File.OpenWrite(path))
            {
                wk.Write(fsWrite);
                return true;
            }
        }
        public static IWorkbook FactoryModel<T>(List<T> list, ISheet sheet)
        {
            var model=list[0];
            if (model is memberInfoModel)
            {
                return memberInfopirent(list, sheet);
            }
            else if (model is memberToUpModel)
            {
                return toupmoneypirent(list, sheet);
            }
            else if (model is JCInfoModel)
            {
                return jcinfopirent(list, sheet);
            }
            else if (model is WPEnd)
            {
                return wupiaopirent(list, sheet);
            }
            else if (model is CardExitMoney)
            {
                return lishiinfopirent(list, sheet);
            }
            else if (model is TJBBSR)
            {
                return shourupirent(list, sheet);
            }
            else if (model is DXmemberModel)
            {
                return shortinfopirent(list, sheet);
            }
            else if (model is PutHuo)
            {
                return huoputpirent(list, sheet);
            }
            else if(model is ExitCardModel)
            {
                return huiyuanExitCard(list, sheet);
            }
            else //if (model is ExitDanModel)
            {
                return huiyuanExitDan(list, sheet);
            }
        }

        private static IWorkbook wupiaopirent<T>(List<T> list, ISheet sheet)
        {
            //
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("取走时间");
            row.CreateCell(1).SetCellValue("单号");
            row.CreateCell(2).SetCellValue("店铺名称");
            row.CreateCell(3).SetCellValue("取走人姓名");
            row.CreateCell(4).SetCellValue("取走人电话");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                WPEnd model = item as WPEnd;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.DateTime);
                row.CreateCell(1).SetCellValue(model.DanNumber);
                row.CreateCell(2).SetCellValue(model.DPName);
                row.CreateCell(3).SetCellValue(model.Name);
                row.CreateCell(4).SetCellValue(model.TelPhon);
                rowIndex++;
            }
            return sheet.Workbook;
        }

        private static IWorkbook huiyuanExitDan<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("会员名称");
            row.CreateCell(1).SetCellValue("会员卡号");
            row.CreateCell(2).SetCellValue("业务员");
            row.CreateCell(3).SetCellValue("所属店铺");
            row.CreateCell(4).SetCellValue("金额");
            row.CreateCell(5).SetCellValue("服务名称");
            row.CreateCell(6).SetCellValue("退单时间");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                ExitDanModel model = item as ExitDanModel;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.memberName);
                row.CreateCell(1).SetCellValue(model.memberCardNo);
                row.CreateCell(2).SetCellValue(model.saleMen);
                row.CreateCell(3).SetCellValue(model.DPName);
                row.CreateCell(4).SetCellValue(model.DanMoney);
                row.CreateCell(5).SetCellValue(model.StaffName);
                row.CreateCell(6).SetCellValue(model.ExitDanTime);
                rowIndex++;
            }
            return sheet.Workbook;
        }

        private static IWorkbook huiyuanExitCard<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("会员姓名");
            row.CreateCell(1).SetCellValue("退卡日期");
            row.CreateCell(2).SetCellValue("业务员");
            row.CreateCell(3).SetCellValue("退卡金额");
            row.CreateCell(4).SetCellValue("退卡类型");
            row.CreateCell(5).SetCellValue("所属店铺");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                ExitCardModel model = item as ExitCardModel;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.memberName);
                row.CreateCell(1).SetCellValue(model.DateTimeCard);
                row.CreateCell(2).SetCellValue(model.saleMen);
                row.CreateCell(3).SetCellValue(model.CardMoney);
                row.CreateCell(4).SetCellValue(model.CardType);
                row.CreateCell(5).SetCellValue(model.DPName);
                rowIndex++;
            }
            return sheet.Workbook;
        }

        private static IWorkbook huoinpirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("库存号");
            row.CreateCell(1).SetCellValue("商品名称");
            row.CreateCell(2).SetCellValue("商品类型");
            row.CreateCell(3).SetCellValue("金额");
            row.CreateCell(4).SetCellValue("进货数量");
            row.CreateCell(5).SetCellValue("总库存");
            row.CreateCell(6).SetCellValue("进货日期");
            row.CreateCell(7).SetCellValue("业务员");
            row.CreateCell(8).SetCellValue("店铺名称");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                InHuoTJ model = item as InHuoTJ;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.HuoNumber);
                row.CreateCell(1).SetCellValue(model.HuoName);
                row.CreateCell(2).SetCellValue(model.HuoType);
                row.CreateCell(3).SetCellValue(model.HuoMoney);
                row.CreateCell(4).SetCellValue(model.HuoCount);
                row.CreateCell(5).SetCellValue(model.HuoSum);
                row.CreateCell(6).SetCellValue(model.HuoDate);
                row.CreateCell(7).SetCellValue(model.HuoSale);
                row.CreateCell(8).SetCellValue(model.HuoDianName);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 商品销售导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook huoputpirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("库存号");
            row.CreateCell(1).SetCellValue("商品名称");
            row.CreateCell(2).SetCellValue("商品类型");
            row.CreateCell(3).SetCellValue("金额");
            row.CreateCell(4).SetCellValue("会员卡号");
            row.CreateCell(5).SetCellValue("数量");
            row.CreateCell(6).SetCellValue("业务员");
            row.CreateCell(7).SetCellValue("客户姓名");
            row.CreateCell(8).SetCellValue("日期");
            row.CreateCell(9).SetCellValue("店铺名称");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                PutHuo model = item as PutHuo;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.PutNo);
                row.CreateCell(1).SetCellValue(model.PutName);
                row.CreateCell(2).SetCellValue(model.PutType);
                row.CreateCell(3).SetCellValue(model.PutMoney);
                row.CreateCell(4).SetCellValue(model.PutCardNo);
                row.CreateCell(5).SetCellValue(model.PutCount);
                row.CreateCell(6).SetCellValue(model.PutSale);
                row.CreateCell(7).SetCellValue(model.PubPersonName);
                row.CreateCell(8).SetCellValue(model.PutDate);
                row.CreateCell(9).SetCellValue(model.PutDianName);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 短信导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook shortinfopirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("卡号");
            row.CreateCell(1).SetCellValue("会员名称");
            row.CreateCell(2).SetCellValue("电话号码");
            row.CreateCell(3).SetCellValue("日期");
            row.CreateCell(4).SetCellValue("业务员");
            row.CreateCell(5).SetCellValue("发送内容");
            row.CreateCell(6).SetCellValue("店铺名称");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                DXmemberModel model = item as DXmemberModel;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.CardNumber);
                row.CreateCell(1).SetCellValue(model.MemberName);
                row.CreateCell(2).SetCellValue(model.TelPhone);
                row.CreateCell(3).SetCellValue(model.Date);
                row.CreateCell(4).SetCellValue(model.SaleMan);
                row.CreateCell(5).SetCellValue(model.Content);
                row.CreateCell(6).SetCellValue(model.DianPu);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 收入信息表导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook shourupirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("收入名称");
            row.CreateCell(1).SetCellValue("收入日期");
            row.CreateCell(2).SetCellValue("金额");
            row.CreateCell(3).SetCellValue("业务员");
            row.CreateCell(4).SetCellValue("店铺名称");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                TJBBSR model = item as TJBBSR;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.Name);
                row.CreateCell(1).SetCellValue(model.Date);
                row.CreateCell(2).SetCellValue(model.Money);
                row.CreateCell(3).SetCellValue(model.SaleMan);
                row.CreateCell(4).SetCellValue(model.DianPu);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 历史消费记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook lishiinfopirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("会员姓名");
            row.CreateCell(1).SetCellValue("会员卡号");
            row.CreateCell(2).SetCellValue("卡名字");
            row.CreateCell(3).SetCellValue("卡类型");
            row.CreateCell(4).SetCellValue("消费金额");
            row.CreateCell(5).SetCellValue("所属店铺");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                CardExitMoney model = item as CardExitMoney;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.membername);
                row.CreateCell(1).SetCellValue(model.membernum);
                row.CreateCell(2).SetCellValue(model.cardname);
                row.CreateCell(3).SetCellValue(model.cardtype);
                row.CreateCell(4).SetCellValue(model.cardmoney);
                row.CreateCell(5).SetCellValue(model.dpname);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 取走导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        //private static IWorkbook quzoufopirent<T>(List<T> list, ISheet sheet)
        //{
        //    int rowIndex = 0;
        //    IRow row = sheet.CreateRow(rowIndex);
        //    #region MyRegion//表头
        //    row.CreateCell(0).SetCellValue("会员卡号");
        //    row.CreateCell(1).SetCellValue("会员姓名");
        //    row.CreateCell(2).SetCellValue("欠款金额");
        //    row.CreateCell(3).SetCellValue("寄存类型");
        //    row.CreateCell(4).SetCellValue("寄存品牌");
        //    row.CreateCell(5).SetCellValue("寄存颜色");
        //    row.CreateCell(6).SetCellValue("服务类型");
        //    row.CreateCell(7).SetCellValue("寄存时间");
        //    row.CreateCell(8).SetCellValue("取走时间");
        //    row.CreateCell(9).SetCellValue("物品状态");
        //    row.CreateCell(10).SetCellValue("消费单号");
        //    row.CreateCell(11).SetCellValue("备注");
        //    row.CreateCell(12).SetCellValue("常见问题");
        //    row.CreateCell(13).SetCellValue("业务员");
        //    row.CreateCell(14).SetCellValue("店铺名称");
        //    rowIndex++;
        //    #endregion
        //    foreach (T item in list)
        //    {
        //        JCInfoModel model = item as JCInfoModel;
        //        //每遍历一条数据创建一行
        //        row = sheet.CreateRow(rowIndex);
        //        //创建行中的单元格
        //        row.CreateCell(0).SetCellValue(model.jcCardNumber);
        //        row.CreateCell(1).SetCellValue(model.jcName);
        //        row.CreateCell(2).SetCellValue(model.jcQMoney);
        //        row.CreateCell(3).SetCellValue(model.jcType);
        //        row.CreateCell(4).SetCellValue(model.jcPinPai);
        //        row.CreateCell(5).SetCellValue(model.jcColor);
        //        row.CreateCell(6).SetCellValue(model.jcType);
        //        row.CreateCell(7).SetCellValue(model.jcBeginDate);
        //        row.CreateCell(8).SetCellValue(model.jcEndDate);
        //        row.CreateCell(9).SetCellValue(model.jcAddress);
        //        row.CreateCell(10).SetCellValue(model.jcDanNumber);
        //        row.CreateCell(11).SetCellValue(model.jcRemark);
        //        row.CreateCell(12).SetCellValue(model.jcQuestion);
        //        row.CreateCell(13).SetCellValue(model.jcPression);
        //        row.CreateCell(14).SetCellValue(model.lsdm);
        //        rowIndex++;
        //    }
        //    return sheet.Workbook;
        //}
        /// <summary>
        /// 寄存导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook jcinfopirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("会员卡号");
            row.CreateCell(1).SetCellValue("会员姓名");
            row.CreateCell(2).SetCellValue("欠款金额");
            row.CreateCell(3).SetCellValue("寄存类型");
            row.CreateCell(4).SetCellValue("寄存品牌");
            row.CreateCell(5).SetCellValue("寄存颜色");
            row.CreateCell(6).SetCellValue("服务类型");
            row.CreateCell(7).SetCellValue("寄存时间");
            row.CreateCell(8).SetCellValue("取走时间");
            row.CreateCell(9).SetCellValue("物品状态");
            row.CreateCell(10).SetCellValue("消费单号");
            row.CreateCell(11).SetCellValue("备注");
            row.CreateCell(12).SetCellValue("常见问题");
            row.CreateCell(13).SetCellValue("业务员");
            row.CreateCell(14).SetCellValue("店铺名称");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                JCInfoModel model = item as JCInfoModel;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.jcCardNumber);
                row.CreateCell(1).SetCellValue(model.jcName);
                row.CreateCell(2).SetCellValue(model.jcQMoney);
                row.CreateCell(3).SetCellValue(model.jcType);
                row.CreateCell(4).SetCellValue(model.jcPinPai);
                row.CreateCell(5).SetCellValue(model.jcColor);
                row.CreateCell(6).SetCellValue(model.jcType);
                row.CreateCell(7).SetCellValue(model.jcBeginDate);
                row.CreateCell(8).SetCellValue(model.jcEndDate);
                row.CreateCell(9).SetCellValue(model.jcAddress);
                row.CreateCell(10).SetCellValue(model.jcDanNumber);
                row.CreateCell(11).SetCellValue(model.jcRemark);
                row.CreateCell(12).SetCellValue(model.jcQuestion);
                row.CreateCell(13).SetCellValue(model.jcPression);
                row.CreateCell(14).SetCellValue(model.lsdm);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 充值导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook toupmoneypirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("会员卡号");
            row.CreateCell(1).SetCellValue("会员姓名");
            row.CreateCell(2).SetCellValue("卡类型");
            row.CreateCell(3).SetCellValue("充值日期");
            row.CreateCell(4).SetCellValue("业务员");
            row.CreateCell(5).SetCellValue("店铺名");
            row.CreateCell(6).SetCellValue("充值金额");
            row.CreateCell(7).SetCellValue("充值次数");
            row.CreateCell(8).SetCellValue("剩余金额");
            row.CreateCell(9).SetCellValue("剩余次数");
            rowIndex++;
            #endregion
            foreach (T item in list)
            {
                memberToUpModel model = item as memberToUpModel;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.czNo);
                row.CreateCell(1).SetCellValue(model.czName);
                row.CreateCell(2).SetCellValue(model.czType);
                row.CreateCell(3).SetCellValue(model.czDate);
                row.CreateCell(4).SetCellValue(model.czSaleman);
                row.CreateCell(5).SetCellValue(model.dianpu);
                row.CreateCell(6).SetCellValue(model.czMoney);
                row.CreateCell(7).SetCellValue(model.czCount);
                row.CreateCell(8).SetCellValue(model.czyMoney);
                row.CreateCell(9).SetCellValue(model.czyCount);
                rowIndex++;
            }
            return sheet.Workbook;
        }
        /// <summary>
        /// 办卡导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static IWorkbook memberInfopirent<T>(List<T> list, ISheet sheet)
        {
            int rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex);
            #region MyRegion//表头
            row.CreateCell(0).SetCellValue("会员卡号");
            row.CreateCell(1).SetCellValue("会员姓名");
            row.CreateCell(2).SetCellValue("会员电话");
            row.CreateCell(3).SetCellValue("会员生日");
            row.CreateCell(4).SetCellValue("身份证号");
            row.CreateCell(5).SetCellValue("办卡日期");
            row.CreateCell(6).SetCellValue("会员性别");
            row.CreateCell(7).SetCellValue("折扣");
            row.CreateCell(8).SetCellValue("卡到期");
            row.CreateCell(9).SetCellValue("服务折扣");
            row.CreateCell(10).SetCellValue("充值金额");
            row.CreateCell(11).SetCellValue("办卡金额");
            row.CreateCell(12).SetCellValue("店铺名");
            row.CreateCell(13).SetCellValue("卡类型");
            row.CreateCell(14).SetCellValue("业务员");
            row.CreateCell(15).SetCellValue("会员类别");
            row.CreateCell(16).SetCellValue("地址");
            row.CreateCell(17).SetCellValue("备注");
            row.CreateCell(18).SetCellValue("状态");
            row.CreateCell(19).SetCellValue("密码");
            rowIndex++; 
            #endregion
            foreach (T item in list)
            {
                memberInfoModel model = item as memberInfoModel;
                //每遍历一条数据创建一行
                row = sheet.CreateRow(rowIndex);
                //创建行中的单元格
                row.CreateCell(0).SetCellValue(model.memberCardNo);
                row.CreateCell(1).SetCellValue(model.memberName);
                row.CreateCell(2).SetCellValue(model.memberTel);
                row.CreateCell(3).SetCellValue(model.birDate);
                row.CreateCell(4).SetCellValue(model.memberDocument);
                row.CreateCell(5).SetCellValue(model.cardDate);
                row.CreateCell(6).SetCellValue(model.memberSex);
                row.CreateCell(7).SetCellValue(model.rebate);
                row.CreateCell(8).SetCellValue(model.endDate);
                row.CreateCell(9).SetCellValue(model.fuwuBate);
                row.CreateCell(10).SetCellValue(model.toUpMoney);
                row.CreateCell(11).SetCellValue(model.cardMoney);
                row.CreateCell(12).SetCellValue(model.dianName);
                row.CreateCell(13).SetCellValue(model.cardType);
                row.CreateCell(14).SetCellValue(model.saleMan);
                row.CreateCell(15).SetCellValue(model.memberType);
                row.CreateCell(16).SetCellValue(model.address);
                row.CreateCell(17).SetCellValue(model.remark);
                row.CreateCell(18).SetCellValue(model.zhuangtai);
                row.CreateCell(19).SetCellValue(model.password);
                rowIndex++;
            }
            return sheet.Workbook;
        }
    }
}
