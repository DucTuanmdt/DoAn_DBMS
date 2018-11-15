using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh.DisplayLayer
{
    public partial class FormLoginServer : Form
    {
        public String Datasource { get { return txtDatasource.Text; } set { txtDatasource.Text = value; } }
        public String Database { get { return "QuanLySieuThi"; } }
        public String Username { get { return txtUsername.Text; } set { txtUsername.Text = value; } }
        public String Password { get { return txtPassword.Text; } set { txtPassword.Text = value; } }
        private FormMain mainForm;

        public FormLoginServer()
        {
            InitializeComponent();
        }
        public FormLoginServer(FormMain mainForm, string username, string password)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            //this.txtUsername.Text = username;
            //this.txtPassword.Text = password;
        }

        private void FormLoginServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                String msg = "";
                String cap = "";

                if (txtDatasource.Text.Trim().Length == 0)
                {
                    msg = "You must supply a Data Source. Please enter a Data Source and try again.";
                    cap = "Missing Data";
                    MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.mainForm.SetData(this);
            this.mainForm.CheckConnection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.mainForm.SetData(this);
            this.mainForm.CheckTruyCapServer();
        }
    }
}
