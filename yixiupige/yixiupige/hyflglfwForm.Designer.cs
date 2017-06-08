namespace yixiupige
{
    partial class hyflglfwForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hyflglfwForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.memberNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberCardMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberRebateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberTopUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kinyaoo123456DataSet = new yixiupige.kinyaoo123456DataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.tcbutton = new System.Windows.Forms.Button();
            this.scfwbutton = new System.Windows.Forms.Button();
            this.xgfwbutton = new System.Windows.Forms.Button();
            this.zjfwbutton = new System.Windows.Forms.Button();
            this.hylbscbutton = new System.Windows.Forms.Button();
            this.hylbxgbutton = new System.Windows.Forms.Button();
            this.zjhylbbutton = new System.Windows.Forms.Button();
            this.memberTypeTableAdapter = new yixiupige.kinyaoo123456DataSetTableAdapters.memberTypeTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinyaoo123456DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 302);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会员分类表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.memberNameDataGridViewTextBoxColumn,
            this.memberCardMoneyDataGridViewTextBoxColumn,
            this.memberRebateDataGridViewTextBoxColumn,
            this.memberTopUpDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.memberTypeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(696, 276);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // memberNameDataGridViewTextBoxColumn
            // 
            this.memberNameDataGridViewTextBoxColumn.DataPropertyName = "memberName";
            this.memberNameDataGridViewTextBoxColumn.Frozen = true;
            this.memberNameDataGridViewTextBoxColumn.HeaderText = "卡名称";
            this.memberNameDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.memberNameDataGridViewTextBoxColumn.Name = "memberNameDataGridViewTextBoxColumn";
            this.memberNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.memberNameDataGridViewTextBoxColumn.Width = 50;
            // 
            // memberCardMoneyDataGridViewTextBoxColumn
            // 
            this.memberCardMoneyDataGridViewTextBoxColumn.DataPropertyName = "memberCardMoney";
            this.memberCardMoneyDataGridViewTextBoxColumn.HeaderText = "办卡金额";
            this.memberCardMoneyDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.memberCardMoneyDataGridViewTextBoxColumn.Name = "memberCardMoneyDataGridViewTextBoxColumn";
            this.memberCardMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberCardMoneyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.memberCardMoneyDataGridViewTextBoxColumn.Width = 62;
            // 
            // memberRebateDataGridViewTextBoxColumn
            // 
            this.memberRebateDataGridViewTextBoxColumn.DataPropertyName = "memberRebate";
            this.memberRebateDataGridViewTextBoxColumn.HeaderText = "消费折扣";
            this.memberRebateDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.memberRebateDataGridViewTextBoxColumn.Name = "memberRebateDataGridViewTextBoxColumn";
            this.memberRebateDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberRebateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.memberRebateDataGridViewTextBoxColumn.Width = 62;
            // 
            // memberTopUpDataGridViewTextBoxColumn
            // 
            this.memberTopUpDataGridViewTextBoxColumn.DataPropertyName = "memberTopUp";
            this.memberTopUpDataGridViewTextBoxColumn.HeaderText = "充值金额";
            this.memberTopUpDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.memberTopUpDataGridViewTextBoxColumn.Name = "memberTopUpDataGridViewTextBoxColumn";
            this.memberTopUpDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberTopUpDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.memberTopUpDataGridViewTextBoxColumn.Width = 62;
            // 
            // memberTypeBindingSource
            // 
            this.memberTypeBindingSource.DataMember = "memberType";
            this.memberTypeBindingSource.DataSource = this.kinyaoo123456DataSet;
            // 
            // kinyaoo123456DataSet
            // 
            this.kinyaoo123456DataSet.DataSetName = "kinyaoo123456DataSet";
            this.kinyaoo123456DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 8;
            // 
            // tcbutton
            // 
            this.tcbutton.BackColor = System.Drawing.Color.Transparent;
            this.tcbutton.FlatAppearance.BorderSize = 0;
            this.tcbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcbutton.Image = global::yixiupige.Properties.Resources._4505;
            this.tcbutton.Location = new System.Drawing.Point(650, 17);
            this.tcbutton.Name = "tcbutton";
            this.tcbutton.Size = new System.Drawing.Size(75, 83);
            this.tcbutton.TabIndex = 6;
            this.tcbutton.Text = "\r\n退出";
            this.tcbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tcbutton.UseVisualStyleBackColor = false;
            this.tcbutton.Click += new System.EventHandler(this.tcbutton_Click);
            // 
            // scfwbutton
            // 
            this.scfwbutton.BackColor = System.Drawing.Color.Transparent;
            this.scfwbutton.FlatAppearance.BorderSize = 0;
            this.scfwbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scfwbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scfwbutton.Image = global::yixiupige.Properties.Resources._6962;
            this.scfwbutton.Location = new System.Drawing.Point(553, 17);
            this.scfwbutton.Name = "scfwbutton";
            this.scfwbutton.Size = new System.Drawing.Size(91, 78);
            this.scfwbutton.TabIndex = 5;
            this.scfwbutton.Text = "\r\n删除服务类别";
            this.scfwbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.scfwbutton.UseVisualStyleBackColor = false;
            this.scfwbutton.Click += new System.EventHandler(this.scfwbutton_Click);
            // 
            // xgfwbutton
            // 
            this.xgfwbutton.BackColor = System.Drawing.Color.Transparent;
            this.xgfwbutton.FlatAppearance.BorderSize = 0;
            this.xgfwbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xgfwbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xgfwbutton.Image = global::yixiupige.Properties.Resources._1631;
            this.xgfwbutton.Location = new System.Drawing.Point(447, 17);
            this.xgfwbutton.Name = "xgfwbutton";
            this.xgfwbutton.Size = new System.Drawing.Size(87, 78);
            this.xgfwbutton.TabIndex = 4;
            this.xgfwbutton.Text = "\r\n修改服务类别";
            this.xgfwbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.xgfwbutton.UseVisualStyleBackColor = false;
            this.xgfwbutton.Click += new System.EventHandler(this.xgfwbutton_Click);
            // 
            // zjfwbutton
            // 
            this.zjfwbutton.BackColor = System.Drawing.Color.Transparent;
            this.zjfwbutton.FlatAppearance.BorderSize = 0;
            this.zjfwbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zjfwbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zjfwbutton.Image = global::yixiupige.Properties.Resources._1133944;
            this.zjfwbutton.Location = new System.Drawing.Point(333, 15);
            this.zjfwbutton.Name = "zjfwbutton";
            this.zjfwbutton.Size = new System.Drawing.Size(85, 83);
            this.zjfwbutton.TabIndex = 3;
            this.zjfwbutton.Text = "\r\n增加服务类别";
            this.zjfwbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zjfwbutton.UseVisualStyleBackColor = false;
            this.zjfwbutton.Click += new System.EventHandler(this.zjfwbutton_Click);
            // 
            // hylbscbutton
            // 
            this.hylbscbutton.BackColor = System.Drawing.Color.Transparent;
            this.hylbscbutton.FlatAppearance.BorderSize = 0;
            this.hylbscbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hylbscbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hylbscbutton.Image = global::yixiupige.Properties.Resources._532579;
            this.hylbscbutton.Location = new System.Drawing.Point(221, 12);
            this.hylbscbutton.Name = "hylbscbutton";
            this.hylbscbutton.Size = new System.Drawing.Size(95, 88);
            this.hylbscbutton.TabIndex = 2;
            this.hylbscbutton.Text = "\r\n会员类别删除";
            this.hylbscbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.hylbscbutton.UseVisualStyleBackColor = false;
            this.hylbscbutton.Click += new System.EventHandler(this.hylbscbutton_Click);
            // 
            // hylbxgbutton
            // 
            this.hylbxgbutton.BackColor = System.Drawing.Color.Transparent;
            this.hylbxgbutton.FlatAppearance.BorderSize = 0;
            this.hylbxgbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hylbxgbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hylbxgbutton.Image = global::yixiupige.Properties.Resources._556807;
            this.hylbxgbutton.Location = new System.Drawing.Point(108, 12);
            this.hylbxgbutton.Name = "hylbxgbutton";
            this.hylbxgbutton.Size = new System.Drawing.Size(93, 88);
            this.hylbxgbutton.TabIndex = 1;
            this.hylbxgbutton.Text = "\r\n会员类别修改";
            this.hylbxgbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.hylbxgbutton.UseVisualStyleBackColor = false;
            this.hylbxgbutton.Click += new System.EventHandler(this.hylbxgbutton_Click);
            // 
            // zjhylbbutton
            // 
            this.zjhylbbutton.BackColor = System.Drawing.Color.Transparent;
            this.zjhylbbutton.FlatAppearance.BorderSize = 0;
            this.zjhylbbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zjhylbbutton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zjhylbbutton.Image = global::yixiupige.Properties.Resources._1166404;
            this.zjhylbbutton.Location = new System.Drawing.Point(12, 12);
            this.zjhylbbutton.Name = "zjhylbbutton";
            this.zjhylbbutton.Size = new System.Drawing.Size(90, 88);
            this.zjhylbbutton.TabIndex = 0;
            this.zjhylbbutton.Text = "\r\n增加会员类别";
            this.zjhylbbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zjhylbbutton.UseVisualStyleBackColor = false;
            this.zjhylbbutton.Click += new System.EventHandler(this.zjhylbbutton_Click);
            // 
            // memberTypeTableAdapter
            // 
            this.memberTypeTableAdapter.ClearBeforeFill = true;
            // 
            // hyflglfwForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tcbutton);
            this.Controls.Add(this.scfwbutton);
            this.Controls.Add(this.xgfwbutton);
            this.Controls.Add(this.zjfwbutton);
            this.Controls.Add(this.hylbscbutton);
            this.Controls.Add(this.hylbxgbutton);
            this.Controls.Add(this.zjhylbbutton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "hyflglfwForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员分类管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.hyflglfwForm_FormClosed);
            this.Load += new System.EventHandler(this.hyflglfwForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinyaoo123456DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zjhylbbutton;
        private System.Windows.Forms.Button hylbxgbutton;
        private System.Windows.Forms.Button hylbscbutton;
        private System.Windows.Forms.Button zjfwbutton;
        private System.Windows.Forms.Button xgfwbutton;
        private System.Windows.Forms.Button scfwbutton;
        private System.Windows.Forms.Button tcbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource memberTypeBindingSource;
        private kinyaoo123456DataSet kinyaoo123456DataSet;
        private kinyaoo123456DataSetTableAdapters.memberTypeTableAdapter memberTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberCardMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberRebateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberTopUpDataGridViewTextBoxColumn;
    }
}