using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using RMPCLApp.DAL;
using RMPCLApp.Models;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RMPCLApp.Operation
{
    public partial class ProductDetails : DevExpress.XtraEditors.XtraForm
    {
        public Operation.BusinessClasses.ProductMaster prodMaster { get; set; }
        public Operation.BusinessClasses.DailyProduction DailyProd { get; set; }
        public Operation.BusinessClasses.DailyProductionTmpTbl DailyTmpTbl { get; set; }
        public ServiceDAL DalService { get; set; }
        private int RowCounter { get; set; }
        private decimal ActualProduction { get; set; }
        private string DProdCode { get; set; }
        private int isNewRecord { get; set; }
        public Operation.BusinessClasses.MonthlyProduction monthProd { get; set; }
        // public DailyProduction dailyProd { get; set; }
        public decimal ClosingStock { get; set; }
        public DailyConsumption dailyConsum { get; set; }

        private int isPageLoaded { get; set; }
        private int issavedClicked { get; set; }
        private int empRoleId { get; set; }
        private int IsEntriesDone { get; set; }
        public int DynamicPrpty { get; set; }
        private string ProductName { get; set; }
        private bool isPrdMasterValid { get; set; }
        private bool isProdName { get; set; }

        public EventHandler<string> UpdateTimeInterval;

        public ProductDetails()
        {
            DalService = new ServiceDAL();
            prodMaster = new Operation.BusinessClasses.ProductMaster();
            DailyProd = new Operation.BusinessClasses.DailyProduction();
            DailyTmpTbl = new Operation.BusinessClasses.DailyProductionTmpTbl();
            monthProd = new Operation.BusinessClasses.MonthlyProduction();
            dailyConsum = new DailyConsumption();
            IsEntriesDone = 0;
            RowCounter = 0;
            InitializeComponent();
        }

        #region "variable Declaration"
        Double WorkHr = 0;
        decimal WorkMin = 0;
        DataTable prodData = null;
        DataTable dailyProduction = null;
        DataTable GridBck = null;
        DataTable SearchProdDt = null;
        DataTable unitMasterDT = null;
        DataTable dailMastrBck = null;
        DataTable DGVRowDT = null;
        DataTable DailyDataPSSP = null;
        DataTable DailyDataGSSP = null;
        DataTable ElecConsumptionPSSP = null;
        DataTable ElecConsumptionGSSP = null;
        DataTable ProdData = null;
        DataTable dts1 = new DataTable();
        DataTable ProdCodeDT = null;
        List<string> MessasgeAP = new List<string>();
        public delegate void MyDelegate();
        //holdUserInfo _strcu = new holdUserInfo();
        int retVal = 0;
        decimal totalCoal = 0;
        int totaHr = 0;
        int totMin = 0;
        int k = 0;
        Dashboard dashboard = new Dashboard();
        int lastRowIndex = 0;
        string ConsumSaved = "";
        bool tabReload = false;
        string[] hrArr = new string[] { };
        string[] MainhrArr = new string[] { };
        public string EmpCode { get; set; }
        private string adminCode { get; set; }
        private int RoleId { get; set; }
        private int isPageValidated { get; set; }
        public int isPlantLocked { get; set; }
        private string SelectedPlantName { get; set; }
        private int IsUpdateCall { get; set; }
        private int RowNumber { get; set; }
        private bool isPlantPanelSelection { get; set; }
        public bool IsDailyDashboardLoaded { get; set; }
        public bool IsMonthlyDashboardLoaded { get; set; }

        public EventHandler<int> updateCalendarEvent;
        public EventHandler<int> updateworkDaysEvent;
        #endregion

        #region Enums
        public enum PlantName
        {
            None,
            PSSP,
            GSSP
        }

        public enum TimeUnit
        {
            None,
            Hours
        }
        public enum MinutesUnit
        {
            None,
            Minutes
        }
        public enum ElectricityUnit
        {
            None,
            Units

        }
        public enum CoalUnit
        {
            None,
            Kg,
            Tonne,
            MetricTonne

        }
        public enum UnitCmb
        {
            None,
            Kg,
            tonne,
            metrictonne,
            Add
        }
        #endregion
        private void AddMessage()
        {
            try
            {
                MessasgeAP.Add("Record Saved Successfully");
                MessasgeAP.Add("Record Updated Successfully");
                MessasgeAP.Add("Submitted for Approval");
                MessasgeAP.Add("Approved & Closed");
                MessasgeAP.Add("Oops something went Wrong!.");
                MessasgeAP.Add("Submitted & closed");
                MessasgeAP.Add("Please upload an Image!.");
                MessasgeAP.Add("User Assigned Successfully.");
                MessasgeAP.Add("Request Rejected Successfully!.");
                MessasgeAP.Add("Request Closed Successfully!.");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateReport()
        {
            try
            {
                if (isPageLoaded == 1)
                {
                    string RptNo = string.Empty;
                    string[] appArr = new string[] { };
                    if (isPageLoaded == 1)
                    {
                    }
                    if (isPageLoaded == 0)
                    {

                    }

                    ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "ProductionMasterTab")
                        if (ProdMasterpages.SelectedIndex==6)
                        {
                        string ProdNo = Resources.Instance.GetIncidentReportNo_RMPCL("SP_GetProductNo").ToString();
                        if (!string.IsNullOrEmpty(ProdNo))
                        {
                            appArr = ProdNo.Split('/');
                            ProdNo = Convert.ToString(Convert.ToInt32(appArr[2]) + 1);
                            RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + ProdNo;
                            lblProdNo.Text = RptNo;
                        }
                        else
                        {
                            RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + 1001;
                            lblProdNo.Text = RptNo;
                        }
                    }
                    ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "tabMonthlyProd")
                        if (ProdMasterpages.SelectedIndex==5)
                        {
                        string ProdNo = Resources.Instance.GetIncidentReportNo_RMPCL("SP_GetProductTargetCode").ToString();
                        if (!string.IsNullOrEmpty(ProdNo))
                        {
                            appArr = ProdNo.Split('/');
                            ProdNo = Convert.ToString(Convert.ToInt32(appArr[2]) + 1);
                            RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + ProdNo;
                            lblProdNoMon.Text = RptNo;
                            DProdCode = RptNo;
                        }
                        else
                        {
                            RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + 1001;
                            lblProdNoMon.Text = RptNo;
                        }
                        //ControlSet();
                    }
                    ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "tabDailyProd")
                        if (ProdMasterpages.SelectedIndex==1)
                        {
                        string ProdNo = Resources.Instance.GetIncidentReportNo_RMPCL("SP_GetProductDProdCode").ToString();
                        if (!string.IsNullOrEmpty(ProdNo))
                        {
                            appArr = ProdNo.Split('/');
                            ProdNo = Convert.ToString(Convert.ToInt32(appArr[2]) + 1);
                            RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + ProdNo;
                            lblDprodCode.Text = RptNo;
                            lblDprodCode.Visible = true;
                            DProdCode = RptNo;
                        }
                        else
                        {
                            RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + 1001;
                            lblDprodCode.Text = RptNo;
                        }
                    }

                    ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "tabConsumption")
                     if (ProdMasterpages.SelectedIndex==0)
                    {
                        string ProdNo = Resources.Instance.GetIncidentReportNo_RMPCL("SP_GetProductConsumeCode").ToString();
                        if (!string.IsNullOrEmpty(ProdNo))
                        {
                            appArr = ProdNo.Split('/');
                            ProdNo = Convert.ToString(Convert.ToInt32(appArr[2]) + 1);
                            RptNo = "CON" + "/" + DateTime.Now.Year + "/" + ProdNo;
                            lblConsumCode.Text = RptNo;
                            DProdCode = RptNo;
                        }
                        else
                        {
                            RptNo = "CON" + "/" + DateTime.Now.Year + "/" + 1001;
                            lblConsumCode.Text = RptNo;
                        }
                    }
                    ////ProdMasterpages.SelectedIndex = 5;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAdminCode()
        {
            try
            {
                adminCode = GlobalDeclaration._holdInfo[0].EmpCode;
                
                RoleId = Resources.Instance.MapAdminRole_RMPCL(adminCode);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddComboValues()
        {
            try
            {
                cmbPlantName.DataSource = Enum.GetValues(typeof(PlantName));
                cmbPlantNameD.DataSource = Enum.GetValues(typeof(PlantName));
                cmbPUnit.DataSource = Enum.GetValues(typeof(TimeUnit));
                cmbMaintUnit.DataSource = Enum.GetValues(typeof(TimeUnit));
                cmbRunningUnit.DataSource = Enum.GetValues(typeof(TimeUnit));
                cmbElecUnitConsump1.DataSource = Enum.GetValues(typeof(ElectricityUnit));
                cmbPlantNameConsum.DataSource = Enum.GetValues(typeof(PlantName));
                cmbPlantNameMon.DataSource = Enum.GetValues(typeof(PlantName));
                cmbPlantNameD.DataSource = Enum.GetValues(typeof(PlantName));
                cmbCoalUnit.DataSource = Enum.GetValues(typeof(CoalUnit));
                unitMasterDT = new DataTable();
                unitMasterDT = prodMaster.GetUnitMaster("", 2);
                for (int m = 0; m < unitMasterDT.Rows.Count; m++)
                {
                    cmbmonTargetMon.Items.Add(unitMasterDT.Rows[m][1]);
                    cmbclosingtargetMon.Items.Add(unitMasterDT.Rows[m][1]);
                    cmbdailytargetMon.Items.Add(unitMasterDT.Rows[m][1]);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProductPage();
                ////ValidateProductPage();
                issavedClicked = 1;
                if (btnSave.Text == "Update")
                {

                }
                else
                {
                    ValidateProdCode();
                }

                if (isPageValidated == 1)
                {
                    ObjectToClassMapper();
                }

                if (isPageValidated == 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "The Page contains Validation Error. Please validate & continue!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProdCode.Focus();
                }
                GenerateReport();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ControlSet()
        {
            try
            {
                txtnoWorkDaysMon.Text = GlobalDeclaration.dayList;
                txttotalWorkdaysMon.Text = GlobalDeclaration.dayCount.ToString();
                ProdMasterpages.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidateProdCode()
        {
            try
            {
                if (txtProdCode.Text != "")
                {
                    ProdCodeDT = DalService.GetProductCode();
                    DataRow[] filteredRows = ProdCodeDT.Select("ProdCode = '" + txtProdCode.Text + "'");
                    if (filteredRows.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(txtProdCode.Text))
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Product Code already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtProdCode.Focus();
                        }
                        isPageValidated = 0;
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form
                {
                    TopMost = true,
                    StartPosition = FormStartPosition.CenterScreen
                }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObjectToDALMApperProductMaster()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    retVal = prodMaster.SetProductDetails(prodMaster, 1);
                }
                else
                {
                    retVal = prodMaster.SetProductDetails(prodMaster, 3);
                }
                ResetControls();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }
        private void ObjectToClassMapper()
        {
            try
            {
                prodMaster.ProdName = txtProdName.Text;
                prodMaster.ProdCode = txtProdCode.Text;
                prodMaster.PlantName = cmbPlantName.Text;
                prodMaster.UniqCode = lblProdNo.Text;
                prodMaster.DateAdded = Convert.ToDateTime(lblDatetime.Text);
                prodMaster.CreatedBy = adminCode;
                prodMaster.RoleId = RoleId;
                prodMaster.IsActive = 1;
                prodMaster.DeactivatedFrom = DateTime.Now;
                prodMaster.DeactivatedTo = DateTime.Now;
                // int m = DalService.AddNearMissUAUCRequestor(nearMiss);
                AddMessage();
                int m = ObjectToDALMApperProductMaster();
                if (m > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[0], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                getProductDetails();
                btnSave.Text = "Save";

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getProductDetails()
        {
            try
            {
                prodData = Resources.Instance.GetProductMaster_RMPCL("", "", "", DateTime.Now, "", "", 0, 4, 1, DateTime.Now, DateTime.Now);
                if (prodData.Rows.Count > 0)
                {
                    DGVProdGrid.DataSource = prodData;
                    //this.DGVProdGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    this.DGVProdGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    this.DGVProdGrid.Size = new System.Drawing.Size(1459, 414);
                    DGVProdGrid.Columns["ProdId"].Visible = false;
                    DGVProdGrid.Columns["IsActive"].Visible = false;
                    DGVProdGrid.Columns["DeActivatedFrom"].Visible = false;
                    DGVProdGrid.Columns["DeActivatedTo"].Visible = false;

                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getAllProductDetails()
        {
            try
            {
                prodData = Resources.Instance.GetProductMaster_RMPCL("", "", "", DateTime.Now, "", "", 0, 2, 1, DateTime.Now, DateTime.Now);
                if (prodData.Rows.Count > 0)
                {
                    DGVProdGrid.DataSource = prodData;
                    //this.DGVProdGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    this.DGVProdGrid.Size = new System.Drawing.Size(1459, 414);

                }
                DGVProdGrid.Columns["ProdId"].Visible = false;
                // DGVProdGrid.Columns["RoleId"].Visible = false;
                //  DGVProdGrid.Columns["ProdId"].Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int ObjectToDALMApperDailyProduction()
        {
            try
            {
                if (IsUpdateCall == 1)
                {
                    if (btnAdd.Text == "Update")
                    {
                        retVal = DailyProd.SetDailyProduction(DailyProd, 3);
                        btnAdd.Text = "Add";
                    }
                }
                else
                {
                    if (btnSave.Text == "Save")
                    {
                        retVal = DailyProd.SetDailyProduction(DailyProd, 1);
                        DataTable dts1 = new DataTable();
                        dts1 = DailyTmpTbl.GetDailyProductionTempTbl("", "", "", "", 0, 0, 0, 0, 0, "", 0, DateTime.Now, DateTime.Now, DateTime.Now, "", "", 2);
                        if (dts1.Rows.Count > 0)
                        {
                            retVal = DailyTmpTbl.SetDailyProduction(DailyTmpTbl, 3);
                        }
                    }

                    if (btnSave.Text != "Save")
                    {
                        retVal = DailyProd.SetDailyProduction(DailyProd, 2);
                    }
                }
                // IsUpdateCall = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }

        private int ObjectToDALMApperDailyConsumption()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    retVal = DalService.AddDailyConsumption(dailyConsum, 1);
                }
                else
                {
                    retVal = DalService.AddDailyConsumption(dailyConsum, 2);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }

        private int ObjectToDALMApperMonthlyProduction()
        {
            try
            {
                if (isNewRecord == 0)
                {
                    if (SearchProdDt.Rows.Count > 0)
                    {
                        DataRow[] filteredRows = SearchProdDt.Select("PlantName = '" + cmbPlantNameMon.Text + "' and TargetYear = '" + DateTime.Now.Year + "' and TargetMonth = '" + DateTime.Now.Month + "' and ProdName = '" + cmbProdNameMon.Text + "'");
                        if (filteredRows.Length > 0)
                        {
                            string workdays = txtnoWorkDaysMon.Text; //filteredRows[0]["DaysWorked"].ToString();
                            decimal updatarget = Convert.ToDecimal(filteredRows[0]["MonthlyTarget"]) + Convert.ToDecimal(txtmonthlyTgtMon.Text);
                            decimal dailytarget = Convert.ToDecimal(filteredRows[0]["DailyTarget"]);

                            string[] worklist = new string[] { };
                            worklist = txtnoWorkDaysMon.Text.Split(',');
                            for (int m = 0; m < worklist.Length; m++)
                            {
                                if (!workdays.Contains(worklist[m]))
                                {
                                    workdays = workdays + ',' + worklist[m];
                                }
                            }
                            //updatarget = updatarget ;
                            int WorkDaysCount = workdays.Split(',').Length;
                            dailytarget = Convert.ToDecimal(updatarget / WorkDaysCount);
                            monthProd.DaysWorked = workdays;
                            monthProd.MonthlyTarget = updatarget;
                            monthProd.DailyTarget = dailytarget;
                            retVal = monthProd.SetMonthlyProduction(monthProd, 4);
                        }
                        else
                        {
                            retVal = monthProd.SetMonthlyProduction(monthProd, 1);
                        }
                    }
                    else
                    {
                        retVal = monthProd.SetMonthlyProduction(monthProd, 1);
                    }


                }

                if (isNewRecord == 1)
                {
                    if (btnSaveMonthly.Text != "Save")
                    {
                        retVal = monthProd.SetMonthlyProduction(monthProd, 2);
                    }
                    else
                    {
                        retVal = monthProd.SetMonthlyProduction(monthProd, 1);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }
        private void btnSubmitClose_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectToClassMapper();
                // ResetControls();
                this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControler(int empRoleId)
        {
            try
            {
                btnMonthProdTrgt.Visible = true;
                btnConsumptionDetails.Visible = true;
                btnProductMaster.Visible = true;
                btnDailyProd.Visible = true;
                btnMonthProdReport.Visible = true;
                btnDailyProdReport.Visible = true;

                switch (empRoleId)
                {
                    case 1:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabDailyProd);
                            tabDailyProd.Hide();
                            btnDailyProd.Visible = false;
                            btnConsumptionDetails.Visible = true;
                            break;
                        }
                    case 7:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabDailyProd);
                            tabDailyProd.Hide();
                            tabConsumption.Hide();
                            btnDailyProd.Visible = false;
                            btnConsumptionDetails.Visible = false;
                            tabProdMaster.Show();
                            tabMonthlyProdTrgt.Show();
                            tabDailyProdReport.Show();
                            tabMonthlyProdReport.Show();
                            btnDailyProdReport.Location = btnDailyProd.Location;// new Point(427, 5);
                            btnMonthProdReport.Location = btnConsumptionDetails.Location;// new Point(631, 5);
                            break;
                        }

                    case 3:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabDailyProd);
                            ////ProdMasterpages.TabPages.Remove(tabConsumption);
                            ////ProdMasterpages.TabPages.Remove(ProductionMasterTab);
                            ////ProdMasterpages.TabPages.Remove(tabMonthlyProd);
                            tabProdMaster.Hide();
                            tabDailyProd.Hide();
                            tabConsumption.Hide();
                            
                            
                            btnProductMaster.Visible = false;
                            btnDailyProd.Visible = false;
                            btnConsumptionDetails.Visible = false;
                            btnMonthProdTrgt.Visible = false;
                            
                            tabMonthlyProdReport.Show();
                            tabDailyProdReport.Show();
                            btnDailyProdReport.Location = btnProductMaster.Location;
                            btnMonthProdReport.Location = btnMonthProdTrgt.Location;
                            ProdMasterpages.SelectedIndex = 4;
                            break;
                        }
                    case 4:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabMonthlyProd);
                            ////ProdMasterpages.TabPages.Remove(tabConsumption);
                            ////ProdMasterpages.TabPages.Remove(ProductionMasterTab);
                            tabMonthlyProdTrgt.Hide();
                            tabConsumption.Hide();
                            tabProdMaster.Hide();
                            btnMonthProdTrgt.Visible = false;
                            btnConsumptionDetails.Visible = false;
                            btnProductMaster.Visible = false;

                            tabDailyProd.Show();
                            tabMonthlyProdReport.Show();
                            tabDailyProdReport.Show();

                            btnMonthProdReport.Location = btnDailyProd.Location;
                            btnDailyProd.Location = btnProductMaster.Location;
                            btnDailyProdReport.Location = btnMonthProdTrgt.Location;

                            //btnDailyProd.Location= btnMonthProd.Location;
                            //btnMonthProdReport.Location = btnDailyProdReport.Location;
                            //btnDailyProdReport.Location = btnConsumptionDetails.Location;
                            ProdMasterpages.SelectedIndex = 2;
                            break;
                        }
                    case 5:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabMonthlyProd);
                            ////ProdMasterpages.TabPages.Remove(tabConsumption);
                            ////ProdMasterpages.TabPages.Remove(ProductionMasterTab);
                            ////ProdMasterpages.TabPages.Remove(tabDailyProd);
                            tabMonthlyProdTrgt.Hide();
                            tabConsumption.Hide();
                            tabProdMaster.Hide();
                            tabDailyProd.Hide();
                            btnMonthProdTrgt.Visible = false;
                            btnConsumptionDetails.Visible = false;
                            btnProductMaster.Visible = false;
                            btnDailyProd.Visible = false;
                            break;
                        }
                    case 2:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabMonthlyProd);
                            ////ProdMasterpages.TabPages.Remove(tabConsumption);
                            ////ProdMasterpages.TabPages.Remove(ProductionMasterTab);
                            ////ProdMasterpages.TabPages.Remove(tabDailyProd);
                            tabMonthlyProdTrgt.Hide();
                            tabConsumption.Hide();
                            tabProdMaster.Hide();
                            tabDailyProd.Hide();
                            btnMonthProdTrgt.Visible = false;
                            btnConsumptionDetails.Visible = false;
                            btnProductMaster.Visible = false;
                            btnDailyProd.Visible = false;
                            break;
                        }
                    case 8:
                        {
                            ////ProdMasterpages.TabPages.Remove(tabMonthlyProd);
                            ////ProdMasterpages.TabPages.Remove(tabConsumption);
                            ////ProdMasterpages.TabPages.Remove(ProductionMasterTab);
                            ////ProdMasterpages.TabPages.Remove(tabDailyProd);
                            tabMonthlyProdTrgt.Hide();
                            tabConsumption.Hide();
                            tabProdMaster.Hide();
                            tabDailyProd.Hide();
                            btnMonthProdTrgt.Visible = false;
                            btnConsumptionDetails.Visible = false;
                            btnProductMaster.Visible = false;
                            btnDailyProd.Visible = false;
                            break;
                        }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ProductDetails_Load(object sender, EventArgs e)
        {
            pnlPlantSelection.Visible = false;
            HideProdMasterpagesHeader();
            try
            {
                empRoleId = Resources.Instance.MapAdminRole_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode.ToString());
                isPageLoaded = 1;
                TabControler(empRoleId);


                GetAdminCode();
                if (ProdMasterpages.SelectedTab.Tag.ToString() == "ProductionMasterTab")
                {
                    lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    //prodData = prodMaster.GetProductDetails();
                    //DGVProdGrid.DataSource = prodData;
                }
                lblEmpNameD.Text = GlobalDeclaration._holdInfo[0].UserName;
                GenerateReport();
                AddComboValues();
                dailyProduction = new DataTable();
                dailMastrBck = new DataTable();
                DGVRowDT = new DataTable();
                GridBck = new DataTable();
                AddColumnsDT();
                cmbProdNameD.Items.Clear();
                lblDlDate.Text = DateTime.Now.ToString();
                ProdMasterpages.Controls.Remove(tabConsumption);
                //lblPlantGSSP.Text = PlantName.GSSP.ToString();
                //lblPlantPSSP.Text = PlantName.PSSP.ToString();
                lblDailyPrdRPT.Text = DateTime.Now.ToString();
                lblMonthTraget.Text = DateTime.Now.ToString();
                cmbMonthlyPname.DataSource = Enum.GetValues(typeof(PlantName));
                lblMonthlyDate.Text = DateTime.Now.ToString();
                InitCmbHours();
                if (empRoleId == 1 || empRoleId == 7)
                {
                    getProductDetails();
                    getMonthlyProductionData();
                }
                timerTicker.Enabled = true;
                dtpProdDateD.Value = DateTime.Today.AddDays(-1);
                GetProductCode();
                isNewRecord = 0;
                // txtnoWorkDaysMon.Enabled = true;
                DataTable tds = new DataTable();
                tds = DalService.GetProductionCalendar("", DateTime.Now.Year, "", 1);
                int monthCal = tds.Rows.Count;
                int CAlMonth = Convert.ToInt32(tds.Rows[monthCal - 1][1]);
                if (DynamicPrpty == 0)
                {
                    txttotalWorkdaysMon.Text = tds.Rows[0][3].ToString();
                    DynamicPrpty = Convert.ToInt32(txttotalWorkdaysMon.Text);
                }
                var countryIDs = tds.AsEnumerable().Where(row => row.Field<string>("MonthName") == DateTime.Now.Month.ToString()).FirstOrDefault();
                //if (countryIDs != null)
                //{
                //    txtProdCodeD.Text = countryIDs[1].ToString();
                //}
                if (DynamicPrpty != 0 && countryIDs!=null && countryIDs[1].ToString() != "")
                {
                    //txttotalWorkdaysMon.Text = DynamicPrpty.ToString();
                    txttotalWorkdaysMon.Text = countryIDs[3].ToString();
                }
                GlobalDeclaration.dayCount = int.Parse(txttotalWorkdaysMon.Text);
                //txttotalWorkdaysMon.Text = GlobalDeclaration.dayCount.ToString();
                txtnoWorkDaysMon.Enabled = false;
                ProdData = prodMaster.GetDailyProductProduced(DateTime.Now);

                //ProductDetails conDetails = new ProductDetails();
                //conDetails.updateworkDaysEvent += RedirectTabControl;

                // sft.updateCalendarEvent += setTextValue;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetProductCode()
        {
            try
            {
                ProdCodeDT = new DataTable();
                ProdCodeDT = DalService.GetProductCode();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidateConsumptionPage()
        {
            if (cmbPlantNameConsum.SelectedIndex == 0)
            {
                cmbPlantNameConsum.Focus();
                isPageValidated = 0;
                lblConErr.Visible = true;
            }
            else
            {
                isPageValidated = 1;
                lblConErr.Visible = false;
            }

            if (txtTotalElectricity.Text == "")
            {
                lblElecErr.Visible = true;
                isPageValidated = 0;
                txtTotalElectricity.Focus();
            }
            else
            {
                lblElecErr.Visible = false;
                isPageValidated = 1;
            }

            if ((cmbPlantNameConsum.SelectedIndex != 0) && (txtTotalElectricity.Text != ""))
            {
                isPageValidated = 1;
            }
            else
            {
                isPageValidated = 0;
            }
        }


        private void ValidateProductPage()
        {
            
            if ((txtProdCode.Text.Length == 0) || (txtProdCode.Text == "") || string.IsNullOrEmpty(txtProdCode.Text))
            {
                txtProdCode.Focus();
                lblProdCode.Visible = true;
                isPageValidated = 0;
            }
            else
            {
                isPageValidated = 1;
                lblProdCode.Visible = false;
            }
            if ((txtProdName.Text.Length == 0) || (txtProdName.Text == "") || string.IsNullOrEmpty(txtProdName.Text))
            {
                txtProdName.Focus();
                lblProdName.Visible = true;
                isPageValidated = 0;
            }
            else
            {
                isPageValidated = 1;
                lblProdName.Visible = false;
            }

            if (cmbPlantName.SelectedIndex == 0 || string.IsNullOrEmpty(cmbPlantName.Text))
            {
                cmbPlantName.Focus();
                lblPlantMaster.Visible = true;
                isPageValidated = 0;
            }
            else
            {
                isPageValidated = 1;
                lblPlantMaster.Visible = false;
            }

            if ((txtProdCode.Text.Length > 0) && (txtProdName.Text.Length > 0) && (cmbPlantName.SelectedIndex != 0) && (isPrdMasterValid = true))// && (isProdName == true))
            {
                isPageValidated = 1;
            }
            else
            {
                isPageValidated = 0;
                //eps.SetError(txtProdCode, null);
                //eps.SetError(txtProdName, null);
                //eps.SetError(cmbPlantName, null);
            }

        }

        private void ValidateMonthlyPage()
        {
            if ((cmbPlantNameMon.Text.Length == 0) || (cmbPlantNameMon.Text == "None"))
            {
                cmbPlantNameMon.Focus();
                lblPlantNAmeMon.Visible = true;
                isPageValidated = 0;
            }
            else
            {
                lblPlantNAmeMon.Visible = false;
                isPageValidated = 1;
            }
            if (cmbProdNameMon.SelectedIndex == 0)
            {
                cmbProdNameMon.Focus();
                lblProMon.Visible = true;
                isPageValidated = 0;

            }
            else
            {
                lblProMon.Visible = false;
                isPageValidated = 1;
            }

            if (txtmonthlyTgtMon.Text.Length == 0)
            {
                txtmonthlyTgtMon.Focus();
                isPageValidated = 0;
                lblTargetMon.Visible = true;
            }
            else
            {
                isPageValidated = 1;
                lblTargetMon.Visible = false;
            }

            if (txttotalWorkdaysMon.Text.Length == 0)
            {
                txttotalWorkdaysMon.Focus();
                lblWorkdays.Visible = true;
                isPageValidated = 0;
            }
            else
            {
                lblWorkdays.Visible = false;
                isPageValidated = 1;
            }

            if (((cmbPlantNameMon.Text != "None")) && (cmbPlantNameMon.Text.Length > 0) && (txtprodcodeMon.Text.Length > 0) && (txtmonthlyTgtMon.Text.Length > 0) && (cmbmonTargetMon.Text != ""))
            {
                isPageValidated = 1;
            }
            else
            {
                isPageValidated = 0;
            }
        }
        private void InitCmbHours()
        {
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    CmbPHours.Items.Add(i);
                    cmbMHours.Items.Add(i);
                    cmbTotRunhrs.Items.Add(i);
                }
                for (int j = 0; j < 60; j++)
                {
                    cmbPMinutes.Items.Add(j);
                    cmbMaintMinute.Items.Add(j);
                    cmbTotRunMint.Items.Add(j);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVProdGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if(DGVProdGrid.Rows[0].Cells[0].Value.ToString()=="Edit")
                //  {
                //      return;
                //  }
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    txtProdCode.Text = DGVProdGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtProdName.Text = DGVProdGrid.Rows[e.RowIndex].Cells["ProdName"].Value.ToString();
                    lblProdNo.Text = DGVProdGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                    cmbPlantName.Text = DGVProdGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetControls()
        {
            txtProdCode.Text = "";
            txtProdName.Text = "";
            cmbPlantName.Text = "";
            btnSave.Text = "Save";
            cmbPlantName.SelectedIndex = 0;
            lblPlantMaster.Visible = false;
            lblProdCode.Visible = false;
            lblProdName.Visible = false;

        }

        private void cmbProdNameD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var countryIDs = prodData.AsEnumerable().Where(row => row.Field<String>("ProdName") == cmbProdNameD.Text).FirstOrDefault();
                if (countryIDs != null)
                {
                    txtProdCodeD.Text = countryIDs[2].ToString();
                }
                List<string> itList = new List<string>();
                itList = Resources.Instance.GetProductClosingStock_RMPCL(txtProdCodeD.Text);
                if (itList.Count > 0)
                {
                    txtOpenStockD.Text = itList[0].ToString();
                    txtDailyProdD.Text = itList[1].ToString();
                    cmbDailyProdD.Items.Add(itList[2].ToString());
                    cmbDailyProdD.Text = itList[2].ToString();
                }
                else
                {
                    txtOpenStockD.Text = "0";
                }
                unitMasterDT = new DataTable();
                unitMasterDT = Resources.Instance.GetUnitMaster_RMPCL("", 2);

                cmbActualProdD.Items.Clear();
                cmbProdDispatchedD.Items.Clear();
                cmbClosingStockD.Items.Clear();
                cmbActualProdD.Items.Clear();
                for (int m = 0; m < unitMasterDT.Rows.Count; m++)
                {
                    cmbActualProdD.Items.Add(unitMasterDT.Rows[m][1]);
                    cmbProdDispatchedD.Items.Add(unitMasterDT.Rows[m][1]);
                    cmbClosingStockD.Items.Add(unitMasterDT.Rows[m][1]);
                    if (itList.Count > 0)
                    {
                        cmbActualProdD.Text = itList[2].ToString();
                        cmbProdDispatchedD.Text = itList[2].ToString();
                        cmbClosingStockD.Text = itList[2].ToString();
                    }
                }
                cmbActualProdD.Enabled = false;
                cmbProdDispatchedD.Enabled = false;
                cmbClosingStockD.Enabled = false;
                cmbActualProdD.Enabled = false;

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlantNameD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                prodData = prodMaster.GetProductDataPlantWise(cmbPlantNameD.Text, "", "", DateTime.Now, "", "", 0, 6, 1, DateTime.Now, DateTime.Now);
                cmbProdNameD.Items.Clear();
                // SelectedPlantName = cmbPlantNameD.Text;
                if (cmbPlantNameD.Text == "None")
                {
                    cmbProdNameD.Items.Clear();
                }
                else
                {
                    //cmbProdNameMon.Items.Add("");
                    for (int n = 0; n < prodData.Rows.Count; n++)
                    {
                        cmbProdNameD.Items.Add(prodData.Rows[n][4]);
                    }
                }
                txtOpenStockD.Text = "";
                txtDailyProdD.Text = "";
                txtProdCodeD.Text = "";
                //cmbPlantNameD.Enabled = false;
                //if (DGVDailyProduction.Rows.Count > 0)
                //{
                //    if (DGVDailyProduction.Rows[0].Cells[4].Value.ToString() != cmbPlantNameD.Text)
                //    {
                //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please complete the consumption cycle!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        cmbPlantNameD.Text = ;
                //        cmbPlantNameD.Enabled = false;
                //    }
                // }
                // cmbDailyProdD.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ValidateDailyPage()
        {
            try
            {
                if (string.IsNullOrEmpty(cmbPlantNameD.Text))
                {
                    cmbPlantNameD.Focus();
                    lblPlantDErr.Visible = true;
                    isPageValidated = 0;
                }
                else
                {
                    lblPlantDErr.Visible = false;
                    isPageValidated = 1;
                }


                if (string.IsNullOrEmpty(cmbProdNameD.Text))
                {
                    cmbProdNameD.Focus();
                    lblProdDErr.Visible = true;
                    isPageValidated = 0;
                }
                else
                {
                    lblProdDErr.Visible = false;
                    isPageValidated = 1;
                }

                if (txtActualProdD.Text.Length == 0)
                {
                    txtActualProdD.Focus();
                    lblActProdDErr.Visible = true;
                    isPageValidated = 0;
                }
                else
                {
                    lblActProdDErr.Visible = false;
                    isPageValidated = 1;
                }

                if (!string.IsNullOrEmpty(cmbPlantNameD.Text) && (txtActualProdD.Text.Length > 0) && (!string.IsNullOrEmpty(cmbProdNameD.Text)))
                {
                    isPageValidated = 1;
                }
                else
                {
                    isPageValidated = 0;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getDailyProductionData()
        {
            try
            {
                DailyDataPSSP = new DataTable();
                DailyDataPSSP = DalService.GetDailyProduction(lblDprodCode.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateDailyPage();
                if (isPageValidated == 1)
                {

                    if (btnAdd.Text == "Update")
                    {
                        // ObjectToDALMApperDailyProduction();
                        IsUpdateCall = 1;
                        // ObjectToClassDailyProduction();

                        RowCounter = RowCounter + 1;
                        AddRowsDT();
                        btnAdd.Text = "Add";
                        //  getDailyProductionData();
                    }
                    else
                    {
                        //RowCounter = 0;
                        if (Convert.ToDecimal(txtClosingStockD.Text) >= 0)
                        {
                            RowCounter = RowCounter + 1;
                            AddRowsDT();
                            cmbPlantNameD.Enabled = false;
                            ActualProduction = ActualProduction + Convert.ToDecimal(txtActualProdD.Text);
                            GlobalDeclaration.ProdUnit = cmbActualProdD.Text;
                            txtClosingStockD.Focus();
                            ResetAll();
                            // 
                        }
                        else
                        {
                            txtClosingStockD.Focus();
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Negative Stocking is not allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    dts1 = DailyTmpTbl.GetDailyProductionTempTbl("", "", "", "", 0, 0, 0, 0, 0, "", 0, DateTime.Now, DateTime.Now, DateTime.Now, "", "", 2);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumnsDT()
        {

            dailyProduction.Columns.Add("Sl No.");
            dailyProduction.Columns.Add("Daily Prod Code");
            dailyProduction.Columns.Add("Plant Name");
            dailyProduction.Columns.Add("Product Name (Unit)");
            dailyProduction.Columns.Add("Opening Stock (Unit)");
            dailyProduction.Columns.Add("Daily Production Target");
            dailyProduction.Columns.Add("Actual Production");
            dailyProduction.Columns.Add("Product Dispatched");
            dailyProduction.Columns.Add("Closing Stock");


            dailMastrBck.Columns.Add("Sl No.");
            dailMastrBck.Columns.Add("Daily Prod Code");
            dailMastrBck.Columns.Add("Plant Name");
            dailMastrBck.Columns.Add("Product Name");
            dailMastrBck.Columns.Add("Product Code");
            dailMastrBck.Columns.Add("Opening Stock");
            dailMastrBck.Columns.Add("Daily Production Target");
            dailMastrBck.Columns.Add("Actual Production");
            dailMastrBck.Columns.Add("Product Dispatched");
            dailMastrBck.Columns.Add("Closing Stock");
            dailMastrBck.Columns.Add("Filled By");
            dailMastrBck.Columns.Add("Role");
            dailMastrBck.Columns.Add("Created Date");
            dailMastrBck.Columns.Add("Data Uploaded For");
            dailMastrBck.Columns.Add("Actual Production Unit");
            dailMastrBck.Columns.Add("Dispatched Unit");

            GridBck.Columns.Add("Sl No.");
            GridBck.Columns.Add("Daily Prod Code");
            GridBck.Columns.Add("Plant Name");
            GridBck.Columns.Add("Product Name");
            GridBck.Columns.Add("Product Code");
            GridBck.Columns.Add("Opening Stock");
            GridBck.Columns.Add("Daily Production Target");
            GridBck.Columns.Add("Actual Production");
            GridBck.Columns.Add("Product Dispatched");
            GridBck.Columns.Add("Closing Stock");
            GridBck.Columns.Add("Filled By");
            GridBck.Columns.Add("Role");
            GridBck.Columns.Add("Created Date");
            GridBck.Columns.Add("Data Uploaded For");
            GridBck.Columns.Add("Actual Production Unit");
            GridBck.Columns.Add("Dispatched Unit");
        }



        private void AddRowsDT()
        {
            // dailMastrBck.Rows.Clear();
            // GridBck = new DataTable();
            DataRow drRows = dailMastrBck.NewRow();
            drRows[0] = RowCounter;
            drRows[1] = lblDprodCode.Text;
            drRows[2] = cmbPlantNameD.Text;
            drRows[3] = cmbProdNameD.Text;
            drRows[4] = txtProdCodeD.Text;
            drRows[5] = txtOpenStockD.Text;
            drRows[6] = txtDailyProdD.Text;
            drRows[7] = txtActualProdD.Text;
            drRows[8] = txtProdDispatchedD.Text;
            drRows[9] = txtClosingStockD.Text;
            drRows[10] = GlobalDeclaration._holdInfo[0].EmpCode;
            drRows[11] = RoleId;
            drRows[12] = DateTime.Now;
            drRows[13] = dtpProdDateD.Text;
            drRows[14] = cmbActualProdD.Text;
            drRows[15] = cmbProdDispatchedD.Text;

            // dailMastrBck = GridBck.Clone();
            dailMastrBck.Rows.Add(drRows);
            // GridBck= dailMastrBck.Clone();
            if (RowNumber >= 0 && btnAdd.Text == "Update")
            {
                this.DGVDailyProduction.Rows.RemoveAt(RowNumber);
            }
            for (int m = 0; m < DGVDailyProduction.Rows.Count; m++)
            {
                string prodname = DGVDailyProduction.Rows[m].Cells[5].Value.ToString();
                decimal production = 0;
                decimal dispatched = 0;
                if (prodname == cmbProdNameD.Text)
                {
                    production = Convert.ToDecimal(DGVDailyProduction.Rows[m].Cells[9].Value);
                    production = production + Convert.ToDecimal(txtActualProdD.Text);
                    dispatched = Convert.ToDecimal(DGVDailyProduction.Rows[m].Cells[10].Value);
                    dispatched = dispatched + Convert.ToDecimal(txtProdDispatchedD.Text);
                    this.DGVDailyProduction.Rows.RemoveAt(m);
                    RowCounter = m;
                    drRows[0] = RowCounter + 1;
                    drRows[7] = production;
                    drRows[8] = dispatched;
                }
            }

            GridBck.Merge(dailMastrBck);
            DGVDailyProduction.DataSource = GridBck;
            this.DGVDailyProduction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dailMastrBck = GridBck.Clone();
            DGVDailyProduction.Columns["Role"].Visible = true;
            DGVDailyProduction.Columns["Created Date"].Visible = true;
            DGVDailyProduction.Columns["Data Uploaded For"].Visible = true;
            DGVDailyProduction.Columns["Actual Production Unit"].Visible = true;
            DGVDailyProduction.Columns["Dispatched Unit"].Visible = true;
        }

        private void txtActualProdD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //  lblTotalProduction.Text = txtActualProdD.Text;
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdDispatchedD_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResetAll()
        {
            cmbPlantNameD.Text = "";
            txtActualProdD.Text = "";
            txtClosingStockD.Text = "";
            txtDailyProdD.Text = "0";
            txtOpenStockD.Text = "";
            txtProdCodeD.Text = "";
            txtProdDispatchedD.Text = "0";
            cmbActualProdD.Text = "";
            cmbClosingStockD.Text = "";
            // cmbProdNameD.Items.Clear();
            //cmbActualProdD.Items.Clear();
        }


        public EventHandler<string> GenerateLabelRpt;

        /// <summary>
        /// /Not Mapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                ProdData = prodMaster.GetDailyProductProduced(DateTime.Now);
                IsEntriesDone = 0;
                if (ProdData.Rows.Count >= 0)
                {
                    for (int j = 0; j < ProdData.Rows.Count; j++)
                    {
                        for (int m = 0; m < DGVDailyProduction.Rows.Count; m++)
                        {
                            var countryIDs = ProdData.AsEnumerable().Where(row => row.Field<DateTime>("DateFilledFor") == Convert.ToDateTime(dtpProdDateD.Value) && row.Field<String>("ProdName") == DGVDailyProduction.Rows[m].Cells[5].Value.ToString()).FirstOrDefault();
                            if (countryIDs != null)
                            {
                                ProductName = countryIDs[5].ToString();
                            }
                        }
                    }
                    if ((ProductName) != null)
                    {
                        XtraMessageBox.Show("Entry for this Product" + " " + ProductName + " " + "already made", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        IsEntriesDone = 1;
                        ProductName = null;
                    }

                    if (DGVDailyProduction.Rows.Count > 0 && IsEntriesDone == 0)
                    {
                        //string message = "Are you sure you want to continue?";
                        //string title = "Items Removal Window";
                        //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        //DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                        //if (result == DialogResult.Yes)
                        //{
                        GlobalDeclaration.ProdCode = lblDprodCode.Text;
                        GlobalDeclaration.plantName = cmbPlantNameD.Text;
                        GlobalDeclaration.ProdUnit = DGVDailyProduction.Rows[0].Cells[17].Value.ToString();
                        IsUpdateCall = 0;
                        ObjectToClassDailyProduction();
                        GenerateReport();
                        RowCounter = 0;
                        //}
                        //else
                        //{
                        ObjectToClassDailyTmpTbl();
                        //  RowCounter = 0;
                        //}
                    }

                }
                else
                {
                    XtraMessageBox.Show("First fill Consumption Details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObjectToClassDailyProduction()
        {
            try
            {
                int m = 0;

                //int  lastRowIndex = 0;
                for (int k = 0; k < DGVDailyProduction.Rows.Count; k++)
                {
                    tabReload = true;
                    ConsumSaved = lblDprodCode.Text;
                    DailyProd.DProdCode = DGVDailyProduction.Rows[k].Cells[3].Value.ToString();
                    DailyProd.PlantName = DGVDailyProduction.Rows[k].Cells[4].Value.ToString();
                    DailyProd.ProdName = DGVDailyProduction.Rows[k].Cells[5].Value.ToString();
                    DailyProd.ProdCode = DGVDailyProduction.Rows[k].Cells[6].Value.ToString();
                    DailyProd.OpeningStock = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[7].Value);
                    DailyProd.DailyTarget = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[8].Value);
                    DailyProd.ActualProd = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[9].Value);
                    decimal prodDisp = 0;
                    if (DGVDailyProduction.Rows[k].Cells[10].Value.ToString() == "")
                    {
                        prodDisp = 0;
                    }
                    else
                    {
                        prodDisp = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[10].Value);
                    }
                    DailyProd.ProdDispatched = prodDisp;
                    DailyProd.ClosingStock = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells["Closing Stock"].Value);
                    DailyProd.EmpCode = DGVDailyProduction.Rows[k].Cells[12].Value.ToString();
                    DailyProd.RoleId = Convert.ToInt32(DGVDailyProduction.Rows[k].Cells[13].Value);
                    DailyProd.CreatedDate = Convert.ToDateTime(DGVDailyProduction.Rows[k].Cells[14].Value);
                    DailyProd.DateFilledFor = Convert.ToDateTime(DGVDailyProduction.Rows[k].Cells[15].Value);
                    DailyProd.UpdateDate = DateTime.Now;
                    DailyProd.ActualProdUnit = DGVDailyProduction.Rows[k].Cells[16].Value.ToString();
                    DailyProd.PrdoDispatchedUnit = DGVDailyProduction.Rows[k].Cells[17].Value.ToString();
                    // int m = DalService.AddNearMissUAUCRequestor(nearMiss);
                    AddMessage();
                    m = ObjectToDALMApperDailyProduction();
                    btnSave.Text = "Save";
                    GlobalDeclaration.TotalProduction = GlobalDeclaration.TotalProduction + DailyProd.ActualProd;
                    if (DGVDailyProduction.Rows.Count >= 0)
                    {
                        GlobalDeclaration.plantName = DGVDailyProduction.Rows[0].Cells[4].Value.ToString();
                    }
                    lblDateObj.Text = dtpProdDateD.Text;
                    //   lastRowIndex = k;
                    // k = lastRowIndex;
                }

                if (k == DGVDailyProduction.Rows.Count)
                {
                }
                if (m < 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (IsUpdateCall == 0)
                {
                    bunifuButton2.Enabled = false;
                    ProductConsumtion conDetails = new ProductConsumtion();
                    conDetails.RedirectToTabEvent += RedirectTabControl;
                    conDetails.Show();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObjectToClassDailyTmpTbl()
        {
            try
            {
                for (int k = 0; k < DGVDailyProduction.Rows.Count; k++)
                {
                    tabReload = true;
                    ConsumSaved = lblDprodCode.Text;
                    DailyTmpTbl.DProdCode = DGVDailyProduction.Rows[k].Cells[3].Value.ToString();
                    DailyTmpTbl.PlantName = DGVDailyProduction.Rows[k].Cells[4].Value.ToString();
                    DailyTmpTbl.ProdName = DGVDailyProduction.Rows[k].Cells[5].Value.ToString();
                    DailyTmpTbl.ProdCode = DGVDailyProduction.Rows[k].Cells[6].Value.ToString();
                    DailyTmpTbl.OpeningStock = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[7].Value);
                    DailyTmpTbl.DailyTarget = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[8].Value);
                    DailyTmpTbl.ActualProd = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[9].Value);
                    decimal prodDisp = 0;
                    if (DGVDailyProduction.Rows[k].Cells[10].Value.ToString() == "")
                    {
                        prodDisp = 0;
                    }
                    else
                    {
                        prodDisp = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[10].Value);
                    }
                    DailyTmpTbl.ProdDispatched = prodDisp;
                    DailyTmpTbl.ClosingStock = Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[11].Value);
                    DailyTmpTbl.EmpCode = DGVDailyProduction.Rows[k].Cells[12].Value.ToString();
                    DailyTmpTbl.RoleId = Convert.ToInt32(Convert.ToDecimal(DGVDailyProduction.Rows[k].Cells[13].Value));
                    DailyTmpTbl.CreatedDate = Convert.ToDateTime(DGVDailyProduction.Rows[k].Cells[14].Value);
                    DailyTmpTbl.DateFilledFor = Convert.ToDateTime(DGVDailyProduction.Rows[k].Cells[15].Value);
                    DailyTmpTbl.UpdateDate = DateTime.Now;
                    DailyTmpTbl.ActualProdUnit = DGVDailyProduction.Rows[k].Cells[16].Value.ToString();
                    DailyTmpTbl.PrdoDispatchedUnit = DGVDailyProduction.Rows[k].Cells[17].Value.ToString();
                    AddDailyProductionToTemp();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDailyProductionToTemp()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    retVal = DailyTmpTbl.SetDailyProduction(DailyTmpTbl, 1);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProdMasterpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "tabDailyProd")
                if(ProdMasterpages.SelectedIndex==1)
                {
                    //PnlDailyProd.Enabled = false;
                }

                ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "TabDailyProdReport" && (IsDailyDashboardLoaded == false))
                if (ProdMasterpages.SelectedIndex==3 && (IsDailyDashboardLoaded == false))
                {
                    LoadProductDashboard();
                    IsDailyDashboardLoaded = true;
                }
                ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "MonthlyReport" && (IsMonthlyDashboardLoaded == false))
                if (ProdMasterpages.SelectedIndex == 5 && (IsMonthlyDashboardLoaded == false))
                {
                    ExecuteThreadMonthlyProduction();
                    IsMonthlyDashboardLoaded = true;
                }
                GenerateReport();
                GlobalDeclaration.TotalProduction = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEPSErrorNull()
        {
            //   eps.Dispose();
        }
        private void DGVDailyProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    // ActualProduction = ActualProduction - Convert.ToDecimal(this.DGVDailyProduction.Rows[e.RowIndex].Cells[6].Value.ToString());
                    lblDprodCode.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cmbPlantName.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cmbProdNameD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtProdCodeD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtDailyProdD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[8].Value.ToString();
                    txtOpenStockD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtActualProdD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[9].Value.ToString();
                    txtProdDispatchedD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtClosingStockD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[11].Value.ToString();
                    cmbActualProdD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[13].Value.ToString();
                    cmbProdDispatchedD.Text = this.DGVDailyProduction.Rows[e.RowIndex].Cells[17].Value.ToString();
                    btnAdd.Text = "Update";
                    RowNumber = e.RowIndex;
                    RowCounter = e.RowIndex;
                }
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        RowCounter = DGVDailyProduction.Rows.Count;
                        IsEntriesDone = 0;
                        for (int m = 0; m < DGVDailyProduction.Rows.Count; m++)
                        {
                            DGVDailyProduction.Rows[e.RowIndex].Cells[2].Value = m + 1;
                            int n = DailyProd.DropDailyGridProductionTempData(DGVDailyProduction.Rows[e.RowIndex].Cells[6].Value.ToString(), DGVDailyProduction.Rows[e.RowIndex].Cells[4].Value.ToString());
                        }
                        this.DGVDailyProduction.Rows.RemoveAt(e.RowIndex);
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalElectricity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtElecRate.Text = Convert.ToString(Convert.ToDecimal(txtTotalElectricity.Text) / Convert.ToDecimal(lblTotalProduction.Text));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalCoal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCoalRate.Text = Convert.ToString(Convert.ToDecimal(txtTotalCoal.Text) / Convert.ToDecimal(lblTotalProduction.Text));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlantNameMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                prodData = prodMaster.GetProductDataPlantWise(cmbPlantNameMon.Text, "", "", DateTime.Now, "", "", 0, 6, 1, DateTime.Now, DateTime.Now);
                cmbProdNameMon.Items.Clear();
                txtprodcodeMon.Text = "";
                if (cmbPlantNameMon.Text == "None")
                {
                    cmbProdNameMon.Items.Clear();
                }
                else
                {
                    //cmbProdNameMon.Items.Add("");
                    for (int n = 0; n < prodData.Rows.Count; n++)
                    {
                        cmbProdNameMon.Items.Add(prodData.Rows[n][4]);
                    }
                }
                txtprodcodeMon.Text = "";
                //txtnoWorkDaysMon.Text = string.Empty;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProdNameMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var countryIDs = prodData.AsEnumerable().Where(row => row.Field<String>("ProdName") == cmbProdNameMon.Text).FirstOrDefault();
                if (countryIDs != null)
                {
                    txtprodcodeMon.Text = countryIDs["prodCode"].ToString();
                }
                //  txtnoWorkDaysMon.Text = string.Empty;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            try
            {
                //Operation.CalendarSelection sft = new Operation.CalendarSelection();
                //sft.updateCalendarEvent += setTextValue;
                //sft.Show();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void setTextValue(object sender, int value)
        {
            try
            {
                DataTable tds = new DataTable();
                tds = DalService.GetProductionCalendar("", DateTime.Now.Year, "", 1);

                var isExistCount = from row in tds.AsEnumerable()
                                   where row.Field<int>("MonthName") == Convert.ToInt32(DateTime.Now.Month)
                                   && row.Field<int>("CalendarYear") == Convert.ToInt32(DateTime.Now.Year)
                                   select row.Field<string>("WorkingDays");
                if (isExistCount.Any())
                    txttotalWorkdaysMon.Text = value.ToString();
                //txttotalWorkdaysMon.Text = GlobalDeclaration.dayCount.ToString();
                ProdMasterpages.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVMonthlyProduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    lblDatetime.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtclosingtgtMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtdailytgtMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtnoWorkDaysMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtmonthlyTgtMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[8].Value.ToString();
                    txtprodcodeMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[15].Value.ToString();
                    txttotalWorkdaysMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[10].Value.ToString();
                    cmbPlantNameMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[11].Value.ToString();
                    cmbProdNameMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[16].Value.ToString();
                    cmbclosingtargetMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbdailytargetMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbmonTargetMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells[2].Value.ToString();
                    lblProdNoMon.Text = DGVMonthlyProduction.Rows[e.RowIndex].Cells["TargetCode"].Value.ToString();
                    btnSaveMonthly.Text = "Update";
                    isNewRecord = 1;

                    //txtprodcode.Text=
                }


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateMonthlyPage();
                if (isPageValidated == 1)
                {
                    ObjectToClassMapperMonthlyProduction();
                    ResetControlsMonthly();
                }
                else
                {

                }
                GenerateReport();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObjectToClassMapperMonthlyProduction()
        {
            try
            {
                monthProd.PlantName = cmbPlantNameMon.Text;
                monthProd.NoWorkDays = Convert.ToInt32(txttotalWorkdaysMon.Text);
                monthProd.DaysWorked = txtnoWorkDaysMon.Text;
                monthProd.CreatedBy = adminCode;
                monthProd.RoleId = RoleId;


                monthProd.MonthlyTarget = Convert.ToDecimal(txtmonthlyTgtMon.Text);
                monthProd.DailyTarget = Convert.ToDecimal(txtdailytgtMon.Text);
                monthProd.ClosingStock = Convert.ToDecimal(txtclosingtgtMon.Text);
                monthProd.MonthlyTargetUnit = cmbmonTargetMon.Text;
                monthProd.DailyTargetUnit = cmbdailytargetMon.Text;


                monthProd.ClosingStockUnit = cmbclosingtargetMon.Text;
                monthProd.TargetCode = lblProdNoMon.Text;
                monthProd.TargetMonth = DateTime.Now.Month.ToString();
                monthProd.TargetYear = DateTime.Now.Year;
                monthProd.CreatedDate = DateTime.Now;
                monthProd.ProdCode = txtprodcodeMon.Text;
                // int m = DalService.AddNearMissUAUCRequestor(nearMiss);
                AddMessage();
                int m = ObjectToDALMApperMonthlyProduction();
                if (m > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[0], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isPlantLocked = 1;
                    // cmbPlantNameMon.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                getMonthlyProductionData();
                btnSave.Text = "Save";
                // tabControl1.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getMonthlyProductionData()
        {
            try
            {
                prodData = DalService.GetMonthlyProductionTarget_RMPCL(0, "", cmbPlantNameMon.Text, Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0), "", "", "", DateTime.Now, lblProdNoMon.Text, RoleId, adminCode, DateTime.Now.Month.ToString(), DateTime.Now.Year, txtprodcodeMon.Text, 3);
                DGVMonthlyProduction.DataSource = prodData;
                this.DGVMonthlyProduction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                SearchProdDt = new DataTable();
                SearchProdDt = prodData;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMonProdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControlsMonthly();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetControlsMonthly()
        {
            txtclosingtgtMon.Text = "";
            txtdailytgtMon.Text = "";
            txtmonthlyTgtMon.Text = "";
            //  txtnoWorkDaysMon.Text = "";
            txtprodcodeMon.Text = "";
            // txttotalWorkdaysMon.Text = "";
            cmbclosingtargetMon.Text = "";
            cmbdailytargetMon.Text = "";
            cmbmonTargetMon.Text = "";
            cmbPlantNameMon.Text = "";
            cmbProdNameMon.Text = "";
            lblProdNoMon.Text = "";
            lblPlantNAmeMon.Visible = false;
            lblProMon.Visible = false;
            lblWorkdays.Visible = false;
            lblTargetMon.Visible = false;
            btnSaveMonthly.Text = "Save";
            GenerateReport();
        }

        private void DGVConsumDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProdConsumpSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateConsumptionPage();
                if (isPageValidated == 1)
                {
                    ObjectToClassDailyConsumption();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObjectToClassDailyConsumption()
        {
            try
            {
                tabReload = false;
                dailyConsum.DProdCode = lblDprodCode.Text;
                dailyConsum.CoalConsumed = Convert.ToDecimal(txtTotalCoal.Text);
                dailyConsum.CoalRate = Convert.ToDecimal(txtCoalRate.Text);
                dailyConsum.CoalUnit = cmbCoalUnit.Text;
                dailyConsum.DConsumCode = lblConsumCode.Text;
                dailyConsum.ElectricityConsumed = Convert.ToDecimal(txtTotalElectricity.Text);
                dailyConsum.ElectricityRate = Convert.ToDecimal(txtElecRate.Text);
                dailyConsum.ElectricityUnit = cmbElecUnitConsump1.Text;
                dailyConsum.MaintenanceTime = Convert.ToDecimal((Convert.ToDecimal(cmbMHours.Text) * 60) + Convert.ToDecimal(cmbMaintMinute.Text));
                dailyConsum.MaintenanceTimeUnit = cmbRunMint.Text;
                dailyConsum.PlantName = cmbPlantName.Text;
                dailyConsum.PowerTrip = Convert.ToDecimal((Convert.ToDecimal(CmbPHours.Text) * 60) + Convert.ToDecimal(cmbPMinutes.Text));
                dailyConsum.PowerTripUnit = cmbMUnit.Text;
                dailyConsum.TotalProduction = Convert.ToDecimal(lblTotalProduction.Text);
                dailyConsum.TotalRunningTime = Convert.ToDecimal((Convert.ToDecimal(WorkHr) * 60) + (Convert.ToDecimal(WorkMin)));
                dailyConsum.TotalRunningTimeUnit = cmbMUnit.Text;
                dailyConsum.TotalUnit = lblConsumUnit.Text;
                dailyConsum.CreatedDate = DateTime.Now;
                AddMessage();
                int m = ObjectToDALMApperDailyConsumption();
                //getMonthlyProductionData();
                btnSave.Text = "Save";
                if (m > 0)
                {
                    // ConsumSaved = false;
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[0], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProdMasterpages.SelectedIndex = 3;
                    ProdMasterpages.Controls.Remove(tabConsumption);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GetDailyConsumption();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetDailyConsumption()
        {
            try
            {
                DGVRowDT = DalService.GetDailyConsumption(lblConsumCode.Text, 1);
                DGVConsumDetails.DataSource = DGVRowDT;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbmonTargetMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbmonTargetMon.Text == UnitCmb.Add.ToString())
                {
                    AddUnit addn = new AddUnit();
                    addn.updateUnitEvent += UpdateComboList;
                    addn.Show();
                }
                else
                {
                    cmbdailytargetMon.Text = cmbmonTargetMon.Text;
                    cmbclosingtargetMon.Text = cmbmonTargetMon.Text;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateComboList(object sender, string value)
        {
            try
            {
                cmbdailytargetMon.Items.Clear();
                cmbclosingtargetMon.Items.Clear();
                cmbmonTargetMon.Items.Clear();
                unitMasterDT = Resources.Instance.GetUnitMaster_RMPCL("", 2);
                for (int o = 0; o < unitMasterDT.Rows.Count; o++)
                {
                    cmbmonTargetMon.Items.Add(unitMasterDT.Rows[o][1]);
                    cmbclosingtargetMon.Items.Add(unitMasterDT.Rows[o][1]);
                    cmbdailytargetMon.Items.Add(unitMasterDT.Rows[o][1]);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbdailytargetMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbmonTargetMon.Text == UnitCmb.Add.ToString())
                {
                    AddUnit addn = new AddUnit();
                    addn.updateUnitEvent += UpdateComboList;
                    addn.Show();
                }
                else
                {
                    cmbdailytargetMon.Text = cmbmonTargetMon.Text;
                    cmbclosingtargetMon.Text = cmbmonTargetMon.Text;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnDailyProdRptView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProductDashboard();
                //safetyThread.Start();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportFile()
        {
            if (dashboardViewer2.AllowPrintDashboard)
            {
                // The PDF file name.
                string fileName = "Output.pdf";
                // Path to the PDF file.
                string filePath = "c:\\temp";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                string fullPath = String.Format("{0}\\{1}", filePath, fileName);

                // Exports to a stream as PDF.
                FileStream pdfStream = new FileStream(fullPath, FileMode.Create);
                dashboardViewer2.ExportToPdf(pdfStream);
                pdfStream.Close();
            }
        }
        void ExecuteThread()
        {
            MyDelegate delInstatnce = new MyDelegate(LoadMaintenanceDBoard);
            this.Invoke(delInstatnce);
        }

        private void LoadProductDashboard()
        {
            //Task.Factory.StartNew(() =>
            //{
            //    try
            //    {
            //        MyDelegate delInstatnce = new MyDelegate(LoadMaintenanceDBoard);
            //        this.Invoke(delInstatnce);
            //    }
            //    catch (Exception Ex)
            //    {
            //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //});
            ExecuteThread();
        }
        private void LoadMaintenanceDBoard()
        {
            string XmlPath = Application.StartupPath + @"\" + "FinalDsbdRed2" + ".xml";
            // dashboard.LoadFromXml(XmlPath);
            DashBoardView1.LoadDashboard(XmlPath);
            // dashboard.SaveToXml(XmlPath);
        }

       
        private void DashBoardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs e)
        {
            string text = System.IO.Path.GetFullPath("AppSetting.ini");
            if (File.Exists(text))
            {
                IniFile.SetPath(text);

            }
        }
       

        private void btnMonProdRptView_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteThreadMonthlyProduction();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteThreadMonthlyProduction()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    MyDelegate delInstatnce = new MyDelegate(LoadMonthlyProductionDBoard);
                    this.Invoke(delInstatnce);
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

        }

        private void LoadMonthlyProductionDBoard()
        {
            try
            {
                string XmlPath = Application.StartupPath + @"\" + "MonthlyProductionDBoard" + ".xml";
                dashboard.LoadFromXml(XmlPath);
                dashboardViewer2.LoadDashboard(XmlPath);
                dashboard.SaveToXml(XmlPath);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void DgvDataDetailedView_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Escape)
        //        {
        //            this.DgvDataDetailedView.DataSource = "";
        //            this.DgvDataDetailedView.Visible = false;
        //            pnlMonth.Visible = false;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtProdDispatchedD_Leave(object sender, EventArgs e)
        {
            try
            {
                if ((txtProdDispatchedD.Text != "0") && (txtActualProdD.Text != ""))
                {
                    txtClosingStockD.Text = Convert.ToString((Convert.ToDecimal(txtActualProdD.Text) + Convert.ToDecimal(txtOpenStockD.Text)) - 0);
                }
                if ((txtProdDispatchedD.Text != "") && (txtActualProdD.Text != "") && (txtOpenStockD.Text != ""))
                {
                    txtClosingStockD.Text = Convert.ToString((Convert.ToDecimal(txtActualProdD.Text) + Convert.ToDecimal(txtOpenStockD.Text)) - 0);
                }
                if (txtActualProdD.Text.Trim() != "")
                {
                    if (txtProdDispatchedD.Text == "")
                    {
                        txtClosingStockD.Text = Convert.ToString((Convert.ToDecimal(txtActualProdD.Text) + Convert.ToDecimal(txtOpenStockD.Text)) - 0);
                    }
                    else
                    {
                        txtClosingStockD.Text = Convert.ToString((Convert.ToDecimal(txtActualProdD.Text) + Convert.ToDecimal(txtOpenStockD.Text)) - Convert.ToDecimal(txtProdDispatchedD.Text));
                    }
                }
                txtClosingStockD.Enabled = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMainUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                int TotalHours = Convert.ToInt32(CmbPHours.Text) + Convert.ToInt32(cmbMHours.Text);
                int totalMinutes = Convert.ToInt32(cmbPMinutes.Text) + Convert.ToInt32(cmbMaintMinute.Text);
                int TotalTime = TotalHours * 60 + totalMinutes;
                double runningSeconds = Convert.ToDouble((Convert.ToDecimal(24 * 60 * 60) - Convert.ToDecimal(TotalTime * 60)));
                double hour = runningSeconds / 3600.00;
                double FinalHour = Math.Floor(hour);
                WorkHr = FinalHour;
                decimal d = new decimal(Convert.ToDouble(hour));
                d = d % 1;
                decimal minutes = Math.Round((d * 60));
                WorkMin = minutes;
                cmbTotRunhrs.Text = FinalHour.ToString();
                cmbTotRunMint.Text = minutes.ToString();
                cmbMaintUnit.SelectedText = cmbMaintUnit.Items[1].ToString();
                //cmbMaintUnit.SelectedIndex = cmbMaintUnit.Items.IndexOf("Hours");
                CmbRunHrs.SelectedIndex = 1;
                cmbRunMint.SelectedIndex = 1;
                //cmbMainUnit.SelectedIndex = cmbMainUnit.Items.IndexOf("Minutes");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string GetHour(int second)
        {
            double hour = second / 3600.00;
            double FinalHour = Math.Floor(hour);
            decimal d = new decimal(Convert.ToDouble(hour));
            d = d % 1;
            decimal minutes = Math.Round((d * 60));
            string value = FinalHour + ":" + minutes;
            return value;
        }
        private void DashBoardView1_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            try
            {
                string text = System.IO.Path.GetFullPath("AppSetting.ini");
                if (File.Exists(text))
                {
                    IniFile.SetPath(text);
                }

                if (e.DataSourceName == "SQL Data Source 1")
                {
                    MsSqlConnectionParameters parameters = e.ConnectionParameters as MsSqlConnectionParameters;
                    if (parameters != null)
                    {
                        parameters.ServerName = IniFile.IniReadValue("DBConfig", "ServerName");
                        parameters.UserName = IniFile.IniReadValue("DBConfig", "UserName");
                        parameters.Password = IniFile.IniReadValue("DBConfig", "Password");
                        parameters.DatabaseName = IniFile.IniReadValue("DBConfig", "DBName");
                        // parameters.Password = ;
                    }
                }
                if (e.DataSourceName == "SQL Data Source 2")
                {
                    MsSqlConnectionParameters parameters = e.ConnectionParameters as MsSqlConnectionParameters;
                    if (parameters != null)
                    {
                        parameters.ServerName = IniFile.IniReadValue("DBConfig", "ServerName");
                        parameters.UserName = IniFile.IniReadValue("DBConfig", "UserName");
                        parameters.Password = IniFile.IniReadValue("DBConfig", "Password");
                        parameters.DatabaseName = IniFile.IniReadValue("DBConfig", "DBName");
                    }
                }

                if (e.DataSourceName == "SQL Data Source 3")
                {
                    MsSqlConnectionParameters parameters = e.ConnectionParameters as MsSqlConnectionParameters;
                    if (parameters != null)
                    {
                        parameters.ServerName = IniFile.IniReadValue("DBConfig", "ServerName");
                        parameters.UserName = IniFile.IniReadValue("DBConfig", "UserName");
                        parameters.Password = IniFile.IniReadValue("DBConfig", "Password");
                        parameters.DatabaseName = IniFile.IniReadValue("DBConfig", "DBName");
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dashboardViewer2_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            try
            {
                string text = System.IO.Path.GetFullPath("AppSetting.ini");
                if (File.Exists(text))
                {
                    IniFile.SetPath(text);
                }

                if (e.DataSourceName == "SQL Data Source 1")
                {
                    MsSqlConnectionParameters parameters = e.ConnectionParameters as MsSqlConnectionParameters;
                    if (parameters != null)
                    {
                        parameters.ServerName = IniFile.IniReadValue("DBConfig", "ServerName");
                        parameters.UserName = IniFile.IniReadValue("DBConfig", "UserName");
                        parameters.Password = IniFile.IniReadValue("DBConfig", "Password");
                        parameters.DatabaseName = IniFile.IniReadValue("DBConfig", "DBName");
                        // parameters.Password = ;
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnMonthlyExportPDF_Click(object sender, EventArgs e)
        {
            ExportFile();
        }

        private void timerTicker_Tick(object sender, EventArgs e)
        {
            try
            {
                //GlobalDeclaration.prdDetails.UpdateTimeInterval += UpdateTimeHandler;
                //if (GlobalDeclaration.prdDetails.UpdateTimeInterval != null)
                //    GlobalDeclaration.prdDetails.UpdateTimeInterval.Invoke(sender, lblProdNo.Text);
                //if (UpdateTimeInterval != null)
                //{
                //    this.UpdateTimeInterval += UpdateTimeHandler;

                //}
                lblDatetime.Text = DateTime.Now.ToString();
                lblDlDate.Text = DateTime.Now.ToString();
                lblMonthTraget.Text = DateTime.Now.ToString();
                lblDateObj.Text = DateTime.Now.ToString();
                lblDailyPrdRPT.Text = DateTime.Now.ToString();
                lblMonthlyDate.Text = DateTime.Now.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTimeHandler(object sender, string value)
        {
            try
            {
                //lblDlDate.Text = DateTime.Now.ToString();
                //lblDatetime.Text = DateTime.Now.ToString();
                //lblMonthTraget.Text = DateTime.Now.ToString();
                //lblDailyPrdRPT.Text = DateTime.Now.ToString();
                //lblMonthlyDate.Text = DateTime.Now.ToString();
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProdGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                foreach (DataGridViewColumn column in DGVProdGrid.Columns)
                {
                    column.ReadOnly = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProdGrid_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                DGVProdGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVProdGrid.AllowUserToResizeRows = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtProdCode.Text.TrimStart(' ');
                txtProdCode.Focus();
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(char.IsSymbol(e.KeyChar));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtProdName.Text.TrimStart(' ');
                txtProdName.Focus();
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(char.IsNumber(e.KeyChar));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtProdName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void cmbPlantName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtProdCode_Leave(object sender, EventArgs e)
        {

        }

        private void txtProdName_Leave(object sender, EventArgs e)
        {
            try { 
            ValidateProductPage();
            issavedClicked = 1;
            if (btnSave.Text == "Update")
            {

            }
            else
            {
                ValidateProdCode();
            }

            if (isPageValidated == 1)
            {
                ObjectToClassMapper();
            }

            if (isPageValidated == 0)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "The Page contains Validation Error. Please validate & continue!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProdCode.Focus();
            }
            GenerateReport();
        }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen
    }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cmbPlantName_Leave(object sender, EventArgs e)
        {

        }

        private void txtmonthlyTgtMon_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtmonthlyTgtMon.Text.Length > 0 && txttotalWorkdaysMon.Text.Length > 0)
                {
                    decimal finalOut = Convert.ToDecimal(txtmonthlyTgtMon.Text) / Convert.ToDecimal(txttotalWorkdaysMon.Text);
                    txtdailytgtMon.Text = String.Format("{0:0.00}", finalOut);
                }
                else
                {
                    // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen },"Monthly Target required", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // eps.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlantNameMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void cmbProdNameMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtprodcodeMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtnoWorkDaysMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txttotalWorkdaysMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtmonthlyTgtMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtdailytgtMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void cmbmonTargetMon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmonthlyTgtMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar == '.');
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtActualProdD_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar == '.');
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdDispatchedD_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsPunctuation(e.KeyChar)) && !(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(char.IsNumber(e.KeyChar));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtclosingtgtMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar == '.');
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdCode_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtProdCode.Text.StartsWith(" "))
                {
                    isPrdMasterValid = false;
                }
                else
                {
                    isPrdMasterValid = true;
                }
                if (isPrdMasterValid == false)
                {
                    XtraMessageBox.Show("Product Code cannot be empty", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProdCode.Focus();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtProdCode_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                DataRow[] filteredRows = ProdCodeDT.Select("ProdCode = '%" + txtProdCode.Text + "%'");
                if (filteredRows.Length > 0)
                {
                    if (!string.IsNullOrEmpty(txtProdCode.Text))
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Product Code already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProdCode.Focus();
                    }
                    isPageValidated = 0;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdName_MouseLeave(object sender, EventArgs e)
        {

        }

        private void onTabControlChange()
        {
            try
            {

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbActualProdD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime strtdate = dtpFromDate.Value;
                // dtpProdDateD.Value = DateTime.Today.AddDays(-1);
                dtpToDate.Value = strtdate.AddDays(30);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void ResetDailyProd()
        {
            lblPlantDErr.Visible = false;
            lblProdDErr.Visible = false;
            lblActProdDErr.Visible = false;
            cmbPlantNameD.Text = "";
            cmbProdNameD.Text = "";
            txtProdCodeD.Text = "";
            txtOpenStockD.Text = "";
            txtDailyProdD.Text = "";
            txtActualProdD.Text = "";
            txtProdDispatchedD.Text = "";
            txtClosingStockD.Text = "";
            // DGVDailyProduction.DataSource = null;
            btnAdd.Text = "Add";
            cmbPlantNameD.Enabled = true;
            RowCounter = 0;
            // DGVDailyProduction.Rows.Clear();
        }
        private void btnCancelLocal_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DGVDailyProduction.Rows.Count > 0)
                {
                    DGVDailyProduction.Rows.RemoveAt(0);
                    //DGVDailyProduction.Rows.Clear();
                    //AddColumnsDT();
                    DGVDailyProduction.DataSource = GridBck;
                }
                ResetDailyProd();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.ProdMasterpages.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {

        }

        public void RedirectTabControl(object sender, int value)
        {
            try
            {
                if (value >= 1)
                {
                    ResetDailyProd();
                    ProdMasterpages.SelectedIndex = 0;
                    isPlantLocked = 0;
                    cmbPlantNameMon.Enabled = true;
                    cmbPlantNameD.Enabled = true;
                    dailMastrBck.Clear();
                    GridBck.Rows.Clear();
                    DGVDailyProduction.Width = 1465;
                    DGVDailyProduction.Height = 252;
                    int count = DGVDailyProduction.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DGVDailyProduction.Rows.RemoveAt(i);
                    }
                    bunifuButton2.Enabled = true;
                    DGVDailyProduction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    if (GlobalDeclaration.isConsumptionFormClosed == true)
                    {
                        int n = DailyProd.DropDailyProductionData(GlobalDeclaration.ProdCode);
                    }
                    // GenerateReport();
                    // getDailyProductionData();
                    // txttotalWorkdaysMon.Text = GlobalDeclaration.dayCount.ToString();
                }
                else
                {
                    ResetDailyProd();
                    ProdMasterpages.SelectedIndex = 0;
                    isPlantLocked = 0;
                    cmbPlantNameMon.Enabled = true;
                    cmbPlantNameD.Enabled = true;
                    dailMastrBck.Clear();
                    GridBck.Rows.Clear();
                    DGVDailyProduction.Width = 1465;
                    DGVDailyProduction.Height = 252;
                    int count = DGVDailyProduction.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DGVDailyProduction.Rows.RemoveAt(i);
                    }
                    bunifuButton2.Enabled = true;
                    DGVDailyProduction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                GenerateReport();
                getDailyProductionData();
                txttotalWorkdaysMon.Text = GlobalDeclaration.dayCount.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateProductStatus(object sender, string value)
        {
            try
            {
                getAllProductDetails();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlantNameConsum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtProdCode_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (issavedClicked == 0)
                {
                    ValidateProdCode();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton7_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMonNewProdCalander_Click(object sender, EventArgs e)
        {
            try
            {
                empRoleId = Resources.Instance.MapAdminRole_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode.ToString());
                if (empRoleId == 1 || empRoleId == 7)
                {
                    Operation.Production_Calendar sft = new Operation.Production_Calendar();
                    GlobalDeclaration.isAdmin = true;
                    GlobalDeclaration.dayCount = 1;
                    sft.updateCalendarEvent += setTextValue;
                    sft.updateworkDaysEvent += RedirectTabControl;
                    sft.Show();
                }
                else
                {
                    XtraMessageBox.Show("You need to be an Administrator to edit Production calendar!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoadUnsaved_Click(object sender, EventArgs e)
        {
            try
            {
                pnlPlantSelection.Visible = true;
                

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    pnlPlantSelection.Visible = false;
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPlSelection_Click(object sender, EventArgs e)
        {
            try
            {
                isPlantPanelSelection = true;
                if (cmbPlName.Text != "N/A")
                {
                    dts1 = DailyTmpTbl.GetDailyProductionTempTbl("", cmbPlName.Text, "", "", 0, 0, 0, 0, 0, "", 0, DateTime.Now, DateTime.Now, DateTime.Now, "", "", 2);
                    DGVDailyProduction.DataSource = dts1;
                    this.DGVDailyProduction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    isPlantPanelSelection = false;
                    this.pnlPlantSelection.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ResetDailyProd();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private void btnDeactivate_Click_2(object sender, EventArgs e)
        {
            try
            {
                Operation.ProductDeactivateWindow deactive = new ProductDeactivateWindow();
                deactive.updateActivatedEvent += UpdateProductStatus;
                deactive.Show();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdCode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtProdCode.Text.StartsWith(" "))
                {
                    isPrdMasterValid = false;
                }
                else
                {
                    isPrdMasterValid = true;
                }
                if (isPrdMasterValid == false)
                {
                    XtraMessageBox.Show("Product Code cannot be empty", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProdCode.Focus();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                IsDailyDashboardLoaded = false;
                IsMonthlyDashboardLoaded = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdName_TabStopChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProdName.Text.StartsWith(" ") ||string.IsNullOrEmpty(txtProdName.Text))
                {
                    isProdName = false;
                }
                else
                {
                    isProdName = true;
                }
                if (isProdName == false)
                {
                    XtraMessageBox.Show("Product name cannot be empty", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProdName.Focus();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProdName.Text.StartsWith(" "))
                {
                    isProdName = false;
                }
                else
                {
                    isProdName = true;
                }
                if (isProdName == false)
                {
                    XtraMessageBox.Show("Product name cannot be empty", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProdName.Focus();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HideProdMasterpagesHeader()
        {
            ProdMasterpages.Appearance = TabAppearance.FlatButtons;
            ProdMasterpages.ItemSize = new Size(0, 1);
            ProdMasterpages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in ProdMasterpages.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void btnMonthProd_Click(object sender, EventArgs e)
        {
            ProdMasterpages.SelectedIndex = 1;
        }

        private void btnDailyProd_Click(object sender, EventArgs e)
        {
            ProdMasterpages.SelectedIndex = 2;
            MigrationActivity();
        }

        private void btnConsumptionDetails_Click(object sender, EventArgs e)
        {
            ProdMasterpages.SelectedIndex = 3;
            MigrationActivity();
        }

        private void btnDailyProdReport_Click(object sender, EventArgs e)
        {
            ProdMasterpages.Enabled = true;
            if(Properties.Settings.Default.RoleID==7 || Properties.Settings.Default.RoleID == 4 || Properties.Settings.Default.RoleID == 3)
            ProdMasterpages.SelectedIndex = 3;
            else
                ProdMasterpages.SelectedIndex = 4;
            // MigrationActivity();
        }

        private void btnMonthProdReport_Click(object sender, EventArgs e)
        {
            ProdMasterpages.Enabled = true;
            if(Properties.Settings.Default.RoleID==7 || Properties.Settings.Default.RoleID == 4 || Properties.Settings.Default.RoleID == 3)
            ProdMasterpages.SelectedIndex = 4;
            else
                ProdMasterpages.SelectedIndex = 5;
            //MigrationActivity();
        }

        private void btnProductMaster_Click(object sender, EventArgs e)
        {
            ProdMasterpages.SelectedIndex = 0;
            // MigrationActivity();
        }

       

       
        public void MigrationActivity()
        {
            try
            {
                ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "tabDailyProd")
                if (ProdMasterpages.SelectedIndex == 1)
                {
                    //PnlDailyProd.Enabled = false;
                }

                ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "TabDailyProdReport" && (IsDailyDashboardLoaded == false))
                if (ProdMasterpages.SelectedIndex == 3 && (IsDailyDashboardLoaded == false))
                {
                    LoadProductDashboard();
                    IsDailyDashboardLoaded = true;
                }
                ////if (ProdMasterpages.SelectedTab.Tag.ToString() == "MonthlyReport" && (IsMonthlyDashboardLoaded == false))
                if (ProdMasterpages.SelectedIndex == 5 && (IsMonthlyDashboardLoaded == false))
                {
                    ExecuteThreadMonthlyProduction();
                    IsMonthlyDashboardLoaded = true;
                }
                GenerateReport();
                GlobalDeclaration.TotalProduction = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


        //private void validateProductName()
        //{
        //    try
        //    {
        //        if (txtProdName.Text.StartsWith(" "))
        //        {
        //            isProdName = false;
        //        }
        //        else
        //        {
        //            isProdName = true;
        //        }
        //        if (isProdName == false)
        //        {
        //            XtraMessageBox.Show("Product name cannot be empty", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtProdName.Focus();
        //        }
        //        ValidateProductPage();

        //    }
        //    catch
        //       {

        //        }
        //    }
    }
}