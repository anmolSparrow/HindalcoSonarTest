
using CADImport;
using ClosedXML.Excel;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.UAUCs
{
    public partial class UAUCView : XtraForm
    {
        public UAUC UAUC { set; get; }
        public string CurrentUser { get; set; }
        public int CurrentUserRole { get; set; }
        public UAUCView()
        {
            InitializeComponent();
            UAUC = new UAUC();
            //var dttt = UAUC.GetAllUsers();
            UAUC.GetAllUsers();
            UAUC.CurrentUserCode = UAUC.GetAllUsers().AsEnumerable().Where(X => X.Field<string>("UserName") == GlobalDeclaration._holdInfo[0].UserName).ToList().FirstOrDefault()["EmpCode"].ToString();
            UAUC.CurrentUserRole = Properties.Settings.Default.RoleID.ToString();// UAUC.GetAllUsers().AsEnumerable().Where(X => X.Field<string>("UserName") == GlobalDeclaration._holdInfo[0].UserName).ToList().FirstOrDefault()["RoleID"].ToString();
            ////btnUAUCApproval.Text = "Assigned Task";
            //if (UAUC.CurrentUserRole == "7" || UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "5")
            //{
            //    btnUAUCApproval.Text = "Reported Events";
            //}
            CurrentUser = GlobalDeclaration._holdInfo[0].UserName;
            //CurrentUserRole = Properties.Settings.Default.RoleID;
        }

        //private void btnUaucAddNew_Click(object sender, EventArgs e)
        //{
        //    UaucPages.SelectedIndex = 1;
        //    RefreshForNewUAUC();
        //    HideActionControls();
        //}

        private void btnUAUCBack_Click(object sender, EventArgs e)
        {
            UaucPages.SelectedIndex = currtabIndex;
            //UaucPages.SelectedIndex = 0;
            ViewUAUSelfCData();
            ViewUAUAssignedCData(UAUC.CurrentUserCode);
            ShowControls();
            lblAddNewHdr.Text = "Create New";
        }
        private void btnUaucPcBox_Click(object sender, EventArgs e)
        {
            string impath = browseImageFile();
            if (string.IsNullOrEmpty(impath)) return;
            UAUC.SnapImage = System.IO.File.ReadAllBytes(impath);
            ////PcbxUauc.Image = GetImage(UAUC.SnapImage);
            ////PcbxUauc.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //private void RefreshForNewUAUCOld()
        //{
        //    txtUaucObsNo.Clear();
        //    txtUaucObsNo.Text = GenerateGlobalDocID("SP_GetUAUCObsID", "OBS");
        //    dtpUaucObsDate.Value = DateTime.Today;
        //    cmbUaucOunit.Items.Clear();
        //    cmbUaucOunit.Text = "";
        //    txtUaucDocBy.Clear();
        //    txtUaucDocBy.Text = GlobalDeclaration._holdInfo[0].UserName;
        //    //txtUaucMachineTag.Clear();

        //    txtUaucObsBy.Clear();
        //    cmbUaucPlantArea.Items.Clear();
        //    cmbUaucPlantArea.Text = "";
        //    txtUaucObsrvation.Clear();
        //    txtUaucSpecificArea.Clear();
        //    cmbUaucAssignedTo.Items.Clear();
        //    cmbUaucAssignedTo.Text = "";
        //    //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
        //    //cmbUaucUnSafAct.Items.Clear();
        //    //cmbUaucUnSafAct.Text = "";
        //    txtUaucRecommd.Clear();
        //    txtUaucRemarks.Clear();
        //    txtUaucStatus.Clear();
        //    txtUaucStatus.Text = UAUCStatus.Prepare.ToString();

        //    LoadOperationUnits();
        //    LoadAssignedTo();
        //    LoadArea();
        //    LoadMachineTag();
        //}

        private void RefreshForNewUAUC()
        {
            txtUaucObsNo.Text = string.Empty;//.Clear();
            txtUaucObsNo.Text = GenerateGlobalDocID("SP_GetUAUCObsID", "OBS");
            dtpUaucObsDate.Value = DateTime.Today;
            cmbUaucOunit.Items.Clear();
            cmbUaucOunit.Text = "";
            txtUaucDocBy.Text = string.Empty;//;
            txtUaucDocBy.Text = GlobalDeclaration._holdInfo[0].UserName;
            //txtUaucMachineTag.Clear();
            cmbUAUCMachineTag.Items.Clear();
            txtUaucObsBy.Text = string.Empty;//;
            cmbUaucPlantArea.Items.Clear();
            cmbUaucPlantArea.Text = "";
            txtUaucObsrvation.Text = string.Empty;//;
            txtUaucSpecificArea.Text = string.Empty;//;
            cmbUaucAssignedTo.Items.Clear();
            cmbUaucAssignedTo.Text = "";
            PcbxUauc.Image = null;
            lblAddNewHdr.Text = "Create New";
            //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
            //cmbUaucUnSafAct.Items.Clear();
            //cmbUaucUnSafAct.Text = "";
            txtUaucRecommd.Text = string.Empty;
            txtUaucRemarks.Text = string.Empty;//
            txtUaucStatus.Text = string.Empty;//
            txtUaucStatus.Text = UAUCStatus.Prepare.ToString();
            txtUaucObsNo.Enabled = false;
            txtUaucDocBy.Enabled = false;
            txtUaucStatus.Enabled = false;

            LoadOperationUnits();
            LoadAssignedTo();
            LoadArea();
            LoadMachineTag();
        }

        private string GenerateGlobalDocID(string procedureId, string preText)
        {
            string procureId = string.Empty;
            int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);
            //string preText = preText;// "PUR";
            Resources.Instance.GetMaxID(procedureId, "@MaxID", ref randomDigit);
            if (randomDigit == 0)
            {
                randomDigit = 1;
            }
            else
                randomDigit += 1;
            //if (!CallingLocation)
            procureId = Convert.ToString(preText + '-' + 00 + randomDigit);
            return procureId;
        }
        private void MapUAUCToData(UAUCStatus status)
        {
            try
            {
                DataTable dt = UAUC.GetAllArea();
                UAUC.ObservationNo = txtUaucObsNo.Text;
                UAUC.ObservationDate = dtpUaucObsDate.Value;
                UAUC.Hours = cmbFromHours.Text;
                UAUC.Minuts = cmbFromMinuts.Text;
                UAUC.ObservedBy = txtUaucObsBy.Text;
                UAUC.ObservedByCode = txtUaucObsBy.Text;
                UAUC.OperationUnit = cmbUaucOunit.Text;
                UAUC.OperationUnitCode = UAUC.GetAllOperationUnits().AsEnumerable().Where(X => X.Field<string>("OperationUnitName") == UAUC.OperationUnit).ToList().FirstOrDefault()["OperationUnitCode"].ToString();
                UAUC.PlantArea = cmbUaucPlantArea.Text;
                if (UAUC.GetAllArea().AsEnumerable().Where(X => X.Field<string>("NameOfArea") == UAUC.PlantArea).ToList().Count > 0)
                    UAUC.PlantAreaCode = UAUC.GetAllArea().AsEnumerable().Where(X => X.Field<string>("NameOfArea") == UAUC.PlantArea).ToList().FirstOrDefault()["AreaCode"].ToString();
                UAUC.Recommendation = txtUaucRecommd.Text;
                if (status == UAUCStatus.Open || status == UAUCStatus.Rejected)
                {
                    UAUC.SafetyUser = CurrentUser;
                    if (!string.IsNullOrEmpty(UAUC.SafetyUser))
                        UAUC.SafetyUserCode = UAUC.LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == UAUC.SafetyUser).ToList().FirstOrDefault()["EmpCode"].ToString();
                }
                else
                {
                    UAUC.SafetyUser = txtSafetyUsr.Text;
                    if (!string.IsNullOrEmpty(UAUC.SafetyUser))
                        UAUC.SafetyUserCode = UAUC.LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == UAUC.SafetyUser).ToList().FirstOrDefault()["EmpCode"].ToString();
                }
                if (!String.IsNullOrWhiteSpace(txtInputRemark.Text))
                {
                    string msg = string.Format("Documented by {0} on {1} Comments:{2}", CurrentUser, DateTime.Now.ToString(), txtInputRemark.Text);
                    txtUaucRemarks.Text = txtUaucRemarks.Text + Environment.NewLine + msg;
                    //txtUaucRemarks.Text = txtUaucRemarks.Text + Environment.NewLine + DateTime.Now.ToString()+ txtInputRemark.Text;
                    if (string.IsNullOrWhiteSpace(txtUaucRemarks.Text)) txtUaucRemarks.Text = "N/A"; //on 07/12/22
                    UAUC.Remarks = txtUaucRemarks.Text;
                }
                if (status == UAUCStatus.Prepare || status == UAUCStatus.Rejected)
                {
                    UAUC.AssigenedTo = "N/A";
                    UAUC.AssigenedToCode = "N/A";
                    UAUC.AssigenedDate = DateTime.Today;
                }

                else
                {
                    UAUC.AssigenedTo = cmbUaucAssignedTo.Text;
                    UAUC.AssigenedDate = dtpUAUCAsgnDate.Value;
                }

                if (!string.IsNullOrEmpty(UAUC.AssigenedTo) && UAUC.AssigenedTo != "N/A")
                    UAUC.AssigenedToCode = UAUC.GetAllUsers().AsEnumerable().Where(X => X.Field<string>("UserName") == UAUC.AssigenedTo).ToList().FirstOrDefault()["EmpCode"].ToString();
                else
                {
                    UAUC.AssigenedTo = "N/A";
                    UAUC.AssigenedToCode = "N/A";
                    UAUC.AssigenedDate = DateTime.Today;
                }

                UAUC.DocumentedBy = txtUaucDocBy.Text;
                UAUC.DocumentedCode = UAUC.LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == UAUC.DocumentedBy).ToList().FirstOrDefault()["EmpCode"].ToString();
                UAUC.Observation = txtUaucObsrvation.Text;
                if (!string.IsNullOrWhiteSpace(cmbUAUCMachineTag.Text))
                {
                    UAUC.MachineTag = cmbUAUCMachineTag.Text;
                }
                else
                {
                    UAUC.MachineTag = "N/A";
                }
               
                //UAUC.MachineTag = txtUaucMachineTag.Text;
                UAUC.SpecificArea = txtUaucSpecificArea.Text;
                UAUC.Status = (int)status; //(int)(UAUCStatus)Enum.Parse(typeof(UAUCStatus), status);// (int)UAUCStatus.Prepare;
                //else if (status == UAUCStatus.ForApproval.ToString())
                //    UAUC.Status = (int)(UAUCStatus)Enum.Parse(typeof(UAUCStatus), status);
                UAUC.UnsafeCondition = (int)(UnsafeCondition)Enum.Parse(typeof(UnsafeCondition), cmbUaucUnSafAct.Text);//cmbUaucUnSafAct.Text);
                if (PcbxUauc.Image != null)
                    UAUC.SnapImage = GetByteFromImage(PcbxUauc.Image);
                UAUC.SetUAUCToData(UAUC);
                txtUaucStatus.Text = status.ToString();
                txtSafetyUsr.Text = CurrentUser;
                XtraMessageBox.Show("Data Saved Successfully");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOperationUnits()
        {
            if (cmbUaucOunit.Items.Count > 0)
                cmbUaucOunit.Items.Clear();
            DataTable dt = UAUC.GetAllOperationUnits();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbUaucOunit.Items.Add(dt.Rows[i]["OperationUnitName"]);
            }

        }
        private void LoadAssignedTo()
        {
            if (cmbUaucAssignedTo.Items.Count > 0)
                cmbUaucAssignedTo.Items.Clear();
            DataTable dt = UAUC.GetAllUsers();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbUaucAssignedTo.Items.Add(dt.Rows[i]["UserName"]);
            }
        }
        private void LoadArea()
        {
            if (cmbUaucPlantArea.Items.Count > 0)
                cmbUaucPlantArea.Items.Clear();
            DataTable dt = UAUC.GetAllArea();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbUaucPlantArea.Items.Add(dt.Rows[i]["NameOfArea"]);
            }
        }
        private void HideActionControls()
        {
            btnUAUCSubmit.Visible = true;
            btnUAUCSave.Visible = true;
            btnUaucPcBox.Visible = false;
            btnUAUCSubmit.Text = "Submit";
            cmbUaucAssignedTo.Visible = true;
            cmbUaucAssignedTo.Enabled = true;
            lblUaucAssignedTo.Visible = true;
            dtpUAUCAsgnDate.Visible = true;
            lblUAUCAsgnDate.Visible = true;
            txtInputRemark.Enabled = true;
            txtUaucRemarks.Enabled = false;
            if (txtUaucStatus.Text == UAUCStatus.Prepare.ToString())
            {
                EnableInputControls();
                txtUaucDocBy.Text = GlobalDeclaration._holdInfo[0].UserName;
                txtUaucStatus.Text = UAUCStatus.Prepare.ToString();
                cmbUaucAssignedTo.Visible = false;
                lblUaucAssignedTo.Visible = false;
                dtpUAUCAsgnDate.Visible = false;
                lblUAUCAsgnDate.Visible = false;
                btnUAUCReject.Visible = false;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = true;
                txtUaucObsNo.Enabled = false;
                txtUaucDocBy.Enabled = false;
                txtUaucStatus.Enabled = false;

            }
            if (txtUaucStatus.Text == UAUCStatus.Reported.ToString())
            {
                btnUAUCSave.Visible = false;
                btnUAUCReject.Visible = true;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = false;
                btnUAUCSubmit.Text = "Approve";

                DisableInputControls();
                txtUaucRemarks.Enabled = true;
                cmbUaucAssignedTo.Visible = true;
                cmbUaucAssignedTo.Enabled = true;
                dtpUAUCAsgnDate.Visible = true;
                dtpUAUCAsgnDate.Enabled = true;
                lblUAUCAsgnDate.Visible = true;
                txtUaucRemarks.Enabled = false;

                if (GlobalDeclaration._holdInfo[0].UserName == txtUaucDocBy.Text)
                {
                    btnUAUCSubmit.Visible = false;
                    btnUAUCReject.Visible = false;
                    cmbUaucAssignedTo.Visible = false;
                    lblUaucAssignedTo.Visible = false;
                    dtpUAUCAsgnDate.Visible = false;
                    lblUAUCAsgnDate.Visible = false;
                }
                if ((UAUC.CurrentUserRole != "1" || UAUC.CurrentUserRole != "7" || UAUC.CurrentUserRole != "7") && (GlobalDeclaration._holdInfo[0].UserName != txtUaucDocBy.Text))
                {
                    UAUC.AssigenedDate = DateTime.Today;
                    if (string.IsNullOrWhiteSpace(cmbUaucAssignedTo.Text))
                    {
                        XtraMessageBox.Show("Please select AssignedTo");
                        return;
                    }
                }

            }
            if (txtUaucStatus.Text == UAUCStatus.ReOpen.ToString())
            {
                btnUAUCSave.Visible = false;
                btnUAUCReject.Visible = false;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = false;
                btnUAUCSubmit.Visible = false;
                btnUaucPcBox.Visible = true;
                //if (UAUC.CurrentUserRole != "1" && UAUC.CurrentUserRole != "7")
                //{
                //    btnUAUCSubmit.Visible = false;
                //    btnUAUCSubmit.Text = "Close";
                //}
                if (GlobalDeclaration._holdInfo[0].UserName == cmbUaucAssignedTo.Text)
                {
                    btnUAUCSubmit.Visible = true;
                    btnUAUCSubmit.Text = "Close";
                }
                DisableInputControls();
                ////txtUaucRemarks.Enabled = true;

            }
            if (txtUaucStatus.Text == UAUCStatus.Open.ToString())
            {
                btnUAUCSave.Visible = false;
                btnUAUCReject.Visible = false;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = false;
                btnUAUCSubmit.Visible = false;
                btnUAUCSubmit.Text = "Close";
                if (UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "7")
                {
                    btnUAUCSubmit.Visible = false;
                    btnUAUCSubmit.Text = "Close";
                }
                if (GlobalDeclaration._holdInfo[0].UserName == cmbUaucAssignedTo.Text)
                {
                    btnUAUCSubmit.Visible = true;
                    btnUAUCSubmit.Text = "Close";
                }

                DisableInputControls();
                ////txtUaucRemarks.Enabled = false;
            }

            if (txtUaucStatus.Text == UAUCStatus.DeptClosed.ToString())
            {
                btnUAUCSave.Visible = false;
                btnUAUCReject.Visible = false;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = false;
                btnUAUCSubmit.Visible = false;
                if (UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "5" || UAUC.CurrentUserRole == "7")
                {
                    btnUAUCSubmit.Visible = true;
                    btnUAUCReOpen.Visible = true;
                    btnUAUCSubmit.Text = "Close";
                }
                DisableInputControls();
                ////txtUaucRemarks.Enabled = false;
            }
            if (txtUaucStatus.Text == UAUCStatus.Rejected.ToString())
            {
                btnUAUCSave.Visible = false;
                btnUAUCReject.Visible = false;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = false;
                btnUAUCSubmit.Visible = false;
                DisableInputControls();
                ////txtUaucRemarks.Enabled = true;
            }
            if (txtUaucStatus.Text == UAUCStatus.Closed.ToString())
            {
                btnUAUCSave.Visible = false;
                btnUAUCReject.Visible = false;
                btnUAUCReOpen.Visible = false;
                btnUAUCDelete.Visible = false;
                btnUaucPcBox.Visible = false;
                btnUAUCSubmit.Visible = false;
                DisableInputControls();
                ////txtUaucRemarks.Enabled = false;
            }
        }
        private void EnableInputControls()
        {
            txtUaucObsNo.Enabled = true;
            dtpUaucObsDate.Enabled = true;
            cmbUaucOunit.Enabled = true;
            txtUaucDocBy.Enabled = true;
            cmbUAUCMachineTag.Enabled = true;
            //txtUaucMachineTag.Enabled = true;
            txtUaucObsBy.Enabled = true;
            cmbUaucPlantArea.Enabled = true;
            txtUaucObsrvation.Enabled = true;
            txtUaucSpecificArea.Enabled = true;
            cmbUaucAssignedTo.Enabled = true;
            //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
            cmbUaucUnSafAct.Enabled = true; //((UnsafeCondition)(int.Parse(dgvUAUCdata.Rows[e.RowIndex].Cells["UnsafeCondition"].Value.ToString()))).ToString();
            txtUaucRecommd.Enabled = true;
            ////txtUaucRemarks.Enabled = true;
            txtUaucStatus.Enabled = true;
        }
        private void DisableInputControls()
        {
            txtUaucObsNo.Enabled = false;
            dtpUaucObsDate.Enabled = false;
            cmbUaucOunit.Enabled = false;
            txtUaucDocBy.Enabled = false;
            //txtUaucMachineTag.Enabled = false;
            cmbUAUCMachineTag.Enabled = false;
            txtUaucObsBy.Enabled = false;
            cmbUaucPlantArea.Enabled = false;
            txtUaucObsrvation.Enabled = false;
            txtUaucSpecificArea.Enabled = false;
            cmbUaucAssignedTo.Enabled = false;
            dtpUAUCAsgnDate.Enabled = false;
            //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
            cmbUaucUnSafAct.Enabled = false; //((UnsafeCondition)(int.Parse(dgvUAUCdata.Rows[e.RowIndex].Cells["UnsafeCondition"].Value.ToString()))).ToString();
            txtUaucRecommd.Enabled = false;
            ////txtUaucRemarks.Enabled = false;
            txtUaucStatus.Enabled = false;
        }
        private void ShowControls()
        {
            if (txtUaucStatus.Text == UAUCStatus.Prepare.ToString())
            {
                btnUAUCReject.Visible = true;
                btnUAUCDelete.Visible = true;
                btnUAUCReOpen.Visible = false;

            }
        }
        private void UAUCView_Load(object sender, EventArgs e)
        {
            HideUAUCPagesHeader();
            DisableControlPermanent();
            ////btnUAUCClosed.Visible = false;
            if (UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "5" || UAUC.CurrentUserRole == "7")
            {
                ////btnUAUCClosed.Visible = true;
            }
            ViewUAUSelfCData();
            LoadMachineTag();
            //ViewAllUAUCdata();
            //cmbUaucUnSafAct.DataSource = Enum.GetNames(typeof(UnsafeCondition));
        }

        private void dgvUAUCdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtUaucObsNo.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["ObservationNo"].Value.ToString();
                dtpUaucObsDate.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["ObservationDate"].Value.ToString();
                cmbUaucOunit.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["OperationUnit"].Value.ToString();
                txtUaucDocBy.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["DocumentedBy"].Value.ToString();
                cmbUAUCMachineTag.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString();
                //txtUaucMachineTag.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString();
                txtUaucObsBy.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["ObservedBy"].Value.ToString();
                cmbUaucPlantArea.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["PlantArea"].Value.ToString();
                txtUaucObsrvation.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["Observation"].Value.ToString();
                txtUaucSpecificArea.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["SpecificArea"].Value.ToString();
                cmbUaucAssignedTo.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedTo"].Value.ToString();
                dtpUAUCAsgnDate.Value = DateTime.Parse(dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString());
                //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
                cmbUaucUnSafAct.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["UnsafeCondition"].Value.ToString(); //((UnsafeCondition)(int.Parse(dgvUAUCdata.Rows[e.RowIndex].Cells["UnsafeCondition"].Value.ToString()))).ToString();
                txtUaucRecommd.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["Recommendation"].Value.ToString();
                txtUaucRemarks.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                txtUaucStatus.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                cmbFromHours.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["ViewHours"].Value.ToString();
                cmbFromMinuts.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["ViewMinuts"].Value.ToString();
                txtSafetyUsr.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["SafetyUser"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(dgvUAUCdata.Rows[e.RowIndex].Cells["SnapImage"].Value.ToString()))
                {
                    PcbxUauc.Image = GetImage((byte[])(dgvUAUCdata.Rows[e.RowIndex].Cells["SnapImage"].Value));
                    PcbxUauc.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                UaucPages.SelectedIndex = 1;
                cmbUaucAssignedTo.Enabled = false;
                HideActionControls();
                LoadAssignedTo();
                LoadMachineTag();
                lblAddNewHdr.Text = "View Detail";
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ViewAllUAUCdata()
        //{
        //    dgvUAUCdata.DataSource = UAUC.GetAllUAUC();
        //}
        private void ViewUAUSelfCData()
        {
            try
            {
                DataTable dt = null;
                ////dt = UAUC.GetAllUAUC();
                dt = UAUC.GetUAUCByUser(UAUC.CurrentUserCode);

                var v = dt.AsEnumerable().Where(X => X.Field<string>("DocumentedByCode") == UAUC.CurrentUserCode).ToList();
                if (v.Count > 0)
                {
                    dt = dt.AsEnumerable().Where(X => X.Field<string>("DocumentedByCode") == UAUC.CurrentUserCode).CopyToDataTable();
                }
               

                if (dt == null) return;

                if (dgvUAUCdata.Rows.Count > 0)
                    dgvUAUCdata.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvUAUCdata.Rows.Add(dr);
                        int index = dgvUAUCdata.Rows.Count - 1;
                        dgvUAUCdata.Rows[index].Cells["ObservationNo"].Value = dt.Rows[i]["ObservationNo"];
                        dgvUAUCdata.Rows[index].Cells["ObservationDate"].Value = (DateTime.Parse(dt.Rows[i]["ObservationDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
                        dgvUAUCdata.Rows[index].Cells["OperationUnit"].Value = dt.Rows[i]["OperationUnit"].ToString();
                        dgvUAUCdata.Rows[index].Cells["DocumentedBy"].Value = dt.Rows[i]["DocumentedBy"];
                        dgvUAUCdata.Rows[index].Cells["MachineTag"].Value = dt.Rows[i]["MachineTag"];
                        dgvUAUCdata.Rows[index].Cells["ObservedBy"].Value = dt.Rows[i]["ObservedBy"].ToString();
                        dgvUAUCdata.Rows[index].Cells["PlantArea"].Value = dt.Rows[i]["PlantArea"];
                        dgvUAUCdata.Rows[index].Cells["ViewHours"].Value = dt.Rows[i]["UACHours"];
                        dgvUAUCdata.Rows[index].Cells["ViewMinuts"].Value = dt.Rows[i]["UACMinuts"];
                        dgvUAUCdata.Rows[index].Cells["Observation"].Value = dt.Rows[i]["Observation"];
                        dgvUAUCdata.Rows[index].Cells["SpecificArea"].Value = dt.Rows[i]["SpecificArea"].ToString();
                        dgvUAUCdata.Rows[index].Cells["AssignedTo"].Value = dt.Rows[i]["AssignedTo"];
                        dgvUAUCdata.Rows[index].Cells["AssignedDate"].Value = (DateTime.Parse(dt.Rows[i]["AssignedDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
                        dgvUAUCdata.Rows[index].Cells["UnsafeCondition"].Value = ((UnsafeCondition)dt.Rows[i]["UnsafeCondition"]).ToString();
                        dgvUAUCdata.Rows[index].Cells["Recommendation"].Value = dt.Rows[i]["Recommendation"].ToString();
                        dgvUAUCdata.Rows[index].Cells["Remarks"].Value = dt.Rows[i]["Remarks"];
                        dgvUAUCdata.Rows[index].Cells["SafetyUser"].Value = dt.Rows[i]["SafetyUser"];
                        dgvUAUCdata.Rows[index].Cells["Status"].Value = ((UAUCStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        dgvUAUCdata.Rows[index].Cells["SnapImage"].Value = dt.Rows[i]["SnapImage"];
                        dgvUAUCdata.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewUAUCClosedData()
        {
            try
            {
                //DataTable dt = UAUC.GetAllUAUC();
                DataTable dt = null;
                dt = UAUC.GetAllUAUC();
                var v = dt.AsEnumerable().Where(X => X.Field<int>("Status") == 3 || X.Field<int>("Status") == 6).ToList();
                if (v.Count > 0)
                {
                    dt = dt.AsEnumerable().Where(X => X.Field<int>("Status") == 3 || X.Field<int>("Status") == 6).CopyToDataTable();
                }

                if (dt == null) return;

                if (dgvUAUCClosedData.Rows.Count > 0)
                    dgvUAUCClosedData.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvUAUCClosedData.Rows.Add(dr);
                        int index = dgvUAUCClosedData.Rows.Count - 1;
                        dgvUAUCClosedData.Rows[index].Cells["ClosObservationNo"].Value = dt.Rows[i]["ObservationNo"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosObservationDate"].Value = (DateTime.Parse(dt.Rows[i]["ObservationDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
                        dgvUAUCClosedData.Rows[index].Cells["ClosOperationUnit"].Value = dt.Rows[i]["OperationUnit"].ToString();
                        dgvUAUCClosedData.Rows[index].Cells["ClosDocumentedBy"].Value = dt.Rows[i]["DocumentedBy"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosMachineTag"].Value = dt.Rows[i]["MachineTag"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosObservedBy"].Value = dt.Rows[i]["ObservedBy"].ToString();
                        dgvUAUCClosedData.Rows[index].Cells["ClosPlantArea"].Value = dt.Rows[i]["PlantArea"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosObservation"].Value = dt.Rows[i]["Observation"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosSpecificArea"].Value = dt.Rows[i]["SpecificArea"].ToString();
                        dgvUAUCClosedData.Rows[index].Cells["ClosAssignedTo"].Value = dt.Rows[i]["AssignedTo"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosAssignedDate"].Value = (DateTime.Parse(dt.Rows[i]["AssignedDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
                        dgvUAUCClosedData.Rows[index].Cells["ClosUnsafeCondition"].Value = ((UnsafeCondition)dt.Rows[i]["UnsafeCondition"]).ToString();
                        dgvUAUCClosedData.Rows[index].Cells["ClosRecommendation"].Value = dt.Rows[i]["Recommendation"].ToString();
                        dgvUAUCClosedData.Rows[index].Cells["ClosRemarks"].Value = dt.Rows[i]["Remarks"];
                        dgvUAUCClosedData.Rows[index].Cells["ClosStatus"].Value = ((UAUCStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        dgvUAUCClosedData.Rows[index].Cells["ClosSnapImage"].Value = dt.Rows[i]["SnapImage"];
                        dgvUAUCClosedData.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewUAUAssignedCData(string assignedToCode)
        {
            try
            {
                DataTable dt = null;
                if (UAUC.CurrentUserRole == "7" || UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "5")
                {
                    dt = UAUC.GetAllUAUC();
                    var v = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 0).ToList();
                    if (v.Count > 0)
                    {
                        dt = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 0).CopyToDataTable();
                    }
                }
                else
                {
                    dt = UAUC.GetAssignedUAUC(assignedToCode);
                    var v = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 5).ToList();
                    if (v.Count > 0)
                        dt = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 5).CopyToDataTable();
                    else
                        return;
                }
                if (dt == null) return;



                // DataTable dt = UAUC.GetAssignedUAUC(assignedToCode);
                if (dgvUAUCAsgnData.Rows.Count > 0)
                    dgvUAUCAsgnData.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvUAUCAsgnData.Rows.Add(dr);
                        int index = dgvUAUCAsgnData.Rows.Count - 1;
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnObservationNo"].Value = dt.Rows[i]["ObservationNo"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnObservationDate"].Value = (DateTime.Parse(dt.Rows[i]["ObservationDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnHours"].Value = dt.Rows[i]["UACHours"].ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnMinuts"].Value = dt.Rows[i]["UACMinuts"].ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnOperationUnit"].Value = dt.Rows[i]["OperationUnit"].ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnDocumentedBy"].Value = dt.Rows[i]["DocumentedBy"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnMachineTag"].Value = dt.Rows[i]["MachineTag"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnObservedBy"].Value = dt.Rows[i]["ObservedBy"].ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnPlantArea"].Value = dt.Rows[i]["PlantArea"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnObservation"].Value = dt.Rows[i]["Observation"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnSpecificArea"].Value = dt.Rows[i]["SpecificArea"].ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnAssignedTo"].Value = dt.Rows[i]["AssignedTo"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnSafetyUser"].Value = dt.Rows[i]["SafetyUser"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnAssignedDate"].Value = (DateTime.Parse(dt.Rows[i]["AssignedDate"].ToString())).ToString("dd-MM-yyyy");
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnUnsafeCondition"].Value = ((UnsafeCondition)dt.Rows[i]["UnsafeCondition"]).ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnRecommendation"].Value = dt.Rows[i]["Recommendation"].ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnRemarks"].Value = dt.Rows[i]["Remarks"];
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnStatus"].Value = ((UAUCStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        dgvUAUCAsgnData.Rows[index].Cells["AsgnSnapImage"].Value = dt.Rows[i]["SnapImage"];
                        dgvUAUCAsgnData.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUAUCSave_Click(object sender, EventArgs e)
        {
            if (ValidateUAUC() == false) return;
            MapUAUCToData(UAUCStatus.Prepare);
            btnUAUCSave.Visible = false;
           
        }

        private void btnUAUCSubmit_Click(object sender, EventArgs e)
        {
            if (txtUaucStatus.Text == UAUCStatus.Prepare.ToString())
            {
                if (ValidateUAUC() == false) return;
                MapUAUCToData(UAUCStatus.Reported);
                HideActionControls();
                //if (CurrentUserRole == 5)
                {
                    UAUC.SubmitMail(UAUC);
                }
            }
            else if (txtUaucStatus.Text == UAUCStatus.Reported.ToString())
            {
                if (cmbUaucAssignedTo.Text == "N/A" && (UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "5" || UAUC.CurrentUserRole == "7") && (GlobalDeclaration._holdInfo[0].UserName != txtUaucDocBy.Text))
                {
                    XtraMessageBox.Show("Please Select Responsibility");
                    return;
                }
                try
                {
                    MapUAUCToData(UAUCStatus.Open);
                    btnUAUCSubmit.Visible = false;
                    btnUAUCReject.Visible = false;
                    Resources.Instance.UpdateUAUC(UAUC.ObservationNo, UAUC.SafetyUser, UAUC.SafetyUserCode);
                    UAUC.ApproveMail(UAUC);
                }
                catch(Exception ex)
                {

                }
            }
            else if (txtUaucStatus.Text == UAUCStatus.Open.ToString() || txtUaucStatus.Text == UAUCStatus.ReOpen.ToString())
            {
                MapUAUCToData(UAUCStatus.DeptClosed);
                btnUAUCSubmit.Visible = false;
                UAUC.DeptClosureMail(UAUC);
            }

            else if (txtUaucStatus.Text == UAUCStatus.DeptClosed.ToString())
            {
                MapUAUCToData(UAUCStatus.Closed);
                btnUAUCSubmit.Visible = false;
                btnUAUCReOpen.Visible = false;
                UAUC.ClosureMail(UAUC);
            }
        }

        private void btnUAUCReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUaucStatus.Text == UAUCStatus.Reported.ToString())
                {
                    MapUAUCToData(UAUCStatus.Rejected);

                    Resources.Instance.UpdateUAUC(UAUC.ObservationNo, UAUC.SafetyUser, UAUC.SafetyUserCode);
                    HideActionControls();
                    UAUC.RejectMail(UAUC);
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btnUAUCDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUAUCView_Click(object sender, EventArgs e)
        {
            UaucPages.SelectedIndex = 0;
            ViewUAUSelfCData();
            currtabIndex = 0;
        }
        int currtabIndex;
        private void btnUAUCApproval_Click(object sender, EventArgs e)
        {
            UaucPages.SelectedIndex = 2;
            ViewUAUAssignedCData(UAUC.CurrentUserCode);
            currtabIndex = 2;
        }

        private void dgvUAUCAsgnData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtUaucObsNo.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnObservationNo"].Value.ToString();
                dtpUaucObsDate.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnObservationDate"].Value.ToString();
                cmbFromHours.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnHours"].Value.ToString();
                cmbFromMinuts.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnMinuts"].Value.ToString();
                cmbUaucOunit.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnOperationUnit"].Value.ToString();
                txtUaucDocBy.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnDocumentedBy"].Value.ToString();
                cmbUAUCMachineTag.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnMachineTag"].Value.ToString();
                //txtUaucMachineTag.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnMachineTag"].Value.ToString();
                txtUaucObsBy.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnObservedBy"].Value.ToString();
                cmbUaucPlantArea.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnPlantArea"].Value.ToString();
                txtUaucObsrvation.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnObservation"].Value.ToString();
                txtUaucSpecificArea.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnSpecificArea"].Value.ToString();
                cmbUaucAssignedTo.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnAssignedTo"].Value.ToString();
                //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
                txtSafetyUsr.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnSafetyUser"].Value.ToString();
                cmbUaucUnSafAct.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnUnsafeCondition"].Value.ToString(); //((UnsafeCondition)(int.Parse(dgvUAUCdata.Rows[e.RowIndex].Cells["UnsafeCondition"].Value.ToString()))).ToString();
                txtUaucRecommd.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnRecommendation"].Value.ToString();
                txtUaucRemarks.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnRemarks"].Value.ToString();
                txtUaucStatus.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnStatus"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnSnapImage"].Value.ToString()))
                {
                    PcbxUauc.Image = GetImage((byte[])(dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnSnapImage"].Value));
                    PcbxUauc.SizeMode = PictureBoxSizeMode.Zoom;
                }
                UaucPages.SelectedIndex = 1;
                lblAddNewHdr.Text = "Update UAUC";
                HideActionControls();
                LoadAssignedTo();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnUAUCReOpen_Click(object sender, EventArgs e)
        {
           if (txtUaucStatus.Text == UAUCStatus.DeptClosed.ToString())
            {
                MapUAUCToData(UAUCStatus.ReOpen);
                btnUAUCSubmit.Visible = false;
                btnUAUCReOpen.Visible = false;
                UAUC.ReOpenMail(UAUC);
            }
        }

        private void btnUAUCClosed_Click(object sender, EventArgs e)
        {
            UaucPages.SelectedIndex = 3;
            ViewUAUCClosedData();
        }

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
                        PcbxUauc.Image = new Bitmap(opFileDialog.FileName);
                        imgPath = opFileDialog.FileName;
                        PcbxUauc.SizeMode = PictureBoxSizeMode.StretchImage;

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

        private Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }
        public static byte[] GetByteFromImage(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        private Boolean ValidateUAUC()
        {
            ErrorProvider errProvider = null;
            errProvider = new ErrorProvider();
            errProvider.Clear();
            bool IsValid = true;
            DateTime dtm = Convert.ToDateTime(dtpUaucObsDate.Value.ToString("dd-MM-yyyy"));
            if (dtm > DateTime.Today)
            {
                XtraMessageBox.Show("Invalid Observed-Date! Please select Observed-Date! as equal or less than Current-Date");
                //errProvider = new ErrorProvider();
                errProvider.SetError(dtpUaucObsDate, "Invalid Observed-Date! Please select Observed-Date! as equal or less than Current-Date");
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(cmbUaucOunit.Text))
            {
                XtraMessageBox.Show("Please Select OperationUnit!");
                //errProvider = new ErrorProvider();
                errProvider.SetError(cmbUaucOunit, "Please Select OperationUnit!");
                IsValid = false;
            }

            else if (string.IsNullOrEmpty(txtUaucObsBy.Text))
            {
                XtraMessageBox.Show("Please fill person who observed!");
                //errProvider = new ErrorProvider();
                errProvider.SetError(txtUaucObsBy, "Please fill person who observed!");
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(cmbUaucPlantArea.Text))
            {
                XtraMessageBox.Show("Please Select Plant-Area!");
                //errProvider = new ErrorProvider();
                errProvider.SetError(cmbUaucPlantArea, "Please Select Plant-Area!");
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(cmbUaucUnSafAct.Text))
            {
                XtraMessageBox.Show("Please Select UnsafeCondition/Act!");
                //errProvider = new ErrorProvider();
                errProvider.SetError(cmbUaucUnSafAct, "Please Select UnsafeCondition/Act!");
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txtUaucSpecificArea.Text))
            {
                XtraMessageBox.Show("Please fill Specific-Area!");
                //errProvider = new ErrorProvider();
                errProvider.SetError(txtUaucSpecificArea, "Please fill Specific-Area!");
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txtUaucObsrvation.Text))
            {
                XtraMessageBox.Show("Please fill Observation!");
                //errProvider = new ErrorProvider();
                errProvider.SetError(txtUaucObsrvation, "Please fill Observation!");
                IsValid = false;
            }
            //else if (string.IsNullOrEmpty(cmbUaucAssignedTo.Text))
            //{
            //    XtraMessageBox.Show("Please fill Responsibility!");
            //    //errProvider = new ErrorProvider();
            //    errProvider.SetError(cmbUaucAssignedTo, "Please fill Responsibility!");
            //    IsValid = false;
            //}

            return IsValid;
        }

        public void LoadMachineTag()
        {
            foreach (var item in GlobalDeclaration._MyTagDictinary)
            {
                string MachineTag = item.Value;
                cmbUAUCMachineTag.Items.Add(MachineTag);
            }
            cmbUAUCMachineTag.Items.Add("Select Cad Layout..");
        }

        private void txtUAUCViewSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //ViewUAUSelfCData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUAUCViewSearch_Click(object sender, EventArgs e)
        {
            FilterUAUCViewData();
        }
        private void FilterUAUCViewData()
        {
            try
            {
                if (txtUAUCViewSearch.Text != string.Empty && dgvUAUCdata.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvUAUCdata.Rows)
                    {
                        //string ss= row.Cells["DocumentNo"].Value.ToString();
                        if (row.Cells["ObservationNo"].Value.ToString().ToUpper() == txtUAUCViewSearch.Text.ToUpper() || row.Cells["OperationUnit"].Value.ToString() == txtUAUCViewSearch.Text
                            || row.Cells["Status"].Value.ToString().ToUpper() == txtUAUCViewSearch.Text.ToUpper() || row.Cells["PlantArea"].Value.ToString().ToUpper() == txtUAUCViewSearch.Text.ToUpper()
                            || row.Cells["AssignedTo"].Value.ToString() == txtUAUCViewSearch.Text || row.Cells["UnsafeCondition"].Value.ToString().ToUpper() == txtUAUCViewSearch.Text.ToUpper()
                            || row.Cells["AssignedDate"].Value.ToString() == txtUAUCViewSearch.Text || row.Cells["DocumentedBy"].Value.ToString() == txtUAUCViewSearch.Text)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
                else
                {
                    ViewUAUSelfCData();
                }
                dgvUAUCdata.Sort(dgvUAUCdata.Columns["ObservationDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterUAUCAsgnData()
        {
            try
            {
                if (txtUAUCAsgnSearch.Text != string.Empty && dgvUAUCAsgnData.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvUAUCAsgnData.Rows)
                    {
                        //string ss= row.Cells["DocumentNo"].Value.ToString();
                        if (row.Cells["AsgnObservationNo"].Value.ToString().ToUpper() == txtUAUCAsgnSearch.Text.ToUpper() || row.Cells["AsgnOperationUnit"].Value.ToString() == txtUAUCAsgnSearch.Text
                            || row.Cells["AsgnStatus"].Value.ToString().ToUpper() == txtUAUCAsgnSearch.Text.ToUpper() || row.Cells["AsgnPlantArea"].Value.ToString().ToUpper() == txtUAUCAsgnSearch.Text.ToUpper()
                            || row.Cells["AsgnAssignedTo"].Value.ToString() == txtUAUCAsgnSearch.Text || row.Cells["AsgnUnsafeCondition"].Value.ToString().ToUpper() == txtUAUCAsgnSearch.Text.ToUpper()
                            || row.Cells["AsgnAssignedDate"].Value.ToString() == txtUAUCAsgnSearch.Text || row.Cells["AsgnDocumentedBy"].Value.ToString() == txtUAUCAsgnSearch.Text
                            || row.Cells["AsgnObservationDate"].Value.ToString() == txtUAUCAsgnSearch.Text)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
                else
                {
                    ViewUAUAssignedCData(UAUC.CurrentUserCode);
                }
                dgvUAUCAsgnData.Sort(dgvUAUCAsgnData.Columns["AsgnObservationDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterUAUCClosData()
        {
            try
            {
                if (txtUAUCClosedSearch.Text != string.Empty && dgvUAUCClosedData.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvUAUCClosedData.Rows)
                    {
                        //string ss= row.Cells["DocumentNo"].Value.ToString();
                        if (row.Cells["ClosObservationNo"].Value.ToString().ToUpper() == txtUAUCClosedSearch.Text.ToUpper() || row.Cells["ClosOperationUnit"].Value.ToString() == txtUAUCClosedSearch.Text
                            || row.Cells["ClosStatus"].Value.ToString().ToUpper() == txtUAUCClosedSearch.Text.ToUpper() || row.Cells["ClosPlantArea"].Value.ToString().ToUpper() == txtUAUCClosedSearch.Text.ToUpper()
                            || row.Cells["ClosAssignedTo"].Value.ToString() == txtUAUCClosedSearch.Text || row.Cells["ClosUnsafeCondition"].Value.ToString().ToUpper() == txtUAUCClosedSearch.Text.ToUpper()
                            || row.Cells["ClosAssignedDate"].Value.ToString() == txtUAUCClosedSearch.Text || row.Cells["ClosDocumentedBy"].Value.ToString() == txtUAUCClosedSearch.Text
                            || row.Cells["ClosObservationDate"].Value.ToString() == txtUAUCClosedSearch.Text)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
                else
                {
                    ViewUAUCClosedData();
                }
                dgvUAUCClosedData.Sort(dgvUAUCClosedData.Columns["ClosObservationDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUAUCViewExport_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvUAUCdata, lblViewSelfDataHdr.Text);
        }

        private void ExportExcelReport(DataGridView dgv, string fileName)
        {
            try
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    dt.Columns.Add(column.HeaderText);//, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }

                //Exporting to Excel
                string folderPath = "C:\\Excel\\";
                SaveFileDialog directchoosedlg = new SaveFileDialog();
                directchoosedlg.FileName = fileName;

                if (directchoosedlg.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Sheet1");
                        string fPath = directchoosedlg.FileName + ".xlsx"; //folderPath + "\\" + fileName + ".xlsx";
                        if (File.Exists(fPath))
                        {
                            DialogResult dgres = XtraMessageBox.Show("File already exist! Are you want to replace?", "Alert", MessageBoxButtons.YesNo);
                            if (dgres == DialogResult.Yes)
                            {
                                wb.SaveAs(fPath);
                                XtraMessageBox.Show("Report Downloaded Successfully.");
                            }
                            else
                                return;
                        }
                        else
                        {
                            wb.SaveAs(fPath);
                            XtraMessageBox.Show("Report Downloaded Successfully.");
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUAUCAsgnSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //ViewUAUAssignedCData(UAUC.CurrentUserCode);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUAUCAsgnSearch_Click(object sender, EventArgs e)
        {
            FilterUAUCAsgnData();
        }

        private void txtUAUCAsgnExport_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvUAUCAsgnData, lblApprovalDataHdr.Text);
        }

        private void btnUAUCClosedSearch_Click(object sender, EventArgs e)
        {
            FilterUAUCClosData();
        }

        private void btnUAUCClosedExport_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvUAUCClosedData, lblViewCloseDataHdr.Text);
        }

        private void cmbUAUCMachineTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbUAUCMachineTag.SelectedItem.ToString())
            {
                case "Select Cad Layout..":
                    this.Hide();
                    break;
                default:
                    {

                    }
                    break;
            }
        }

        public void CallEventfrm_SomeEvent(params object[] args)
        {
            // textBox1.Text = args[0].ToString();
            // textBox3.Text = args[1].ToString();
            //cmbBasicMachineIsolation.SelectedItem = args[1].ToString();
            //cmbBasicMachineIsolation.Text = args[1].ToString();
            //cmbBasicMachineIsolation.Enabled = false;
            //listBox1.Visible = false;
            //textBox2.Text = args[2].ToString();
            DPoint _points = ((DPoint)args[0]);
            cmbUAUCMachineTag.SelectedItem = GlobalDeclaration._MyTagDictinary[_points];
            //var Area = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("Cadlocation") == "X" + _points.X + " " + "Y" + _points.Y).Select(X => X.Field<string>("MachineLocation")).Distinct().ToList();
            //if (Area.Count > 0)
            //    cmbArea.Text = Area[0].ToString();



        }

        int zoomInt = 0;

        public void zoomPicturebox()
        {
            switch (zoomInt)
            {
                case -3:
                    this.PcbxUauc.Width -= 210; //Zoom width by 210
                    this.PcbxUauc.Height -= 210; //Zoom height by 210
                    break;
                case -2:
                    this.PcbxUauc.Width -= 155; //Zoom width by 155
                    this.PcbxUauc.Height -= 155; //Zoom height by 155
                    break;
                case -1:
                    this.PcbxUauc.Width -= 65; //Zoom width by 75
                    this.PcbxUauc.Height -= 65; //Zoom height by 75
                    break;
                case 0:
                    PcbxUauc.Size = new Size(850, 1100);
                    break;
                case 1:
                    this.PcbxUauc.Width += 75; //Zoom width by 75
                    this.PcbxUauc.Height += 75; //Zoom height by 75
                    break;
                case 2:
                    this.PcbxUauc.Width += 150; //Zoom width by 150
                    this.PcbxUauc.Height += 150; //Zoom height by 150
                    break;
                case 3:
                    this.PcbxUauc.Width += 175; //Zoom width by 175
                    this.PcbxUauc.Height += 175; //Zoom height by 175
                    break;
                case 4:
                    this.PcbxUauc.Width += 200; //Zoom width by 175
                    this.PcbxUauc.Height += 200; //Zoom height by 175
                    break;
            }
            PcbxUauc.Refresh(); //Helps causing pictures from getting pixialated: Forces the control to invalidate its client area and immediately redraw itself and any child controls
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            HindalcoiOS.Configuration.MailConfigView mcv = new HindalcoiOS.Configuration.MailConfigView();
            mcv.Show();
        }

        private void UaucPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UaucPages.SelectedIndex == 1)
            {
                RefreshForNewUAUC();
                HideActionControls();
            }
            if (UaucPages.SelectedIndex == 0)
            {
                ViewUAUSelfCData();
                currtabIndex = 0;
            }
            if (UaucPages.SelectedIndex == 3)
            {
                ViewUAUCClosedData();
            }
        }

        private void btnUaucAddNew_Click(object sender, EventArgs e)
        {
            UaucPages.SelectedIndex = 1;
            RefreshForNewUAUC();
            HideActionControls();
            InitCmbHours();
        }

        private void HideUAUCPagesHeader()
        {
            UaucPages.Appearance = TabAppearance.FlatButtons;
            UaucPages.ItemSize = new Size(0, 1);
            UaucPages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in UaucPages.TabPages)
            {
                tab.Hide();// = "";
            }
        }
        private void DisableControlPermanent()
        {
            txtUaucObsNo.Enabled = false;
            txtUaucDocBy.Enabled = false;
            txtUaucStatus.Enabled = false;
            //txtUaucObsNo.Enabled = false;
            txtSafetyUsr.Enabled = false;
        }

        private void dgvUAUCClosedData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtUaucObsNo.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosObservationNo"].Value.ToString();
                dtpUaucObsDate.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosObservationDate"].Value.ToString();
                cmbUaucOunit.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosOperationUnit"].Value.ToString();
                txtUaucDocBy.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosDocumentedBy"].Value.ToString();
                cmbUAUCMachineTag.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosMachineTag"].Value.ToString();
                //txtUaucMachineTag.Text = dgvUAUCAsgnData.Rows[e.RowIndex].Cells["AsgnMachineTag"].Value.ToString();
                txtUaucObsBy.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosObservedBy"].Value.ToString();
                cmbUaucPlantArea.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosPlantArea"].Value.ToString();
                txtUaucObsrvation.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosObservation"].Value.ToString();
                txtUaucSpecificArea.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosSpecificArea"].Value.ToString();
                cmbUaucAssignedTo.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosAssignedTo"].Value.ToString();
                //dtp.Text = dgvUAUCdata.Rows[e.RowIndex].Cells["AssignedDate"].Value.ToString();
                cmbUaucUnSafAct.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosUnsafeCondition"].Value.ToString(); //((UnsafeCondition)(int.Parse(dgvUAUCdata.Rows[e.RowIndex].Cells["UnsafeCondition"].Value.ToString()))).ToString();
                txtUaucRecommd.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosRecommendation"].Value.ToString();
                txtUaucRemarks.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosRemarks"].Value.ToString();
                txtUaucStatus.Text = dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosStatus"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosSnapImage"].Value.ToString()))
                {
                    PcbxUauc.Image = GetImage((byte[])(dgvUAUCClosedData.Rows[e.RowIndex].Cells["ClosSnapImage"].Value));
                    PcbxUauc.SizeMode = PictureBoxSizeMode.Zoom;
                }
                UaucPages.SelectedIndex = 1;
                lblAddNewHdr.Text = "View Closed & Rejected UAUC";
                HideActionControls();
                LoadAssignedTo();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblUaucStatus_Click(object sender, EventArgs e)
        {

        }

        private void InitCmbHours()
        {
            try
            {
                if (cmbFromHours.Items.Count > 0)
                    cmbFromHours.Items.Clear();

                if (cmbFromMinuts.Items.Count > 0)
                    cmbFromMinuts.Items.Clear();

                for (int i = 0; i < 24; i++)
                {
                    cmbFromHours.Items.Add(i);
                }
                for (int j = 0; j < 60; j++)
                {
                    cmbFromMinuts.Items.Add(j);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public enum UAUCStatus
    {
        Prepare = 0,
        Reported = 1,
        Open = 2,
        Rejected = 3,
        ReOpen = 4,
        DeptClosed = 5,
        Closed = 6
    }
    public enum UnsafeCondition
    {
        None = 0,
        UnsafeAct = 1,
        UnsafeCondition = 2,
    }

}
