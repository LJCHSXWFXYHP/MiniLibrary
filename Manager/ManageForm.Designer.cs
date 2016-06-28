namespace Manager
{
    partial class ManageWindow
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.UserManageTab = new System.Windows.Forms.TabPage();
            this.BookTab = new System.Windows.Forms.TabPage();
            this.OrderTab = new System.Windows.Forms.TabPage();
            this.UserGridView = new System.Windows.Forms.DataGridView();
            this.BooksGridView = new System.Windows.Forms.DataGridView();
            this.RecordGridView = new System.Windows.Forms.DataGridView();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.UserManageTab.SuspendLayout();
            this.BookTab.SuspendLayout();
            this.OrderTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.MainTab);
            this.TabControl.Controls.Add(this.UserManageTab);
            this.TabControl.Controls.Add(this.BookTab);
            this.TabControl.Controls.Add(this.OrderTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(884, 561);
            this.TabControl.TabIndex = 2;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.UserNameLbl);
            this.MainTab.Controls.Add(this.TitleLbl);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(876, 535);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "主页";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // UserManageTab
            // 
            this.UserManageTab.Controls.Add(this.UserGridView);
            this.UserManageTab.Location = new System.Drawing.Point(4, 22);
            this.UserManageTab.Name = "UserManageTab";
            this.UserManageTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserManageTab.Size = new System.Drawing.Size(876, 535);
            this.UserManageTab.TabIndex = 1;
            this.UserManageTab.Text = "用户管理";
            this.UserManageTab.UseVisualStyleBackColor = true;
            // 
            // BookTab
            // 
            this.BookTab.Controls.Add(this.BooksGridView);
            this.BookTab.Location = new System.Drawing.Point(4, 22);
            this.BookTab.Name = "BookTab";
            this.BookTab.Padding = new System.Windows.Forms.Padding(3);
            this.BookTab.Size = new System.Drawing.Size(876, 535);
            this.BookTab.TabIndex = 2;
            this.BookTab.Text = "图书管理";
            this.BookTab.UseVisualStyleBackColor = true;
            // 
            // OrderTab
            // 
            this.OrderTab.Controls.Add(this.RecordGridView);
            this.OrderTab.Location = new System.Drawing.Point(4, 22);
            this.OrderTab.Name = "OrderTab";
            this.OrderTab.Padding = new System.Windows.Forms.Padding(3);
            this.OrderTab.Size = new System.Drawing.Size(876, 535);
            this.OrderTab.TabIndex = 3;
            this.OrderTab.Text = "记录管理";
            this.OrderTab.UseVisualStyleBackColor = true;
            // 
            // UserGridView
            // 
            this.UserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserGridView.Location = new System.Drawing.Point(3, 3);
            this.UserGridView.Name = "UserGridView";
            this.UserGridView.RowTemplate.Height = 23;
            this.UserGridView.Size = new System.Drawing.Size(870, 319);
            this.UserGridView.TabIndex = 0;
            // 
            // BooksGridView
            // 
            this.BooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BooksGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.BooksGridView.Location = new System.Drawing.Point(3, 3);
            this.BooksGridView.Name = "BooksGridView";
            this.BooksGridView.RowTemplate.Height = 23;
            this.BooksGridView.Size = new System.Drawing.Size(870, 319);
            this.BooksGridView.TabIndex = 1;
            // 
            // RecordGridView
            // 
            this.RecordGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.RecordGridView.Location = new System.Drawing.Point(3, 3);
            this.RecordGridView.Name = "RecordGridView";
            this.RecordGridView.RowTemplate.Height = 23;
            this.RecordGridView.Size = new System.Drawing.Size(870, 319);
            this.RecordGridView.TabIndex = 2;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLbl.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TitleLbl.Location = new System.Drawing.Point(3, 3);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(870, 92);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Mini Library 管理系统";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserNameLbl.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLbl.ForeColor = System.Drawing.Color.Black;
            this.UserNameLbl.Location = new System.Drawing.Point(3, 95);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(870, 38);
            this.UserNameLbl.TabIndex = 1;
            this.UserNameLbl.Text = "当前用户： Admin";
            this.UserNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ManageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.TabControl.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.UserManageTab.ResumeLayout(false);
            this.BookTab.ResumeLayout(false);
            this.OrderTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.TabPage UserManageTab;
        private System.Windows.Forms.TabPage BookTab;
        private System.Windows.Forms.TabPage OrderTab;
        private System.Windows.Forms.DataGridView UserGridView;
        private System.Windows.Forms.DataGridView BooksGridView;
        private System.Windows.Forms.DataGridView RecordGridView;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label UserNameLbl;
    }
}