using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Manager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            bool flag = false;
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

        private bool LoginVerify()
        {
            MySqlConnection DBConn;
            MySqlConnectionStringBuilder ConnStr = new MySqlConnectionStringBuilder("");
            ConnStr.Port = 3306;
            ConnStr.Server = "115.159.145.115";
            ConnStr.UserID = "library";
            ConnStr.Password = "library";
            ConnStr.Database = "MiniLibrary";
            DBConn = new MySqlConnection(ConnStr.ConnectionString);
            try
            {
                DBConn.Open();
                string sql = "select PhoneNum,Password,Type,Name from UserInformation";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, DBConn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (reader.GetString(0) == UserNameBox.Text)
                        {
                            if (reader.GetString(1) != PswdBox.Text)
                            {
                                MessageBox.Show("密码错误！");
                                return false;
                            }else if (reader.GetInt16(2) != 3)
                            {
                                MessageBox.Show("该用户无管理员权限！");
                                return false;
                            }
                            else
                            {
                                MessageBox.Show("登陆成功!");
                                ManageWindow MW = new ManageWindow(reader.GetString(3));
                                MW.Show();
                                Hide();
                                return true;
                            }
                        }
                    }
                }
                MessageBox.Show("用户不存在");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败： "+ex.Message);
            }
            DBConn.Close();
            return false;
        }
    }
}
