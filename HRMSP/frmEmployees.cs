using HRMSWinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRMSP
{
    public partial class frmEmployees : Form
    {
        private readonly DatabaseHelper dbHelper;
        private DataTable departments;
        private DataTable designations;
        private int? selectedEmployeeId = null;

        public frmEmployees()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            ConfigureUI();
            LoadInitialData();
        }

        private void ConfigureUI()
        {
            this.Text = "Employee Management";
            this.StartPosition = FormStartPosition.CenterParent;

            foreach (Button btn in new[] { btnAdd, btnUpdate, btnDelete, btnClear })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
            }

            btnAdd.BackColor = Color.Green;
            btnUpdate.BackColor = Color.Teal;
            btnDelete.BackColor = Color.Red;
            btnClear.BackColor = Color.Gray;
        }

        private void LoadInitialData()
        {
            try
            {
                var deptParams = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_department_id", DBNull.Value),
                    new MySqlParameter("@in_department_name", DBNull.Value)
                };

                departments = dbHelper.ExecuteStoredProcedure("DepartmentSp", deptParams);

                if (departments != null && departments.Rows.Count > 0)
                {
                    cmbDepartment.DataSource = departments;
                    cmbDepartment.DisplayMember = "department_name";
                    cmbDepartment.ValueMember = "department_id";
                    cmbDepartment.SelectedIndex = -1;
                }

                var desParams = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_designation_id", DBNull.Value),
                    new MySqlParameter("@in_designation_name", DBNull.Value)
                };

                designations = dbHelper.ExecuteStoredProcedure("DesignationSp", desParams);

                if (designations != null && designations.Rows.Count > 0)
                {
                    cmbDesignation.DataSource = designations;
                    cmbDesignation.DisplayMember = "designation_name";
                    cmbDesignation.ValueMember = "designation_id";
                    cmbDesignation.SelectedIndex = -1;
                }
                
                LoadEmployees(); // Load DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdown data: " + ex.Message);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_employee_id", DBNull.Value),
                    new MySqlParameter("@in_ename", DBNull.Value),
                    new MySqlParameter("@in_email", DBNull.Value),
                    new MySqlParameter("@in_department_id", DBNull.Value),
                    new MySqlParameter("@in_designation_id", DBNull.Value),
                    new MySqlParameter("@in_salary", DBNull.Value),
                    new MySqlParameter("@in_pass", DBNull.Value),
                    new MySqlParameter("@in_bankname", DBNull.Value),
                    new MySqlParameter("@in_bankno", DBNull.Value),
                    new MySqlParameter("@in_nationality", DBNull.Value)
                };

                DataTable dt = dbHelper.ExecuteStoredProcedure("EmployeeSp", parameters);
                dgvEmployees.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployee()) return;

            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "INSERT"),
                    new MySqlParameter("@in_employee_id", DBNull.Value),
                    new MySqlParameter("@in_ename", txtFullName.Text.Trim()),
                    new MySqlParameter("@in_email", txtEmail.Text.Trim()),
                    new MySqlParameter("@in_department_id", Convert.ToInt32(cmbDepartment.SelectedValue)),
                    new MySqlParameter("@in_designation_id", Convert.ToInt32(cmbDesignation.SelectedValue)),
                    new MySqlParameter("@in_salary", DBNull.Value),
                    new MySqlParameter("@in_pass", DBNull.Value),
                    new MySqlParameter("@in_bankname", DBNull.Value),
                    new MySqlParameter("@in_bankno", DBNull.Value),
                    new MySqlParameter("@in_nationality", DBNull.Value)
                };

                int result = dbHelper.ExecuteStoredProcedureNonQuery("EmployeeSp", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == null || !ValidateEmployee()) return;

            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "UPDATE"),
                    new MySqlParameter("@in_employee_id", selectedEmployeeId),
                    new MySqlParameter("@in_ename", txtFullName.Text.Trim()),
                    new MySqlParameter("@in_email", txtEmail.Text.Trim()),
                    new MySqlParameter("@in_department_id", Convert.ToInt32(cmbDepartment.SelectedValue)),
                    new MySqlParameter("@in_designation_id", Convert.ToInt32(cmbDesignation.SelectedValue)),
                    new MySqlParameter("@in_salary", DBNull.Value),
                    new MySqlParameter("@in_pass", DBNull.Value),
                    new MySqlParameter("@in_bankname", DBNull.Value),
                    new MySqlParameter("@in_bankno", DBNull.Value),
                    new MySqlParameter("@in_nationality", DBNull.Value)
                };

                int result = dbHelper.ExecuteStoredProcedureNonQuery("EmployeeSp", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message);
            }
        }
        private void dvgEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the click is not on header
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

                selectedEmployeeId = Convert.ToInt32(row.Cells["employee_id"].Value);
                txtFullName.Text = row.Cells["ename"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString(); // Optional: remove if not used
                txtEmail.Text = row.Cells["email"].Value.ToString();
                cmbDepartment.SelectedValue = Convert.ToInt32(row.Cells["department_id"].Value);
                cmbDesignation.SelectedValue = Convert.ToInt32(row.Cells["designation_id"].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmail == null)
            {
                MessageBox.Show("Please select an employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var parameters = new MySqlParameter[]
                    {
                new MySqlParameter("action", "DELETE"),
                new MySqlParameter("in_employee_id", selectedEmployeeId),
                new MySqlParameter("in_ename", DBNull.Value),
                new MySqlParameter("in_email", DBNull.Value),
                new MySqlParameter("in_department_id", DBNull.Value),
                new MySqlParameter("in_designation_id", DBNull.Value),
                new MySqlParameter("in_salary", DBNull.Value),
                new MySqlParameter("in_pass", DBNull.Value),
                new MySqlParameter("in_bankname", DBNull.Value),
                new MySqlParameter("in_bankno", DBNull.Value),
                new MySqlParameter("in_nationality", DBNull.Value)
                    };

                    int result = dbHelper.ExecuteStoredProcedureNonQuery("EmployeeSp", parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadEmployees(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete employee. Try again.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedEmployeeId = null;
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbDesignation.SelectedIndex = -1;
        }

        private bool ValidateEmployee()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter full name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter phone number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbDepartment.SelectedIndex == -1 || cmbDesignation.SelectedIndex == -1)
            {
                MessageBox.Show("Please select department and designation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            LoadEmployees(); // Ensure employee data loads when form opens
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                selectedEmployeeId = Convert.ToInt32(row.Cells["employee_id"].Value); // Must match your column name

                txtFullName.Text = row.Cells["ename"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                cmbDepartment.Text = row.Cells["department_name"].Value.ToString(); // or .SelectedValue = ...
                cmbDesignation.Text = row.Cells["designation_name"].Value.ToString();
            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
