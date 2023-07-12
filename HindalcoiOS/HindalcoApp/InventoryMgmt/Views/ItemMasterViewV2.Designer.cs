
namespace HindalcoiOS.InventoryMgmt
{
    partial class ItemMasterView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxAddItemDetails = new System.Windows.Forms.GroupBox();
            this.btnExportItem = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnOpeningUpload = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtItemName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dpnThreslimit = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.txtModel = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.btnItemDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnItemCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnItemUpload = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnItemAddUnit = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnItemAddSubCat = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbSubCategory = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.cmbUnit = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblParentCategory = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblSubCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblModel = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblUnit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblThreshold = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblMake = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblItemCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblItemName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtMake = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtParentCategory = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtItemCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.gbxAllItemDetails = new System.Windows.Forms.GroupBox();
            this.dgvItemMaster = new System.Windows.Forms.DataGridView();
            this.sparrowDropdownMenu1 = new SparrowRMSControl.SparrowControl.SparrowDropdownMenu(this.components);
            this.btnCategoryUpload = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.gbxAddItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpnThreslimit)).BeginInit();
            this.gbxAllItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAddItemDetails
            // 
            this.gbxAddItemDetails.Controls.Add(this.btnCategoryUpload);
            this.gbxAddItemDetails.Controls.Add(this.btnExportItem);
            this.gbxAddItemDetails.Controls.Add(this.btnOpeningUpload);
            this.gbxAddItemDetails.Controls.Add(this.txtItemName);
            this.gbxAddItemDetails.Controls.Add(this.dpnThreslimit);
            this.gbxAddItemDetails.Controls.Add(this.txtModel);
            this.gbxAddItemDetails.Controls.Add(this.btnItemDelete);
            this.gbxAddItemDetails.Controls.Add(this.btnItemCancel);
            this.gbxAddItemDetails.Controls.Add(this.btnAdd);
            this.gbxAddItemDetails.Controls.Add(this.btnItemUpload);
            this.gbxAddItemDetails.Controls.Add(this.btnItemAddUnit);
            this.gbxAddItemDetails.Controls.Add(this.btnItemAddSubCat);
            this.gbxAddItemDetails.Controls.Add(this.cmbSubCategory);
            this.gbxAddItemDetails.Controls.Add(this.cmbUnit);
            this.gbxAddItemDetails.Controls.Add(this.lblParentCategory);
            this.gbxAddItemDetails.Controls.Add(this.lblSubCat);
            this.gbxAddItemDetails.Controls.Add(this.lblModel);
            this.gbxAddItemDetails.Controls.Add(this.lblUnit);
            this.gbxAddItemDetails.Controls.Add(this.lblThreshold);
            this.gbxAddItemDetails.Controls.Add(this.lblMake);
            this.gbxAddItemDetails.Controls.Add(this.lblItemCode);
            this.gbxAddItemDetails.Controls.Add(this.lblItemName);
            this.gbxAddItemDetails.Controls.Add(this.txtMake);
            this.gbxAddItemDetails.Controls.Add(this.txtParentCategory);
            this.gbxAddItemDetails.Controls.Add(this.txtItemCode);
            this.gbxAddItemDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddItemDetails.Location = new System.Drawing.Point(12, 1);
            this.gbxAddItemDetails.Name = "gbxAddItemDetails";
            this.gbxAddItemDetails.Size = new System.Drawing.Size(987, 245);
            this.gbxAddItemDetails.TabIndex = 0;
            this.gbxAddItemDetails.TabStop = false;
            this.gbxAddItemDetails.Text = "Add Item Details";
            // 
            // btnExportItem
            // 
            this.btnExportItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportItem.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnExportItem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnExportItem.BorderRadius = 14;
            this.btnExportItem.BorderSize = 0;
            this.btnExportItem.FlatAppearance.BorderSize = 0;
            this.btnExportItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnExportItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnExportItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportItem.Location = new System.Drawing.Point(693, 200);
            this.btnExportItem.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnExportItem.Name = "btnExportItem";
            this.btnExportItem.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnExportItem.Size = new System.Drawing.Size(98, 30);
            this.btnExportItem.TabIndex = 61;
            this.btnExportItem.Text = "Export";
            this.btnExportItem.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportItem.UseVisualStyleBackColor = false;
            this.btnExportItem.Click += new System.EventHandler(this.btnExportItem_Click);
            // 
            // btnOpeningUpload
            // 
            this.btnOpeningUpload.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOpeningUpload.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.btnOpeningUpload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOpeningUpload.BorderRadius = 14;
            this.btnOpeningUpload.BorderSize = 0;
            this.btnOpeningUpload.FlatAppearance.BorderSize = 0;
            this.btnOpeningUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOpeningUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOpeningUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpeningUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpeningUpload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpeningUpload.Location = new System.Drawing.Point(825, 118);
            this.btnOpeningUpload.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOpeningUpload.Name = "btnOpeningUpload";
            this.btnOpeningUpload.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnOpeningUpload.Size = new System.Drawing.Size(142, 30);
            this.btnOpeningUpload.TabIndex = 60;
            this.btnOpeningUpload.Text = "Upload Opening";
            this.btnOpeningUpload.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpeningUpload.UseVisualStyleBackColor = false;
            this.btnOpeningUpload.Visible = false;
            this.btnOpeningUpload.Click += new System.EventHandler(this.btnOpeningUpload_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtItemName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtItemName.BorderRadius = 0;
            this.txtItemName.BorderSize = 1;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtItemName.Location = new System.Drawing.Point(149, 26);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtItemName.PasswordChar = false;
            this.txtItemName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtItemName.PlaceholderText = "";
            this.txtItemName.Size = new System.Drawing.Size(210, 35);
            this.txtItemName.TabIndex = 59;
            this.txtItemName.UnderlinedStyle = false;
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // dpnThreslimit
            // 
            this.dpnThreslimit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dpnThreslimit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpnThreslimit.Location = new System.Drawing.Point(149, 112);
            this.dpnThreslimit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.dpnThreslimit.Name = "dpnThreslimit";
            this.dpnThreslimit.Size = new System.Drawing.Size(210, 30);
            this.dpnThreslimit.TabIndex = 58;
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.Window;
            this.txtModel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtModel.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtModel.BorderRadius = 0;
            this.txtModel.BorderSize = 1;
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtModel.Location = new System.Drawing.Point(149, 193);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Multiline = true;
            this.txtModel.Name = "txtModel";
            this.txtModel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtModel.PasswordChar = false;
            this.txtModel.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtModel.PlaceholderText = "";
            this.txtModel.Size = new System.Drawing.Size(210, 35);
            this.txtModel.TabIndex = 57;
            this.txtModel.UnderlinedStyle = false;
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.BackColor = System.Drawing.Color.Red;
            this.btnItemDelete.BackgroundColor = System.Drawing.Color.Red;
            this.btnItemDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnItemDelete.BorderRadius = 14;
            this.btnItemDelete.BorderSize = 0;
            this.btnItemDelete.FlatAppearance.BorderSize = 0;
            this.btnItemDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemDelete.ForeColor = System.Drawing.Color.White;
            this.btnItemDelete.Location = new System.Drawing.Point(826, 197);
            this.btnItemDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnItemDelete.Size = new System.Drawing.Size(136, 30);
            this.btnItemDelete.TabIndex = 56;
            this.btnItemDelete.Text = "Delete";
            this.btnItemDelete.TextColor = System.Drawing.Color.White;
            this.btnItemDelete.UseVisualStyleBackColor = false;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.BackColor = System.Drawing.Color.DarkGray;
            this.btnItemCancel.BackgroundColor = System.Drawing.Color.DarkGray;
            this.btnItemCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnItemCancel.BorderRadius = 14;
            this.btnItemCancel.BorderSize = 0;
            this.btnItemCancel.FlatAppearance.BorderSize = 0;
            this.btnItemCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemCancel.ForeColor = System.Drawing.Color.White;
            this.btnItemCancel.Location = new System.Drawing.Point(693, 159);
            this.btnItemCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnItemCancel.Size = new System.Drawing.Size(98, 30);
            this.btnItemCancel.TabIndex = 55;
            this.btnItemCancel.Text = "Cancel";
            this.btnItemCancel.TextColor = System.Drawing.Color.White;
            this.btnItemCancel.UseVisualStyleBackColor = false;
            this.btnItemCancel.Click += new System.EventHandler(this.btnItemCancel_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(581, 158);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(94, 30);
            this.btnAdd.TabIndex = 54;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnItemUpload
            // 
            this.btnItemUpload.BackColor = System.Drawing.Color.LimeGreen;
            this.btnItemUpload.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.btnItemUpload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnItemUpload.BorderRadius = 14;
            this.btnItemUpload.BorderSize = 0;
            this.btnItemUpload.FlatAppearance.BorderSize = 0;
            this.btnItemUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemUpload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnItemUpload.Location = new System.Drawing.Point(826, 158);
            this.btnItemUpload.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemUpload.Name = "btnItemUpload";
            this.btnItemUpload.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnItemUpload.Size = new System.Drawing.Size(137, 30);
            this.btnItemUpload.TabIndex = 53;
            this.btnItemUpload.Text = "Upload Item";
            this.btnItemUpload.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnItemUpload.UseVisualStyleBackColor = false;
            this.btnItemUpload.Visible = false;
            this.btnItemUpload.Click += new System.EventHandler(this.btnItemUpload_Click);
            // 
            // btnItemAddUnit
            // 
            this.btnItemAddUnit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnItemAddUnit.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btnItemAddUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnItemAddUnit.BorderRadius = 14;
            this.btnItemAddUnit.BorderSize = 0;
            this.btnItemAddUnit.FlatAppearance.BorderSize = 0;
            this.btnItemAddUnit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemAddUnit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemAddUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemAddUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemAddUnit.ForeColor = System.Drawing.Color.White;
            this.btnItemAddUnit.Location = new System.Drawing.Point(825, 28);
            this.btnItemAddUnit.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemAddUnit.Name = "btnItemAddUnit";
            this.btnItemAddUnit.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnItemAddUnit.Size = new System.Drawing.Size(142, 30);
            this.btnItemAddUnit.TabIndex = 52;
            this.btnItemAddUnit.Text = "Add Unit";
            this.btnItemAddUnit.TextColor = System.Drawing.Color.White;
            this.btnItemAddUnit.UseVisualStyleBackColor = false;
            this.btnItemAddUnit.Click += new System.EventHandler(this.btnItemAddUnit_Click);
            // 
            // btnItemAddSubCat
            // 
            this.btnItemAddSubCat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnItemAddSubCat.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btnItemAddSubCat.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnItemAddSubCat.BorderRadius = 14;
            this.btnItemAddSubCat.BorderSize = 0;
            this.btnItemAddSubCat.FlatAppearance.BorderSize = 0;
            this.btnItemAddSubCat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemAddSubCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemAddSubCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemAddSubCat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemAddSubCat.ForeColor = System.Drawing.Color.White;
            this.btnItemAddSubCat.Location = new System.Drawing.Point(825, 75);
            this.btnItemAddSubCat.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnItemAddSubCat.Name = "btnItemAddSubCat";
            this.btnItemAddSubCat.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnItemAddSubCat.Size = new System.Drawing.Size(145, 30);
            this.btnItemAddSubCat.TabIndex = 51;
            this.btnItemAddSubCat.Text = "Add Sub Category";
            this.btnItemAddSubCat.TextColor = System.Drawing.Color.White;
            this.btnItemAddSubCat.UseVisualStyleBackColor = false;
            this.btnItemAddSubCat.Click += new System.EventHandler(this.btnItemAddSubCat_Click);
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbSubCategory.BorderSize = 1;
            this.cmbSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbSubCategory.ItemHeight = 22;
            this.cmbSubCategory.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbSubCategory.ListTextColor = System.Drawing.Color.White;
            this.cmbSubCategory.Location = new System.Drawing.Point(581, 70);
            this.cmbSubCategory.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(210, 30);
            this.cmbSubCategory.TabIndex = 48;
            this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
            // 
            // cmbUnit
            // 
            this.cmbUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbUnit.BorderSize = 1;
            this.cmbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbUnit.ItemHeight = 22;
            this.cmbUnit.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbUnit.ListTextColor = System.Drawing.Color.White;
            this.cmbUnit.Location = new System.Drawing.Point(581, 28);
            this.cmbUnit.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(210, 30);
            this.cmbUnit.TabIndex = 47;
            // 
            // lblParentCategory
            // 
            this.lblParentCategory.AutoSize = true;
            this.lblParentCategory.Depth = 0;
            this.lblParentCategory.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblParentCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblParentCategory.Location = new System.Drawing.Point(456, 124);
            this.lblParentCategory.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblParentCategory.Name = "lblParentCategory";
            this.lblParentCategory.Size = new System.Drawing.Size(67, 18);
            this.lblParentCategory.TabIndex = 46;
            this.lblParentCategory.Text = "Category";
            // 
            // lblSubCat
            // 
            this.lblSubCat.AutoSize = true;
            this.lblSubCat.Depth = 0;
            this.lblSubCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubCat.Location = new System.Drawing.Point(456, 81);
            this.lblSubCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblSubCat.Name = "lblSubCat";
            this.lblSubCat.Size = new System.Drawing.Size(96, 18);
            this.lblSubCat.TabIndex = 45;
            this.lblSubCat.Text = "Sub Category";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Depth = 0;
            this.lblModel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblModel.Location = new System.Drawing.Point(21, 207);
            this.lblModel.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(46, 18);
            this.lblModel.TabIndex = 44;
            this.lblModel.Text = "Model";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Depth = 0;
            this.lblUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUnit.Location = new System.Drawing.Point(456, 35);
            this.lblUnit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(33, 18);
            this.lblUnit.TabIndex = 43;
            this.lblUnit.Text = "Unit";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Depth = 0;
            this.lblThreshold.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblThreshold.Location = new System.Drawing.Point(21, 121);
            this.lblThreshold.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(106, 18);
            this.lblThreshold.TabIndex = 42;
            this.lblThreshold.Text = "Minimum Stock";
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Depth = 0;
            this.lblMake.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMake.Location = new System.Drawing.Point(21, 164);
            this.lblMake.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(43, 18);
            this.lblMake.TabIndex = 41;
            this.lblMake.Text = "Make";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Depth = 0;
            this.lblItemCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblItemCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemCode.Location = new System.Drawing.Point(21, 74);
            this.lblItemCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(78, 18);
            this.lblItemCode.TabIndex = 40;
            this.lblItemCode.Text = "Item Code";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemName.Location = new System.Drawing.Point(21, 35);
            this.lblItemName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(84, 18);
            this.lblItemName.TabIndex = 39;
            this.lblItemName.Text = "Item Name";
            // 
            // txtMake
            // 
            this.txtMake.BackColor = System.Drawing.SystemColors.Window;
            this.txtMake.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtMake.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtMake.BorderRadius = 0;
            this.txtMake.BorderSize = 1;
            this.txtMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMake.Location = new System.Drawing.Point(149, 151);
            this.txtMake.Margin = new System.Windows.Forms.Padding(4);
            this.txtMake.Multiline = true;
            this.txtMake.Name = "txtMake";
            this.txtMake.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMake.PasswordChar = false;
            this.txtMake.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMake.PlaceholderText = "";
            this.txtMake.Size = new System.Drawing.Size(210, 35);
            this.txtMake.TabIndex = 38;
            this.txtMake.UnderlinedStyle = false;
            // 
            // txtParentCategory
            // 
            this.txtParentCategory.BackColor = System.Drawing.SystemColors.Window;
            this.txtParentCategory.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtParentCategory.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtParentCategory.BorderRadius = 0;
            this.txtParentCategory.BorderSize = 1;
            this.txtParentCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParentCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtParentCategory.Location = new System.Drawing.Point(581, 110);
            this.txtParentCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentCategory.Multiline = true;
            this.txtParentCategory.Name = "txtParentCategory";
            this.txtParentCategory.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtParentCategory.PasswordChar = false;
            this.txtParentCategory.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtParentCategory.PlaceholderText = "";
            this.txtParentCategory.Size = new System.Drawing.Size(210, 35);
            this.txtParentCategory.TabIndex = 37;
            this.txtParentCategory.UnderlinedStyle = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtItemCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtItemCode.BorderRadius = 0;
            this.txtItemCode.BorderSize = 1;
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtItemCode.Location = new System.Drawing.Point(149, 69);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemCode.Multiline = true;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtItemCode.PasswordChar = false;
            this.txtItemCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtItemCode.PlaceholderText = "";
            this.txtItemCode.Size = new System.Drawing.Size(210, 35);
            this.txtItemCode.TabIndex = 35;
            this.txtItemCode.UnderlinedStyle = false;
            // 
            // gbxAllItemDetails
            // 
            this.gbxAllItemDetails.Controls.Add(this.dgvItemMaster);
            this.gbxAllItemDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAllItemDetails.Location = new System.Drawing.Point(12, 253);
            this.gbxAllItemDetails.Name = "gbxAllItemDetails";
            this.gbxAllItemDetails.Size = new System.Drawing.Size(987, 239);
            this.gbxAllItemDetails.TabIndex = 1;
            this.gbxAllItemDetails.TabStop = false;
            this.gbxAllItemDetails.Text = "All Item Details";
            // 
            // dgvItemMaster
            // 
            this.dgvItemMaster.AllowUserToAddRows = false;
            this.dgvItemMaster.AllowUserToDeleteRows = false;
            this.dgvItemMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemMaster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvItemMaster.ColumnHeadersHeight = 35;
            this.dgvItemMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItemMaster.EnableHeadersVisualStyles = false;
            this.dgvItemMaster.Location = new System.Drawing.Point(16, 24);
            this.dgvItemMaster.Name = "dgvItemMaster";
            this.dgvItemMaster.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItemMaster.RowHeadersVisible = false;
            this.dgvItemMaster.RowHeadersWidth = 51;
            this.dgvItemMaster.RowTemplate.Height = 24;
            this.dgvItemMaster.Size = new System.Drawing.Size(963, 199);
            this.dgvItemMaster.TabIndex = 0;
            this.dgvItemMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemMaster_CellDoubleClick);
            // 
            // sparrowDropdownMenu1
            // 
            this.sparrowDropdownMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sparrowDropdownMenu1.IsMainMenu = false;
            this.sparrowDropdownMenu1.MenuItemHeight = 25;
            this.sparrowDropdownMenu1.MenuItemTextColor = System.Drawing.Color.Empty;
            this.sparrowDropdownMenu1.Name = "sparrowDropdownMenu1";
            this.sparrowDropdownMenu1.PrimaryColor = System.Drawing.Color.Empty;
            this.sparrowDropdownMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnCategoryUpload
            // 
            this.btnCategoryUpload.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCategoryUpload.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.btnCategoryUpload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCategoryUpload.BorderRadius = 14;
            this.btnCategoryUpload.BorderSize = 0;
            this.btnCategoryUpload.FlatAppearance.BorderSize = 0;
            this.btnCategoryUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCategoryUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCategoryUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoryUpload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCategoryUpload.Location = new System.Drawing.Point(538, 201);
            this.btnCategoryUpload.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCategoryUpload.Name = "btnCategoryUpload";
            this.btnCategoryUpload.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCategoryUpload.Size = new System.Drawing.Size(137, 30);
            this.btnCategoryUpload.TabIndex = 62;
            this.btnCategoryUpload.Text = "Cat Upload";
            this.btnCategoryUpload.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnCategoryUpload.UseVisualStyleBackColor = false;
            this.btnCategoryUpload.Visible = false;
            this.btnCategoryUpload.Click += new System.EventHandler(this.btnCategoryUpload_Click);
            // 
            // ItemMasterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 504);
            this.Controls.Add(this.gbxAllItemDetails);
            this.Controls.Add(this.gbxAddItemDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemMasterView";
            this.Text = "Item Master";
            this.Load += new System.EventHandler(this.ItemMasterView_Load);
            this.gbxAddItemDetails.ResumeLayout(false);
            this.gbxAddItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpnThreslimit)).EndInit();
            this.gbxAllItemDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddItemDetails;
        private System.Windows.Forms.GroupBox gbxAllItemDetails;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtMake;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtParentCategory;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtItemCode;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbSubCategory;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbUnit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblParentCategory;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblSubCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblModel;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUnit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblThreshold;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblMake;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblItemCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblItemName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnItemDelete;
        private SparrowRMSControl.SparrowControl.SparrowButton btnItemCancel;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnItemUpload;
        private SparrowRMSControl.SparrowControl.SparrowButton btnItemAddUnit;
        private SparrowRMSControl.SparrowControl.SparrowButton btnItemAddSubCat;
        private System.Windows.Forms.DataGridView dgvItemMaster;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtModel;
        private SparrowRMSControl.SparrowControl.SparrowDropdownMenu sparrowDropdownMenu1;
        private SparrowRMSControl.SparrowControl.SparrowNumericUpDown dpnThreslimit;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtItemName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnOpeningUpload;
        private SparrowRMSControl.SparrowControl.SparrowButton btnExportItem;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCategoryUpload;
    }
}