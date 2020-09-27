using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUONO_CAFE2
{
    public partial class ManagerFront : Form
    {
        public ManagerFront()
        {
            InitializeComponent();
        }

        private void btnViewAccounts_Click(object sender, EventArgs e)
        {
            AdminManageUser amu = new AdminManageUser();
            amu.Show();
            this.Hide();
        }

        private void ManagerFront_Load(object sender, EventArgs e)
        {

        }

        private void btnViewStocks_Click(object sender, EventArgs e)
        {
            Stocks s = new Stocks();
            s.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
