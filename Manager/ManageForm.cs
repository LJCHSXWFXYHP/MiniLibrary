using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class ManageWindow : Form
    {
        public ManageWindow()
        {
            InitializeComponent();
        }

        public ManageWindow(string userName)
        {
            InitializeComponent();
            UserNameLbl.Text = "当前用户： " + userName;
        }


        private void ManageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
