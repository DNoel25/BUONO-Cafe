﻿using System;
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
    public partial class SearchUser : Form
    {
        public SearchUser()
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

        private void btnsearch2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select User_Name from Users_Table where User_Name = '"+txtName.Text+"'",con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Employee Name is not exists!!!!!!!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from Users_Table where User_Name = @User_Name",con);
                    cmd.Parameters.AddWithValue("@User_Name",txtName.Text);

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

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT User_NIC from Users_Table where User_NIC = '" + txtNIC.Text+"'",con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Employee is not exist...!!!!!!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from Users_Table where User_NIC  = @User_NIC", con);
                    cmd.Parameters.AddWithValue("@User_NIC", txtNIC.Text);

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
