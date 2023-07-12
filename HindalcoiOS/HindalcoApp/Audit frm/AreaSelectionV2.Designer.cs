
namespace HindalcoiOS.Audit_frm
{
    partial class AreaSelection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxMachineArea = new System.Windows.Forms.GroupBox();
            this.btnNewArea = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnReset = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAreaUpdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbAreaName = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblAreaOwner = new System.Windows.Forms.Label();
            this.cmbAreaOwner = new CheckComboBoxTest.CheckedComboBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.gbxArea = new System.Windows.Forms.GroupBox();
            this.DgvAreaMaster = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxMachineArea.SuspendLayout();
            this.gbxArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAreaMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxMachineArea
            // 
            this.gbxMachineArea.Controls.Add(this.btnNewArea);
            this.gbxMachineArea.Controls.Add(this.btnReset);
            this.gbxMachineArea.Controls.Add(this.btnAreaUpdate);
            this.gbxMachineArea.Controls.Add(this.cmbAreaName);
            this.gbxMachineArea.Controls.Add(this.lblAreaOwner);
            this.gbxMachineArea.Controls.Add(this.cmbAreaOwner);
            this.gbxMachineArea.Controls.Add(this.lblAreaName);
            this.gbxMachineArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxMachineArea.Location = new System.Drawing.Point(20, 4);
            this.gbxMachineArea.Name = "gbxMachineArea";
            this.gbxMachineArea.Size = new System.Drawing.Size(802, 130);
            this.gbxMachineArea.TabIndex = 0;
            this.gbxMachineArea.TabStop = false;
            this.gbxMachineArea.Text = "Machine Area Details";
            // 
            // btnNewArea
            // 
            this.btnNewArea.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNewArea.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnNewArea.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnNewArea.BorderRadius = 14;
            this.btnNewArea.BorderSize = 0;
            this.btnNewArea.FlatAppearance.BorderSize = 0;
            this.btnNewArea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnNewArea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnNewArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewArea.ForeColor = System.Drawing.Color.White;
            this.btnNewArea.Location = new System.Drawing.Point(233, 78);
            this.btnNewArea.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnNewArea.Name = "btnNewArea";
            this.btnNewArea.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnNewArea.Size = new System.Drawing.Size(106, 29);
            this.btnNewArea.TabIndex = 9;
            this.btnNewArea.Text = "New Area";
            this.btnNewArea.TextColor = System.Drawing.Color.White;
            this.btnNewArea.UseVisualStyleBackColor = false;
            this.btnNewArea.Click += new System.EventHandler(this.btnNewArea_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.BorderRadius = 14;
            this.btnReset.BorderSize = 0;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(668, 86);
            this.btnReset.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.Name = "btnReset";
            this.btnReset.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReset.Size = new System.Drawing.Size(106, 29);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.TextColor = System.Drawing.Color.White;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAreaUpdate
            // 
            this.btnAreaUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAreaUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAreaUpdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAreaUpdate.BorderRadius = 14;
            this.btnAreaUpdate.BorderSize = 0;
            this.btnAreaUpdate.FlatAppearance.BorderSize = 0;
            this.btnAreaUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAreaUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAreaUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAreaUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAreaUpdate.ForeColor = System.Drawing.Color.White;
            this.btnAreaUpdate.Location = new System.Drawing.Point(556, 86);
            this.btnAreaUpdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAreaUpdate.Name = "btnAreaUpdate";
            this.btnAreaUpdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAreaUpdate.Size = new System.Drawing.Size(106, 29);
            this.btnAreaUpdate.TabIndex = 7;
            this.btnAreaUpdate.Text = "Add/Update";
            this.btnAreaUpdate.TextColor = System.Drawing.Color.White;
            this.btnAreaUpdate.UseVisualStyleBackColor = false;
            this.btnAreaUpdate.Click += new System.EventHandler(this.btnAreaUpdate_Click);
            // 
            // cmbAreaName
            // 
            this.cmbAreaName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbAreaName.BorderSize = 0;
            this.cmbAreaName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAreaName.FormattingEnabled = true;
            this.cmbAreaName.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbAreaName.ListBackColor = System.Drawing.Color.Red;
            this.cmbAreaName.ListTextColor = System.Drawing.Color.White;
            this.cmbAreaName.Location = new System.Drawing.Point(129, 35);
            this.cmbAreaName.Name = "cmbAreaName";
            this.cmbAreaName.Size = new System.Drawing.Size(210, 33);
            this.cmbAreaName.TabIndex = 7;
            // 
            // lblAreaOwner
            // 
            this.lblAreaOwner.AutoSize = true;
            this.lblAreaOwner.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaOwner.Location = new System.Drawing.Point(452, 41);
            this.lblAreaOwner.Name = "lblAreaOwner";
            this.lblAreaOwner.Size = new System.Drawing.Size(85, 18);
            this.lblAreaOwner.TabIndex = 4;
            this.lblAreaOwner.Text = "Area Owner";
            // 
            // cmbAreaOwner
            // 
            this.cmbAreaOwner.CheckOnClick = true;
            this.cmbAreaOwner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbAreaOwner.DropDownHeight = 1;
            this.cmbAreaOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAreaOwner.ForeColor = System.Drawing.Color.DimGray;
            this.cmbAreaOwner.IntegralHeight = false;
            this.cmbAreaOwner.ItemHeight = 22;
            this.cmbAreaOwner.Location = new System.Drawing.Point(556, 35);
            this.cmbAreaOwner.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbAreaOwner.Name = "cmbAreaOwner";
            this.cmbAreaOwner.Size = new System.Drawing.Size(218, 28);
            this.cmbAreaOwner.TabIndex = 3;
            this.cmbAreaOwner.ValueSeparator = ", ";
            this.cmbAreaOwner.Click += new System.EventHandler(this.cmbAreaOwner_SelectedIndexChanged);
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaName.Location = new System.Drawing.Point(32, 38);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(82, 18);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "Area Name";
            // 
            // gbxArea
            // 
            this.gbxArea.Controls.Add(this.DgvAreaMaster);
            this.gbxArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxArea.Location = new System.Drawing.Point(12, 142);
            this.gbxArea.Name = "gbxArea";
            this.gbxArea.Size = new System.Drawing.Size(815, 214);
            this.gbxArea.TabIndex = 1;
            this.gbxArea.TabStop = false;
            this.gbxArea.Text = "Area Details";
            // 
            // DgvAreaMaster
            // 
            this.DgvAreaMaster.AllowUserToAddRows = false;
            this.DgvAreaMaster.AllowUserToDeleteRows = false;
            this.DgvAreaMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAreaMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvAreaMaster.ColumnHeadersHeight = 35;
            this.DgvAreaMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvAreaMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.AreaName,
            this.AreaOwner});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAreaMaster.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvAreaMaster.EnableHeadersVisualStyles = false;
            this.DgvAreaMaster.Location = new System.Drawing.Point(13, 22);
            this.DgvAreaMaster.Name = "DgvAreaMaster";
            this.DgvAreaMaster.ReadOnly = true;
            this.DgvAreaMaster.RowHeadersVisible = false;
            this.DgvAreaMaster.RowHeadersWidth = 51;
            this.DgvAreaMaster.RowTemplate.Height = 24;
            this.DgvAreaMaster.Size = new System.Drawing.Size(790, 176);
            this.DgvAreaMaster.TabIndex = 0;
            this.DgvAreaMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAreaMaster_CellDoubleClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.MinimumWidth = 2;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AreaName
            // 
            this.AreaName.HeaderText = "Area Name";
            this.AreaName.MinimumWidth = 6;
            this.AreaName.Name = "AreaName";
            this.AreaName.ReadOnly = true;
            // 
            // AreaOwner
            // 
            this.AreaOwner.HeaderText = "Area Owner";
            this.AreaOwner.MinimumWidth = 6;
            this.AreaOwner.Name = "AreaOwner";
            this.AreaOwner.ReadOnly = true;
            // 
            // AreaSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 368);
            this.Controls.Add(this.gbxArea);
            this.Controls.Add(this.gbxMachineArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreaSelection";
            this.Text = "Area Selection";
            this.Load += new System.EventHandler(this.AreaSelection_Load);
            this.gbxMachineArea.ResumeLayout(false);
            this.gbxMachineArea.PerformLayout();
            this.gbxArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAreaMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMachineArea;
        private System.Windows.Forms.GroupBox gbxArea;
        private CheckComboBoxTest.CheckedComboBox cmbAreaOwner;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.DataGridView DgvAreaMaster;
       
        private System.Windows.Forms.Label lblAreaOwner;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAreaUpdate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnReset;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbAreaName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnNewArea;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaOwner;
    }
}