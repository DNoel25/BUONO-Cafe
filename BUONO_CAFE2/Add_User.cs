using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BUONO_CAFE2
{
    public partial class Add_User : Form
    {
        public Add_User(string s )
        {
            
            InitializeComponent();
            if (s == "Add")
                btnUpdateUser.Visible = false;
            else
                btnAddUser.Visible = false;

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminManageUser back = new AdminManageUser();
            back.Show();
            Visible = false;
        }

        private void Add_User_Load(object sender, EventArgs e)
        {

        }

        private void btnFormClear_Click(object sender, EventArgs e)
        {
            txtUser_id.Clear();
            txtName.Clear();
            txtPassword.Clear();
            txtType.Clear();
            txtEmail.Clear();
            txtNIC.Clear();
            txtTNo.Clear();
            


        }
    }
}
