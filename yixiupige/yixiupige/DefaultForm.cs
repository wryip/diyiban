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
    public partial class DefaultForm : Form
    {
        public delegate void fromclose();
        public static  fromclose _fromclose;
        private DefaultForm()
        {
            InitializeComponent();
        }
        private static DefaultForm _danli=null;
        public static DefaultForm CreateForm(fromclose ss)
        {
            _fromclose = ss;
            if(_danli==null)
            {
                _danli=new DefaultForm();
            }
            return _danli;
        }
        private void DefaultForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DateTime date = DateTime.Now;
            label1.Text = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            label2.Text = date.Hour.ToString() + "-" + date.Minute.ToString() + "-" + date.Second.ToString();
            

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label2.Text = date.Hour.ToString() + "-" + date.Minute.ToString() + "-" + date.Second.ToString();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            _fromclose();
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            shglform shouhuo = shglform.CreateForm();
            shouhuo.MdiParent = this;
            shouhuo.Parent = panel3;
            shouhuo.WindowState = FormWindowState.Maximized;
            //shouhuo.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            shouhuo.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            hyglform huiyuan = hyglform.CreateForm();
            huiyuan.MdiParent = this;
            huiyuan.Parent = panel3;
            huiyuan.WindowState = FormWindowState.Maximized;
            huiyuan.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            jcform jicun = jcform.CreateForm();
            jicun.MdiParent = this;
            jicun.Parent = panel3;
            jicun.WindowState = FormWindowState.Maximized;
            jicun.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            jcglform jicunguanli = jcglform.CreateForm();
            jicunguanli.MdiParent = this;
            jicunguanli.Parent = panel3;
            jicunguanli.WindowState = FormWindowState.Maximized;
            jicunguanli.Show();
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            spform shangpinguanli = spform.CreateForm();
            shangpinguanli.MdiParent = this;
            shangpinguanli.Parent = panel3;
            shangpinguanli.WindowState = FormWindowState.Maximized;
            shangpinguanli.Show();
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            dxform duanxinguanli = dxform.CreateForm();
            duanxinguanli.MdiParent = this;
            duanxinguanli.Parent = panel3;
            duanxinguanli.WindowState = FormWindowState.Maximized;
            duanxinguanli.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            tjform tongjibaobiao = tjform.CreateForm();
            tongjibaobiao.MdiParent = this;
            tongjibaobiao.Parent = panel3;
            tongjibaobiao.WindowState = FormWindowState.Maximized;
            tongjibaobiao.Show();
            
        }
     

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            jisuanqi jisuanqi = jisuanqi.CreateForm();
            //jisuanqi.MdiParent = this;
            //jisuanqi.Parent = panel3;
            jisuanqi.StartPosition = FormStartPosition.CenterScreen;
            //jisuanqi.WindowState = FormWindowState.Maximized;
            jisuanqi.Show();
            
        }
        //显示管理员设置窗口
        private void 管理员设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glyszForm glygl = glyszForm.Create();
            glygl.Show();
            glygl.Focus();
        }
        //显示连锁店管理窗口
        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsdglForm lsdgl = lsdglForm.Create();
            lsdgl.Show();
            lsdgl.Focus();
        }

        private void 数据库管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sjkglForm sjkgl = sjkglForm.Create();
            sjkgl.Show();
            sjkgl.Focus();
        }

        private void 基本参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jbcsForm jbcs = jbcsForm.Create();
            jbcs.Show();
            jbcs.Focus();
        }

        private void 分类服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hyflglfwForm hyflgl = hyflglfwForm.Create();
            hyflgl.Show();
            hyflgl.Focus();
        }

        private void 其他ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qtForm qt = qtForm.Create();
            qt.Show();
            qt.Focus();
        }

        private void 寄存收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jcsfForm jcsf = jcsfForm.Create();
            jcsf.Show();
            jcsf.Focus();
        }

        private void 架号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jhglForm jhgl = jhglForm.Create();
            jhgl.Show();
            jhgl.Focus();
        }

        private void 员工管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ygglForm yggl = ygglForm.Create();
            yggl.Show();
            yggl.Focus();
        }

        private void 提成管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcglForm tcgl = tcglForm.Create();
            tcgl.Show();
            tcgl.Focus();
        }

        private void DefaultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
