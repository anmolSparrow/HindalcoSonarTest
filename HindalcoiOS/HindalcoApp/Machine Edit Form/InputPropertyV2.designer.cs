
namespace HindalcoiOS.Machine_Edit_Form
{
    partial class Input_Property
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
            this.gbxConnPprty = new System.Windows.Forms.GroupBox();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.dgvInputppty = new System.Windows.Forms.DataGridView();
            this.gbxConnPprty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputppty)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxConnPprty
            // 
            this.gbxConnPprty.Controls.Add(this.btnSave);
            this.gbxConnPprty.Controls.Add(this.dgvInputppty);
            this.gbxConnPprty.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConnPprty.Location = new System.Drawing.Point(12, -1);
            this.gbxConnPprty.Name = "gbxConnPprty";
            this.gbxConnPprty.Size = new System.Drawing.Size(751, 279);
            this.gbxConnPprty.TabIndex = 0;
            this.gbxConnPprty.TabStop = false;
            this.gbxConnPprty.Text = "Input Connector Property";
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
            this.btnSave.Location = new System.Drawing.Point(623, 237);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(112, 30);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvInputppty
            // 
            this.dgvInputppty.AllowUserToAddRows = false;
            this.dgvInputppty.AllowUserToDeleteRows = false;
            this.dgvInputppty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInputppty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInputppty.ColumnHeadersHeight = 35;
            this.dgvInputppty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInputppty.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInputppty.EnableHeadersVisualStyles = false;
            this.dgvInputppty.Location = new System.Drawing.Point(10, 26);
            this.dgvInputppty.Name = "dgvInputppty";
            this.dgvInputppty.ReadOnly = true;
            this.dgvInputppty.RowHeadersWidth = 51;
            this.dgvInputppty.RowTemplate.Height = 24;
            this.dgvInputppty.Size = new System.Drawing.Size(725, 203);
            this.dgvInputppty.TabIndex = 0;
            // 
            // Input_Property
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 290);
            this.Controls.Add(this.gbxConnPprty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Input_Property";
            this.Text = "Input Property";
            this.Load += new System.EventHandler(this.Input_Property_Load);
            this.gbxConnPprty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputppty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConnPprty;
        private System.Windows.Forms.DataGridView dgvInputppty;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
    }
}