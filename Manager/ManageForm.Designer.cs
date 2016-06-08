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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("图书管理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("订单管理");
            this.MenuTV = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.libraryDataSet = new Manager.libraryDataSet();
            this.libraryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuTV
            // 
            this.MenuTV.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuTV.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuTV.Location = new System.Drawing.Point(0, 0);
            this.MenuTV.Name = "MenuTV";
            treeNode1.Name = "UsersManageNode";
            treeNode1.Text = "用户管理";
            treeNode2.Name = "BooksManageNode";
            treeNode2.Text = "图书管理";
            treeNode3.Name = "OrdersManageNode";
            treeNode3.Text = "订单管理";
            this.MenuTV.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.MenuTV.Size = new System.Drawing.Size(192, 561);
            this.MenuTV.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.libraryDataSetBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(192, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(692, 561);
            this.dataGridView1.TabIndex = 2;
            // 
            // libraryDataSet
            // 
            this.libraryDataSet.DataSetName = "libraryDataSet";
            this.libraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // libraryDataSetBindingSource
            // 
            this.libraryDataSetBindingSource.DataSource = this.libraryDataSet;
            this.libraryDataSetBindingSource.Position = 0;
            // 
            // ManageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MenuTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManageWindow";
            this.Text = "管理";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView MenuTV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource libraryDataSetBindingSource;
        private libraryDataSet libraryDataSet;
    }
}