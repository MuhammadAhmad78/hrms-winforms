using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HRMSP
{
   

    public partial class frmMain : Form
    {
        public frmMain()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            int empId = frmLogin.LoggedInEmployeeId;
            lblWelcome.Text = "Welcome " + frmLogin.LoggedInUserName;
           
        }

        private void OpenForm<T>() where T : Form, new()
        {
            int empId = frmLogin.LoggedInEmployeeId;
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate();
                    return;
                }
            }

            var newForm = new T();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenForm<frmEmployees>();

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenForm<frmDepartments>();

        private void designationsToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenForm<frmDesignations>();

        private void leaveManagementToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenForm<frmLeaveManagement>();

        private void salarySlipsToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenForm<frmSalarySlips>();

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmLogin().Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        
    }
}
