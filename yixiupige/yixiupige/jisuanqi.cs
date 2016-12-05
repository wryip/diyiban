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
    public partial class jisuanqi : Form
    {
        private string num1;
        private string num2;
        private string num3;
        private char Mark;
        private bool More;          //判断是否进行连续运算                    
        private bool change;        //判断第一次输入的数字和后来输入的数字
        private bool clear;
        public jisuanqi()
        {
            InitializeComponent();
        }
        private static jisuanqi _danli = null;
        public static jisuanqi CreateForm()
        {
            if (_danli == null)
            {
                _danli = new jisuanqi();
            }
            return _danli;
        }
        public void Init()
        {
            num1 = "";
            num2 = "";
            num3 = "";
            Mark = '0';
            More = true;
            change = true;
            clear = true;
            this.textBox1.Text = "0";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jisuanqi_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (change)
            {
                if (clear)
                {
                    num1 = "";
                    clear = false;
                }
                if (num1 == "0")
                {
                    num1 = btn.Text;
                }
                else
                {
                    if (num1 != "." || num1.IndexOf('.') == -1)
                    {
                        num1 += btn.Text;
                    }
                }
                textBox1.Text = num1;
            }
            else
            {
                num2 += btn.Text;
                textBox1.Text = num2;
            }
        }
        public string getnum(string num1, string num2, char Mark)
        {
            double n1;
            double n2;
            try
            {
                n1 = Convert.ToDouble(num1);
                n2 = Convert.ToDouble(num2);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            switch (Mark)
            {
                case '+': n1 += n2; break;
                case '-': n1 -= n2; break;
                case '*': n1 *= n2; break;
                case '/': n1 /= n2; break;
                //case '%': n1 = n1 / 100; break;
                //case 'x': n1 = 1 / n1; break;
                //case 's': n1 = Math.Sqrt(n1); break;
                //case '_': n1 = -n1; break;
                default: n1 = 0; break;
            }
            return n1.ToString();

        }
        /// <summary>
        /// 等于运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn47_Click(object sender, EventArgs e)
        {
            if (More)
            {
                num1 = execute(num1, num3, Mark);
            }
            else
            {
                num1 = execute(num1, num2, Mark);
                num3 = num2;
                num2 = "";
                More = true;
            }
            this.textBox1.Text = num1;
            change = true;
            clear = true;
        }
        /// <summary>
        /// 特殊情况
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="mar"></param>
        /// <returns></returns>
        public string execute(string num1, string num2, char mar)
        {
            if (num1 == "" && num2 == "" && Mark == '0')
            {
                return "0";
            }
            else if (num1 == "" && num2 == "" && Mark != '0')
            {
                return "0";
            }
            else if (num1 != "" && num2 == "" && Mark == '0')
            {
                return num1;
            }
            else if (num1 == "" && num2 != "" && Mark == '0')
            {
                return num2;
            }
            else if (num1 == "" && num2 != "" && Mark != '0')
            {
                return getnum(num2, num3, Mark);
            }
            else if (num1 != "" && num2 == "" && Mark != '0')
            {
                return getnum(num1, num1, Mark);
            }
            else
            {
                return getnum(num1, num2, Mark);
            }
        }
        public void Marks(char Mark)
        {
            //this.textBox1.Text = "";//隐藏第一个输入的数字num1
            if (More)
            {
                this.Mark = Mark;
                More = false;
            }
            else
            {
                num1 = execute(num1, num2, Mark);
                this.textBox1.Text = num1;
            }
            num2 = "";
            change = false;
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            Marks('*');
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            Marks('/');
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            Marks('-');
        }

        private void btn46_Click(object sender, EventArgs e)
        {
            Marks('+');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (change)
            {
                if (num1.Length > 0)
                {
                    num1 = num1.Substring(0, num1.Length - 1);
                }
                else
                {
                    num1 = "0";
                }
                textBox1.Text = num1;
            }
            else
            {
                if (num2.Length > 0)
                {
                    num2 = num2.Substring(0, num2.Length - 1);
                }
                else
                {
                    num2 = "0";
                }
                textBox1.Text = num2;
            }
        }

        private void jisuanqi_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
