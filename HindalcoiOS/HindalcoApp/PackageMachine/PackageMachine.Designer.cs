namespace HindalcoiOS.PackageMachine
{
    partial class PackageMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageMachine));
            this.cadPictBox = new CADImport.FaceModule.CADPictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cadPictBox
            // 
            this.cadPictBox.AllowDrop = true;
            this.cadPictBox.BackColor = System.Drawing.Color.Black;
            this.cadPictBox.ContextMenuStrip = this.contextMenuStrip1;
            this.cadPictBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cadPictBox.DoubleBuffering = true;
            this.cadPictBox.Location = new System.Drawing.Point(0, 0);
            this.cadPictBox.Name = "cadPictBox";
            this.cadPictBox.Ortho = false;
            this.cadPictBox.Position = new System.Drawing.Point(0, 0);
            this.cadPictBox.ScrollBars = CADImport.FaceModule.ScrollBarsShow.None;
            this.cadPictBox.Size = new System.Drawing.Size(841, 419);
            this.cadPictBox.TabIndex = 3;
            this.cadPictBox.VirtualSize = new System.Drawing.Size(0, 0);
            this.cadPictBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.cadPictBox_DragDrop);
            this.cadPictBox.Paint += new System.Windows.Forms.PaintEventHandler(this.cadPictBox_Paint);
            this.cadPictBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cadPictBox_KeyDown);
            this.cadPictBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CADPictBoxKeyUp);
            this.cadPictBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseDoubleClick);
            this.cadPictBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseDown);
            this.cadPictBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseMove);
            this.cadPictBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 60);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkToolStripMenuItem.Image")));
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.checkToolStripMenuItem.Text = "Generate Package";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // PackageMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 419);
            this.Controls.Add(this.cadPictBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PackageMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PackageMachine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackageMachine_FormClosing);
            this.Load += new System.EventHandler(this.PackageMachine_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        public CADImport.FaceModule.CADPictureBox cadPictBox;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}