using BLL;
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
            List<jbcs> list = jbcsbll.selectList(6);
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
            begindate = dateTimePicker1.Text.Trim();
            enddate = dateTimePicker2.Text.Trim();
            yginfo = comboBox1.Text.Trim();
            lbinfo = comboBox2.Text.Trim();
            int selectIndex=tabControl1.SelectedIndex;
            switch (selectIndex)
            {
                    //办卡统计
                case 0: bktjdata();
                    break;
                //充值统计
                case 1: cztjdata();
                    break;
                //寄存统计
                case 2: jctjdata();
                    break;
                //取走统计
                case 3: qztjdata();
                    break;
                //消费统计
                case 4: xftjdata();
                    break;
                //收入统计
                case 5: srtjdata();
                    break;
                //短信统计
                case 6: dxtjdata();
                    break;
                //商品销售
                case 7: spxsdata();
                    break;
                default: spjhdata();
                    break;
            }
        }
        //商品进货
        private void spjhdata()
        {
            throw new NotImplementedException();
        }
        //商品销售
        private void spxsdata()
        {
            throw new NotImplementedException();
        }
        //短信统计
        private void dxtjdata()
        {
            List<DXmemberModel> list = new List<DXmemberModel>();
            list = dxbll.selectListTJ(begindate, enddate, yginfo);
            dataGridView8.DataSource = list;
        }
        //收入统计
        private void srtjdata()
        {
            List<TJBBSR> list = new List<TJBBSR>();
            list = tjbll.selectTJBB(begindate, enddate, yginfo, lbinfo);
            dataGridView7.DataSource = list;
        }
        //消费统计
        private void xftjdata()
        {
            List<LiShiConsumption> list = new List<LiShiConsumption>();
            list = lsbll.selectTJ(begindate, enddate, yginfo);
            dataGridView6.DataSource = list;
        }
        //取走统计
        private void qztjdata()
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = jcbll.selectQZTJ(begindate, enddate, yginfo, lbinfo);
            dataGridView4.DataSource = list;
        }
        //寄存统计
        private void jctjdata()
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = jcbll.selectTJ(begindate, enddate, yginfo, lbinfo);
            dataGridView3.DataSource = list;
        }
        //充值统计
        private void cztjdata()
        {
            List<memberToUpModel> list = new List<memberToUpModel>();
            list = czbll.selectTJ(begindate, enddate, yginfo);
            dataGridView2.DataSource = list;
        }
        //办卡统计
        private void bktjdata()
        {
            List<memberInfoModel> list = bkbll.tjbbOfbk(begindate, enddate, yginfo);
            dataGridView1.DataSource = list;
        }
    }
}
