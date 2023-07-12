
namespace HindalcoiOS.PackageMachine
{
    partial class Remote_Connection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbsearch = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblSearch = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.DGVLoadRC = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SysNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dtination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblsource = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtCordinate = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtsource = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.DgvRC = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConnection = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnUnitCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextDGVLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoadRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRC)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.ContextDGVLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cmbsearch);
            this.groupBox1.Controls.Add(this.lblSearch);
            this.groupBox1.Controls.Add(this.DGVLoadRC);
            this.groupBox1.Controls.Add(this.lblsource);
            this.groupBox1.Controls.Add(this.txtCordinate);
            this.groupBox1.Controls.Add(this.txtsource);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1164, 330);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote Connection";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BorderRadius = 14;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1016, 81);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(127, 30);
            this.btnAdd.TabIndex = 58;
            this.btnAdd.Text = "Add Connection";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbsearch
            // 
            this.cmbsearch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbsearch.BorderSize = 1;
            this.cmbsearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbsearch.ForeColor = System.Drawing.Color.DimGray;
            this.cmbsearch.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbsearch.ItemHeight = 26;
            this.cmbsearch.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbsearch.ListTextColor = System.Drawing.Color.White;
            this.cmbsearch.Location = new System.Drawing.Point(614, 26);
            this.cmbsearch.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbsearch.Name = "cmbsearch";
            this.cmbsearch.Size = new System.Drawing.Size(217, 32);
            this.cmbsearch.TabIndex = 44;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Depth = 0;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSearch.Location = new System.Drawing.Point(449, 35);
            this.lblSearch.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(141, 18);
            this.lblSearch.TabIndex = 40;
            this.lblSearch.Text = "Search Machine Tag";
            // 
            // DGVLoadRC
            // 
            this.DGVLoadRC.AllowUserToAddRows = false;
            this.DGVLoadRC.AllowUserToDeleteRows = false;
            this.DGVLoadRC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVLoadRC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVLoadRC.ColumnHeadersHeight = 35;
            this.DGVLoadRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVLoadRC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.MName,
            this.MCor,
            this.SysNo,
            this.CType,
            this.SSource,
            this.Dtination});
            this.DGVLoadRC.EnableHeadersVisualStyles = false;
            this.DGVLoadRC.Location = new System.Drawing.Point(16, 131);
            this.DGVLoadRC.Name = "DGVLoadRC";
            this.DGVLoadRC.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVLoadRC.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVLoadRC.RowHeadersVisible = false;
            this.DGVLoadRC.RowHeadersWidth = 51;
            this.DGVLoadRC.RowTemplate.Height = 24;
            this.DGVLoadRC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLoadRC.Size = new System.Drawing.Size(1129, 180);
            this.DGVLoadRC.TabIndex = 37;
            this.DGVLoadRC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLoadRC_CellContentClick);
            this.DGVLoadRC.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLoadRC_CellContentDoubleClick);
            // 
            // SNo
            // 
            this.SNo.HeaderText = "Sr. No";
            this.SNo.MinimumWidth = 6;
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            // 
            // MName
            // 
            this.MName.HeaderText = "Machine Name";
            this.MName.MinimumWidth = 6;
            this.MName.Name = "MName";
            this.MName.ReadOnly = true;
            // 
            // MCor
            // 
            this.MCor.HeaderText = "Machine Core";
            this.MCor.MinimumWidth = 6;
            this.MCor.Name = "MCor";
            this.MCor.ReadOnly = true;
            // 
            // SysNo
            // 
            this.SysNo.HeaderText = "Machine Tag";
            this.SysNo.MinimumWidth = 6;
            this.SysNo.Name = "SysNo";
            this.SysNo.ReadOnly = true;
            // 
            // CType
            // 
            this.CType.HeaderText = "Connector Type";
            this.CType.MinimumWidth = 6;
            this.CType.Name = "CType";
            this.CType.ReadOnly = true;
            // 
            // SSource
            // 
            this.SSource.HeaderText = "Source";
            this.SSource.MinimumWidth = 6;
            this.SSource.Name = "SSource";
            this.SSource.ReadOnly = true;
            // 
            // Dtination
            // 
            this.Dtination.HeaderText = "Destination";
            this.Dtination.MinimumWidth = 6;
            this.Dtination.Name = "Dtination";
            this.Dtination.ReadOnly = true;
            // 
            // lblsource
            // 
            this.lblsource.AutoSize = true;
            this.lblsource.Depth = 0;
            this.lblsource.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblsource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblsource.Location = new System.Drawing.Point(40, 35);
            this.lblsource.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblsource.Name = "lblsource";
            this.lblsource.Size = new System.Drawing.Size(105, 18);
            this.lblsource.TabIndex = 35;
            this.lblsource.Text = "Machine Name";
            // 
            // txtCordinate
            // 
            this.txtCordinate.BackColor = System.Drawing.SystemColors.Window;
            this.txtCordinate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCordinate.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCordinate.BorderRadius = 0;
            this.txtCordinate.BorderSize = 1;
            this.txtCordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCordinate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCordinate.Location = new System.Drawing.Point(926, 26);
            this.txtCordinate.Margin = new System.Windows.Forms.Padding(4);
            this.txtCordinate.Multiline = true;
            this.txtCordinate.Name = "txtCordinate";
            this.txtCordinate.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCordinate.PasswordChar = false;
            this.txtCordinate.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCordinate.PlaceholderText = "";
            this.txtCordinate.Size = new System.Drawing.Size(217, 32);
            this.txtCordinate.TabIndex = 34;
            this.txtCordinate.UnderlinedStyle = false;
            // 
            // txtsource
            // 
            this.txtsource.BackColor = System.Drawing.SystemColors.Window;
            this.txtsource.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtsource.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtsource.BorderRadius = 0;
            this.txtsource.BorderSize = 1;
            this.txtsource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsource.Location = new System.Drawing.Point(161, 27);
            this.txtsource.Margin = new System.Windows.Forms.Padding(4);
            this.txtsource.Multiline = true;
            this.txtsource.Name = "txtsource";
            this.txtsource.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtsource.PasswordChar = false;
            this.txtsource.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtsource.PlaceholderText = "";
            this.txtsource.Size = new System.Drawing.Size(210, 32);
            this.txtsource.TabIndex = 33;
            this.txtsource.UnderlinedStyle = false;
            // 
            // DgvRC
            // 
            this.DgvRC.AllowUserToAddRows = false;
            this.DgvRC.AllowUserToDeleteRows = false;
            this.DgvRC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvRC.ColumnHeadersHeight = 35;
            this.DgvRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvRC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.DgvRC.EnableHeadersVisualStyles = false;
            this.DgvRC.Location = new System.Drawing.Point(28, 132);
            this.DgvRC.Name = "DgvRC";
            this.DgvRC.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRC.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvRC.RowHeadersVisible = false;
            this.DgvRC.RowHeadersWidth = 51;
            this.DgvRC.RowTemplate.Height = 24;
            this.DgvRC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRC.Size = new System.Drawing.Size(1129, 181);
            this.DgvRC.TabIndex = 60;
            this.DgvRC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRC_CellContentClick);
            this.DgvRC.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRC_CellEnter);
            this.DgvRC.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvRC_CurrentCellDirtyStateChanged);
            this.DgvRC.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvRC_EditingControlShowing);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Sr. No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Machine Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Machine Core";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Machine Tag";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Connector Type";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Source";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Destination";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConnection.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnConnection.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnConnection.BorderRadius = 14;
            this.btnConnection.BorderSize = 0;
            this.btnConnection.FlatAppearance.BorderSize = 0;
            this.btnConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.ForeColor = System.Drawing.Color.White;
            this.btnConnection.Location = new System.Drawing.Point(916, 336);
            this.btnConnection.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnConnection.Size = new System.Drawing.Size(112, 30);
            this.btnConnection.TabIndex = 59;
            this.btnConnection.Text = "Connect";
            this.btnConnection.TextColor = System.Drawing.Color.White;
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnUnitCancel
            // 
            this.btnUnitCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUnitCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUnitCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUnitCancel.BorderRadius = 14;
            this.btnUnitCancel.BorderSize = 0;
            this.btnUnitCancel.FlatAppearance.BorderSize = 0;
            this.btnUnitCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUnitCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUnitCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitCancel.ForeColor = System.Drawing.Color.White;
            this.btnUnitCancel.Location = new System.Drawing.Point(1043, 336);
            this.btnUnitCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUnitCancel.Name = "btnUnitCancel";
            this.btnUnitCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUnitCancel.Size = new System.Drawing.Size(112, 30);
            this.btnUnitCancel.TabIndex = 39;
            this.btnUnitCancel.Text = "Cancel";
            this.btnUnitCancel.TextColor = System.Drawing.Color.White;
            this.btnUnitCancel.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem1,
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 56);
            // 
            // addRowToolStripMenuItem1
            // 
            this.addRowToolStripMenuItem1.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addRowToolStripMenuItem1.Name = "addRowToolStripMenuItem1";
            this.addRowToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addRowToolStripMenuItem1.Size = new System.Drawing.Size(212, 26);
            this.addRowToolStripMenuItem1.Text = "Add Row";
            this.addRowToolStripMenuItem1.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // ContextDGVLoad
            // 
            this.ContextDGVLoad.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextDGVLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem,
            this.addRowToolStripMenuItem2});
            this.ContextDGVLoad.Name = "ContextDGVLoad";
            this.ContextDGVLoad.Size = new System.Drawing.Size(213, 56);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.addRowToolStripMenuItem.Text = "Add Row";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // addRowToolStripMenuItem2
            // 
            this.addRowToolStripMenuItem2.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.addRowToolStripMenuItem2.Name = "addRowToolStripMenuItem2";
            this.addRowToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.addRowToolStripMenuItem2.Size = new System.Drawing.Size(212, 26);
            this.addRowToolStripMenuItem2.Text = "Delete Row";
            this.addRowToolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Remote_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 377);
            this.Controls.Add(this.DgvRC);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUnitCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Remote_Connection";
            this.Text = "Remote Connection";
            this.Load += new System.EventHandler(this.Remote_Connection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoadRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRC)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ContextDGVLoad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblSearch;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUnitCancel;
        public System.Windows.Forms.DataGridView DGVLoadRC;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblsource;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtCordinate;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtsource;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbsearch;
        public SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        public SparrowRMSControl.SparrowControl.SparrowButton btnConnection;
        public System.Windows.Forms.DataGridView DgvRC;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextDGVLoad;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn SysNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dtination;
    }
}

