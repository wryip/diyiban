namespace yixiupige
{
    partial class qtForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.zjbutton = new System.Windows.Forms.Button();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.th = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(16, 132);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(549, 374);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mc,
            this.th});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(541, 348);
            this.dataGridView1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::yixiupige.Properties.Resources._4505;
            this.button4.Location = new System.Drawing.Point(437, 19);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 95);
            this.button4.TabIndex = 3;
            this.button4.Text = "\r\n退出\r\n";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::yixiupige.Properties.Resources._6962;
            this.button3.Location = new System.Drawing.Point(296, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 96);
            this.button3.TabIndex = 2;
            this.button3.Text = "\r\n删除\r\n";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::yixiupige.Properties.Resources._1631;
            this.button2.Location = new System.Drawing.Point(153, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 96);
            this.button2.TabIndex = 1;
            this.button2.Text = "\r\n\r\n修改";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zjbutton
            // 
            this.zjbutton.FlatAppearance.BorderSize = 0;
            this.zjbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zjbutton.Image = global::yixiupige.Properties.Resources._1133944;
            this.zjbutton.Location = new System.Drawing.Point(16, 15);
            this.zjbutton.Margin = new System.Windows.Forms.Padding(4);
            this.zjbutton.Name = "zjbutton";
            this.zjbutton.Size = new System.Drawing.Size(100, 99);
            this.zjbutton.TabIndex = 0;
            this.zjbutton.Text = "\r\n增加";
            this.zjbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zjbutton.UseVisualStyleBackColor = true;
            this.zjbutton.Click += new System.EventHandler(this.zjbutton_Click);
            // 
            // mc
            // 
            this.mc.DataPropertyName = "QtName";
            this.mc.HeaderText = "名称";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            // 
            // th
            // 
            this.th.DataPropertyName = "QtTc";
            this.th.HeaderText = "提成";
            this.th.Name = "th";
            this.th.ReadOnly = true;
            // 
            // qtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.zjbutton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "qtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "其他服务";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.qtForm_FormClosed);
            this.Load += new System.EventHandler(this.qtForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zjbutton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn th;
    }
}