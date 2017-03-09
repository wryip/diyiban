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
        public string lbinfo { get; set; }
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
            begindate = TimeGuiGe.TimePicter(dateTimePicker1.Text);
            enddate = TimeGuiGe.TimePicter(dateTimePicker2.Text);
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
                //消费统计
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
                default: spjhdata(dpname);
                    break;
            }
        }
        //商品进货
        private void spjhdata(string name)
        {
            List<InHuoTJ> list = new List<InHuoTJ>();
            list = inhuo.selectListTJ(begindate, enddate, yginfo);
            List<InHuoTJ> list1 = new List<InHuoTJ>();
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.HuoDianName == name)
                    { list1.Add(iteam); }
                }
                dataGridView10.DataSource = list1;
            }            
            dataGridView10.DataSource = list;
        }
        //商品销售
        private void spxsdata(string name)
        {
            List<PutHuo> list = new List<PutHuo>();
            List<PutHuo> list1 = new List<PutHuo>();
            list = inhuo.SelectListXS(begindate, enddate, yginfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.PutDianName == name)
                    { list1.Add(iteam); }
                }
                dataGridView9.DataSource = list1;
                return;
            }
            dataGridView9.DataSource = list;
        }
        //短信统计
        private void dxtjdata(string name)
        {
            List<DXmemberModel> list = new List<DXmemberModel>();
            List<DXmemberModel> list1 = new List<DXmemberModel>();
            list = dxbll.selectListTJ(begindate, enddate, yginfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.DianPu == name)
                    { list1.Add(iteam); }
                }
                dataGridView8.DataSource = list1;
                return;
            }
            dataGridView8.DataSource = list;
        }
        //收入统计
        private void srtjdata(string name)
        {
            List<TJBBSR> list = new List<TJBBSR>();
            List<TJBBSR> list1 = new List<TJBBSR>();
            list = tjbll.selectTJBB(begindate, enddate, yginfo, lbinfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.DianPu == name)
                    { list1.Add(iteam); }
                }
                dataGridView7.DataSource = list1; 
                return;
            }
            dataGridView7.DataSource = list;
        }
        //消费统计
        private void xftjdata(string name)
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            List<LiShiConsumption> list1 = new List<LiShiConsumption>();
            list = lsbll.selectTJ(begindate, enddate, yginfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.LSMultipleName == name)
                    { list1.Add(iteam); }
                }
                dataGridView6.DataSource = list1;
                return;
            }
            dataGridView6.DataSource = list;
        }
        //取走统计
        private void qztjdata(string name)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            List<JCInfoModel> list1 = new List<JCInfoModel>();
            list = jcbll.selectQZTJ(begindate, enddate, yginfo, lbinfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.lsdm == name)
                    { list1.Add(iteam); }
                }
                dataGridView4.DataSource = list1;
                return;
            }
            dataGridView4.DataSource = list;
        }
        //寄存统计
        private void jctjdata(string name)
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            List<JCInfoModel> list1 = new List<JCInfoModel>();
            list = jcbll.selectTJ(begindate, enddate, yginfo, lbinfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.lsdm == name)
                    { list1.Add(iteam); }
                }
                dataGridView3.DataSource = list1;
                return;
            }
            dataGridView3.DataSource = list;
        }
        //充值统计
        private void cztjdata(string name)
        {
            List<memberToUpModel> list = new List<memberToUpModel>();
            List<memberToUpModel> list1 = new List<memberToUpModel>();
            list = czbll.selectTJ(begindate, enddate, yginfo);
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.dianpu == name)
                    { list1.Add(iteam); }
                }
                dataGridView2.DataSource = list1;
                return;
            }
            dataGridView2.DataSource = list;
        }
        //办卡统计
        private void bktjdata(string name)
        {
            List<memberInfoModel> list = bkbll.tjbbOfbk(begindate, enddate, yginfo);
            List<memberInfoModel> list1 = new List<memberInfoModel>();
            if (name != "")
            {
                foreach (var iteam in list)
                {
                    if (iteam.dianName == name)
                    { list1.Add(iteam); }
                }
                dataGridView1.DataSource = list1;
                return;
            }
            dataGridView1.DataSource = list;
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
                bool result = NPOIHelper.PrintDocument<LiShiConsumption>((List<LiShiConsumption>)dataGridView6.DataSource, "消费统计");
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
            else
            {
                bool result = NPOIHelper.PrintDocument<InHuoTJ>((List<InHuoTJ>)dataGridView10.DataSource, "商品进货");
                if (result)
                {
                    MessageBox.Show("导出成功");
                    return;
                }
                MessageBox.Show("导出失败");
            }
        }
    }
}
