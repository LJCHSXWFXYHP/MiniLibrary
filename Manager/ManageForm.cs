using System;
using System.Windows.Forms;

namespace Manager
{
    public partial class ManageWindow : Form
    {
        public ManageWindow()
        {
            InitializeComponent();
            FormClosing += ManageForm__FormClosing;
        }

        public ManageWindow(string userName)
        {
            InitializeComponent();
            UserNameLbl.Text = "当前用户： " + userName;
        }


        private void ManageForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“miniLibraryDataSet1.UserInformation”中。您可以根据需要移动或删除它。
            userInformationTableAdapter.Fill(userDataSet.UserInformation);
            // TODO: 这行代码将数据加载到表“recordDataSet.BorrowRecode”中。您可以根据需要移动或删除它。
            borrowRecodeTableAdapter.Fill(recordDataSet.BorrowRecode);
            // TODO: 这行代码将数据加载到表“miniLibraryDataSet.BookClass”中。您可以根据需要移动或删除它。
            bookClassTableAdapter.Fill(BooksDataSet.BookClass);
            // TODO: 这行代码将数据加载到表“userDataSet.UserInformation”中。您可以根据需要移动或删除它。
            userInformationTableAdapter.Fill(userDataSet.UserInformation);
        }

        private void ManageUserBtn_Click(object sender, EventArgs e)
        {
            TabControl.SelectTab(1);
        }

        private void ManageBooksBtn_Click(object sender, EventArgs e)
        {
            TabControl.SelectTab(2);
        }

        private void ManageRecordBtn_Click(object sender, EventArgs e)
        {
            TabControl.SelectTab(3);
        }

        private void NewAdminBtn_Click(object sender, EventArgs e)
        {
            var nad = new NewAdminDia();
            nad.Disposed += HandleNewAdmin;
            nad.Show();
        }

        private void HandleNewAdmin(object sender, EventArgs e)
        {
            userInformationTableAdapter.Fill(userDataSet.UserInformation);
            UserGridView.Refresh();
        }

        private void NewBookBtn_Click(object sender, EventArgs e)
        {
            var nbd = new NewBookDia();
            nbd.Disposed += HandleNewBook;
            nbd.Show();
        }

        private void HandleNewBook(object sender, EventArgs e)
        {
            bookClassTableAdapter.Fill(BooksDataSet.BookClass);
            BooksGridView.Refresh();
        }

        private static void ManageForm__FormClosing(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            userInformationTableAdapter.Update(userDataSet);
        }

        private void BooksGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bookClassTableAdapter.Update(BooksDataSet);
        }

        private void RecordGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            borrowRecodeTableAdapter.Update(recordDataSet);
        }
    }
}