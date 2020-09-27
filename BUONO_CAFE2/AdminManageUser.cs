using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUONO_CAFE2
{
    public partial class AdminManageUser : Form
    {
        public AdminManageUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_User a = new Add_User("Add");
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_User a = new Add_User("Update");
            a.Show();
            this.Hide();
        }

        private void AdminManageUser_Load(object sender, EventArgs e)
        {

        }

        private void btnSeachUser_Click(object sender, EventArgs e)
        {
            SearchAndDeleteUser s = new SearchAndDeleteUser();
            s.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
