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
    public partial class QHFrom : Form
    {
        public QHFrom()
        {
            InitializeComponent();
        }
        QZEndBLL qzbll = new QZEndBLL();
        JCInfoBLL bll = new JCInfoBLL();
        private static QHFrom _danli = null;
        public static QHFrom CreateForm()
        {
            if (_danli == null)
            {
                _danli = new QHFrom();
            }
            return _danli;
        }
        private void QHFrom_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //取走绑定数据
            //databindview1();
            //退回绑定数据
        }

        private void databindview1()
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = bll.selectFinishJC(FilterClass.DianPu1.UserName);
            dataGridView1.DataSource = list;
        }

        private void QHFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //取走绑定数据
            //databindview1();
            ////退回绑定数据
            //databindview2();
            dataGridView1.DataSource = new List<JCInfoModel>();
            dataGridView2.DataSource = new List<JCInfoModel>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool mh = checkBox1.Checked;
            List<JCInfoModel> listk=new List<JCInfoModel>();
                List<JCInfoModel> listbk=new List<JCInfoModel>();
                int i = 1;
                int j = 1;
            string type = comboBox1.Text.Trim();
            if (type == "")
            {
                MessageBox.Show("数据为空，请输入数据之后在进行搜索！");
                return;
            }
            string neirong = textBox1.Text.Trim();
            //string begindate = TimeGuiGe.TimePicterBegin(dateTimePicker1.Text);
            //string enddate = TimeGuiGe.TimePicterEng(dateTimePicker2.Text);
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = bll.selectQZ(type, neirong.Trim(), mh);
            if (list.Count <= 0)
            {
                MessageBox.Show("无数据！");
                return;
            }
            foreach (JCInfoModel model in list)
            {
                if (model.jcAddress.Trim() == "店铺已收" || model.jcAddress.Trim() == "店铺完工" || model.jcAddress.Trim() == "退回待处理")
                {
                    model.jcNo = i++;
                    listk.Add(model);
                }
                else
                {
                    model.jcNo = j++;
                    listbk.Add(model);
                }
            }
            dataGridView1.DataSource = listk;
            dataGridView2.DataSource = listbk;
        }

        private void 取走ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[0].Cells["jcID"].Value);
            qzjcFrom qzjc = qzjcFrom.CreateForm(id, databindview1, hsuaxin);
            qzjc.Show();
            qzjc.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> list=new List<int>();
            foreach (DataGridViewRow iteam in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                }
            }
            if (list.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            //int id = Convert.ToInt32(dataGridView1.Rows[0].Cells["jcID"].Value);
            qzjcFrom qzjc = qzjcFrom.CreateForm(list[0], databindview1, hsuaxin);
            qzjc.Show();
            qzjc.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            string dannumber="";
            foreach (DataGridViewRow iteam in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                    dannumber = iteam.Cells["jcDanNumber"].Value.ToString();
                }
            }
            if (list.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            QueRenEnd quend = QueRenEnd.CreateForm(ZhiXing, list[0], dannumber, hsuaxin);
            quend.Show();
            quend.Focus();
        }
        public void ZhiXing(string name,string tel,int id,string dannumber)
        {
            WPEnd model = new WPEnd();
            model.Name = name;
            model.TelPhon = tel;
            model.JCID = id;
            model.DanNumber = dannumber;
            model.DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");            
            bool result = qzbll.AddIteam(model);
            if (result)
            {
                qzjcFrom qzjc = qzjcFrom.CreateForm(id, databindview1, hsuaxin);
                qzjc.Show();
                qzjc.Focus();
            }
        }
        public void hsuaxin()
        {
            button2_Click(button2,new EventArgs());
        }

        //private void QHFrom_Click(object sender, EventArgs e)
        //{
        //    if (pictureBox1.Visible == true)
        //    {
        //        pictureBox1.Visible = false;
        //    }
        //}

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            if (index >= 0)
            {
                string path = dataGridView1.Rows[index].Cells["jcImgUrl"].Value.ToString();
                PictureShow from = PictureShow.Create(path);
                from.Focus();
                from.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridView2.SelectedRows[0].Index;
            if (index >= 0)
            {
                string path = dataGridView2.Rows[index].Cells["jcImgUrl1"].Value.ToString();
                PictureShow from = PictureShow.Create(path);
                from.Focus();
                from.Show();
            }
        }
    }
}
