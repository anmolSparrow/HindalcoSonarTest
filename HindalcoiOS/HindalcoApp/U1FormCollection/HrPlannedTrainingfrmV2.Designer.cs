
namespace HindalcoiOS.U1FormCollection
{
    partial class HrPlannedTrainingfrm
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
            this.grpPlanned = new System.Windows.Forms.GroupBox();
            this.DgvPlaned = new System.Windows.Forms.DataGridView();
            this.btnsave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpPlanned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlaned)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPlanned
            // 
            this.grpPlanned.Controls.Add(this.DgvPlaned);
            this.grpPlanned.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlanned.Location = new System.Drawing.Point(13, 13);
            this.grpPlanned.Name = "grpPlanned";
            this.grpPlanned.Size = new System.Drawing.Size(1220, 311);
            this.grpPlanned.TabIndex = 0;
            this.grpPlanned.TabStop = false;
            this.grpPlanned.Text = "HR Planned View";
            // 
            // DgvPlaned
            // 
            this.DgvPlaned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlaned.Location = new System.Drawing.Point(7, 23);
            this.DgvPlaned.Name = "DgvPlaned";
            this.DgvPlaned.RowHeadersWidth = 51;
            this.DgvPlaned.RowTemplate.Height = 24;
            this.DgvPlaned.Size = new System.Drawing.Size(1207, 282);
            this.DgvPlaned.TabIndex = 0;
            this.DgvPlaned.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaned_CellClick);
            this.DgvPlaned.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaned_CellContentClick);
            this.DgvPlaned.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaned_CellEnter);
            this.DgvPlaned.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaned_CellValueChanged);
            this.DgvPlaned.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvPlaned_CurrentCellDirtyStateChanged);
            this.DgvPlaned.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvPlaned_Scroll);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BorderRadius = 14;
            this.btnsave.BorderSize = 0;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(1075, 324);
            this.btnsave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.Name = "btnsave";
            this.btnsave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsave.Size = new System.Drawing.Size(158, 32);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Update Planned Info";
            this.btnsave.TextColor = System.Drawing.Color.White;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // HrPlannedTrainingfrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 367);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.grpPlanned);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "HrPlannedTrainingfrm";
            this.Text = "HR Planned Training Form";
            this.grpPlanned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlaned)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPlanned;
        private System.Windows.Forms.DataGridView DgvPlaned;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsave;
    }
}