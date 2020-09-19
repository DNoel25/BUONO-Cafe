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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        public int ProductID;

        private void Stocks_Load(object sender, EventArgs e)
        {
            GetProductsRecord();
        }

        private void GetProductsRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from  Stock_Table", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            ProductRecordDataGridView.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Stock_Table VALUES(@Product_Name , @Product_Price , @ProductQuantity)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Product_Name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Product_Price",txtProductPrice.Text);
                cmd.Parameters.AddWithValue("@ProductQuantity",txtQuantities.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Stock Product is added successfully saved in the database", "Saved" , MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetProductsRecord();
                ResetFormControls();
            }
        }

        private bool IsValid()
        {
            if(txtProductName.Text == string.Empty)
            {
                MessageBox.Show("Student Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            ProductID = 0;
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtQuantities.Clear();

            txtProductName.Focus();
        }

        private void ProductRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductID = Convert.ToInt32(ProductRecordDataGridView.SelectedRows[0].Cells[0].Value);

            txtProductName.Text = ProductRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtProductPrice.Text = ProductRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantities.Text = ProductRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ProductID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Stock_Table SET Product_Name = @Product_Name , Product_Price = @Product_Price , Product_Quantity = @ProductQuantity WHERE ProductID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Product_Name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Product_Price", txtProductPrice.Text);
                cmd.Parameters.AddWithValue("@ProductQuantity", txtQuantities.Text);
                cmd.Parameters.AddWithValue("@ID", this.ProductID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student information Updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetProductsRecord();
                ResetFormControls(); 
            }
            else
            {
                MessageBox.Show("Please select a product to update the information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ProductID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Stock_Table WHERE ProductID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.ProductID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student is deleted from the system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetProductsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please select a product to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }
