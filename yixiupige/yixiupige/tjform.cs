using BLL;
using Commond;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yixiupige
{
    public partial class tjfrom : Form
    {
        public string begindate { get; set; }
        public string enddate { get; set; }
        public string yginfo { get; set; }
        CardExitMoneyBll carexit = new CardExitMoneyBll();
        BLL.LoginUser logfinish = new BLL.LoginUser();
        QZEndBLL qzbll = new QZEndBLL();
        ExitDanBLL exitdan = new ExitDanBLL();
        public string lbinfo { get; set; }
        ExitCardBLL exitbll = new ExitCardBLL();
        DPInfoBLL dpbll = new DPInfoBLL();
        staffInfoBLL staffbll=new staffInfoBLL();
        TJBBBLL inhuo = new TJBBBLL();
        DXSendBLL dxbll = new DXSendBLL();
        TJBBBLL tjbll = new TJBBBLL();
        LSConsumptionBLL lsbll = new LSConsumptionBLL();
        JCInfoBLL jcbll = new JCInfoBLL();
        memberCZMoneyBLL czbll = new memberCZMoneyBLL();
        memberInfoBLL bkbll = new memberInfoBLL();
        public tjfrom()
        {
            InitializeComponent();
        }
        //加载所有员工
        jbcsBLL jbcsbll = new jbcsBLL();
        private static tjfrom _danli = null;
        public static tjfrom CreateForm()
        {
            if (_danli == null)
            {
                _danli = new tjfrom();
            }
            return _danli;
        }
        private void tjform_Load(object sender, EventArgs e)
        {
            List<jbcs> list;
            string dianname = FilterClass.DianPu1.UserName;
            if (dianname.Trim() == "admin")
            {
                comboBox3.Items.Add("全部");
                label5.Visible = true;
                comboBox3.Visible = true;
                List<string> str = dpbll.selectDPName();
                foreach (var iteam in str)
                {
                    comboBox3.Items.Add(iteam);
                }
                comboBox3.SelectedIndex = 0;
            }
            list = staffbll.selectSH();
            comboBox1.Items.Add("全部");
            comboBox2.Items.Add("全部");
            foreach (var iteam in list)
            {
                comboBox1.Items.Add(iteam.AllType);
            }
            comboBox1.SelectedIndex = 0;
            list = jbcsbll.selectList(5);
            foreach (var iteam in list)
            {
                comboBox2.Items.Add(iteam.AllType);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void tjform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dpname="";
            if (comboBox3.Visible)
            {
                dpname = comboBox3.Text;
            }
            begindate = TimeGuiGe.TimePicterBegin(dateTimePicker1.Text);
            enddate = TimeGuiGe.TimePicterEng(dateTimePicker2.Text);
            yginfo = comboBox1.Text.Trim();
            lbinfo = comboBox2.Text.Trim();
            int selectIndex=tabControl1.SelectedIndex;
            switch (selectIndex)
            {
                    //办卡统计
                case 0: bktjdata(dpname);
                    break;
                //充值统计
                case 1: cztjdata(dpname);
                    break;
                //寄存统计
                case 2: jctjdata(dpname);
                    break;
                //取走统计
                case 3: qztjdata(dpname);
                    break;
                //会员卡消费统计
                case 4: xftjdata(dpname);
                    break;
                //收入统计
                case 5: srtjdata(dpname);
                    break;
                //短信统计
                case 6: dxtjdata(dpname);
                    break;
                //商品销售
                case 7: spxsdata(dpname);
                    break;
                case 8: spjhdata(dpname);
                    break;
                case 9: ExitCard(dpname);
                    break;
                case 10: Exitdan(dpname);
                    break;
                case 11: QMoneyJC(dpname);
                    break;
                case 12: wpqzAction(dpname);
                    break;
                case 13: sendXI(dpname);
                    break;
                case 14: InDP(dpname);
                    break;
                case 15: againSend(dpname);
                    break;
                case 16: YGFinish(dpname);
                    break;
                //case 17: XMoneyLS(dpname);
                //    break;
            }
        }
        //现金消费
        //private void XMoneyLS(string dpname)
        //{
        //    double money = 0;
        //    List<XMoneyLS> list = lsbll.SelectXMoney(begindate, enddate, dpname);
        //    dataGridView18.DataSource = list;
        //    foreach (var iteam in list)
        //    {
        //        money += Convert.ToDouble(iteam.MoneyXM);
        //    }
        //    label8.Text = list.Count.ToString();
        //    label9.Text = money.ToString();
        //}
        //店内完成
        private void YGFinish(string dpname)
        {
            double money = 0;
            List<JCInfoModel> list = logfinish.YGFinish(begindate, enddate, dpname);
            dataGridView17.DataSource = list;
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcNo);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
        }
        /// <summary>
        /// 返工统计
        /// </summary>
        /// <param name="dpname"></param>
        private void againSend(string dpname)
        {
            double money = 0;
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = jcbll.selectTJagainSend(begindate, enddate,dpname);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcNo);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView16.DataSource = list;
        }
        /// <summary>
        /// 店铺接收
        /// </summary>
        /// <param name="dpname"></param>
        private void InDP(string dpname)
        {
            double money = 0;
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = jcbll.selectTJInDP(begindate, enddate, dpname);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcNo);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView15.DataSource = list;
        }
        /// <summary>
        /// 送洗统计
        /// </summary>
        /// <param name="dpname"></param>
        private void sendXI(string dpname)
        {
            double money = 0;
            List<JCInfoModel> list = new List<JCInfoModel>();
            //List<JCInfoModel> list1 = new List<JCInfoModel>();
            list = jcbll.selectTJSendXi(begindate, enddate,dpname);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcNo);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView14.DataSource = list;
        }

        private void wpqzAction(string dpname)
        {
            double money = 0;
            List<WPEnd> list = new List<WPEnd>();            
            list = qzbll.SelectAll(begindate, enddate, dpname);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.ID);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView13.DataSource = list;
        }
        /// <summary>
        /// 寄存欠款
        /// </summary>
        /// <param name="name"></param>
        private void QMoneyJC(string name)
        {
            double money = 0;
            List<JCInfoModel> list = new List<JCInfoModel>();       
            list = jcbll.selectQMoney(begindate, enddate,name);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcQMoney);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView12.DataSource = list;
        }
        /// <summary>
        /// 退单统计
        /// </summary>
        /// <param name="name"></param>
        private void Exitdan(string name)
        {
            double money = 0;
            List<ExitDanModel> list = new List<ExitDanModel>();
            list = exitdan.SelectAllList(begindate, enddate, name);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.DanMoney);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView11.DataSource = list;
        }
        /// <summary>
        /// 退卡统计
        /// </summary>
        /// <param name="name"></param>
        private void ExitCard(string name)
        {
            double money = 0;
            List<ExitCardModel> list=new List<ExitCardModel>();
            list=exitbll.SelectAllList(begindate, enddate,name);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.CardMoney);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView5.DataSource = list;
        }
        //商品进货
        private void spjhdata(string name)
        {
            double money = 0;
            List<InHuoTJ> list = new List<InHuoTJ>();
            list = inhuo.selectListTJ(begindate, enddate, yginfo, name);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.HuoMoney);
            }           
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
            dataGridView10.DataSource = list;
        }
        //商品销售
        private void spxsdata(string name)
        {
            double money = 0;
            int count = 0;
            List<PutHuo> list = new List<PutHuo>();
            list = inhuo.SelectListXS(begindate, enddate, yginfo, name);
            foreach (var iteam in list)
            {
                count += Convert.ToInt32(iteam.PutCount);
                money += Convert.ToDouble(iteam.PutMoney);
            }
            label8.Text = count.ToString();
            label9.Text = money.ToString();
            dataGridView9.DataSource = list;
        }
        //短信统计
        private void dxtjdata(string name)
        {
            List<DXmemberModel> list = new List<DXmemberModel>();
            list = dxbll.selectListTJ(begindate, enddate, name);
            dataGridView8.DataSource = list;
        }
        //收入统计函数提前改过
        private void srtjdata(string name)
        {
            double money = 0;
            List<TJBBSR> list = new List<TJBBSR>();
            list = tjbll.selectTJBB(begindate, enddate, yginfo, lbinfo, name);
            dataGridView7.DataSource = list;
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.Money);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
        }
        //消费统计
        private void xftjdata(string name)
        {
            double money = 0;
            List<CardExitMoney> list = new List<CardExitMoney>();
            list = carexit.selectTJ(begindate, enddate, name);
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.cardmoney);
            }
            //List<LiShiConsumption> list = new List<LiShiConsumption>();
            //list = lsbll.selectTJ(begindate, enddate, yginfo, name);
            dataGridView6.DataSource = list;
            //foreach (var iteam in list)
            //{
            //    money += Convert.ToDouble(iteam.LSMoney);
            //}
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
        }
        //取走统计
        private void qztjdata(string name)
        {
            double money = 0;
            List<JCInfoModel> list = new List<JCInfoModel>();
            List<JCInfoModel> list1 = new List<JCInfoModel>();
            list = jcbll.selectQZTJ(begindate, enddate, yginfo, lbinfo, name);
            //if (name != "")
            //{
            //    foreach (var iteam in list)
            //    {
            //        if (iteam.lsdm == name)
            //        {
            //            list1.Add(iteam);
            //            money += Convert.ToDouble(iteam.jcNo);
            //        }
            //    }
            //    dataGridView4.DataSource = list1;
            //    label8.Text = list1.Count.ToString();
            //    label9.Text = money.ToString();
            //    return;
            //}
            dataGridView4.DataSource = list;
            label8.Text = list.Count.ToString();
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcNo);
            }
            label9.Text = money.ToString();
        }
        //寄存统计
        private void jctjdata(string name)
        {
            double money = 0;            
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = jcbll.selectTJ(begindate, enddate, yginfo, lbinfo, name);
            dataGridView3.DataSource = list;
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.jcNo);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
        }
        //充值统计
        private void cztjdata(string name)
        {
            double money = 0;
            List<memberToUpModel> list = new List<memberToUpModel>();
            list = czbll.selectTJ(begindate, enddate, yginfo, name);
            dataGridView2.DataSource = list;
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.czMoney);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
        }
        //办卡统计
        private void bktjdata(string name)
        {
            double money = 0;
            List<memberInfoModel> list = bkbll.tjbbOfbk(begindate, enddate, name.Trim());
            dataGridView1.DataSource = list;
            foreach (var iteam in list)
            {
                money += Convert.ToDouble(iteam.cardMoney);
            }
            label8.Text = list.Count.ToString();
            label9.Text = money.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectIndex = tabControl1.SelectedIndex;
            if (selectIndex == 0)
            {
                bool result=NPOIHelper.PrintDocument<memberInfoModel>((List < memberInfoModel >)dataGridView1.DataSource, "办卡统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 1)
            {
                bool result = NPOIHelper.PrintDocument<memberToUpModel>((List<memberToUpModel>)dataGridView2.DataSource, "充值统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 2)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView3.DataSource, "寄存统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 3)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView4.DataSource, "取走统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 4)
            {
                bool result = NPOIHelper.PrintDocument<CardExitMoney>((List<CardExitMoney>)dataGridView6.DataSource, "会员卡消费");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 5)
            {
                bool result = NPOIHelper.PrintDocument<TJBBSR>((List<TJBBSR>)dataGridView7.DataSource, "收入统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 6)
            {
                bool result = NPOIHelper.PrintDocument<DXmemberModel>((List<DXmemberModel>)dataGridView8.DataSource, "短信统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 7)
            {
                bool result = NPOIHelper.PrintDocument<PutHuo>((List<PutHuo>)dataGridView9.DataSource, "商品销售");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 8)
            {
                bool result = NPOIHelper.PrintDocument<InHuoTJ>((List<InHuoTJ>)dataGridView10.DataSource, "商品补货");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 9)
            {
                bool result = NPOIHelper.PrintDocument<ExitCardModel>((List<ExitCardModel>)dataGridView5.DataSource, "会员退卡");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 10)
            {
                bool result = NPOIHelper.PrintDocument<ExitDanModel>((List<ExitDanModel>)dataGridView11.DataSource, "会员退单");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 11)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView12.DataSource, "欠款统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 12)
            {
                bool result = NPOIHelper.PrintDocument<WPEnd>((List<WPEnd>)dataGridView13.DataSource, "无票取走");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 13)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView13.DataSource, "送洗统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 14)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView14.DataSource, "接收统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 15)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView15.DataSource, "返工统计");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            else if (selectIndex == 16)
            {
                bool result = NPOIHelper.PrintDocument<JCInfoModel>((List<JCInfoModel>)dataGridView17.DataSource, "店内完成");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
            //else if (selectIndex == 17)
            //{
            //    bool result = NPOIHelper.PrintDocument<XMoneyLS>((List<XMoneyLS>)dataGridView18.DataSource, "现金消费");
            //    if (result)
            //    {
            //        MessageBox.Show("导出成功");
            //        return;
            //    }
            //    MessageBox.Show("导出失败");
            //}
        }
    }
}
