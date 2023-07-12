
namespace HindalcoiOS.Maintenance
{
    partial class MaintenanceStatus
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
            this.DgvCloser = new System.Windows.Forms.DataGridView();
            this.MachineTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShutDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreezDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCloser)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvCloser
            // 
            this.DgvCloser.AllowUserToAddRows = false;
            this.DgvCloser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCloser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCloser.ColumnHeadersHeight = 35;
            this.DgvCloser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvCloser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineTag,
            this.MachineName,
            this.Frequency,
            this.ShutDown,
            this.Resource,
            this.Activity,
            this.FreezDate,
            this.CloseDate,
            this.Priority});
            this.DgvCloser.EnableHeadersVisualStyles = false;
            this.DgvCloser.Location = new System.Drawing.Point(12, 12);
            this.DgvCloser.Name = "DgvCloser";
            this.DgvCloser.ReadOnly = true;
            this.DgvCloser.RowHeadersWidth = 51;
            this.DgvCloser.RowTemplate.Height = 24;
            this.DgvCloser.Size = new System.Drawing.Size(1037, 323);
            this.DgvCloser.TabIndex = 0;
            // 
            // MachineTag
            // 
            this.MachineTag.HeaderText = "Machine Tag";
            this.MachineTag.MinimumWidth = 6;
            this.MachineTag.Name = "MachineTag";
            this.MachineTag.ReadOnly = true;
            this.MachineTag.Width = 125;
            // 
            // MachineName
            // 
            this.MachineName.HeaderText = "Machine Name";
            this.MachineName.MinimumWidth = 6;
            this.MachineName.Name = "MachineName";
            this.MachineName.ReadOnly = true;
            this.MachineName.Width = 125;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MinimumWidth = 6;
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Width = 125;
            // 
            // ShutDown
            // 
            this.ShutDown.HeaderText = "ShutDown";
            this.ShutDown.MinimumWidth = 6;
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.ReadOnly = true;
            this.ShutDown.Width = 125;
            // 
            // Resource
            // 
            this.Resource.HeaderText = "Resource";
            this.Resource.MinimumWidth = 6;
            this.Resource.Name = "Resource";
            this.Resource.ReadOnly = true;
            this.Resource.Width = 125;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Activity";
            this.Activity.MinimumWidth = 6;
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            this.Activity.Width = 125;
            // 
            // FreezDate
            // 
            this.FreezDate.HeaderText = "Freeze Date";
            this.FreezDate.MinimumWidth = 6;
            this.FreezDate.Name = "FreezDate";
            this.FreezDate.ReadOnly = true;
            this.FreezDate.Width = 125;
            // 
            // CloseDate
            // 
            this.CloseDate.HeaderText = "Close Date";
            this.CloseDate.MinimumWidth = 6;
            this.CloseDate.Name = "CloseDate";
            this.CloseDate.ReadOnly = true;
            this.CloseDate.Width = 125;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 125;
            // 
            // MaintenanceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 347);
            this.Controls.Add(this.DgvCloser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceStatus";
            this.Text = "Maintenance Status";
            ((System.ComponentModel.ISupportInitialize)(this.DgvCloser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvCloser;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShutDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreezDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
    }
}