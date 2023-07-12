
namespace HindalcoiOS.U1FormCollection
{
    partial class AddBreakDownfrm
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
            this.grpbrk = new System.Windows.Forms.GroupBox();
            this.DgvBrk = new System.Windows.Forms.DataGridView();
            this.btnsave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.ContextAddBRk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpbrk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBrk)).BeginInit();
            this.ContextAddBRk.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbrk
            // 
            this.grpbrk.Controls.Add(this.DgvBrk);
            this.grpbrk.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbrk.Location = new System.Drawing.Point(22, 20);
            this.grpbrk.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grpbrk.Name = "grpbrk";
            this.grpbrk.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.grpbrk.Size = new System.Drawing.Size(1380, 369);
            this.grpbrk.TabIndex = 0;
            this.grpbrk.TabStop = false;
            this.grpbrk.Text = "Machine Breakdown Info";
            // 
            // DgvBrk
            // 
            this.DgvBrk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBrk.Location = new System.Drawing.Point(12, 36);
            this.DgvBrk.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DgvBrk.Name = "DgvBrk";
            this.DgvBrk.RowHeadersWidth = 51;
            this.DgvBrk.RowTemplate.Height = 24;
            this.DgvBrk.Size = new System.Drawing.Size(1358, 323);
            this.DgvBrk.TabIndex = 0;
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
            this.btnsave.Location = new System.Drawing.Point(1150, 405);
            this.btnsave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnsave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.Name = "btnsave";
            this.btnsave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsave.Size = new System.Drawing.Size(242, 47);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Update and Save";
            this.btnsave.TextColor = System.Drawing.Color.White;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click_1);
            // 
            // ContextAddBRk
            // 
            this.ContextAddBRk.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextAddBRk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.deleteDataToolStripMenuItem});
            this.ContextAddBRk.Name = "ContextAddBRk";
            this.ContextAddBRk.Size = new System.Drawing.Size(217, 80);
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(216, 38);
            this.addDataToolStripMenuItem.Text = "Add Data";
            // 
            // deleteDataToolStripMenuItem
            // 
            this.deleteDataToolStripMenuItem.Name = "deleteDataToolStripMenuItem";
            this.deleteDataToolStripMenuItem.Size = new System.Drawing.Size(216, 38);
            this.deleteDataToolStripMenuItem.Text = "Delete Data";
            // 
            // AddBreakDownfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 473);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.grpbrk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "AddBreakDownfrm";
            this.Text = "Add BreakDown Form";
            this.grpbrk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBrk)).EndInit();
            this.ContextAddBRk.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbrk;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsave;
        private System.Windows.Forms.DataGridView DgvBrk;
        private System.Windows.Forms.ContextMenuStrip ContextAddBRk;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataToolStripMenuItem;
    }
}