using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using RMPCLApp.Class_Operation;
using RMPCLApp.OHC_AMC;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace RMPCLApp.OHC_and_AMC.View
{
    public partial class OHCFrm : DevExpress.XtraEditors.XtraForm
    {
        #region Local Variable Declaration
        public OHCReport oHCReport;
        private List<string> _SheetNameHold = new List<string>();
        public EventHandler<string> ClearDic;
        public EventHandler<DataSet> _UploadReport;
        #endregion

        #region Form Constructor
        public OHCFrm()
        {
            oHCReport = new OHCReport();
            InitializeComponent();
        }
        #endregion

        #region Method Collection
        public void BindDriopDown()
        {
            dropdownGender.DataSource = Enum.GetValues(typeof(Gender));
            dropdownHealth.DataSource = Enum.GetValues(typeof(HealthStatus));
            DataTable dt = oHCReport.GetEmpType();
            if (dt.Rows.Count > 0)
            {
                dropdownEMPType.DataSource = dt;
                dropdownEMPType.ValueMember = "EmpType";
                dropdownEMPType.DisplayMember = "EmpType";
            }
            dt = Resources.Instance.DepartmentMaster;
            if (dt.Rows.Count > 0)
            {
                dropdownDPT.DataSource = dt;
                dropdownDPT.ValueMember = "DepartName";
                dropdownDPT.DisplayMember = "DepartName";
            }

        }
        public void LoadPDFFile(string FileNames)
        {
            string fileExtention = Path.GetExtension(FileNames);
            string[] s = (FileNames.ToString()).Split('\\');
            int count = s.Length;
            string FileName = s[count - 1].Split('.')[0];
            if (fileExtention.ToUpper() == ".PDF")
            {
                if (!_SheetNameHold.Contains(FileName))
                {
                    //tabcontrolAudit.SelectedIndex = 2;
                    //tabcontrolAudit.TabPages[0].Hide();
                    //tabcontrolAudit.TabPages[1].Hide();                       
                    _SheetNameHold.Add(FileName);
                    oHCReport.GetBytes(fileExtention, FileNames);
                }
                else
                {
                    XtraMessageBox.Show("Same File " + this.lblupload.Text + " Already Uploaded", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        DataTable GloblaDataTabl = null;
        //public void FillSummaryData()
        //{
        //    HideandDisableCtrl();
        //    if (oHCReport.CallingStatus == CallingStatus.Summary)
        //    {
        //        GloblaDataTabl = oHCReport.GetRecord();

        //        if (GloblaDataTabl.Rows.Count > 0)
        //        {
        //            btnUpload.Visible = false;
        //            btnExportData.Location = btnUpload.Location;
        //            for (int i = 0; i < GloblaDataTabl.Rows.Count; i++)
        //            {
        //                oHCReport.SINO = int.Parse(GloblaDataTabl.Rows[i]["SrNo"].ToString());
        //                oHCReport.EmployeeCode = GloblaDataTabl.Rows[i]["EmployeeCode"].ToString();
        //                oHCReport.EmployeeName = GloblaDataTabl.Rows[i]["EmployeeName"].ToString();
        //                oHCReport.DOB = Convert.ToDateTime(GloblaDataTabl.Rows[i]["DOB"].ToString());
        //                oHCReport.Gender = (Gender)Enum.ToObject(typeof(Gender), int.Parse(GloblaDataTabl.Rows[i]["Gender"].ToString()));
        //                oHCReport.AadharNumber = Convert.ToInt64(GloblaDataTabl.Rows[i]["AadharNumber"].ToString());
        //                oHCReport.DOJ = Convert.ToDateTime(GloblaDataTabl.Rows[i]["DOJ"].ToString());
        //                oHCReport.DepartmentName = GloblaDataTabl.Rows[i]["Department"].ToString();
        //                oHCReport.EmployeeType = GloblaDataTabl.Rows[i]["EmploymentType"].ToString();
        //                oHCReport.CompanyName = GloblaDataTabl.Rows[i]["Company"].ToString();
        //                oHCReport.CheckUpDate = Convert.ToDateTime(GloblaDataTabl.Rows[i]["CheckUpDate"].ToString());
        //                oHCReport.HealthStatus = (HealthStatus)Enum.ToObject(typeof(HealthStatus), int.Parse(GloblaDataTabl.Rows[i]["HealthStatus"].ToString()));
        //                oHCReport.Remark = GloblaDataTabl.Rows[i]["Remark"].ToString();
        //                oHCReport.FileBytes = (byte[])GloblaDataTabl.Rows[i]["Report"];
        //                oHCReport.GetImageValue = oHCReport.GetImage((byte[])GloblaDataTabl.Rows[i]["Photo"]);
        //                oHCReport.ReportPath = GloblaDataTabl.Rows[i]["Reportname"].ToString();
        //                DGVGridview.AddNewRow();
        //                oHCReport.clearAllProt();
        //            }
        //        }
        //        else
        //        {
        //            btnUpload.Enabled = false;
        //            btnExportData.Enabled = false;
        //        }
          
        //    }
        //}
        private void GetPDFFileByte(string EmpCode)
        {
            try
            {
                if (GloblaDataTabl == null) return;
                DataTable bytes = GloblaDataTabl.AsEnumerable().Where(X => X.Field<string>("EmployeeCode") == EmpCode).CopyToDataTable();// Select(X => X.Field<string>("Report"));                
                oHCReport.FileBytes = (byte[])bytes.Rows[0]["Report"];
                //oHCReport.FileBytes = (byte[])bytes;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public void HideandDisableCtrl()
        {
            GRPOHCDetails.Hide();
            GrpDGV.Location = GRPOHCDetails.Location;
            GrpDGV.Size = GRPOHCDetails.Size;
            dgvOHCdataView.Size = new Size(1404,443);
            if (oHCReport.CallingStatus == CallingStatus.Upload)
            {
                btnExportData.Visible = false;
            }
        }
        private void ResetAllCTRlValue()
        {
            try
            {
                txtsrno.Text = oHCReport.SINO.ToString();
                txtEmployeeCode.Text = oHCReport.EmployeeCode;
                txtEmpName.Text = oHCReport.EmployeeName;
                DatePickerDOB.Value = oHCReport.DOB;
                dropdownGender.SelectedItem = oHCReport.Gender;
                txtAaDharNo.Text = oHCReport.AadharNumber.ToString();
                datetimeDOJ.Value = oHCReport.DOJ;
                dropdownDPT.SelectedValue = oHCReport.DepartmentName;
                dropdownEMPType.SelectedValue = oHCReport.EmployeeType;
                txtCompnay.Text = oHCReport.CompanyName;
                datetimeCheckDate.Value = oHCReport.CheckUpDate;
                dropdownHealth.SelectedItem = oHCReport.HealthStatus;
                if (oHCReport.CallingStatus == CallingStatus.Summary)
                {
                    txtRemark.Text = oHCReport.Remark;
                    lblupload.Text = oHCReport.ReportPath;
                    pictureEmp.Image = oHCReport.GetImageValue;

                }
                else if (oHCReport.CallingStatus == CallingStatus.Upload)
                {
                    txtRemark.Text = oHCReport.Remark;
                    btnUpload.Visible = false;
                    btnUpload.Enabled = false;
                    btnExportData.Visible = false;
                    btnExportData.Enabled = false;
                }
                EnableCTRL();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void HideButtonCTRLForNew()
        {
            this.btnUpload.Visible = false;
            this.btnExportData.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnDelete.Visible = false;
        }
        public void GenerateSrNo()
        {
            try
            {
                int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);                                        
                Resources.Instance.GetMaxID("GetMaxSerNo", "@MaxID", ref randomDigit);//Change by RP   
                oHCReport.SINO = randomDigit + 1;
                if (oHCReport.CallingStatus == CallingStatus.New)
                    txtsrno.Text = oHCReport.SINO.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearPropertytext()
        {
            txtsrno.Text = string.Empty;
            oHCReport.SINO = 0;
            oHCReport.EmployeeCode = txtEmployeeCode.Text = string.Empty;
            oHCReport.EmployeeName = txtEmpName.Text = string.Empty;
            //datetimeDOJ.Format = DateTimePickerFormat.Custom;
            //datetimeDOJ.CustomFormat = " ";
            //datetimeCheckDate.Format = DateTimePickerFormat.Custom;
            //datetimeCheckDate.CustomFormat = " ";
            oHCReport.AadharNumber = 0;
            txtAaDharNo.Text = string.Empty;
            //DatePickerDOB.Format = DateTimePickerFormat.Custom;
            //DatePickerDOB.CustomFormat = " ";
            oHCReport.CompanyName = txtCompnay.Text = string.Empty;
            oHCReport.Remark = txtRemark.Text = string.Empty;
            pictureEmp.Image = null;
            lblupload.Text = string.Empty;
            oHCReport.Remark = txtRemark.Text = "";
            oHCReport.CompanyName = txtCompnay.Text = "";
            oHCReport.ImageByte = null;
            pictureEmp.Image = null;
            if (oHCReport.CallingStatus == CallingStatus.New)
                GenerateSrNo();
        }
        public void UploadEventFire(object sender, DataSet ds)
        {
            try
            {
                if (ds.Tables[sender.ToString()].Columns[0].ColumnName == "Employee Code" && ds.Tables[sender.ToString()].Columns[0].ColumnName == "Employee Name" &&
                   ds.Tables[sender.ToString()].Columns[0].ColumnName == "DOB" && ds.Tables[sender.ToString()].Columns[0].ColumnName == "Gender")
                {
                    XtraMessageBox.Show("This File is not a Valid.\n Please Download Valid Excel File Format", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < ds.Tables[sender.ToString()].Rows.Count; i++)
                {
                    GenerateSrNo();
                    DataRow row = ds.Tables[sender.ToString()].Rows[i];
                    oHCReport.EmployeeCode = row["Employee Code"].ToString();
                    oHCReport.EmployeeName = row["Employee Name"].ToString();
                    oHCReport.DOB = Convert.ToDateTime(row["DOB"].ToString());
                    oHCReport.Gender = (Gender)Enum.Parse(typeof(Gender), row["Gender"].ToString(), true);
                    oHCReport.AadharNumber = Convert.ToInt64(row["Aadhar Number"].ToString());
                    oHCReport.DOJ = Convert.ToDateTime(row["DOJ"].ToString());
                    oHCReport.DepartmentName = row["Department"].ToString();
                    oHCReport.EmployeeType = row["Employee Type"].ToString();
                    oHCReport.CompanyName = row["Company"].ToString();
                    oHCReport.CheckUpDate = Convert.ToDateTime(row["CheckUpDate"].ToString());
                    oHCReport.HealthStatus = (HealthStatus)Enum.Parse(typeof(HealthStatus), row["Health Status"].ToString(), true);
                    oHCReport.Remark = row["Remarks"].ToString();
                    // oHCReport.GetImageValue = oHCReport.GetImage((byte[])dt.Rows[i]["Photo"]);
                    //oHCReport.ReportPath = dt.Rows[i]["Reportname"].ToString();
                    //DGVGridview.AddNewRow();
                    oHCReport.clearAllProt();
                    // DGVfreeze.Rows.Add(dr);
                }
                btnUpload.Visible = false;
                btnUpload.Enabled = false;
            }
            catch (Exception Ex)
            {
                oHCReport.clearAllProt();
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidationCheck(bool isUpdate)
        {
            if (string.IsNullOrEmpty(oHCReport.EmployeeCode))
            {
                XtraMessageBox.Show("Kindly Fill the Employee Code", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }
            if ((oHCReport.IsUniqueEmpId(oHCReport.EmployeeCode)) && (oHCReport.CallingStatus == CallingStatus.New || oHCReport.CallingStatus == CallingStatus.Summary) && !isUpdate)
            {
                XtraMessageBox.Show("Employee Code already exists.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Text=string.Empty;
                txtEmployeeCode.Focus();
                return false;
            }
            if (oHCReport.DOB.ToString() == "01-01-0001 00:00:00")
            {
                XtraMessageBox.Show("Please select DOB", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DatePickerDOB.Focus();
                return false;
            }
            if (oHCReport.CheckUpDate.ToString() == "01-01-0001 00:00:00")
            {
                XtraMessageBox.Show("Please select Check-Up Date", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datetimeCheckDate.Focus();
                return false;
            }
            if (oHCReport.DOJ.ToString() == "01-01-0001 00:00:00")
            {
                XtraMessageBox.Show("Please select DOJ", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                datetimeDOJ.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(oHCReport.EmployeeName))
            {
                XtraMessageBox.Show("Kindly Fill the Employee Name", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(oHCReport.AadharNumber.ToString()))
            {
                XtraMessageBox.Show("Kindly Fill the Aadhar Number", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAaDharNo.Focus();
                return false;
            }
            if (!oHCReport.IsValidId(oHCReport.AadharNumber.ToString()))
            {
                XtraMessageBox.Show("Please Enter Valid Aadhar Number", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAaDharNo.Text = string.Empty;
                txtAaDharNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(oHCReport.DepartmentName))
            {
                XtraMessageBox.Show("Please Select DepartmentName", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dropdownDPT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(oHCReport.CompanyName))
            {
                XtraMessageBox.Show("Please Enter the Company Name", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompnay.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(oHCReport.EmployeeType))
            {
                XtraMessageBox.Show("Please Select EmployeementName", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dropdownEMPType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(oHCReport.Remark))
            {
                XtraMessageBox.Show("Please Fill The Remark Field", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemark.Focus();
                return false;
            }
            if (oHCReport.DOB > DateTime.Now)
            {
                XtraMessageBox.Show("DOB Should be Less than Current Date", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DatePickerDOB.Focus();
                return false;
            }
            if (oHCReport.ImageByte == null)
            {
                XtraMessageBox.Show("Kindly Upload Photo", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (oHCReport.FileBytes == null)
            {
                XtraMessageBox.Show("Kindly Upload PDF File", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public void DisableCTRL()
        {
            this.txtAaDharNo.Enabled = false;
            this.txtCompnay.Enabled = false;
            this.txtEmployeeCode.Enabled = false;
            this.txtEmpName.Enabled = false;
            this.txtRemark.Enabled = false;
            lblupload.Enabled = false;
            this.txtsrno.Enabled = false;
            this.txtAaDharNo.Enabled = false;
            this.dropdownDPT.Enabled = false;
            this.dropdownEMPType.Enabled = false;
            this.dropdownGender.Enabled = false;
            this.dropdownHealth.Enabled = false;
            this.datetimeCheckDate.Enabled = false;
            this.datetimeDOJ.Enabled = false;
            this.DatePickerDOB.Enabled = false;
            this.pictureEmp.Enabled = false;
            btnuploadImage.Enabled = false;
            btnDelete.Enabled = false;
            btnUploadRPT.Enabled = false;
        }
        public void EnableCTRL()
        {
            this.txtAaDharNo.Enabled = true;
            //this.txtCompnay.Enabled = true;
            this.txtEmployeeCode.Enabled = true;
            this.txtEmpName.Enabled = true;
            this.txtRemark.Enabled = true;
            lblupload.Enabled = true;
            this.txtsrno.Enabled = false;
            this.txtAaDharNo.Enabled = true;
            this.dropdownDPT.Enabled = true;
            this.dropdownEMPType.Enabled = true;
            this.dropdownGender.Enabled = true;
            this.dropdownHealth.Enabled = true;
            this.datetimeCheckDate.Enabled = true;
            this.datetimeDOJ.Enabled = true;
            this.DatePickerDOB.Enabled = true;
            this.pictureEmp.Enabled = true;
            btnuploadImage.Enabled = true;
            btnDelete.Enabled = true;
            btnUploadRPT.Enabled = true;
        }
        #endregion

        #region OHC Event Details
        private void OHCFrm_Load(object sender, EventArgs e)
        {
            try
            {
                BindDriopDown();
                ////DGVGridview.Columns.Clear();
                ////DGVDetails.DataSource = oHCReport.BindColumn();
                ////DGVGridview.InitNewRow += DGVGridview_InitNewRow;
                if (oHCReport.CallingStatus == CallingStatus.Summary)
                {
                    //FillSummaryData();
                    FillDataView();
                }
                if (oHCReport.CallingStatus == CallingStatus.Upload)
                {
                    this._UploadReport += UploadEventFire;
                }
                txtEmpName.KeyPress += txtEmpName_KeyPress;
                //txtEmployeeCode.Input.KeyPress += txtEmpCode_KeyPressEvent;                
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else if (oHCReport.CallingStatus == CallingStatus.New)
            //{
            //    BindDriopDown();
            //    //DGVGridview.InitNewRow += DGVGridview_InitNewRow;
            //}

        }
        int Coi = 0;
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (oHCReport.CallingStatus == CallingStatus.Summary || oHCReport.CallingStatus == CallingStatus.Upload)
            {
                btnBack.Visible = false;
                this.btnUpload.Visible = false;
                if (oHCReport.CallingStatus == CallingStatus.Summary)
                {
                    this.btnExportData.Visible = true;
                    oHCReport.FileBytes = null;
                }

                GRPOHCDetails.Hide();
                GrpDGV.Show();
                GrpDGV.Location = GRPOHCDetails.Location;
                oHCReport.clearAllProt();
            }
        }
        private void DGVGridview_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (oHCReport.CallingStatus == CallingStatus.New || oHCReport.CallingStatus == CallingStatus.Summary || oHCReport.CallingStatus == CallingStatus.Upload)
                {
                    view.SetRowCellValue(e.RowHandle, "S.No.", oHCReport.SINO);
                    view.SetRowCellValue(e.RowHandle, "Employee Code", oHCReport.EmployeeCode);
                    view.SetRowCellValue(e.RowHandle, "Employee Name", oHCReport.EmployeeName);
                    view.SetRowCellValue(e.RowHandle, "DOB", oHCReport.DOB);
                    view.SetRowCellValue(e.RowHandle, "Gender", oHCReport.Gender);
                    view.SetRowCellValue(e.RowHandle, "Aadhar Number", oHCReport.AadharNumber);
                    view.SetRowCellValue(e.RowHandle, "Date Of Joining", oHCReport.DOJ);
                    view.SetRowCellValue(e.RowHandle, "Department", oHCReport.DepartmentName);
                    view.SetRowCellValue(e.RowHandle, "Employee Type", oHCReport.EmployeeType);
                    view.SetRowCellValue(e.RowHandle, "Company", oHCReport.CompanyName);
                    view.SetRowCellValue(e.RowHandle, "Chech-Up Date", oHCReport.CheckUpDate);
                    view.SetRowCellValue(e.RowHandle, "Health Status", oHCReport.HealthStatus);
                    view.SetRowCellValue(e.RowHandle, "Remarks", oHCReport.Remark);
                    if (oHCReport.CallingStatus != CallingStatus.Upload)
                    {
                        view.SetRowCellValue(e.RowHandle, "Report", oHCReport.ReportPath);
                        RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
                        pictureEdit.SizeMode = PictureSizeMode.Squeeze;
                        pictureEdit.PictureStoreMode = PictureStoreMode.Image;
                        //DGVDetails.RepositoryItems.Add(pictureEdit);
                        //DGVGridview.OptionsView.RowAutoHeight = true;
                        //DGVGridview.Columns["Photo"].ColumnEdit = pictureEdit;
                        //DGVGridview.Columns["Photo"].OptionsColumn.FixedWidth = true;
                        //DGVGridview.Columns["Photo"].Width = 100;
                        if (pictureEmp.Image != null && oHCReport.CallingStatus == CallingStatus.New)
                        {
                            view.SetRowCellValue(e.RowHandle, "Photo", pictureEmp.Image);
                        }
                        else
                        {
                            view.SetRowCellValue(e.RowHandle, "Photo", oHCReport.GetImageValue);
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void DGVGridview_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (oHCReport.CallingStatus == CallingStatus.Summary || oHCReport.CallingStatus == CallingStatus.Upload)
        //        {
        //            int[] selectedRowHandles = DGVGridview.GetSelectedRows();
        //            if (selectedRowHandles.Length > 0)
        //            {
        //                DGVGridview.FocusedRowHandle = selectedRowHandles[0];
        //                DataRowView selRow = (DataRowView)(((GridView)DGVDetails.MainView).GetRow(selectedRowHandles[0]));
        //                oHCReport.SINO = int.Parse(selRow["S.No."].ToString());
        //                oHCReport.EmployeeCode = selRow["Employee Code"].ToString();
        //                oHCReport.EmployeeName = selRow["Employee Name"].ToString();
        //                oHCReport.DOB = Convert.ToDateTime(selRow["DOB"].ToString());
        //                string Genders = selRow["Gender"].ToString();
        //                oHCReport.Gender = (Gender)Enum.Parse(typeof(Gender), Genders, true);
        //                oHCReport.AadharNumber = Convert.ToInt64(selRow["Aadhar Number"].ToString());
        //                oHCReport.DOJ = Convert.ToDateTime(selRow["Date Of Joining"].ToString());
        //                oHCReport.DepartmentName = selRow["Department"].ToString();
        //                oHCReport.EmployeeType = selRow["Employee Type"].ToString();
        //                if (oHCReport.EmployeeType == "Permanent")
        //                {
        //                    oHCReport.CompanyName = txtCompnay.Text = "RMPCL";
        //                    txtCompnay.Enabled = false;
        //                    //txtCompnay.ReadOnly = true;
        //                }
        //                else
        //                {
        //                    oHCReport.CompanyName = selRow["Company"].ToString();
        //                }
        //                oHCReport.CheckUpDate = Convert.ToDateTime(selRow["Chech-Up Date"].ToString());
        //                oHCReport.HealthStatus = (HealthStatus)Enum.Parse(typeof(HealthStatus), selRow["Health Status"].ToString(), true); //((HealthStatus)selRow["Health Status"]);
        //                oHCReport.Remark = selRow["Remarks"].ToString();

        //                if (oHCReport.CallingStatus == CallingStatus.Summary || (oHCReport.CallingStatus == CallingStatus.Upload && !string.IsNullOrEmpty(selRow["Report"].ToString())))
        //                {
        //                    string[] s = (selRow["Report"].ToString()).Split('\\');
        //                    int count = s.Length;
        //                    string FileName = s[count - 1].Split('.')[0];
        //                    oHCReport.ReportPath = FileName;
        //                    oHCReport.ImageByte = oHCReport.SaveImage(selRow["Photo"]);
        //                    oHCReport.GetImageValue = oHCReport.GetImage(oHCReport.ImageByte);
        //                    GetPDFFileByte(oHCReport.EmployeeCode);
        //                }
        //                //if (oHCReport.CallingStatus == CallingStatus.Summary||(oHCReport.CallingStatus == CallingStatus.Upload && !string.IsNullOrEmpty(selRow["Report"].ToString())))
        //                //{
        //                //    oHCReport.ReportPath = selRow["Report"].ToString();
        //                //    oHCReport.ImageByte = oHCReport.SaveImage(selRow["Photo"]);
        //                //    //System.IO.File.WriteAllBytes("hello.pdf", fileContent);
        //                //    oHCReport.GetImageValue = oHCReport.GetImage(oHCReport.ImageByte);
        //                //    GetPDFFileByte(oHCReport.EmployeeCode);
        //                //}                        
        //                GrpDGV.Hide();
        //                GRPOHCDetails.Show();
        //                GRPOHCDetails.Location = GrpDGV.Location;
        //                btnBack.Visible = true;
        //                btnBack.Location = btnExportData.Location;
        //                btnAdd.Visible = false;
        //                btnUpdate.Visible = true;
        //                btnUpdate.Location = btnAdd.Location;
        //                btnDelete.Visible = true;
        //                btnDelete.Location = new Point(1102, 344);
        //                ResetAllCTRlValue();
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationCheck(false))
                {
                    int Sts = oHCReport.SaveData(oHCReport, 0);
                    if (Sts > 0)
                    {
                        ////DGVGridview.AddNewRow();
                        XtraMessageBox.Show("Record Saved Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearPropertytext();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationCheck(true))
                {
                    int Sts = 0;
                    if (oHCReport.CallingStatus == CallingStatus.Summary)
                    {
                        Sts = oHCReport.SaveData(oHCReport, 1);// For Updattion Command Execute
                        DataRow[] RowExists = GloblaDataTabl.Select("EmployeeCode='" + oHCReport.EmployeeCode + "'");
                        if (RowExists.Length > 0)
                        {
                            RowExists[0]["Report"] = oHCReport.FileBytes;
                        }
                    }
                    else if (oHCReport.CallingStatus == CallingStatus.Upload)// For Insert When  Upload from Excel Data
                    {
                        if (string.IsNullOrEmpty(oHCReport.ReportPath) && oHCReport.FileBytes == null)
                        {
                            XtraMessageBox.Show("Please Upload Employee Report", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (oHCReport.FileBytes == null && pictureEmp == null && oHCReport.ImageByte == null)
                        {
                            XtraMessageBox.Show("Please Upload Employee Photo", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        bool IsExists = oHCReport.IsUniqueEmpId(oHCReport.EmployeeCode);
                        if (IsExists)
                        {
                            Sts = oHCReport.SaveData(oHCReport, 1);
                        }
                        else
                        {
                            Sts = oHCReport.SaveData(oHCReport, 0);
                        }

                    }
                    if (Sts > 0)
                    {
                        XtraMessageBox.Show("Record Update Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisableCTRL();
                        //int[] selectedRowHandles = DGVGridview.GetSelectedRows();
                        //if (selectedRowHandles.Length > 0)
                        //{
                        //    int RowIndex = DGVGridview.FocusedRowHandle = selectedRowHandles[0];
                        //    DGVGridview.SetRowCellValue(RowIndex, "S.No.", oHCReport.SINO);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Employee Code", oHCReport.EmployeeCode);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Employee Name", oHCReport.EmployeeName);
                        //    DGVGridview.SetRowCellValue(RowIndex, "DOB", oHCReport.DOB);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Gender", oHCReport.Gender);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Aadhar Number", oHCReport.AadharNumber);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Date Of Joining", oHCReport.DOJ);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Department", oHCReport.DepartmentName);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Employee Type", oHCReport.EmployeeType);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Company", oHCReport.CompanyName);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Chech-Up Date", oHCReport.CheckUpDate);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Health Status", oHCReport.HealthStatus);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Remarks", oHCReport.Remark);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Report", oHCReport.ReportPath);
                        //    DGVGridview.SetRowCellValue(RowIndex, "Photo", pictureEmp.Image);
                        //    DGVGridview.PostEditor();
                        //    DGVGridview.UpdateCurrentRow();
                        //}
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int sts = oHCReport.DeleteRecord(oHCReport);
                if (sts > 0)
                {
                    XtraMessageBox.Show("Record delete Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oHCReport.clearAllProt();
                    ClearPropertytext();
                    ////int[] selectedRowHandles = DGVGridview.GetSelectedRows();
                    ////if (selectedRowHandles.Length > 0)
                    ////{
                    ////    int RowIndex = DGVGridview.FocusedRowHandle = selectedRowHandles[0];
                    ////    DGVGridview.DeleteRow(RowIndex);
                    ////    btnBack_Click(sender, e);//Done Sir
                    ////}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnUploadRPT_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog obd = new OpenFileDialog();
                obd.Filter = "PDF Files| *.pdf";
                DialogResult dlgRes = obd.ShowDialog(this);
                if ((dlgRes != DialogResult.OK) || (string.IsNullOrEmpty(obd.FileName)))
                {
                    return;
                }
                string[] s = (obd.FileName.ToString()).Split('\\');
                int count = s.Length;
                string FileName = s[count - 1].Split('.')[0];
                lblupload.Text = FileName;
                oHCReport.ReportPath = obd.FileName.ToString();
                LoadPDFFile(obd.FileName.ToString());
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnuploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _opfl = new OpenFileDialog();
                _opfl.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.BMP)| *.jpg; *.jpeg; *.png; *.gif | bmp files(*.bmp) | *.bmp; ";
                if (_opfl.ShowDialog() != DialogResult.Cancel)
                {
                    string fileExtention = Path.GetExtension(_opfl.FileName);
                    if (fileExtention.ToUpper() == ".JPG")
                    {
                        Image img = Image.FromFile(_opfl.FileName);
                        MemoryStream ms1 = new MemoryStream();
                        img.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] ImageSize = new byte[ms1.Length];
                        //if (ms1.Length > 102400)
                        //{
                        //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please upload less than 100 kb image");
                        //}
                        //else
                        //{
                        //    pictureEmp.Image = img;
                        //    oHCReport.ImageByte = oHCReport.SaveImage(img);
                        //}
                        pictureEmp.Image = img;
                        oHCReport.ImageByte = oHCReport.SaveImage(img);
                    }
                    else
                    {
                        XtraMessageBox.Show("Please Upload Only JPEG Image Format", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                XtraMessageBox.Show("Accept Alphabets only", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtEmpCode_KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                XtraMessageBox.Show("Accept Alphabets only", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtAaDharNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                XtraMessageBox.Show("Please Enter Number Only", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                XtraMessageBox.Show("Accept Alphabets only", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dropdownEMPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownEMPType.SelectedValue == null) return;
            oHCReport.EmployeeType = dropdownEMPType.SelectedValue.ToString();
            if (dropdownEMPType.SelectedValue.ToString() == "Permanent")
            {
                txtCompnay.Enabled = false;
                txtCompnay.Enabled = false;// txtCompnay.ReadOnly = true;
                oHCReport.CompanyName = txtCompnay.Text = "RMPCL";
            }
            else
            {
                if (txtCompnay.Text != "RMPCL" && dropdownEMPType.SelectedValue.ToString() != "Permanent")
                {
                    txtCompnay.Enabled = true;
                    txtCompnay.Enabled = false;//txtCompnay.ReadOnly = false;
                    txtCompnay.Text = string.Empty;
                }
                else
                {
                    txtCompnay.Enabled = true;
                    txtCompnay.Enabled = false;//txtCompnay.ReadOnly = false;
                    txtCompnay.Text = string.Empty;
                }
                //if (string.IsNullOrEmpty(txtCompnay.Text) && oHCReport.CallingStatus == CallingStatus.New)
                //{

                //    txtCompnay.Enabled = true;
                //    txtCompnay.ReadOnly = false;
                //    oHCReport.CompanyName = txtCompnay.Text = string.Empty;
                //}
                //else if (string.IsNullOrEmpty(oHCReport.CompanyName) && oHCReport.CallingStatus == CallingStatus.Summary)
                //{
                //    txtCompnay.Enabled = true;
                //    txtCompnay.ReadOnly = false;
                //    oHCReport.CompanyName = txtCompnay.Text = string.Empty;
                //}

            }

            // dropdownmachinetag.Enabled = false;

        }
        private void dropdownGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownGender.SelectedItem.ToString()))
            {
                oHCReport.Gender = ((Gender)dropdownGender.SelectedItem);
            }
        }
        private void dropdownHealth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownHealth.SelectedItem.ToString()))
            {
                oHCReport.HealthStatus = ((HealthStatus)dropdownHealth.SelectedItem);
            }
        }
        private void dropdownDPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownDPT.SelectedValue == null) return;
            if (!string.IsNullOrEmpty(dropdownDPT.SelectedValue.ToString()))
            {
                oHCReport.DepartmentName = dropdownDPT.SelectedValue.ToString();
            }
        }
        private void lblupload_Click(object sender, EventArgs e)
        {
            try
            {

                if (oHCReport.CallingStatus == CallingStatus.New)
                {
                    if (!this.lblupload.Text.Contains(".") && !string.IsNullOrEmpty(txtEmpName.Text))
                    {
                        string fileExtention = Path.GetExtension(this.lblupload.Text);
                        string[] s = (this.lblupload.Text.ToString()).Split('\\');
                        int count = s.Length;
                        string FileName = s[count - 1].Split('.')[0];
                        byte[] returnByte = oHCReport.GetBytes(fileExtention, this.lblupload.Text);
                        oHCReport.ReportPath = this.lblupload.Text;
                        oHCReport.ReloadPDF(txtEmpName.Text, returnByte);
                    }
                }
                else if (oHCReport.CallingStatus == CallingStatus.Summary || oHCReport.CallingStatus == CallingStatus.Upload)
                {
                    GetPDFFileByte(oHCReport.EmployeeCode);
                    oHCReport.ReportPath = this.lblupload.Text;
                    oHCReport.ReloadPDF(txtEmpName.Text, oHCReport.FileBytes);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtEmployeeCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeCode.Text) && txtEmployeeCode.Text.Length > 0)
                {
                    XtraMessageBox.Show("Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeCode.Text = string.Empty;
                    txtEmployeeCode.Focus();
                    return;

                }
                else
                {
                    if (txtEmployeeCode.Text.StartsWith(" "))
                    {
                        XtraMessageBox.Show("Beginning Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmployeeCode.Text = string.Empty;
                        txtEmployeeCode.Focus();
                        return;
                    }
                    else if (txtEmployeeCode.Text.EndsWith(" "))
                    {
                        XtraMessageBox.Show("trailing Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmployeeCode.Text = string.Empty;
                        txtEmployeeCode.Focus();
                        return;
                    }
                    else
                    {
                        oHCReport.EmployeeCode = txtEmployeeCode.Text;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtEmpName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpName.Text) && txtEmpName.Text.Length > 0)
            {
                XtraMessageBox.Show("Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpName.Text = string.Empty;
                txtEmpName.Focus();
                return;
            }
            else
            {
                if (txtEmpName.Text.StartsWith(" "))
                {
                    XtraMessageBox.Show("Beginning Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpName.Text = string.Empty;
                    txtEmpName.Focus();
                    return;
                }
                else if (txtEmpName.Text.EndsWith(" "))
                {
                    XtraMessageBox.Show("Beginning Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpName.Text = string.Empty;
                    txtEmpName.Focus();
                    return;
                }
                else
                {
                    oHCReport.EmployeeName = txtEmpName.Text;
                }
            }
        }
        private void txtAaDharNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAaDharNo.Text) && txtAaDharNo.Text.Length > 0)
            {
                XtraMessageBox.Show("Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAaDharNo.Text = string.Empty;
                txtAaDharNo.Focus();
                return;
            }
            else
            {
                oHCReport.AadharNumber = Convert.ToInt64(txtAaDharNo.Text);
            }
        }
        private void txtCompnay_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompnay.Text) && txtCompnay.Text.Length > 0)
            {
                XtraMessageBox.Show("Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompnay.Text = string.Empty;
                txtCompnay.Focus();
                return;
            }
            else
            {
                if (txtCompnay.Text.StartsWith(" "))
                {
                    XtraMessageBox.Show("Beginning Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompnay.Text = string.Empty;
                    txtCompnay.Focus();
                    return;
                }
                else if (txtCompnay.Text.EndsWith(" "))
                {
                    XtraMessageBox.Show("trailing Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompnay.Text = string.Empty;
                    txtCompnay.Focus();
                    return;
                }
                else
                {
                    oHCReport.CompanyName = txtCompnay.Text;
                }

            }
        }
        private void txtRemark_Leave(object sender, EventArgs e)
        {
            // if (!string.IsNullOrEmpty(txtRemark.Text))
            //{
            //    oHCReport.Remark = txtRemark.Text;
            //}
            if (txtRemark.Text.StartsWith(" "))
            {
                XtraMessageBox.Show("Beginning Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemark.Text = string.Empty;
                txtRemark.Focus();
                return;
            }
            else if (txtRemark.Text.EndsWith(" "))
            {
                XtraMessageBox.Show("trailing Space Not Allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemark.Text = string.Empty;
                txtRemark.Focus();
                return;
            }
            else
            {
                oHCReport.Remark = txtRemark.Text;
            }
        }
        private void DatePickerDOB_ValueChanged(object sender, EventArgs e)
        {
            if (DatePickerDOB.Value != null)
            {
                oHCReport.DOB = DatePickerDOB.Value;
            }
        }
        private void datetimeDOJ_ValueChanged(object sender, EventArgs e)
        {
            if (datetimeDOJ.Value != null)
            {
                oHCReport.DOJ = datetimeDOJ.Value;
            }
        }
        private void datetimeCheckDate_ValueChanged(object sender, EventArgs e)
        {

            if (datetimeCheckDate.Value != null)
            {
                oHCReport.CheckUpDate = datetimeCheckDate.Value;
            }

        }
        private void btnExportData_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog _fld = new FolderBrowserDialog();
                DialogResult result = _fld.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string FileName = _fld.SelectedPath;
                    FileName = string.Concat(FileName, @"\", "EmployeeSummary", DateTime.Now.ToString("dd-MM-yyy"), ".xlsx");
                    XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                    options.ShowGridLines = true;
                    options.FitToPrintedPageHeight = true;
                    options.FitToPrintedPageWidth = true;
                    options.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.True;
                    options.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    options.ExportMode = XlsxExportMode.SingleFile;
                    options.SheetName = "Employee Summary";
                    options.AllowFixedColumnHeaderPanel = DefaultBoolean.Default;
                    ////DGVGridview.ExportToXlsx(FileName, options);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {

        }
        private void OHCFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            oHCReport.Dispose();
            this.Dispose();
            this.ClearDic.Invoke(sender, oHCReport.FormName);
        }
        private void DGVDetails_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FillDataView()
        {
            // dgvOHCdataView.DataSource= oHCReport.GetRecord();
            HideandDisableCtrl();
            try
            {
                DataTable dt = null;

                ////dt = UAUC.GetAllUAUC();
                dt = oHCReport.GetRecord();

                //var v = dt.AsEnumerable().Where(X => X.Field<string>("DocumentedByCode") == UAUC.CurrentUserCode).ToList();
                //if (v.Count > 0)
                //{
                //    dt = dt.AsEnumerable().Where(X => X.Field<string>("DocumentedByCode") == UAUC.CurrentUserCode).CopyToDataTable();
                //}


                if (dt == null) return;

                if (dgvOHCdataView.Rows.Count > 0)
                    dgvOHCdataView.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvOHCdataView.Rows.Add(dr);
                        int index = dgvOHCdataView.Rows.Count - 1;
                        dgvOHCdataView.Rows[index].Cells["SrNo"].Value = dt.Rows[i]["SrNo"].ToString();
                        dgvOHCdataView.Rows[index].Cells["EmployeeCode"].Value = dt.Rows[i]["EmployeeCode"].ToString();//)).ToString("dd-MM-yyyy hh:mm");
                        dgvOHCdataView.Rows[index].Cells["EmployeeName"].Value = dt.Rows[i]["EmployeeName"].ToString();
                        dgvOHCdataView.Rows[index].Cells["DOB"].Value = dt.Rows[i]["DOB"].ToString();
                        dgvOHCdataView.Rows[index].Cells["Gender"].Value = dt.Rows[i]["Gender"].ToString();
                        dgvOHCdataView.Rows[index].Cells["AadharNumber"].Value = dt.Rows[i]["AadharNumber"].ToString();
                        dgvOHCdataView.Rows[index].Cells["DOJo"].Value = dt.Rows[i]["DOJ"].ToString();
                        dgvOHCdataView.Rows[index].Cells["Department"].Value = dt.Rows[i]["Department"].ToString();
                        dgvOHCdataView.Rows[index].Cells["EmployeeType"].Value = dt.Rows[i]["EmploymentType"].ToString();
                        dgvOHCdataView.Rows[index].Cells["Company"].Value = dt.Rows[i]["Company"].ToString();
                        dgvOHCdataView.Rows[index].Cells["CheckUpDate"].Value = (DateTime.Parse(dt.Rows[i]["CheckUpDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
                        dgvOHCdataView.Rows[index].Cells["Remark"].Value = dt.Rows[i]["Remark"].ToString();
                        dgvOHCdataView.Rows[index].Cells["Report"].Value = dt.Rows[i]["Report"].ToString();
                        dgvOHCdataView.Rows[index].Cells["Reportname"].Value = dt.Rows[i]["Reportname"];
                        dgvOHCdataView.Rows[index].Cells["HealthStatus"].Value = dt.Rows[i]["HealthStatus"].ToString();
                        dgvOHCdataView.Rows[index].Cells["Photo"].Value =dt.Rows[i]["Photo"];
                        dgvOHCdataView.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvOHCdataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (oHCReport.CallingStatus == CallingStatus.Summary || oHCReport.CallingStatus == CallingStatus.Upload)
                {
                    //int[] selectedRowHandles = DGVGridview.GetSelectedRows();
                    //if (selectedRowHandles.Length > 0)
                    {
                        if (e.RowIndex < 0) return;
                        
                        //DGVGridview.FocusedRowHandle = selectedRowHandles[0];
                        //DataRowView selRow = (DataRowView)(((GridView)DGVDetails.MainView).GetRow(selectedRowHandles[0]));
                        oHCReport.SINO = int.Parse(dgvOHCdataView.Rows[e.RowIndex].Cells["SrNo"].Value.ToString());
                        oHCReport.EmployeeCode = dgvOHCdataView.Rows[e.RowIndex].Cells["EmployeeCode"].Value.ToString();
                        oHCReport.EmployeeName = dgvOHCdataView.Rows[e.RowIndex].Cells["EmployeeName"].Value.ToString(); //selRow["Employee Name"].ToString();
                        oHCReport.DOB = Convert.ToDateTime(dgvOHCdataView.Rows[e.RowIndex].Cells["DOB"].Value.ToString());// Convert.ToDateTime(selRow["DOB"].ToString());
                        string Genders = dgvOHCdataView.Rows[e.RowIndex].Cells["Gender"].Value.ToString();// selRow["Gender"].ToString();
                        oHCReport.Gender = (Gender)Enum.Parse(typeof(Gender), Genders, true);
                        oHCReport.AadharNumber = Convert.ToInt64(dgvOHCdataView.Rows[e.RowIndex].Cells["AadharNumber"].Value.ToString());// Convert.ToInt64(selRow["Aadhar Number"].ToString());
                        oHCReport.DOJ = Convert.ToDateTime(dgvOHCdataView.Rows[e.RowIndex].Cells["DOJo"].Value.ToString());// Convert.ToDateTime(selRow["Date Of Joining"].ToString());
                        oHCReport.DepartmentName = dgvOHCdataView.Rows[e.RowIndex].Cells["Department"].Value.ToString();// selRow["Department"].ToString();
                        oHCReport.EmployeeType = dgvOHCdataView.Rows[e.RowIndex].Cells["EmployeeType"].Value.ToString();// selRow["Employee Type"].ToString();
                        if (oHCReport.EmployeeType == "Permanent")
                        {
                            oHCReport.CompanyName = txtCompnay.Text = "RMPCL";
                            txtCompnay.Enabled = false;
                            //txtCompnay.ReadOnly = true;
                        }
                        else
                        {
                            oHCReport.CompanyName = dgvOHCdataView.Rows[e.RowIndex].Cells["Company"].Value.ToString();// selRow["Company"].ToString();
                        }
                        var vv = dgvOHCdataView.Rows[e.RowIndex].Cells["HealthStatus"].Value.ToString();
                        oHCReport.CheckUpDate = Convert.ToDateTime(dgvOHCdataView.Rows[e.RowIndex].Cells["CheckUpDate"].Value.ToString()); //Convert.ToDateTime(selRow["Chech-Up Date"].ToString());
                        oHCReport.HealthStatus = (HealthStatus)Enum.Parse(typeof(HealthStatus), vv, true); //((HealthStatus)selRow["Health Status"]);
                        oHCReport.Remark = dgvOHCdataView.Rows[e.RowIndex].Cells["Remark"].Value.ToString();

                        if (oHCReport.CallingStatus == CallingStatus.Summary || (oHCReport.CallingStatus == CallingStatus.Upload && !string.IsNullOrEmpty(dgvOHCdataView.Rows[e.RowIndex].Cells["Report"].Value.ToString())))
                        {
                            string[] s = dgvOHCdataView.Rows[e.RowIndex].Cells["Report"].Value.ToString().Split('\\');// (selRow["Report"].ToString()).Split('\\');
                            int count = s.Length;
                            string FileName = s[count - 1].Split('.')[0];
                            oHCReport.ReportPath = FileName;
                            oHCReport.ImageByte =(byte[])dgvOHCdataView.Rows[e.RowIndex].Cells["Photo"].Value;// oHCReport.SaveImage(dgvOHCdataView.Rows[e.RowIndex].Cells["Photo"].Value);// oHCReport.SaveImage(selRow["Photo"]);
                            oHCReport.GetImageValue = oHCReport.GetImage(oHCReport.ImageByte);
                            GetPDFFileByte(oHCReport.EmployeeCode);
                        }
                        //if (oHCReport.CallingStatus == CallingStatus.Summary||(oHCReport.CallingStatus == CallingStatus.Upload && !string.IsNullOrEmpty(selRow["Report"].ToString())))
                        //{
                        //    oHCReport.ReportPath = selRow["Report"].ToString();
                        //    oHCReport.ImageByte = oHCReport.SaveImage(selRow["Photo"]);
                        //    //System.IO.File.WriteAllBytes("hello.pdf", fileContent);
                        //    oHCReport.GetImageValue = oHCReport.GetImage(oHCReport.ImageByte);
                        //    GetPDFFileByte(oHCReport.EmployeeCode);
                        //}                        
                        GrpDGV.Hide();
                        GRPOHCDetails.Show();
                        GRPOHCDetails.Location = GrpDGV.Location;
                        btnBack.Visible = true;
                        btnBack.Location = btnExportData.Location;
                        btnAdd.Visible = false;
                        btnUpdate.Visible = true;
                        btnUpdate.Location = btnAdd.Location;
                        btnDelete.Visible = true;
                        ////btnDelete.Location = new Point(1102, 344);
                        ResetAllCTRlValue();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ViewUAUAssignedCData(DataTable dtt)
        //{
        //    try
        //    {
        //        DataTable dt = null;
        //        if (UAUC.CurrentUserRole == "7" || UAUC.CurrentUserRole == "1" || UAUC.CurrentUserRole == "5")
        //        {
        //            dt = UAUC.GetAllUAUC();
        //            var v = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 0).ToList();
        //            if (v.Count > 0)
        //            {
        //                dt = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 0).CopyToDataTable();
        //            }
        //        }
        //        else
        //        {
        //            dt = UAUC.GetAssignedUAUC(assignedToCode);
        //            var v = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 5).ToList();
        //            if (v.Count > 0)
        //                dt = dt.AsEnumerable().Where(X => X.Field<int>("Status") != 3 && X.Field<int>("Status") != 6 && X.Field<int>("Status") != 5).CopyToDataTable();
        //            else
        //                return;
        //        }
        //        if (dt == null) return;



        //        // DataTable dt = UAUC.GetAssignedUAUC(assignedToCode);
        //        if (dgvOHCdataView.Rows.Count > 0)
        //            dgvOHCdataView.Rows.Clear();
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                DataGridViewRow dr = new DataGridViewRow();
        //                dgvOHCdataView.Rows.Add(dr);
        //                int index = dgvOHCdataView.Rows.Count - 1;
        //                dgvOHCdataView.Rows[index].Cells["AsgnObservationNo"].Value = dt.Rows[i]["ObservationNo"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnObservationDate"].Value = (DateTime.Parse(dt.Rows[i]["ObservationDate"].ToString())).ToString("dd-MM-yyyy hh:mm");
        //                dgvOHCdataView.Rows[index].Cells["AsgnOperationUnit"].Value = dt.Rows[i]["OperationUnit"].ToString();
        //                dgvOHCdataView.Rows[index].Cells["AsgnDocumentedBy"].Value = dt.Rows[i]["DocumentedBy"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnMachineTag"].Value = dt.Rows[i]["MachineTag"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnObservedBy"].Value = dt.Rows[i]["ObservedBy"].ToString();
        //                dgvOHCdataView.Rows[index].Cells["AsgnPlantArea"].Value = dt.Rows[i]["PlantArea"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnObservation"].Value = dt.Rows[i]["Observation"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnSpecificArea"].Value = dt.Rows[i]["SpecificArea"].ToString();
        //                dgvOHCdataView.Rows[index].Cells["AsgnAssignedTo"].Value = dt.Rows[i]["AssignedTo"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnAssignedDate"].Value = (DateTime.Parse(dt.Rows[i]["AssignedDate"].ToString())).ToString("dd-MM-yyyy");
        //                dgvOHCdataView.Rows[index].Cells["AsgnUnsafeCondition"].Value = ((UnsafeCondition)dt.Rows[i]["UnsafeCondition"]).ToString();
        //                dgvOHCdataView.Rows[index].Cells["AsgnRecommendation"].Value = dt.Rows[i]["Recommendation"].ToString();
        //                dgvOHCdataView.Rows[index].Cells["AsgnRemarks"].Value = dt.Rows[i]["Remarks"];
        //                dgvOHCdataView.Rows[index].Cells["AsgnStatus"].Value = ((UAUCStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
        //                dgvOHCdataView.Rows[index].Cells["AsgnSnapImage"].Value = dt.Rows[i]["SnapImage"];
        //                dgvOHCdataView.Visible = true;
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public byte[] GetByteFromImage(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

    }
}
