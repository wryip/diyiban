﻿namespace yixiupige
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 541);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(142, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "商品信息";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(134, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1171, 516);
            this.panel3.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 11);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1163, 500);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dataGridView1_RowContextMenuStripNeeded);
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
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看商品ToolStripMenuItem,
            this.增加商品ToolStripMenuItem,
            this.修改商品ToolStripMenuItem,
            this.商品补货ToolStripMenuItem,
            this.删除商品ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 114);
            // 
            // 查看商品ToolStripMenuItem
            // 
            this.查看商品ToolStripMenuItem.Name = "查看商品ToolStripMenuItem";
            this.查看商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看商品ToolStripMenuItem.Text = "查询商品";
            this.查看商品ToolStripMenuItem.Click += new System.EventHandler(this.查看商品ToolStripMenuItem_Click_1);
            // 
            // 增加商品ToolStripMenuItem
            // 
            this.增加商品ToolStripMenuItem.Name = "增加商品ToolStripMenuItem";
            this.增加商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加商品ToolStripMenuItem.Text = "增加商品";
            this.增加商品ToolStripMenuItem.Click += new System.EventHandler(this.增加商品ToolStripMenuItem_Click);
            // 
            // 修改商品ToolStripMenuItem
            // 
            this.修改商品ToolStripMenuItem.Name = "修改商品ToolStripMenuItem";
            this.修改商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改商品ToolStripMenuItem.Text = "修改商品";
            this.修改商品ToolStripMenuItem.Click += new System.EventHandler(this.修改商品ToolStripMenuItem_Click_1);
            // 
            // 商品补货ToolStripMenuItem
            // 
            this.商品补货ToolStripMenuItem.Name = "商品补货ToolStripMenuItem";
            this.商品补货ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.商品补货ToolStripMenuItem.Text = "商品补货";
            this.商品补货ToolStripMenuItem.Click += new System.EventHandler(this.商品补货ToolStripMenuItem_Click_1);
            // 
            // 删除商品ToolStripMenuItem
            // 
            this.删除商品ToolStripMenuItem.Name = "删除商品ToolStripMenuItem";
            this.删除商品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除商品ToolStripMenuItem.Text = "删除商品";
            this.删除商品ToolStripMenuItem.Click += new System.EventHandler(this.删除商品ToolStripMenuItem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "商品分类";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Location = new System.Drawing.Point(8, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 473);
            this.panel2.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(8, 10);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "spAll";
            treeNode1.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(110, 458);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(8, 494);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "数据导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // spform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 594);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "spform";
            this.Text = "商品管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.spform_FormClosing);
            this.Load += new System.EventHandler(this.spform_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;

    }
}