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
    public partial class StockInsert : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        public StockInsert()
        {
            InitializeComponent();
        }

        private void ItemsInsert_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_dd();
            fill_dg();
        }

        public void fill_dd()
        {
            cmbUnit.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Unit";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                cmbUnit.Items.Add(dr["Unit"].ToString());
            }

        }

        public void fill_dg()
        { 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Stock__Table";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
             

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT into Stock__Table values('" + txtProductName.Text + "' , '" + txtProductPrice.Text + "' , '" + txtQuantities.Text + "', '" + cmbUnit.SelectedItem.ToString() + "')";
            //cmd.CommandText = "INSERT into Stock_Table1 values('" + txtProductName.Text + "' , '" + txtProductPrice.Text.ToString() + "' , '" + txtQuantities.Text.ToString() + "', '" + cmbUnit.SelectedItem.ToString() + "')";
            cmd.ExecuteNonQuery();

            txtProductName.Clear();
            txtProductPrice.Clear();
            txtQuantities.Clear();
            cmbUnit.Text = "";
            
            fill_dg();
            MessageBox.Show("Inserted");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        } 

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            cmbUnit1.Items.Clear(); 
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * from Unit";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                cmbUnit1.Items.Add(dr2["Unit"].ToString());
            }


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Stock__Table where ProductID = " + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows) 
            {
                txtProductName1.Text = dr["Product_Name"].ToString();
                txtProductPrice1.Text = dr["Product_Price"].ToString();
                txtQuantities1.Text = dr["Product_Quantity"].ToString();
                cmbUnit1.SelectedItem = dr["Product_Unit"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Stock__Table SET Product_Name = '"+txtProductName1.Text+"' , Product_Price  = '"+txtProductPrice1.Text+"' , Product_Quantity = '"+txtQuantities1.Text+"' , Product_Unit =  '"+cmbUnit1.SelectedItem.ToString()+"' WHERE ProductID = "+i+" ";
            cmd.ExecuteNonQuery();
             
            fill_dg();  
        }
    }
}
