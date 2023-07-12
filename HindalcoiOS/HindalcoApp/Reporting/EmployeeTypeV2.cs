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
    public partial class EmployeeType : XtraForm
    {
        public EventHandler<string> NewEmpTypeHandler;
        public IncidentReport IncReport { get; set; }
        public ServiceDAL DalService { get; set; }
        public string EmpCode { get; set; }
        private string adminCode { get; set; }
        private int RoleId { get; set; }
        private bool isPageValidated { get; set; }
        private int TypeID { get; set; }

        ErrorProvider eps = null;
        public EmployeeType()
        {
            DalService = new ServiceDAL();
            eps = new ErrorProvider();
            TypeID = 0;
            InitializeComponent();

        }
        #region "Variable Declaration"
        DataTable empType = null;
        #endregion

        private void EmployeeType_Load(object sender, EventArgs e)
        {
            try
            {
                empType = new DataTable();
                empType = DalService.GetEmployeeTyp(4, "", 0);
                TypeID = Convert.ToInt32(empType.Rows[0][2]) + 1;

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmpType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmpType.Text))
                {
                    e.Cancel = true;
                    txtEmpType.Focus();
                    eps.SetError(txtEmpType, "Employee Type required");
                    isPageValidated = true;
                }
                else
                {
                    e.Cancel = false;
                    eps.SetError(txtEmpType, null);
                    isPageValidated = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployeeType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void EmployeeType_KeyDown(object sender, KeyEventArgs e)
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
                if (isPageValidated == false)
                {
                    int retVal = DalService.EmployeeType(2, txtEmpType.Text, TypeID);
                    if (retVal > 0)
                    {
                        if (NewEmpTypeHandler != null)
                            NewEmpTypeHandler.Invoke(sender, "");
                        XtraMessageBox.Show("Record saved successfully!.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable to add new Type!.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Employee Type Required!.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtEmpType.Text = "";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}





