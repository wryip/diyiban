﻿namespace yixiupige
{
    partial class jcglform
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.glNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcPression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcDanNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glQianKuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcPaiNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suoshudp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcImgUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查找寄存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改寄存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加寄存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除寄存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消取走ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1365, 541);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(228, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1124, 519);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "寄存信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.glNo,
            this.jcQuestion,
            this.jcPression,
            this.jcDanNumber,
            this.Tel,
            this.glCardNo,
            this.glName,
            this.glQianKuan,
            this.glClass,
            this.glType,
            this.jcPaiNumber,
            this.glColor,
            this.glDemo,
            this.glDate,
            this.suoshudp,
            this.glMark,
            this.jcRemark,
            this.glQuestion,
            this.glTel,
            this.glDanNo,
            this.jcImgUrl});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1101, 492);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dataGridView1_RowContextMenuStripNeeded);
            // 
            // glNo
            // 
            this.glNo.DataPropertyName = "jcNo";
            this.glNo.HeaderText = "编号";
            this.glNo.Name = "glNo";
            this.glNo.ReadOnly = true;
            this.glNo.Width = 111;
            // 
            // jcQuestion
            // 
            this.jcQuestion.DataPropertyName = "jcQuestion";
            this.jcQuestion.HeaderText = "常见问题";
            this.jcQuestion.Name = "jcQuestion";
            this.jcQuestion.ReadOnly = true;
            // 
            // jcPression
            // 
            this.jcPression.DataPropertyName = "jcPression";
            this.jcPression.HeaderText = "业务员";
            this.jcPression.Name = "jcPression";
            this.jcPression.ReadOnly = true;
            // 
            // jcDanNumber
            // 
            this.jcDanNumber.DataPropertyName = "jcDanNumber";
            this.jcDanNumber.HeaderText = "单号";
            this.jcDanNumber.Name = "jcDanNumber";
            this.jcDanNumber.ReadOnly = true;
            // 
            // Tel
            // 
            this.Tel.DataPropertyName = "Tel";
            this.Tel.HeaderText = "电话";
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            // 
            // glCardNo
            // 
            this.glCardNo.DataPropertyName = "jcCardNumber";
            this.glCardNo.HeaderText = "卡号";
            this.glCardNo.Name = "glCardNo";
            this.glCardNo.ReadOnly = true;
            this.glCardNo.Width = 110;
            // 
            // glName
            // 
            this.glName.DataPropertyName = "jcName";
            this.glName.HeaderText = "姓名";
            this.glName.Name = "glName";
            this.glName.ReadOnly = true;
            this.glName.Width = 111;
            // 
            // glQianKuan
            // 
            this.glQianKuan.DataPropertyName = "jcQMoney";
            this.glQianKuan.HeaderText = "欠款";
            this.glQianKuan.Name = "glQianKuan";
            this.glQianKuan.ReadOnly = true;
            this.glQianKuan.Width = 111;
            // 
            // glClass
            // 
            this.glClass.DataPropertyName = "jcType";
            this.glClass.HeaderText = "类别";
            this.glClass.Name = "glClass";
            this.glClass.ReadOnly = true;
            this.glClass.Width = 110;
            // 
            // glType
            // 
            this.glType.DataPropertyName = "jcPinPai";
            this.glType.HeaderText = "品牌";
            this.glType.Name = "glType";
            this.glType.ReadOnly = true;
            this.glType.Width = 111;
            // 
            // jcPaiNumber
            // 
            this.jcPaiNumber.DataPropertyName = "jcPaiNumber";
            this.jcPaiNumber.HeaderText = "牌号";
            this.jcPaiNumber.Name = "jcPaiNumber";
            this.jcPaiNumber.ReadOnly = true;
            this.jcPaiNumber.Visible = false;
            // 
            // glColor
            // 
            this.glColor.DataPropertyName = "jcColor";
            this.glColor.HeaderText = "颜色";
            this.glColor.Name = "glColor";
            this.glColor.ReadOnly = true;
            this.glColor.Width = 111;
            // 
            // glDemo
            // 
            this.glDemo.DataPropertyName = "jcStaff";
            this.glDemo.HeaderText = "服务项目";
            this.glDemo.Name = "glDemo";
            this.glDemo.ReadOnly = true;
            this.glDemo.Width = 111;
            // 
            // glDate
            // 
            this.glDate.DataPropertyName = "jcBeginDate";
            this.glDate.HeaderText = "寄存时间";
            this.glDate.Name = "glDate";
            this.glDate.ReadOnly = true;
            this.glDate.Width = 110;
            // 
            // suoshudp
            // 
            this.suoshudp.DataPropertyName = "lsdp";
            this.suoshudp.HeaderText = "所属店铺";
            this.suoshudp.Name = "suoshudp";
            this.suoshudp.ReadOnly = true;
            // 
            // glMark
            // 
            this.glMark.DataPropertyName = "jcEndDate";
            this.glMark.HeaderText = "取走时间";
            this.glMark.Name = "glMark";
            this.glMark.ReadOnly = true;
            this.glMark.Width = 111;
            // 
            // jcRemark
            // 
            this.jcRemark.DataPropertyName = "jcRemark";
            this.jcRemark.HeaderText = "备注";
            this.jcRemark.Name = "jcRemark";
            this.jcRemark.ReadOnly = true;
            // 
            // glQuestion
            // 
            this.glQuestion.DataPropertyName = "jcZT";
            this.glQuestion.HeaderText = "状态";
            this.glQuestion.Name = "glQuestion";
            this.glQuestion.ReadOnly = true;
            this.glQuestion.Width = 111;
            // 
            // glTel
            // 
            this.glTel.DataPropertyName = "jcAddress";
            this.glTel.HeaderText = "物品位置";
            this.glTel.Name = "glTel";
            this.glTel.ReadOnly = true;
            this.glTel.Width = 110;
            // 
            // glDanNo
            // 
            this.glDanNo.DataPropertyName = "jcID";
            this.glDanNo.HeaderText = "物品ID";
            this.glDanNo.Name = "glDanNo";
            this.glDanNo.ReadOnly = true;
            this.glDanNo.Width = 111;
            // 
            // jcImgUrl
            // 
            this.jcImgUrl.DataPropertyName = "jcImgUrl";
            this.jcImgUrl.HeaderText = "图片路径";
            this.jcImgUrl.Name = "jcImgUrl";
            this.jcImgUrl.ReadOnly = true;
            this.jcImgUrl.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找寄存ToolStripMenuItem,
            this.修改寄存ToolStripMenuItem,
            this.增加寄存ToolStripMenuItem,
            this.删除寄存ToolStripMenuItem,
            this.取消取走ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
            // 
            // 查找寄存ToolStripMenuItem
            // 
            this.查找寄存ToolStripMenuItem.Name = "查找寄存ToolStripMenuItem";
            this.查找寄存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查找寄存ToolStripMenuItem.Text = "查找寄存";
            this.查找寄存ToolStripMenuItem.Click += new System.EventHandler(this.查找寄存ToolStripMenuItem_Click);
            // 
            // 修改寄存ToolStripMenuItem
            // 
            this.修改寄存ToolStripMenuItem.Name = "修改寄存ToolStripMenuItem";
            this.修改寄存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改寄存ToolStripMenuItem.Text = "修改寄存";
            this.修改寄存ToolStripMenuItem.Click += new System.EventHandler(this.修改寄存ToolStripMenuItem_Click);
            // 
            // 增加寄存ToolStripMenuItem
            // 
            this.增加寄存ToolStripMenuItem.Name = "增加寄存ToolStripMenuItem";
            this.增加寄存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.增加寄存ToolStripMenuItem.Text = "增加寄存";
            this.增加寄存ToolStripMenuItem.Click += new System.EventHandler(this.增加寄存ToolStripMenuItem_Click);
            // 
            // 删除寄存ToolStripMenuItem
            // 
            this.删除寄存ToolStripMenuItem.Name = "删除寄存ToolStripMenuItem";
            this.删除寄存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除寄存ToolStripMenuItem.Text = "删除寄存";
            this.删除寄存ToolStripMenuItem.Click += new System.EventHandler(this.删除寄存ToolStripMenuItem_Click);
            // 
            // 取消取走ToolStripMenuItem
            // 
            this.取消取走ToolStripMenuItem.Name = "取消取走ToolStripMenuItem";
            this.取消取走ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消取走ToolStripMenuItem.Text = "取消取走";
            this.取消取走ToolStripMenuItem.Click += new System.EventHandler(this.取消取走ToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Location = new System.Drawing.Point(22, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 325);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "寄存分类";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(8, 19);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "treeAll";
            treeNode1.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(187, 300);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(22, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 188);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片预览";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // jcglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 561);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "jcglform";
            this.Text = "寄存管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.jcglform_FormClosing);
            this.Load += new System.EventHandler(this.jcglform_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查找寄存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改寄存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加寄存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除寄存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消取走ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn glNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcPression;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcDanNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn glCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glName;
        private System.Windows.Forms.DataGridViewTextBoxColumn glQianKuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn glClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn glType;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcPaiNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn glColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn suoshudp;
        private System.Windows.Forms.DataGridViewTextBoxColumn glMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn glQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn glTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcImgUrl;

    }
}