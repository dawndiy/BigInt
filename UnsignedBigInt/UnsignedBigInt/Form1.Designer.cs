namespace UnsignedBigInt
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_cl = new System.Windows.Forms.Button();
            this.radioButton_add = new System.Windows.Forms.RadioButton();
            this.radioButton_sub = new System.Windows.Forms.RadioButton();
            this.radioButton_mul = new System.Windows.Forms.RadioButton();
            this.radioButton_div = new System.Windows.Forms.RadioButton();
            this.btn_res = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(57, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(258, 65);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(57, 83);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(258, 65);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.Location = new System.Drawing.Point(57, 154);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(258, 65);
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "大整数1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "大整数2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "结果";
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(166, 331);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(69, 25);
            this.btn_about.TabIndex = 9;
            this.btn_about.Text = "关于";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(241, 331);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(69, 25);
            this.btn_exit.TabIndex = 10;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_cl
            // 
            this.btn_cl.Location = new System.Drawing.Point(91, 331);
            this.btn_cl.Name = "btn_cl";
            this.btn_cl.Size = new System.Drawing.Size(69, 25);
            this.btn_cl.TabIndex = 8;
            this.btn_cl.Text = "C";
            this.btn_cl.UseVisualStyleBackColor = true;
            this.btn_cl.Click += new System.EventHandler(this.btn_cl_Click);
            // 
            // radioButton_add
            // 
            this.radioButton_add.AutoSize = true;
            this.radioButton_add.Location = new System.Drawing.Point(22, 295);
            this.radioButton_add.Name = "radioButton_add";
            this.radioButton_add.Size = new System.Drawing.Size(29, 16);
            this.radioButton_add.TabIndex = 3;
            this.radioButton_add.TabStop = true;
            this.radioButton_add.Text = "+";
            this.radioButton_add.UseVisualStyleBackColor = true;
            this.radioButton_add.CheckedChanged += new System.EventHandler(this.radioButton_add_CheckedChanged);
            // 
            // radioButton_sub
            // 
            this.radioButton_sub.AutoSize = true;
            this.radioButton_sub.Location = new System.Drawing.Point(106, 295);
            this.radioButton_sub.Name = "radioButton_sub";
            this.radioButton_sub.Size = new System.Drawing.Size(29, 16);
            this.radioButton_sub.TabIndex = 4;
            this.radioButton_sub.TabStop = true;
            this.radioButton_sub.Text = "-";
            this.radioButton_sub.UseVisualStyleBackColor = true;
            this.radioButton_sub.CheckedChanged += new System.EventHandler(this.radioButton_sub_CheckedChanged);
            // 
            // radioButton_mul
            // 
            this.radioButton_mul.AutoSize = true;
            this.radioButton_mul.Location = new System.Drawing.Point(197, 295);
            this.radioButton_mul.Name = "radioButton_mul";
            this.radioButton_mul.Size = new System.Drawing.Size(29, 16);
            this.radioButton_mul.TabIndex = 5;
            this.radioButton_mul.TabStop = true;
            this.radioButton_mul.Text = "*";
            this.radioButton_mul.UseVisualStyleBackColor = true;
            this.radioButton_mul.CheckedChanged += new System.EventHandler(this.radioButton_mul_CheckedChanged);
            // 
            // radioButton_div
            // 
            this.radioButton_div.AutoSize = true;
            this.radioButton_div.Location = new System.Drawing.Point(275, 295);
            this.radioButton_div.Name = "radioButton_div";
            this.radioButton_div.Size = new System.Drawing.Size(29, 16);
            this.radioButton_div.TabIndex = 6;
            this.radioButton_div.TabStop = true;
            this.radioButton_div.Text = "/";
            this.radioButton_div.UseVisualStyleBackColor = true;
            this.radioButton_div.CheckedChanged += new System.EventHandler(this.radioButton_div_CheckedChanged);
            // 
            // btn_res
            // 
            this.btn_res.Location = new System.Drawing.Point(16, 331);
            this.btn_res.Name = "btn_res";
            this.btn_res.Size = new System.Drawing.Size(69, 25);
            this.btn_res.TabIndex = 7;
            this.btn_res.Text = "=";
            this.btn_res.UseVisualStyleBackColor = true;
            this.btn_res.Click += new System.EventHandler(this.btn_res_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(57, 225);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(258, 51);
            this.textBox4.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "说明";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 368);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btn_res);
            this.Controls.Add(this.radioButton_div);
            this.Controls.Add(this.radioButton_mul);
            this.Controls.Add(this.radioButton_sub);
            this.Controls.Add(this.radioButton_add);
            this.Controls.Add(this.btn_cl);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(333, 214);
            this.Name = "Form1";
            this.Text = "大整数计算器 v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_cl;
        private System.Windows.Forms.RadioButton radioButton_add;
        private System.Windows.Forms.RadioButton radioButton_sub;
        private System.Windows.Forms.RadioButton radioButton_mul;
        private System.Windows.Forms.RadioButton radioButton_div;
        private System.Windows.Forms.Button btn_res;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
    }
}

