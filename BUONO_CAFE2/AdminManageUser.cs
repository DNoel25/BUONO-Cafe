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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_User a = new Add_User("Update");
            a.Show();
        }

        private void AdminManageUser_Load(object sender, EventArgs e)
        {

        }
    }
}
