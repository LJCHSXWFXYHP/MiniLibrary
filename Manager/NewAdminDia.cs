using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Manager
{
    public partial class NewAdminDia : Form
    {
        public NewAdminDia()
        {
            InitializeComponent();
        }

        private void PhoneNumHint(object sender, EventArgs e)
        {
            var rg = new Regex("^[0-9]+$");
            if (!rg.IsMatch(PhoneNumBox.Text))
            {
                PhoneHintLbl.Visible = true;
                //必须是数字
            }
            else
            {
                if (PhoneNumBox.Text.Length != 11)
                {
                    PhoneHintLbl.Visible = true;
                }
                else
                {
                    PhoneHintLbl.Visible = false;
                }
            }
        }

        private void UserIdHint(object sender, EventArgs e)
        {
            if (NameBox.Text.Length == 0)
            {
                UserIdHintLbl.Visible = true;
            }
            else
            {
                UserIdHintLbl.Visible = false;
            }
        }

        private void PswdHint(object sender, EventArgs e)
        {
            if (PswdBox.Text.Length > 16 || PswdBox.Text.Length == 0)
            {
                PswdHintLbl.Visible = true;
            }
            else
            {
                PswdHintLbl.Visible = false;
            }
        }

        private void ConfPswdHint(object sender, EventArgs e)
        {
            if (PswdBox.Text != ConfPswdBox.Text)
            {
                ConfPswdHintLbl.Visible = true;
            }
            else
            {
                ConfPswdHintLbl.Visible = false;
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            var canSubmit = true;
            var rg = new Regex("^[0-9]+$");
            if (!rg.IsMatch(PhoneNumBox.Text))
            {
                PhoneHintLbl.Visible = true;
                canSubmit = false;
                //必须是数字
            }
            else
            {
                if (PhoneNumBox.Text.Length != 11)
                {
                    PhoneHintLbl.Visible = true;
                    canSubmit = false;
                }
                else
                {
                    PhoneHintLbl.Visible = false;
                }
            }
            if (NameBox.Text.Length == 0)
            {
                UserIdHintLbl.Visible = true;
                return;
            }
            UserIdHintLbl.Visible = false;
            if (PswdBox.Text.Length > 16 || PswdBox.Text.Length == 0)
            {
                PswdHintLbl.Visible = true;
                return;
            }
            PswdHintLbl.Visible = false;
            if (PswdBox.Text != ConfPswdBox.Text)
            {
                ConfPswdHintLbl.Visible = true;
                return;
            }
            ConfPswdHintLbl.Visible = false;

            if (canSubmit)
            {
                try
                {
                    var connStr = new MySqlConnectionStringBuilder("")
                    {
                        Port = 3306,
                        Server = "115.159.145.115",
                        UserID = "library",
                        Password = "library",
                        Database = "MiniLibrary"
                    };
                    var dbConn = new MySqlConnection(connStr.ConnectionString);
                    dbConn.Open();
                    var sql =
                        "INSERT INTO `MiniLibrary`.`UserInformation` (`PhoneNum`, `Type`, `Name`, `Password`) VALUES ('" +
                        PhoneNumBox.Text + "', '" + AdminLevel.Value + "', '" + NameBox.Text + "', '" + ConfPswdBox.Text +
                        "');";
                    var mySqlCommand = new MySqlCommand(sql, dbConn);
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("管理员用户添加成功！");
                    dbConn.Close();
                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据库错误： " + ex.Message);
                    Dispose();
                }
            }
        }
    }
}