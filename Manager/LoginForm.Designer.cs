namespace Manager
{
    partial class LoginForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.PswdLbl = new System.Windows.Forms.Label();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.PswdBox = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.IdErrorLbl = new System.Windows.Forms.Label();
            this.PswdErrorLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.UserNameLbl.Location = new System.Drawing.Point(61, 119);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(88, 25);
            this.UserNameLbl.TabIndex = 0;
            this.UserNameLbl.Text = "用户名：";
            // 
            // PswdLbl
            // 
            this.PswdLbl.AutoSize = true;
            this.PswdLbl.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PswdLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PswdLbl.Location = new System.Drawing.Point(61, 197);
            this.PswdLbl.Name = "PswdLbl";
            this.PswdLbl.Size = new System.Drawing.Size(87, 25);
            this.PswdLbl.TabIndex = 1;
            this.PswdLbl.Text = "密   码：";
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(155, 123);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(171, 21);
            this.UserNameBox.TabIndex = 2;
            this.UserNameBox.Text = "12121212121";
            this.UserNameBox.Leave += new System.EventHandler(this.UserNameBox_Leave);
            // 
            // PswdBox
            // 
            this.PswdBox.Location = new System.Drawing.Point(155, 201);
            this.PswdBox.Name = "PswdBox";
            this.PswdBox.Size = new System.Drawing.Size(171, 21);
            this.PswdBox.TabIndex = 3;
            this.PswdBox.Text = "aaaaaa";
            this.PswdBox.UseSystemPasswordChar = true;
            this.PswdBox.Leave += new System.EventHandler(this.PswdBox_Leave);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LoginBtn.Location = new System.Drawing.Point(155, 279);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 35);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "登    陆";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // IdErrorLbl
            // 
            this.IdErrorLbl.AutoSize = true;
            this.IdErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.IdErrorLbl.Location = new System.Drawing.Point(153, 157);
            this.IdErrorLbl.Name = "IdErrorLbl";
            this.IdErrorLbl.Size = new System.Drawing.Size(77, 12);
            this.IdErrorLbl.TabIndex = 5;
            this.IdErrorLbl.Text = "请输入用户名";
            this.IdErrorLbl.Visible = false;
            // 
            // PswdErrorLbl
            // 
            this.PswdErrorLbl.AutoSize = true;
            this.PswdErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.PswdErrorLbl.Location = new System.Drawing.Point(153, 235);
            this.PswdErrorLbl.Name = "PswdErrorLbl";
            this.PswdErrorLbl.Size = new System.Drawing.Size(65, 12);
            this.PswdErrorLbl.TabIndex = 6;
            this.PswdErrorLbl.Text = "请输入密码";
            this.PswdErrorLbl.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 103);
            this.label1.TabIndex = 7;
            this.label1.Text = "登录到\r\nMini Library";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PswdErrorLbl);
            this.Controls.Add(this.IdErrorLbl);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PswdBox);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.PswdLbl);
            this.Controls.Add(this.UserNameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Label PswdLbl;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.TextBox PswdBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label IdErrorLbl;
        private System.Windows.Forms.Label PswdErrorLbl;
        private System.Windows.Forms.Label label1;
    }
}

