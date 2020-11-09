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
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Project_management_system;
namespace BUONO_CAFE2
{
    public partial class Login : Form
    {
       // internal MDIParent1 MDIParent1;
        ConnectionString cs = new ConnectionString();
        SqlConnection con = null;
        //  private int childFormNumber = 0;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        public Login()
        { 
            InitializeComponent(); 
        }
         

        private void Login_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs.ConDB);

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT User_Name,User_Password,User_Type FROM Users_Table WHERE User_Type=@User_Type AND User_Name = @User_Name AND User_Password = @User_Password", myConnection);
                SqlParameter uName = new SqlParameter("@User_Name", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@User_Password", SqlDbType.VarChar);
                SqlParameter Userleavel = new SqlParameter("@User_Type", SqlDbType.VarChar);

                uName.Value = txtUserName.Text;
                uPassword.Value = txtPassword.Text;
                Userleavel.Value = comboBox1.Text;

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);
                myCommand.Parameters.Add(Userleavel);

                  
                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

              
                if (myReader.Read() == true)
                {
                    int i;
                    progressBar1.Visible = true;
                    progressBar1.Maximum = 5000;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 4;
                    progressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                 //       ProgressBar1.PerformStep();
                    }
                    this.Hide();
                   

                    MDIParent1 frm = new MDIParent1();
                    SetValueForText1 = txtUserName.Text;
                    SetValueForText2 = comboBox1.Text;
                    frm.Show();

                    //frm.lbl.Text = txtUserName.Text;
                    //  frm.statusStrip.Text = txtUserName.Text;

                    //  frm.toolStripStatusLabel1.Text = txtUserName.Text;
                   

                    st1 = txtUserName.Text;
                    st2 = "Successfully logged in";
                    cf.LogFunc(st1, System.DateTime.Now, st2);

                }


                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }



            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void btnClear_Click(object sender, EventArgs e)
        {



        }

    }
}
