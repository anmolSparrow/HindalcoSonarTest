using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using HindalcoiOS.Models;
using HindalcoiOS.DAL;

namespace HindalcoiOS.Operation
{
    public partial class CalendarSelection : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> updateCalendarEvent;
        public ProductMaster prodMaster { get; set; }
        public ServiceDAL DalService { get; set; }
        public CalendarSelection()
        {
            DalService = new ServiceDAL();
            prodMaster = new ProductMaster();
            InitializeComponent();
        }

        #region "variable Declaration"
        DataTable prodData = null;
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
                // lblProdNo.Text = RptNo;
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
                //cmbPlantName.DataSource = Enum.GetValues(typeof(PlantName));
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
                //  ObjectToClassMapper();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ObjectToClassMapper()
        //{
        //    try
        //    {
        //        prodMaster .ProdName= txtProdName.Text;
        //        prodMaster.ProdCode =txtProdCode.Text;
        //        prodMaster.PlantName = cmbPlantName.Text;
        //        prodMaster.UniqCode = lblProdNo.Text;
        //        prodMaster.DateAdded =Convert.ToDateTime(lblDatetime.Text);
        //        prodMaster.CreatedBy = adminCode;
        //        prodMaster.RoleId = RoleId;
        //        // int m = DalService.AddNearMissUAUCRequestor(nearMiss);
        //        AddMessage();
        //        int m=  ObjectToDALMApper();
        //        if (m > 0)
        //        {
        //            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[0], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //        getProductDetails();
        //        btnSave.Text = "Save";

        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}      

        //private void getProductDetails()
        //{
        //    try
        //    {
        //        prodData = Resources.Instance.GetProductMaster_RMPCL("", "", "", DateTime.Now, "", "", 0, 2);
        //        if (prodData.Rows.Count > 0)
        //        {
        //            DGVProdGrid.DataSource = prodData;
        //        }
        //        DGVProdGrid.Columns["ProdId"].Visible = false;
        //       // DGVProdGrid.Columns["RoleId"].Visible = false;
        //      //  DGVProdGrid.Columns["ProdId"].Visible = false;
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private int ObjectToDALMApper()
        //{
        //    if (btnSave.Text == "Save")
        //    {
        //        retVal = DalService.AddProductMaster(prodMaster, 1);
        //    }
        //    else
        //    {
        //        retVal = DalService.AddProductMaster(prodMaster, 3);
        //    }
        //    return retVal;
        //}

        //private void btnSubmitClose_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ObjectToClassMapper();
        //        // ResetControls();
        //        this.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            try
            {
                //lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                // GenerateReport();
                //  AddComboValues();
                // GetAdminCode();
                //getProductDetails();
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

        }
        private void DateCalendarGrp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                bool IsExist = SeachListEmp(DateCalendarGrp.SelectionStart.ToString("dd"));
                if (IsExist == false)
                {
                    string selectedEmp = DateCalendarGrp.SelectionStart.ToString("dd") + ",";
                    lstDatreCalendar.Items.Add(selectedEmp);
                    //for (int j = 0; j < lstDatreCalendar.Items.Count; j++)
                    //{
                    //   // emplList = emplList + lstEmp.Items[j].Text;
                    //}
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SeachListEmp(string StringToSearch)
        {
            bool RetVal = false;
            try
            {
                string iSearch = StringToSearch.ToLower();
                foreach (ListViewItem item in lstDatreCalendar.Items)
                {
                    if (item.Text.ToLower().Contains(iSearch))
                    {
                        RetVal = true;
                    }
                }
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return RetVal;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lstDatreCalendar.Items.Count; i++)
                {
                    GlobalDeclaration.dayList = lstDatreCalendar.Items[i].Text.ToString() + GlobalDeclaration.dayList;
                    GlobalDeclaration.dayCount = i + 1;
                }
                int lstind = GlobalDeclaration.dayList.LastIndexOf(',');
                GlobalDeclaration.dayList = GlobalDeclaration.dayList.Remove(lstind);
                if (updateCalendarEvent != null)
                    updateCalendarEvent.Invoke(sender, GlobalDeclaration.dayList);
                this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void CalendarSelection_Load(object sender, EventArgs e)
        {

        }
    }
}