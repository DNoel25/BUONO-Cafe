using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BUONO_CAFE2
{
    public partial class SearchAndDeleteUser : Form
    {
        public SearchAndDeleteUser()
        {
            InitializeComponent();
        }
        string connectionString =  @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True" ;

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEId.Text = "";
            txtName.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminManageUser back = new AdminManageUser();
            back.Show();
            Visible = false;
        }

        private void SearchUser_Load(object sender, EventArgs e)
        {

        }
         

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
             


             
        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlDataAdapter da = new SqlDataAdapter("Select User_id from Users_Table where User_id='" + txtEId.Text + "' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Employee ID is not Exists!!");
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("SELECT * from Users_Table Where User_id = @User_id", con);
                    cmd.Parameters.AddWithValue("@User_id", txtEId.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();


                    dt2.Load(sdr);
                    con.Close();

                    EmployeeDataGridView.DataSource = dt2;


                }
            }
        }
    }
}
