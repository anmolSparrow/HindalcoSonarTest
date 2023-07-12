
namespace HindalcoiOS.Safety_Form_list
{
    partial class SafetyChecklist
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
            this.grpCheckLIst = new System.Windows.Forms.GroupBox();
            this.DgvSafetychklist = new System.Windows.Forms.DataGridView();
            this.btnConsumpDetailDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpPic = new System.Windows.Forms.GroupBox();
            this.lblAdd = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnUpdateList = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.pictureBox1 = new SparrowRMSControl.SparrowControl.SparrowCircularpictureBox();
            this.contextRowAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpCheckLIst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSafetychklist)).BeginInit();
            this.grpPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextRowAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCheckLIst
            // 
            this.grpCheckLIst.Controls.Add(this.DgvSafetychklist);
            this.grpCheckLIst.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCheckLIst.Location = new System.Drawing.Point(12, 2);
            this.grpCheckLIst.Name = "grpCheckLIst";
            this.grpCheckLIst.Size = new System.Drawing.Size(815, 190);
            this.grpCheckLIst.TabIndex = 1;
            this.grpCheckLIst.TabStop = false;
            this.grpCheckLIst.Text = "Safety Checklist Information";
            // 
            // DgvSafetychklist
            // 
            this.DgvSafetychklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSafetychklist.Location = new System.Drawing.Point(13, 24);
            this.DgvSafetychklist.Name = "DgvSafetychklist";
            this.DgvSafetychklist.RowHeadersWidth = 51;
            this.DgvSafetychklist.RowTemplate.Height = 24;
            this.DgvSafetychklist.Size = new System.Drawing.Size(788, 150);
            this.DgvSafetychklist.TabIndex = 35;
            this.DgvSafetychklist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSafetychklist_CellClick);
            this.DgvSafetychklist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSafetychklist_CellContentClick);
            this.DgvSafetychklist.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSafetychklist_CellContentDoubleClick);
            this.DgvSafetychklist.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSafetychklist_CellEnter);
            // 
            // btnConsumpDetailDelete
            // 
            this.btnConsumpDetailDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConsumpDetailDelete.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnConsumpDetailDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnConsumpDetailDelete.BorderRadius = 14;
            this.btnConsumpDetailDelete.BorderSize = 0;
            this.btnConsumpDetailDelete.FlatAppearance.BorderSize = 0;
            this.btnConsumpDetailDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConsumpDetailDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConsumpDetailDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumpDetailDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumpDetailDelete.ForeColor = System.Drawing.Color.White;
            this.btnConsumpDetailDelete.Location = new System.Drawing.Point(496, 397);
            this.btnConsumpDetailDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConsumpDetailDelete.Name = "btnConsumpDetailDelete";
            this.btnConsumpDetailDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnConsumpDetailDelete.Size = new System.Drawing.Size(94, 30);
            this.btnConsumpDetailDelete.TabIndex = 34;
            this.btnConsumpDetailDelete.Text = "Save";
            this.btnConsumpDetailDelete.TextColor = System.Drawing.Color.White;
            this.btnConsumpDetailDelete.UseVisualStyleBackColor = false;
            // 
            // grpPic
            // 
            this.grpPic.Controls.Add(this.lblAdd);
            this.grpPic.Controls.Add(this.btnUpdateList);
            this.grpPic.Controls.Add(this.pictureBox1);
            this.grpPic.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPic.Location = new System.Drawing.Point(14, 198);
            this.grpPic.Name = "grpPic";
            this.grpPic.Size = new System.Drawing.Size(815, 177);
            this.grpPic.TabIndex = 36;
            this.grpPic.TabStop = false;
            this.grpPic.Text = "Upload Photo";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Depth = 0;
            this.lblAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAdd.Location = new System.Drawing.Point(350, 76);
            this.lblAdd.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(75, 18);
            this.lblAdd.TabIndex = 36;
            this.lblAdd.Text = "Add Photo";
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateList.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateList.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateList.BorderRadius = 14;
            this.btnUpdateList.BorderSize = 0;
            this.btnUpdateList.FlatAppearance.BorderSize = 0;
            this.btnUpdateList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdateList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateList.ForeColor = System.Drawing.Color.White;
            this.btnUpdateList.Location = new System.Drawing.Point(663, 70);
            this.btnUpdateList.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUpdateList.Size = new System.Drawing.Size(111, 30);
            this.btnUpdateList.TabIndex = 35;
            this.btnUpdateList.Text = "Save Data";
            this.btnUpdateList.TextColor = System.Drawing.Color.White;
            this.btnUpdateList.UseVisualStyleBackColor = false;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pictureBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.BorderColor2 = System.Drawing.Color.HotPink;
            this.pictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pictureBox1.BorderSize = 2;
            this.pictureBox1.GradientAngle = 50F;
            this.pictureBox1.Location = new System.Drawing.Point(479, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // contextRowAdd
            // 
            this.contextRowAdd.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextRowAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.contextRowAdd.Name = "contextRowAdd";
            this.contextRowAdd.Size = new System.Drawing.Size(213, 56);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.addToolStripMenuItem.Text = "Add Row";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // SafetyChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 387);
            this.Controls.Add(this.grpPic);
            this.Controls.Add(this.grpCheckLIst);
            this.Controls.Add(this.btnConsumpDetailDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SafetyChecklist";
            this.Text = "Safety Checklist";
            this.Load += new System.EventHandler(this.SafetyChecklist_Load);
            this.grpCheckLIst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSafetychklist)).EndInit();
            this.grpPic.ResumeLayout(false);
            this.grpPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextRowAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCheckLIst;
        private SparrowRMSControl.SparrowControl.SparrowButton btnConsumpDetailDelete;
        private System.Windows.Forms.DataGridView DgvSafetychklist;
        private System.Windows.Forms.GroupBox grpPic;
        private SparrowRMSControl.SparrowControl.SparrowCircularpictureBox pictureBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUpdateList;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAdd;
        private System.Windows.Forms.ContextMenuStrip contextRowAdd;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
    }
}