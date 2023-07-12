using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.DAL;
using HindalcoiOS.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Operation
{
    public partial class ProductConsumtion : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<int> RedirectToTabEvent;
        //public EventHandler<object> RedirectToTabEvent;
        public DailyConsumption dailyConsum { get; set; }
        public Operation.BusinessClasses.DailyProduction DailyProd { get; set; }
        public ServiceDAL DalService { get; set; }
        private int isPageValidated { get; set; }
        public bool isPrdConsumptionClosed { get; set; }

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
        public ProductConsumtion()
        {
            DailyProd = new BusinessClasses.DailyProduction();
            DalService = new ServiceDAL();
            dailyConsum = new DailyConsumption();
            InitializeComponent();
        }

        #region "Variable Declaration"

        Double WorkHr = 0;
        decimal WorkMin = 0;
        #endregion
        private void cmbPlantNameConsum_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void ProductConsumption_Load(object sender, EventArgs e)
        {
            try
            {
                ToolTip ToolTip1 = new ToolTip();
                ToolTip1.SetToolTip(lblElectricConsume, "Consumption of PSSP/GSSP , cumulative for or a complete plant");
                ToolTip1.SetToolTip(lblProdConsCoalConsum, "Consumption of PSSP/GSSP , cumulative for or a complete plant");
                lblConsumCode.Visible = true;
                lblConsumUnit.Text = GlobalDeclaration.ProdUnit.ToString();
                cmbPlantNameConsum.Enabled = true;
                lblTotalProduction.Text = GlobalDeclaration.TotalProduction.ToString();
                cmbPlantNameConsum.Items.Add(GlobalDeclaration.plantName);
                cmbPlantNameConsum.Text = GlobalDeclaration.plantName;
                cmbElecUnitConsump1.DataSource = Enum.GetValues(typeof(ElectricityUnit));
                lblConsumCode.Text = GlobalDeclaration.ProdCode;
                cmbCoalUnit.DataSource = Enum.GetValues(typeof(CoalUnit));
                cmbCoalUnit.SelectedIndex = 3;
                cmbCoalUnit.Enabled = false;
                cmbElecUnitConsump1.SelectedIndex = 1;
                cmbElecUnitConsump1.Enabled = false;
                cmbPlantNameConsum.Enabled = false;
                InitCmbHours();
                cmbPUnit.SelectedIndex = 0;
                cmbMUnit.SelectedIndex = 0;
                cmbMaintMinute.SelectedIndex = 0;
                cmbMainUnit.SelectedIndex = 0;
                cmbMaintUnit.SelectedIndex = 0;
                //   CaseCheck();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaseCheck()
        {
            try
            {
                switch (lblTotalProduction.Text)
                {
                    case "0":
                        {
                            txtTotalElectricity.Text = "0.00";
                            txtTotalCoal.Text = "0.00";
                            txtElecRate.Text = "0.00";
                            txtCoalRate.Text = "0.00";
                            txtElecRate.Enabled = false;
                            txtCoalRate.Enabled = false;
                            break;
                        }
                }
                if (lblTotalProduction.Text != "0")
                {
                    decimal output = Convert.ToDecimal(txtTotalElectricity.Text) / Convert.ToDecimal(lblTotalProduction.Text);
                    txtElecRate.Text = String.Format("{0:0.00}", output);
                }
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
                if (FinalHour == 0)
                {
                    cmbTotRunhrs.Text = "0";
                }
                cmbTotRunhrs.Text = FinalHour.ToString();
                cmbTotRunMint.Text = minutes.ToString();
                cmbMaintUnit.SelectedText = cmbMaintUnit.Text;
                //cmbMaintUnit.SelectedIndex = cmbMaintUnit.Items.IndexOf("Hours");
                CmbRunHrs.SelectedIndex = 0;
                cmbRunMint.SelectedIndex = 0;
                //cmbMainUnit.SelectedIndex = cmbMainUnit.Items.IndexOf("Minutes");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateConsumptionPage()
        {
            if (string.IsNullOrEmpty(cmbPlantNameConsum.Text))
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

            if (!string.IsNullOrEmpty(cmbPlantNameConsum.Text) && (!string.IsNullOrEmpty(txtTotalElectricity.Text)))
            {
                isPageValidated = 1;
            }
            else
            {
                isPageValidated = 0;
            }
        }
        int m = 0;
        private void ObjectToClassDailyConsumption()
        {
            try
            {
                dailyConsum.DProdCode = GlobalDeclaration.ProdCode;
                dailyConsum.CoalConsumed = Convert.ToDecimal(txtTotalCoal.Text);
                dailyConsum.CoalRate = Convert.ToDecimal(txtCoalRate.Text);
                dailyConsum.CoalUnit = cmbCoalUnit.Text;
                dailyConsum.DConsumCode = lblConsumCode.Text;
                dailyConsum.ElectricityConsumed = Convert.ToDecimal(txtTotalElectricity.Text);
                dailyConsum.ElectricityRate = Convert.ToDecimal(txtElecRate.Text);
                dailyConsum.ElectricityUnit = cmbElecUnitConsump1.Text;
                dailyConsum.MaintenanceTime = Convert.ToDecimal((Convert.ToDecimal(cmbMHours.Text) * 60) + Convert.ToDecimal(cmbMaintMinute.Text));
                dailyConsum.MaintenanceTimeUnit = cmbRunMint.Text;
                dailyConsum.PlantName = GlobalDeclaration.plantName;
                dailyConsum.PowerTrip = Convert.ToDecimal((Convert.ToDecimal(CmbPHours.Text) * 60) + Convert.ToDecimal(cmbPMinutes.Text));
                dailyConsum.PowerTripUnit = cmbMUnit.Text;
                dailyConsum.TotalProduction = Convert.ToDecimal(lblTotalProduction.Text);
                dailyConsum.TotalRunningTime = Convert.ToDecimal((Convert.ToDecimal(WorkHr) * 60) + (Convert.ToDecimal(WorkMin)));
                dailyConsum.TotalRunningTimeUnit = cmbMUnit.Text;
                dailyConsum.TotalUnit = lblConsumUnit.Text;
                dailyConsum.CreatedDate = DateTime.Now;
                m = DalService.AddDailyConsumption(dailyConsum, 1);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateConsumptionPage();
                if (isPageValidated == 1)
                {
                    ObjectToClassDailyConsumption();
                    if (m > 0)
                    {
                        int x = DailyProd.DropDailyProductionTempData(DateTime.Now, cmbPlantNameConsum.Text);
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Daily Consumption Added successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalDeclaration.TotalProduction = 1;
                        Task.Delay(8000);
                        if (RedirectToTabEvent != null)
                            /////##########################3 Note--------RedirectToTabEvent will take 1 only when the suer either closes the form or cancels the entry made.
                            ///The 0 value represents data is saved by the user #################################//////////////////////////////////////////////////////////.
                            RedirectToTabEvent.Invoke(sender, 0);
                        this.Dispose();
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Oops something went wrong!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if ((lblTotalProduction.Text != "0") && (lblTotalProduction.Text != "0.00"))
                {
                    decimal output = Convert.ToDecimal(txtTotalElectricity.Text) / Convert.ToDecimal(lblTotalProduction.Text);
                    txtElecRate.Text = String.Format("{0:0.00}", output);
                }
                else
                {
                    txtTotalElectricity.Text = String.Format("{0:0.00}", txtTotalElectricity.Text);
                    txtElecRate.Text = String.Format("{0:0.00}", txtTotalElectricity.Text);
                }

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
                decimal output = Convert.ToDecimal(txtTotalCoal.Text) / Convert.ToDecimal(lblTotalProduction.Text);
                txtCoalRate.Text = String.Format("{0:0.00}", output);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMaintMinute_MouseLeave(object sender, EventArgs e)
        {

        }

        private void ProductConsumtion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GlobalDeclaration.isConsumptionFormClosed = true;
                if (RedirectToTabEvent != null)
                    //GlobalDeclaration.dayList =txtRemarks.Text;
                    RedirectToTabEvent.Invoke(sender, 1);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (RedirectToTabEvent != null)
                    //GlobalDeclaration.dayList =txtRemarks.Text;
                    RedirectToTabEvent.Invoke(sender, 1);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTotalCoal_Leave(object sender, EventArgs e)
        {
            try
            {
                if ((lblTotalProduction.Text != "0") && (lblTotalProduction.Text != "0.00"))
                {
                    decimal output = Convert.ToDecimal(txtTotalCoal.Text) / Convert.ToDecimal(lblTotalProduction.Text);
                    txtCoalRate.Text = String.Format("{0:0.00}", output);
                }
                else
                {
                    txtTotalCoal.Text = String.Format("{0:0.00}", txtTotalCoal.Text);
                    txtCoalRate.Text = String.Format("{0:0.00}", txtTotalCoal.Text);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CmbPHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbPHours.Text == "24")
                {
                    cmbPMinutes.Text = "0";
                    cmbPMinutes.Enabled = false;
                }
                else
                {
                    cmbPMinutes.Enabled = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbMHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMHours.Text == "24")
                {
                    cmbMaintMinute.Text = "0";
                    cmbMaintMinute.Enabled = false;
                }
                else
                {
                    cmbMaintMinute.Enabled = true;

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblTotalProduction_Leave(object sender, EventArgs e)
        {
            try
            {
                // CaseCheck();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbMaintMinute_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbPHours.Text != "" && cmbMHours.Text != "")
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
                    if (FinalHour == 0)
                    {
                        cmbTotRunhrs.Text = "0";
                    }
                    cmbTotRunhrs.Text = FinalHour.ToString();
                    cmbTotRunMint.Text = minutes.ToString();
                 //   cmbMaintUnit.SelectedText = cmbMaintUnit.Text;
                    //cmbMaintUnit.SelectedIndex = cmbMaintUnit.Items.IndexOf("Hours");
                    CmbRunHrs.SelectedIndex = 0;
                    cmbRunMint.SelectedIndex = 0;
                }
                //cmbMainUnit.SelectedIndex = cmbMainUnit.Items.IndexOf("Minutes");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTotalElectricity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalCoal_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}