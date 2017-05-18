namespace yixiupige
{
    partial class zjhyflForm
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
            this.hymctextBox = new System.Windows.Forms.TextBox();
            this.splxcomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bkjetextBox = new System.Windows.Forms.TextBox();
            this.czcstextBox = new System.Windows.Forms.TextBox();
            this.spzktextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "办卡类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "消费折扣：";
            // 
            // hymctextBox
            // 
            this.hymctextBox.Location = new System.Drawing.Point(93, 28);
            this.hymctextBox.Name = "hymctextBox";
            this.hymctextBox.Size = new System.Drawing.Size(243, 21);
            this.hymctextBox.TabIndex = 3;
            // 
            // splxcomboBox
            // 
            this.splxcomboBox.FormattingEnabled = true;
            this.splxcomboBox.Items.AddRange(new object[] {
            "计次卡",
            "折扣卡",
            "储值卡"});
            this.splxcomboBox.Location = new System.Drawing.Point(93, 58);
            this.splxcomboBox.Name = "splxcomboBox";
            this.splxcomboBox.Size = new System.Drawing.Size(57, 20);
            this.splxcomboBox.TabIndex = 4;
            this.splxcomboBox.SelectedIndexChanged += new System.EventHandler(this.splxcomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(165, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "办卡金额：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(165, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "充值次数：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(104, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(212, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bkjetextBox
            // 
            this.bkjetextBox.Location = new System.Drawing.Point(236, 60);
            this.bkjetextBox.Name = "bkjetextBox";
            this.bkjetextBox.Size = new System.Drawing.Size(100, 21);
            this.bkjetextBox.TabIndex = 9;
            // 
            // czcstextBox
            // 
            this.czcstextBox.Location = new System.Drawing.Point(236, 86);
            this.czcstextBox.Name = "czcstextBox";
            this.czcstextBox.Size = new System.Drawing.Size(100, 21);
            this.czcstextBox.TabIndex = 10;
            // 
            // spzktextBox
            // 
            this.spzktextBox.Location = new System.Drawing.Point(93, 85);
            this.spzktextBox.Name = "spzktextBox";
            this.spzktextBox.Size = new System.Drawing.Size(57, 21);
            this.spzktextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(48, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "注：消费折扣填写数字，例如八折就填写80";
            // 
            // zjhyflForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::yixiupige.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(395, 182);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spzktextBox);
            this.Controls.Add(this.czcstextBox);
            this.Controls.Add(this.bkjetextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.splxcomboBox);
            this.Controls.Add(this.hymctextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "zjhyflForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加会员分类";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.zjhyflForm_FormClosed);
            this.Load += new System.EventHandler(this.zjhyflForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hymctextBox;
        private System.Windows.Forms.ComboBox splxcomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox bkjetextBox;
        private System.Windows.Forms.TextBox czcstextBox;
        private System.Windows.Forms.TextBox spzktextBox;
        private System.Windows.Forms.Label label6;
    }
}