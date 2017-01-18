namespace yixiupige
{
    partial class hylxedit
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
            this.spzktextBox = new System.Windows.Forms.TextBox();
            this.czcstextBox = new System.Windows.Forms.TextBox();
            this.bkjetextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splxcomboBox = new System.Windows.Forms.ComboBox();
            this.hymctextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // spzktextBox
            // 
            this.spzktextBox.Location = new System.Drawing.Point(148, 105);
            this.spzktextBox.Margin = new System.Windows.Forms.Padding(4);
            this.spzktextBox.Name = "spzktextBox";
            this.spzktextBox.ReadOnly = true;
            this.spzktextBox.Size = new System.Drawing.Size(75, 25);
            this.spzktextBox.TabIndex = 23;
            this.spzktextBox.Text = "100";
            // 
            // czcstextBox
            // 
            this.czcstextBox.Location = new System.Drawing.Point(339, 107);
            this.czcstextBox.Margin = new System.Windows.Forms.Padding(4);
            this.czcstextBox.Name = "czcstextBox";
            this.czcstextBox.Size = new System.Drawing.Size(132, 25);
            this.czcstextBox.TabIndex = 22;
            // 
            // bkjetextBox
            // 
            this.bkjetextBox.Location = new System.Drawing.Point(339, 74);
            this.bkjetextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bkjetextBox.Name = "bkjetextBox";
            this.bkjetextBox.Size = new System.Drawing.Size(132, 25);
            this.bkjetextBox.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 153);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 20;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "充值次数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "办卡金额：";
            // 
            // splxcomboBox
            // 
            this.splxcomboBox.FormattingEnabled = true;
            this.splxcomboBox.Items.AddRange(new object[] {
            "计次卡",
            "折扣卡",
            "储值卡"});
            this.splxcomboBox.Location = new System.Drawing.Point(148, 71);
            this.splxcomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.splxcomboBox.Name = "splxcomboBox";
            this.splxcomboBox.Size = new System.Drawing.Size(75, 23);
            this.splxcomboBox.TabIndex = 16;
            this.splxcomboBox.SelectedIndexChanged += new System.EventHandler(this.splxcomboBox_SelectedIndexChanged);
            // 
            // hymctextBox
            // 
            this.hymctextBox.Location = new System.Drawing.Point(148, 34);
            this.hymctextBox.Margin = new System.Windows.Forms.Padding(4);
            this.hymctextBox.Name = "hymctextBox";
            this.hymctextBox.Size = new System.Drawing.Size(323, 25);
            this.hymctextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "商品折扣：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "办卡类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "会员名称：";
            // 
            // hylxedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 216);
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
            this.Name = "hylxedit";
            this.Text = "编辑会员";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.hylxedit_FormClosed);
            this.Load += new System.EventHandler(this.hylxedit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox spzktextBox;
        private System.Windows.Forms.TextBox czcstextBox;
        private System.Windows.Forms.TextBox bkjetextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox splxcomboBox;
        private System.Windows.Forms.TextBox hymctextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}