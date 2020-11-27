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
    public partial class Purchase_Report : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        string query = "";

        public Purchase_Report()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Purchase_Stock_Info ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["Product_Total"].ToString());

            }

            lblTotal.Text = i.ToString();

            query = "SELECT * from Purchase_Stock_Info ";
        }

        private void Purchase_Report_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string StartDate;
            string EndDate;

            StartDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            EndDate = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from Purchase_Stock_Info WHERE Purchase_Date >= '" + StartDate.ToString() +"' AND Purchase_Date <='"+EndDate.ToString()+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                i += Convert.ToInt32(dr["Product_Total"].ToString());

            }

            lblTotal.Text = i.ToString();
            query = "SELECT * from Purchase_Stock_Info WHERE Purchase_Date >= '" + StartDate.ToString() + "' AND Purchase_Date <='" + EndDate.ToString() + "'";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Generate_Purchase_Report gpr = new Generate_Purchase_Report();
            gpr.get_Value(query.ToString()) ;
            gpr.Show(); 
        }
    }
}
