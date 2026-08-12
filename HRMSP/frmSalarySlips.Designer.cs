namespace HRMSP
{
    partial class frmSalarySlips
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalarySlips));
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmp = new System.Windows.Forms.Label();
            this.txtBasic = new System.Windows.Forms.TextBox();
            this.txtHRA = new System.Windows.Forms.TextBox();
            this.txtDeductions = new System.Windows.Forms.TextBox();
            this.lblBasic = new System.Windows.Forms.Label();
            this.lblDeductions = new System.Windows.Forms.Label();
            this.lblfAllownce = new System.Windows.Forms.Label();
            this.lblbonus = new System.Windows.Forms.Label();
            this.lblNetSalary = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvSalarySlips = new System.Windows.Forms.DataGridView();
            this.Netsal = new System.Windows.Forms.TextBox();
            this.my = new System.Windows.Forms.ComboBox();
            this.lblselect = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtfAllownce = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttAllownce = new System.Windows.Forms.TextBox();
            this.txtmAllownce = new System.Windows.Forms.TextBox();
            this.lblmAllownce = new System.Windows.Forms.Label();
            this.lbltAllownce = new System.Windows.Forms.Label();
            this.dtpMonthYear = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalarySlips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(355, 69);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(121, 21);
            this.cmbEmployee.TabIndex = 0;
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Location = new System.Drawing.Point(355, 50);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(53, 13);
            this.lblEmp.TabIndex = 1;
            this.lblEmp.Text = "Employee";
            // 
            // txtBasic
            // 
            this.txtBasic.Location = new System.Drawing.Point(355, 151);
            this.txtBasic.Name = "txtBasic";
            this.txtBasic.Size = new System.Drawing.Size(121, 20);
            this.txtBasic.TabIndex = 2;
            // 
            // txtHRA
            // 
            this.txtHRA.Location = new System.Drawing.Point(355, 112);
            this.txtHRA.Name = "txtHRA";
            this.txtHRA.Size = new System.Drawing.Size(121, 20);
            this.txtHRA.TabIndex = 3;
            // 
            // txtDeductions
            // 
            this.txtDeductions.Location = new System.Drawing.Point(355, 190);
            this.txtDeductions.Name = "txtDeductions";
            this.txtDeductions.Size = new System.Drawing.Size(121, 20);
            this.txtDeductions.TabIndex = 4;
            // 
            // lblBasic
            // 
            this.lblBasic.AutoSize = true;
            this.lblBasic.Location = new System.Drawing.Point(355, 135);
            this.lblBasic.Name = "lblBasic";
            this.lblBasic.Size = new System.Drawing.Size(36, 13);
            this.lblBasic.TabIndex = 6;
            this.lblBasic.Text = "Basic:";
            // 
            // lblDeductions
            // 
            this.lblDeductions.AutoSize = true;
            this.lblDeductions.Location = new System.Drawing.Point(355, 174);
            this.lblDeductions.Name = "lblDeductions";
            this.lblDeductions.Size = new System.Drawing.Size(61, 13);
            this.lblDeductions.TabIndex = 7;
            this.lblDeductions.Text = "Deductions";
            // 
            // lblfAllownce
            // 
            this.lblfAllownce.AutoSize = true;
            this.lblfAllownce.Location = new System.Drawing.Point(595, 50);
            this.lblfAllownce.Name = "lblfAllownce";
            this.lblfAllownce.Size = new System.Drawing.Size(77, 13);
            this.lblfAllownce.TabIndex = 8;
            this.lblfAllownce.Text = "Food Allownce";
            // 
            // lblbonus
            // 
            this.lblbonus.AutoSize = true;
            this.lblbonus.Location = new System.Drawing.Point(355, 96);
            this.lblbonus.Name = "lblbonus";
            this.lblbonus.Size = new System.Drawing.Size(40, 13);
            this.lblbonus.TabIndex = 9;
            this.lblbonus.Text = "Bonus:";
            // 
            // lblNetSalary
            // 
            this.lblNetSalary.AutoSize = true;
            this.lblNetSalary.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNetSalary.Location = new System.Drawing.Point(356, 266);
            this.lblNetSalary.Name = "lblNetSalary";
            this.lblNetSalary.Size = new System.Drawing.Size(59, 13);
            this.lblNetSalary.TabIndex = 10;
            this.lblNetSalary.Text = "Net Salary:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Yellow;
            this.btnCalculate.Location = new System.Drawing.Point(358, 283);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 11;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.Location = new System.Drawing.Point(359, 312);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(439, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvSalarySlips
            // 
            this.dgvSalarySlips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalarySlips.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSalarySlips.Location = new System.Drawing.Point(0, 365);
            this.dgvSalarySlips.Name = "dgvSalarySlips";
            this.dgvSalarySlips.Size = new System.Drawing.Size(983, 250);
            this.dgvSalarySlips.TabIndex = 14;
            // 
            // Netsal
            // 
            this.Netsal.Location = new System.Drawing.Point(421, 263);
            this.Netsal.Name = "Netsal";
            this.Netsal.Size = new System.Drawing.Size(100, 20);
            this.Netsal.TabIndex = 15;
            // 
            // my
            // 
            this.my.FormattingEnabled = true;
            this.my.Items.AddRange(new object[] {
            "Monthly",
            "Yearly"});
            this.my.Location = new System.Drawing.Point(581, 312);
            this.my.Name = "my";
            this.my.Size = new System.Drawing.Size(121, 21);
            this.my.TabIndex = 16;
            // 
            // lblselect
            // 
            this.lblselect.AutoSize = true;
            this.lblselect.Location = new System.Drawing.Point(578, 293);
            this.lblselect.Name = "lblselect";
            this.lblselect.Size = new System.Drawing.Size(37, 13);
            this.lblselect.TabIndex = 17;
            this.lblselect.Text = "Select";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.Location = new System.Drawing.Point(440, 312);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtfAllownce
            // 
            this.txtfAllownce.Location = new System.Drawing.Point(598, 70);
            this.txtfAllownce.Name = "txtfAllownce";
            this.txtfAllownce.Size = new System.Drawing.Size(121, 20);
            this.txtfAllownce.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(603, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Allownces:";
            // 
            // txttAllownce
            // 
            this.txttAllownce.Location = new System.Drawing.Point(598, 190);
            this.txttAllownce.Name = "txttAllownce";
            this.txttAllownce.Size = new System.Drawing.Size(121, 20);
            this.txttAllownce.TabIndex = 21;
            // 
            // txtmAllownce
            // 
            this.txtmAllownce.Location = new System.Drawing.Point(598, 135);
            this.txtmAllownce.Name = "txtmAllownce";
            this.txtmAllownce.Size = new System.Drawing.Size(121, 20);
            this.txtmAllownce.TabIndex = 22;
            // 
            // lblmAllownce
            // 
            this.lblmAllownce.AutoSize = true;
            this.lblmAllownce.Location = new System.Drawing.Point(595, 112);
            this.lblmAllownce.Name = "lblmAllownce";
            this.lblmAllownce.Size = new System.Drawing.Size(90, 13);
            this.lblmAllownce.TabIndex = 23;
            this.lblmAllownce.Text = "Medical Allownce";
            // 
            // lbltAllownce
            // 
            this.lbltAllownce.AutoSize = true;
            this.lbltAllownce.Location = new System.Drawing.Point(595, 174);
            this.lbltAllownce.Name = "lbltAllownce";
            this.lbltAllownce.Size = new System.Drawing.Size(83, 13);
            this.lbltAllownce.TabIndex = 24;
            this.lbltAllownce.Text = "Travel Allownce";
            // 
            // dtpMonthYear
            // 
            this.dtpMonthYear.Location = new System.Drawing.Point(568, 238);
            this.dtpMonthYear.Name = "dtpMonthYear";
            this.dtpMonthYear.Size = new System.Drawing.Size(200, 20);
            this.dtpMonthYear.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 342);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // frmSalarySlips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(983, 615);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpMonthYear);
            this.Controls.Add(this.lbltAllownce);
            this.Controls.Add(this.lblmAllownce);
            this.Controls.Add(this.txtmAllownce);
            this.Controls.Add(this.txttAllownce);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblselect);
            this.Controls.Add(this.my);
            this.Controls.Add(this.Netsal);
            this.Controls.Add(this.dgvSalarySlips);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblNetSalary);
            this.Controls.Add(this.lblbonus);
            this.Controls.Add(this.lblfAllownce);
            this.Controls.Add(this.lblDeductions);
            this.Controls.Add(this.lblBasic);
            this.Controls.Add(this.txtfAllownce);
            this.Controls.Add(this.txtDeductions);
            this.Controls.Add(this.txtHRA);
            this.Controls.Add(this.txtBasic);
            this.Controls.Add(this.lblEmp);
            this.Controls.Add(this.cmbEmployee);
            this.Name = "frmSalarySlips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Slips";
            this.Load += new System.EventHandler(this.frmSalarySlips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalarySlips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.TextBox txtBasic;
        private System.Windows.Forms.TextBox txtHRA;
        private System.Windows.Forms.TextBox txtDeductions;
        private System.Windows.Forms.Label lblBasic;
        private System.Windows.Forms.Label lblDeductions;
        private System.Windows.Forms.Label lblfAllownce;
        private System.Windows.Forms.Label lblbonus;
        private System.Windows.Forms.Label lblNetSalary;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvSalarySlips;
        private System.Windows.Forms.TextBox Netsal;
        private System.Windows.Forms.ComboBox my;
        private System.Windows.Forms.Label lblselect;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtfAllownce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttAllownce;
        private System.Windows.Forms.TextBox txtmAllownce;
        private System.Windows.Forms.Label lblmAllownce;
        private System.Windows.Forms.Label lbltAllownce;
        private System.Windows.Forms.DateTimePicker dtpMonthYear;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}