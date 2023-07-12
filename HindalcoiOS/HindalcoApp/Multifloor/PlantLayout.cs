using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Multifloor
{
    public partial class PlantLayout : Form
    {
        public decimal NumberOfPlant { get; set; }       
        public decimal prevValue = 0;
        public int labellocationdiff = 43;
        public int textlocation = 46;
        private Label lbl;
        public TextBox txt;
        public List<string> _FormName = new List<string>();  
        public EventHandler<string> _FormClosed;
        public PlantLayout()
        {
            InitializeComponent();
        }
        private void PlantLayout_Load(object sender, EventArgs e)
        {                 
            if (this.Controls.OfType<TextBox>().Count() > 0)
            {                
                for (int i = 0; i < this.Controls.OfType<TextBox>().Count(); i++)
                {
                    var ctrl = this.Controls.OfType<TextBox>().ToList();
                    if (!string.IsNullOrEmpty(ctrl[i].Text))
                    {
                        ctrl[i].Enabled = false;                       
                    }
                }
                numericUpDown1.Value = prevValue;
            }            
        }
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                var ctrl = this.Controls.OfType<TextBox>().ToList();
                for (int i = 0; i < this.Controls.OfType<TextBox>().Count(); i++)
                {
                    if (!string.IsNullOrEmpty(ctrl[i].Text))
                    {
                        if (!_FormName.Contains(ctrl[i].Text))
                        {                           
                            _FormName.Add(ctrl[i].Text);
                        }                        
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
        }        

        private void numvoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (!System.Text.RegularExpressions.Regex.IsMatch(text.Text, "^[a-zA-Z ]"))
            {                
                if (text.Text.Length > 0)
                {
                    text.Text.Remove(text.Text.Length - 1);
                }
            }
        }
        int count = 1;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                string ctrlname = string.Empty;
                if (numericUpDown1.Value < prevValue)
                {

                    Control ctrl = this.Controls.OfType<Label>().Where(X => X.Name == "dynamiclbl" + (this.Controls.OfType<Label>().Count() - 1)).FirstOrDefault();
                    if (ctrl == null) return;
                    labellocationdiff = labellocationdiff - (lblfloor.Location.Y + 4);
                    if (!string.IsNullOrEmpty(ctrl.Text))
                        this.Controls.Remove(ctrl);

                    Control ctrltxt = this.Controls.OfType<TextBox>().ToList()[this.Controls.OfType<TextBox>().Count() - 1];
                    textlocation = textlocation - (numericUpDown1.Location.Y + 4);
                    ctrlname = ctrltxt.Text;
                    this.Controls.Remove(ctrltxt);
                    if (numericUpDown1.Value == 0)
                    {
                        btncreate.Visible = false;
                    }
                    if (!string.IsNullOrEmpty(ctrlname))
                        _FormClosed.Invoke(sender, ctrlname);
                }
                else if (numericUpDown1.Value > prevValue)
                {
                    try
                    {
                        AdddynamicCTRL("NumKey", int.Parse(numericUpDown1.Value.ToString()));
                    }
                    catch (Exception Ex)
                    {
                        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                NumberOfPlant = prevValue = numericUpDown1.Value;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AdddynamicCTRL(string accesscaller = "", int floorcount = 0)//string accesscaller = "", int floorcount = 0
        {
            try
            {
                // dynamic Label Creation
                lbl = new Label();
                this.Controls.Add(lbl);
                //this.SuspendLayout();
                lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.Location = new System.Drawing.Point(7, lblfloor.Location.Y + labellocationdiff);

                lbl.Name = "dynamiclbl" + floorcount;
                lbl.Tag = floorcount;
                lbl.Size = new System.Drawing.Size(101, 20);
                lbl.Text = "Floor Number-" + floorcount;

                labellocationdiff = lbl.Location.Y + 4;
                //_ctrllist.Add(lbl);
                // Dynamic TextBox Creation

                txt = new TextBox();
                this.Controls.Add(txt);
                txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
                txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txt.Location = new System.Drawing.Point(129, numericUpDown1.Location.Y + textlocation);

                txt.MaxLength = 15;
                txt.TextChanged += textBox1_TextChanged;
                txt.Name = "dynamictxt" + floorcount;
                txt.Tag = floorcount;
                txt.Size = new System.Drawing.Size(158, 22);
                textlocation = txt.Location.Y + 4;              
                //Dynamic Button Creation              
                btncreate.Visible = true;
                //if (accesscaller == "ReloadDocking")
                //{
                //    NumberOfPlant = prevValue = numericUpDown1.Value = floorcount;
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }            

        private void PlantLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var ctrl = this.Controls.OfType<TextBox>().ToList();
                var ctrllbl = this.Controls.OfType<Label>().Where(X => X.Tag != null).ToList();
                for (int i = 0; i < ctrl.Count(); i++)
                {
                    if (string.IsNullOrEmpty(ctrl[i].Text))
                    {                        
                        this.Controls.Remove(ctrl[i]);
                        this.Controls.Remove(ctrllbl[i]);
                        labellocationdiff = labellocationdiff - (lblfloor.Location.Y + 4);
                        textlocation = textlocation - (numericUpDown1.Location.Y + 4);
                    }
                }
                prevValue = numericUpDown1.Value = decimal.Parse(this.Controls.OfType<TextBox>().Count().ToString());
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if(DialogResult==DialogResult.OK)
            //{
            //    //DialogResult = DialogResult.Cancel;
            //}
        }

       
    }
}
