
namespace HindalcoiOS.Configuration
{
    partial class EmployeeMasterFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvMasterView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFinder = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnUserMaster = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMasterView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DgvMasterView);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 347);
            this.panel1.TabIndex = 0;
            // 
            // DgvMasterView
            // 
            this.DgvMasterView.AllowUserToAddRows = false;
            this.DgvMasterView.AllowUserToOrderColumns = true;
            this.DgvMasterView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMasterView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMasterView.ColumnHeadersHeight = 35;
            this.DgvMasterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvMasterView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.ViewTask});
            this.DgvMasterView.EnableHeadersVisualStyles = false;
            this.DgvMasterView.Location = new System.Drawing.Point(4, 4);
            this.DgvMasterView.Name = "DgvMasterView";
            this.DgvMasterView.RowHeadersWidth = 51;
            this.DgvMasterView.RowTemplate.Height = 24;
            this.DgvMasterView.Size = new System.Drawing.Size(999, 340);
            this.DgvMasterView.TabIndex = 0;
            this.DgvMasterView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMasterView_CellContentClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            // 
            // ViewTask
            // 
            this.ViewTask.HeaderText = "View Task";
            this.ViewTask.MinimumWidth = 6;
            this.ViewTask.Name = "ViewTask";
            this.ViewTask.Visible = false;
            // 
            // btnFinder
            // 
            this.btnFinder.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinder.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnFinder.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFinder.BorderRadius = 14;
            this.btnFinder.BorderSize = 0;
            this.btnFinder.FlatAppearance.BorderSize = 0;
            this.btnFinder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnFinder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnFinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinder.ForeColor = System.Drawing.Color.White;
            this.btnFinder.Location = new System.Drawing.Point(762, 375);
            this.btnFinder.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnFinder.Name = "btnFinder";
            this.btnFinder.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnFinder.Size = new System.Drawing.Size(124, 30);
            this.btnFinder.TabIndex = 1;
            this.btnFinder.Text = "Add Employee";
            this.btnFinder.TextColor = System.Drawing.Color.White;
            this.btnFinder.UseVisualStyleBackColor = false;
            this.btnFinder.Click += new System.EventHandler(this.btnFinder_Click);
            // 
            // btnUserMaster
            // 
            this.btnUserMaster.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUserMaster.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUserMaster.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUserMaster.BorderRadius = 14;
            this.btnUserMaster.BorderSize = 0;
            this.btnUserMaster.FlatAppearance.BorderSize = 0;
            this.btnUserMaster.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUserMaster.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUserMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserMaster.ForeColor = System.Drawing.Color.White;
            this.btnUserMaster.Location = new System.Drawing.Point(892, 375);
            this.btnUserMaster.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUserMaster.Name = "btnUserMaster";
            this.btnUserMaster.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUserMaster.Size = new System.Drawing.Size(124, 30);
            this.btnUserMaster.TabIndex = 2;
            this.btnUserMaster.Text = "Add User";
            this.btnUserMaster.TextColor = System.Drawing.Color.White;
            this.btnUserMaster.UseVisualStyleBackColor = false;
            this.btnUserMaster.Click += new System.EventHandler(this.btnUserMaster_Click);
            // 
            // EmployeeMasterFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 415);
            this.Controls.Add(this.btnUserMaster);
            this.Controls.Add(this.btnFinder);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeMasterFrm";
            this.Text = "Employee Master";
            this.Load += new System.EventHandler(this.EmployeeMasterFrm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMasterView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvMasterView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ViewTask;
        private SparrowRMSControl.SparrowControl.SparrowButton btnFinder;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUserMaster;
    }
}