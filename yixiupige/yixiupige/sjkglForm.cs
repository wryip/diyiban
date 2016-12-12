using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace yixiupige
{
    public partial class sjkglForm : Form
    {
       
        public sjkglForm()
        {
            InitializeComponent();
        }
        private static sjkglForm sjkgl;
        public static sjkglForm Create()
        {
            if (sjkgl==null)
            {
                sjkgl = new sjkglForm();
            }
            return sjkgl;
        }
        private void sjkglForm_Load(object sender, EventArgs e)
        {
            ljlable.Text = @"C/data";
        }
        //选择备份路径
        private void button2_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            
            fbd.ShowDialog();
            bfljlabel.Text = fbd.SelectedPath;
            
        }

        private void sjkglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sjkgl = null;
        }
    }
}
