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
    public partial class YGFinish : Form
    {
        public YGFinish()
        {
            InitializeComponent();
        }
        public delegate void Databind(string name);
        public static Databind bind;
        BLL.LoginUser bll = new BLL.LoginUser();
        private static YGFinish _danli = null;
        staffInfoBLL ygbll = new staffInfoBLL();
        public static YGFinish CreateForm(Databind bind1)
        {
            bind = bind1;
            if (_danli == null)
            {
                _danli = new YGFinish();
            }
            return _danli;
        }
        private void YGFinish_Load(object sender, EventArgs e)
        {
            string DPName = FilterClass.DianPu1.UserName.Trim();
            //List<YGUser> list = new List<YGUser>();
            //list = bll.SelectUserName(DPName);
            List<jbcs> list = new List<jbcs>();
            list = ygbll.selectDNWC(DPName);
            dataGridView1.DataSource = list;
        }

        private void YGFinish_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            string UserName = dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString();
            bind(UserName);
            this.Close();
        }
    }
}
