using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using RMPCLApp.DAL;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RMPCLApp.Operation
{
    public partial class MonthlyProductionTarget : DevExpress.XtraEditors.XtraForm
    {
        public Operation.BusinessClasses.MonthlyProduction monthProd { get; set; }
        public decimal ClosingStock { get; set; }
        public ServiceDAL DalService { get; set; }
        public MonthlyProductionTarget()
        {
            DalService = new ServiceDAL();
            monthProd = new Operation.BusinessClasses.MonthlyProduction();
            InitializeComponent();
        }

        #region "variable Declaration"
        DataTable prodData = null;
        DataTable unitMasterDT = null;
        List<string> MessasgeAP = new List<string>();
        //holdUserInfo _strcu = new holdUserInfo();
        int retVal = 0;

        public string EmpCode { get; set; }

        private string adminCode { get; set; }

        private int RoleId { get; set; }

        #endregion

        public enum PlantName
        {
            None,
            PSSP,
            GSSP
        }

        public enum UnitCmb
        {
            None,
            Kg,
            tonne,
            metrictonne,
            Add
        }
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
                string RptNo = "PRD" + "/" + DateTime.Now.Year + "/" + GlobalDeclaration.RandomNumber(1001, 9999);
                lblProdNoMon.Text = RptNo;
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
                cmbPlantNameMon.DataSource = Enum.GetValues(typeof(PlantName));
                //cmbmonTarget.DataSource = Enum.GetValues(typeof(UnitCmb));
                //cmbclosingtarget.DataSource = Enum.GetValues(typeof(UnitCmb)); 
                //cmbdailytarget.DataSource = Enum.GetValues(typeof(UnitCmb));
                unitMasterDT = new DataTable();
                unitMasterDT = Resources.Instance.GetUnitMaster_RMPCL("", 2);
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
                ObjectToClassMapper();
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
            txtnoWorkDaysMon.Text = "";
            txtprodcodeMon.Text = "";
            txttotalWorkdaysMon.Text = "";
            cmbclosingtargetMon.Text = "";
            cmbdailytargetMon.Text = "";
            cmbmonTargetMon.Text = "";
            cmbPlantNameMon.Text = "";
            cmbProdNameMon.Text = "";
            lblProdNoMon.Text = "";
            GenerateReport();
        }
        private void ObjectToClassMapper()
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
                monthProd.MonthlyTargetUnit = adminCode;
                monthProd.DailyTargetUnit = cmbdailytargetMon.Text;


                monthProd.ClosingStockUnit = cmbclosingtargetMon.Text;
                monthProd.TargetCode = lblProdNoMon.Text;
                monthProd.TargetMonth = DateTime.Now.Month.ToString();
                monthProd.TargetYear = DateTime.Now.Year;
                monthProd.CreatedDate = DateTime.Now;
                monthProd.ProdCode = txtprodcodeMon.Text;
                // int m = DalService.AddNearMissUAUCRequestor(nearMiss);
                AddMessage();
                int m = ObjectToDALMApper();
                if (m > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[0], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                getMonthlyProductionData();
                btnSave.Text = "Save";
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
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int ObjectToDALMApper()
        {
            if (btnSave.Text == "Save")
            {
                retVal = DalService.AddMonthlyProduction(monthProd, 1);
            }
            else
            {
                retVal = DalService.AddMonthlyProduction(monthProd, 2);
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

        private void MonthlyProductionTarget_Load(object sender, EventArgs e)
        {
            try
            {
                lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                GenerateReport();
                AddComboValues();
                GetAdminCode();
                cmbProdNameMon.Items.Clear();
                getMonthlyProductionData();
                //  getProductDetails();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProdGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Operation.CalendarSelection sft = new Operation.CalendarSelection();
                sft.updateCalendarEvent += setTextValue;
                sft.Show();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void setTextValue(object sender, string value)
        {
            txtnoWorkDaysMon.Text = GlobalDeclaration.dayList;
            txttotalWorkdaysMon.Text = GlobalDeclaration.dayCount.ToString();
        }

        private void DateCalendarGrp_Click(object sender, EventArgs e)
        {
            try
            {
                //DatreCalendar.Items.Add(DateCalendarGrp.s
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmonthlyTgt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txttotalWorkdaysMon.Text) < Convert.ToInt32(txtmonthlyTgtMon.Text))
                {
                    txtdailytgtMon.Text = String.Format("{0:N}", (Convert.ToDecimal(txtmonthlyTgtMon.Text) / Convert.ToDecimal(txttotalWorkdaysMon.Text)).ToString());
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbmonTarget_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cmbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var countryIDs = prodData.AsEnumerable().Where(row => row.Field<String>("ProdName") == cmbProdNameMon.Text).FirstOrDefault();
                txtprodcodeMon.Text = countryIDs[2].ToString();
                //DataRow[] result = prodData.Select("ProdName='"+cmbProdName.Text+"'");
                //foreach (DataRow row in result)
                //{
                // txtprodcode.Text=results[1].to
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProdNameMon.Items.Clear();
                prodData = Resources.Instance.GetProductMaster_RMPCL(cmbPlantNameMon.Text, "", "", DateTime.Now, "", "", 0, 2,1,DateTime.Now, DateTime.Now);
                for (int n = 0; n < prodData.Rows.Count; n++)
                {
                    cmbProdNameMon.Items.Add(prodData.Rows[n][4]);
                }
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
                    btnSave.Text = "Update";

                    //txtprodcode.Text=
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}