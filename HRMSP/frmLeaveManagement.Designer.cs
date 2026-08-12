using System;
using System.Windows.Forms;

namespace HRMSP
{
    partial class frmLeaveManagement : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvLeaves = new System.Windows.Forms.DataGridView();
            this.lblemp = new System.Windows.Forms.Label();
            this.lblr = new System.Windows.Forms.Label();
            this.lblt = new System.Windows.Forms.Label();
            this.lblf = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.cmpemp = new System.Windows.Forms.ComboBox();
            this.dtpf = new System.Windows.Forms.DateTimePicker();
            this.dtpft = new System.Windows.Forms.DateTimePicker();
            this.reason = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaves)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLeaves
            // 
            this.dgvLeaves.Location = new System.Drawing.Point(0, 0);
            this.dgvLeaves.Name = "dgvLeaves";
            this.dgvLeaves.Size = new System.Drawing.Size(586, 182);
            this.dgvLeaves.TabIndex = 0;
            this.dgvLeaves.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLeaves_CellClick);
            // 
            // lblemp
            // 
            this.lblemp.AutoSize = true;
            this.lblemp.Location = new System.Drawing.Point(12, 207);
            this.lblemp.Name = "lblemp";
            this.lblemp.Size = new System.Drawing.Size(56, 13);
            this.lblemp.TabIndex = 1;
            this.lblemp.Text = "Employee:";
            // 
            // lblr
            // 
            this.lblr.AutoSize = true;
            this.lblr.Location = new System.Drawing.Point(231, 236);
            this.lblr.Name = "lblr";
            this.lblr.Size = new System.Drawing.Size(47, 13);
            this.lblr.TabIndex = 2;
            this.lblr.Text = "Reason:";
            // 
            // lblt
            // 
            this.lblt.AutoSize = true;
            this.lblt.Location = new System.Drawing.Point(33, 279);
            this.lblt.Name = "lblt";
            this.lblt.Size = new System.Drawing.Size(23, 13);
            this.lblt.TabIndex = 3;
            this.lblt.Text = "To:";
            // 
            // lblf
            // 
            this.lblf.AutoSize = true;
            this.lblf.Location = new System.Drawing.Point(33, 236);
            this.lblf.Name = "lblf";
            this.lblf.Size = new System.Drawing.Size(33, 13);
            this.lblf.TabIndex = 4;
            this.lblf.Text = "From:";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(-3, 185);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(75, 13);
            this.lblDetails.TabIndex = 5;
            this.lblDetails.Text = "Leave Details:";
            // 
            // cmpemp
            // 
            this.cmpemp.FormattingEnabled = true;
            this.cmpemp.Location = new System.Drawing.Point(75, 207);
            this.cmpemp.Name = "cmpemp";
            this.cmpemp.Size = new System.Drawing.Size(121, 21);
            this.cmpemp.TabIndex = 6;
            this.cmpemp.Click += new System.EventHandler(this.Cmpemp_DropDown);
            // 
            // dtpf
            // 
            this.dtpf.Location = new System.Drawing.Point(75, 236);
            this.dtpf.Name = "dtpf";
            this.dtpf.Size = new System.Drawing.Size(121, 20);
            this.dtpf.TabIndex = 7;
            // 
            // dtpft
            // 
            this.dtpft.Location = new System.Drawing.Point(75, 273);
            this.dtpft.Name = "dtpft";
            this.dtpft.Size = new System.Drawing.Size(121, 20);
            this.dtpft.TabIndex = 8;
            // 
            // reason
            // 
            this.reason.Location = new System.Drawing.Point(284, 207);
            this.reason.Multiline = true;
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(122, 63);
            this.reason.TabIndex = 9;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.Green;
            this.Add.Location = new System.Drawing.Point(441, 204);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(61, 23);
            this.Add.TabIndex = 10;
            this.Add.Text = "ADD";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.Gray;
            this.Clear.Location = new System.Drawing.Point(522, 237);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(64, 23);
            this.Clear.TabIndex = 11;
            this.Clear.Text = "CLEAR";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Red;
            this.Delete.Location = new System.Drawing.Point(441, 237);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(61, 23);
            this.Delete.TabIndex = 12;
            this.Delete.Text = "DELETE";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.LightBlue;
            this.Update.Location = new System.Drawing.Point(522, 204);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(64, 23);
            this.Update.TabIndex = 13;
            this.Update.Text = "UPDATE";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Approved",
            "Pending",
            "Rejected"});
            this.cmbStatus.Location = new System.Drawing.Point(285, 279);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 14;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            this.cmbStatus.SelectedValueChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(234, 286);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status:";
            // 
            // frmLeaveManagement
            // 
            this.ClientSize = new System.Drawing.Size(764, 400);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dgvLeaves);
            this.Controls.Add(this.lblemp);
            this.Controls.Add(this.lblr);
            this.Controls.Add(this.lblt);
            this.Controls.Add(this.lblf);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.cmpemp);
            this.Controls.Add(this.dtpf);
            this.Controls.Add(this.dtpft);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Name = "frmLeaveManagement";
            this.Text = "Leave Management";
            this.Load += new System.EventHandler(this.FrmLeaveManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }     
        #endregion

        private System.Windows.Forms.DataGridView dgvLeaves;
        private System.Windows.Forms.Label lblemp;
        private System.Windows.Forms.Label lblr;
        private System.Windows.Forms.Label lblt;
        private System.Windows.Forms.Label lblf;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.ComboBox cmpemp;
        private System.Windows.Forms.DateTimePicker dtpf;
        private System.Windows.Forms.DateTimePicker dtpft;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private ComboBox cmbStatus;
        private Label lblStatus;
    }
}
