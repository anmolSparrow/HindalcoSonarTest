
namespace HindalcoiOS.InventoryMgmt
{
    partial class ConsumpItemDetailView
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
            this.dpnConsumQty = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.lblConsumTotCost = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumRate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumedQty = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumAvailQty = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumpCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumpSubCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsumedUnit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblBatchNo = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblConsunedItem = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnComsumItemDetailAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnConsumpDetailDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtConsumTotCost = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtConsumeUnitCost = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtConsumAvailQty = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtConsumpSubCat = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtConsumpCat = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbConsumedbatch = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.txtConsumedUnit = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbConsumedItem = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.gbxConsumpItemDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpnConsumQty)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxConsumpItemDetail
            // 
            this.gbxConsumpItemDetail.Controls.Add(this.dpnConsumQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumTotCost);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumRate);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumedQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumAvailQty);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumpCat);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumpSubCat);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsumedUnit);
            this.gbxConsumpItemDetail.Controls.Add(this.lblBatchNo);
            this.gbxConsumpItemDetail.Controls.Add(this.lblConsunedItem);
            this.gbxConsumpItemDetail.Controls.Add(this.btnComsumItemDetailAdd);
            this.gbxConsumpItemDetail.Controls.Add(this.btnConsumpDetailDelete);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumTotCost);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumeUnitCost);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumAvailQty);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumpSubCat);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumpCat);
            this.gbxConsumpItemDetail.Controls.Add(this.cmbConsumedbatch);
            this.gbxConsumpItemDetail.Controls.Add(this.txtConsumedUnit);
            this.gbxConsumpItemDetail.Controls.Add(this.cmbConsumedItem);
            this.gbxConsumpItemDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConsumpItemDetail.Location = new System.Drawing.Point(9, 12);
            this.gbxConsumpItemDetail.Name = "gbxConsumpItemDetail";
            this.gbxConsumpItemDetail.Size = new System.Drawing.Size(822, 261);
            this.gbxConsumpItemDetail.TabIndex = 0;
            this.gbxConsumpItemDetail.TabStop = false;
            this.gbxConsumpItemDetail.Text = "Add Item";
            // 
            // dpnConsumQty
            // 
            this.dpnConsumQty.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dpnConsumQty.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpnConsumQty.Location = new System.Drawing.Point(593, 75);
            this.dpnConsumQty.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.dpnConsumQty.Name = "dpnConsumQty";
            this.dpnConsumQty.Size = new System.Drawing.Size(210, 31);
            this.dpnConsumQty.TabIndex = 38;
            this.dpnConsumQty.ValueChanged += new System.EventHandler(this.ConsumpItemDetailView_MouseHover);
            this.dpnConsumQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumQty_KeyPress);
            // 
            // lblConsumTotCost
            // 
            this.lblConsumTotCost.AutoSize = true;
            this.lblConsumTotCost.Depth = 0;
            this.lblConsumTotCost.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumTotCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumTotCost.Location = new System.Drawing.Point(474, 180);
            this.lblConsumTotCost.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumTotCost.Name = "lblConsumTotCost";
            this.lblConsumTotCost.Size = new System.Drawing.Size(75, 18);
            this.lblConsumTotCost.TabIndex = 37;
            this.lblConsumTotCost.Text = "Total Cost";
            // 
            // lblConsumRate
            // 
            this.lblConsumRate.AutoSize = true;
            this.lblConsumRate.Depth = 0;
            this.lblConsumRate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumRate.Location = new System.Drawing.Point(474, 132);
            this.lblConsumRate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumRate.Name = "lblConsumRate";
            this.lblConsumRate.Size = new System.Drawing.Size(67, 18);
            this.lblConsumRate.TabIndex = 36;
            this.lblConsumRate.Text = "Unit Cost";
            // 
            // lblConsumedQty
            // 
            this.lblConsumedQty.AutoSize = true;
            this.lblConsumedQty.Depth = 0;
            this.lblConsumedQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumedQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumedQty.Location = new System.Drawing.Point(474, 80);
            this.lblConsumedQty.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumedQty.Name = "lblConsumedQty";
            this.lblConsumedQty.Size = new System.Drawing.Size(106, 18);
            this.lblConsumedQty.TabIndex = 35;
            this.lblConsumedQty.Text = "Consumed Qty";
            // 
            // lblConsumAvailQty
            // 
            this.lblConsumAvailQty.AutoSize = true;
            this.lblConsumAvailQty.Depth = 0;
            this.lblConsumAvailQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumAvailQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumAvailQty.Location = new System.Drawing.Point(474, 29);
            this.lblConsumAvailQty.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumAvailQty.Name = "lblConsumAvailQty";
            this.lblConsumAvailQty.Size = new System.Drawing.Size(92, 18);
            this.lblConsumAvailQty.TabIndex = 34;
            this.lblConsumAvailQty.Text = "Available Qty";
            // 
            // lblConsumpCat
            // 
            this.lblConsumpCat.AutoSize = true;
            this.lblConsumpCat.Depth = 0;
            this.lblConsumpCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumpCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumpCat.Location = new System.Drawing.Point(17, 218);
            this.lblConsumpCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumpCat.Name = "lblConsumpCat";
            this.lblConsumpCat.Size = new System.Drawing.Size(67, 18);
            this.lblConsumpCat.TabIndex = 33;
            this.lblConsumpCat.Text = "Category";
            // 
            // lblConsumpSubCat
            // 
            this.lblConsumpSubCat.AutoSize = true;
            this.lblConsumpSubCat.Depth = 0;
            this.lblConsumpSubCat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumpSubCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumpSubCat.Location = new System.Drawing.Point(17, 173);
            this.lblConsumpSubCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumpSubCat.Name = "lblConsumpSubCat";
            this.lblConsumpSubCat.Size = new System.Drawing.Size(96, 18);
            this.lblConsumpSubCat.TabIndex = 32;
            this.lblConsumpSubCat.Text = "Sub Category";
            // 
            // lblConsumedUnit
            // 
            this.lblConsumedUnit.AutoSize = true;
            this.lblConsumedUnit.Depth = 0;
            this.lblConsumedUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConsumedUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsumedUnit.Location = new System.Drawing.Point(17, 121);
            this.lblConsumedUnit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsumedUnit.Name = "lblConsumedUnit";
            this.lblConsumedUnit.Size = new System.Drawing.Size(33, 18);
            this.lblConsumedUnit.TabIndex = 31;
            this.lblConsumedUnit.Text = "Unit";
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Depth = 0;
            this.lblBatchNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBatchNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBatchNo.Location = new System.Drawing.Point(17, 72);
            this.lblBatchNo.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(68, 18);
            this.lblBatchNo.TabIndex = 30;
            this.lblBatchNo.Text = "Batch No";
            // 
            // lblConsunedItem
            // 
            this.lblConsunedItem.AutoSize = true;
            this.lblConsunedItem.Depth = 0;
            this.lblConsunedItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsunedItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsunedItem.Location = new System.Drawing.Point(17, 29);
            this.lblConsunedItem.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblConsunedItem.Name = "lblConsunedItem";
            this.lblConsunedItem.Size = new System.Drawing.Size(40, 18);
            this.lblConsunedItem.TabIndex = 29;
            this.lblConsunedItem.Text = "Item";
            // 
            // btnComsumItemDetailAdd
            // 
            this.btnComsumItemDetailAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnComsumItemDetailAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnComsumItemDetailAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnComsumItemDetailAdd.BorderRadius = 14;
            this.btnComsumItemDetailAdd.BorderSize = 0;
            this.btnComsumItemDetailAdd.FlatAppearance.BorderSize = 0;
            this.btnComsumItemDetailAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnComsumItemDetailAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnComsumItemDetailAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComsumItemDetailAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComsumItemDetailAdd.ForeColor = System.Drawing.Color.White;
            this.btnComsumItemDetailAdd.Location = new System.Drawing.Point(691, 220);
            this.btnComsumItemDetailAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnComsumItemDetailAdd.Name = "btnComsumItemDetailAdd";
            this.btnComsumItemDetailAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnComsumItemDetailAdd.Size = new System.Drawing.Size(112, 30);
            this.btnComsumItemDetailAdd.TabIndex = 28;
            this.btnComsumItemDetailAdd.Text = "Add Item";
            this.btnComsumItemDetailAdd.TextColor = System.Drawing.Color.White;
            this.btnComsumItemDetailAdd.UseVisualStyleBackColor = false;
            this.btnComsumItemDetailAdd.Click += new System.EventHandler(this.btnComsumItemDetailAdd_Click);
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
            this.btnConsumpDetailDelete.Location = new System.Drawing.Point(589, 221);
            this.btnConsumpDetailDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnConsumpDetailDelete.Name = "btnConsumpDetailDelete";
            this.btnConsumpDetailDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnConsumpDetailDelete.Size = new System.Drawing.Size(87, 30);
            this.btnConsumpDetailDelete.TabIndex = 27;
            this.btnConsumpDetailDelete.Text = "Delete";
            this.btnConsumpDetailDelete.TextColor = System.Drawing.Color.White;
            this.btnConsumpDetailDelete.UseVisualStyleBackColor = false;
            this.btnConsumpDetailDelete.Click += new System.EventHandler(this.btnConsumpDetailDelete_Click);
            // 
            // txtConsumTotCost
            // 
            this.txtConsumTotCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumTotCost.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumTotCost.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumTotCost.BorderRadius = 0;
            this.txtConsumTotCost.BorderSize = 1;
            this.txtConsumTotCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumTotCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumTotCost.Location = new System.Drawing.Point(593, 176);
            this.txtConsumTotCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumTotCost.Multiline = true;
            this.txtConsumTotCost.Name = "txtConsumTotCost";
            this.txtConsumTotCost.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumTotCost.PasswordChar = false;
            this.txtConsumTotCost.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumTotCost.PlaceholderText = "";
            this.txtConsumTotCost.Size = new System.Drawing.Size(210, 35);
            this.txtConsumTotCost.TabIndex = 26;
            this.txtConsumTotCost.UnderlinedStyle = false;
            // 
            // txtConsumeUnitCost
            // 
            this.txtConsumeUnitCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumeUnitCost.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumeUnitCost.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumeUnitCost.BorderRadius = 0;
            this.txtConsumeUnitCost.BorderSize = 1;
            this.txtConsumeUnitCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumeUnitCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumeUnitCost.Location = new System.Drawing.Point(592, 124);
            this.txtConsumeUnitCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumeUnitCost.Multiline = true;
            this.txtConsumeUnitCost.Name = "txtConsumeUnitCost";
            this.txtConsumeUnitCost.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumeUnitCost.PasswordChar = false;
            this.txtConsumeUnitCost.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumeUnitCost.PlaceholderText = "";
            this.txtConsumeUnitCost.Size = new System.Drawing.Size(210, 35);
            this.txtConsumeUnitCost.TabIndex = 25;
            this.txtConsumeUnitCost.UnderlinedStyle = false;
            // 
            // txtConsumAvailQty
            // 
            this.txtConsumAvailQty.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumAvailQty.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumAvailQty.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumAvailQty.BorderRadius = 0;
            this.txtConsumAvailQty.BorderSize = 1;
            this.txtConsumAvailQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumAvailQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumAvailQty.Location = new System.Drawing.Point(593, 17);
            this.txtConsumAvailQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumAvailQty.Multiline = true;
            this.txtConsumAvailQty.Name = "txtConsumAvailQty";
            this.txtConsumAvailQty.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumAvailQty.PasswordChar = false;
            this.txtConsumAvailQty.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumAvailQty.PlaceholderText = "";
            this.txtConsumAvailQty.Size = new System.Drawing.Size(210, 35);
            this.txtConsumAvailQty.TabIndex = 23;
            this.txtConsumAvailQty.UnderlinedStyle = false;
            // 
            // txtConsumpSubCat
            // 
            this.txtConsumpSubCat.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumpSubCat.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumpSubCat.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumpSubCat.BorderRadius = 0;
            this.txtConsumpSubCat.BorderSize = 1;
            this.txtConsumpSubCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumpSubCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumpSubCat.Location = new System.Drawing.Point(121, 167);
            this.txtConsumpSubCat.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumpSubCat.Multiline = true;
            this.txtConsumpSubCat.Name = "txtConsumpSubCat";
            this.txtConsumpSubCat.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumpSubCat.PasswordChar = false;
            this.txtConsumpSubCat.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumpSubCat.PlaceholderText = "";
            this.txtConsumpSubCat.Size = new System.Drawing.Size(210, 35);
            this.txtConsumpSubCat.TabIndex = 22;
            this.txtConsumpSubCat.UnderlinedStyle = false;
            // 
            // txtConsumpCat
            // 
            this.txtConsumpCat.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumpCat.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumpCat.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumpCat.BorderRadius = 0;
            this.txtConsumpCat.BorderSize = 1;
            this.txtConsumpCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumpCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumpCat.Location = new System.Drawing.Point(121, 213);
            this.txtConsumpCat.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumpCat.Multiline = true;
            this.txtConsumpCat.Name = "txtConsumpCat";
            this.txtConsumpCat.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumpCat.PasswordChar = false;
            this.txtConsumpCat.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumpCat.PlaceholderText = "";
            this.txtConsumpCat.Size = new System.Drawing.Size(210, 35);
            this.txtConsumpCat.TabIndex = 21;
            this.txtConsumpCat.UnderlinedStyle = false;
            // 
            // cmbConsumedbatch
            // 
            this.cmbConsumedbatch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbConsumedbatch.BorderSize = 1;
            this.cmbConsumedbatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsumedbatch.ForeColor = System.Drawing.Color.DimGray;
            this.cmbConsumedbatch.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbConsumedbatch.IntegralHeight = false;
            this.cmbConsumedbatch.ItemHeight = 22;
            this.cmbConsumedbatch.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbConsumedbatch.ListTextColor = System.Drawing.Color.White;
            this.cmbConsumedbatch.Location = new System.Drawing.Point(121, 66);
            this.cmbConsumedbatch.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbConsumedbatch.Name = "cmbConsumedbatch";
            this.cmbConsumedbatch.Size = new System.Drawing.Size(210, 30);
            this.cmbConsumedbatch.Sorted = true;
            this.cmbConsumedbatch.TabIndex = 17;
            this.cmbConsumedbatch.SelectedIndexChanged += new System.EventHandler(this.cmbConsumedbatch_SelectedIndexChanged);
            // 
            // txtConsumedUnit
            // 
            this.txtConsumedUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsumedUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConsumedUnit.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConsumedUnit.BorderRadius = 0;
            this.txtConsumedUnit.BorderSize = 1;
            this.txtConsumedUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumedUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsumedUnit.Location = new System.Drawing.Point(121, 116);
            this.txtConsumedUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsumedUnit.Multiline = true;
            this.txtConsumedUnit.Name = "txtConsumedUnit";
            this.txtConsumedUnit.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConsumedUnit.PasswordChar = false;
            this.txtConsumedUnit.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConsumedUnit.PlaceholderText = "";
            this.txtConsumedUnit.Size = new System.Drawing.Size(210, 35);
            this.txtConsumedUnit.TabIndex = 18;
            this.txtConsumedUnit.UnderlinedStyle = false;
            // 
            // cmbConsumedItem
            // 
            this.cmbConsumedItem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbConsumedItem.BorderSize = 1;
            this.cmbConsumedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsumedItem.ForeColor = System.Drawing.Color.DimGray;
            this.cmbConsumedItem.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbConsumedItem.IntegralHeight = false;
            this.cmbConsumedItem.ItemHeight = 22;
            this.cmbConsumedItem.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbConsumedItem.ListTextColor = System.Drawing.Color.White;
            this.cmbConsumedItem.Location = new System.Drawing.Point(121, 17);
            this.cmbConsumedItem.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbConsumedItem.Name = "cmbConsumedItem";
            this.cmbConsumedItem.Size = new System.Drawing.Size(210, 30);
            this.cmbConsumedItem.TabIndex = 17;
            this.cmbConsumedItem.SelectedIndexChanged += new System.EventHandler(this.cmbConsumedItem_SelectedIndexChanged);
            this.cmbConsumedItem.Leave += new System.EventHandler(this.cmbConsumedItem_Leave);
            // 
            // ConsumpItemDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 290);
            this.Controls.Add(this.gbxConsumpItemDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsumpItemDetailView";
            this.Text = "Consumed Item Detail";
            this.Load += new System.EventHandler(this.ConsumpItemDetailView_Load);
            this.MouseHover += new System.EventHandler(this.ConsumpItemDetailView_MouseHover);
            this.gbxConsumpItemDetail.ResumeLayout(false);
            this.gbxConsumpItemDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpnConsumQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConsumpItemDetail;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumedUnit;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbConsumedItem;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumTotCost;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumeUnitCost;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumAvailQty;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumpSubCat;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConsumpCat;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbConsumedbatch;
        private SparrowRMSControl.SparrowControl.SparrowButton btnComsumItemDetailAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnConsumpDetailDelete;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumTotCost;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumRate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumedQty;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumAvailQty;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumpCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumpSubCat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsumedUnit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblBatchNo;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblConsunedItem;
        private SparrowRMSControl.SparrowControl.SparrowNumericUpDown dpnConsumQty;
    }
}