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

namespace BUONO_CAFE2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from login where username ='"+txtUserName.Text+"' and password ='"+txtPassword.Text+"'",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string cmbItemValue = comboBox1.SelectedItem.ToString();
            
            if(dt.Rows.Count > 0)
            {
                for(int i=0 ; i < dt.Rows.Count ; i++)
                {
                    if(dt.Rows[i]["usertype"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("You are LogedIn as " + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex  == 0)
                        {
                            AdminManageUser admin = new AdminManageUser();
                            admin.Show();
                            this.Hide();
                        }
                        else 
                        {
                            ManagerFront mf = new ManagerFront();
                            mf.Show();
                            this.Hide();

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR...!!!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
