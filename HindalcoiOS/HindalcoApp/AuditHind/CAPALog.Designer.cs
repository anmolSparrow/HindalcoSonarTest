
namespace Hind.AuditMgmt
{
    partial class CAPALog
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
            this.gbxViewVendor = new System.Windows.Forms.GroupBox();
            this.dgvViewDeptMaster = new System.Windows.Forms.DataGridView();
            this.ObsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPAUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPAAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREVAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxViewVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDeptMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxViewVendor
            // 
            this.gbxViewVendor.Controls.Add(this.dgvViewDeptMaster);
            this.gbxViewVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxViewVendor.Location = new System.Drawing.Point(12, 12);
            this.gbxViewVendor.Name = "gbxViewVendor";
            this.gbxViewVendor.Size = new System.Drawing.Size(750, 187);
            this.gbxViewVendor.TabIndex = 50;
            this.gbxViewVendor.TabStop = false;
            this.gbxViewVendor.Text = "View All";
            // 
            // dgvViewDeptMaster
            // 
            this.dgvViewDeptMaster.AllowUserToAddRows = false;
            this.dgvViewDeptMaster.AllowUserToDeleteRows = false;
            this.dgvViewDeptMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewDeptMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewDeptMaster.ColumnHeadersHeight = 35;
            this.dgvViewDeptMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewDeptMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObsCode,
            this.CreatedDate,
            this.CAPAUser,
            this.CAPAAction,
            this.PREVAction});
            this.dgvViewDeptMaster.EnableHeadersVisualStyles = false;
            this.dgvViewDeptMaster.Location = new System.Drawing.Point(18, 25);
            this.dgvViewDeptMaster.Name = "dgvViewDeptMaster";
            this.dgvViewDeptMaster.ReadOnly = true;
            this.dgvViewDeptMaster.RowHeadersVisible = false;
            this.dgvViewDeptMaster.RowHeadersWidth = 51;
            this.dgvViewDeptMaster.RowTemplate.Height = 24;
            this.dgvViewDeptMaster.Size = new System.Drawing.Size(699, 144);
            this.dgvViewDeptMaster.TabIndex = 0;
            //this.dgvViewDeptMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewDeptMaster_CellDoubleClick);
            // 
            // ObsCode
            // 
            this.ObsCode.HeaderText = "ObsCode";
            this.ObsCode.MinimumWidth = 6;
            this.ObsCode.Name = "ObsCode";
            this.ObsCode.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // CAPAUser
            // 
            this.CAPAUser.HeaderText = "CAPAUser";
            this.CAPAUser.MinimumWidth = 6;
            this.CAPAUser.Name = "CAPAUser";
            this.CAPAUser.ReadOnly = true;
            // 
            // CAPAAction
            // 
            this.CAPAAction.HeaderText = "CorrAction";
            this.CAPAAction.MinimumWidth = 6;
            this.CAPAAction.Name = "CAPAAction";
            this.CAPAAction.ReadOnly = true;
            // 
            // PREVAction
            // 
            this.PREVAction.HeaderText = "PREVAction";
            this.PREVAction.MinimumWidth = 6;
            this.PREVAction.Name = "PREVAction";
            this.PREVAction.ReadOnly = true;
            // 
            // CAPALog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 220);
            this.Controls.Add(this.gbxViewVendor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CAPALog";
            this.Text = "CAPA Log";
            //this.Load += new System.EventHandler(this.Department_Load);
            this.gbxViewVendor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDeptMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxViewVendor;
        private System.Windows.Forms.DataGridView dgvViewDeptMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObsCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAPAUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAPAAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn PREVAction;
    }
}