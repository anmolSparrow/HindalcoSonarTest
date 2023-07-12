namespace RMPCLApp.Machine_Edit_Form
{
    partial class Tentive_Price
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.ritchtxtnotes = new System.Windows.Forms.RichTextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtNewTechn = new System.Windows.Forms.TextBox();
            this.txtmake = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.ritchtxtnotes);
            this.groupBox1.Controls.Add(this.txtprice);
            this.groupBox1.Controls.Add(this.txtNewTechn);
            this.groupBox1.Controls.Add(this.txtmake);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(590, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tentive Price Update";
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(181, 327);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(126, 30);
            this.btnupdate.TabIndex = 8;
            this.btnupdate.Text = "Update Price";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // ritchtxtnotes
            // 
            this.ritchtxtnotes.Location = new System.Drawing.Point(181, 150);
            this.ritchtxtnotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ritchtxtnotes.MaxLength = 150;
            this.ritchtxtnotes.Name = "ritchtxtnotes";
            this.ritchtxtnotes.Size = new System.Drawing.Size(399, 134);
            this.ritchtxtnotes.TabIndex = 7;
            this.ritchtxtnotes.Text = "";
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(181, 113);
            this.txtprice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtprice.MaxLength = 25;
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(187, 24);
            this.txtprice.TabIndex = 6;
            this.txtprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprice_KeyPress);
            // 
            // txtNewTechn
            // 
            this.txtNewTechn.Location = new System.Drawing.Point(181, 78);
            this.txtNewTechn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewTechn.MaxLength = 15;
            this.txtNewTechn.Name = "txtNewTechn";
            this.txtNewTechn.Size = new System.Drawing.Size(187, 24);
            this.txtNewTechn.TabIndex = 5;
            this.txtNewTechn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmake_KeyPress);
            // 
            // txtmake
            // 
            this.txtmake.Location = new System.Drawing.Point(181, 45);
            this.txtmake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtmake.MaxLength = 15;
            this.txtmake.Name = "txtmake";
            this.txtmake.Size = new System.Drawing.Size(187, 24);
            this.txtmake.TabIndex = 4;
            this.txtmake.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmake_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Notes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Technology";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make";
            // 
            // Tentive_Price
            // 
            this.AcceptButton = this.btnupdate;
            this.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 374);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tentive_Price";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tentive_Price";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Tentive_Price_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.RichTextBox ritchtxtnotes;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.TextBox txtNewTechn;
        private System.Windows.Forms.TextBox txtmake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}