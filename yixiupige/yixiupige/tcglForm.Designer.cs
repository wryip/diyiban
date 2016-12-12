namespace yixiupige
{
    partial class tcglForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tjbutton = new System.Windows.Forms.Button();
            this.tcjsbutton = new System.Windows.Forms.Button();
            this.wjsradioButton = new System.Windows.Forms.RadioButton();
            this.yjsradioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fwxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ywy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.js = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "员工：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(246, 24);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(105, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(398, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // tjbutton
            // 
            this.tjbutton.Location = new System.Drawing.Point(525, 22);
            this.tjbutton.Name = "tjbutton";
            this.tjbutton.Size = new System.Drawing.Size(75, 23);
            this.tjbutton.TabIndex = 6;
            this.tjbutton.Text = "统计";
            this.tjbutton.UseVisualStyleBackColor = true;
            // 
            // tcjsbutton
            // 
            this.tcjsbutton.Location = new System.Drawing.Point(622, 22);
            this.tcjsbutton.Name = "tcjsbutton";
            this.tcjsbutton.Size = new System.Drawing.Size(75, 23);
            this.tcjsbutton.TabIndex = 7;
            this.tcjsbutton.Text = "提成结算";
            this.tcjsbutton.UseVisualStyleBackColor = true;
            // 
            // wjsradioButton
            // 
            this.wjsradioButton.AutoSize = true;
            this.wjsradioButton.Location = new System.Drawing.Point(726, 26);
            this.wjsradioButton.Name = "wjsradioButton";
            this.wjsradioButton.Size = new System.Drawing.Size(59, 16);
            this.wjsradioButton.TabIndex = 8;
            this.wjsradioButton.TabStop = true;
            this.wjsradioButton.Text = "未结算";
            this.wjsradioButton.UseVisualStyleBackColor = true;
           
            // 
            // yjsradioButton
            // 
            this.yjsradioButton.AutoSize = true;
            this.yjsradioButton.Location = new System.Drawing.Point(808, 27);
            this.yjsradioButton.Name = "yjsradioButton";
            this.yjsradioButton.Size = new System.Drawing.Size(59, 16);
            this.yjsradioButton.TabIndex = 9;
            this.yjsradioButton.TabStop = true;
            this.yjsradioButton.Text = "已结算\r\n";
            this.yjsradioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(14, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 423);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bh,
            this.kh,
            this.lb,
            this.xm,
            this.sj,
            this.sl,
            this.tc,
            this.fwxm,
            this.ywy,
            this.js});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(908, 403);
            this.dataGridView1.TabIndex = 0;
            // 
            // bh
            // 
            this.bh.HeaderText = "编号";
            this.bh.Name = "bh";
            this.bh.ReadOnly = true;
            // 
            // kh
            // 
            this.kh.HeaderText = "卡号";
            this.kh.Name = "kh";
            this.kh.ReadOnly = true;
            // 
            // lb
            // 
            this.lb.HeaderText = "类别";
            this.lb.Name = "lb";
            this.lb.ReadOnly = true;
            // 
            // xm
            // 
            this.xm.HeaderText = "姓名";
            this.xm.Name = "xm";
            this.xm.ReadOnly = true;
            // 
            // sj
            // 
            this.sj.HeaderText = "时间";
            this.sj.Name = "sj";
            this.sj.ReadOnly = true;
            // 
            // sl
            // 
            this.sl.HeaderText = "数量";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            // 
            // tc
            // 
            this.tc.HeaderText = "提成";
            this.tc.Name = "tc";
            this.tc.ReadOnly = true;
            // 
            // fwxm
            // 
            this.fwxm.HeaderText = "服务项目";
            this.fwxm.Name = "fwxm";
            this.fwxm.ReadOnly = true;
            // 
            // ywy
            // 
            this.ywy.HeaderText = "业务员";
            this.ywy.Name = "ywy";
            this.ywy.ReadOnly = true;
            // 
            // js
            // 
            this.js.HeaderText = "结算";
            this.js.Name = "js";
            this.js.ReadOnly = true;
            // 
            // tcglForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 485);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.yjsradioButton);
            this.Controls.Add(this.wjsradioButton);
            this.Controls.Add(this.tcjsbutton);
            this.Controls.Add(this.tjbutton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "tcglForm";
            this.Text = "员工提成窗口";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tcglForm_FormClosed);
       
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button tjbutton;
        private System.Windows.Forms.Button tcjsbutton;
        private System.Windows.Forms.RadioButton wjsradioButton;
        private System.Windows.Forms.RadioButton yjsradioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bh;
        private System.Windows.Forms.DataGridViewTextBoxColumn kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lb;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn tc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fwxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ywy;
        private System.Windows.Forms.DataGridViewTextBoxColumn js;
    }
}