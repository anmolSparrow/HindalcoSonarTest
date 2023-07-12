
namespace HindalcoiOS.InventoryMgmt
{
    partial class ReturnItemDetailView
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
            this.gbxConsumpItemDetail = new System.Windows.Forms.GroupBox();
            this.dpnReturnQty = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.lblConsumedQty = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtConsumedQty = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblReturnTotCost = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblReturnRate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblReturnQty = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumpCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblReturnSubCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblReturnUnit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblReturnBatchNo = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblReturnItem = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnReturnItemDetailAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnReturnDetailDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtReturnTotCost = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtReturnUnitCost = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtReturnCat = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtReturnSubCat = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbReturnbatch = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.txtReturnUnit = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbReturnItem = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.gbxConsumpItemDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpnReturnQty)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxConsumpItemDetail
            // 
            this.gbxConsumpItemDetail.Controls.Add(this.dpnReturnQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumedQty);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumedQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnTotCost);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnRate);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumpCat);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnSubCat);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnUnit);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnBatchNo);
            this.gbxConsumpItemDetail.Controls.Add(this.lblReturnItem);
            this.gbxConsumpItemDetail.Controls.Add(this.btnReturnItemDetailAdd);
            this.gbxConsumpItemDetail.Controls.Add(this.btnReturnDetailDelete);
            this.gbxConsumpItemDetail.Controls.Add(this.txtReturnTotCost);
            this.gbxConsumpItemDetail.Controls.Add(this.txtReturnUnitCost);
            this.gbxConsumpItemDetail.Controls.Add(this.txtReturnCat);
            this.gbxConsumpItemDetail.Controls.Add(this.txtReturnSubCat);
            this.gbxConsumpItemDetail.Controls.Add(this.cmbReturnbatch);
            this.gbxConsumpItemDetail.Controls.Add(this.txtReturnUnit);
            this.gbxConsumpItemDetail.Controls.Add(this.cmbReturnItem);
            this.gbxConsumpItemDetail.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConsumpItemDetail.Location = new System.Drawing.Point(21, 9);
            this.gbxConsumpItemDetail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbxConsumpItemDetail.Name = "gbxConsumpItemDetail";
            this.gbxConsumpItemDetail.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbxConsumpItemDetail.Size = new System.Drawing.Size(1397, 433);
            this.gbxConsumpItemDetail.TabIndex = 1;
            this.gbxConsumpItemDetail.TabStop = false;
            this.gbxConsumpItemDetail.Text = "Add Item";
            // 
            // dpnReturnQty
            // 
            this.dpnReturnQty.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dpnReturnQty.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpnReturnQty.Location = new System.Drawing.Point(1011, 111);
            this.dpnReturnQty.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dpnReturnQty.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.dpnReturnQty.Name = "dpnReturnQty";
            this.dpnReturnQty.Size = new System.Drawing.Size(360, 44);
            this.dpnReturnQty.TabIndex = 40;
            this.dpnReturnQty.ValueChanged += new System.EventHandler(this.dpnReturnQty_ValueChanged);
            // 
            // lblConsumedQty
            // 
            this.lblConsumedQty.AutoSize = true;
            this.lblConsumedQty.Depth = 0;
            this.lblConsumedQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumedQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumedQty.Location = new System.Drawing.Point(809, 45);
            this.lblConsumedQty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConsumedQty.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumedQty.Name = "lblConsumedQty";
            this.lblConsumedQty.Size = new System.Drawing.Size(168, 29);
            this.lblConsumedQty.TabIndex = 39;
            this.lblConsumedQty.Text = "Consumed Qty";
            // 
            // txtConsumedQty
            // 
            this.txtConsumedQty.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumedQty.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumedQty.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumedQty.BorderRadius = 0;
            this.txtConsumedQty.BorderSize = 1;
            this.txtConsumedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumedQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumedQty.Location = new System.Drawing.Point(1011, 31);
            this.txtConsumedQty.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtConsumedQty.Multiline = true;
            this.txtConsumedQty.Name = "txtConsumedQty";
            this.txtConsumedQty.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtConsumedQty.PasswordChar = false;
            this.txtConsumedQty.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumedQty.PlaceholderText = "";
            this.txtConsumedQty.Size = new System.Drawing.Size(360, 55);
            this.txtConsumedQty.TabIndex = 38;
            this.txtConsumedQty.UnderlinedStyle = false;
            // 
            // lblReturnTotCost
            // 
            this.lblReturnTotCost.AutoSize = true;
            this.lblReturnTotCost.Depth = 0;
            this.lblReturnTotCost.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReturnTotCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnTotCost.Location = new System.Drawing.Point(809, 280);
            this.lblReturnTotCost.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnTotCost.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnTotCost.Name = "lblReturnTotCost";
            this.lblReturnTotCost.Size = new System.Drawing.Size(120, 29);
            this.lblReturnTotCost.TabIndex = 37;
            this.lblReturnTotCost.Text = "Total Cost";
            // 
            // lblReturnRate
            // 
            this.lblReturnRate.AutoSize = true;
            this.lblReturnRate.Depth = 0;
            this.lblReturnRate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReturnRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnRate.Location = new System.Drawing.Point(809, 192);
            this.lblReturnRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnRate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnRate.Name = "lblReturnRate";
            this.lblReturnRate.Size = new System.Drawing.Size(109, 29);
            this.lblReturnRate.TabIndex = 36;
            this.lblReturnRate.Text = "Unit Cost";
            // 
            // lblReturnQty
            // 
            this.lblReturnQty.AutoSize = true;
            this.lblReturnQty.Depth = 0;
            this.lblReturnQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReturnQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnQty.Location = new System.Drawing.Point(809, 119);
            this.lblReturnQty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnQty.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnQty.Name = "lblReturnQty";
            this.lblReturnQty.Size = new System.Drawing.Size(155, 29);
            this.lblReturnQty.TabIndex = 35;
            this.lblReturnQty.Text = "Returned Qty";
            // 
            // lblConsumpCat
            // 
            this.lblConsumpCat.AutoSize = true;
            this.lblConsumpCat.Depth = 0;
            this.lblConsumpCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumpCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumpCat.Location = new System.Drawing.Point(29, 341);
            this.lblConsumpCat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConsumpCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumpCat.Name = "lblConsumpCat";
            this.lblConsumpCat.Size = new System.Drawing.Size(108, 29);
            this.lblConsumpCat.TabIndex = 33;
            this.lblConsumpCat.Text = "Category";
            // 
            // lblReturnSubCat
            // 
            this.lblReturnSubCat.AutoSize = true;
            this.lblReturnSubCat.Depth = 0;
            this.lblReturnSubCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReturnSubCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnSubCat.Location = new System.Drawing.Point(29, 270);
            this.lblReturnSubCat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnSubCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnSubCat.Name = "lblReturnSubCat";
            this.lblReturnSubCat.Size = new System.Drawing.Size(155, 29);
            this.lblReturnSubCat.TabIndex = 32;
            this.lblReturnSubCat.Text = "Sub Category";
            // 
            // lblReturnUnit
            // 
            this.lblReturnUnit.AutoSize = true;
            this.lblReturnUnit.Depth = 0;
            this.lblReturnUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReturnUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnUnit.Location = new System.Drawing.Point(29, 189);
            this.lblReturnUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnUnit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnUnit.Name = "lblReturnUnit";
            this.lblReturnUnit.Size = new System.Drawing.Size(55, 29);
            this.lblReturnUnit.TabIndex = 31;
            this.lblReturnUnit.Text = "Unit";
            // 
            // lblReturnBatchNo
            // 
            this.lblReturnBatchNo.AutoSize = true;
            this.lblReturnBatchNo.Depth = 0;
            this.lblReturnBatchNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReturnBatchNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnBatchNo.Location = new System.Drawing.Point(29, 112);
            this.lblReturnBatchNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnBatchNo.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnBatchNo.Name = "lblReturnBatchNo";
            this.lblReturnBatchNo.Size = new System.Drawing.Size(109, 29);
            this.lblReturnBatchNo.TabIndex = 30;
            this.lblReturnBatchNo.Text = "Batch No";
            // 
            // lblReturnItem
            // 
            this.lblReturnItem.AutoSize = true;
            this.lblReturnItem.Depth = 0;
            this.lblReturnItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReturnItem.Location = new System.Drawing.Point(29, 45);
            this.lblReturnItem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReturnItem.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblReturnItem.Name = "lblReturnItem";
            this.lblReturnItem.Size = new System.Drawing.Size(63, 29);
            this.lblReturnItem.TabIndex = 29;
            this.lblReturnItem.Text = "Item";
            // 
            // btnReturnItemDetailAdd
            // 
            this.btnReturnItemDetailAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnItemDetailAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnItemDetailAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnItemDetailAdd.BorderRadius = 14;
            this.btnReturnItemDetailAdd.BorderSize = 0;
            this.btnReturnItemDetailAdd.FlatAppearance.BorderSize = 0;
            this.btnReturnItemDetailAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReturnItemDetailAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReturnItemDetailAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnItemDetailAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnItemDetailAdd.ForeColor = System.Drawing.Color.White;
            this.btnReturnItemDetailAdd.Location = new System.Drawing.Point(1179, 350);
            this.btnReturnItemDetailAdd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnReturnItemDetailAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReturnItemDetailAdd.Name = "btnReturnItemDetailAdd";
            this.btnReturnItemDetailAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReturnItemDetailAdd.Size = new System.Drawing.Size(192, 47);
            this.btnReturnItemDetailAdd.TabIndex = 28;
            this.btnReturnItemDetailAdd.Text = "Add Item";
            this.btnReturnItemDetailAdd.TextColor = System.Drawing.Color.White;
            this.btnReturnItemDetailAdd.UseVisualStyleBackColor = false;
            this.btnReturnItemDetailAdd.Click += new System.EventHandler(this.btnReturnItemDetailAdd_Click);
            // 
            // btnReturnDetailDelete
            // 
            this.btnReturnDetailDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnDetailDelete.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnDetailDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnDetailDelete.BorderRadius = 14;
            this.btnReturnDetailDelete.BorderSize = 0;
            this.btnReturnDetailDelete.FlatAppearance.BorderSize = 0;
            this.btnReturnDetailDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReturnDetailDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReturnDetailDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnDetailDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnDetailDelete.ForeColor = System.Drawing.Color.White;
            this.btnReturnDetailDelete.Location = new System.Drawing.Point(1011, 350);
            this.btnReturnDetailDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnReturnDetailDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReturnDetailDelete.Name = "btnReturnDetailDelete";
            this.btnReturnDetailDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReturnDetailDelete.Size = new System.Drawing.Size(149, 47);
            this.btnReturnDetailDelete.TabIndex = 27;
            this.btnReturnDetailDelete.Text = "Delete";
            this.btnReturnDetailDelete.TextColor = System.Drawing.Color.White;
            this.btnReturnDetailDelete.UseVisualStyleBackColor = false;
            this.btnReturnDetailDelete.Click += new System.EventHandler(this.btnReturnDetailDelete_Click);
            // 
            // txtReturnTotCost
            // 
            this.txtReturnTotCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtReturnTotCost.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtReturnTotCost.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtReturnTotCost.BorderRadius = 0;
            this.txtReturnTotCost.BorderSize = 1;
            this.txtReturnTotCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnTotCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReturnTotCost.Location = new System.Drawing.Point(1011, 270);
            this.txtReturnTotCost.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtReturnTotCost.Multiline = true;
            this.txtReturnTotCost.Name = "txtReturnTotCost";
            this.txtReturnTotCost.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtReturnTotCost.PasswordChar = false;
            this.txtReturnTotCost.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReturnTotCost.PlaceholderText = "";
            this.txtReturnTotCost.Size = new System.Drawing.Size(360, 55);
            this.txtReturnTotCost.TabIndex = 26;
            this.txtReturnTotCost.UnderlinedStyle = false;
            // 
            // txtReturnUnitCost
            // 
            this.txtReturnUnitCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtReturnUnitCost.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtReturnUnitCost.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtReturnUnitCost.BorderRadius = 0;
            this.txtReturnUnitCost.BorderSize = 1;
            this.txtReturnUnitCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnUnitCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReturnUnitCost.Location = new System.Drawing.Point(1011, 183);
            this.txtReturnUnitCost.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtReturnUnitCost.Multiline = true;
            this.txtReturnUnitCost.Name = "txtReturnUnitCost";
            this.txtReturnUnitCost.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtReturnUnitCost.PasswordChar = false;
            this.txtReturnUnitCost.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReturnUnitCost.PlaceholderText = "";
            this.txtReturnUnitCost.Size = new System.Drawing.Size(360, 55);
            this.txtReturnUnitCost.TabIndex = 25;
            this.txtReturnUnitCost.UnderlinedStyle = false;
            // 
            // txtReturnCat
            // 
            this.txtReturnCat.BackColor = System.Drawing.SystemColors.Window;
            this.txtReturnCat.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtReturnCat.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtReturnCat.BorderRadius = 0;
            this.txtReturnCat.BorderSize = 1;
            this.txtReturnCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReturnCat.Location = new System.Drawing.Point(207, 341);
            this.txtReturnCat.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtReturnCat.Multiline = true;
            this.txtReturnCat.Name = "txtReturnCat";
            this.txtReturnCat.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtReturnCat.PasswordChar = false;
            this.txtReturnCat.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReturnCat.PlaceholderText = "";
            this.txtReturnCat.Size = new System.Drawing.Size(360, 55);
            this.txtReturnCat.TabIndex = 22;
            this.txtReturnCat.UnderlinedStyle = false;
            // 
            // txtReturnSubCat
            // 
            this.txtReturnSubCat.BackColor = System.Drawing.SystemColors.Window;
            this.txtReturnSubCat.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtReturnSubCat.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtReturnSubCat.BorderRadius = 0;
            this.txtReturnSubCat.BorderSize = 1;
            this.txtReturnSubCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnSubCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReturnSubCat.Location = new System.Drawing.Point(207, 264);
            this.txtReturnSubCat.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtReturnSubCat.Multiline = true;
            this.txtReturnSubCat.Name = "txtReturnSubCat";
            this.txtReturnSubCat.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtReturnSubCat.PasswordChar = false;
            this.txtReturnSubCat.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReturnSubCat.PlaceholderText = "";
            this.txtReturnSubCat.Size = new System.Drawing.Size(360, 55);
            this.txtReturnSubCat.TabIndex = 21;
            this.txtReturnSubCat.UnderlinedStyle = false;
            // 
            // cmbReturnbatch
            // 
            this.cmbReturnbatch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbReturnbatch.BorderSize = 1;
            this.cmbReturnbatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReturnbatch.ForeColor = System.Drawing.Color.DimGray;
            this.cmbReturnbatch.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbReturnbatch.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbReturnbatch.ListTextColor = System.Drawing.Color.White;
            this.cmbReturnbatch.Location = new System.Drawing.Point(207, 103);
            this.cmbReturnbatch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbReturnbatch.MinimumSize = new System.Drawing.Size(340, 0);
            this.cmbReturnbatch.Name = "cmbReturnbatch";
            this.cmbReturnbatch.Size = new System.Drawing.Size(357, 41);
            this.cmbReturnbatch.TabIndex = 19;
            this.cmbReturnbatch.SelectedIndexChanged += new System.EventHandler(this.cmbReturnbatch_SelectedIndexChanged);
            this.cmbReturnbatch.Click += new System.EventHandler(this.cmbReturnbatch_SelectedIndexChanged);
            // 
            // txtReturnUnit
            // 
            this.txtReturnUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtReturnUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtReturnUnit.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtReturnUnit.BorderRadius = 0;
            this.txtReturnUnit.BorderSize = 1;
            this.txtReturnUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReturnUnit.Location = new System.Drawing.Point(207, 181);
            this.txtReturnUnit.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtReturnUnit.Multiline = true;
            this.txtReturnUnit.Name = "txtReturnUnit";
            this.txtReturnUnit.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtReturnUnit.PasswordChar = false;
            this.txtReturnUnit.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReturnUnit.PlaceholderText = "";
            this.txtReturnUnit.Size = new System.Drawing.Size(360, 55);
            this.txtReturnUnit.TabIndex = 18;
            this.txtReturnUnit.UnderlinedStyle = false;
            // 
            // cmbReturnItem
            // 
            this.cmbReturnItem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbReturnItem.BorderSize = 1;
            this.cmbReturnItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReturnItem.ForeColor = System.Drawing.Color.DimGray;
            this.cmbReturnItem.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbReturnItem.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbReturnItem.ListTextColor = System.Drawing.Color.White;
            this.cmbReturnItem.Location = new System.Drawing.Point(207, 27);
            this.cmbReturnItem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbReturnItem.MinimumSize = new System.Drawing.Size(340, 0);
            this.cmbReturnItem.Name = "cmbReturnItem";
            this.cmbReturnItem.Size = new System.Drawing.Size(357, 48);
            this.cmbReturnItem.TabIndex = 17;
            this.cmbReturnItem.SelectedIndexChanged += new System.EventHandler(this.cmbReturnItem_SelectedIndexChanged);
            this.cmbReturnItem.Click += new System.EventHandler(this.cmbReturnItem_SelectedIndexChanged);
            // 
            // ReturnItemDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 453);
            this.Controls.Add(this.gbxConsumpItemDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnItemDetailView";
            this.Text = "Return Item Detail";
            this.Load += new System.EventHandler(this.ReturnItemDetailView_Load);
            this.gbxConsumpItemDetail.ResumeLayout(false);
            this.gbxConsumpItemDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpnReturnQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConsumpItemDetail;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnTotCost;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnRate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnQty;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumpCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnSubCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnUnit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnBatchNo;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblReturnItem;
        private SparrowRMSControl.SparrowControl.SparrowButton btnReturnItemDetailAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnReturnDetailDelete;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtReturnTotCost;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtReturnUnitCost;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtReturnCat;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtReturnSubCat;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbReturnbatch;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtReturnUnit;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbReturnItem;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumedQty;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumedQty;
        private SparrowRMSControl.SparrowControl.SparrowNumericUpDown dpnReturnQty;
    }
}