
namespace HindalcoiOS.Audit_frm
{
    partial class AcceptanceDetails
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
            this.bunifuGroupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvAcceptance = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.btnupdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcceptance)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.Controls.Add(this.DgvAcceptance);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(766, 261);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Acceptance Details Fill";
            // 
            // DgvAcceptance
            // 
            this.DgvAcceptance.AllowUserToAddRows = false;
            this.DgvAcceptance.AllowUserToDeleteRows = false;
            this.DgvAcceptance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvAcceptance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAcceptance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAcceptance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAcceptance.ColumnNameToSum = null;
            this.DgvAcceptance.ColumnSum = 0D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAcceptance.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAcceptance.EnableColumnSumming = false;
            this.DgvAcceptance.EnableHeadersVisualStyles = false;
            this.DgvAcceptance.Location = new System.Drawing.Point(7, 23);
            this.DgvAcceptance.MultiSelect = false;
            this.DgvAcceptance.Name = "DgvAcceptance";
            this.DgvAcceptance.RowHeadersVisible = false;
            this.DgvAcceptance.RowHeadersWidth = 51;
            this.DgvAcceptance.RowTemplate.Height = 24;
            this.DgvAcceptance.Size = new System.Drawing.Size(753, 232);
            this.DgvAcceptance.TabIndex = 0;
            this.DgvAcceptance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAcceptance_CellClick);
            this.DgvAcceptance.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAcceptance_CellEndEdit);
            this.DgvAcceptance.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAcceptance_CellEnter);
            this.DgvAcceptance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvAcceptance_Scroll);
            this.DgvAcceptance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvAcceptance_KeyDown);
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
            this.btnupdate.Location = new System.Drawing.Point(648, 282);
            this.btnupdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnupdate.Size = new System.Drawing.Size(124, 30);
            this.btnupdate.TabIndex = 1;
            this.btnupdate.Text = "Save Data";
            this.btnupdate.TextColor = System.Drawing.Color.White;
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.deleteDataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 56);
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.addDataToolStripMenuItem.Text = "Add Data";
            this.addDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // deleteDataToolStripMenuItem
            // 
            this.deleteDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteDataToolStripMenuItem.Name = "deleteDataToolStripMenuItem";
            this.deleteDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteDataToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.deleteDataToolStripMenuItem.Text = "Delete Data";
            // 
            // AcceptanceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 324);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.bunifuGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcceptanceDetails";
            this.Text = "Acceptance Details";
            this.Load += new System.EventHandler(this.AcceptanceDetails_Load);
            this.bunifuGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAcceptance)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bunifuGroupBox1;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvAcceptance;
        private SparrowRMSControl.SparrowControl.SparrowButton btnupdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataToolStripMenuItem;
    }
}