using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Manager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //FormClosing+=
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void UserNameBox_Leave(object sender, EventArgs e)
        {
            IdErrorLbl.Visible = UserNameBox.Text == "";
        }

        private void PswdBox_Leave(object sender, EventArgs e)
        {
            PswdErrorLbl.Visible = PswdBox.Text == "";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var flag = false;
            if (UserNameBox.Text == "")
            {
                IdErrorLbl.Visible = true;
                flag = true;
            }
            if (PswdBox.Text == "")
            {
                PswdErrorLbl.Visible = true;
                flag = true;
            }

            if (!flag)
            {
                LoginVerify();
            }
        }

        private void LoginVerify()
        {
            var connStr = new MySqlConnectionStringBuilder("");
            connStr.Port = 3306;
            connStr.Server = "115.159.145.115";
            connStr.UserID = "library";
            connStr.Password = "library";
            connStr.Database = "MiniLibrary";
            var dbConn = new MySqlConnection(connStr.ConnectionString);
            try
            {
                dbConn.Open();
                var sql = "select PhoneNum,Password,Type,Name from UserInformation";
                var mySqlCommand = new MySqlCommand(sql, dbConn);
                var reader = mySqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (reader.GetString(0) == UserNameBox.Text)
                        {
                            if (reader.GetString(1) != PswdBox.Text)
                            {
                                MessageBox.Show("密码错误！");
                                return;
                            }
                            if (reader.GetInt16(2) != 3)
                            {
                                MessageBox.Show("该用户无管理员权限！");
                                return;
                            }
                            MessageBox.Show("登陆成功!");
                            var MW = new ManageWindow(reader.GetString(3));
                            MW.Show();
                            Hide();
                            return;
                        }
                    }
                }
                MessageBox.Show("用户不存在");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败： " + ex.Message);
            }
            dbConn.Close();
        }
    }
}