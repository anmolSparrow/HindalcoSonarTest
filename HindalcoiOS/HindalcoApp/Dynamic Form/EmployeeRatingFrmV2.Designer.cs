
namespace HindalcoiOS.Dynamic_Form
{
    partial class EmployeeRatingFrm
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
            this.gbxEmpRate = new System.Windows.Forms.GroupBox();
            this.btnupdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.gbxEmpRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxEmpRate
            // 
            this.gbxEmpRate.Controls.Add(this.btnupdate);
            this.gbxEmpRate.Location = new System.Drawing.Point(12, 9);
            this.gbxEmpRate.Name = "gbxEmpRate";
            this.gbxEmpRate.Size = new System.Drawing.Size(380, 128);
            this.gbxEmpRate.TabIndex = 0;
            this.gbxEmpRate.TabStop = false;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnupdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnupdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnupdate.BorderRadius = 14;
            this.btnupdate.BorderSize = 0;
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(186, 44);
            this.btnupdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnupdate.Size = new System.Drawing.Size(124, 32);
            this.btnupdate.TabIndex = 0;
            this.btnupdate.Text = "Update";
            this.btnupdate.TextColor = System.Drawing.Color.White;
            this.btnupdate.UseVisualStyleBackColor = false;
            // 
            // EmployeeRatingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 146);
            this.Controls.Add(this.gbxEmpRate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeRatingFrm";
            this.Text = "Employee Rating Form";
            this.gbxEmpRate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxEmpRate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnupdate;
    }
}