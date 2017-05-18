namespace yixiupige
{
    partial class jhglForm
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
            this.scbutton = new System.Windows.Forms.Button();
            this.fxbutton = new System.Windows.Forms.Button();
            this.qxbutton = new System.Windows.Forms.Button();
            this.scjhbutton = new System.Windows.Forms.Button();
            this.sltextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.qstextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.scbutton);
            this.groupBox1.Controls.Add(this.fxbutton);
            this.groupBox1.Controls.Add(this.qxbutton);
            this.groupBox1.Controls.Add(this.scjhbutton);
            this.groupBox1.Controls.Add(this.sltextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.qstextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成牌号";
            // 
            // scbutton
            // 
            this.scbutton.Location = new System.Drawing.Point(611, 40);
            this.scbutton.Name = "scbutton";
            this.scbutton.Size = new System.Drawing.Size(75, 23);
            this.scbutton.TabIndex = 7;
            this.scbutton.Text = "删除";
            this.scbutton.UseVisualStyleBackColor = true;
            // 
            // fxbutton
            // 
            this.fxbutton.Location = new System.Drawing.Point(506, 40);
            this.fxbutton.Name = "fxbutton";
            this.fxbutton.Size = new System.Drawing.Size(75, 23);
            this.fxbutton.TabIndex = 6;
            this.fxbutton.Text = "反选";
            this.fxbutton.UseVisualStyleBackColor = true;
            // 
            // qxbutton
            // 
            this.qxbutton.Location = new System.Drawing.Point(404, 40);
            this.qxbutton.Name = "qxbutton";
            this.qxbutton.Size = new System.Drawing.Size(75, 23);
            this.qxbutton.TabIndex = 5;
            this.qxbutton.Text = "全选";
            this.qxbutton.UseVisualStyleBackColor = true;
            // 
            // scjhbutton
            // 
            this.scjhbutton.Location = new System.Drawing.Point(289, 40);
            this.scjhbutton.Name = "scjhbutton";
            this.scjhbutton.Size = new System.Drawing.Size(75, 23);
            this.scjhbutton.TabIndex = 4;
            this.scjhbutton.Text = "生成架号";
            this.scjhbutton.UseVisualStyleBackColor = true;
            // 
            // sltextBox
            // 
            this.sltextBox.Location = new System.Drawing.Point(199, 40);
            this.sltextBox.Name = "sltextBox";
            this.sltextBox.Size = new System.Drawing.Size(53, 23);
            this.sltextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "架号数量：";
            // 
            // qstextBox
            // 
            this.qstextBox.Location = new System.Drawing.Point(71, 39);
            this.qstextBox.Name = "qstextBox";
            this.qstextBox.Size = new System.Drawing.Size(48, 23);
            this.qstextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始架号：";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(719, 356);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 378);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "牌号信息";
            // 
            // jhglForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::yixiupige.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(744, 492);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.Name = "jhglForm";
            this.Text = "架号管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.jhglForm_FormClosed);
            this.Load += new System.EventHandler(this.jhglForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button scbutton;
        private System.Windows.Forms.Button fxbutton;
        private System.Windows.Forms.Button qxbutton;
        private System.Windows.Forms.Button scjhbutton;
        private System.Windows.Forms.TextBox sltextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox qstextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}