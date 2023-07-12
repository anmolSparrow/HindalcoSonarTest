using DevExpress.XtraEditors;
//using HindalcoiOS.Class_Operation;
//using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SparrowRMS;
using HindalcoiOS.Class_Operation;
using System.IO;
using HindalcoiOS.Models;
using HindalcoiOS.DAL;

namespace HindalcoiOS.Reporting
{
    public partial class IncidentClosure : XtraForm
    {
        public EventHandler<string> NewEmpTypeHandler;
        public IncidentReport IncReport { get; set; }
        public ServiceDAL DalService { get; set; }
        private bool is_PageValidated { get; set; }

        public IncidentClosure()
        {
            DalService = new ServiceDAL();

            InitializeComponent();

        }
        #region "Variable Declaration"
        DataTable empType = null;
        #endregion


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int j = Resources.Instance.UpdateIncidentReport_RMPCL(GlobalDeclaration.PermitType, "Closed", DateTime.Now, txtRemarks.Text);
                if (j > 0)
                {
                    XtraMessageBox.Show("Record updated successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Task.Delay(8000);
                    this.Close();

                    if (NewEmpTypeHandler != null)
                        //GlobalDeclaration.dayList =txtRemarks.Text;
                        NewEmpTypeHandler.Invoke(sender, txtRemarks.Text);
                }
                else
                {
                    XtraMessageBox.Show("Oops something went wrong", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployeeType_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtRemarks.Text = "";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}





