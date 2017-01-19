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
    public partial class hyflglfwForm : Form
    {
        public hyflglfwForm()
        {
            InitializeComponent();
        }
        private static hyflglfwForm hyfl;
        public static hyflglfwForm Create()
        {
            if (hyfl==null)
            {
                hyfl = new hyflglfwForm();
            }
            return hyfl;
        }
        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyflglfwForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hyfl = null;
        }

        private void zjhylbbutton_Click(object sender, EventArgs e)
        {
            zjhyflForm zjhyfl = zjhyflForm.Create(gridbind);
            zjhyfl.Show();
            zjhyfl.Focus();
        }

        private void zjfwbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void xgfwbutton_Click(object sender, EventArgs e)
        {

        }

        private void hylbscbutton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count != 1)
            {
                MessageBox.Show("请选择一条数据");
                return;
            }
            string name = rows[0].Cells[0].Value.ToString();
            DialogResult result= MessageBox.Show("确定删除？","提示",MessageBoxButtons.OKCancel);
            if (result.ToString() == "OK")
            {
                memberTypeCURD memberbll = new memberTypeCURD();
                bool res=memberbll.deleteinfo(name);
                if (res)
                {
                    gridbind();
                }               
            }
            
        }

        private void hylbxgbutton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count != 1)
            {
                MessageBox.Show("请选择一条数据");
                return;
            }
            string name = rows[0].Cells[0].Value.ToString();
            memberTypeCURD memberbll = new memberTypeCURD();
            memberType edit = memberbll.EditMember(name);
            hylxedit zjhyfl = hylxedit.Create(edit,gridbind);
            zjhyfl.Show();
            zjhyfl.Focus();
        }

        private void hyflglfwForm_Load(object sender, EventArgs e)
        {           
            // TODO:  这行代码将数据加载到表“kinyaoo123456DataSet.memberType”中。您可以根据需要移动或删除它。
            this.memberTypeTableAdapter.Fill(this.kinyaoo123456DataSet.memberType);

        }
        public void gridbind()
        {
            this.memberTypeTableAdapter.Fill(this.kinyaoo123456DataSet.memberType);
        }

    }
}
