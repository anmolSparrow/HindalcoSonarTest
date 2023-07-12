
namespace HindalcoiOS.U1FormCollection
{
    partial class AddMyteamtrnFrm
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
            this.grpmyteam = new System.Windows.Forms.GroupBox();
            this.DGVAddtrn = new System.Windows.Forms.DataGridView();
            this.button1 = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpsts = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.DgvStatus = new System.Windows.Forms.DataGridView();
            this.grpmyteam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAddtrn)).BeginInit();
            this.grpsts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // grpmyteam
            // 
            this.grpmyteam.Controls.Add(this.DGVAddtrn);
            this.grpmyteam.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpmyteam.Location = new System.Drawing.Point(13, 13);
            this.grpmyteam.Name = "grpmyteam";
            this.grpmyteam.Size = new System.Drawing.Size(838, 243);
            this.grpmyteam.TabIndex = 0;
            this.grpmyteam.TabStop = false;
            this.grpmyteam.Text = "Add New My Team Training";
            // 
            // DGVAddtrn
            // 
            this.DGVAddtrn.AllowUserToAddRows = false;
            this.DGVAddtrn.AllowUserToDeleteRows = false;
            this.DGVAddtrn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAddtrn.Location = new System.Drawing.Point(7, 23);
            this.DGVAddtrn.Name = "DGVAddtrn";
            this.DGVAddtrn.RowHeadersWidth = 51;
            this.DGVAddtrn.RowTemplate.Height = 24;
            this.DGVAddtrn.Size = new System.Drawing.Size(825, 214);
            this.DGVAddtrn.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.button1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.BorderRadius = 14;
            this.button1.BorderSize = 0;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(359, 263);
            this.button1.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.button1.Name = "button1";
            this.button1.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.button1.Size = new System.Drawing.Size(148, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send for Approval";
            this.button1.TextColor = System.Drawing.Color.White;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // grpsts
            // 
            this.grpsts.Controls.Add(this.checkedListBox1);
            this.grpsts.Controls.Add(this.DgvStatus);
            this.grpsts.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpsts.Location = new System.Drawing.Point(13, 312);
            this.grpsts.Name = "grpsts";
            this.grpsts.Size = new System.Drawing.Size(838, 229);
            this.grpsts.TabIndex = 2;
            this.grpsts.TabStop = false;
            this.grpsts.Text = "My Team Training Status";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(715, 129);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 1;
            // 
            // DgvStatus
            // 
            this.DgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStatus.Location = new System.Drawing.Point(7, 23);
            this.DgvStatus.Name = "DgvStatus";
            this.DgvStatus.RowHeadersWidth = 51;
            this.DgvStatus.RowTemplate.Height = 24;
            this.DgvStatus.Size = new System.Drawing.Size(825, 200);
            this.DgvStatus.TabIndex = 0;
            // 
            // AddMyteamtrnFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 553);
            this.Controls.Add(this.grpsts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpmyteam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddMyteamtrnFrm";
            this.Text = "Add My team trn Form";
            this.grpmyteam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAddtrn)).EndInit();
            this.grpsts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpmyteam;
        private SparrowRMSControl.SparrowControl.SparrowButton button1;
        private System.Windows.Forms.GroupBox grpsts;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataGridView DGVAddtrn;
        private System.Windows.Forms.DataGridView DgvStatus;
    }
}