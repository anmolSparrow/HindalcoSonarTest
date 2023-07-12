
namespace HindalcoiOS.U1FormCollection
{
    partial class InventoryAddDetails
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
            this.gbxInventory = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbUnits = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.txtQty = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbItems = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblAddUom = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblAddQty = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblAddItem = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.gbxInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxInventory
            // 
            this.gbxInventory.Controls.Add(this.btnUpdate);
            this.gbxInventory.Controls.Add(this.cmbUnits);
            this.gbxInventory.Controls.Add(this.txtQty);
            this.gbxInventory.Controls.Add(this.cmbItems);
            this.gbxInventory.Controls.Add(this.lblAddUom);
            this.gbxInventory.Controls.Add(this.lblAddQty);
            this.gbxInventory.Controls.Add(this.lblAddItem);
            this.gbxInventory.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInventory.Location = new System.Drawing.Point(13, 6);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(427, 213);
            this.gbxInventory.TabIndex = 0;
            this.gbxInventory.TabStop = false;
            this.gbxInventory.Text = "Inventory Details";
            this.gbxInventory.Enter += new System.EventHandler(this.gbxInventory_Enter);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderRadius = 14;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(258, 163);
            this.btnUpdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUpdate.Size = new System.Drawing.Size(124, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbUnits
            // 
            this.cmbUnits.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbUnits.BorderSize = 1;
            this.cmbUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbUnits.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbUnits.ListTextColor = System.Drawing.Color.White;
            this.cmbUnits.Location = new System.Drawing.Point(174, 119);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(220, 30);
            this.cmbUnits.TabIndex = 5;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.SystemColors.Window;
            this.txtQty.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtQty.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtQty.BorderRadius = 0;
            this.txtQty.BorderSize = 1;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQty.Location = new System.Drawing.Point(174, 72);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Multiline = true;
            this.txtQty.Name = "txtQty";
            this.txtQty.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtQty.PasswordChar = false;
            this.txtQty.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtQty.PlaceholderText = "";
            this.txtQty.Size = new System.Drawing.Size(220, 33);
            this.txtQty.TabIndex = 4;
            this.txtQty.UnderlinedStyle = false;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqty_KeyPress);
            // 
            // cmbItems
            // 
            this.cmbItems.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbItems.BorderSize = 1;
            this.cmbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbItems.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbItems.ListTextColor = System.Drawing.Color.White;
            this.cmbItems.Location = new System.Drawing.Point(174, 28);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(220, 30);
            this.cmbItems.TabIndex = 3;
            // 
            // lblAddUom
            // 
            this.lblAddUom.AutoSize = true;
            this.lblAddUom.Depth = 0;
            this.lblAddUom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUom.Location = new System.Drawing.Point(6, 128);
            this.lblAddUom.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAddUom.Name = "lblAddUom";
            this.lblAddUom.Size = new System.Drawing.Size(41, 18);
            this.lblAddUom.TabIndex = 2;
            this.lblAddUom.Text = "UOM";
            // 
            // lblAddQty
            // 
            this.lblAddQty.AutoSize = true;
            this.lblAddQty.Depth = 0;
            this.lblAddQty.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddQty.Location = new System.Drawing.Point(7, 82);
            this.lblAddQty.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAddQty.Name = "lblAddQty";
            this.lblAddQty.Size = new System.Drawing.Size(124, 18);
            this.lblAddQty.TabIndex = 1;
            this.lblAddQty.Text = "Quantity Required";
            // 
            // lblAddItem
            // 
            this.lblAddItem.AutoSize = true;
            this.lblAddItem.Depth = 0;
            this.lblAddItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddItem.Location = new System.Drawing.Point(7, 37);
            this.lblAddItem.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAddItem.Name = "lblAddItem";
            this.lblAddItem.Size = new System.Drawing.Size(70, 18);
            this.lblAddItem.TabIndex = 0;
            this.lblAddItem.Text = "Add Item";
            // 
            // InventoryAddDetails
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 233);
            this.Controls.Add(this.gbxInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryAddDetails";
            this.Text = "Add inventory";
            this.Load += new System.EventHandler(this.InventoryAddDetails_Load);
            this.gbxInventory.ResumeLayout(false);
            this.gbxInventory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxInventory;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbUnits;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtQty;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbItems;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAddUom;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAddQty;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAddItem;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUpdate;
    }
}