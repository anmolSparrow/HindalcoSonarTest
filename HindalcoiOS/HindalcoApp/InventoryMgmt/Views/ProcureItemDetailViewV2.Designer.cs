
namespace HindalcoiOS.InventoryMgmt
{
    partial class ProcureItemDetailView
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
            this.nUpdnProcureUnitCost = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.btnAddnewItem = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblTotCost = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblRate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblInputQty = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblBatchNo = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblProcureCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblProcureSubCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblUnit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblItem = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnProcItemDetailAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnProcItemDetailDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtProcureTotCost = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtProcBatchno = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtItemSubcategory = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtItemCategory = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtProcureUnit = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbProcureItem = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.dpnProcureQty = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.gbxConsumpItemDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpdnProcureUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpnProcureQty)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxConsumpItemDetail
            // 
            this.gbxConsumpItemDetail.Controls.Add(this.dpnProcureQty);
            this.gbxConsumpItemDetail.Controls.Add(this.nUpdnProcureUnitCost);
            this.gbxConsumpItemDetail.Controls.Add(this.btnAddnewItem);
            this.gbxConsumpItemDetail.Controls.Add(this.lblTotCost);
            this.gbxConsumpItemDetail.Controls.Add(this.lblRate);
            this.gbxConsumpItemDetail.Controls.Add(this.lblInputQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblBatchNo);
            this.gbxConsumpItemDetail.Controls.Add(this.lblProcureCat);
            this.gbxConsumpItemDetail.Controls.Add(this.lblProcureSubCat);
            this.gbxConsumpItemDetail.Controls.Add(this.lblUnit);
            this.gbxConsumpItemDetail.Controls.Add(this.lblItem);
            this.gbxConsumpItemDetail.Controls.Add(this.btnProcItemDetailAdd);
            this.gbxConsumpItemDetail.Controls.Add(this.btnProcItemDetailDelete);
            this.gbxConsumpItemDetail.Controls.Add(this.txtProcureTotCost);
            this.gbxConsumpItemDetail.Controls.Add(this.txtProcBatchno);
            this.gbxConsumpItemDetail.Controls.Add(this.txtItemSubcategory);
            this.gbxConsumpItemDetail.Controls.Add(this.txtItemCategory);
            this.gbxConsumpItemDetail.Controls.Add(this.txtProcureUnit);
            this.gbxConsumpItemDetail.Controls.Add(this.cmbProcureItem);
            this.gbxConsumpItemDetail.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConsumpItemDetail.Location = new System.Drawing.Point(7, 12);
            this.gbxConsumpItemDetail.Name = "gbxConsumpItemDetail";
            this.gbxConsumpItemDetail.Size = new System.Drawing.Size(822, 265);
            this.gbxConsumpItemDetail.TabIndex = 0;
            this.gbxConsumpItemDetail.TabStop = false;
            this.gbxConsumpItemDetail.Text = "Add Item";
            // 
            // nUpdnProcureUnitCost
            // 
            this.nUpdnProcureUnitCost.BorderColor = System.Drawing.Color.DodgerBlue;
            this.nUpdnProcureUnitCost.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpdnProcureUnitCost.Location = new System.Drawing.Point(597, 130);
            this.nUpdnProcureUnitCost.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nUpdnProcureUnitCost.Name = "nUpdnProcureUnitCost";
            this.nUpdnProcureUnitCost.Size = new System.Drawing.Size(212, 31);
            this.nUpdnProcureUnitCost.TabIndex = 39;
            this.nUpdnProcureUnitCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nUpdnProcureUnitCost_KeyDown);
            this.nUpdnProcureUnitCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nUpdnProcureUnitCost_KeyUp);
            // 
            // btnAddnewItem
            // 
            this.btnAddnewItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddnewItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddnewItem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddnewItem.BorderRadius = 14;
            this.btnAddnewItem.BorderSize = 0;
            this.btnAddnewItem.FlatAppearance.BorderSize = 0;
            this.btnAddnewItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddnewItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddnewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddnewItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddnewItem.ForeColor = System.Drawing.Color.White;
            this.btnAddnewItem.Location = new System.Drawing.Point(355, 24);
            this.btnAddnewItem.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddnewItem.Name = "btnAddnewItem";
            this.btnAddnewItem.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddnewItem.Size = new System.Drawing.Size(117, 30);
            this.btnAddnewItem.TabIndex = 38;
            this.btnAddnewItem.Text = "Add New Item";
            this.btnAddnewItem.TextColor = System.Drawing.Color.White;
            this.btnAddnewItem.UseVisualStyleBackColor = false;
            this.btnAddnewItem.Click += new System.EventHandler(this.btnAddnewItem_Click);
            // 
            // lblTotCost
            // 
            this.lblTotCost.AutoSize = true;
            this.lblTotCost.Depth = 0;
            this.lblTotCost.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTotCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotCost.Location = new System.Drawing.Point(488, 192);
            this.lblTotCost.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblTotCost.Name = "lblTotCost";
            this.lblTotCost.Size = new System.Drawing.Size(75, 18);
            this.lblTotCost.TabIndex = 37;
            this.lblTotCost.Text = "Total Cost";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Depth = 0;
            this.lblRate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRate.Location = new System.Drawing.Point(488, 137);
            this.lblRate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(67, 18);
            this.lblRate.TabIndex = 36;
            this.lblRate.Text = "Unit Cost";
            // 
            // lblInputQty
            // 
            this.lblInputQty.AutoSize = true;
            this.lblInputQty.Depth = 0;
            this.lblInputQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblInputQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInputQty.Location = new System.Drawing.Point(488, 85);
            this.lblInputQty.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblInputQty.Name = "lblInputQty";
            this.lblInputQty.Size = new System.Drawing.Size(86, 18);
            this.lblInputQty.TabIndex = 35;
            this.lblInputQty.Text = "Procure Qty";
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Depth = 0;
            this.lblBatchNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBatchNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBatchNo.Location = new System.Drawing.Point(488, 34);
            this.lblBatchNo.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(73, 18);
            this.lblBatchNo.TabIndex = 34;
            this.lblBatchNo.Text = "Batch No.";
            // 
            // lblProcureCat
            // 
            this.lblProcureCat.AutoSize = true;
            this.lblProcureCat.Depth = 0;
            this.lblProcureCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblProcureCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProcureCat.Location = new System.Drawing.Point(19, 192);
            this.lblProcureCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblProcureCat.Name = "lblProcureCat";
            this.lblProcureCat.Size = new System.Drawing.Size(67, 18);
            this.lblProcureCat.TabIndex = 33;
            this.lblProcureCat.Text = "Category";
            // 
            // lblProcureSubCat
            // 
            this.lblProcureSubCat.AutoSize = true;
            this.lblProcureSubCat.Depth = 0;
            this.lblProcureSubCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblProcureSubCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProcureSubCat.Location = new System.Drawing.Point(18, 138);
            this.lblProcureSubCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblProcureSubCat.Name = "lblProcureSubCat";
            this.lblProcureSubCat.Size = new System.Drawing.Size(96, 18);
            this.lblProcureSubCat.TabIndex = 32;
            this.lblProcureSubCat.Text = "Sub Category";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Depth = 0;
            this.lblUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUnit.Location = new System.Drawing.Point(18, 83);
            this.lblUnit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(33, 18);
            this.lblUnit.TabIndex = 31;
            this.lblUnit.Text = "Unit";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Depth = 0;
            this.lblItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItem.Location = new System.Drawing.Point(17, 35);
            this.lblItem.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(40, 18);
            this.lblItem.TabIndex = 29;
            this.lblItem.Text = "Item";
            // 
            // btnProcItemDetailAdd
            // 
            this.btnProcItemDetailAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnProcItemDetailAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnProcItemDetailAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnProcItemDetailAdd.BorderRadius = 14;
            this.btnProcItemDetailAdd.BorderSize = 0;
            this.btnProcItemDetailAdd.FlatAppearance.BorderSize = 0;
            this.btnProcItemDetailAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnProcItemDetailAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnProcItemDetailAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcItemDetailAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcItemDetailAdd.ForeColor = System.Drawing.Color.White;
            this.btnProcItemDetailAdd.Location = new System.Drawing.Point(698, 224);
            this.btnProcItemDetailAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnProcItemDetailAdd.Name = "btnProcItemDetailAdd";
            this.btnProcItemDetailAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnProcItemDetailAdd.Size = new System.Drawing.Size(112, 30);
            this.btnProcItemDetailAdd.TabIndex = 28;
            this.btnProcItemDetailAdd.Text = "Save";
            this.btnProcItemDetailAdd.TextColor = System.Drawing.Color.White;
            this.btnProcItemDetailAdd.UseVisualStyleBackColor = false;
            this.btnProcItemDetailAdd.Click += new System.EventHandler(this.btnProcItemDetailAdd_Click);
            // 
            // btnProcItemDetailDelete
            // 
            this.btnProcItemDetailDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnProcItemDetailDelete.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnProcItemDetailDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnProcItemDetailDelete.BorderRadius = 14;
            this.btnProcItemDetailDelete.BorderSize = 0;
            this.btnProcItemDetailDelete.FlatAppearance.BorderSize = 0;
            this.btnProcItemDetailDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnProcItemDetailDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnProcItemDetailDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcItemDetailDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcItemDetailDelete.ForeColor = System.Drawing.Color.White;
            this.btnProcItemDetailDelete.Location = new System.Drawing.Point(597, 224);
            this.btnProcItemDetailDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnProcItemDetailDelete.Name = "btnProcItemDetailDelete";
            this.btnProcItemDetailDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnProcItemDetailDelete.Size = new System.Drawing.Size(87, 30);
            this.btnProcItemDetailDelete.TabIndex = 27;
            this.btnProcItemDetailDelete.Text = "Delete";
            this.btnProcItemDetailDelete.TextColor = System.Drawing.Color.White;
            this.btnProcItemDetailDelete.UseVisualStyleBackColor = false;
            this.btnProcItemDetailDelete.Click += new System.EventHandler(this.btnProcItemDetailDelete_Click);
            // 
            // txtProcureTotCost
            // 
            this.txtProcureTotCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtProcureTotCost.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtProcureTotCost.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtProcureTotCost.BorderRadius = 0;
            this.txtProcureTotCost.BorderSize = 1;
            this.txtProcureTotCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcureTotCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProcureTotCost.Location = new System.Drawing.Point(600, 185);
            this.txtProcureTotCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcureTotCost.Multiline = true;
            this.txtProcureTotCost.Name = "txtProcureTotCost";
            this.txtProcureTotCost.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtProcureTotCost.PasswordChar = false;
            this.txtProcureTotCost.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtProcureTotCost.PlaceholderText = "";
            this.txtProcureTotCost.Size = new System.Drawing.Size(210, 35);
            this.txtProcureTotCost.TabIndex = 26;
            this.txtProcureTotCost.UnderlinedStyle = false;
            // 
            // txtProcBatchno
            // 
            this.txtProcBatchno.BackColor = System.Drawing.SystemColors.Window;
            this.txtProcBatchno.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtProcBatchno.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtProcBatchno.BorderRadius = 0;
            this.txtProcBatchno.BorderSize = 1;
            this.txtProcBatchno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcBatchno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProcBatchno.Location = new System.Drawing.Point(600, 20);
            this.txtProcBatchno.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcBatchno.Multiline = true;
            this.txtProcBatchno.Name = "txtProcBatchno";
            this.txtProcBatchno.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtProcBatchno.PasswordChar = false;
            this.txtProcBatchno.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtProcBatchno.PlaceholderText = "";
            this.txtProcBatchno.Size = new System.Drawing.Size(210, 35);
            this.txtProcBatchno.TabIndex = 23;
            this.txtProcBatchno.UnderlinedStyle = false;
            // 
            // txtItemSubcategory
            // 
            this.txtItemSubcategory.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemSubcategory.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtItemSubcategory.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtItemSubcategory.BorderRadius = 0;
            this.txtItemSubcategory.BorderSize = 1;
            this.txtItemSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubcategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtItemSubcategory.Location = new System.Drawing.Point(133, 129);
            this.txtItemSubcategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemSubcategory.Multiline = true;
            this.txtItemSubcategory.Name = "txtItemSubcategory";
            this.txtItemSubcategory.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtItemSubcategory.PasswordChar = false;
            this.txtItemSubcategory.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtItemSubcategory.PlaceholderText = "";
            this.txtItemSubcategory.Size = new System.Drawing.Size(210, 35);
            this.txtItemSubcategory.TabIndex = 22;
            this.txtItemSubcategory.UnderlinedStyle = false;
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemCategory.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtItemCategory.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtItemCategory.BorderRadius = 0;
            this.txtItemCategory.BorderSize = 1;
            this.txtItemCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtItemCategory.Location = new System.Drawing.Point(133, 185);
            this.txtItemCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemCategory.Multiline = true;
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtItemCategory.PasswordChar = false;
            this.txtItemCategory.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtItemCategory.PlaceholderText = "";
            this.txtItemCategory.Size = new System.Drawing.Size(210, 35);
            this.txtItemCategory.TabIndex = 21;
            this.txtItemCategory.UnderlinedStyle = false;
            // 
            // txtProcureUnit
            // 
            this.txtProcureUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtProcureUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtProcureUnit.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtProcureUnit.BorderRadius = 0;
            this.txtProcureUnit.BorderSize = 1;
            this.txtProcureUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcureUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProcureUnit.Location = new System.Drawing.Point(133, 73);
            this.txtProcureUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcureUnit.Multiline = true;
            this.txtProcureUnit.Name = "txtProcureUnit";
            this.txtProcureUnit.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtProcureUnit.PasswordChar = false;
            this.txtProcureUnit.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtProcureUnit.PlaceholderText = "";
            this.txtProcureUnit.Size = new System.Drawing.Size(210, 35);
            this.txtProcureUnit.TabIndex = 18;
            this.txtProcureUnit.UnderlinedStyle = false;
            // 
            // cmbProcureItem
            // 
            this.cmbProcureItem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbProcureItem.BorderSize = 1;
            this.cmbProcureItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProcureItem.ForeColor = System.Drawing.Color.DimGray;
            this.cmbProcureItem.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbProcureItem.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbProcureItem.ListTextColor = System.Drawing.Color.White;
            this.cmbProcureItem.Location = new System.Drawing.Point(133, 27);
            this.cmbProcureItem.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbProcureItem.Name = "cmbProcureItem";
            this.cmbProcureItem.Size = new System.Drawing.Size(210, 30);
            this.cmbProcureItem.TabIndex = 17;
            this.cmbProcureItem.SelectedIndexChanged += new System.EventHandler(this.cmbProcureItem_SelectedIndexChanged);
            this.cmbProcureItem.Click += new System.EventHandler(this.cmbProcureItem_SelectedIndexChanged);
            this.cmbProcureItem.Leave += new System.EventHandler(this.cmbProcureItem_Leave);
            // 
            // dpnProcureQty
            // 
            this.dpnProcureQty.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dpnProcureQty.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpnProcureQty.Location = new System.Drawing.Point(600, 73);
            this.dpnProcureQty.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.dpnProcureQty.Name = "dpnProcureQty";
            this.dpnProcureQty.Size = new System.Drawing.Size(212, 31);
            this.dpnProcureQty.TabIndex = 40;
            this.dpnProcureQty.ValueChanged += new System.EventHandler(this.nUpdnProcureUnitCost_ValueChanged);
            this.dpnProcureQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nUpdnProcureUnitCost_KeyDown);
            this.dpnProcureQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nUpdnProcureUnitCost_KeyUp);
            this.dpnProcureQty.Leave += new System.EventHandler(this.nUpdnProcureUnitCost_ValueChanged);
            // 
            // ProcureItemDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 290);
            this.Controls.Add(this.gbxConsumpItemDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcureItemDetailView";
            this.Text = "Procure Item Detail";
            this.Load += new System.EventHandler(this.ProcureItemDetailView_Load);
            this.Click += new System.EventHandler(this.ProcureItemDetailView_Load);
            this.gbxConsumpItemDetail.ResumeLayout(false);
            this.gbxConsumpItemDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpdnProcureUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpnProcureQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConsumpItemDetail;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtProcureUnit;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbProcureItem;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtProcureTotCost;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtProcBatchno;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtItemSubcategory;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtItemCategory;
        private SparrowRMSControl.SparrowControl.SparrowButton btnProcItemDetailAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnProcItemDetailDelete;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblTotCost;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblRate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblInputQty;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblBatchNo;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblProcureCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblProcureSubCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUnit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblItem;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddnewItem;
        private SparrowRMSControl.SparrowControl.SparrowNumericUpDown nUpdnProcureUnitCost;
        private SparrowRMSControl.SparrowControl.SparrowNumericUpDown dpnProcureQty;
    }
}