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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("全部");
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查找会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员充值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bianhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lsdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找会员ToolStripMenuItem,
            this.增加会员ToolStripMenuItem,
            this.会员修改ToolStripMenuItem,
            this.会员充值ToolStripMenuItem,
            this.会员信息ToolStripMenuItem,
            this.删除会员ToolStripMenuItem,
            this.打印预览ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 186);
            // 
            // 查找会员ToolStripMenuItem
            // 
            this.查找会员ToolStripMenuItem.Name = "查找会员ToolStripMenuItem";
            this.查找会员ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.查找会员ToolStripMenuItem.Text = "查找会员";
            this.查找会员ToolStripMenuItem.Click += new System.EventHandler(this.查找会员ToolStripMenuItem_Click);
            // 
            // 增加会员ToolStripMenuItem
            // 
            this.增加会员ToolStripMenuItem.Name = "增加会员ToolStripMenuItem";
            this.增加会员ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.增加会员ToolStripMenuItem.Text = "增加会员";
            this.增加会员ToolStripMenuItem.Click += new System.EventHandler(this.增加会员ToolStripMenuItem_Click);
            // 
            // 会员修改ToolStripMenuItem
            // 
            this.会员修改ToolStripMenuItem.Name = "会员修改ToolStripMenuItem";
            this.会员修改ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.会员修改ToolStripMenuItem.Text = "会员修改";
            this.会员修改ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 会员充值ToolStripMenuItem
            // 
            this.会员充值ToolStripMenuItem.Name = "会员充值ToolStripMenuItem";
            this.会员充值ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.会员充值ToolStripMenuItem.Text = "会员充值";
            this.会员充值ToolStripMenuItem.Click += new System.EventHandler(this.会员充值ToolStripMenuItem_Click);
            // 
            // 会员信息ToolStripMenuItem
            // 
            this.会员信息ToolStripMenuItem.Name = "会员信息ToolStripMenuItem";
            this.会员信息ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.会员信息ToolStripMenuItem.Text = "会员信息";
            this.会员信息ToolStripMenuItem.Click += new System.EventHandler(this.会员信息ToolStripMenuItem_Click);
            // 
            // 删除会员ToolStripMenuItem
            // 
            this.删除会员ToolStripMenuItem.Name = "删除会员ToolStripMenuItem";
            this.删除会员ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.删除会员ToolStripMenuItem.Text = "删除会员";
            this.删除会员ToolStripMenuItem.Click += new System.EventHandler(this.删除会员ToolStripMenuItem_Click);
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.打印预览ToolStripMenuItem.Text = "会员退卡";
            this.打印预览ToolStripMenuItem.Click += new System.EventHandler(this.打印预览ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1820, 676);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(191, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1625, 670);
            this.groupBox2.TabIndex = 3;
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
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID1,
            this.bianhao,
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
            this.hyDateEnd,
            this.lsdm});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(9, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1608, 636);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dataGridView1_RowContextMenuStripNeeded);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(11, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(172, 670);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会员分类";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(8, 26);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            treeNode2.Name = "全部";
            treeNode2.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(155, 635);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // ID1
            // 
            this.ID1.DataPropertyName = "ID";
            this.ID1.HeaderText = "ID";
            this.ID1.Name = "ID1";
            this.ID1.ReadOnly = true;
            this.ID1.Visible = false;
            // 
            // bianhao
            // 
            this.bianhao.DataPropertyName = "idbh";
            this.bianhao.HeaderText = "编号";
            this.bianhao.Name = "bianhao";
            this.bianhao.ReadOnly = true;
            // 
            // hyCardNo
            // 
            this.hyCardNo.DataPropertyName = "membercardNo";
            this.hyCardNo.HeaderText = "卡号";
            this.hyCardNo.Name = "hyCardNo";
            this.hyCardNo.ReadOnly = true;
            // 
            // hyName
            // 
            this.hyName.DataPropertyName = "memberName";
            this.hyName.HeaderText = "姓名";
            this.hyName.Name = "hyName";
            this.hyName.ReadOnly = true;
            // 
            // hySex
            // 
            this.hySex.DataPropertyName = "memberSex";
            this.hySex.HeaderText = "性别";
            this.hySex.Name = "hySex";
            this.hySex.ReadOnly = true;
            // 
            // hyTel
            // 
            this.hyTel.DataPropertyName = "memberTel";
            this.hyTel.HeaderText = "电话";
            this.hyTel.Name = "hyTel";
            this.hyTel.ReadOnly = true;
            // 
            // hyMoney
            // 
            this.hyMoney.DataPropertyName = "toUpMoney";
            this.hyMoney.HeaderText = "余额";
            this.hyMoney.Name = "hyMoney";
            this.hyMoney.ReadOnly = true;
            // 
            // hyType
            // 
            this.hyType.DataPropertyName = "memberType";
            this.hyType.HeaderText = "会员类别";
            this.hyType.Name = "hyType";
            this.hyType.ReadOnly = true;
            // 
            // hyCardType
            // 
            this.hyCardType.DataPropertyName = "cardType";
            this.hyCardType.HeaderText = "卡类型";
            this.hyCardType.Name = "hyCardType";
            this.hyCardType.ReadOnly = true;
            // 
            // hyDate
            // 
            this.hyDate.DataPropertyName = "cardDate";
            this.hyDate.HeaderText = "办卡日期";
            this.hyDate.Name = "hyDate";
            this.hyDate.ReadOnly = true;
            // 
            // hyActive
            // 
            this.hyActive.DataPropertyName = "zhuangtai";
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
            this.hyDateEnd.DataPropertyName = "endDate";
            this.hyDateEnd.HeaderText = "期限";
            this.hyDateEnd.Name = "hyDateEnd";
            this.hyDateEnd.ReadOnly = true;
            this.hyDateEnd.Visible = false;
            // 
            // lsdm
            // 
            this.lsdm.DataPropertyName = "lsdm";
            this.lsdm.HeaderText = "所属店铺";
            this.lsdm.Name = "lsdm";
            this.lsdm.ReadOnly = true;
            // 
            // hyglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1843, 691);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "hyglform";
            this.Text = "会员管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.hyglform_FormClosing);
            this.Load += new System.EventHandler(this.hyglform_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查找会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员充值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bianhao;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn lsdm;
    }
}