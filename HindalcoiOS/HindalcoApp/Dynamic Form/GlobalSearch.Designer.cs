
namespace HindalcoiOS.Dynamic_Form
{
    partial class GlobalSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Globaltree = new System.Windows.Forms.TreeView();
            this.opcIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.nodeViewTable = new System.Windows.Forms.DataGridView();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblname = new System.Windows.Forms.Label();
            this.btnselectNode = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nodeViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Search Fields:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // Globaltree
            // 
            this.Globaltree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Globaltree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Globaltree.HotTracking = true;
            this.Globaltree.ImageIndex = 0;
            this.Globaltree.ImageList = this.opcIconImageList;
            this.Globaltree.Location = new System.Drawing.Point(39, 128);
            this.Globaltree.Name = "Globaltree";
            this.Globaltree.SelectedImageIndex = 0;
            this.Globaltree.Size = new System.Drawing.Size(338, 463);
            this.Globaltree.TabIndex = 2;
            this.Globaltree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Globaltree_AfterSelect);
            // 
            // opcIconImageList
            // 
            this.opcIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("opcIconImageList.ImageStream")));
            this.opcIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.opcIconImageList.Images.SetKeyName(0, "unspecifiedIcon.png");
            this.opcIconImageList.Images.SetKeyName(1, "objectIcon.png");
            this.opcIconImageList.Images.SetKeyName(2, "variableIcon.png");
            this.opcIconImageList.Images.SetKeyName(3, "methodIcon.png");
            this.opcIconImageList.Images.SetKeyName(4, "objectTypeIcon.png");
            this.opcIconImageList.Images.SetKeyName(5, "variableType.png");
            this.opcIconImageList.Images.SetKeyName(6, "referenceTypeIcon.jpg");
            this.opcIconImageList.Images.SetKeyName(7, "dataTypeIcon.png");
            this.opcIconImageList.Images.SetKeyName(8, "viewIcon.png");
            this.opcIconImageList.Images.SetKeyName(9, "folderIcon.jpg");
            this.opcIconImageList.Images.SetKeyName(10, "propertyIcon.png");
            this.opcIconImageList.Images.SetKeyName(11, "serverIcon.png");
            // 
            // nodeViewTable
            // 
            this.nodeViewTable.AllowUserToAddRows = false;
            this.nodeViewTable.AllowUserToDeleteRows = false;
            this.nodeViewTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.nodeViewTable.ColumnHeadersHeight = 30;
            this.nodeViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.nodeViewTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Attribute,
            this.Value});
            this.nodeViewTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.nodeViewTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.nodeViewTable.Location = new System.Drawing.Point(408, 54);
            this.nodeViewTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nodeViewTable.MultiSelect = false;
            this.nodeViewTable.Name = "nodeViewTable";
            this.nodeViewTable.ReadOnly = true;
            this.nodeViewTable.RowHeadersWidth = 15;
            this.nodeViewTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeViewTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.nodeViewTable.RowTemplate.Height = 30;
            this.nodeViewTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nodeViewTable.Size = new System.Drawing.Size(639, 537);
            this.nodeViewTable.TabIndex = 3;
            // 
            // Attribute
            // 
            this.Attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Attribute.Frozen = true;
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.MinimumWidth = 6;
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            this.Attribute.Width = 250;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblname.Location = new System.Drawing.Point(649, 19);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(0, 28);
            this.lblname.TabIndex = 4;
            // 
            // btnselectNode
            // 
            this.btnselectNode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnselectNode.Location = new System.Drawing.Point(891, 598);
            this.btnselectNode.Name = "btnselectNode";
            this.btnselectNode.Size = new System.Drawing.Size(156, 34);
            this.btnselectNode.TabIndex = 5;
            this.btnselectNode.Text = "&Select Node";
            this.btnselectNode.UseVisualStyleBackColor = true;
            this.btnselectNode.Visible = false;
            this.btnselectNode.Click += new System.EventHandler(this.btnselectNode_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 28;
            this.listBox1.Location = new System.Drawing.Point(39, 62);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(353, 60);
            this.listBox1.TabIndex = 9;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // GlobalSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 646);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnselectNode);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.nodeViewTable);
            this.Controls.Add(this.Globaltree);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GlobalSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GlobalSearch";
            this.Load += new System.EventHandler(this.GlobalSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nodeViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView Globaltree;
        private System.Windows.Forms.ImageList opcIconImageList;
        private System.Windows.Forms.DataGridView nodeViewTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnselectNode;
        private System.Windows.Forms.ListBox listBox1;
    }
}