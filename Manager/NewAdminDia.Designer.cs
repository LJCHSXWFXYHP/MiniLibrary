namespace Manager
{
    partial class NewAdminDia
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
            this.PhoneNumLbl = new System.Windows.Forms.Label();
            this.PhoneNumBox = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.ConfPswdBox = new System.Windows.Forms.TextBox();
            this.ConfPswdLbl = new System.Windows.Forms.Label();
            this.PswdBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PswdLbl = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.PhoneHintLbl = new System.Windows.Forms.Label();
            this.UserIdHintLbl = new System.Windows.Forms.Label();
            this.PswdHintLbl = new System.Windows.Forms.Label();
            this.ConfPswdHintLbl = new System.Windows.Forms.Label();
            this.AdminLevelLbl = new System.Windows.Forms.Label();
            this.AdminLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.AdminLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // PhoneNumLbl
            // 
            this.PhoneNumLbl.AutoSize = true;
            this.PhoneNumLbl.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.PhoneNumLbl.Location = new System.Drawing.Point(73, 60);
            this.PhoneNumLbl.Name = "PhoneNumLbl";
            this.PhoneNumLbl.Size = new System.Drawing.Size(100, 24);
            this.PhoneNumLbl.TabIndex = 0;
            this.PhoneNumLbl.Text = "手机号码：";
            // 
            // PhoneNumBox
            // 
            this.PhoneNumBox.Location = new System.Drawing.Point(191, 62);
            this.PhoneNumBox.Name = "PhoneNumBox";
            this.PhoneNumBox.Size = new System.Drawing.Size(185, 23);
            this.PhoneNumBox.TabIndex = 1;
            this.PhoneNumBox.Leave += new System.EventHandler(this.PhoneNumHint);
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.NameLbl.Location = new System.Drawing.Point(76, 128);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(92, 24);
            this.NameLbl.TabIndex = 2;
            this.NameLbl.Text = "用 户 名：";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(191, 130);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(185, 23);
            this.NameBox.TabIndex = 3;
            this.NameBox.Leave += new System.EventHandler(this.UserIdHint);
            // 
            // ConfPswdBox
            // 
            this.ConfPswdBox.Location = new System.Drawing.Point(191, 269);
            this.ConfPswdBox.Name = "ConfPswdBox";
            this.ConfPswdBox.Size = new System.Drawing.Size(185, 23);
            this.ConfPswdBox.TabIndex = 7;
            this.ConfPswdBox.UseSystemPasswordChar = true;
            this.ConfPswdBox.Leave += new System.EventHandler(this.ConfPswdHint);
            // 
            // ConfPswdLbl
            // 
            this.ConfPswdLbl.AutoSize = true;
            this.ConfPswdLbl.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.ConfPswdLbl.Location = new System.Drawing.Point(73, 267);
            this.ConfPswdLbl.Name = "ConfPswdLbl";
            this.ConfPswdLbl.Size = new System.Drawing.Size(100, 24);
            this.ConfPswdLbl.TabIndex = 6;
            this.ConfPswdLbl.Text = "确认密码：";
            // 
            // PswdBox
            // 
            this.PswdBox.Location = new System.Drawing.Point(191, 201);
            this.PswdBox.Name = "PswdBox";
            this.PswdBox.Size = new System.Drawing.Size(185, 23);
            this.PswdBox.TabIndex = 5;
            this.PswdBox.UseSystemPasswordChar = true;
            this.PswdBox.Leave += new System.EventHandler(this.PswdHint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label2.Location = new System.Drawing.Point(69, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "密       码：";
            // 
            // PswdLbl
            // 
            this.PswdLbl.AutoSize = true;
            this.PswdLbl.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.PswdLbl.Location = new System.Drawing.Point(74, 201);
            this.PswdLbl.Name = "PswdLbl";
            this.PswdLbl.Size = new System.Drawing.Size(99, 24);
            this.PswdLbl.TabIndex = 4;
            this.PswdLbl.Text = "密       码：";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.SubmitBtn.Location = new System.Drawing.Point(179, 406);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(99, 33);
            this.SubmitBtn.TabIndex = 8;
            this.SubmitBtn.Text = "确   认";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // PhoneHintLbl
            // 
            this.PhoneHintLbl.AutoSize = true;
            this.PhoneHintLbl.ForeColor = System.Drawing.Color.Red;
            this.PhoneHintLbl.Location = new System.Drawing.Point(197, 88);
            this.PhoneHintLbl.Name = "PhoneHintLbl";
            this.PhoneHintLbl.Size = new System.Drawing.Size(130, 17);
            this.PhoneHintLbl.TabIndex = 9;
            this.PhoneHintLbl.Text = "手机号应为11位纯数字";
            this.PhoneHintLbl.Visible = false;
            // 
            // UserIdHintLbl
            // 
            this.UserIdHintLbl.AutoSize = true;
            this.UserIdHintLbl.ForeColor = System.Drawing.Color.Red;
            this.UserIdHintLbl.Location = new System.Drawing.Point(197, 156);
            this.UserIdHintLbl.Name = "UserIdHintLbl";
            this.UserIdHintLbl.Size = new System.Drawing.Size(130, 17);
            this.UserIdHintLbl.TabIndex = 10;
            this.UserIdHintLbl.Text = "用户名不多于10个字符";
            this.UserIdHintLbl.Visible = false;
            // 
            // PswdHintLbl
            // 
            this.PswdHintLbl.AutoSize = true;
            this.PswdHintLbl.ForeColor = System.Drawing.Color.Red;
            this.PswdHintLbl.Location = new System.Drawing.Point(197, 227);
            this.PswdHintLbl.Name = "PswdHintLbl";
            this.PswdHintLbl.Size = new System.Drawing.Size(94, 17);
            this.PswdHintLbl.TabIndex = 11;
            this.PswdHintLbl.Text = "密码不多于16位";
            this.PswdHintLbl.Visible = false;
            // 
            // ConfPswdHintLbl
            // 
            this.ConfPswdHintLbl.AutoSize = true;
            this.ConfPswdHintLbl.ForeColor = System.Drawing.Color.Red;
            this.ConfPswdHintLbl.Location = new System.Drawing.Point(197, 295);
            this.ConfPswdHintLbl.Name = "ConfPswdHintLbl";
            this.ConfPswdHintLbl.Size = new System.Drawing.Size(140, 17);
            this.ConfPswdHintLbl.TabIndex = 12;
            this.ConfPswdHintLbl.Text = "请确认两次输入密码相同";
            this.ConfPswdHintLbl.Visible = false;
            // 
            // AdminLevelLbl
            // 
            this.AdminLevelLbl.AutoSize = true;
            this.AdminLevelLbl.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.AdminLevelLbl.Location = new System.Drawing.Point(73, 339);
            this.AdminLevelLbl.Name = "AdminLevelLbl";
            this.AdminLevelLbl.Size = new System.Drawing.Size(100, 24);
            this.AdminLevelLbl.TabIndex = 13;
            this.AdminLevelLbl.Text = "管理级别：";
            // 
            // AdminLevel
            // 
            this.AdminLevel.Location = new System.Drawing.Point(191, 341);
            this.AdminLevel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.AdminLevel.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AdminLevel.Name = "AdminLevel";
            this.AdminLevel.Size = new System.Drawing.Size(68, 23);
            this.AdminLevel.TabIndex = 14;
            this.AdminLevel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NewAdminDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 485);
            this.Controls.Add(this.AdminLevel);
            this.Controls.Add(this.AdminLevelLbl);
            this.Controls.Add(this.ConfPswdHintLbl);
            this.Controls.Add(this.PswdHintLbl);
            this.Controls.Add(this.UserIdHintLbl);
            this.Controls.Add(this.PhoneHintLbl);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.ConfPswdBox);
            this.Controls.Add(this.ConfPswdLbl);
            this.Controls.Add(this.PswdBox);
            this.Controls.Add(this.PswdLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.PhoneNumBox);
            this.Controls.Add(this.PhoneNumLbl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "NewAdminDia";
            this.Text = "新建管理员";
            ((System.ComponentModel.ISupportInitialize)(this.AdminLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PhoneNumLbl;
        private System.Windows.Forms.TextBox PhoneNumBox;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox ConfPswdBox;
        private System.Windows.Forms.Label ConfPswdLbl;
        private System.Windows.Forms.TextBox PswdBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PswdLbl;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label PhoneHintLbl;
        private System.Windows.Forms.Label UserIdHintLbl;
        private System.Windows.Forms.Label PswdHintLbl;
        private System.Windows.Forms.Label ConfPswdHintLbl;
        private System.Windows.Forms.Label AdminLevelLbl;
        private System.Windows.Forms.NumericUpDown AdminLevel;
    }
}