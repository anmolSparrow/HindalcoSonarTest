
namespace HindalcoiOS.U1FormCollection
{
    partial class ObservationFrmcs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpObser = new System.Windows.Forms.GroupBox();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.DgvObser = new System.Windows.Forms.DataGridView();
            this.MachineTagNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeResponce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criticality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendbtn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpObser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvObser)).BeginInit();
            this.SuspendLayout();
            // 
            // grpObser
            // 
            this.grpObser.Controls.Add(this.btnSave);
            this.grpObser.Controls.Add(this.DgvObser);
            this.grpObser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpObser.Location = new System.Drawing.Point(13, 12);
            this.grpObser.Name = "grpObser";
            this.grpObser.Size = new System.Drawing.Size(937, 315);
            this.grpObser.TabIndex = 0;
            this.grpObser.TabStop = false;
            this.grpObser.Text = "Machine Observation info";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderRadius = 14;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(784, 271);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(128, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Update && Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DgvObser
            // 
            this.DgvObser.AllowUserToAddRows = false;
            this.DgvObser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvObser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvObser.ColumnHeadersHeight = 35;
            this.DgvObser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvObser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineTagNo,
            this.MachineName,
            this.TypeResponce,
            this.Expected,
            this.ObservationV,
            this.Result,
            this.ValueMin,
            this.ValueMax,
            this.Deviations,
            this.Criticality,
            this.ObservationN,
            this.sendbtn});
            this.DgvObser.EnableHeadersVisualStyles = false;
            this.DgvObser.Location = new System.Drawing.Point(6, 22);
            this.DgvObser.Name = "DgvObser";
            this.DgvObser.RowHeadersWidth = 51;
            this.DgvObser.RowTemplate.Height = 24;
            this.DgvObser.Size = new System.Drawing.Size(924, 238);
            this.DgvObser.TabIndex = 0;
            this.DgvObser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvObser_CellContentClick);
            this.DgvObser.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvObser_CellEnter);
            this.DgvObser.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvObser_CellValueChanged);
            // 
            // MachineTagNo
            // 
            this.MachineTagNo.HeaderText = "Machine Tag";
            this.MachineTagNo.MinimumWidth = 6;
            this.MachineTagNo.Name = "MachineTagNo";
            this.MachineTagNo.Width = 125;
            // 
            // MachineName
            // 
            this.MachineName.HeaderText = "Machine Name";
            this.MachineName.MinimumWidth = 6;
            this.MachineName.Name = "MachineName";
            this.MachineName.Width = 125;
            // 
            // TypeResponce
            // 
            this.TypeResponce.HeaderText = "Type of Responce";
            this.TypeResponce.MinimumWidth = 6;
            this.TypeResponce.Name = "TypeResponce";
            this.TypeResponce.Width = 125;
            // 
            // Expected
            // 
            this.Expected.HeaderText = "Expected Condition";
            this.Expected.MinimumWidth = 6;
            this.Expected.Name = "Expected";
            this.Expected.Width = 125;
            // 
            // ObservationV
            // 
            this.ObservationV.HeaderText = "Observation Visual";
            this.ObservationV.MinimumWidth = 6;
            this.ObservationV.Name = "ObservationV";
            this.ObservationV.Width = 125;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.MinimumWidth = 6;
            this.Result.Name = "Result";
            this.Result.Width = 125;
            // 
            // ValueMin
            // 
            this.ValueMin.HeaderText = "Value Min";
            this.ValueMin.MinimumWidth = 6;
            this.ValueMin.Name = "ValueMin";
            this.ValueMin.Width = 125;
            // 
            // ValueMax
            // 
            this.ValueMax.HeaderText = "Value Max";
            this.ValueMax.MinimumWidth = 6;
            this.ValueMax.Name = "ValueMax";
            this.ValueMax.Width = 125;
            // 
            // Deviations
            // 
            this.Deviations.HeaderText = "Deviations";
            this.Deviations.MinimumWidth = 6;
            this.Deviations.Name = "Deviations";
            this.Deviations.Width = 125;
            // 
            // Criticality
            // 
            this.Criticality.HeaderText = "Criticality";
            this.Criticality.MinimumWidth = 6;
            this.Criticality.Name = "Criticality";
            this.Criticality.Width = 125;
            // 
            // ObservationN
            // 
            this.ObservationN.HeaderText = "Observation Numeric";
            this.ObservationN.MinimumWidth = 6;
            this.ObservationN.Name = "ObservationN";
            this.ObservationN.Width = 125;
            // 
            // sendbtn
            // 
            this.sendbtn.HeaderText = "Send for Preview";
            this.sendbtn.MinimumWidth = 6;
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Width = 125;
            // 
            // ObservationFrmcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 339);
            this.Controls.Add(this.grpObser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObservationFrmcs";
            this.Text = "Observation Form";
            this.Load += new System.EventHandler(this.ObservationFrmcs_Load);
            this.grpObser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvObser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpObser;
        private System.Windows.Forms.DataGridView DgvObser;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTagNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeResponce;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deviations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criticality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationN;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendbtn;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
    }
}