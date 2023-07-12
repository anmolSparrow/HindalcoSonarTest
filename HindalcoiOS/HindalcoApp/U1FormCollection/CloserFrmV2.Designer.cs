
namespace HindalcoiOS.U1FormCollection
{
    partial class CloserFrm
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
            this.bunifuGroupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvClosure = new System.Windows.Forms.DataGridView();
            this.TaskDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClosure)).BeginInit();
            this.TaskDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.Controls.Add(this.DgvClosure);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(816, 204);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Machine Closure Information";
            // 
            // DgvClosure
            // 
            this.DgvClosure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClosure.Location = new System.Drawing.Point(7, 23);
            this.DgvClosure.Name = "DgvClosure";
            this.DgvClosure.RowHeadersWidth = 51;
            this.DgvClosure.RowTemplate.Height = 24;
            this.DgvClosure.Size = new System.Drawing.Size(803, 175);
            this.DgvClosure.TabIndex = 0;
            this.DgvClosure.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClosure_CellContentClick);
            // 
            // TaskDetails
            // 
            this.TaskDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TaskDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTaskToolStripMenuItem});
            this.TaskDetails.Name = "TaskDetails";
            this.TaskDetails.Size = new System.Drawing.Size(154, 28);
            // 
            // deleteTaskToolStripMenuItem
            // 
            this.deleteTaskToolStripMenuItem.Name = "deleteTaskToolStripMenuItem";
            this.deleteTaskToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.deleteTaskToolStripMenuItem.Text = "Delete Task";
            this.deleteTaskToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem);
            // 
            // CloserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 229);
            this.Controls.Add(this.bunifuGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CloserFrm";
            this.Text = "Closer Form";
            this.Load += new System.EventHandler(this.CloserFrm_Load);
            this.bunifuGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClosure)).EndInit();
            this.TaskDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bunifuGroupBox1;
        private System.Windows.Forms.DataGridView DgvClosure;
        private System.Windows.Forms.ContextMenuStrip TaskDetails;
        //private System.Windows.Forms.ToolStripMenuItem addTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
    }
}