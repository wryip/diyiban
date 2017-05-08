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
    public partial class jcform : Form
    {
        public jcform()
        {
            InitializeComponent();
        }
        BLL.LoginUser logbll = new BLL.LoginUser();
        private static jcform _danli = null;
        JCInfoBLL jcbll = new JCInfoBLL();
        DPInfoBLL dpbll = new DPInfoBLL();
        TJBBBLL tjbb = new TJBBBLL();
        public static jcform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new jcform();
            }
            return _danli;
        }
        private void jcform_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            string dpname = FilterClass.DianPu1.UserName.Trim();
            list = jcbll.SelectSongXi(dpname);
            dataGridView3.DataSource = list;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void jcform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        //private void dataGridView3_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        //{
        //    //int count = dataGridView3.Rows.Count;
        //    dataGridView3.Rows[e.RowIndex].Selected = true;
        //}

        //private void 送洗ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
           
        //}

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex == 0)
            {
                dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                numberAdd();
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "全选")
            {
                button1.Text = "取消";
                foreach (DataGridViewRow iteam in dataGridView3.Rows)
                {
                    iteam.Cells["XZ"].Value = true;
                }
            }
            else
            {
                button1.Text = "全选";
                foreach (DataGridViewRow iteam in dataGridView3.Rows)
                {
                    iteam.Cells["XZ"].Value = false;
                }
            }
            numberAdd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<JCInfoModel> jclist = new List<JCInfoModel>();
            List<int> list = new List<int>();
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                    jclist.Add(iteam.DataBoundItem as JCInfoModel);
                }
            }
            if (list.Count <= 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            #region MyRegion
            bool result = jcbll.UpdateSXZT(list);
            //if (result)
            //{
            //foreach (int ID in list)
            //{
            //    string bgjtm = "";
            //    string num = "";
            //    string dpname = FilterClass.DianPu1.UserName.Trim();
            //    //拿到店铺编号，合今日所松溪的数量的number，然后拼接不干胶打印机条码的数字
            //    //第一个是前面的店铺编号，后面的是所卖的数量
            //    string[] dpnumber = dpbll.selectNumberAndNo(dpname);
            //    string dpID = dpnumber[2].Trim();
            //    num = dpnumber[1].Trim();
            //    for (int i = num.Length; i < 4; i++)
            //    {
            //        num = "0" + num;
            //    }
            //    //保存为正确格式的条码
            //    bgjtm = dpnumber[0].Trim() + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + num;
            //    //打印
            //    result = PirentZXingNet.PirentTM(bgjtm);
            //    //成功后打印不干胶条形码
            //    if (result)
            //    {
            //        result = jcbll.UpdatePaiNumber(ID.ToString(), bgjtm);
            //        if (result)
            //        {
            //            int j = Convert.ToInt32(num);
            //            j++;
            //            result = dpbll.uodateNumber(dpID, j);
            //            if (result)
            //            {
            //                count++;
            //                //BindData();
            //                //MessageBox.Show("成功！");
            //            }
            //            //return;
            //        }
            //    }
            //    //MessageBox.Show("失败请稍后再试！");
            //}
            //if (count != 0)
            //{ 
            #endregion
                    //将送洗的东西添加到统计报表
            result=tjbb.AddSendXi(list);
            if (result)
            {
                MessageBox.Show("成功，共送洗" + list.Count.ToString() + "件！");
                BindData();
            }
            //成功送洗之后，打印与物流的小票
            PirentDocumentClass.SendWuLiu(jclist,"物品送洗");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //List<int> list = new List<int>();
            //foreach (DataGridViewRow iteam in dataGridView3.Rows)
            //{
            //    if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
            //    {
            //        list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
            //    }
            //}
            //string ID = dataGridView3.SelectedRows[0].Cells["jcID"].Value.ToString();
            //拿到送洗的ID
            
            YGFinish ygfin = YGFinish.CreateForm(BindData);
            ygfin.Show();
            ygfin.Focus();
        }
        public void BindData(string name)
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                }
            }
            if (list.Count <= 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            bool result = jcbll.UpdateDPFinsh(list);
            //把状态标记为店铺完工
            if (result)
            {
                result = logbll.AddUserFinish(name, list);
            }
            if (result)
            {
                MessageBox.Show("成功！");
                BindData();
                return;
            }
            MessageBox.Show("失败！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<JCInfoModel> jclist = new List<JCInfoModel>();
            //List<int> list = new List<int>();
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    //list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                    jclist.Add(iteam.DataBoundItem as JCInfoModel);
                }
            }
            if (jclist.Count <= 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            foreach (JCInfoModel iteam in jclist)
            {
                PirentZXingNet.PirentTM(iteam.jcPaiNumber, iteam.jcStaff, iteam.jcDanNumber, iteam.jcEndDate,1,1,iteam.jcQuestion,iteam.jcType,iteam.jcPinPai,iteam.jcColor,iteam.jcRemark);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tmnum = textBox1.Text.Trim();
            if (tmnum == "")
            {
                MessageBox.Show("请输入数据！");
                return;
            }
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells["jcPaiNumber"].Value.ToString().Trim() == tmnum)
                {
                    row.Cells["XZ"].Value = true;
                    textBox1.Text = "";
                    //该表lable中的数量信息
                    numberAdd();
                    return;
                }
            }
        }
        private void numberAdd()
        {
            int count = 0;
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    count++;
                }
            }
            label1.Text = count.ToString();
        }
    }
}
