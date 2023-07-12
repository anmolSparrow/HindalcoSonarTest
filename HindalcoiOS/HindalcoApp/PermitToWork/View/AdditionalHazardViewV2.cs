using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HindalcoiOS.PermitToWork
{
    public partial class AdditionalHazardView : DevExpress.XtraEditors.XtraForm
    {
        public event SomeEvents GetValue;
        public AdditionalHazard additionalHazard { get; set; }
        public AdditionalHazardView(string permitCode, bool IsNew)
        {
            additionalHazard = new AdditionalHazard();
            additionalHazard.PermitCode = permitCode;
            InitializeComponent();
            btnAddHazDelete.Visible = false;
            btnAddHazSave.Text = "Save";
            if (IsNew == false)
            {
                btnAddHazDelete.Visible = true;
                btnAddHazSave.Text = "Update";
            }
        }

        public void MapAdditionalHazard()
        {
            try
            {
                additionalHazard.Hazard = txtAddHazard.Text;
                additionalHazard.Remarks = txtAddHazRemarks.Text;
                additionalHazard.CreatedDate = DateTime.Today;
                additionalHazard.SetAdditionalHazard(additionalHazard);
                XtraMessageBox.Show("Record added successfully");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddHazSave_Click(object sender, EventArgs e)
        {
            MapAdditionalHazard();

        }
        public void MapAddHazardToView(AdditionalHazard addHaz)
        {
            txtAddHazard.Text = addHaz.Hazard;
            txtAddHazRemarks.Text = addHaz.Remarks;
            additionalHazard.AddHazId = addHaz.AddHazId;
        }

        private void btnAddHazDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
                if (dgres == DialogResult.Yes)
                {
                    additionalHazard.DeleteAdditionalHazard(additionalHazard);
                    XtraMessageBox.Show("Record Deleted Successfully.");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
