using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.DAL;
using HindalcoiOS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Operation
{
    public delegate void SomeEvents(params object[] objec);
    public partial class ProductionCalendar : DevExpress.XtraEditors.XtraForm
    {
        #region "Variable Declaration"
        List<string> CalendarList = new List<string>();
        public EventHandler<int> updateworkDaysEvent;
        //public EventHandler<object[]> updateworkDaysEventExt;
        public event SomeEvents SomeEvent;
        
        public EventHandler<int> updateCalendarEvent;
        public ServiceDAL DalService { get; set; }
        public ProductMaster prodMaster { get; set; }
        public int MonthName { get; set; }

        public int monthId { get; set; }
        public int validPrpty { get; set; }
        #endregion
        public ProductionCalendar()
        {
            InitializeComponent();
            DalService = new DAL.ServiceDAL();
            prodMaster = new ProductMaster();
            cmbOpUnit.DataSource = Properties.Settings.Default.OperationUnits;
            cmbOpUnit.ValueMember = "OperationUnitName";
            cmbOpUnit.DisplayMember = "OperationUnitName";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalDeclaration.dayList = string.Empty;
                GlobalDeclaration.dayList = txtNoDays.Text;
                DataTable tds = new DataTable();
                tds = DalService.GetProductionCalendar("", DateTime.Now.Year, "", 1);
                if (btnSave.Text == "Save")
                {
                    validateDaysEntered();
                    if (validPrpty == 0)
                    {
                        int isFirstEntry = 0;
                        if (tds.Rows.Count == 0)
                        {
                            isFirstEntry = 1;
                        }
                        int m = DalService.AddProductionCalendar(monthId.ToString(), DateTime.Now.Year, txtNoDays.Text, isFirstEntry);
                        GlobalDeclaration.dayCount = Convert.ToInt32(txtNoDays.Text);
                        if (m > 0)
                        {
                            XtraMessageBox.Show("Record saved successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Oops something went wrong!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        GlobalDeclaration.dayCount = Convert.ToInt32(txtNoDays.Text);
                        if (updateworkDaysEvent != null)
                            //GlobalDeclaration.dayList =txtRemarks.Text;
                            updateworkDaysEvent.Invoke(sender, GlobalDeclaration.dayCount);
                        if (SomeEvent != null)
                        {                           
                            SomeEvent.Invoke(GlobalDeclaration.dayCount, cmbOpUnit.Text, cmbMonthCalendar.Text);
                        }
                        //if (updateCalendarEvent != null)
                        //    //GlobalDeclaration.dayList =txtRemarks.Text;
                        //    updateCalendarEvent.Invoke(sender, GlobalDeclaration.dayCount);
                        // prdmaster.Show();
                        Task.Delay(8000);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Please check the working days", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNoDays.Focus();
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    if (string.IsNullOrEmpty(txtNoDays.Text))
                    {
                        XtraMessageBox.Show("Production Calendar cannot be left empty!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        validateDaysEntered();
                        if (validPrpty == 0)
                        {
                            var countryIDs = tds.AsEnumerable().Where(row => row.Field<string>("MonthName") == monthId.ToString()).FirstOrDefault();
                            int n = 0;
                            if (countryIDs == null)
                            {
                                n = DalService.AddProductionCalendar(monthId.ToString(), DateTime.Now.Year, txtNoDays.Text, 1);
                            }
                            else
                            {
                                n = DalService.UpdateProductionCalendar(GlobalDeclaration.dayList.ToString(), monthId);
                            }
                            //if (updateCalendarEvent != null)
                            //    updateCalendarEvent.Invoke(sender, GlobalDeclaration.dayList);
                            if (n > 0)
                            {
                                XtraMessageBox.Show("Record updated successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                XtraMessageBox.Show("Oops something went wrong!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            GlobalDeclaration.dayCount = Convert.ToInt32(txtNoDays.Text);
                            ////if (updateworkDaysEvent != null)
                                //GlobalDeclaration.dayList =txtRemarks.Text;
                                ////updateworkDaysEvent.Invoke(sender, GlobalDeclaration.dayCount);
                            if (SomeEvent != null)
                            {
                                SomeEvent.Invoke(GlobalDeclaration.dayCount, cmbOpUnit.Text, cmbMonthCalendar.Text);
                            }
                            //if (updateCalendarEvent != null)
                            //    //GlobalDeclaration.dayList =txtRemarks.Text;
                            //    updateCalendarEvent.Invoke(sender, GlobalDeclaration.dayCount);
                            // prdmaster.Show();
                            Task.Delay(8000);
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("Please check the working days", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNoDays.Focus();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                cmbMonthCalendar.Text = "";
                txtNoDays.Text = "";
                lblDaysErr.Visible = false;
                lblMonErr.Visible = false;
                FormCollection fc = Application.OpenForms;//ParentWindow
                foreach (Form frm in fc)
                {
                    if (frm.Name != "ProductMaster")
                    {
                        return;
                    }
                }
                this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Production_Calendar_Load(object sender, EventArgs e)
        {
            try
            {
                //switch (GlobalDeclaration.dayCount)
                // {
                //     case 0:
                //         {
                //             break;
                //         }
                //     case 1:
                //         {
                //             chkEdit.Checked = false;
                //             chkEdit.Enabled = false;
                //             btnSave.Text = "Update";
                //             break;
                //         }
                // }
                cmbMonthCalendar.DataSource = InitCalendar();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> InitCalendar()
        {
            try
            {
                CalendarList.Add("January");
                CalendarList.Add("February");
                CalendarList.Add("March");
                CalendarList.Add("April");
                CalendarList.Add("May");
                CalendarList.Add("June");
                CalendarList.Add("July");
                CalendarList.Add("August");
                CalendarList.Add("September");
                CalendarList.Add("October");
                CalendarList.Add("November");
                CalendarList.Add("December");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return CalendarList;
        }

        private void cmbMonthCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtNoDays.Focus();
                monthId = cmbMonthCalendar.SelectedIndex + 1;
                DataTable tds = new DataTable();
                tds = DalService.GetProductionCalendar("", DateTime.Now.Year, "", 1);
                var countryIDs = tds.AsEnumerable().Where(row => row.Field<string>("MonthName") == monthId.ToString()).FirstOrDefault();
                if (countryIDs != null)
                {
                    txtNoDays.Text = countryIDs[3].ToString();
                    btnSave.Text = "Update";
                    chkEdit.Checked = false;
                    chkEdit.Enabled = true;
                    txtNoDays.Enabled = false;
                }
                else
                {
                    txtNoDays.Text = "0";
                    btnSave.Text = "Save";
                    chkEdit.Checked = true;
                    chkEdit.Enabled = false;
                    txtNoDays.Enabled = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNoDays_TextChanged(object sender, EventArgs e)
        {

        }
        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Text = "Update";
                txtNoDays.Enabled = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNoDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtNoDays.Text.TrimStart(' ');
                txtNoDays.Focus();
                e.Handled = !(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void validateDaysEntered()
        {
            try
            {
                switch (cmbMonthCalendar.Text)
                {
                    case "January":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "February":
                        {
                            if (int.Parse(txtNoDays.Text) > 28)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "March":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "April":
                        {
                            if (int.Parse(txtNoDays.Text) > 30)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "May":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "June":
                        {
                            if (int.Parse(txtNoDays.Text) > 30)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "July":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "August":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "September":
                        {
                            if (int.Parse(txtNoDays.Text) > 30)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "October":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "November":
                        {
                            if (int.Parse(txtNoDays.Text) > 30)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                    case "December":
                        {
                            if (int.Parse(txtNoDays.Text) > 31)
                            {
                                validPrpty = 0;
                            }
                            break;
                        }
                }
                if (txtNoDays.Text.Length == 0)
                {
                    lblDaysErr.Visible = true;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNoDays_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (txtNoDays.Text == "")
                {
                    return;
                }
                if (txtNoDays.Text == "0")
                {
                    XtraMessageBox.Show("Working days cannot be set to 0", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoDays.Focus();
                }
                if (int.Parse(txtNoDays.Text) > 31)
                {
                    XtraMessageBox.Show("Working days cannot be greater then 31", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoDays.Focus();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}