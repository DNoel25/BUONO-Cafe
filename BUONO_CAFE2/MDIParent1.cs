using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BUONO_CAFE2
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        public static string Uleavel = "cashier";
        public static string UleavelManager = "manager";

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
          

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {


            label1.Text = Login.SetValueForText1;
            lbluserpower.Text = Login.SetValueForText2;
           
            if (Uleavel == lbluserpower.Text)
            {
                usersToolStripMenuItem.Visible = false;
            }

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Units un = new Units();
            un.Show();

        }

        private void deleteInforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dealer_Info di = new Dealer_Info();
            di.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase p = new Purchase();
            p.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Report pr = new Purchase_Report();
            pr.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockInsert ii = new StockInsert();
            ii.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManageUser am = new AdminManageUser();
            am.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManageUser frm2 = new AdminManageUser();
            frm2.Show();
            
        }

        //private void sadasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form1 frm2 = new Form1();
        //    frm2.Show();
        //}

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManageUser am = new AdminManageUser();
            am.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
