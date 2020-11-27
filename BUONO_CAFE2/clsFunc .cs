using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Project_management_system
{
    class clsFunc
    {
    
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
  
      
        public void LogFunc(string st1, DateTime st2, string st3)
        {

            con = new SqlConnection(cs.ConDB);
            con.Open();
            string cb = "insert into Logs(UserName,Date,Operation) VALUES (@d1,@d2,@d3)";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", st1);
            cmd.Parameters.AddWithValue("@d2", st2);
            cmd.Parameters.AddWithValue("@d3", st3);
            cmd.ExecuteReader();
            con.Close();
        }
    }
}
