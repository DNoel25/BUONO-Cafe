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
    public partial class Dealer_Info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        public Dealer_Info()
        {
            InitializeComponent();
        }

        private void Dealer_Info_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            dg();
        }

        public void dg()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Dealer_Info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnAddDealer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT into Dealer_Info values('"+txtDealerName.Text+ "' , '" + txtCompanyName.Text + "' , '" + txtContact.Text + "' , '" + txtAddress.Text + "' , '" + txtCity.Text + "')" ;
            cmd.ExecuteNonQuery();

            txtDealerName.Clear();
            txtCompanyName.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtCity.Clear();

            dg();

            MessageBox.Show("Revord Added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE from Dealer_Info WHERE id = "+id+"";
            cmd.ExecuteNonQuery();

            dg();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Dealer_Info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                txtDealerName1.Text = dr["Dealer_Name"].ToString();
                txtCompanyName1.Text = dr["Dealer_Company_Name"].ToString();
                txtContact1.Text = dr["Contact"].ToString();
                txtAddress1.Text = dr["Address"].ToString();
                txtCity1.Text = dr["City"].ToString();
            }

        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Dealer_Info SET Dealer_Name = '"+txtDealerName1.Text+"' , Dealer_Company_Name = '"+txtCompanyName1.Text+"' , Contact = '"+txtContact1.Text+"' ,  Address = '"+txtAddress1.Text+"', City = '"+txtCity1.Text+"' WHERE  id = "+id+" ";

            cmd.ExecuteNonQuery();
            panel2.Visible = false;
            dg();
        }
    }
}
