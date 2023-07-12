
namespace HindalcoiOS.InventoryMgmt
{
    partial class VendorMasterView
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
            this.gbxAddVendor = new System.Windows.Forms.GroupBox();
            this.btnAddVendor = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnVendorCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblVendorAddress = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblVendorContPerson = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblVendorEmail = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblVendorContact = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblVendorCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblVendorName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtVendorAddress = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtVendorContPerson = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtVendorContact = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtVendorEmail = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtVendorCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtVendorName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.gbxViewVendor = new System.Windows.Forms.GroupBox();
            this.dgvViewVendorMaster = new System.Windows.Forms.DataGridView();
            this.VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxAddVendor.SuspendLayout();
            this.gbxViewVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewVendorMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAddVendor
            // 
            this.gbxAddVendor.Controls.Add(this.btnAddVendor);
            this.gbxAddVendor.Controls.Add(this.btnVendorCancel);
            this.gbxAddVendor.Controls.Add(this.lblVendorAddress);
            this.gbxAddVendor.Controls.Add(this.lblVendorContPerson);
            this.gbxAddVendor.Controls.Add(this.lblVendorEmail);
            this.gbxAddVendor.Controls.Add(this.lblVendorContact);
            this.gbxAddVendor.Controls.Add(this.lblVendorCode);
            this.gbxAddVendor.Controls.Add(this.lblVendorName);
            this.gbxAddVendor.Controls.Add(this.txtVendorAddress);
            this.gbxAddVendor.Controls.Add(this.txtVendorContPerson);
            this.gbxAddVendor.Controls.Add(this.txtVendorContact);
            this.gbxAddVendor.Controls.Add(this.txtVendorEmail);
            this.gbxAddVendor.Controls.Add(this.txtVendorCode);
            this.gbxAddVendor.Controls.Add(this.txtVendorName);
            this.gbxAddVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddVendor.Location = new System.Drawing.Point(12, 1);
            this.gbxAddVendor.Name = "gbxAddVendor";
            this.gbxAddVendor.Size = new System.Drawing.Size(905, 167);
            this.gbxAddVendor.TabIndex = 0;
            this.gbxAddVendor.TabStop = false;
            this.gbxAddVendor.Text = "Add Vendor";
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddVendor.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddVendor.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddVendor.BorderRadius = 14;
            this.btnAddVendor.BorderSize = 0;
            this.btnAddVendor.FlatAppearance.BorderSize = 0;
            this.btnAddVendor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddVendor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVendor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVendor.ForeColor = System.Drawing.Color.White;
            this.btnAddVendor.Location = new System.Drawing.Point(776, 30);
            this.btnAddVendor.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddVendor.Size = new System.Drawing.Size(112, 30);
            this.btnAddVendor.TabIndex = 51;
            this.btnAddVendor.Text = "Add";
            this.btnAddVendor.TextColor = System.Drawing.Color.White;
            this.btnAddVendor.UseVisualStyleBackColor = false;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // btnVendorCancel
            // 
            this.btnVendorCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVendorCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnVendorCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnVendorCancel.BorderRadius = 14;
            this.btnVendorCancel.BorderSize = 0;
            this.btnVendorCancel.FlatAppearance.BorderSize = 0;
            this.btnVendorCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnVendorCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnVendorCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendorCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendorCancel.ForeColor = System.Drawing.Color.White;
            this.btnVendorCancel.Location = new System.Drawing.Point(776, 82);
            this.btnVendorCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnVendorCancel.Name = "btnVendorCancel";
            this.btnVendorCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnVendorCancel.Size = new System.Drawing.Size(112, 30);
            this.btnVendorCancel.TabIndex = 50;
            this.btnVendorCancel.Text = "Cancel";
            this.btnVendorCancel.TextColor = System.Drawing.Color.White;
            this.btnVendorCancel.UseVisualStyleBackColor = false;
            this.btnVendorCancel.Click += new System.EventHandler(this.btnVendorCancel_Click);
            // 
            // lblVendorAddress
            // 
            this.lblVendorAddress.AutoSize = true;
            this.lblVendorAddress.Depth = 0;
            this.lblVendorAddress.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVendorAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVendorAddress.Location = new System.Drawing.Point(433, 133);
            this.lblVendorAddress.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblVendorAddress.Name = "lblVendorAddress";
            this.lblVendorAddress.Size = new System.Drawing.Size(60, 18);
            this.lblVendorAddress.TabIndex = 49;
            this.lblVendorAddress.Text = "Address";
            // 
            // lblVendorContPerson
            // 
            this.lblVendorContPerson.AutoSize = true;
            this.lblVendorContPerson.Depth = 0;
            this.lblVendorContPerson.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVendorContPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVendorContPerson.Location = new System.Drawing.Point(433, 82);
            this.lblVendorContPerson.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblVendorContPerson.Name = "lblVendorContPerson";
            this.lblVendorContPerson.Size = new System.Drawing.Size(107, 18);
            this.lblVendorContPerson.TabIndex = 48;
            this.lblVendorContPerson.Text = "Contact Person";
            // 
            // lblVendorEmail
            // 
            this.lblVendorEmail.AutoSize = true;
            this.lblVendorEmail.Depth = 0;
            this.lblVendorEmail.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVendorEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVendorEmail.Location = new System.Drawing.Point(433, 35);
            this.lblVendorEmail.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblVendorEmail.Name = "lblVendorEmail";
            this.lblVendorEmail.Size = new System.Drawing.Size(41, 18);
            this.lblVendorEmail.TabIndex = 47;
            this.lblVendorEmail.Text = "Email";
            // 
            // lblVendorContact
            // 
            this.lblVendorContact.AutoSize = true;
            this.lblVendorContact.Depth = 0;
            this.lblVendorContact.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVendorContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVendorContact.Location = new System.Drawing.Point(28, 133);
            this.lblVendorContact.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblVendorContact.Name = "lblVendorContact";
            this.lblVendorContact.Size = new System.Drawing.Size(58, 18);
            this.lblVendorContact.TabIndex = 46;
            this.lblVendorContact.Text = "Contact";
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.AutoSize = true;
            this.lblVendorCode.Depth = 0;
            this.lblVendorCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVendorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVendorCode.Location = new System.Drawing.Point(28, 82);
            this.lblVendorCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(92, 18);
            this.lblVendorCode.TabIndex = 45;
            this.lblVendorCode.Text = "Vendor Code";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Depth = 0;
            this.lblVendorName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVendorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVendorName.Location = new System.Drawing.Point(28, 35);
            this.lblVendorName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(98, 18);
            this.lblVendorName.TabIndex = 44;
            this.lblVendorName.Text = "Vendor Name";
            // 
            // txtVendorAddress
            // 
            this.txtVendorAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorAddress.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorAddress.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorAddress.BorderRadius = 0;
            this.txtVendorAddress.BorderSize = 1;
            this.txtVendorAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorAddress.Location = new System.Drawing.Point(544, 119);
            this.txtVendorAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorAddress.Multiline = true;
            this.txtVendorAddress.Name = "txtVendorAddress";
            this.txtVendorAddress.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorAddress.PasswordChar = false;
            this.txtVendorAddress.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorAddress.PlaceholderText = "";
            this.txtVendorAddress.Size = new System.Drawing.Size(210, 35);
            this.txtVendorAddress.TabIndex = 43;
            this.txtVendorAddress.UnderlinedStyle = false;
            // 
            // txtVendorContPerson
            // 
            this.txtVendorContPerson.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorContPerson.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorContPerson.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorContPerson.BorderRadius = 0;
            this.txtVendorContPerson.BorderSize = 1;
            this.txtVendorContPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorContPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorContPerson.Location = new System.Drawing.Point(544, 72);
            this.txtVendorContPerson.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorContPerson.Multiline = true;
            this.txtVendorContPerson.Name = "txtVendorContPerson";
            this.txtVendorContPerson.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorContPerson.PasswordChar = false;
            this.txtVendorContPerson.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorContPerson.PlaceholderText = "";
            this.txtVendorContPerson.Size = new System.Drawing.Size(210, 35);
            this.txtVendorContPerson.TabIndex = 42;
            this.txtVendorContPerson.UnderlinedStyle = false;
            this.txtVendorContPerson.Leave += new System.EventHandler(this.txtVendorContact_Leave);
            // 
            // txtVendorContact
            // 
            this.txtVendorContact.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorContact.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorContact.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorContact.BorderRadius = 0;
            this.txtVendorContact.BorderSize = 1;
            this.txtVendorContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorContact.Location = new System.Drawing.Point(141, 119);
            this.txtVendorContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorContact.Multiline = true;
            this.txtVendorContact.Name = "txtVendorContact";
            this.txtVendorContact.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorContact.PasswordChar = false;
            this.txtVendorContact.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorContact.PlaceholderText = "";
            this.txtVendorContact.Size = new System.Drawing.Size(210, 35);
            this.txtVendorContact.TabIndex = 40;
            this.txtVendorContact.UnderlinedStyle = false;
            // 
            // txtVendorEmail
            // 
            this.txtVendorEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorEmail.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorEmail.BorderRadius = 0;
            this.txtVendorEmail.BorderSize = 1;
            this.txtVendorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorEmail.Location = new System.Drawing.Point(544, 26);
            this.txtVendorEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorEmail.Multiline = true;
            this.txtVendorEmail.Name = "txtVendorEmail";
            this.txtVendorEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorEmail.PasswordChar = false;
            this.txtVendorEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorEmail.PlaceholderText = "";
            this.txtVendorEmail.Size = new System.Drawing.Size(210, 35);
            this.txtVendorEmail.TabIndex = 41;
            this.txtVendorEmail.UnderlinedStyle = false;
            this.txtVendorEmail.Leave += new System.EventHandler(this.txtVendorEmail_Leave);
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorCode.BorderRadius = 0;
            this.txtVendorCode.BorderSize = 1;
            this.txtVendorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorCode.Location = new System.Drawing.Point(141, 71);
            this.txtVendorCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorCode.Multiline = true;
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorCode.PasswordChar = false;
            this.txtVendorCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorCode.PlaceholderText = "";
            this.txtVendorCode.Size = new System.Drawing.Size(210, 35);
            this.txtVendorCode.TabIndex = 39;
            this.txtVendorCode.UnderlinedStyle = false;
            // 
            // txtVendorName
            // 
            this.txtVendorName.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorName.BorderRadius = 0;
            this.txtVendorName.BorderSize = 1;
            this.txtVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorName.Location = new System.Drawing.Point(141, 25);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorName.Multiline = true;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorName.PasswordChar = false;
            this.txtVendorName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorName.PlaceholderText = "";
            this.txtVendorName.Size = new System.Drawing.Size(210, 35);
            this.txtVendorName.TabIndex = 38;
            this.txtVendorName.UnderlinedStyle = false;
            // 
            // gbxViewVendor
            // 
            this.gbxViewVendor.Controls.Add(this.dgvViewVendorMaster);
            this.gbxViewVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxViewVendor.Location = new System.Drawing.Point(12, 179);
            this.gbxViewVendor.Name = "gbxViewVendor";
            this.gbxViewVendor.Size = new System.Drawing.Size(905, 187);
            this.gbxViewVendor.TabIndex = 50;
            this.gbxViewVendor.TabStop = false;
            this.gbxViewVendor.Text = "View Vendors";
            // 
            // dgvViewVendorMaster
            // 
            this.dgvViewVendorMaster.AllowUserToAddRows = false;
            this.dgvViewVendorMaster.AllowUserToDeleteRows = false;
            this.dgvViewVendorMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewVendorMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewVendorMaster.ColumnHeadersHeight = 35;
            this.dgvViewVendorMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewVendorMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendorName,
            this.VendorCode,
            this.Contact,
            this.ContactPerson,
            this.EmailID,
            this.CreatedDate,
            this.Address});
            this.dgvViewVendorMaster.EnableHeadersVisualStyles = false;
            this.dgvViewVendorMaster.Location = new System.Drawing.Point(18, 25);
            this.dgvViewVendorMaster.Name = "dgvViewVendorMaster";
            this.dgvViewVendorMaster.ReadOnly = true;
            this.dgvViewVendorMaster.RowHeadersWidth = 51;
            this.dgvViewVendorMaster.RowTemplate.Height = 24;
            this.dgvViewVendorMaster.Size = new System.Drawing.Size(870, 144);
            this.dgvViewVendorMaster.TabIndex = 0;
            this.dgvViewVendorMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewVendorMaster_CellDoubleClick);
            // 
            // VendorName
            // 
            this.VendorName.HeaderText = "Vendor Name";
            this.VendorName.MinimumWidth = 6;
            this.VendorName.Name = "VendorName";
            this.VendorName.ReadOnly = true;
            // 
            // VendorCode
            // 
            this.VendorCode.HeaderText = "Vendor Code";
            this.VendorCode.MinimumWidth = 6;
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.ReadOnly = true;
            // 
            // Contact
            // 
            this.Contact.HeaderText = "Contact";
            this.Contact.MinimumWidth = 6;
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // ContactPerson
            // 
            this.ContactPerson.HeaderText = "Contact Person";
            this.ContactPerson.MinimumWidth = 6;
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.ReadOnly = true;
            // 
            // EmailID
            // 
            this.EmailID.HeaderText = "Email ID";
            this.EmailID.MinimumWidth = 6;
            this.EmailID.Name = "EmailID";
            this.EmailID.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // VendorMasterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 378);
            this.Controls.Add(this.gbxViewVendor);
            this.Controls.Add(this.gbxAddVendor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendorMasterView";
            this.Text = "Vendor Master";
            this.Load += new System.EventHandler(this.VendorMasterView_Load);
            this.gbxAddVendor.ResumeLayout(false);
            this.gbxAddVendor.PerformLayout();
            this.gbxViewVendor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewVendorMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddVendor;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblVendorAddress;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblVendorContPerson;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblVendorEmail;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblVendorContact;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblVendorCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblVendorName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorAddress;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorContPerson;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorContact;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorEmail;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorName;
        private System.Windows.Forms.GroupBox gbxViewVendor;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddVendor;
        private SparrowRMSControl.SparrowControl.SparrowButton btnVendorCancel;
        private System.Windows.Forms.DataGridView dgvViewVendorMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}