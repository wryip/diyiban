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
    public partial class EditQtFuWu : Form
    {
        public EditQtFuWu()
        {
            InitializeComponent();
        }
        public delegate void databind();
        public static qtFuWuModel model1;
        public static databind bind1;
        QtFuWuBLL bll = new QtFuWuBLL();
        private static EditQtFuWu qt;
        public static EditQtFuWu Create(databind bind, qtFuWuModel model)
        {
            model1 = model;
            bind1 = bind;
            if (qt == null)
            {
                qt = new EditQtFuWu();
            }
            return qt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            qtFuWuModel model = new qtFuWuModel();
            model.QtName = textBox1.Text.Trim();
            int money = 0;
            try
            {
                money = Convert.ToInt32(textBox2.Text.Trim());
                if (money > 100 || money < 0)
                {
                    MessageBox.Show("请输入合理的提成！");
                    return;
                }
                model.QtTc = money;
                bool result = bll.EditModel(model);
                if (result)
                {
                    MessageBox.Show("修改成功！");
                    bind1();
                    this.Close();
                    return;
                }
                MessageBox.Show("错误！请稍后再试！");
            }
            catch
            {
                MessageBox.Show("提成请输入数字！");
            }
        }

        private void EditQtFuWu_Load(object sender, EventArgs e)
        {
            textBox1.Text = model1.QtName.Trim();
            textBox1.ReadOnly = true;
            textBox2.Text = model1.QtTc.ToString().Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditQtFuWu_FormClosing(object sender, FormClosingEventArgs e)
        {
            qt = null;
        }
    }
}
