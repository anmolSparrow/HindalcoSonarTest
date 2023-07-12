
namespace HindalcoiOS.U1FormCollection
{
    partial class TrainingFrm
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
            this.lbrecord = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.grptraining = new System.Windows.Forms.GroupBox();
            this.DgvLoadDetails = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnUpdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grptraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLoadDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lbrecord
            // 
            this.lbrecord.AutoSize = true;
            this.lbrecord.Depth = 0;
            this.lbrecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbrecord.Location = new System.Drawing.Point(737, 13);
            this.lbrecord.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbrecord.Name = "lbrecord";
            this.lbrecord.Size = new System.Drawing.Size(92, 17);
            this.lbrecord.TabIndex = 0;
            this.lbrecord.Text = ".....................";
            // 
            // grptraining
            // 
            this.grptraining.Controls.Add(this.DgvLoadDetails);
            this.grptraining.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptraining.Location = new System.Drawing.Point(13, 49);
            this.grptraining.Name = "grptraining";
            this.grptraining.Size = new System.Drawing.Size(873, 239);
            this.grptraining.TabIndex = 1;
            this.grptraining.TabStop = false;
            this.grptraining.Text = "Training Information";
            // 
            // DgvLoadDetails
            // 
            this.DgvLoadDetails.AllowUserToAddRows = false;
            this.DgvLoadDetails.AllowUserToDeleteRows = false;
            this.DgvLoadDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvLoadDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLoadDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvLoadDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLoadDetails.ColumnNameToSum = null;
            this.DgvLoadDetails.ColumnSum = 0D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLoadDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvLoadDetails.EnableColumnSumming = false;
            this.DgvLoadDetails.EnableHeadersVisualStyles = false;
            this.DgvLoadDetails.Location = new System.Drawing.Point(7, 23);
            this.DgvLoadDetails.MultiSelect = false;
            this.DgvLoadDetails.Name = "DgvLoadDetails";
            this.DgvLoadDetails.RowHeadersVisible = false;
            this.DgvLoadDetails.RowHeadersWidth = 51;
            this.DgvLoadDetails.RowTemplate.Height = 24;
            this.DgvLoadDetails.Size = new System.Drawing.Size(860, 210);
            this.DgvLoadDetails.TabIndex = 0;
            this.DgvLoadDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLoadDetails_CellEnter);
            this.DgvLoadDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLoadDetails_CellValueChanged);
            this.DgvLoadDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvLoadDetails_CurrentCellDirtyStateChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(509, 323);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 4);
            this.checkedListBox1.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderRadius = 14;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(711, 297);
            this.btnUpdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUpdate.Size = new System.Drawing.Size(169, 30);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update Training Info.";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // TrainingFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 352);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.grptraining);
            this.Controls.Add(this.lbrecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainingFrm";
            this.Text = "Training Form";
            this.Load += new System.EventHandler(this.TrainingFrm_Load);
            this.grptraining.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLoadDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SparrowRMSControl.SparrowControl.SparrowLabel lbrecord;
        private System.Windows.Forms.GroupBox grptraining;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvLoadDetails;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUpdate;
    }
}