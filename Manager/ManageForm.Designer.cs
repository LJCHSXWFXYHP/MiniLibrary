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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("图书管理");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("订单管理");
            this.MenuTV = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // MenuTV
            // 
            this.MenuTV.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuTV.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuTV.Location = new System.Drawing.Point(0, 0);
            this.MenuTV.Name = "MenuTV";
            treeNode4.Name = "UsersManageNode";
            treeNode4.Text = "用户管理";
            treeNode5.Name = "BooksManageNode";
            treeNode5.Text = "图书管理";
            treeNode6.Name = "OrdersManageNode";
            treeNode6.Text = "订单管理";
            this.MenuTV.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.MenuTV.Size = new System.Drawing.Size(192, 561);
            this.MenuTV.TabIndex = 1;
            // 
            // ManageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.MenuTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManageWindow";
            this.Text = "管理";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView MenuTV;
    }
}