using HRMSWinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HRMSP
{
    public partial class frmDesignations : Form
    {
        private readonly DatabaseHelper dbHelper;
        private int? selectedDesignationId = null;

        public frmDesignations()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            ConfigureUI();
            LoadDesignations();
            dgvDesignations.CellClick += dgvDesignations_CellClick; // Ensure event handler is connected
        }

        private void ConfigureUI()
        {
            this.Text = "Designation Management";
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

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadDesignations()
        {
            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("action", "SELECT"),
                    new MySqlParameter("in_designation_id", 0),
                    new MySqlParameter("in_designation_name", "")
                };

                DataTable dt = dbHelper.ExecuteStoredProcedure("DesignationSp", parameters);

                if (dt == null || dt.Columns.Count == 0)
                {
                    MessageBox.Show("No data found in designations.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvDesignations.DataSource = dt;

                if (dgvDesignations.Columns.Contains("designation_id"))
                {
                    dgvDesignations.Columns["designation_id"].HeaderText = "ID";
                    dgvDesignations.Columns["designation_id"].Width = 50;
                }

                if (dgvDesignations.Columns.Contains("designation_name"))
                {
                    dgvDesignations.Columns["designation_name"].HeaderText = "Designation Name";
                    dgvDesignations.Columns["designation_name"].Width = 200;
                }

                if (dgvDesignations.Columns.Contains("created_date"))
                {
                    dgvDesignations.Columns["created_date"].HeaderText = "Created Date";
                    dgvDesignations.Columns["created_date"].Width = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading designations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtDesignationName.Clear();
            selectedDesignationId = null;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtDesignationName.Focus();
            dgvDesignations.ClearSelection();
        }

        private bool ValidateDesignation()
        {
            if (string.IsNullOrWhiteSpace(txtDesignationName.Text))
            {
                MessageBox.Show("Please enter designation name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateDesignation()) return;

            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("action", "INSERT"),
                    new MySqlParameter("in_designation_id", 0),
                    new MySqlParameter("in_designation_name", txtDesignationName.Text.Trim())
                };

                int result = dbHelper.ExecuteStoredProcedureNonQuery("DesignationSp", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Designation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDesignations();
                    ClearForm();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("This designation already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding designation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDesignationId == null || !ValidateDesignation()) return;

            try
            {
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("action", "UPDATE"),
                    new MySqlParameter("in_designation_id", selectedDesignationId),
                    new MySqlParameter("in_designation_name", txtDesignationName.Text.Trim())
                };

                int result = dbHelper.ExecuteStoredProcedureNonQuery("DesignationSp", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Designation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDesignations();
                    ClearForm();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("This designation name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating designation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDesignationId == null)
            {
                MessageBox.Show("Please select a designation to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this designation?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("action", "DELETE"),
                        new MySqlParameter("in_designation_id", selectedDesignationId),
                        new MySqlParameter("in_designation_name", DBNull.Value)
                    };

                    int result = dbHelper.ExecuteStoredProcedureNonQuery("DesignationSp", parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Designation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDesignations();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("No designation deleted. It may not exist.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1451)
                {
                    MessageBox.Show("This designation is referenced by employees and cannot be deleted.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting designation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvDesignations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDesignations.Rows[e.RowIndex].Cells["designation_id"].Value != null)
            {
                var row = dgvDesignations.Rows[e.RowIndex];
                selectedDesignationId = Convert.ToInt32(row.Cells["designation_id"].Value);
                txtDesignationName.Text = row.Cells["designation_name"].Value.ToString();

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
