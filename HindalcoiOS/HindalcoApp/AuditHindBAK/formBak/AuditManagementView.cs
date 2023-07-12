using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMPCLApp.AuditHind
{
    public partial class AuditManagementView : XtraForm
    {
        AuditManagement audMgmt = null;
        public AuditManagementView()
        {
            InitializeComponent();
            //audMgmt = new AuditManagement();
        }

        #region Controls Handler-------------------
        private void lblRtCauseObsAuditee_Click(object sender, EventArgs e)
        {

        }

        private void AuditManagementView_Load(object sender, EventArgs e)
        {
            GlobalDeclaration.HideTabCtrlPagesHeader(AuditMgmtPages);
        }

        private void btnDetailData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 0;
            //GetSelf data
        }

        private void btnAssignedData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 2;
            //GetAssigned data
        }

        private void btnClosedData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 3;
            //GetClosed data
        }

        private void dgvViewAuditData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                audMgmt = null;
                audMgmt = new AuditManagement();
                if (e.RowIndex < 0) return;

                audMgmt.DocNo = dgvViewAuditData.Rows[e.RowIndex].Cells["DocNo"].Value.ToString();
                audMgmt.DocDate =DateTime.Parse(dgvViewAuditData.Rows[e.RowIndex].Cells["DocDate"].Value.ToString());
                audMgmt.DocBy = dgvViewAuditData.Rows[e.RowIndex].Cells["DocBy"].Value.ToString();
                audMgmt.Auditor = dgvViewAuditData.Rows[e.RowIndex].Cells["Auditor"].Value.ToString();
                audMgmt.Auditee = dgvViewAuditData.Rows[e.RowIndex].Cells["Auditee"].Value.ToString();
                audMgmt.Dept = dgvViewAuditData.Rows[e.RowIndex].Cells["Dept"].Value.ToString();
                audMgmt.Area = dgvViewAuditData.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                audMgmt.AuditType = dgvViewAuditData.Rows[e.RowIndex].Cells["AuditType"].Value.ToString();
                audMgmt.CateofObs = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsCategory"].Value.ToString();
                audMgmt.NarrationObs = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsNarration"].Value.ToString();
                audMgmt.RootCauseObsAuditor = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsRootCauseAuditor"].Value.ToString();
                audMgmt.RootCauseObsAuditee = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsRootCauseAuditee"].Value.ToString();
                audMgmt.DeviaSafetyStd = dgvViewAuditData.Rows[e.RowIndex].Cells["safetyStdDeviation"].Value.ToString();
                audMgmt.Status = dgvViewAuditData.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                audMgmt.CorrAction = dgvViewAuditData.Rows[e.RowIndex].Cells["CorrectiveActions"].Value.ToString();
                audMgmt.OffResponsCorr= dgvViewAuditData.Rows[e.RowIndex].Cells["OffResponsCorr"].Value.ToString();
                audMgmt.PrevAction = dgvViewAuditData.Rows[e.RowIndex].Cells["RecurrPrevAction"].Value.ToString();
                audMgmt.OffResponsPrev = dgvViewAuditData.Rows[e.RowIndex].Cells["OffResponsPrev"].Value.ToString();

                MapObjectToControl(audMgmt);
                ////txtDocNo.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["DocNo"].Value.ToString();
                ////dtpDocDate.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["DocDate"].Value.ToString();
                ////txtDocBy.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["DocBy"].Value.ToString();
                ////txtAuditor.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["Auditor"].Value.ToString();
                ////txtAuditee.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["Auditee"].Value.ToString();
                ////txtDept.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["Dept"].Value.ToString();
                ////txtArea.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                ////txtAuditType.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["AuditType"].Value.ToString();
                ////txtObsCate.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsCategory"].Value.ToString();
                ////txtNarrObs.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsNarration"].Value.ToString();
                ////txtRtCauseObsAuditor.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsRootCauseAuditor"].Value.ToString();
                ////txtRtCauseObsAuditee.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["ObsRootCauseAuditee"].Value.ToString();
                ////txtSafetStdDev.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["safetyStdDeviation"].Value.ToString();
                ////txtStatus.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                ////txtCorrAction.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["CorrectiveActions"].Value.ToString();
                ////txtOffcResponsCorr.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["OffResponsCorr"].Value.ToString();
                ////txtPrevAction.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["RecurrPrevAction"].Value.ToString();
                ////txtOffcResponsPrev.Text = dgvViewAuditData.Rows[e.RowIndex].Cells["OffResponsPrev"].Value.ToString();

                //btnAdd.Text = "Update";
                //ViewDept();
                AuditMgmtPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsgnData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                audMgmt = null;
                audMgmt = new AuditManagement();
                if (e.RowIndex < 0) return;
                audMgmt.DocNo = dgvAsgnData.Rows[e.RowIndex].Cells["asgnDocNo"].Value.ToString();
                audMgmt.DocDate =DateTime.Parse(dgvAsgnData.Rows[e.RowIndex].Cells["asgnDocDate"].Value.ToString());
                audMgmt.DocBy = dgvAsgnData.Rows[e.RowIndex].Cells["asgnDocBy"].Value.ToString();
                audMgmt.Auditor = dgvAsgnData.Rows[e.RowIndex].Cells["asgnAuditor"].Value.ToString();
                audMgmt.Auditee = dgvAsgnData.Rows[e.RowIndex].Cells["asgnAuditee"].Value.ToString();
                audMgmt.Dept = dgvAsgnData.Rows[e.RowIndex].Cells["asgnDept"].Value.ToString();
                audMgmt.Area = dgvAsgnData.Rows[e.RowIndex].Cells["asgnArea"].Value.ToString();
                audMgmt.AuditType = dgvAsgnData.Rows[e.RowIndex].Cells["asgnAuditType"].Value.ToString();
                audMgmt.CateofObs = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsCategory"].Value.ToString();
                audMgmt.NarrationObs = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsNarration"].Value.ToString();
                audMgmt.RootCauseObsAuditor = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsRootCauseAuditor"].Value.ToString();
                audMgmt.RootCauseObsAuditee = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsRootCauseAuditee"].Value.ToString();
                audMgmt.DeviaSafetyStd = dgvAsgnData.Rows[e.RowIndex].Cells["asgnsafetyStdDeviation"].Value.ToString();
                audMgmt.Status = dgvAsgnData.Rows[e.RowIndex].Cells["asgnStatus"].Value.ToString();
                audMgmt.CorrAction = dgvAsgnData.Rows[e.RowIndex].Cells["asgnCorrectiveActions"].Value.ToString();
                audMgmt.OffResponsCorr = dgvAsgnData.Rows[e.RowIndex].Cells["asgnOffResponsCorr"].Value.ToString();
                audMgmt.PrevAction = dgvAsgnData.Rows[e.RowIndex].Cells["asgnRecurrPrevAction"].Value.ToString();
                audMgmt.OffResponsPrev = dgvAsgnData.Rows[e.RowIndex].Cells["asgnOffResponsPrev"].Value.ToString();
                MapObjectToControl(audMgmt);
              
                //ViewDept();
                AuditMgmtPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClosData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                audMgmt = null;
                audMgmt = new AuditManagement();
                if (e.RowIndex < 0) return;
                audMgmt.DocNo = dgvAsgnData.Rows[e.RowIndex].Cells["closDocNo"].Value.ToString();
                audMgmt.DocDate =DateTime.Parse(dgvAsgnData.Rows[e.RowIndex].Cells["closDocDate"].Value.ToString());
                audMgmt.DocBy = dgvAsgnData.Rows[e.RowIndex].Cells["closDocBy"].Value.ToString();
                audMgmt.Auditor = dgvAsgnData.Rows[e.RowIndex].Cells["closAuditor"].Value.ToString();
                audMgmt.Auditee = dgvAsgnData.Rows[e.RowIndex].Cells["closAuditee"].Value.ToString();
                audMgmt.Dept = dgvAsgnData.Rows[e.RowIndex].Cells["closDept"].Value.ToString();
                audMgmt.Area = dgvAsgnData.Rows[e.RowIndex].Cells["closArea"].Value.ToString();
                audMgmt.AuditType = dgvAsgnData.Rows[e.RowIndex].Cells["closAuditType"].Value.ToString();
                audMgmt.CateofObs = dgvAsgnData.Rows[e.RowIndex].Cells["closObsCategory"].Value.ToString();
                audMgmt.NarrationObs = dgvAsgnData.Rows[e.RowIndex].Cells["closObsNarration"].Value.ToString();
                audMgmt.RootCauseObsAuditor = dgvAsgnData.Rows[e.RowIndex].Cells["closObsRootCauseAuditor"].Value.ToString();
                audMgmt.RootCauseObsAuditee = dgvAsgnData.Rows[e.RowIndex].Cells["closObsRootCauseAuditee"].Value.ToString();
                audMgmt.DeviaSafetyStd = dgvAsgnData.Rows[e.RowIndex].Cells["clossafetyStdDeviation"].Value.ToString();
                audMgmt.Status = dgvAsgnData.Rows[e.RowIndex].Cells["closStatus"].Value.ToString();
                audMgmt.CorrAction = dgvAsgnData.Rows[e.RowIndex].Cells["closCorrectiveActions"].Value.ToString();
                audMgmt.OffResponsCorr = dgvAsgnData.Rows[e.RowIndex].Cells["closOffResponsCorr"].Value.ToString();
                audMgmt.PrevAction = dgvAsgnData.Rows[e.RowIndex].Cells["closRecurrPrevAction"].Value.ToString();
                audMgmt.OffResponsPrev= dgvAsgnData.Rows[e.RowIndex].Cells["closOffResponsPrev"].Value.ToString();

                MapControlToObject(audMgmt);
                //ViewDept();
                AuditMgmtPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsgnBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnViewBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnClosBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult drr = MessageBox.Show("Are you Sure ?", "Alert", MessageBoxButtons.YesNo);
            if (drr == DialogResult.Yes)
            {
                if (txtStatus.Text == "Open")
                {
                    txtStatus.Text = "Submitted";
                }
                if (txtStatus.Text == "Submitted")
                {
                    txtStatus.Text = "Assigned";
                }
                if (txtStatus.Text == "CapaClosed")
                {
                    txtStatus.Text = "Closed";
                }
            }
            //Update data to database
        }

        private void btnUaucPcBox_Click(object sender, EventArgs e)
        {
            string impath = browseImageFile();
            //if (string.IsNullOrEmpty(impath)) return;
            //UAUC.SnapImage = System.IO.File.ReadAllBytes(impath);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
          DialogResult drr=  MessageBox.Show("Are you Sure ?", "Alert", MessageBoxButtons.YesNo);
            if (drr == DialogResult.Yes)
            {
                if (txtStatus.Text == "CapaClosed")
                {
                    txtStatus.Text = "Reopened";
                }
            }
        }

        private void btnReOpen_Click(object sender, EventArgs e)
        {
            DialogResult drr = MessageBox.Show("Are you Sure ?", "Alert", MessageBoxButtons.YesNo);
            if (drr == DialogResult.Yes)
            {
                if (txtStatus.Text == "Submitted")
                {
                    txtStatus.Text = "Rejected";
                }
            }
        }
        #endregion

        #region Methods-----------------
        public string browseImageFile()
        {
            string imgPath = string.Empty;
            try
            {
                OpenFileDialog opFileDialog = new OpenFileDialog();
                {
                    opFileDialog.InitialDirectory = @"C:\";
                    opFileDialog.Title = "Browse";
                    opFileDialog.CheckFileExists = true;
                    opFileDialog.CheckPathExists = true;
                    //DefaultExt = "txt",
                    opFileDialog.Filter = "Images(*.Jpeg;*.png;*.jpg;)|*.Jpeg;*.png;*.jpg;";
                    //FilterIndex = 2,
                    //RestoreDirectory = true,
                    opFileDialog.ReadOnlyChecked = false;
                    // ShowReadOnly = true
                }

                if (opFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //if (is_Redirected == true)
                    {
                        PictureBox imageControl = new PictureBox();
                        PcbxAuditMgmt.Image = new Bitmap(opFileDialog.FileName);
                        imgPath = opFileDialog.FileName;
                        PcbxAuditMgmt.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    //else
                    //{
                    //    PcbxUauc.Image = new Bitmap(opFileDialog.FileName);
                    //    imgPath = openFileDialog1.FileName;
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return imgPath;
        }

        public void MapObjectToControl(AuditManagement admgmt)
        {
            txtDocNo.Text = admgmt.DocNo;
            dtpDocDate.Value = admgmt.DocDate;
            txtDocBy.Text = admgmt.DocBy;
            txtAuditor.Text = admgmt.Auditor;
            txtAuditee.Text = admgmt.Auditee;
            txtDept.Text = admgmt.Dept;
            txtArea.Text = admgmt.Area;
            txtAuditType.Text = admgmt.AuditType;
            txtObsCate.Text = admgmt.CateofObs;
            txtNarrObs.Text = admgmt.NarrationObs;
            txtRtCauseObsAuditor.Text = admgmt.RootCauseObsAuditee;
            txtRtCauseObsAuditee.Text = admgmt.RootCauseObsAuditee;
            txtSafetStdDev.Text = admgmt.DeviaSafetyStd;
            txtStatus.Text = admgmt.Status;
            txtCorrAction.Text = admgmt.CorrAction;
            txtOffcResponsCorr.Text = admgmt.OffResponsCorr;
            txtPrevAction.Text = admgmt.PrevAction;
            txtOffcResponsPrev.Text = audMgmt.OffResponsPrev;
        }

        public void MapControlToObject(AuditManagement admgmt)
        {
            admgmt.DocNo= txtDocNo.Text;
            admgmt.DocDate = dtpDocDate.Value;
            admgmt.DocBy = txtDocBy.Text;
            admgmt.Auditor = txtAuditor.Text;
            admgmt.Auditee = txtAuditee.Text;
            admgmt.Dept = txtDept.Text;
            admgmt.Area = txtArea.Text;
            admgmt.AuditType = txtAuditType.Text;
            admgmt.CateofObs = txtObsCate.Text;
            admgmt.NarrationObs = txtNarrObs.Text;
            admgmt.RootCauseObsAuditee = txtRtCauseObsAuditor.Text;
            admgmt.RootCauseObsAuditee = txtRtCauseObsAuditee.Text;
            admgmt.DeviaSafetyStd = txtSafetStdDev.Text;
            admgmt.Status = txtStatus.Text;
            admgmt.CorrAction = txtCorrAction.Text;
            admgmt.OffResponsCorr = txtOffcResponsCorr.Text;
            admgmt.PrevAction = txtPrevAction.Text;
            admgmt.OffResponsPrev = txtOffcResponsPrev.Text;
        }

        
        public void DefaultSet()
        {

        }
        #endregion
    }
    public enum AuditStatus
    {
      Prepare=0,
      Open=1,
      Submitted=2,
      Closed,
      Assigned,
      CapaClosed,
      ReAssigned
    }

    public class AuditManagement
    {
        public string DocNo { set; get; }
        public string AuditPlanID { set; get; }
        public DateTime DocDate { set; get; }
        public string AuditType { set; get; }
        public string Month { set; get; }
        public string Year { set; get; }
        public string Quarter { set; get; }
        public string Dept { set; get; }
        public string DocBy { set; get; }
        public string Area { set; get; }
        public string Auditor { set; get; }
        public string Auditee { set; get; }
        public string CAPAUser { set; get; }
        public string CateofObs { set; get; }
        public string NarrationObs { set; get; }
        public string RootCauseObsAuditor { set; get; }
        public string RootCauseObsAuditee { set; get; }
        public string CorrAction { set; get; }
        public string PrevAction { set; get; }
        public string OffResponsPrev { set; get; }
        public string OffResponsCorr { set; get; }
        public DateTime DateofCompl { set; get; }
        public string  DeviaSafetyStd { set; get; }
        public byte[] Photo { set; get; }
        public string Status { set; get; }
    }
}
