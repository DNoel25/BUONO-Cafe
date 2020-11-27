using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BUONO_CAFE2
{
    public partial class Generate_Purchase_Report : Form
    {
        string j;
        int tot = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BUONO_CAFE;Integrated Security=True");
        
        public void get_Value(String i)
        {
            j = i;
        }
        public Generate_Purchase_Report()
        {
            InitializeComponent();
        }

        private void Generate_Purchase_Report_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            DataSet1 ds = new DataSet1();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = j;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable2);

            tot = 0;

            foreach (DataRow dr  in dt.Rows)
            {
                tot = tot + Convert.ToInt32(dr["Total"].ToString());
            }

            CrystalReport2 myreport = new CrystalReport2();
            myreport.SetDataSource(ds);
            myreport.SetParameterValue("Total", tot.ToString());
            crystalReportViewer1.ReportSource = myreport;
        }
        
        



    }
}
