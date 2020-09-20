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
using System.Net.Mail;

namespace BUONO_CAFE2
{
    public partial class Add_User : Form
    {
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        public Add_User(string s )
        {
            
            InitializeComponent();
            if (s == "Add")
                btnUpdateUser.Visible = false;
            else
                btnAddUser.Visible = false;

        }

        string UserType;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //bool email = IsEmailValid(txtEmail.Text); 

            //if (email == false)
            //{
            //MessageBox.Show("Please Enter valid Email Address");
            //}

            if (txtUser_id.Text == " " || txtName.Text == " " || txtPassword.Text == " " || txtEmail.Text == " " || txtNIC.Text == " "
                || txtTNo.Text == " ")
            {
                MessageBox.Show("Please fill the Fields");
            }
            else if(!(txtTNo.Text.Length == 10))
            {
                MessageBox.Show("Please enter 10 digits number");
            }
            else if(!rdoAdmin.Checked && !rdoManager.Checked && !rdoCashier.Checked)
            {
                MessageBox.Show("Please select a User Type!!");
            }
            else{
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select User_id from Users_Table where User_id = '"+txtUser_id.Text +"'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Employee ID is already exist!!");
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into Users_Table values(@User_id , @User_Name,@User_Password,@User_type,@user_Email,@User_NIC,@User_TNo)",con);
                        cmd.Parameters.AddWithValue("@User_id",txtUser_id.Text);
                        cmd.Parameters.AddWithValue("@User_Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@User_Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@User_Type", UserType );
                        cmd.Parameters.AddWithValue("@User_Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@User_NIC", txtNIC.Text);
                        cmd.Parameters.AddWithValue("@User_TNo", txtTNo.Text);

                        int result = cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("New Employee added to the System","Saved" , MessageBoxButtons.OK);

                        ResetFormControls();
                    }
                }
            }
        }

        private void ResetFormControls()
        {
            txtUser_id.Clear();
            txtName.Clear();
            txtPassword.Clear();
            UserType = "";
            txtEmail.Clear();
            txtNIC.Clear();
            txtTNo.Clear();
        }

        private bool IsEmailValid(string m)
        {
            try
            {
                MailAddress ma = new MailAddress(m);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter a valid emailID");
                return false;
            }
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
            txtEmail.Clear();
            txtNIC.Clear();
            txtTNo.Clear();

            rdoAdmin.Checked = false;
            rdoManager.Checked = false;
            rdoCashier.Checked = false;
            


        }

        private void rdoAdmin_CheckedChanged(object sender, EventArgs e)
        {
            UserType = "Admin";
        }

        private void rdoManager_CheckedChanged(object sender, EventArgs e)
        {
            UserType = "Manager";
        }

        private void rdoCashier_CheckedChanged(object sender, EventArgs e)
        {
            UserType = "Cashier";
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
             
        }
    }
}
