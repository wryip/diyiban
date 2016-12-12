namespace yixiupige
{
    partial class hyglform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("金卡");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("银卡");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("会员卡");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("全部", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hySex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hyDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查找会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员充值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.积分兑换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 536);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会员分类";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(7, 21);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "jinka";
            treeNode5.Text = "金卡";
            treeNode6.Name = "yinka";
            treeNode6.Text = "银卡";
            treeNode7.Name = "huiyuanka";
            treeNode7.Text = "会员卡";
            treeNode8.Name = "quanbu";
            treeNode8.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(85, 509);
            this.treeView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(148, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1188, 536);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会员信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hyNo,
            this.hyCardNo,
            this.hyName,
            this.hySex,
            this.hyTel,
            this.hyMoney,
            this.hyType,
            this.hyCardType,
            this.hyDate,
            this.hyActive,
            this.hyNumber,
            this.hyDateEnd});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(7, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1175, 509);
            this.dataGridView1.TabIndex = 0;
            // 
            // hyNo
            // 
            this.hyNo.HeaderText = "编号";
            this.hyNo.Name = "hyNo";
            this.hyNo.ReadOnly = true;
            // 
            // hyCardNo
            // 
            this.hyCardNo.HeaderText = "卡号";
            this.hyCardNo.Name = "hyCardNo";
            this.hyCardNo.ReadOnly = true;
            // 
            // hyName
            // 
            this.hyName.HeaderText = "姓名";
            this.hyName.Name = "hyName";
            this.hyName.ReadOnly = true;
            // 
            // hySex
            // 
            this.hySex.HeaderText = "性别";
            this.hySex.Name = "hySex";
            this.hySex.ReadOnly = true;
            // 
            // hyTel
            // 
            this.hyTel.HeaderText = "电话";
            this.hyTel.Name = "hyTel";
            this.hyTel.ReadOnly = true;
            // 
            // hyMoney
            // 
            this.hyMoney.HeaderText = "余额";
            this.hyMoney.Name = "hyMoney";
            this.hyMoney.ReadOnly = true;
            // 
            // hyType
            // 
            this.hyType.HeaderText = "会员类别";
            this.hyType.Name = "hyType";
            this.hyType.ReadOnly = true;
            // 
            // hyCardType
            // 
            this.hyCardType.HeaderText = "卡类型";
            this.hyCardType.Name = "hyCardType";
            this.hyCardType.ReadOnly = true;
            // 
            // hyDate
            // 
            this.hyDate.HeaderText = "办卡日期";
            this.hyDate.Name = "hyDate";
            this.hyDate.ReadOnly = true;
            // 
            // hyActive
            // 
            this.hyActive.HeaderText = "会员状态";
            this.hyActive.Name = "hyActive";
            this.hyActive.ReadOnly = true;
            // 
            // hyNumber
            // 
            this.hyNumber.HeaderText = "积分";
            this.hyNumber.Name = "hyNumber";
            this.hyNumber.ReadOnly = true;
            // 
            // hyDateEnd
            // 
            this.hyDateEnd.HeaderText = "期限";
            this.hyDateEnd.Name = "hyDateEnd";
            this.hyDateEnd.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找会员ToolStripMenuItem,
            this.增加会员ToolStripMenuItem,
            this.会员修改ToolStripMenuItem,
            this.会员充值ToolStripMenuItem,
            this.积分兑换ToolStripMenuItem,
            this.删除会员ToolStripMenuItem,
            this.导出数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 180);
            // 
            // 查找会员ToolStripMenuItem
            // 
            this.查找会员ToolStripMenuItem.Name = "查找会员ToolStripMenuItem";
            this.查找会员ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查找会员ToolStripMenuItem.Text = "查找会员";
            this.查找会员ToolStripMenuItem.Click += new System.EventHandler(this.查找会员ToolStripMenuItem_Click);
            // 
            // 增加会员ToolStripMenuItem
            // 
            this.增加会员ToolStripMenuItem.Name = "增加会员ToolStripMenuItem";
            this.增加会员ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.增加会员ToolStripMenuItem.Text = "增加会员";
            this.增加会员ToolStripMenuItem.Click += new System.EventHandler(this.增加会员ToolStripMenuItem_Click);
            // 
            // 会员修改ToolStripMenuItem
            // 
            this.会员修改ToolStripMenuItem.Name = "会员修改ToolStripMenuItem";
            this.会员修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.会员修改ToolStripMenuItem.Text = "会员修改";
            // 
            // 会员充值ToolStripMenuItem
            // 
            this.会员充值ToolStripMenuItem.Name = "会员充值ToolStripMenuItem";
            this.会员充值ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.会员充值ToolStripMenuItem.Text = "会员充值";
            // 
            // 积分兑换ToolStripMenuItem
            // 
            this.积分兑换ToolStripMenuItem.Name = "积分兑换ToolStripMenuItem";
            this.积分兑换ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.积分兑换ToolStripMenuItem.Text = "积分兑换";
            // 
            // 删除会员ToolStripMenuItem
            // 
            this.删除会员ToolStripMenuItem.Name = "删除会员ToolStripMenuItem";
            this.删除会员ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除会员ToolStripMenuItem.Text = "删除会员";
            // 
            // 导出数据ToolStripMenuItem
            // 
            this.导出数据ToolStripMenuItem.Name = "导出数据ToolStripMenuItem";
            this.导出数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出数据ToolStripMenuItem.Text = "导出数据";
            // 
            // hyglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "hyglform";
            this.Text = "会员管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.hyglform_FormClosing);
            this.Load += new System.EventHandler(this.hyglform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hySex;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn hyDateEnd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查找会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员充值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 积分兑换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出数据ToolStripMenuItem;
    }
}