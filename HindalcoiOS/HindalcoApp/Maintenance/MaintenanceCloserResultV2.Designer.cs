
namespace HindalcoiOS.Maintenance
{
    partial class MaintenanceCloserResult
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
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.btnClose = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.XtraTbCtl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabresult = new DevExpress.XtraTab.XtraTabPage();
            this.DgvResult = new System.Windows.Forms.DataGridView();
            this.Mtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objactivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vmax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observationV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rsult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observationN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criticality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idrisk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActionable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XtraTbCtl)).BeginInit();
            this.XtraTbCtl.SuspendLayout();
            this.xtraTabresult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.btnClose);
            this.grpResult.Controls.Add(this.XtraTbCtl);
            this.grpResult.Location = new System.Drawing.Point(12, 3);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(1265, 450);
            this.grpResult.TabIndex = 0;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Result Details";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.BorderRadius = 14;
            this.btnClose.BorderSize = 0;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1120, 407);
            this.btnClose.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClose.Name = "btnClose";
            this.btnClose.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnClose.Size = new System.Drawing.Size(124, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Ok";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // XtraTbCtl
            // 
            this.XtraTbCtl.Location = new System.Drawing.Point(13, 27);
            this.XtraTbCtl.Name = "XtraTbCtl";
            this.XtraTbCtl.SelectedTabPage = this.xtraTabresult;
            this.XtraTbCtl.Size = new System.Drawing.Size(1232, 367);
            this.XtraTbCtl.TabIndex = 0;
            this.XtraTbCtl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabresult,
            this.xtraTabPage2});
            this.XtraTbCtl.Visible = false;
            // 
            // xtraTabresult
            // 
            this.xtraTabresult.Controls.Add(this.DgvResult);
            this.xtraTabresult.Name = "xtraTabresult";
            this.xtraTabresult.Size = new System.Drawing.Size(1230, 337);
            this.xtraTabresult.Text = "Maintenance Final Result";
            // 
            // DgvResult
            // 
            this.DgvResult.AllowUserToAddRows = false;
            this.DgvResult.AllowUserToDeleteRows = false;
            this.DgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvResult.ColumnHeadersHeight = 35;
            this.DgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mtag,
            this.MachineName,
            this.objactivity,
            this.responce,
            this.Element,
            this.Vmin,
            this.Vmax,
            this.observationV,
            this.Rsult,
            this.observationN,
            this.Deviations,
            this.Remark,
            this.criticality,
            this.Idrisk,
            this.btnActionable});
            this.DgvResult.EnableHeadersVisualStyles = false;
            this.DgvResult.Location = new System.Drawing.Point(14, 10);
            this.DgvResult.Name = "DgvResult";
            this.DgvResult.RowHeadersWidth = 51;
            this.DgvResult.RowTemplate.Height = 24;
            this.DgvResult.Size = new System.Drawing.Size(1198, 308);
            this.DgvResult.TabIndex = 0;
            // 
            // Mtag
            // 
            this.Mtag.HeaderText = "Machine Tag";
            this.Mtag.MinimumWidth = 6;
            this.Mtag.Name = "Mtag";
            // 
            // MachineName
            // 
            this.MachineName.HeaderText = "Machine Name";
            this.MachineName.MinimumWidth = 6;
            this.MachineName.Name = "MachineName";
            // 
            // objactivity
            // 
            this.objactivity.HeaderText = "Activity";
            this.objactivity.MinimumWidth = 6;
            this.objactivity.Name = "objactivity";
            // 
            // responce
            // 
            this.responce.HeaderText = "Responce";
            this.responce.MinimumWidth = 6;
            this.responce.Name = "responce";
            // 
            // Element
            // 
            this.Element.HeaderText = "Element";
            this.Element.MinimumWidth = 6;
            this.Element.Name = "Element";
            // 
            // Vmin
            // 
            this.Vmin.HeaderText = "Value Min";
            this.Vmin.MinimumWidth = 6;
            this.Vmin.Name = "Vmin";
            // 
            // Vmax
            // 
            this.Vmax.HeaderText = "Value Max";
            this.Vmax.MinimumWidth = 6;
            this.Vmax.Name = "Vmax";
            // 
            // observationV
            // 
            this.observationV.HeaderText = "Observation Value";
            this.observationV.MinimumWidth = 6;
            this.observationV.Name = "observationV";
            // 
            // Rsult
            // 
            this.Rsult.HeaderText = "Result";
            this.Rsult.MinimumWidth = 6;
            this.Rsult.Name = "Rsult";
            // 
            // observationN
            // 
            this.observationN.HeaderText = "Observation Numeric";
            this.observationN.MinimumWidth = 6;
            this.observationN.Name = "observationN";
            // 
            // Deviations
            // 
            this.Deviations.HeaderText = "Deviations";
            this.Deviations.MinimumWidth = 6;
            this.Deviations.Name = "Deviations";
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.MinimumWidth = 6;
            this.Remark.Name = "Remark";
            // 
            // criticality
            // 
            this.criticality.HeaderText = "Criticality";
            this.criticality.MinimumWidth = 6;
            this.criticality.Name = "criticality";
            // 
            // Idrisk
            // 
            this.Idrisk.HeaderText = "Identified Risk";
            this.Idrisk.MinimumWidth = 6;
            this.Idrisk.Name = "Idrisk";
            // 
            // btnActionable
            // 
            this.btnActionable.HeaderText = "Actionable";
            this.btnActionable.MinimumWidth = 6;
            this.btnActionable.Name = "btnActionable";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1230, 337);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // MaintenanceCloserResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 465);
            this.Controls.Add(this.grpResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceCloserResult";
            this.Text = "Maintenance Closer Result";
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XtraTbCtl)).EndInit();
            this.XtraTbCtl.ResumeLayout(false);
            this.xtraTabresult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpResult;
        private DevExpress.XtraTab.XtraTabControl XtraTbCtl;
        private DevExpress.XtraTab.XtraTabPage xtraTabresult;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.DataGridView DgvResult;
        private SparrowRMSControl.SparrowControl.SparrowButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn objactivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn responce;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vmax;
        private System.Windows.Forms.DataGridViewTextBoxColumn observationV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rsult;
        private System.Windows.Forms.DataGridViewTextBoxColumn observationN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deviations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn criticality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idrisk;
        private System.Windows.Forms.DataGridViewButtonColumn btnActionable;
    }
}