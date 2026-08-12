using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRMSWinForms;

namespace HRMSP
{
    public partial class frmSalarySlips : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        int selectedId = 0;

        public frmSalarySlips()
        {
            InitializeComponent();
            cmbEmployee.SelectedIndexChanged += cmbEmployee_SelectedIndexChanged;
        }

        private void frmSalarySlips_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadSalarySlips();
            my.SelectedIndex = 0;
        }

        private void LoadEmployees()
        {
            try
            {
                DataTable dt = db.ExecuteStoredProcedure("EmployeeSp", new MySqlParameter[]
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
                });

                if (dt != null && dt.Columns.Contains("employee_id") && dt.Columns.Contains("ename"))
                {
                    cmbEmployee.DataSource = dt;
                    cmbEmployee.DisplayMember = "ename";
                    cmbEmployee.ValueMember = "employee_id";
                    cmbEmployee.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void LoadSalarySlips()
        {
            try
            {
                DataTable dt = db.ExecuteStoredProcedure("SalarySlipSp", new MySqlParameter[]
                {
                    new MySqlParameter("@action", "SELECT"),
                    new MySqlParameter("@in_salaryslipid", 0),
                    new MySqlParameter("@in_monthyear", dtpMonthYear.Value),
                    new MySqlParameter("@in_employee_id", 0),
                    new MySqlParameter("@in_salary", 0),
                    new MySqlParameter("@in_Actualsalary", 0),
                    new MySqlParameter("@in_advancesalary", 0),
                    new MySqlParameter("@in_leaveded", 0),
                    new MySqlParameter("@in_foodallownce", 0),
                    new MySqlParameter("@in_Medicalallownce", 0),
                    new MySqlParameter("@in_travelallownce", 0),
                    new MySqlParameter("@in_Bonus", 0)
                });

                dgvSalarySlips.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading salary slips: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            cmbEmployee.SelectedIndex = -1;
            dtpMonthYear.Value = DateTime.Today;
            txtBasic.Clear();
            txtHRA.Clear();
            txtfAllownce.Clear();
            txtmAllownce.Clear();
            txttAllownce.Clear();
            txtDeductions.Clear();
            Netsal.Clear();
            selectedId = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal basic = string.IsNullOrEmpty(txtBasic.Text) ? 0 : Convert.ToDecimal(txtBasic.Text);
                decimal hra = string.IsNullOrEmpty(txtHRA.Text) ? 0 : Convert.ToDecimal(txtHRA.Text);
                decimal food = string.IsNullOrEmpty(txtfAllownce.Text) ? 0 : Convert.ToDecimal(txtfAllownce.Text);
                decimal medical = string.IsNullOrEmpty(txtmAllownce.Text) ? 0 : Convert.ToDecimal(txtmAllownce.Text);
                decimal travel = string.IsNullOrEmpty(txttAllownce.Text) ? 0 : Convert.ToDecimal(txttAllownce.Text);
                decimal deductions = string.IsNullOrEmpty(txtDeductions.Text) ? 0 : Convert.ToDecimal(txtDeductions.Text);

                decimal totalIncome = basic + hra + food + medical + travel;
                decimal netSalary = totalIncome - deductions;

                if (my.SelectedItem?.ToString() == "Yearly")
                    netSalary *= 12;

                Netsal.Text = netSalary.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.ExecuteStoredProcedureNonQuery("SalarySlipSp", new MySqlParameter[]
                {
                    new MySqlParameter("@action", "INSERT"),
                    new MySqlParameter("@in_salaryslipid", 0),
                    new MySqlParameter("@in_monthyear", dtpMonthYear.Value),
                    new MySqlParameter("@in_employee_id", Convert.ToInt32(cmbEmployee.SelectedValue)),
                    new MySqlParameter("@in_salary", Convert.ToDecimal(txtBasic.Text)),
                    new MySqlParameter("@in_Actualsalary", Convert.ToDecimal(Netsal.Text)),
                    new MySqlParameter("@in_advancesalary", 0),
                    new MySqlParameter("@in_leaveded", Convert.ToDecimal(txtDeductions.Text)),
                    new MySqlParameter("@in_foodallownce", Convert.ToDecimal(txtfAllownce.Text)),
                    new MySqlParameter("@in_Medicalallownce", Convert.ToDecimal(txtmAllownce.Text)),
                    new MySqlParameter("@in_travelallownce", Convert.ToDecimal(txttAllownce.Text)),
                    new MySqlParameter("@in_Bonus", Convert.ToDecimal(txtHRA.Text))
                });

                MessageBox.Show("Saved successfully!");
                LoadSalarySlips();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a row to update.");
                return;
            }

            try
            {
                db.ExecuteStoredProcedureNonQuery("SalarySlipSp", new MySqlParameter[]
                {
                    new MySqlParameter("@action", "UPDATE"),
                    new MySqlParameter("@in_salaryslipid", selectedId),
                    new MySqlParameter("@in_monthyear", dtpMonthYear.Value),
                    new MySqlParameter("@in_employee_id", Convert.ToInt32(cmbEmployee.SelectedValue)),
                    new MySqlParameter("@in_salary", Convert.ToDecimal(txtBasic.Text)),
                    new MySqlParameter("@in_Actualsalary", Convert.ToDecimal(Netsal.Text)),
                    new MySqlParameter("@in_advancesalary", 0),
                    new MySqlParameter("@in_leaveded", Convert.ToDecimal(txtDeductions.Text)),
                    new MySqlParameter("@in_foodallownce", Convert.ToDecimal(txtfAllownce.Text)),
                    new MySqlParameter("@in_Medicalallownce", Convert.ToDecimal(txtmAllownce.Text)),
                    new MySqlParameter("@in_travelallownce", Convert.ToDecimal(txttAllownce.Text)),
                    new MySqlParameter("@in_Bonus", Convert.ToDecimal(txtHRA.Text))
                });

                MessageBox.Show("Updated successfully!");
                LoadSalarySlips();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void dgvSalarySlips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalarySlips.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["salaryslipid"].Value);

                cmbEmployee.SelectedValue = Convert.ToInt32(row.Cells["employee_id"].Value);
                dtpMonthYear.Value = Convert.ToDateTime(row.Cells["monthyear"].Value);
                txtBasic.Text = row.Cells["salary"].ToString();
                Netsal.Text = row.Cells["Actualsalary"].ToString();
                txtfAllownce.Text = row.Cells["foodallownce"].ToString();
                txtmAllownce.Text = row.Cells["Medicalallownce"].ToString();
                txttAllownce.Text = row.Cells["travelallownce"].ToString();
                txtDeductions.Text = row.Cells["leaveded"].ToString();
                txtHRA.Text = row.Cells["Bonus"].ToString();
            }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue != null && int.TryParse(cmbEmployee.SelectedValue.ToString(), out int empId))
            {
                try
                {
                    DataTable dt = db.ExecuteStoredProcedure("SalarySlipSp", new MySqlParameter[]
                    {
                        new MySqlParameter("@action", "GETBYEMP"),
                        new MySqlParameter("@in_salaryslipid", 0),
                        new MySqlParameter("@in_monthyear", dtpMonthYear.Value),
                        new MySqlParameter("@in_employee_id", empId),
                        new MySqlParameter("@in_salary", 0),
                        new MySqlParameter("@in_Actualsalary", 0),
                        new MySqlParameter("@in_advancesalary", 0),
                        new MySqlParameter("@in_leaveded", 0),
                        new MySqlParameter("@in_foodallownce", 0),
                        new MySqlParameter("@in_Medicalallownce", 0),
                        new MySqlParameter("@in_travelallownce", 0),
                        new MySqlParameter("@in_Bonus", 0)
                    });

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtBasic.Text = row["salary"].ToString();
                        txtHRA.Text = row["Bonus"].ToString();
                        txtfAllownce.Text = row["foodallownce"].ToString();
                        txtmAllownce.Text = row["Medicalallownce"].ToString();
                        txttAllownce.Text = row["travelallownce"].ToString();
                        txtDeductions.Text = row["leaveded"].ToString();
                        Netsal.Text = row["Actualsalary"].ToString();
                        dtpMonthYear.Value = Convert.ToDateTime(row["monthyear"]);
                        selectedId = Convert.ToInt32(row["salaryslipid"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading selected employee data: " + ex.Message);
                }
            }
        }
    }
}
