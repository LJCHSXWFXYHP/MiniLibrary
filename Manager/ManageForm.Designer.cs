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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.ManageRecordBtn = new System.Windows.Forms.Button();
            this.ManageBooksBtn = new System.Windows.Forms.Button();
            this.ManageUserBtn = new System.Windows.Forms.Button();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.UserManageTab = new System.Windows.Forms.TabPage();
            this.NewAdminBtn = new System.Windows.Forms.Button();
            this.UserGridView = new System.Windows.Forms.DataGridView();
            this.phoneNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userDataSet = new Manager.MiniLibraryDataSet1();
            this.BookManageTab = new System.Windows.Forms.TabPage();
            this.NewBookBtn = new System.Windows.Forms.Button();
            this.BooksGridView = new System.Windows.Forms.DataGridView();
            this.bookClassIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookAuthorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookPressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookSummaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookCatalogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookClassificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BooksDataSet = new Manager.MiniLibraryDataSet();
            this.RecordManageTab = new System.Windows.Forms.TabPage();
            this.RecordGridView = new System.Windows.Forms.DataGridView();
            this.bookIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnFlagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ifRenewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowRecodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recordDataSet = new Manager.RecordDataSet();
            this.bookClassTableAdapter = new Manager.MiniLibraryDataSetTableAdapters.BookClassTableAdapter();
            this.borrowRecodeTableAdapter = new Manager.RecordDataSetTableAdapters.BorrowRecodeTableAdapter();
            this.userInformationTableAdapter = new Manager.MiniLibraryDataSet1TableAdapters.UserInformationTableAdapter();
            this.TabControl.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.UserManageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).BeginInit();
            this.BookManageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksDataSet)).BeginInit();
            this.RecordManageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowRecodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.MainTab);
            this.TabControl.Controls.Add(this.UserManageTab);
            this.TabControl.Controls.Add(this.BookManageTab);
            this.TabControl.Controls.Add(this.RecordManageTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 561);
            this.TabControl.TabIndex = 2;
            // 
            // MainTab
            // 
            this.MainTab.BackgroundImage = global::Manager.Properties.Resources.bck;
            this.MainTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainTab.Controls.Add(this.ManageRecordBtn);
            this.MainTab.Controls.Add(this.ManageBooksBtn);
            this.MainTab.Controls.Add(this.ManageUserBtn);
            this.MainTab.Controls.Add(this.UserNameLbl);
            this.MainTab.Controls.Add(this.TitleLbl);
            this.MainTab.Location = new System.Drawing.Point(4, 26);
            this.MainTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainTab.Size = new System.Drawing.Size(776, 531);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "主页";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // ManageRecordBtn
            // 
            this.ManageRecordBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ManageRecordBtn.Location = new System.Drawing.Point(565, 382);
            this.ManageRecordBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ManageRecordBtn.Name = "ManageRecordBtn";
            this.ManageRecordBtn.Size = new System.Drawing.Size(117, 57);
            this.ManageRecordBtn.TabIndex = 4;
            this.ManageRecordBtn.Text = "记录管理";
            this.ManageRecordBtn.UseVisualStyleBackColor = true;
            this.ManageRecordBtn.Click += new System.EventHandler(this.ManageRecordBtn_Click);
            // 
            // ManageBooksBtn
            // 
            this.ManageBooksBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ManageBooksBtn.Location = new System.Drawing.Point(340, 382);
            this.ManageBooksBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ManageBooksBtn.Name = "ManageBooksBtn";
            this.ManageBooksBtn.Size = new System.Drawing.Size(117, 57);
            this.ManageBooksBtn.TabIndex = 3;
            this.ManageBooksBtn.Text = "图书管理";
            this.ManageBooksBtn.UseVisualStyleBackColor = true;
            this.ManageBooksBtn.Click += new System.EventHandler(this.ManageBooksBtn_Click);
            // 
            // ManageUserBtn
            // 
            this.ManageUserBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ManageUserBtn.Location = new System.Drawing.Point(110, 382);
            this.ManageUserBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ManageUserBtn.Name = "ManageUserBtn";
            this.ManageUserBtn.Size = new System.Drawing.Size(117, 57);
            this.ManageUserBtn.TabIndex = 2;
            this.ManageUserBtn.Text = "用户管理";
            this.ManageUserBtn.UseVisualStyleBackColor = true;
            this.ManageUserBtn.Click += new System.EventHandler(this.ManageUserBtn_Click);
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserNameLbl.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLbl.ForeColor = System.Drawing.Color.Chartreuse;
            this.UserNameLbl.Location = new System.Drawing.Point(3, 134);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(770, 54);
            this.UserNameLbl.TabIndex = 1;
            this.UserNameLbl.Text = "当前用户： Admin";
            this.UserNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLbl.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TitleLbl.Location = new System.Drawing.Point(3, 4);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(770, 130);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Mini Library 管理系统";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserManageTab
            // 
            this.UserManageTab.Controls.Add(this.NewAdminBtn);
            this.UserManageTab.Controls.Add(this.UserGridView);
            this.UserManageTab.Location = new System.Drawing.Point(4, 26);
            this.UserManageTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserManageTab.Name = "UserManageTab";
            this.UserManageTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserManageTab.Size = new System.Drawing.Size(776, 531);
            this.UserManageTab.TabIndex = 1;
            this.UserManageTab.Text = "用户管理";
            this.UserManageTab.UseVisualStyleBackColor = true;
            // 
            // NewAdminBtn
            // 
            this.NewAdminBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewAdminBtn.Location = new System.Drawing.Point(311, 417);
            this.NewAdminBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewAdminBtn.Name = "NewAdminBtn";
            this.NewAdminBtn.Size = new System.Drawing.Size(117, 57);
            this.NewAdminBtn.TabIndex = 3;
            this.NewAdminBtn.Text = "新建管理员";
            this.NewAdminBtn.UseVisualStyleBackColor = true;
            this.NewAdminBtn.Click += new System.EventHandler(this.NewAdminBtn_Click);
            // 
            // UserGridView
            // 
            this.UserGridView.AllowUserToAddRows = false;
            this.UserGridView.AutoGenerateColumns = false;
            this.UserGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.UserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phoneNumDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.idCardDataGridViewTextBoxColumn});
            this.UserGridView.DataSource = this.userInformationBindingSource;
            this.UserGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserGridView.Location = new System.Drawing.Point(3, 4);
            this.UserGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserGridView.MultiSelect = false;
            this.UserGridView.Name = "UserGridView";
            this.UserGridView.ReadOnly = true;
            this.UserGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.UserGridView.RowTemplate.Height = 23;
            this.UserGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserGridView.Size = new System.Drawing.Size(770, 350);
            this.UserGridView.TabIndex = 0;
            this.UserGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.UserGridView_RowsRemoved);
            // 
            // phoneNumDataGridViewTextBoxColumn
            // 
            this.phoneNumDataGridViewTextBoxColumn.DataPropertyName = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn.HeaderText = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn.Name = "phoneNumDataGridViewTextBoxColumn";
            this.phoneNumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCardDataGridViewTextBoxColumn
            // 
            this.idCardDataGridViewTextBoxColumn.DataPropertyName = "IdCard";
            this.idCardDataGridViewTextBoxColumn.HeaderText = "IdCard";
            this.idCardDataGridViewTextBoxColumn.Name = "idCardDataGridViewTextBoxColumn";
            this.idCardDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userInformationBindingSource
            // 
            this.userInformationBindingSource.DataMember = "UserInformation";
            this.userInformationBindingSource.DataSource = this.userDataSet;
            // 
            // userDataSet
            // 
            this.userDataSet.DataSetName = "MiniLibraryDataSet1";
            this.userDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BookManageTab
            // 
            this.BookManageTab.Controls.Add(this.NewBookBtn);
            this.BookManageTab.Controls.Add(this.BooksGridView);
            this.BookManageTab.Location = new System.Drawing.Point(4, 26);
            this.BookManageTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookManageTab.Name = "BookManageTab";
            this.BookManageTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BookManageTab.Size = new System.Drawing.Size(776, 531);
            this.BookManageTab.TabIndex = 2;
            this.BookManageTab.Text = "图书管理";
            this.BookManageTab.UseVisualStyleBackColor = true;
            // 
            // NewBookBtn
            // 
            this.NewBookBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewBookBtn.Location = new System.Drawing.Point(311, 418);
            this.NewBookBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewBookBtn.Name = "NewBookBtn";
            this.NewBookBtn.Size = new System.Drawing.Size(117, 57);
            this.NewBookBtn.TabIndex = 5;
            this.NewBookBtn.Text = "新增图书";
            this.NewBookBtn.UseVisualStyleBackColor = true;
            this.NewBookBtn.Click += new System.EventHandler(this.NewBookBtn_Click);
            // 
            // BooksGridView
            // 
            this.BooksGridView.AllowUserToAddRows = false;
            this.BooksGridView.AutoGenerateColumns = false;
            this.BooksGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.BooksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BooksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookClassIdDataGridViewTextBoxColumn,
            this.bookNameDataGridViewTextBoxColumn,
            this.bookAuthorDataGridViewTextBoxColumn,
            this.bookPressDataGridViewTextBoxColumn,
            this.bookPriceDataGridViewTextBoxColumn,
            this.bookSummaryDataGridViewTextBoxColumn,
            this.bookCatalogDataGridViewTextBoxColumn,
            this.bookClassificationDataGridViewTextBoxColumn,
            this.imageUrlDataGridViewTextBoxColumn});
            this.BooksGridView.DataSource = this.bookClassBindingSource;
            this.BooksGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.BooksGridView.Location = new System.Drawing.Point(3, 4);
            this.BooksGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BooksGridView.MultiSelect = false;
            this.BooksGridView.Name = "BooksGridView";
            this.BooksGridView.ReadOnly = true;
            this.BooksGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.BooksGridView.RowTemplate.Height = 23;
            this.BooksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BooksGridView.Size = new System.Drawing.Size(770, 350);
            this.BooksGridView.TabIndex = 1;
            this.BooksGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BooksGridView_RowsRemoved);
            // 
            // bookClassIdDataGridViewTextBoxColumn
            // 
            this.bookClassIdDataGridViewTextBoxColumn.DataPropertyName = "BookClassId";
            this.bookClassIdDataGridViewTextBoxColumn.HeaderText = "BookClassId";
            this.bookClassIdDataGridViewTextBoxColumn.Name = "bookClassIdDataGridViewTextBoxColumn";
            this.bookClassIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookNameDataGridViewTextBoxColumn
            // 
            this.bookNameDataGridViewTextBoxColumn.DataPropertyName = "BookName";
            this.bookNameDataGridViewTextBoxColumn.HeaderText = "BookName";
            this.bookNameDataGridViewTextBoxColumn.Name = "bookNameDataGridViewTextBoxColumn";
            this.bookNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookAuthorDataGridViewTextBoxColumn
            // 
            this.bookAuthorDataGridViewTextBoxColumn.DataPropertyName = "BookAuthor";
            this.bookAuthorDataGridViewTextBoxColumn.HeaderText = "BookAuthor";
            this.bookAuthorDataGridViewTextBoxColumn.Name = "bookAuthorDataGridViewTextBoxColumn";
            this.bookAuthorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookPressDataGridViewTextBoxColumn
            // 
            this.bookPressDataGridViewTextBoxColumn.DataPropertyName = "BookPress";
            this.bookPressDataGridViewTextBoxColumn.HeaderText = "BookPress";
            this.bookPressDataGridViewTextBoxColumn.Name = "bookPressDataGridViewTextBoxColumn";
            this.bookPressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookPriceDataGridViewTextBoxColumn
            // 
            this.bookPriceDataGridViewTextBoxColumn.DataPropertyName = "BookPrice";
            this.bookPriceDataGridViewTextBoxColumn.HeaderText = "BookPrice";
            this.bookPriceDataGridViewTextBoxColumn.Name = "bookPriceDataGridViewTextBoxColumn";
            this.bookPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookSummaryDataGridViewTextBoxColumn
            // 
            this.bookSummaryDataGridViewTextBoxColumn.DataPropertyName = "BookSummary";
            this.bookSummaryDataGridViewTextBoxColumn.HeaderText = "BookSummary";
            this.bookSummaryDataGridViewTextBoxColumn.Name = "bookSummaryDataGridViewTextBoxColumn";
            this.bookSummaryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookCatalogDataGridViewTextBoxColumn
            // 
            this.bookCatalogDataGridViewTextBoxColumn.DataPropertyName = "BookCatalog";
            this.bookCatalogDataGridViewTextBoxColumn.HeaderText = "BookCatalog";
            this.bookCatalogDataGridViewTextBoxColumn.Name = "bookCatalogDataGridViewTextBoxColumn";
            this.bookCatalogDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookClassificationDataGridViewTextBoxColumn
            // 
            this.bookClassificationDataGridViewTextBoxColumn.DataPropertyName = "BookClassification";
            this.bookClassificationDataGridViewTextBoxColumn.HeaderText = "BookClassification";
            this.bookClassificationDataGridViewTextBoxColumn.Name = "bookClassificationDataGridViewTextBoxColumn";
            this.bookClassificationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imageUrlDataGridViewTextBoxColumn
            // 
            this.imageUrlDataGridViewTextBoxColumn.DataPropertyName = "ImageUrl";
            this.imageUrlDataGridViewTextBoxColumn.HeaderText = "ImageUrl";
            this.imageUrlDataGridViewTextBoxColumn.Name = "imageUrlDataGridViewTextBoxColumn";
            this.imageUrlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookClassBindingSource
            // 
            this.bookClassBindingSource.DataMember = "BookClass";
            this.bookClassBindingSource.DataSource = this.BooksDataSet;
            // 
            // BooksDataSet
            // 
            this.BooksDataSet.DataSetName = "MiniLibraryDataSet";
            this.BooksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RecordManageTab
            // 
            this.RecordManageTab.Controls.Add(this.RecordGridView);
            this.RecordManageTab.Location = new System.Drawing.Point(4, 26);
            this.RecordManageTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RecordManageTab.Name = "RecordManageTab";
            this.RecordManageTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RecordManageTab.Size = new System.Drawing.Size(776, 531);
            this.RecordManageTab.TabIndex = 3;
            this.RecordManageTab.Text = "记录管理";
            this.RecordManageTab.UseVisualStyleBackColor = true;
            // 
            // RecordGridView
            // 
            this.RecordGridView.AllowUserToAddRows = false;
            this.RecordGridView.AutoGenerateColumns = false;
            this.RecordGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.RecordGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookIdDataGridViewTextBoxColumn,
            this.borrowDateDataGridViewTextBoxColumn,
            this.returnFlagDataGridViewTextBoxColumn,
            this.phoneNumDataGridViewTextBoxColumn1,
            this.ifRenewDataGridViewTextBoxColumn});
            this.RecordGridView.DataSource = this.borrowRecodeBindingSource;
            this.RecordGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordGridView.Location = new System.Drawing.Point(3, 4);
            this.RecordGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RecordGridView.MultiSelect = false;
            this.RecordGridView.Name = "RecordGridView";
            this.RecordGridView.ReadOnly = true;
            this.RecordGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.RecordGridView.RowTemplate.Height = 23;
            this.RecordGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecordGridView.Size = new System.Drawing.Size(770, 523);
            this.RecordGridView.TabIndex = 2;
            this.RecordGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.RecordGridView_RowsRemoved);
            // 
            // bookIdDataGridViewTextBoxColumn
            // 
            this.bookIdDataGridViewTextBoxColumn.DataPropertyName = "BookId";
            this.bookIdDataGridViewTextBoxColumn.HeaderText = "BookId";
            this.bookIdDataGridViewTextBoxColumn.Name = "bookIdDataGridViewTextBoxColumn";
            this.bookIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // borrowDateDataGridViewTextBoxColumn
            // 
            this.borrowDateDataGridViewTextBoxColumn.DataPropertyName = "BorrowDate";
            this.borrowDateDataGridViewTextBoxColumn.HeaderText = "BorrowDate";
            this.borrowDateDataGridViewTextBoxColumn.Name = "borrowDateDataGridViewTextBoxColumn";
            this.borrowDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // returnFlagDataGridViewTextBoxColumn
            // 
            this.returnFlagDataGridViewTextBoxColumn.DataPropertyName = "ReturnFlag";
            this.returnFlagDataGridViewTextBoxColumn.HeaderText = "ReturnFlag";
            this.returnFlagDataGridViewTextBoxColumn.Name = "returnFlagDataGridViewTextBoxColumn";
            this.returnFlagDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneNumDataGridViewTextBoxColumn1
            // 
            this.phoneNumDataGridViewTextBoxColumn1.DataPropertyName = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn1.HeaderText = "PhoneNum";
            this.phoneNumDataGridViewTextBoxColumn1.Name = "phoneNumDataGridViewTextBoxColumn1";
            this.phoneNumDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ifRenewDataGridViewTextBoxColumn
            // 
            this.ifRenewDataGridViewTextBoxColumn.DataPropertyName = "IfRenew";
            this.ifRenewDataGridViewTextBoxColumn.HeaderText = "IfRenew";
            this.ifRenewDataGridViewTextBoxColumn.Name = "ifRenewDataGridViewTextBoxColumn";
            this.ifRenewDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // borrowRecodeBindingSource
            // 
            this.borrowRecodeBindingSource.DataMember = "BorrowRecode";
            this.borrowRecodeBindingSource.DataSource = this.recordDataSet;
            // 
            // recordDataSet
            // 
            this.recordDataSet.DataSetName = "RecordDataSet";
            this.recordDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookClassTableAdapter
            // 
            this.bookClassTableAdapter.ClearBeforeFill = true;
            // 
            // borrowRecodeTableAdapter
            // 
            this.borrowRecodeTableAdapter.ClearBeforeFill = true;
            // 
            // userInformationTableAdapter
            // 
            this.userInformationTableAdapter.ClearBeforeFill = true;
            // 
            // ManageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ManageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.TabControl.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.UserManageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).EndInit();
            this.BookManageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BooksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksDataSet)).EndInit();
            this.RecordManageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecordGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowRecodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.TabPage UserManageTab;
        private System.Windows.Forms.TabPage BookManageTab;
        private System.Windows.Forms.TabPage RecordManageTab;
        private System.Windows.Forms.DataGridView UserGridView;
        private System.Windows.Forms.DataGridView BooksGridView;
        private System.Windows.Forms.DataGridView RecordGridView;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Button ManageUserBtn;
        private System.Windows.Forms.Button ManageBooksBtn;
        private System.Windows.Forms.Button ManageRecordBtn;
        private System.Windows.Forms.Button NewAdminBtn;
        private MiniLibraryDataSet BooksDataSet;
        private System.Windows.Forms.BindingSource bookClassBindingSource;
        private MiniLibraryDataSetTableAdapters.BookClassTableAdapter bookClassTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookClassIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookAuthorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookPressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookSummaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookCatalogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookClassificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageUrlDataGridViewTextBoxColumn;
        private RecordDataSet recordDataSet;
        private System.Windows.Forms.BindingSource borrowRecodeBindingSource;
        private RecordDataSetTableAdapters.BorrowRecodeTableAdapter borrowRecodeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnFlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ifRenewDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button NewBookBtn;
        private MiniLibraryDataSet1 userDataSet;
        private System.Windows.Forms.BindingSource userInformationBindingSource;
        private MiniLibraryDataSet1TableAdapters.UserInformationTableAdapter userInformationTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCardDataGridViewTextBoxColumn;
    }
}