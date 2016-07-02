using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Manager
{
    public partial class NewBookDia : Form
    {
        public NewBookDia()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (BookNameBox.Text.Length == 0)
            {
                MessageBox.Show("请输入书名");
                return;
            }
            if (BookIdBox.Text.Length == 0)
            {
                MessageBox.Show("请输入图书编号");
                return;
            }
            if (CatalogBox.Text.Length == 0)
            {
                MessageBox.Show("请输入图书简介");
                return;
            }
            if (CateBox.Text.Length == 0)
            {
                MessageBox.Show("请输入图书分类");
                return;
            }
            if (PriceBox.Text.Length == 0)
            {
                MessageBox.Show("请输入单价");
                return;
            }
            if (MountBox.Text.Length == 0)
            {
                MessageBox.Show("请输入库存数量");
                return;
            }
            try
            {
                var connStr = new MySqlConnectionStringBuilder("")
                {
                    Port = 3306,
                    Server = "115.159.145.115",
                    UserID = "library",
                    Password = "library",
                    Database = "MiniLibrary",
                    CharacterSet = "utf8"
                };
                var dbConn = new MySqlConnection(connStr.ConnectionString);
                dbConn.Open();

                //string sql3 = "SET NAMES UTF8";
                //MySqlCommand mySqlCommand3 = new MySqlCommand(sql3, DBConn);
                //mySqlCommand3.ExecuteNonQuery();

                var sql =
                    "INSERT INTO `MiniLibrary`.`BookClass` (`BookClassId`, `BookName`, `BookAuthor`, `BookPress`, `BookPrice`, `BookSummary`, `BookCatalog`, `BookClassification`, `ImageUrl`) VALUES ('" +
                    BookIdBox.Text + "', '" + BookNameBox.Text + "', '" + EditorBox.Text + "', '" + PublisherBox.Text +
                    "', '" + PriceBox.Text + "', '" + IntroBox.Text + "', '" + CatalogBox.Text + "', '" + CateBox.Text +
                    "', '" + PictureBox.Text + "');";
                var mySqlCommand = new MySqlCommand(sql, dbConn);
                mySqlCommand.ExecuteNonQuery();

                for (var i = 0; i < int.Parse(MountBox.Text); i++)
                {
                    var sql2 =
                        "INSERT INTO `MiniLibrary`.`Book` (`BookClassId`) VALUES ('" +
                        BookIdBox.Text + "');";
                    var mySqlCommand2 = new MySqlCommand(sql2, dbConn);
                    mySqlCommand2.ExecuteNonQuery();
                }

                MessageBox.Show("新增图书添加成功！");
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