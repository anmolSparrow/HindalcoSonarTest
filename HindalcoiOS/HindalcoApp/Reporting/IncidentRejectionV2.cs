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

namespace HindalcoiOS.Reporting
{
    public partial class IncidentRejection : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> IncidentRejectioneHandler;
        public IncidentRejection()
        {
            InitializeComponent();
        }

        private void IncidentRejection_Load(object sender, EventArgs e)
        {
            try
            {
                lblRejectedCode.Text = GlobalDeclaration.IncidentCode;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int j = Resources.Instance.UpdateIncidentReport_RMPCL(GlobalDeclaration.PermitType, "Rejected", DateTime.Now, txtRejectionReason.Text);
                if (j > 0)
                {
                    XtraMessageBox.Show("Record Rejected successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Task.Delay(8000);
                    this.Close();

                    if (IncidentRejectioneHandler != null)
                        //GlobalDeclaration.dayList =txtRemarks.Text;
                        IncidentRejectioneHandler.Invoke(sender, txtRejectionReason.Text);
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
    }

}