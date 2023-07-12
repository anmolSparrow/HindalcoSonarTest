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

namespace HindalcoiOS.Safety_Form_list
{
    public partial class SafetyDontsFrm : XtraForm
    {
        public SafetyDontsFrm()
        {
            this.Text = "Safety Do's & Don'ts";
            UpdateTextPosition();
            InitializeComponent();
        }

        private void SafetyDontsFrm_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            cmblist.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmblist.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }
            return list;
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;

                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                this.Text = tmp + this.Text.Trim();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Value = txtAdd.Text;
            cmblist.Items.Add(Value);
        }

        private void cmboperartion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Value = cmboperartion.SelectedText;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Need To Discuss About this Form Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }
}
