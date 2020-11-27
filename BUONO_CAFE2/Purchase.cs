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
    public partial class Purchase : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        public Purchase()
        {
            InitializeComponent();
        }



        private void Purchase_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_product_Name();
            fill_Dealer_Name();
        }

        public void fill_product_Name()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Stock__Table ";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbProductName.Items.Add(dr["Product_Name"].ToString());

            }


        }

        public void fill_Dealer_Name()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Dealer_Info ";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbDealerName.Items.Add(dr["Dealer_Name"].ToString());

            }


        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Stock__Table  WHERE Product_Name =  '" + cmbProductName.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lblUnit.Text = dr["Product_Unit"].ToString();

            }
        }

        private void txtProductPrice_Leave(object sender, EventArgs e)
        {
            txtProductTotal.Text = Convert.ToString(Convert.ToInt32(txtProductQuantity.Text) * Convert.ToInt32(txtProductPrice.Text));

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (cmbProductName.Text == " " || txtProductQuantity.Text == "" || txtProductPrice.Text=="" || dateTimePicker1.Text=="" || cmbDealerName.Text == "" ||cmbPurchaseType.Text=="" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Please enter the necessory details");
            }
            else { 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT into Purchase_Stock_Info values('" + cmbDealerName.Text + "','" + txtProductQuantity.Text + "', '" + lblUnit.Text + "','" + txtProductPrice.Text + "','" + txtProductTotal.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy")+"','" + cmbDealerName.Text + "','" + cmbProductName.Text + "','" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "','" + txtProfit.Text + "')";
            cmd.ExecuteNonQuery();

            MessageBox.Show("record succefully inserted  ");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
