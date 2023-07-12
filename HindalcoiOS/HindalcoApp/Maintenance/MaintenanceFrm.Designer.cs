namespace HindalcoiOS.Maintenance
{
    partial class MaintenanceFrm
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
            this.dgvSelectAll = new System.Windows.Forms.DataGridView();
            this.txtBxMachineKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxMaintainance = new System.Windows.Forms.GroupBox();
            this.btnApply1 = new SparrowRMSControl.SparrowControl.SparrowButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectAll)).BeginInit();
            this.gbxMaintainance.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSelectAll
            // 
            this.dgvSelectAll.AllowUserToAddRows = false;
            this.dgvSelectAll.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            this.dgvSelectAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectAll.ColumnHeadersHeight = 35;
            this.dgvSelectAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtBxMachineKey,
            this.ConnectType});
            this.dgvSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectAll.EnableHeadersVisualStyles = false;
            this.dgvSelectAll.Location = new System.Drawing.Point(3, 21);
            this.dgvSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSelectAll.Name = "dgvSelectAll";
            this.dgvSelectAll.RowHeadersWidth = 51;
            this.dgvSelectAll.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSelectAll.Size = new System.Drawing.Size(648, 204);
            this.dgvSelectAll.TabIndex = 1;
            this.dgvSelectAll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectAll_CellContentClick);
            // 
            // txtBxMachineKey
            // 
            this.txtBxMachineKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.txtBxMachineKey.HeaderText = "Machine Name";
            this.txtBxMachineKey.MinimumWidth = 6;
            this.txtBxMachineKey.Name = "txtBxMachineKey";
            this.txtBxMachineKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txtBxMachineKey.Width = 109;
            // 
            // ConnectType
            // 
            this.ConnectType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ConnectType.HeaderText = "Type";
            this.ConnectType.MinimumWidth = 6;
            this.ConnectType.Name = "ConnectType";
            this.ConnectType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ConnectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConnectType.Width = 44;
            // 
            // gbxMaintainance
            // 
            this.gbxMaintainance.Controls.Add(this.dgvSelectAll);
            this.gbxMaintainance.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxMaintainance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxMaintainance.Location = new System.Drawing.Point(0, 0);
            this.gbxMaintainance.Name = "gbxMaintainance";
            this.gbxMaintainance.Size = new System.Drawing.Size(654, 228);
            this.gbxMaintainance.TabIndex = 2;
            this.gbxMaintainance.TabStop = false;
            this.gbxMaintainance.Text = "Machine PM Checklist";
            // 
            // btnApply1
            // 
            this.btnApply1.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApply1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnApply1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnApply1.BorderRadius = 14;
            this.btnApply1.BorderSize = 0;
            this.btnApply1.FlatAppearance.BorderSize = 0;
            this.btnApply1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnApply1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnApply1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply1.ForeColor = System.Drawing.Color.White;
            this.btnApply1.Location = new System.Drawing.Point(458, 236);
            this.btnApply1.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnApply1.Name = "btnApply1";
            this.btnApply1.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnApply1.Size = new System.Drawing.Size(124, 30);
            this.btnApply1.TabIndex = 4;
            this.btnApply1.Text = "Apply";
            this.btnApply1.TextColor = System.Drawing.Color.White;
            this.btnApply1.UseVisualStyleBackColor = false;
            this.btnApply1.Click += new System.EventHandler(this.btnApply1_Click);
            // 
            // MaintenanceFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 276);
            this.Controls.Add(this.btnApply1);
            this.Controls.Add(this.gbxMaintainance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MaintenanceFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectAll)).EndInit();
            this.gbxMaintainance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectAll;
        private System.Windows.Forms.GroupBox gbxMaintainance;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBxMachineKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectType;
        private SparrowRMSControl.SparrowControl.SparrowButton btnApply1;
    }
}