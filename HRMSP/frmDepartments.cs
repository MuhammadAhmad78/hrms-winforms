using HRMSWinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRMSP
{
    public partial class frmDepartments : Form
    {
        private readonly DatabaseHelper dbHelper;
        private int? selectedDepartmentId = null;

        public frmDepartments()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Ensure event is registered
            this.Load += frmDepartments_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            dgvDepartments.CellClick += dgvDepartments_CellClick;
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            ConfigureUI();
            LoadDepartments();
        }

        private void ConfigureUI()
        {
            this.Text = "Department Management";
            this.StartPosition = FormStartPosition.CenterParent;

            foreach (Button btn in new[] { btnAdd, btnUpdate, btnDelete, btnClear })
            {
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.White;
                }
            }

            if (btnAdd != null) btnAdd.BackColor = Color.Green;
            if (btnUpdate != null) btnUpdate.BackColor = Color.Teal;
            if (btnDelete != null) btnDelete.BackColor = Color.Red;
            if (btnClear != null) btnClear.BackColor = Color.Gray;

            if (btnUpdate != null) btnUpdate.Enabled = false;
            if (btnDelete != null) btnDelete.Enabled = false;
        }

        private void LoadDepartments()
        {
            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_department_id", 0),
                    new MySqlParameter("@in_department_name", "")
                };

                DataTable dataTable = dbHelper.ExecuteStoredProcedure("DepartmentSp", parameters);
                if (dataTable == null || dataTable.Columns.Count == 0)
                {
                    MessageBox.Show("No columns returned from DepartmentSp.");
                    return;
                }

                dgvDepartments.DataSource = dataTable;

                if (dgvDepartments.Columns.Contains("department_id"))
                {
                    dgvDepartments.Columns["department_id"].HeaderText = "ID";
                    dgvDepartments.Columns["department_id"].Width = 50;
                }

                if (dgvDepartments.Columns.Contains("department_name"))
                {
                    dgvDepartments.Columns["department_name"].HeaderText = "Department Name";
                    dgvDepartments.Columns["department_name"].Width = 200;
                }

                if (dgvDepartments.Columns.Contains("created_date"))
                    dgvDepartments.Columns["created_date"].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            if (textBox1 != null)
            {
                textBox1.Clear();
                textBox1.Focus();
            }

            selectedDepartmentId = null;

            if (btnAdd != null) btnAdd.Enabled = true;
            if (btnUpdate != null) btnUpdate.Enabled = false;
            if (btnDelete != null) btnDelete.Enabled = false;
        }

        private bool ValidateDepartment()
        {
            if (textBox1 == null || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter department name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartment()) return;

            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "INSERT"),
                    new MySqlParameter("@in_department_id", 0),
                    new MySqlParameter("@in_department_name", textBox1.Text.Trim())
                };

                int result = dbHelper.ExecuteStoredProcedureNonQuery("DepartmentSp", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Department added successfully!");
                    LoadDepartments();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding department: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentId == null || !ValidateDepartment()) return;

            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@action", "UPDATE"),
                    new MySqlParameter("@in_department_id", selectedDepartmentId),
                    new MySqlParameter("@in_department_name", textBox1.Text.Trim())
                };

                int result = dbHelper.ExecuteStoredProcedureNonQuery("DepartmentSp", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Department updated successfully!");
                    LoadDepartments();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating department: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentId == null)
            {
                MessageBox.Show("Select a department to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@action", "DELETE"),
                        new MySqlParameter("@in_department_id", selectedDepartmentId),
                        new MySqlParameter("@in_department_name", DBNull.Value)
                    };

                    int result = dbHelper.ExecuteStoredProcedureNonQuery("DepartmentSp", parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Department deleted!");
                        LoadDepartments();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDepartments.Rows.Count > e.RowIndex)
            {
                var row = dgvDepartments.Rows[e.RowIndex];
                selectedDepartmentId = Convert.ToInt32(row.Cells["department_id"].Value);
                textBox1.Text = row.Cells["department_name"].Value.ToString();

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
