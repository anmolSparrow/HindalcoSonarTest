
namespace HindalcoiOS.PermitToWork
{
    partial class ViewPermit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxViewPermit3 = new System.Windows.Forms.GroupBox();
            this.DBGridViewPermit = new System.Windows.Forms.DataGridView();
            this.gbxViewPermit2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtpermitCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblPermitCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.groupBox1.SuspendLayout();
            this.gbxViewPermit3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridViewPermit)).BeginInit();
            this.gbxViewPermit2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.gbxViewPermit3);
            this.groupBox1.Controls.Add(this.gbxViewPermit2);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 380);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gbxViewPermit3
            // 
            this.gbxViewPermit3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxViewPermit3.Controls.Add(this.DBGridViewPermit);
            this.gbxViewPermit3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxViewPermit3.Location = new System.Drawing.Point(7, 118);
            this.gbxViewPermit3.Name = "gbxViewPermit3";
            this.gbxViewPermit3.Size = new System.Drawing.Size(930, 250);
            this.gbxViewPermit3.TabIndex = 1;
            this.gbxViewPermit3.TabStop = false;
            this.gbxViewPermit3.Text = "Permit Details";
            // 
            // DBGridViewPermit
            // 
            this.DBGridViewPermit.AllowUserToAddRows = false;
            this.DBGridViewPermit.AllowUserToDeleteRows = false;
            this.DBGridViewPermit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGridViewPermit.Location = new System.Drawing.Point(10, 23);
            this.DBGridViewPermit.Name = "DBGridViewPermit";
            this.DBGridViewPermit.ReadOnly = true;
            this.DBGridViewPermit.RowHeadersWidth = 51;
            this.DBGridViewPermit.RowTemplate.Height = 24;
            this.DBGridViewPermit.Size = new System.Drawing.Size(914, 210);
            this.DBGridViewPermit.TabIndex = 0;
            this.DBGridViewPermit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGridViewPermit_CellClick);
            // 
            // gbxViewPermit2
            // 
            this.gbxViewPermit2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxViewPermit2.Controls.Add(this.btnSearch);
            this.gbxViewPermit2.Controls.Add(this.txtpermitCode);
            this.gbxViewPermit2.Controls.Add(this.lblPermitCode);
            this.gbxViewPermit2.Location = new System.Drawing.Point(12, 21);
            this.gbxViewPermit2.Name = "gbxViewPermit2";
            this.gbxViewPermit2.Size = new System.Drawing.Size(919, 91);
            this.gbxViewPermit2.TabIndex = 0;
            this.gbxViewPermit2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.BorderRadius = 14;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(403, 33);
            this.btnSearch.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSearch.Size = new System.Drawing.Size(124, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtpermitCode
            // 
            this.txtpermitCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtpermitCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtpermitCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtpermitCode.BorderRadius = 0;
            this.txtpermitCode.BorderSize = 1;
            this.txtpermitCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpermitCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtpermitCode.Location = new System.Drawing.Point(144, 35);
            this.txtpermitCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtpermitCode.Multiline = true;
            this.txtpermitCode.Name = "txtpermitCode";
            this.txtpermitCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtpermitCode.PasswordChar = false;
            this.txtpermitCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtpermitCode.PlaceholderText = "Enter Text";
            this.txtpermitCode.Size = new System.Drawing.Size(232, 30);
            this.txtpermitCode.TabIndex = 1;
            this.txtpermitCode.UnderlinedStyle = false;
            // 
            // lblPermitCode
            // 
            this.lblPermitCode.AutoSize = true;
            this.lblPermitCode.Depth = 0;
            this.lblPermitCode.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermitCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPermitCode.Location = new System.Drawing.Point(6, 42);
            this.lblPermitCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblPermitCode.Name = "lblPermitCode";
            this.lblPermitCode.Size = new System.Drawing.Size(100, 21);
            this.lblPermitCode.TabIndex = 0;
            this.lblPermitCode.Text = "Permit Code";
            // 
            // ViewPermit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 402);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewPermit";
            this.Text = "View Permit";
            this.Load += new System.EventHandler(this.ViewPermitUpd_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbxViewPermit3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DBGridViewPermit)).EndInit();
            this.gbxViewPermit2.ResumeLayout(false);
            this.gbxViewPermit2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxViewPermit2;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSearch;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtpermitCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblPermitCode;
        private System.Windows.Forms.GroupBox gbxViewPermit3;
        private System.Windows.Forms.DataGridView DBGridViewPermit;
    }
}