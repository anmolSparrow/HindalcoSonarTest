
namespace HindalcoiOS.U1FormCollection
{
    partial class FreezePlan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGVfreeze = new System.Windows.Forms.DataGridView();
            this.MType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShtdwnReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditonalManpower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintScheduled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClickMe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInvent = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnupdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVfreeze)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVfreeze);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1223, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Freeze Plan";
            // 
            // DGVfreeze
            // 
            this.DGVfreeze.AllowUserToAddRows = false;
            this.DGVfreeze.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVfreeze.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVfreeze.ColumnHeadersHeight = 35;
            this.DGVfreeze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVfreeze.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MType,
            this.MachineTag,
            this.MachineName,
            this.Freequency,
            this.ShtdwnReq,
            this.ActivityDetails,
            this.Resource,
            this.MReading,
            this.UnitsName,
            this.AdditonalManpower,
            this.MaintScheduled,
            this.Priority,
            this.btnClickMe,
            this.Datetime,
            this.Team,
            this.btnInvent});
            this.DGVfreeze.ContextMenuStrip = this.contextMenuStrip1;
            this.DGVfreeze.EnableHeadersVisualStyles = false;
            this.DGVfreeze.Location = new System.Drawing.Point(7, 23);
            this.DGVfreeze.Name = "DGVfreeze";
            this.DGVfreeze.RowHeadersWidth = 51;
            this.DGVfreeze.RowTemplate.Height = 24;
            this.DGVfreeze.Size = new System.Drawing.Size(1202, 381);
            this.DGVfreeze.TabIndex = 0;
            this.DGVfreeze.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVfreeze_CellClick);
            this.DGVfreeze.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVfreeze_CellContentClick);
            this.DGVfreeze.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVfreeze_CellEnter);
            this.DGVfreeze.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVfreeze_CellFormatting);
            this.DGVfreeze.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGVfreeze_ColumnWidthChanged);
            this.DGVfreeze.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGVfreeze_DataError);
            this.DGVfreeze.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVfreeze_RowLeave);
            this.DGVfreeze.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGVfreeze_Scroll);
            // 
            // MType
            // 
            this.MType.HeaderText = "Maintenance Type";
            this.MType.MinimumWidth = 6;
            this.MType.Name = "MType";
            // 
            // MachineTag
            // 
            this.MachineTag.HeaderText = "Machine Tag";
            this.MachineTag.MinimumWidth = 6;
            this.MachineTag.Name = "MachineTag";
            // 
            // MachineName
            // 
            this.MachineName.HeaderText = "Machine Name";
            this.MachineName.MinimumWidth = 6;
            this.MachineName.Name = "MachineName";
            // 
            // Freequency
            // 
            this.Freequency.HeaderText = "Frequency";
            this.Freequency.MinimumWidth = 6;
            this.Freequency.Name = "Freequency";
            // 
            // ShtdwnReq
            // 
            this.ShtdwnReq.HeaderText = "Shut Down Required";
            this.ShtdwnReq.MinimumWidth = 6;
            this.ShtdwnReq.Name = "ShtdwnReq";
            // 
            // ActivityDetails
            // 
            this.ActivityDetails.HeaderText = "Activity Details";
            this.ActivityDetails.MinimumWidth = 6;
            this.ActivityDetails.Name = "ActivityDetails";
            // 
            // Resource
            // 
            this.Resource.HeaderText = "Resource";
            this.Resource.MinimumWidth = 6;
            this.Resource.Name = "Resource";
            // 
            // MReading
            // 
            this.MReading.HeaderText = "Meter Reading";
            this.MReading.MinimumWidth = 6;
            this.MReading.Name = "MReading";
            // 
            // UnitsName
            // 
            this.UnitsName.HeaderText = "Units Name";
            this.UnitsName.MinimumWidth = 6;
            this.UnitsName.Name = "UnitsName";
            // 
            // AdditonalManpower
            // 
            this.AdditonalManpower.HeaderText = "Additonal Manpower";
            this.AdditonalManpower.MinimumWidth = 6;
            this.AdditonalManpower.Name = "AdditonalManpower";
            // 
            // MaintScheduled
            // 
            this.MaintScheduled.HeaderText = "Maintenance Scheduled";
            this.MaintScheduled.MinimumWidth = 6;
            this.MaintScheduled.Name = "MaintScheduled";
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            // 
            // btnClickMe
            // 
            this.btnClickMe.HeaderText = "Action";
            this.btnClickMe.MinimumWidth = 6;
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.ReadOnly = true;
            this.btnClickMe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnClickMe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnClickMe.Text = "Click FreezeData";
            this.btnClickMe.UseColumnTextForButtonValue = true;
            // 
            // Datetime
            // 
            this.Datetime.HeaderText = "SetDate";
            this.Datetime.MinimumWidth = 6;
            this.Datetime.Name = "Datetime";
            // 
            // Team
            // 
            this.Team.HeaderText = "Add Team";
            this.Team.MinimumWidth = 6;
            this.Team.Name = "Team";
            // 
            // btnInvent
            // 
            this.btnInvent.HeaderText = "Inventory";
            this.btnInvent.MinimumWidth = 6;
            this.btnInvent.Name = "btnInvent";
            this.btnInvent.ReadOnly = true;
            this.btnInvent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnInvent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnInvent.Text = "Click Here";
            this.btnInvent.UseColumnTextForButtonValue = true;
            this.btnInvent.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.deleteDataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 84);
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.addDataToolStripMenuItem.Tag = "0";
            this.addDataToolStripMenuItem.Text = "Add Data";
            this.addDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // deleteDataToolStripMenuItem
            // 
            this.deleteDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.DeleteAll;
            this.deleteDataToolStripMenuItem.Name = "deleteDataToolStripMenuItem";
            this.deleteDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteDataToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.deleteDataToolStripMenuItem.Tag = "1";
            this.deleteDataToolStripMenuItem.Text = "Delete Data";
            this.deleteDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
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
            this.btnupdate.Location = new System.Drawing.Point(1092, 429);
            this.btnupdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnupdate.Size = new System.Drawing.Size(130, 30);
            this.btnupdate.TabIndex = 1;
            this.btnupdate.Text = "Update and Save";
            this.btnupdate.TextColor = System.Drawing.Color.White;
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(953, 434);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 22);
            this.checkedListBox1.TabIndex = 2;
            // 
            // FreezePlan
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 480);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FreezePlan";
            this.Text = "Freeze Plan";
            this.Load += new System.EventHandler(this.FreezePlan_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVfreeze)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVfreeze;
        private SparrowRMSControl.SparrowControl.SparrowButton btnupdate;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShtdwnReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn MReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditonalManpower;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintScheduled;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewButtonColumn btnClickMe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewButtonColumn btnInvent;
    }
}