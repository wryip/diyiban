namespace yixiupige
{
    partial class spform
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("全部");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.spNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品补货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 536);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品分类";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(7, 21);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "spAll";
            treeNode1.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(117, 509);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(150, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1186, 536);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "商品信息";
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
            this.spNo,
            this.spNumber,
            this.spName,
            this.spClass,
            this.spMoney,
            this.spCount,
            this.spLength,
            this.spMark});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(7, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(1173, 509);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // spNo
            // 
            this.spNo.DataPropertyName = "Gid";
            this.spNo.HeaderText = "编号";
            this.spNo.Name = "spNo";
            this.spNo.ReadOnly = true;
            // 
            // spNumber
            // 
            this.spNumber.DataPropertyName = "Gno";
            this.spNumber.HeaderText = "货号";
            this.spNumber.Name = "spNumber";
            this.spNumber.ReadOnly = true;
            // 
            // spName
            // 
            this.spName.DataPropertyName = "Gname";
            this.spName.HeaderText = "商品名称";
            this.spName.Name = "spName";
            this.spName.ReadOnly = true;
            // 
            // spClass
            // 
            this.spClass.DataPropertyName = "Gtype";
            this.spClass.HeaderText = "类别";
            this.spClass.Name = "spClass";
            this.spClass.ReadOnly = true;
            // 
            // spMoney
            // 
            this.spMoney.DataPropertyName = "Gprice";
            this.spMoney.HeaderText = "售价";
            this.spMoney.Name = "spMoney";
            this.spMoney.ReadOnly = true;
            // 
            // spCount
            // 
            this.spCount.DataPropertyName = "Gstock";
            this.spCount.HeaderText = "库存";
            this.spCount.Name = "spCount";
            this.spCount.ReadOnly = true;
            // 
            // spLength
            // 
            this.spLength.DataPropertyName = "Gsum";
            this.spLength.HeaderText = "总数";
            this.spLength.Name = "spLength";
            this.spLength.ReadOnly = true;
            // 
            // spMark
            // 
            this.spMark.DataPropertyName = "Gremark";
            this.spMark.HeaderText = "备注";
            this.spMark.Name = "spMark";
            this.spMark.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看商品ToolStripMenuItem,
            this.增加商品ToolStripMenuItem,
            this.修改商品ToolStripMenuItem,
            this.商品补货ToolStripMenuItem,
            this.删除商品ToolStripMenuItem,
            this.打印预览ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 136);
            // 
            // 查看商品ToolStripMenuItem
            // 
            this.查看商品ToolStripMenuItem.Name = "查看商品ToolStripMenuItem";
            this.查看商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看商品ToolStripMenuItem.Text = "查看商品";
            this.查看商品ToolStripMenuItem.Click += new System.EventHandler(this.查看商品ToolStripMenuItem_Click);
            // 
            // 增加商品ToolStripMenuItem
            // 
            this.增加商品ToolStripMenuItem.Name = "增加商品ToolStripMenuItem";
            this.增加商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加商品ToolStripMenuItem.Text = "增加商品";
            this.增加商品ToolStripMenuItem.Click += new System.EventHandler(this.增加商品ToolStripMenuItem_Click_1);
            // 
            // 修改商品ToolStripMenuItem
            // 
            this.修改商品ToolStripMenuItem.Name = "修改商品ToolStripMenuItem";
            this.修改商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改商品ToolStripMenuItem.Text = "修改商品";
            this.修改商品ToolStripMenuItem.Click += new System.EventHandler(this.修改商品ToolStripMenuItem_Click);
            // 
            // 商品补货ToolStripMenuItem
            // 
            this.商品补货ToolStripMenuItem.Name = "商品补货ToolStripMenuItem";
            this.商品补货ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.商品补货ToolStripMenuItem.Text = "商品补货";
            this.商品补货ToolStripMenuItem.Click += new System.EventHandler(this.商品补货ToolStripMenuItem_Click);
            // 
            // 删除商品ToolStripMenuItem
            // 
            this.删除商品ToolStripMenuItem.Name = "删除商品ToolStripMenuItem";
            this.删除商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除商品ToolStripMenuItem.Text = "删除商品";
            this.删除商品ToolStripMenuItem.Click += new System.EventHandler(this.删除商品ToolStripMenuItem_Click);
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打印预览ToolStripMenuItem.Text = "打印预览";
            // 
            // spform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "spform";
            this.Text = "商品管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.spform_FormClosing);
            this.Load += new System.EventHandler(this.spform_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn spNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn spNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn spName;
        private System.Windows.Forms.DataGridViewTextBoxColumn spClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn spMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn spCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn spLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn spMark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品补货ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览ToolStripMenuItem;
    }
}