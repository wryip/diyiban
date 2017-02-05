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
    public partial class fuwuEdit : Form
    {
        public fuwuEdit()
        {
            InitializeComponent();
        }
        public static string name;
        fuwuBLL fuwubll = new fuwuBLL();
        public delegate void databind();
        public static databind bind1;
        private static fuwuEdit hyfl;
        memberTypeCURD bll = new memberTypeCURD();
        public static fuwuEdit Create(databind bind,string mame1)
        {
            name = mame1;
            bind1 = bind;
            if (hyfl == null)
            {
                hyfl = new fuwuEdit();
            }
            return hyfl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fuwuModel model = new fuwuModel();
            TextBox tb;
            Label lb;
            string str = "";
            int count = tableLayoutPanel1.RowStyles.Count;
            for (int i = 0; i < count - 1; i++)
            {
                if (i == 0)
                {
                    tb = tableLayoutPanel1.GetControlFromPosition(1, i) as TextBox;
                    model.Name = tb.Text.Trim();
                    continue;
                }
                lb = tableLayoutPanel1.GetControlFromPosition(0, i) as Label;
                tb = tableLayoutPanel1.GetControlFromPosition(1, i) as TextBox;
                if (tb.Text == "")
                {
                    MessageBox.Show("信息不能为空！");
                    model.Name = "";
                    str = "";
                    return;
                }
                str += lb.Text.Trim() + "," + tb.Text.Trim() + ";";
            }
            model.neirong = str;
            bool result = fuwubll.EditModel(model);
            if (result)
            {
                MessageBox.Show("修改成功！");
                bind1();
                this.Close();
                return;
            }
            MessageBox.Show("修改失败！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fuwuEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            hyfl = null;
        }

        private void fuwuEdit_Load(object sender, EventArgs e)
        {
            fuwuModel model = new fuwuModel();
            model = fuwubll.selectIteam(name);
            if (model == null)
            {
                MessageBox.Show("请选择有效行！");
                return;
            }
            List<string> list = new List<string>();
            list = bll.selectNodes();
            tableLayoutPanel1.Height = (list.Count + 1) * 40;
            RowStyle row;
            Label lab1;
            TextBox teb1;
            //row = new RowStyle(SizeType.Absolute,40);
            lab1 = new Label();
            lab1.Text = "服务类别名称";
            teb1 = new TextBox();
            teb1.Text = model.Name;
            teb1.ReadOnly = true;
            tableLayoutPanel1.Controls.Add(lab1, 0, 0);
            tableLayoutPanel1.Controls.Add(teb1, 1, 0);
            foreach (var i in list)
            {
                lab1 = new Label();
                lab1.Text = i;
                teb1 = new TextBox();
                row = new RowStyle(SizeType.Absolute, 40);
                string[] str = model.neirong.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var iteam in str)
                {
                    string[] ss = iteam.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (i.Trim() == ss[0].Trim())
                    {
                        teb1.Text = ss[1];
                    }
                }
                tableLayoutPanel1.Controls.Add(lab1, 0, tableLayoutPanel1.RowStyles.Count - 1);
                tableLayoutPanel1.Controls.Add(teb1, 1, tableLayoutPanel1.RowStyles.Count - 1);
                tableLayoutPanel1.RowStyles.Add(row);
            }
        }
    }
}
