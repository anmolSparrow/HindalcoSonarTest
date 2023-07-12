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

namespace HindalcoiOS.Form_Collection
{
    public partial class FormatDownloader : DevExpress.XtraEditors.XtraForm
    {
        public FormatDownloader()
        {
            this.Text = " Excel Format Downloader";
            UpdateTextPosition();
            InitializeComponent();
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
        private void FormatDownloader_Load(object sender, EventArgs e)
        {
            //if (GlobalDeclaration.UserType.Equals("U1-Maintenance"))
            //{
            //    cmbformat.SelectedIndex = 2;
            //    cmbformat.Enabled = false;
            //}
        }
        private DataGridView DgvFormatDownloader;
        private void btndownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbformat.SelectedItem != null)
                {
                    if (!string.IsNullOrEmpty(cmbformat.SelectedItem.ToString()))
                    {
                        BindTraingClm(cmbformat.SelectedItem.ToString());
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please Select Format First", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindTraingClm(string reporttype)
        {
            
             DgvFormatDownloader = new DataGridView();
            var dlgSaveEnt = new SaveFileDialog();
            dlgSaveEnt.Filter = "*.xlsx|*.xlsx|*.csv|*.csv";
            try
            {

                switch (reporttype)
                {
                    case "Training":                      
                        DgvFormatDownloader.ColumnCount = 13;
                        DgvFormatDownloader.Columns[0].Name = "SrNo";
                        DgvFormatDownloader.Columns[0].HeaderText = "Sl.No";

                        DgvFormatDownloader.Columns[1].Name = "EmpName";
                        DgvFormatDownloader.Columns[1].HeaderText = "Employee Code";

                        //DgvFormatDownloader.Columns[2].Name = "Dpt";
                        //DgvFormatDownloader.Columns[2].HeaderText = "Department";

                        DgvFormatDownloader.Columns[2].Name = "TraingType";
                        // DgvFormatDownloader.Columns[2].ValueType = typeof(string);
                        DgvFormatDownloader.Columns[2].HeaderText = "Training Type";

                        DgvFormatDownloader.Columns[3].Name = "TrainingTitle";
                        // DgvFormatDownloader.Columns[3].ValueType = typeof(string);
                        DgvFormatDownloader.Columns[3].HeaderText = "Training Title";
                        DgvFormatDownloader.Columns[3].Width = 116;

                        DgvFormatDownloader.Columns[4].Name = "Startdate";
                        DgvFormatDownloader.Columns[4].HeaderText = "Training Start date";

                        DgvFormatDownloader.Columns[5].Name = "EndDate";
                        DgvFormatDownloader.Columns[5].HeaderText = "Training Completion Date";

                        DgvFormatDownloader.Columns[6].Name = "Duration";
                        DgvFormatDownloader.Columns[6].HeaderText = "Duration";

                        DgvFormatDownloader.Columns[7].Name = "Capability";
                        DgvFormatDownloader.Columns[7].HeaderText = "Capability(Internal/External)";

                        DgvFormatDownloader.Columns[8].Name = "NameOfAgency";
                        DgvFormatDownloader.Columns[8].HeaderText = "Name of Agency";

                        DgvFormatDownloader.Columns[9].Name = "Nameoftrainer";
                        DgvFormatDownloader.Columns[9].HeaderText = "Name of Trainer";

                        DgvFormatDownloader.Columns[10].Name = "Venue";
                        DgvFormatDownloader.Columns[10].HeaderText = "Venue/Location";

                        DgvFormatDownloader.Columns[11].Name = "Measurement";
                        DgvFormatDownloader.Columns[11].HeaderText = "Effectiveness";

                        DgvFormatDownloader.Columns[12].Name = "Status";
                        DgvFormatDownloader.Columns[12].HeaderText = "Status";
                        dlgSaveEnt.Title = "Training File Name";
                        dlgSaveEnt.FileName = reporttype;
                        break;
                    case "MaintenanceU0":
                        {
                            DgvFormatDownloader.ColumnCount = 5;
                            DgvFormatDownloader.Columns[0].Name = "ActivityDetail";
                            DgvFormatDownloader.Columns[0].HeaderText = "Activity Detail";
                            DgvFormatDownloader.Columns[1].Name = "Frequency";
                            DgvFormatDownloader.Columns[1].HeaderText = "Frequency";
                            DgvFormatDownloader.Columns[2].Name = "Outsourced/Inhouse";
                            DgvFormatDownloader.Columns[2].HeaderText = "Outsourced/Inhouse";
                            DgvFormatDownloader.Columns[3].Name = "ShutDownRequired";
                            DgvFormatDownloader.Columns[3].HeaderText = "Shut Down Required";
                            DgvFormatDownloader.Columns[4].Name = "MaintenanceScheduledinWeek";
                            DgvFormatDownloader.Columns[4].HeaderText = "Maintenance Scheduled InWeek";
                            dlgSaveEnt.Title = "Maintenance U0";
                            dlgSaveEnt.FileName = string.Concat(reporttype, "-Format");
                        }
                        break;
                    case "MaintenanceU1":
                        {
                            DgvFormatDownloader.ColumnCount = 12;
                            DgvFormatDownloader.Columns[0].Name = "Priority";
                            DgvFormatDownloader.Columns[0].HeaderText = "Priority";
                            DgvFormatDownloader.Columns[1].Name = "MaintenanceType";
                            DgvFormatDownloader.Columns[1].HeaderText = "Maintenance Type";
                            DgvFormatDownloader.Columns[2].Name = "MachineTag";
                            DgvFormatDownloader.Columns[2].HeaderText = "Machine Tag";
                            DgvFormatDownloader.Columns[3].Name = "MachineName";
                            DgvFormatDownloader.Columns[3].HeaderText = "Machine Name";
                            DgvFormatDownloader.Columns[4].Name = "Frequency";
                            DgvFormatDownloader.Columns[4].HeaderText = "Frequency";
                            DgvFormatDownloader.Columns[5].Name = "MaintScheduled";
                            DgvFormatDownloader.Columns[5].HeaderText = "Maintenance Scheduled In Week";
                            DgvFormatDownloader.Columns[6].Name = "ActivityDetails";
                            DgvFormatDownloader.Columns[6].HeaderText = "Activity Details";
                            DgvFormatDownloader.Columns[7].Name = "ShutDownRequired";
                            DgvFormatDownloader.Columns[7].HeaderText = "Shut Down Required";
                            DgvFormatDownloader.Columns[8].Name = "Resource";
                            DgvFormatDownloader.Columns[8].HeaderText = "Resource";
                            DgvFormatDownloader.Columns[9].Name = "AdditionalManPower";
                            DgvFormatDownloader.Columns[9].HeaderText = "Additional Man Power";
                            DgvFormatDownloader.Columns[10].Name = "MeterReading";
                            DgvFormatDownloader.Columns[10].HeaderText = "Meter Reading";
                            DgvFormatDownloader.Columns[11].Name = "UnitsName";
                            DgvFormatDownloader.Columns[11].HeaderText = "Units Name";
                            //dataGridView1.Columns[12].Name = "Team";
                            //dataGridView1.Columns[13].Name = "Datetime";
                            // Adjust the row heights so that all content is visible.
                            DgvFormatDownloader.AutoResizeRows(
                                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
                            dlgSaveEnt.Title = "Maintenance U1";
                            dlgSaveEnt.FileName = string.Concat(reporttype, "-Format");
                        }
                        break;
                    case "Audit Report":
                        {                          
                            DgvFormatDownloader.ColumnCount = 9;
                            DgvFormatDownloader.Columns[0].Name = "Date";
                            DgvFormatDownloader.Columns[0].HeaderText = "Date";
                            DgvFormatDownloader.Columns[1].Name = "Observation";
                            DgvFormatDownloader.Columns[1].HeaderText = "Observation";
                            DgvFormatDownloader.Columns[2].Name = "Recommendation";
                            DgvFormatDownloader.Columns[2].HeaderText = "Recommendation";
                            DgvFormatDownloader.Columns[3].Name = "Auditor";
                            DgvFormatDownloader.Columns[3].HeaderText = "Auditor";
                            DgvFormatDownloader.Columns[4].Name = "Responsibility";
                            DgvFormatDownloader.Columns[4].HeaderText = "Responsibility";
                            DgvFormatDownloader.Columns[5].Name = "Timeframe";
                            DgvFormatDownloader.Columns[5].HeaderText = "Time frame";
                            DgvFormatDownloader.Columns[6].Name = "Typeofobservation";
                            DgvFormatDownloader.Columns[6].HeaderText = "Type of Observation";
                            DgvFormatDownloader.Columns[7].Name = "Typeofrecommendation";
                            DgvFormatDownloader.Columns[7].HeaderText = "Type of Recommendation";
                            DgvFormatDownloader.Columns[8].Name = "RiskCategory";
                            DgvFormatDownloader.Columns[8].HeaderText = "Risk Category";
                            dlgSaveEnt.Title = "Audit Report";
                            dlgSaveEnt.FileName = string.Concat(reporttype, "-Format");
                        }
                        break;
                    case "Audit Calendar":
                        {
                            DgvFormatDownloader.ColumnCount = 11;
                            DgvFormatDownloader.Columns[0].Name = "NameofAudit";
                            DgvFormatDownloader.Columns[0].HeaderText = "Name of Audit";
                            DgvFormatDownloader.Columns[1].Name = "TypeofAudit";
                            DgvFormatDownloader.Columns[1].HeaderText = "Type of Audit";
                            DgvFormatDownloader.Columns[2].Name = "Area";
                            DgvFormatDownloader.Columns[2].HeaderText = "Audit Area";
                            DgvFormatDownloader.Columns[3].Name = "ProcessName";
                            DgvFormatDownloader.Columns[3].HeaderText = "Process Name";
                            DgvFormatDownloader.Columns[4].Name = "Frequency";
                            DgvFormatDownloader.Columns[4].HeaderText = "Frequency";
                            DgvFormatDownloader.Columns[5].Name = "LastDate";
                            DgvFormatDownloader.Columns[5].HeaderText = "Last Date Of Audit";
                            DgvFormatDownloader.Columns[6].Name = "Department";
                            DgvFormatDownloader.Columns[6].HeaderText = "Department";
                            DgvFormatDownloader.Columns[7].Name = "Individual";
                            DgvFormatDownloader.Columns[7].HeaderText = "Individual";
                            DgvFormatDownloader.Columns[8].Name = "AuditOwner";
                            DgvFormatDownloader.Columns[8].HeaderText = "Audit Owner";
                            DgvFormatDownloader.Columns[9].Name = "Reviewedby";
                            DgvFormatDownloader.Columns[9].HeaderText = "Reviewed by";
                            DgvFormatDownloader.Columns[10].Name = "Approvedby";
                            DgvFormatDownloader.Columns[10].HeaderText = "Approved by";
                            dlgSaveEnt.Title = "Audit Calendar";
                            dlgSaveEnt.FileName = string.Concat(reporttype, "-Format");
                        }
                        break;
                    case "OHC Form Format":
                        {
                            DgvFormatDownloader.ColumnCount = 12;
                            DgvFormatDownloader.Columns[0].Name = "EmployeeName";
                            DgvFormatDownloader.Columns[0].HeaderText = "Employee Name";
                            DgvFormatDownloader.Columns[1].Name = "EmployeeCode";
                            DgvFormatDownloader.Columns[1].HeaderText = "Employee Code";
                            DgvFormatDownloader.Columns[2].Name = "Gender";
                            DgvFormatDownloader.Columns[2].HeaderText = "Gender";
                            DgvFormatDownloader.Columns[3].Name = "DOB";
                            DgvFormatDownloader.Columns[3].HeaderText = "DOB";
                            DgvFormatDownloader.Columns[4].Name = "AadharNUmber";
                            DgvFormatDownloader.Columns[4].HeaderText = "Aadhar Number";
                            DgvFormatDownloader.Columns[5].Name = "DOJ";
                            DgvFormatDownloader.Columns[5].HeaderText = "DOJ";
                            DgvFormatDownloader.Columns[6].Name = "Department";
                            DgvFormatDownloader.Columns[6].HeaderText = "Department";
                            DgvFormatDownloader.Columns[7].Name = "Employee Type";
                            DgvFormatDownloader.Columns[7].HeaderText = "Employee Type";
                            DgvFormatDownloader.Columns[8].Name = "Company";
                            DgvFormatDownloader.Columns[8].HeaderText = "Company";
                            DgvFormatDownloader.Columns[9].Name = "CheckUp Date";
                            DgvFormatDownloader.Columns[9].HeaderText = "CheckUpDate";
                            DgvFormatDownloader.Columns[10].Name = "Health Status";
                            DgvFormatDownloader.Columns[10].HeaderText = "Health Status";
                            DgvFormatDownloader.Columns[11].Name = "Remarks";
                            DgvFormatDownloader.Columns[11].HeaderText = "Remarks";
                            dlgSaveEnt.Title = "OHC Form Format";
                            dlgSaveEnt.FileName = string.Concat(reporttype, "-Format");
                        }
                        break;
                    default:
                        DgvFormatDownloader.ColumnCount = 4;
                        DgvFormatDownloader.Columns[0].Name = "SrNo";
                        DgvFormatDownloader.Columns[0].HeaderText = "SI.No";
                        DgvFormatDownloader.Columns[1].Name = "TraingType";
                        DgvFormatDownloader.Columns[1].HeaderText = "Training Type";
                        DgvFormatDownloader.Columns[2].Name = "TrainingTitle";
                        DgvFormatDownloader.Columns[2].HeaderText = "Training Title";
                        DgvFormatDownloader.Columns[3].Name = "Capability";
                        DgvFormatDownloader.Columns[3].HeaderText = "Capability";
                        break;
                    case "Item Master":
                        {
                            DgvFormatDownloader.ColumnCount = 12;
                            DgvFormatDownloader.Columns[0].Name = "ITEMCODE";
                            DgvFormatDownloader.Columns[1].Name = "ITEMNAME";
                            DgvFormatDownloader.Columns[2].Name = "MAKE";
                            DgvFormatDownloader.Columns[3].Name = "MODEL";
                            DgvFormatDownloader.Columns[4].Name = "MINIMUMSTOCK";
                            DgvFormatDownloader.Columns[5].Name = "UNIT";
                            DgvFormatDownloader.Columns[6].Name = "UNITCODE";
                            DgvFormatDownloader.Columns[7].Name = "SUBCATEGORY";
                            DgvFormatDownloader.Columns[8].Name = "SUBCATEGORYCODE";
                            DgvFormatDownloader.Columns[9].Name = "CATEGORY";
                            DgvFormatDownloader.Columns[10].Name = "CATEGORYCODE";
                            DgvFormatDownloader.Columns[11].Name = "THRESHOLD";
                            DgvFormatDownloader.Columns[0].HeaderText = "ITEMCODE";
                            DgvFormatDownloader.Columns[1].HeaderText = "ITEMNAME";
                            DgvFormatDownloader.Columns[2].HeaderText = "MAKE";
                            DgvFormatDownloader.Columns[3].HeaderText = "MODEL";
                            DgvFormatDownloader.Columns[4].HeaderText = "MINIMUMSTOCK";
                            DgvFormatDownloader.Columns[5].HeaderText = "UNIT";
                            DgvFormatDownloader.Columns[6].HeaderText = "UNITCODE";
                            DgvFormatDownloader.Columns[7].HeaderText = "SUBCATEGORY";
                            DgvFormatDownloader.Columns[8].HeaderText = "SUBCATEGORYCODE";
                            DgvFormatDownloader.Columns[9].HeaderText = "CATEGORY";
                            DgvFormatDownloader.Columns[10].HeaderText = "CATEGORYCODE";
                            DgvFormatDownloader.Columns[11].HeaderText = "THRESHOLD";
                            dlgSaveEnt.Title = "Item Master";
                            dlgSaveEnt.FileName = string.Concat(reporttype, "-Format");
                        }
                        break;
                }
                DgvFormatDownloader.BorderStyle = BorderStyle.Fixed3D;

                DgvFormatDownloader.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvFormatDownloader.AllowUserToResizeColumns = false;

                DgvFormatDownloader.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvFormatDownloader.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvFormatDownloader.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvFormatDownloader.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvFormatDownloader.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvFormatDownloader.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                if (dlgSaveEnt.ShowDialog() != DialogResult.OK)
                    return;
                string fname = dlgSaveEnt.FileName;
                if (fname != null)
                {
                    Microsoft.Office.Interop.Excel._Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = XcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = dlgSaveEnt.Title;
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;
                    for (int i = 1; i < DgvFormatDownloader.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = DgvFormatDownloader.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Font.NAME = "Calibri";
                        worksheet.Cells[1, i].Font.Bold = true;
                        worksheet.Cells[1, i].Interior.Color = Color.Wheat;
                        worksheet.Cells[1, i].Font.Size = 12;
                    }
                    PopulateDropdown(worksheet, reporttype);
                    worksheet.Columns.AutoFit();
                    worksheet.StandardWidth = 116;
                    workbook.SaveAs(fname);
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Format Save Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //XcelApp.Visible = true;
                    XcelApp.UserControl = true;
                    workbook.Close(true, Type.Missing, Type.Missing);
                    XcelApp.Quit();
                    ReleaseObject(worksheet);
                    ReleaseObject(workbook);
                    ReleaseObject(XcelApp);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                XtraMessageBox.Show("Exception Occured while releasing object " + ex.Message, "Error");
            }
            finally
            {
                GC.Collect();
            }
        }
        private void PopulateDropdown(Microsoft.Office.Interop.Excel._Worksheet oSheet, string ReportType)
        {
            try
            {
                if (ReportType == "Training")
                {
                    oSheet.Range["B2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                       Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetEmployee());

                    oSheet.Range["C2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TraingType());


                    oSheet.Range["D2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertInformation,
                  Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TrainingTtitle());
                    oSheet.Range["J2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());
                    oSheet.Range["H2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Capability());


                    oSheet.Range["M2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, StatusCimplete());
                }
                else if (ReportType == "Audit")
                {
                    oSheet.Range["G2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                                         Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TypeOfObservation(), Type.Missing);
                    oSheet.Range["H2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
                        Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TypeOfRecommendation());

                    oSheet.Range["I2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                       Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, RiskCategrory());
                }
                else if (ReportType == "Audit Calendar")
                {
                    oSheet.Range["B2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                                         Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TypeOfAudit(), Type.Missing);

                    oSheet.Range["C2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                                        Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreaterEqual, ListOfArea(), Type.Missing);

                    oSheet.Range["E2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Freequency(), Type.Missing);

                    oSheet.Range["G2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                                    Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetDeptName(), Type.Missing);

                    oSheet.Range["H2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
                        Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());


                    oSheet.Range["I2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                       Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());

                    oSheet.Range["J2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());

                    oSheet.Range["K2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());
                }
                else if (ReportType == "MaintenanceU1")
                {
                    oSheet.Range["A2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Priority());
                    oSheet.Range["B2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, MaintenaceType());
                    oSheet.Range["H2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                     Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, YesNo());
                    oSheet.Range["I2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                    Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, ReSource());
                    oSheet.Range["L2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                     Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, UnitsDetails());
                    oSheet.Range["E2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                    Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Freequency());
                }
                else if (ReportType == "MaintenanceU0")
                {
                    oSheet.Range["B2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Freequency());
                    oSheet.Range["C2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, ReSource());
                    oSheet.Range["D2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, YesNo());
                }
                else if (ReportType == "OHC Form Format")
                {
                    oSheet.Range["C2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Gender());
                    oSheet.Range["G2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetDeptName());
                    oSheet.Range["H2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmployeeType());
                    oSheet.Range["K2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, HelathStatus());
                    //oSheet.Range["D2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                    //                   Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern);
                }
               
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
           
        }
        public string TypeOfAudit()
        {
            //  Resources.Instance.TypeOfAuditDT

            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance.TypeOfAuditDT.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.TypeOfAuditDT.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.TypeOfAuditDT.Rows[i]["TypeOfAudit"].ToString();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                        //break;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        public string ListOfArea()
        {
            StringBuilder strBuilder = new StringBuilder();        
                if (Resources.Instance.AreaOwner.Rows.Count >0)
                {
                    for (int i = 0; i < Resources.Instance.AreaOwner.Rows.Count; i++)//Resources.Instance.AreaOwner.Rows.Count
                    {
                        string excelVal = Resources.Instance.AreaOwner.Rows[i]["NameOfArea"].ToString().Trim();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                        //break;
                    }
                   strBuilder.ToString();                
            }
            return strBuilder.ToString();
        }

        private string TrainingTtitle()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance._trainingTitle.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._trainingTitle.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._trainingTitle.Rows[i]["TTitle"].ToString();

                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                        //break;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string Freequency()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] capabilty = new string[] { "Daily", "Weekly", "Monthly", "Quarterly", "Half-Yearly", "Yearly" };
                for (int i = 0; i < capabilty.Length; i++)
                {
                    string excelVal = capabilty[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string Priority()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] Prt = new string[] { "Urgent", "High", "Medium", "Low", "Non essential" };
                for (int i = 0; i < Prt.Length; i++)
                {
                    string excelVal = Prt[i];
                    stringBuilder.Append(excelVal);

                    stringBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stringBuilder.ToString();
        }
        private string MaintenaceType()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] Prt = new string[] { "Preventive Maintenance", "Corrective Maintenance", "Break Down" };
                for (int i = 0; i < Prt.Length; i++)
                {
                    string excelVal = Prt[i];
                    stringBuilder.Append(excelVal);

                    stringBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stringBuilder.ToString();
        }
        private string YesNo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] Prt = new string[] { "Yes", "No" };
                for (int i = 0; i < Prt.Length; i++)
                {
                    string excelVal = Prt[i];
                    stringBuilder.Append(excelVal);

                    stringBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stringBuilder.ToString();
        }
        private string ReSource()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string[] Prt = new string[] { "InHouse", "OutSource" };
                for (int i = 0; i < Prt.Length; i++)
                {
                    string excelVal = Prt[i];
                    stringBuilder.Append(excelVal);

                    stringBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stringBuilder.ToString();
        }
        public string TypeOfObservation()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance.TpeofObDT.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.TpeofObDT.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.TpeofObDT.Rows[i]["TypeObser"].ToString();

                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                        //break;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        public string TypeOfRecommendation()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance.TpeofObDT.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.TpeofObDT.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.TpeofObDT.Rows[i]["TypeRecomm"].ToString();

                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                        //break;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }

        private string TraingType()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance._TrainingType.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._TrainingType.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._TrainingType.Rows[i]["TraingType"].ToString();

                        strBuilder.Append(excelVal);

                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }

        private string Capability()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] capabilty = new string[] { "Internal", "External" };
                for (int i = 0; i < capabilty.Length; i++)
                {
                    string excelVal = capabilty[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string RiskCategrory()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] ArrayList = { "High", "Low", "Mediam", "Very-High", "Critical" };
                for (int i = 0; i < ArrayList.Length; i++)
                {
                    string excelVal = ArrayList[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }

        private string GetEmployee()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance._EmpCode.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._EmpCode.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._EmpCode.Rows[i]["emp_code"].ToString();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string StatusCimplete()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] capabilty = new string[] { "Completed", "Not Completed" };
                for (int i = 0; i < capabilty.Length; i++)
                {
                    string excelVal = capabilty[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string EmpNameString()
        {
            StringBuilder strBuilder = new StringBuilder();
            string gg = string.Empty;
            try
            {
                if (Resources.Instance._EmpName.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._EmpName.Rows[i]["emp_name"].ToString();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string GetDeptName()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
               // DataTable dt = Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                if (Resources.Instance.DepartmentMaster.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.DepartmentMaster.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.DepartmentMaster.Rows[i]["DepartName"].ToString();

                        strBuilder.Append(excelVal);

                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        public string EmployeeType()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                // DataTable dt = Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                if (Resources.Instance.EmployeementType.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.EmployeementType.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.EmployeementType.Rows[i]["EmpType"].ToString();

                        strBuilder.Append(excelVal);

                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string Gender()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] capabilty = new string[] { "Male", "Female" };
                for (int i = 0; i < capabilty.Length; i++)
                {
                    string excelVal = capabilty[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string HelathStatus()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {

                string[] capabilty = new string[] { "Good", "Excellent", "Poor", "Sick" };
                for (int i = 0; i < capabilty.Length; i++)
                {
                    string excelVal = capabilty[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string UnitsDetails()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance._UnitMaster.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._UnitMaster.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._UnitMaster.Rows[i]["UnitName"].ToString();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
    }
}
