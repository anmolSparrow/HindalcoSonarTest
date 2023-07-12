
namespace HindalcoiOS.U1FormCollection
{
    partial class AddNewTrainingFrm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpAddtrn = new System.Windows.Forms.GroupBox();
            this.DGVAddtrn = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dptname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trntitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trntype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drtion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prvty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vanue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resorce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpblty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsend = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpsts = new System.Windows.Forms.GroupBox();
            this.DgvStatus = new System.Windows.Forms.DataGridView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.AddTrainingctx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpAddtrn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAddtrn)).BeginInit();
            this.grpsts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).BeginInit();
            this.AddTrainingctx.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddtrn
            // 
            this.grpAddtrn.Controls.Add(this.DGVAddtrn);
            this.grpAddtrn.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddtrn.Location = new System.Drawing.Point(13, 13);
            this.grpAddtrn.Name = "grpAddtrn";
            this.grpAddtrn.Size = new System.Drawing.Size(920, 274);
            this.grpAddtrn.TabIndex = 0;
            this.grpAddtrn.TabStop = false;
            this.grpAddtrn.Text = "Add New Training";
            // 
            // DGVAddtrn
            // 
            this.DGVAddtrn.AllowUserToAddRows = false;
            this.DGVAddtrn.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAddtrn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAddtrn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAddtrn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.empname,
            this.empid,
            this.Dptname,
            this.trntitle,
            this.trntype,
            this.drtion,
            this.prvty,
            this.frmdate,
            this.endDate,
            this.vanue,
            this.resorce,
            this.cpblty});
            this.DGVAddtrn.Location = new System.Drawing.Point(7, 23);
            this.DGVAddtrn.Name = "DGVAddtrn";
            this.DGVAddtrn.RowHeadersWidth = 51;
            this.DGVAddtrn.RowTemplate.Height = 24;
            this.DGVAddtrn.Size = new System.Drawing.Size(907, 245);
            this.DGVAddtrn.TabIndex = 0;
            // 
            // SrNo
            // 
            this.SrNo.HeaderText = "Sr No.";
            this.SrNo.MinimumWidth = 6;
            this.SrNo.Name = "SrNo";
            this.SrNo.Width = 125;
            // 
            // empname
            // 
            this.empname.HeaderText = "Employee Name";
            this.empname.MinimumWidth = 6;
            this.empname.Name = "empname";
            this.empname.Width = 125;
            // 
            // empid
            // 
            this.empid.HeaderText = "Employee ID";
            this.empid.MinimumWidth = 6;
            this.empid.Name = "empid";
            this.empid.Width = 125;
            // 
            // Dptname
            // 
            this.Dptname.HeaderText = "Department Name";
            this.Dptname.MinimumWidth = 6;
            this.Dptname.Name = "Dptname";
            this.Dptname.Width = 125;
            // 
            // trntitle
            // 
            this.trntitle.HeaderText = "Training Title";
            this.trntitle.MinimumWidth = 6;
            this.trntitle.Name = "trntitle";
            this.trntitle.Width = 125;
            // 
            // trntype
            // 
            this.trntype.HeaderText = "Training Type";
            this.trntype.MinimumWidth = 6;
            this.trntype.Name = "trntype";
            this.trntype.Width = 125;
            // 
            // drtion
            // 
            this.drtion.HeaderText = "Duration";
            this.drtion.MinimumWidth = 6;
            this.drtion.Name = "drtion";
            this.drtion.Width = 125;
            // 
            // prvty
            // 
            this.prvty.HeaderText = "Priority";
            this.prvty.MinimumWidth = 6;
            this.prvty.Name = "prvty";
            this.prvty.Width = 125;
            // 
            // frmdate
            // 
            this.frmdate.HeaderText = "Training Start Date";
            this.frmdate.MinimumWidth = 6;
            this.frmdate.Name = "frmdate";
            this.frmdate.Width = 125;
            // 
            // endDate
            // 
            this.endDate.HeaderText = "Training Upto";
            this.endDate.MinimumWidth = 6;
            this.endDate.Name = "endDate";
            this.endDate.Width = 125;
            // 
            // vanue
            // 
            this.vanue.HeaderText = "Venue";
            this.vanue.MinimumWidth = 6;
            this.vanue.Name = "vanue";
            this.vanue.Width = 125;
            // 
            // resorce
            // 
            this.resorce.HeaderText = "Resource";
            this.resorce.MinimumWidth = 6;
            this.resorce.Name = "resorce";
            this.resorce.Width = 125;
            // 
            // cpblty
            // 
            this.cpblty.HeaderText = "Capability";
            this.cpblty.MinimumWidth = 6;
            this.cpblty.Name = "cpblty";
            this.cpblty.Width = 125;
            // 
            // btnsend
            // 
            this.btnsend.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnsend.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnsend.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnsend.BorderRadius = 14;
            this.btnsend.BorderSize = 0;
            this.btnsend.FlatAppearance.BorderSize = 0;
            this.btnsend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsend.ForeColor = System.Drawing.Color.White;
            this.btnsend.Location = new System.Drawing.Point(803, 293);
            this.btnsend.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsend.Name = "btnsend";
            this.btnsend.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsend.Size = new System.Drawing.Size(124, 32);
            this.btnsend.TabIndex = 1;
            this.btnsend.Text = "Notify";
            this.btnsend.TextColor = System.Drawing.Color.White;
            this.btnsend.UseVisualStyleBackColor = false;
            // 
            // grpsts
            // 
            this.grpsts.Controls.Add(this.DgvStatus);
            this.grpsts.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpsts.Location = new System.Drawing.Point(13, 348);
            this.grpsts.Name = "grpsts";
            this.grpsts.Size = new System.Drawing.Size(919, 205);
            this.grpsts.TabIndex = 2;
            this.grpsts.TabStop = false;
            this.grpsts.Text = "Training Status";
            // 
            // DgvStatus
            // 
            this.DgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStatus.Location = new System.Drawing.Point(7, 23);
            this.DgvStatus.Name = "DgvStatus";
            this.DgvStatus.RowHeadersWidth = 51;
            this.DgvStatus.RowTemplate.Height = 24;
            this.DgvStatus.Size = new System.Drawing.Size(906, 176);
            this.DgvStatus.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(644, 559);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 3;
            // 
            // AddTrainingctx
            // 
            this.AddTrainingctx.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AddTrainingctx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.AddTrainingctx.Name = "AddTrainingctx";
            this.AddTrainingctx.Size = new System.Drawing.Size(141, 52);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.addNewToolStripMenuItem.Text = "Add New";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // AddNewTrainingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 647);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.grpsts);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.grpAddtrn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddNewTrainingFrm";
            this.Text = "Add New Training";
            this.grpAddtrn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAddtrn)).EndInit();
            this.grpsts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).EndInit();
            this.AddTrainingctx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddtrn;
        private System.Windows.Forms.DataGridView DGVAddtrn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn empname;
        private System.Windows.Forms.DataGridViewTextBoxColumn empid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dptname;
        private System.Windows.Forms.DataGridViewTextBoxColumn trntitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn trntype;
        private System.Windows.Forms.DataGridViewTextBoxColumn drtion;
        private System.Windows.Forms.DataGridViewTextBoxColumn prvty;
        private System.Windows.Forms.DataGridViewTextBoxColumn frmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn vanue;
        private System.Windows.Forms.DataGridViewTextBoxColumn resorce;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpblty;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsend;
        private System.Windows.Forms.GroupBox grpsts;
        private System.Windows.Forms.DataGridView DgvStatus;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ContextMenuStrip AddTrainingctx;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}