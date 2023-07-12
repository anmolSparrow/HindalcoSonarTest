
namespace HindalcoiOS.Audit_frm
{
    partial class AcceptanceDescription
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpAccptance = new System.Windows.Forms.GroupBox();
            this.DgvAcceptnNo = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpAccptance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcceptnNo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAccptance
            // 
            this.grpAccptance.Controls.Add(this.DgvAcceptnNo);
            this.grpAccptance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAccptance.Location = new System.Drawing.Point(13, 13);
            this.grpAccptance.Name = "grpAccptance";
            this.grpAccptance.Size = new System.Drawing.Size(919, 264);
            this.grpAccptance.TabIndex = 0;
            this.grpAccptance.TabStop = false;
            this.grpAccptance.Text = "Acceptance Description";
            // 
            // DgvAcceptnNo
            // 
            this.DgvAcceptnNo.AllowUserToAddRows = false;
            this.DgvAcceptnNo.AllowUserToDeleteRows = false;
            this.DgvAcceptnNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvAcceptnNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAcceptnNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAcceptnNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAcceptnNo.ColumnNameToSum = null;
            this.DgvAcceptnNo.ColumnSum = 0D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAcceptnNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAcceptnNo.EnableColumnSumming = false;
            this.DgvAcceptnNo.EnableHeadersVisualStyles = false;
            this.DgvAcceptnNo.Location = new System.Drawing.Point(7, 23);
            this.DgvAcceptnNo.MultiSelect = false;
            this.DgvAcceptnNo.Name = "DgvAcceptnNo";
            this.DgvAcceptnNo.RowHeadersVisible = false;
            this.DgvAcceptnNo.RowHeadersWidth = 51;
            this.DgvAcceptnNo.RowTemplate.Height = 24;
            this.DgvAcceptnNo.Size = new System.Drawing.Size(906, 225);
            this.DgvAcceptnNo.TabIndex = 0;
            this.DgvAcceptnNo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAcceptnNo_CellEndEdit);
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
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(787, 285);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(124, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Details";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEntryToolStripMenuItem,
            this.deleteEntryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 56);
            // 
            // addEntryToolStripMenuItem
            // 
            this.addEntryToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addEntryToolStripMenuItem.Name = "addEntryToolStripMenuItem";
            this.addEntryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addEntryToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addEntryToolStripMenuItem.Text = "Add Entry";
            this.addEntryToolStripMenuItem.Click += new System.EventHandler(this.addEntryToolStripMenuItem_Click);
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            this.deleteEntryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteEntryToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.deleteEntryToolStripMenuItem.Text = "Delete Entry";
            this.deleteEntryToolStripMenuItem.Click += new System.EventHandler(this.addEntryToolStripMenuItem_Click);
            // 
            // AcceptanceDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 327);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpAccptance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcceptanceDescription";
            this.Text = "Acceptance Description";
            this.Load += new System.EventHandler(this.AcceptanceDecription_Load);
            this.grpAccptance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcceptnNo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAccptance;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvAcceptnNo;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
    }
}