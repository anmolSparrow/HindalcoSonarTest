
namespace HindalcoiOS.U1FormCollection
{
    partial class PlanningFrm
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
            this.GrpPlaling = new System.Windows.Forms.GroupBox();
            this.DgvPlaning = new System.Windows.Forms.DataGridView();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpPlaling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlaning)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpPlaling
            // 
            this.GrpPlaling.Controls.Add(this.DgvPlaning);
            this.GrpPlaling.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpPlaling.Location = new System.Drawing.Point(13, 13);
            this.GrpPlaling.Name = "GrpPlaling";
            this.GrpPlaling.Size = new System.Drawing.Size(966, 252);
            this.GrpPlaling.TabIndex = 0;
            this.GrpPlaling.TabStop = false;
            this.GrpPlaling.Text = "Planning Information";
            // 
            // DgvPlaning
            // 
            this.DgvPlaning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlaning.Location = new System.Drawing.Point(7, 23);
            this.DgvPlaning.Name = "DgvPlaning";
            this.DgvPlaning.RowHeadersWidth = 51;
            this.DgvPlaning.RowTemplate.Height = 24;
            this.DgvPlaning.Size = new System.Drawing.Size(953, 223);
            this.DgvPlaning.TabIndex = 0;
            this.DgvPlaning.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaning_CellClick);
            this.DgvPlaning.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaning_CellEnter);
            this.DgvPlaning.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvPlaning_ColumnWidthChanged);
            this.DgvPlaning.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvPlaning_DataError);
            this.DgvPlaning.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvReport_EditingControlShowing);
            this.DgvPlaning.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvPlaning_Scroll);
            this.DgvPlaning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvPlaning_KeyDown);

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
            this.btnSave.Location = new System.Drawing.Point(837, 273);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(132, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Update && Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 56);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.addRowToolStripMenuItem.Text = "Add Row";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // PlanningFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 314);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.GrpPlaling);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanningFrm";
            this.Text = "Planning Form";
            this.Load += new System.EventHandler(this.PlanningFrm_Load);
            this.GrpPlaling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlaning)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPlaling;
        private System.Windows.Forms.DataGridView DgvPlaning;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
    }
}