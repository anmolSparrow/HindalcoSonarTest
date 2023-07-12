
namespace HindalcoiOS.Audit_frm
{
    partial class AuditReportDisplay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpreport = new System.Windows.Forms.GroupBox();
            this.controlAuditPages = new SparrowRMSControl.SparrowControl.SparrowTabControl();
            this.pgAudit = new System.Windows.Forms.TabPage();
            this.DgvReport = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.pgCapa = new System.Windows.Forms.TabPage();
            this.DGVCapa = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.btnok = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAuditRptCAPA = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAuditRptDetail = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpreport.SuspendLayout();
            this.controlAuditPages.SuspendLayout();
            this.pgAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).BeginInit();
            this.pgCapa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpreport
            // 
            this.grpreport.Controls.Add(this.btnAuditRptCAPA);
            this.grpreport.Controls.Add(this.btnAuditRptDetail);
            this.grpreport.Controls.Add(this.controlAuditPages);
            this.grpreport.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpreport.Location = new System.Drawing.Point(12, 12);
            this.grpreport.Name = "grpreport";
            this.grpreport.Size = new System.Drawing.Size(1074, 311);
            this.grpreport.TabIndex = 0;
            this.grpreport.TabStop = false;
            this.grpreport.Text = "Audit View Report";
            // 
            // controlAuditPages
            // 
            this.controlAuditPages.Controls.Add(this.pgAudit);
            this.controlAuditPages.Controls.Add(this.pgCapa);
            // 
            // 
            // 
            this.controlAuditPages.DisplayStyleProvider.BlendStyle = SparrowRMSControl.SparrowControl.BlendStyle.Normal;
            this.controlAuditPages.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.controlAuditPages.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.controlAuditPages.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.controlAuditPages.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.controlAuditPages.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorFocused = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorSelected = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.controlAuditPages.DisplayStyleProvider.FocusTrack = false;
            this.controlAuditPages.DisplayStyleProvider.HotTrack = true;
            this.controlAuditPages.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.controlAuditPages.DisplayStyleProvider.Opacity = 1F;
            this.controlAuditPages.DisplayStyleProvider.Overlap = 0;
            this.controlAuditPages.DisplayStyleProvider.Padding = new System.Drawing.Point(22, 4);
            this.controlAuditPages.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.Color.DodgerBlue;
            this.controlAuditPages.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.controlAuditPages.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.controlAuditPages.DisplayStyleProvider.ShowTabCloser = false;
            this.controlAuditPages.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.TabColorFocused1 = System.Drawing.Color.DodgerBlue;
            this.controlAuditPages.DisplayStyleProvider.TabColorFocused2 = System.Drawing.Color.DodgerBlue;
            this.controlAuditPages.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.controlAuditPages.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.controlAuditPages.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.controlAuditPages.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(0);
            this.controlAuditPages.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.controlAuditPages.DisplayStyleProvider.TextColorFocused = System.Drawing.Color.White;
            this.controlAuditPages.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.controlAuditPages.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.controlAuditPages.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.controlAuditPages.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.controlAuditPages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlAuditPages.HotTrack = true;
            this.controlAuditPages.Location = new System.Drawing.Point(15, 59);
            this.controlAuditPages.Name = "controlAuditPages";
            this.controlAuditPages.SelectedIndex = 0;
            this.controlAuditPages.SelectTabColor = System.Drawing.Color.DodgerBlue;
            this.controlAuditPages.SelectTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.controlAuditPages.Size = new System.Drawing.Size(1045, 240);
            this.controlAuditPages.TabColor = System.Drawing.Color.DodgerBlue;
            this.controlAuditPages.TabIndex = 0;
            // 
            // pgAudit
            // 
            this.pgAudit.Controls.Add(this.DgvReport);
            this.pgAudit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pgAudit.Location = new System.Drawing.Point(4, 32);
            this.pgAudit.Name = "pgAudit";
            this.pgAudit.Padding = new System.Windows.Forms.Padding(3);
            this.pgAudit.Size = new System.Drawing.Size(1037, 204);
            this.pgAudit.TabIndex = 0;
            this.pgAudit.Text = "Audit Report Details";
            this.pgAudit.UseVisualStyleBackColor = true;
            // 
            // DgvReport
            // 
            this.DgvReport.AllowUserToAddRows = false;
            this.DgvReport.AllowUserToDeleteRows = false;
            this.DgvReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.DgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReport.ColumnNameToSum = null;
            this.DgvReport.ColumnSum = 0D;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvReport.DefaultCellStyle = dataGridViewCellStyle27;
            this.DgvReport.EnableColumnSumming = false;
            this.DgvReport.EnableHeadersVisualStyles = false;
            this.DgvReport.Location = new System.Drawing.Point(6, 6);
            this.DgvReport.MultiSelect = false;
            this.DgvReport.Name = "DgvReport";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.DgvReport.RowHeadersVisible = false;
            this.DgvReport.RowHeadersWidth = 51;
            this.DgvReport.RowTemplate.Height = 24;
            this.DgvReport.Size = new System.Drawing.Size(1023, 195);
            this.DgvReport.TabIndex = 0;
            // 
            // pgCapa
            // 
            this.pgCapa.Controls.Add(this.DGVCapa);
            this.pgCapa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pgCapa.Location = new System.Drawing.Point(4, 32);
            this.pgCapa.Name = "pgCapa";
            this.pgCapa.Padding = new System.Windows.Forms.Padding(3);
            this.pgCapa.Size = new System.Drawing.Size(1037, 204);
            this.pgCapa.TabIndex = 1;
            this.pgCapa.Text = "CAPA";
            this.pgCapa.UseVisualStyleBackColor = true;
            // 
            // DGVCapa
            // 
            this.DGVCapa.AllowUserToAddRows = false;
            this.DGVCapa.AllowUserToDeleteRows = false;
            this.DGVCapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVCapa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCapa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.DGVCapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCapa.ColumnNameToSum = null;
            this.DGVCapa.ColumnSum = 0D;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCapa.DefaultCellStyle = dataGridViewCellStyle30;
            this.DGVCapa.EnableColumnSumming = false;
            this.DGVCapa.EnableHeadersVisualStyles = false;
            this.DGVCapa.Location = new System.Drawing.Point(6, 6);
            this.DGVCapa.MultiSelect = false;
            this.DGVCapa.Name = "DGVCapa";
            this.DGVCapa.RowHeadersVisible = false;
            this.DGVCapa.RowHeadersWidth = 51;
            this.DGVCapa.RowTemplate.Height = 24;
            this.DGVCapa.Size = new System.Drawing.Size(1023, 195);
            this.DGVCapa.TabIndex = 1;
            // 
            // btnok
            // 
            this.btnok.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnok.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnok.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnok.BorderRadius = 15;
            this.btnok.BorderSize = 0;
            this.btnok.FlatAppearance.BorderSize = 0;
            this.btnok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnok.ForeColor = System.Drawing.Color.White;
            this.btnok.Location = new System.Drawing.Point(909, 332);
            this.btnok.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnok.Name = "btnok";
            this.btnok.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnok.Size = new System.Drawing.Size(143, 31);
            this.btnok.TabIndex = 1;
            this.btnok.Text = "OK";
            this.btnok.TextColor = System.Drawing.Color.White;
            this.btnok.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 335);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 125);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnAuditRptCAPA
            // 
            this.btnAuditRptCAPA.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditRptCAPA.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditRptCAPA.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditRptCAPA.BorderRadius = 15;
            this.btnAuditRptCAPA.BorderSize = 0;
            this.btnAuditRptCAPA.FlatAppearance.BorderSize = 0;
            this.btnAuditRptCAPA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAuditRptCAPA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAuditRptCAPA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditRptCAPA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAuditRptCAPA.ForeColor = System.Drawing.Color.White;
            this.btnAuditRptCAPA.Location = new System.Drawing.Point(229, 22);
            this.btnAuditRptCAPA.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAuditRptCAPA.Name = "btnAuditRptCAPA";
            this.btnAuditRptCAPA.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAuditRptCAPA.Size = new System.Drawing.Size(143, 30);
            this.btnAuditRptCAPA.TabIndex = 3;
            this.btnAuditRptCAPA.Text = "CAPA";
            this.btnAuditRptCAPA.TextColor = System.Drawing.Color.White;
            this.btnAuditRptCAPA.UseVisualStyleBackColor = false;
            this.btnAuditRptCAPA.Click += new System.EventHandler(this.btnAuditRptCAPA_Click);
            // 
            // btnAuditRptDetail
            // 
            this.btnAuditRptDetail.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditRptDetail.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditRptDetail.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAuditRptDetail.BorderRadius = 15;
            this.btnAuditRptDetail.BorderSize = 0;
            this.btnAuditRptDetail.FlatAppearance.BorderSize = 0;
            this.btnAuditRptDetail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAuditRptDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAuditRptDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditRptDetail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAuditRptDetail.ForeColor = System.Drawing.Color.White;
            this.btnAuditRptDetail.Location = new System.Drawing.Point(25, 24);
            this.btnAuditRptDetail.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAuditRptDetail.Name = "btnAuditRptDetail";
            this.btnAuditRptDetail.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAuditRptDetail.Size = new System.Drawing.Size(181, 30);
            this.btnAuditRptDetail.TabIndex = 4;
            this.btnAuditRptDetail.Text = "Audit Detail";
            this.btnAuditRptDetail.TextColor = System.Drawing.Color.White;
            this.btnAuditRptDetail.UseVisualStyleBackColor = false;
            this.btnAuditRptDetail.Click += new System.EventHandler(this.btnAuditRptDetail_Click);
            // 
            // AuditReportDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 470);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.grpreport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditReportDisplay";
            this.Text = "Audit Report Display";
            this.Load += new System.EventHandler(this.AuditReportDisplay_Load);
            this.grpreport.ResumeLayout(false);
            this.controlAuditPages.ResumeLayout(false);
            this.pgAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).EndInit();
            this.pgCapa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpreport;
        private SparrowRMSControl.SparrowControl.SparrowTabControl controlAuditPages;
        private System.Windows.Forms.TabPage pgAudit;
        private System.Windows.Forms.TabPage pgCapa;
        private SparrowRMSControl.SparrowControl.SparrowButton btnok;
        private System.Windows.Forms.PictureBox pictureBox1;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvReport;
        private SparrowRMSControl.SparrowControl.SparrowGrid DGVCapa;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAuditRptCAPA;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAuditRptDetail;
    }
}