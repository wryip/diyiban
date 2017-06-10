using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using BLL;
using sample;
using Commond;

namespace yixiupige
{
    public partial class Form1 : Form
    {
        public string sqlconn = ConfigurationManager.ConnectionStrings["sql"].ToString();
        public Form1()
        {
            InitializeComponent();
        }
        DPInfoBLL dpbll = new DPInfoBLL();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            LoginUser User=new LoginUser();
            if (User.SelectUser(textBox2.Text.Trim(), textBox1.Text.Trim(), comboBox1.Text.Trim()))
            {
                //登录信息正确
                //登陆成功后判断该店是不是又过了一天，如果是就将DPNumber再踩修改为一
                dpbll.UpdateDay(DateTime.Now.Day);
                DefaultForm _default2 = DefaultForm.CreateForm(fromclose);
                _default2.Text = FilterClass.DianPu1.UserName;
                //SendInfo from = SendInfo.CreateForm();
                //from.Show();
                //from.Hide();
                _default2.Show();
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("信息错误");
            }
        }
        public void fromclose()
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string name= ConfigurationManager.AppSettings["LoginInfo"].ToString();
            label4.Text = name;
            //sample.sample super = new sample.sample();
            //string res = super.main();
            //if (res != "StatusOk")
            //{
            //    MessageBox.Show("请插入安全狗！");
            //    this.Close();
            //    return;
            //}
            List<string> str = dpbll.selectDPName();
            foreach (var iteam in str)
            {
                comboBox1.Items.Add(iteam);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            string LoginInfo = dpbll.selectLoginInfo();
            if (LoginInfo != "")
            {
                comboBox1.Text = LoginInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
                textBox2.Text = LoginInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
