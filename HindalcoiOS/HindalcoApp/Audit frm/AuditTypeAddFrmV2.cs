using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Audit_frm
{
    public partial class AuditTypeAddFrm : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> updateAuditTypeHandler;
        public AuditTypeAddFrm()
        {
            this.Text = "Add More Audit Type";
            InitializeComponent();
        }

        public string CallType = string.Empty;
        private void AuditTypeAddFrm_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
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
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void txtAddAudit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Recultstring = string.Empty;
            if (CallType == "Maintenance")
            {
                if (!string.IsNullOrEmpty(txtAddAudit.Text))
                    Resources.Instance.InsertMasterKeycom("Sp_InsertMaintenanceInputInfoMaster", this.txtAddAudit.Text, "@inputname", "@string", out Recultstring);
                if (DialogResult.OK == XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information))
                {
                    DialogResult = DialogResult.OK;
                    updateAuditTypeHandler.Invoke(sender, txtAddAudit.Text);
                }
                if (Recultstring == "Same Key Already Exist")
                {
                    XtraMessageBox.Show("Please Enter Another Type.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddAudit.Focus();
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtAddAudit.Text))
                    Resources.Instance.InsertMasterKeycom("Sp_InsertMasterKeyTypeAudit", this.txtAddAudit.Text, "@keycmplist", "@returnvalue", out Recultstring);
                if (DialogResult.OK == XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information))
                {
                    DialogResult = DialogResult.OK;
                    updateAuditTypeHandler.Invoke(sender, txtAddAudit.Text);
                    //txtAddAudit.Text = "";
                    //this.Close();
                }
                if (Recultstring == "Same Key Already Exist")
                {
                    XtraMessageBox.Show("Please Enter Another Type.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddAudit.Focus();
                    return;
                }
                //else
                //{
                //    DialogResult = DialogResult.OK;
                //    updateAuditTypeHandler.Invoke(sender, txtAddAudit.Text);
                //    txtAddAudit.Text = "";
                //    this.Close();

                //}
            }


        }
        public void CallPlace()
        {
            if (CallType == "Maintenance")
            {
                lblaudit.Text = "Enter Input Type";
                btnAdd.Text = "Add Input Type";
            }
        }

      
    }
}
