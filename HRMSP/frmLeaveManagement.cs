using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRMSWinForms;

namespace HRMSP
{
    public partial class frmLeaveManagement : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        int id = 0;

        public frmLeaveManagement()
        {
            InitializeComponent();

            this.Load += FrmLeaveManagement_Load;
            cmpemp.DropDown += Cmpemp_DropDown;
            cmpemp.SelectedIndexChanged += (s, e) => LoadLeavesByEmployee();
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            dgvLeaves.CellClick += DgvLeaves_CellClick;
            Add.Click += Add_Click;
            Update.Click += Update_Click;
            Delete.Click += Delete_Click;
            Clear.Click += Clear_Click;
        }

        private void FrmLeaveManagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadLeaves();
        }

        private void Cmpemp_DropDown(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                MySqlParameter[] p =
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

                var dt = db.ExecuteStoredProcedure("EmployeeSp", p);
                cmpemp.DataSource = dt;
                cmpemp.DisplayMember = "ename";
                cmpemp.ValueMember = "employee_id";
                cmpemp.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void LoadLeaves()
        {
            try
            {
                MySqlParameter[] p =
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_Leaveid", DBNull.Value),
                    new MySqlParameter("@in_Startleavedate", DBNull.Value),
                    new MySqlParameter("@in_Endleavedate", DBNull.Value),
                    new MySqlParameter("@in_Days", DBNull.Value),
                    new MySqlParameter("@in_status", DBNull.Value),
                    new MySqlParameter("@in_Reason", DBNull.Value),
                    new MySqlParameter("@in_employee_id", DBNull.Value)
                };

                dgvLeaves.DataSource = db.ExecuteStoredProcedure("LeaveSp", p);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading leaves: " + ex.Message);
            }
        }

        private void LoadLeavesByEmployee()
        {
            if (cmpemp.SelectedValue == null || cmpemp.SelectedIndex == -1)
                return;

            try
            {
                int empId;
                if (cmpemp.SelectedValue is DataRowView drv)
                {
                    empId = Convert.ToInt32(drv["employee_id"]);
                }
                else
                {
                    empId = Convert.ToInt32(cmpemp.SelectedValue);
                }

                MySqlParameter[] p =
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_Leaveid", DBNull.Value),
                    new MySqlParameter("@in_Startleavedate", DBNull.Value),
                    new MySqlParameter("@in_Endleavedate", DBNull.Value),
                    new MySqlParameter("@in_Days", DBNull.Value),
                    new MySqlParameter("@in_status", DBNull.Value),
                    new MySqlParameter("@in_Reason", DBNull.Value),
                    new MySqlParameter("@in_employee_id", empId)
                };

                dgvLeaves.DataSource = db.ExecuteStoredProcedure("LeaveSp", p);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering leaves by employee: " + ex.Message);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null) return;

            string selectedStatus = cmbStatus.SelectedItem.ToString();

            try
            {
                MySqlParameter[] p =
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_Leaveid", DBNull.Value),
                    new MySqlParameter("@in_Startleavedate", DBNull.Value),
                    new MySqlParameter("@in_Endleavedate", DBNull.Value),
                    new MySqlParameter("@in_Days", DBNull.Value),
                    new MySqlParameter("@in_status", selectedStatus),
                    new MySqlParameter("@in_Reason", DBNull.Value),
                    new MySqlParameter("@in_employee_id", DBNull.Value)
                };

                dgvLeaves.DataSource = db.ExecuteStoredProcedure("LeaveSp", p);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering leaves by status: " + ex.Message);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = 0;
            dtpf.Value = DateTime.Now;
            dtpft.Value = DateTime.Now;
            reason.Clear();
            cmpemp.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (cmpemp.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            try
            {
                int empId = (cmpemp.SelectedValue is DataRowView drv)
                    ? Convert.ToInt32(drv["employee_id"])
                    : Convert.ToInt32(cmpemp.SelectedValue);

                MySqlParameter[] p =
                {
                    new MySqlParameter("@action", "INSERT"),
                    new MySqlParameter("@in_Leaveid", 0),
                    new MySqlParameter("@in_Startleavedate", dtpf.Value),
                    new MySqlParameter("@in_Endleavedate", dtpft.Value),
                    new MySqlParameter("@in_Days", (dtpft.Value - dtpf.Value).Days + 1),
                    new MySqlParameter("@in_status", cmbStatus.SelectedItem ?? DBNull.Value),
                    new MySqlParameter("@in_Reason", reason.Text),
                    new MySqlParameter("@in_employee_id", empId)
                };

                int result = db.ExecuteStoredProcedureNonQuery("LeaveSp", p);
                if (result > 0)
                {
                    MessageBox.Show("Leave added successfully.");
                    LoadLeaves();
                    Clear_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to add leave.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding leave: " + ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Select a leave to update.");
                return;
            }

            try
            {
                int empId = (cmpemp.SelectedValue is DataRowView drv)
                    ? Convert.ToInt32(drv["employee_id"])
                    : Convert.ToInt32(cmpemp.SelectedValue);

                MySqlParameter[] p =
                {
                    new MySqlParameter("@action", "UPDATE"),
                    new MySqlParameter("@in_Leaveid", id),
                    new MySqlParameter("@in_Startleavedate", dtpf.Value),
                    new MySqlParameter("@in_Endleavedate", dtpft.Value),
                    new MySqlParameter("@in_Days", (dtpft.Value - dtpf.Value).Days + 1),
                    new MySqlParameter("@in_status", cmbStatus.SelectedItem ?? DBNull.Value),
                    new MySqlParameter("@in_Reason", reason.Text),
                    new MySqlParameter("@in_employee_id", empId)
                };

                int result = db.ExecuteStoredProcedureNonQuery("LeaveSp", p);
                if (result > 0)
                {
                    MessageBox.Show("Leave updated successfully.");
                    LoadLeaves();
                    Clear_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to update leave.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating leave: " + ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Select a leave to delete.");
                return;
            }

            try
            {

                MySqlParameter[] p =
                {
                    new MySqlParameter("@action", "DELETE"),
                    new MySqlParameter("@in_Leaveid", id),
                    new MySqlParameter("@in_Startleavedate", DBNull.Value),
                    new MySqlParameter("@in_Endleavedate", DBNull.Value),
                    new MySqlParameter("@in_Days", DBNull.Value),
                    new MySqlParameter("@in_status", DBNull.Value),
                    new MySqlParameter("@in_Reason", DBNull.Value),
                    new MySqlParameter("@in_employee_id", DBNull.Value)
                };

                int result = db.ExecuteStoredProcedureNonQuery("LeaveSp", p);
                if (result > 0)
                {
                    MessageBox.Show("Leave deleted successfully.");
                    LoadLeaves();
                    Clear_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete leave.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting leave:" + ex.Message);
            }
        }
        private void DgvLeaves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvLeaves.Rows[e.RowIndex];
            id = Convert.ToInt32(row.Cells["Leaveid"].Value);
            dtpf.Value = Convert.ToDateTime(row.Cells["Startleavedate"].Value);
            dtpft.Value = Convert.ToDateTime(row.Cells["Endleavedate"].Value);
            reason.Text = row.Cells["Reason"].Value.ToString();
            cmpemp.SelectedValue = Convert.ToInt32(row.Cells["employee_id"].Value);
            cmbStatus.SelectedItem = row.Cells["status"].Value.ToString();
        }
    }
}
