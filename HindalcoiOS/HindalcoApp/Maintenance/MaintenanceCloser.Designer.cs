
using DevExpress.XtraEditors;

namespace HindalcoiOS.U1FormCollection
{
    partial class MaintenanceCloser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceCloser));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.DgvClosed = new System.Windows.Forms.DataGridView();
            this.MachineTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShutDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreezDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnClosed = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.Btnpostpont = new SparrowRMSControl.SparrowControl.SparrowButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClosed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.groupControl1.Controls.Add(this.DgvClosed);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1135, 397);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Maitenance Closer Details";
            // 
            // DgvClosed
            // 
            this.DgvClosed.AllowUserToAddRows = false;
            this.DgvClosed.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DgvClosed.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvClosed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvClosed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvClosed.ColumnHeadersHeight = 35;
            this.DgvClosed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvClosed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineTag,
            this.MachineName,
            this.Frequency,
            this.ShutDown,
            this.Resource,
            this.Activity,
            this.Priority,
            this.FreezDate});
            this.DgvClosed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvClosed.EnableHeadersVisualStyles = false;
            this.DgvClosed.Location = new System.Drawing.Point(2, 28);
            this.DgvClosed.Name = "DgvClosed";
            this.DgvClosed.ReadOnly = true;
            this.DgvClosed.RowHeadersVisible = false;
            this.DgvClosed.RowHeadersWidth = 51;
            this.DgvClosed.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvClosed.RowTemplate.Height = 24;
            this.DgvClosed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvClosed.Size = new System.Drawing.Size(1131, 367);
            this.DgvClosed.TabIndex = 0;
            this.DgvClosed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClosed_CellContentClick);
            // 
            // MachineTag
            // 
            this.MachineTag.HeaderText = "Machine Tag";
            this.MachineTag.MinimumWidth = 6;
            this.MachineTag.Name = "MachineTag";
            this.MachineTag.ReadOnly = true;
            // 
            // MachineName
            // 
            this.MachineName.HeaderText = "Machine Name";
            this.MachineName.MinimumWidth = 6;
            this.MachineName.Name = "MachineName";
            this.MachineName.ReadOnly = true;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MinimumWidth = 6;
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            // 
            // ShutDown
            // 
            this.ShutDown.HeaderText = "Shut Down Required";
            this.ShutDown.MinimumWidth = 6;
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.ReadOnly = true;
            // 
            // Resource
            // 
            this.Resource.HeaderText = "Resource";
            this.Resource.MinimumWidth = 6;
            this.Resource.Name = "Resource";
            this.Resource.ReadOnly = true;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Activity";
            this.Activity.MinimumWidth = 6;
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // FreezDate
            // 
            this.FreezDate.HeaderText = "Freez Date";
            this.FreezDate.MinimumWidth = 6;
            this.FreezDate.Name = "FreezDate";
            this.FreezDate.ReadOnly = true;
            // 
            // groupControl2
            // 
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Controls.Add(this.btnClosed);
            this.groupControl2.Controls.Add(this.Btnpostpont);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 397);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1135, 70);
            this.groupControl2.TabIndex = 1;
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClosed.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnClosed.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClosed.BorderRadius = 14;
            this.btnClosed.BorderSize = 0;
            this.btnClosed.FlatAppearance.BorderSize = 0;
            this.btnClosed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosed.ForeColor = System.Drawing.Color.White;
            this.btnClosed.Location = new System.Drawing.Point(862, 16);
            this.btnClosed.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnClosed.Size = new System.Drawing.Size(261, 30);
            this.btnClosed.TabIndex = 5;
            this.btnClosed.Tag = "2";
            this.btnClosed.Text = "Closed";
            this.btnClosed.TextColor = System.Drawing.Color.White;
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // Btnpostpont
            // 
            this.Btnpostpont.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btnpostpont.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.Btnpostpont.BorderColor = System.Drawing.Color.DodgerBlue;
            this.Btnpostpont.BorderRadius = 14;
            this.Btnpostpont.BorderSize = 0;
            this.Btnpostpont.FlatAppearance.BorderSize = 0;
            this.Btnpostpont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.Btnpostpont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.Btnpostpont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnpostpont.ForeColor = System.Drawing.Color.White;
            this.Btnpostpont.Location = new System.Drawing.Point(481, 16);
            this.Btnpostpont.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.Btnpostpont.Name = "Btnpostpont";
            this.Btnpostpont.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.Btnpostpont.Size = new System.Drawing.Size(261, 30);
            this.Btnpostpont.TabIndex = 3;
            this.Btnpostpont.Tag = "0";
            this.Btnpostpont.Text = "Postpone";
            this.Btnpostpont.TextColor = System.Drawing.Color.White;
            this.Btnpostpont.UseVisualStyleBackColor = false;
            this.Btnpostpont.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // MaintenanceCloser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 467);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MaintenanceCloser.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceCloser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaintenanceCloser";
            this.Load += new System.EventHandler(this.MaintenanceCloser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClosed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private System.Windows.Forms.DataGridView DgvClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShutDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreezDate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnClosed;
        private SparrowRMSControl.SparrowControl.SparrowButton Btnpostpont;
    }
}