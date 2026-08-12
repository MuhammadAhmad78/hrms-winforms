using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HRMSWinForms;
using MySql.Data.MySqlClient;

namespace HRMSP
{
    public partial class frmLogin : Form
    {
        private readonly DatabaseHelper dbHelper;

       
        public static int LoggedInEmployeeId = 0;
        public static string LoggedInUserName;

        public frmLogin()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Text = "Enter your email";
        }

        private void lblEmail_Click(object sender, EventArgs e) { }

        private void txtEmail_GotFocus(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter your email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Enter your email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "LOGIN"),
                    new MySqlParameter("@in_email", txtEmail.Text.Trim()),
                    new MySqlParameter("@in_pass", txtPass.Text),
                    new MySqlParameter("@in_employee_id", DBNull.Value),
                    new MySqlParameter("@in_ename", DBNull.Value),
                    new MySqlParameter("@in_department_id", DBNull.Value),
                    new MySqlParameter("@in_designation_id", DBNull.Value),
                    new MySqlParameter("@in_salary", DBNull.Value),
                    new MySqlParameter("@in_bankname", DBNull.Value),
                    new MySqlParameter("@in_bankno", DBNull.Value),
                    new MySqlParameter("@in_nationality", DBNull.Value)
                };

                DataTable result = dbHelper.ExecuteStoredProcedure("EmployeeSp", parameters);

                if (result != null && result.Rows.Count > 0 && result.Columns.Contains("message") && result.Rows[0]["message"].ToString() == "Login successful")
                {
                    // ✅ Store logged-in employee_id
                    LoggedInEmployeeId = Convert.ToInt32(result.Rows[0]["employee_id"]);
                    frmLogin.LoggedInUserName = result.Rows[0]["ename"].ToString();  // Add this line


                    // ✅ Open Main Form
                    this.Hide();
                    new frmMain().Show();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Enter your email")
            {
                MessageBox.Show("Please enter your email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtCredentials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
