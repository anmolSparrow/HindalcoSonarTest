
using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using HindalcoiOS.Class_Operation;
//using// HindalcoiOS.Properties;
using SparrowRMS;
using SparrowRMSControl.SparrowControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.InventoryMgmt
{
    public partial class ManageInventoryView : XtraForm
    {
        public EventHandler<string> GetValue;
       // public event SomeEvents GetValue;
        public ItemProcurement itemProcurement { get; set; }
        public ItemConsumption itemConsumption { get; set; }
        public ItemStock ItemStock { get; set; }
        public ItemReturn itemReturn { get; set; }
        public MailDetail mailDetail { get; set; }
        public ManageInventoryView()
        {
            InitializeComponent();
            itemProcurement = new ItemProcurement();
            if (String.IsNullOrEmpty(txtProcStatus.Text))
            {
                itemProcurement.Status = InvStatus.Prepare;
                txtProcStatus.Text = itemProcurement.Status.ToString();
            }
            itemConsumption = new ItemConsumption();
            if (String.IsNullOrEmpty(txtConsumpStatus.Text))
            {
                itemConsumption.Status = InvStatus.Prepare;
                txtConsumpStatus.Text = itemConsumption.Status.ToString();
            }
            ItemStock = new ItemStock();
            itemReturn = new ItemReturn();
            //UAUC.CurrentUserRole = UAUC.GetAllUsers().AsEnumerable().Where(X => X.Field<string>("UserName") == GlobalDeclaration._holdInfo[0].rol).ToList().FirstOrDefault()["RoleID"].ToString();
        }
        private void ItemProcurementView_Load(object sender, EventArgs e)
        {
            //GenerateProcureId("SP_GetProcDocID", "PUR");
            //GenerateGlobalDocID("SP_GetProcDocID", "PUR");
            //ShowHideStockGrid();
            DisableControlPermanent();
            HideTabControlPagesHeader(InventoryPages);
            HideTabControlPagesHeader(pgProcureLogPages);
            gbxBatchWiseStock.Visible = false;
            gbxAllStockDetail.Visible = true;
            HideProcureGroupBoxes();
            HideConsumpGroupBoxes();
            HideReturnGroupBoxes();
            ViewAllStockData();
            LoadAllMasters();
            ViewProcureData();
            ViewConsumptionData();
            ViewReturnData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MapProcurementToData();
                if (txtProcStatus.Text == InvStatus.Open.ToString())
                    XtraMessageBox.Show("Data updated Successfully.");
                else
                    XtraMessageBox.Show("Data Saved Successfully.");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvProcureGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                btnProcureDelete.Visible = true;
                dtpProcDate.Text = dgvProcureGrid.Rows[e.RowIndex].Cells["PurchaseDate"].Value.ToString();
                dtpDocDate.Text = dgvProcureGrid.Rows[e.RowIndex].Cells["DocumentDate"].Value.ToString();
                cmbVendor.Text = dgvProcureGrid.Rows[e.RowIndex].Cells["Vendor"].Value.ToString();
                txtProcDocNo.Text = dgvProcureGrid.Rows[e.RowIndex].Cells["DocumentNo"].Value.ToString();
                txtProcBillNo.Text = dgvProcureGrid.Rows[e.RowIndex].Cells["BillNo"].Value.ToString();
                txtProcStatus.Text = dgvProcureGrid.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                dgvProcureItemDetailgrid.Enabled = true;
                LoadVendors();
                ViewProcureDetailData();
                ShowProcureGroupBoxes();
                ControlProcureEnability();
                //if (txtProcStatus.Text == InvStatus.Closed.ToString())
                //   {
                //       btnProcureDelete.Visible = false;
                //       btnProcureClose.Visible = false;
                //       btnAddItemDetail.Visible = false;
                //       btnAddVendor.Visible = false;
                //       btnProcureSave.Visible = false;
                //       txtProcBillNo.Enabled = false;
                //       cmbVendor.Enabled = false;
                //       dtpProcDate.Enabled = false;
                //       dgvProcureItemDetailgrid.Enabled = false;
                //       btnAddVendor.Visible = false;

                //}
                //if (txtProcStatus.Text == InvStatus.Prepare.ToString())
                //{
                //    btnProcureDelete.Visible = false;
                //    btnProcureClose.Visible = false;
                //    btnAddItemDetail.Visible = true;
                //    btnAddVendor.Visible = true;
                //    btnProcureSave.Visible = false;
                //    txtProcBillNo.Enabled = true;
                //    cmbVendor.Enabled = true;
                //    dtpProcDate.Enabled = true;
                //}
                //if (txtProcStatus.Text == InvStatus.Open.ToString())
                //{
                //    btnProcureDelete.Visible = true;
                //    btnProcureClose.Visible = true;
                //    btnAddItemDetail.Visible = true;
                //    btnAddVendor.Visible = true;
                //    btnProcureSave.Visible = true;
                //    txtProcBillNo.Enabled = true;
                //    cmbVendor.Enabled = true;
                //    dtpProcDate.Enabled = true;
                //}


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConsumAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MapConsumptionData();
                if (txtConsumpStatus.Text == InvStatus.Open.ToString())
                    XtraMessageBox.Show("Data updated Successfully.");
                else
                    XtraMessageBox.Show("Data Saved Successfully.");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReturnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MapReturnData();
                if (txtReturnStatus.Text == InvStatus.Open.ToString())
                    XtraMessageBox.Show("Data updated Successfully.");
                else
                    XtraMessageBox.Show("Data Saved Successfully.");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ////private void CheckUnitData()
        ////{
        ////    string name = cmbUnit.SelectedItem.ToString();
        ////    if (name == "Add New Unit")
        ////    {
        ////        UOMView uOMView = new UOMView();
        ////        uOMView.GetVakue += UnitAddHandlerEvent;
        ////        //uOMView.UOM.UnitCode;
        ////        if (uOMView.ShowDialog() == DialogResult.OK)
        ////        {
        ////            uOMView.Close();
        ////            uOMView.Dispose();
        ////        }
        ////    }
        ////}
        //private void UnitAddHandlerEvent(object sender, string value)
        //{
        //    if (!cmbUnit.Items.Contains(value))
        //    {
        //        cmbUnit.Items.Add(value);
        //        DialogResult = DialogResult.OK;
        //    }
        //}

        private void ViewMailDetail()
        {
            MailDetailView mailView = new MailDetailView();
            mailView.GetValue += MailView_GetValue; ;

            if (mailView.ShowDialog() == DialogResult.OK)
            {
                mailView.Close();
                mailView.Dispose();
            }
            else
            {
                mailView.Close();
                mailView.Dispose();
            }
        }

        private void MailView_GetValue(params object[] args)
        {
            mailDetail = (MailDetail)args[0];
        }

        private void AddItemDetailHandlerEvent(object sender, string value)
        {
            //if (!cmbUnit.Items.Contains(value))
            //{
            //    cmbUnit.Items.Add(value);
            //    DialogResult = DialogResult.OK;
            //}
        }

        private void txtStockSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dgvViewStockGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("Item like '{0}%' OR ItemCode like '{0}%' OR Make like '{0}%' OR Model like '{0}%' OR Category like '{0}%' OR SubCategory like '{0}%'", txtStockSearch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtReturnSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //(dgvReturnGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("DocumentNo like '{0}%' OR ReferenceNo like '{0}%'", txtReturnSearch.Text);
                ViewReturnData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProcSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ViewProcureData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConsumpSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ViewConsumptionData();
                //(dgvConsumpGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format(" DocumentNo like '{0}%' OR ReferenceNo like '{0}%'", txtConsumpSearch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvConsumpGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                btnConsumeDelete.Visible = true;
                
                txtConsumpDocNo.Text = dgvConsumpGrid.Rows[e.RowIndex].Cells["ConsumpDocumentNo"].Value.ToString();
                txtConsumpRefNo.Text = dgvConsumpGrid.Rows[e.RowIndex].Cells["ConsumpReferenceNo"].Value.ToString();
                dtpConsumpDate.Text = dgvConsumpGrid.Rows[e.RowIndex].Cells["ConsumpDocumentDate"].Value.ToString();
                cmbConsumpType.Text = dgvConsumpGrid.Rows[e.RowIndex].Cells["ConsumpConsumptionType"].Value.ToString();
                txtConsumpRemark.Text = dgvConsumpGrid.Rows[e.RowIndex].Cells["ConsumpRemarks"].Value.ToString();
                txtConsumpStatus.Text = dgvConsumpGrid.Rows[e.RowIndex].Cells["ConsumpStatus"].Value.ToString();
                dgvConsumpDetailGrid.Enabled = true;
               
                ShowConsumpGroupBoxes();
                ControlConsumpEnability();
                ViewConsumptionDetailData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InventoryPages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAvaiStock_Click(object sender, EventArgs e)
        {
            InventoryPages.SelectedIndex = 0;
            ViewAllStockData();
            gbxBatchWiseStock.Visible = false;
            gbxAllStockDetail.Visible = true;
            //lblStockConsumedLog.Text = "Stock Consumed Log";
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            InventoryPages.SelectedIndex = 1;
            ViewProcureData();
            HideProcureGroupBoxes();


        }

        private void btnStockDetails_Click(object sender, EventArgs e)
        {
            //gbxProcureBatchDetail.Visible = false;
            InventoryPages.SelectedIndex = 2;
            ViewAllProcureDetailData();
            gbxProcureBatchDetail.Visible = false;
            gbxProcureAllDetail.Visible = true;


        }

        private void btnConsumption_Click(object sender, EventArgs e)
        {
            InventoryPages.SelectedIndex = 3;
            ViewConsumptionData();
            HideConsumpGroupBoxes();
        }

        private void btnConsumptionDetails_Click(object sender, EventArgs e)
        {
            InventoryPages.SelectedIndex = 4;
            ViewConsumptionLogData();
            //ViewAllConsumptionDetailData();
            gbxConsumeDetailLog.Visible = true;
            gbxAllConsumeDetail.Visible = false;
        }

        private void btnProcure_Click(object sender, EventArgs e)
        {
            InventoryPages.SelectedIndex = 5;
            ViewThresholdProcureDetail();
        }

        private void btnStockReturn_Click(object sender, EventArgs e)
        {
            InventoryPages.SelectedIndex = 6;
            ViewReturnData();
            HideReturnGroupBoxes();
        }
        public void LoadAllMasters()
        {
            //LoadItems();
            //LoadUnits();
            //LoadVendors();
        }
        private void LoadItems()
        {
            itemProcurement.LoadItem = itemProcurement.LoadItemMaster();

            var itemcount = itemProcurement.LoadItem.Rows.Count;
            for (int i = 0; i < itemcount; i++)
            {
                //cmbProcureItem.Items.Add(itemProcurement.LoadItem.Rows[i]["ItemName"]);
                //cmbConsumpItem.Items.Add(itemProcurement.LoadItem.Rows[i]["ItemName"]);
                //cmbReturnItem.Items.Add(itemProcurement.LoadItem.Rows[i]["ItemName"]);
            }
            //cmbProcureItem.Items.Add("Add New Item");

        }
        private void LoadUnits()
        {
            int unitCount = itemProcurement.LoadUnitMaster().Rows.Count;
            for (int i = 0; i < unitCount; i++)
            {
                //cmbUnit.Items.Add(itemProcurement.LoadUnitMaster().Rows[i]["UnitName"]);
            }
            //cmbUnit.Items.Add("Add New Unit");

        }

        private void LoadVendors()
        {
            itemProcurement.LoadVendor = itemProcurement.LoadVendorMaster();
            int unitCount = itemProcurement.LoadVendor.Rows.Count;
            for (int i = 0; i < unitCount; i++)
            {
                cmbVendor.Items.Add(itemProcurement.LoadVendor.Rows[i]["VendorName"]);
            }
            //cmbVendor.Items.Add("Add New Vendor");
        }

        private void MapProcurementToData()
        {
            try
            {
                if (ValidateProcurement() == false) return;
                itemProcurement.DocumentNo = txtProcDocNo.Text;
                itemProcurement.PurchaseDate = Convert.ToDateTime(dtpProcDate.Value);
                itemProcurement.DocDate = Convert.ToDateTime(dtpDocDate.Value);
                itemProcurement.LoadVendor = itemProcurement.LoadVendorMaster();
                if (cmbVendor.SelectedItem != null)
                {
                    itemProcurement.Vendor = cmbVendor.SelectedItem.ToString();
                    itemProcurement.VendorCode = itemProcurement.LoadVendor.AsEnumerable().Where(X => X.Field<string>("vendorName") == itemProcurement.Vendor).ToList().FirstOrDefault()["vendorCode"].ToString();
                }
                else
                {
                    itemProcurement.Vendor = cmbVendor.Text;
                    itemProcurement.VendorCode = itemProcurement.LoadVendor.AsEnumerable().Where(X => X.Field<string>("vendorName") == itemProcurement.Vendor).ToList().FirstOrDefault()["vendorCode"].ToString();
                }
                itemProcurement.BillNo = txtProcBillNo.Text;
                if (txtProcStatus.Text == InvStatus.Prepare.ToString())
                {
                    itemProcurement.Status = InvStatus.Open;
                    txtProcStatus.Text = InvStatus.Open.ToString();
                }
                itemProcurement.SetProcurementValue(itemProcurement);
                ViewProcureData();
                txtProcStatus.Text = itemProcurement.Status.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MapConsumptionData()
        {
            try
            {
                itemConsumption.DocumentNo = txtConsumpDocNo.Text;
                itemConsumption.ReferenceNo = txtConsumpRefNo.Text;
                itemConsumption.DocumentDate = DateTime.Parse(dtpConsumpDate.Text);
                itemConsumption.Remarks = txtConsumpRemark.Text;
                itemConsumption.ConsumptionType = cmbConsumpType.Text;
                itemConsumption.Status = (InvStatus)Enum.Parse(typeof(InvStatus), txtConsumpStatus.Text);
                if (txtConsumpStatus.Text == InvStatus.Prepare.ToString())
                {
                    itemConsumption.Status = InvStatus.Open;
                    txtConsumpStatus.Text = InvStatus.Open.ToString();
                }
               
               
                itemConsumption.SetConsumptionValue(itemConsumption);
                ViewConsumptionData();
                txtConsumpStatus.Text = itemConsumption.Status.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MapReturnData()
        {
            itemReturn.DocumentNo = txtReturnDocNo.Text;
            itemReturn.DocumentDate = DateTime.Parse(dtpReturnDocDate.Text);
            itemReturn.ReferenceNo = txtReturnRefNo.Text;
            itemReturn.Remarks = txtReturnRemarks.Text;
            itemReturn.ConsumptionType = cmbReturnConsumpType.Text;
            itemReturn.Status = (InvStatus)Enum.Parse(typeof(InvStatus), txtReturnStatus.Text);
            if (txtReturnStatus.Text == InvStatus.Prepare.ToString())
            {
                itemReturn.Status = InvStatus.Open;
                txtReturnStatus.Text = InvStatus.Open.ToString();
            }
            itemReturn.SetReturnValue(itemReturn);
            ViewReturnData();
            txtReturnStatus.Text = itemReturn.Status.ToString();
        }

        private void ViewProcureData()
        {
            try
            {
                //DataTable dt= itemProcurement.GetProcurement();
               DataTable dtt= itemProcurement.GetProcurement();
                if (dtt.Rows.Count == 0 || dtt.AsEnumerable().Where(X => X.Field<int>("Status") == 1).Count() == 0)
                {
                    dgvProcureGrid.Rows.Clear();
                    return;
                }
                DataTable dt = itemProcurement.GetProcurement().AsEnumerable().Where(X => X.Field<int>("Status") == 1).CopyToDataTable();
                if (dgvProcureGrid.Rows.Count > 0)
                    dgvProcureGrid.Rows.Clear();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvProcureGrid.Rows.Add(dr);
                        int index = dgvProcureGrid.Rows.Count - 1;
                        dgvProcureGrid.Rows[index].Cells["DocumentNo"].Value = dt.Rows[i]["DocumentNo"];
                        dgvProcureGrid.Rows[index].Cells["BillNo"].Value = dt.Rows[i]["BillNo"];
                        dgvProcureGrid.Rows[index].Cells["Vendor"].Value = dt.Rows[i]["Vendor"].ToString();
                        dgvProcureGrid.Rows[index].Cells["PurchaseDate"].Value = ((DateTime)dt.Rows[i]["PurchaseDate"]).ToString("dd-MM-yyyy");
                        dgvProcureGrid.Rows[index].Cells["DocumentDate"].Value = ((DateTime)dt.Rows[i]["DocumentDate"]).ToString("dd-MM-yyyy"); //dt.Rows[i]["DocumentDate"];
                        dgvProcureGrid.Rows[index].Cells["Status"].Value = ((InvStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        dgvProcureGrid.Visible = true;
                    }
                }

                dgvProcureGrid.Sort(dgvProcureGrid.Columns["PurchaseDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ViewProcureFilterData()
        //{
        //    try
        //    {
        //        DataTable dt = itemProcurement.GetProcurement();
        //        if (dgvProcureGrid.Rows.Count > 0)
        //            dgvProcureGrid.Rows.Clear();

        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                DataGridViewRow dr = new DataGridViewRow();
        //                dgvProcureGrid.Rows.Add(dr);
        //                int index = dgvProcureGrid.Rows.Count - 1;
        //                dgvProcureGrid.Rows[index].Cells["DocumentNo"].Value = dt.Rows[i]["DocumentNo"];
        //                dgvProcureGrid.Rows[index].Cells["BillNo"].Value = dt.Rows[i]["BillNo"];
        //                dgvProcureGrid.Rows[index].Cells["Vendor"].Value = dt.Rows[i]["Vendor"].ToString();
        //                dgvProcureGrid.Rows[index].Cells["PurchaseDate"].Value = ((DateTime)dt.Rows[i]["PurchaseDate"]).ToString("dd-MM-yyyy");
        //                dgvProcureGrid.Rows[index].Cells["DocumentDate"].Value = ((DateTime)dt.Rows[i]["DocumentDate"]).ToString("dd-MM-yyyy"); //dt.Rows[i]["DocumentDate"];
        //                dgvProcureGrid.Rows[index].Cells["Status"].Value = ((InvStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
        //                dgvProcureGrid.Visible = true;
        //            }
        //        }
        //        if (txtProcSearch.Text != string.Empty)
        //        {
        //            foreach (DataGridViewRow row in dgvProcureGrid.Rows)
        //            {
        //                //string ss= row.Cells["DocumentNo"].Value.ToString();
        //                if (row.Cells["DocumentNo"].Value.ToString() == txtProcSearch.Text)
        //                {
        //                    row.Visible = true;
        //                }
        //                else
        //                    row.Visible = false;
        //            }
        //        }
        //        //if (txtProcSearch.Text != string.Empty)

        //        //    dgvProcureGrid.Rows.OfType<DataGridViewRow>().Where(r => r.Cells["BillNo"].Value.ToString() == txtProcSearch.Text.Trim()).ToList().ForEach(row => { if (!row.IsNewRow) row.Visible = true; });
        //        //else
        //        //    dgvProcureGrid.Rows.OfType<DataGridViewRow>().ToList().ForEach(row => { if (!row.IsNewRow) row.Visible = true; });
        //        dgvProcureGrid.Sort(dgvProcureGrid.Columns["PurchaseDate"], ListSortDirection.Descending);
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void FilterProcureGridData()
        {
            try
            {
                if (txtProcSearch.Text != string.Empty && dgvProcureGrid.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvProcureGrid.Rows)
                    {
                        //string ss= row.Cells["DocumentNo"].Value.ToString();
                        if (row.Cells["DocumentNo"].Value.ToString() == txtProcSearch.Text || row.Cells["BillNo"].Value.ToString() == txtProcSearch.Text || row.Cells["Status"].Value.ToString().ToUpper() == txtProcSearch.Text.ToUpper()
                           || row.Cells["Vendor"].Value.ToString().ToUpper() == txtProcSearch.Text.ToUpper() || row.Cells["DocumentDate"].Value.ToString() == txtProcSearch.Text)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
                dgvProcureGrid.Sort(dgvProcureGrid.Columns["PurchaseDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterConsumpGridData()
        {
            try
            {
                if (txtConsumpSearch.Text != string.Empty && dgvConsumpGrid.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvConsumpGrid.Rows)
                    {
                        //string ss= row.Cells["DocumentNo"].Value.ToString();
                        if (row.Cells["ConsumpDocumentNo"].Value.ToString().ToUpper() == txtConsumpSearch.Text.ToUpper() || row.Cells["ConsumpReferenceNo"].Value.ToString() == txtConsumpSearch.Text || row.Cells["ConsumpStatus"].Value.ToString().ToUpper() == txtConsumpSearch.Text.ToUpper()
                           || row.Cells["ConsumpConsumptionType"].Value.ToString().ToUpper() == txtConsumpSearch.Text.ToUpper() || row.Cells["ConsumpDocumentDate"].Value.ToString() == txtConsumpSearch.Text)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
                dgvConsumpGrid.Sort(dgvConsumpGrid.Columns["ConsumpDocumentDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterReturnGridData()
        {
            try
            {
                if (txtReturnSearch.Text != string.Empty && dgvReturnGrid.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvReturnGrid.Rows)
                    {
                        //string ss= row.Cells["DocumentNo"].Value.ToString();
                        if (row.Cells["ReturnDocumentNo"].Value.ToString().ToUpper() == txtReturnSearch.Text.ToUpper() || row.Cells["ReturnReferenceNo"].Value.ToString() == txtReturnSearch.Text || row.Cells["ReturnStatus"].Value.ToString().ToUpper() == txtReturnSearch.Text.ToUpper()
                           || row.Cells["ReturnConsumptionType"].Value.ToString().ToUpper() == txtReturnSearch.Text.ToUpper() || row.Cells["ReturnDocumentDate"].Value.ToString() == txtReturnSearch.Text)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
                dgvReturnGrid.Sort(dgvReturnGrid.Columns["ReturnDocumentDate"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Stock Detail Log
        private void ViewProcureDetailData()
        {
            dgvProcureItemDetailgrid.DataSource = Resources.Instance.GetProcureItemDetail(txtProcDocNo.Text);
            dgvProcureItemDetailgrid.Columns["ItemCode"].Visible = false;
            dgvProcureItemDetailgrid.Columns["UnitCode"].Visible = false;
            dgvProcureItemDetailgrid.Columns["DocumentNo"].Visible = false;
            dgvProcureItemDetailgrid.Columns["DocDate"].Visible = false;
            dgvProcureItemDetailgrid.Columns["Vendor"].Visible = false;
            dgvProcureItemDetailgrid.Columns["BillNo"].Visible = false;
            dgvProcureItemDetailgrid.Columns["BatchNo"].HeaderText = "Batch No.";
            dgvProcureItemDetailgrid.Columns["ProcureQty"].HeaderText = "Procure Qty.";
            dgvProcureItemDetailgrid.Columns["TotalCost"].HeaderText = "Total Cost";
            dgvProcureItemDetailgrid.Columns["UnitCost"].HeaderText = "Unit Cost";
            dgvProcureItemDetailgrid.Sort(dgvProcureItemDetailgrid.Columns["DocDate"], ListSortDirection.Descending);
        }
        //Stock Detail Log Report
        private void ViewAllProcureDetailData()
        {
            try
            {
                //dgvProcureAllDetailGrid.DataSource = Resources.Instance.GetAllProcurement();
                if (Resources.Instance.GetAllProcurement().Rows.Count == 0) return;
                dgvProcureAllDetailGrid.DataSource = Resources.Instance.GetAllProcurement().AsEnumerable().Where(X => X.Field<int>("Status") == 2).CopyToDataTable();
                dgvProcureAllDetailGrid.Columns["Status"].Visible = false;
                dgvProcureAllDetailGrid.Columns["DocumentNo"].HeaderText = "Document No.";
                dgvProcureAllDetailGrid.Columns["DocumentDate"].HeaderText = "Document Date";
                dgvProcureAllDetailGrid.Columns["PurchaseDate"].HeaderText = "Purchase Date";
                dgvProcureAllDetailGrid.Columns["BillNo"].HeaderText = "Bill No";
                dgvProcureAllDetailGrid.Columns["VendorCode"].HeaderText = "Vendor Code";
                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ViewConsumptionData()
        {
            try
            {
                DataTable dt = itemConsumption.GetConsumption();
                if (dt.Rows.Count == 0) return;
                dt = itemConsumption.GetConsumption().AsEnumerable().Where(X => X.Field<int>("Status") == 1).CopyToDataTable();
                if (dgvConsumpGrid.Rows.Count > 0)
                    dgvConsumpGrid.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvConsumpGrid.Rows.Add(dr);
                        int index = dgvConsumpGrid.Rows.Count - 1;
                        dgvConsumpGrid.Rows[index].Cells["ConsumpDocumentNo"].Value = dt.Rows[i]["DocumentNo"];
                        dgvConsumpGrid.Rows[index].Cells["ConsumpReferenceNo"].Value = dt.Rows[i]["ReferenceNo"];
                        dgvConsumpGrid.Rows[index].Cells["ConsumpConsumptionType"].Value = dt.Rows[i]["ConsumptionType"].ToString();
                        dgvConsumpGrid.Rows[index].Cells["ConsumpRemarks"].Value = dt.Rows[i]["Remarks"];
                        dgvConsumpGrid.Rows[index].Cells["ConsumpDocumentDate"].Value = ((DateTime)dt.Rows[i]["DocumentDate"]).ToString("dd-MM-yyyy");// dt.Rows[i]["DocumentDate"];
                        dgvConsumpGrid.Rows[index].Cells["ConsumpStatus"].Value = ((InvStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        dgvConsumpGrid.Sort(dgvConsumpGrid.Columns["ConsumpDocumentDate"], ListSortDirection.Descending);
                        dgvConsumpGrid.Visible = true;
                        dgvConsumpGrid.Columns["ConsumpDocumentNo"].HeaderText = "Document No";
                        
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ViewConsumptionLogData()
        {
            if (itemConsumption.GetConsumption().Rows.Count == 0) return;
            //dgvStockConsumedLog.DataSource = itemConsumption.GetConsumption();
            dgvStockConsumedLog.DataSource = itemConsumption.GetConsumption().AsEnumerable().Where(X => X.Field<int>("Status") == 2).CopyToDataTable();
            dgvStockConsumedLog.Columns["Status"].Visible = false;
            //dgvConsumpGrid.Columns["ItemCode"].Visible = false;
            //dgvConsumpGrid.Columns["UnitCode"].Visible = false;
            dgvStockConsumedLog.Columns["DocumentNo"].HeaderText = "Document No.";
            dgvStockConsumedLog.Columns["DocumentDate"].HeaderText = "Document Date";
            dgvStockConsumedLog.Columns["ReferenceNo"].HeaderText = "Reference No.";
            dgvStockConsumedLog.Columns["ConsumptionType"].HeaderText = "Consumption Type";
            DataTable dt = itemConsumption.GetConsumption();
        }
        private void ViewConsumptionDetailData()
        {
            //btnConsumAdd.Visible = false;
            //btnConsumClose.Visible = false;

            DataTable dt = Resources.Instance.GetConsumedItemDetail(txtConsumpDocNo.Text, txtConsumpRefNo.Text);
            dgvConsumpDetailGrid.DataSource = dt;
            dgvConsumpDetailGrid.Columns["ItemCode"].Visible = false;
            dgvConsumpDetailGrid.Columns["UnitCode"].Visible = false;
            dgvConsumpDetailGrid.Columns["ReferenceNo"].Visible = false;
            dgvConsumpDetailGrid.Columns["DocumentNo"].Visible = false;
            dgvConsumpDetailGrid.Columns["MinimumStock"].HeaderText = "Minimum Stock";
            dgvConsumpDetailGrid.Columns["BatchNo"].HeaderText = "Batch No";
            dgvConsumpDetailGrid.Columns["ConsumedQty"].HeaderText = "Consumed Qty";
            dgvConsumpDetailGrid.Columns["UnitCost"].HeaderText = "Unit Cost";
            dgvConsumpDetailGrid.Columns["TotalCost"].HeaderText = "Total Cost";
            if (dt.Rows.Count == 0 && txtConsumpStatus.Text == InvStatus.Open.ToString())
            {
                btnConsumAdd.Visible = false;
                btnConsumClose.Visible = false;
            }
        }

        //private void ViewAllConsumptionDetailData()
        //{
        //    //dgvAllConsumeDetailGrid.DataSource = Resources.Instance.GetAllConsumedItemDetail();
        //    //dgvAllConsumeDetailGrid.Columns["ItemCode"].Visible = false;
        //    //dgvAllConsumeDetailGrid.Columns["UnitCode"].Visible = false;
        //    //dgvAllConsumeDetailGrid.Columns["ReferenceNo"].Visible = false;
        //    //dgvAllConsumeDetailGrid.Columns["DocumentNo"].Visible = false;
        //    //dgvAllConsumeDetailGrid.Sort(dgvAllConsumeDetailGrid.Columns["DocumentDate"], ListSortDirection.Descending);

        //    //dgvAllConsumeDetailGrid.DataSource = Resources.Instance.GetAllConsumedItemDetailWithReturn();
        //    dgvAllConsumeDetailGrid.Columns["ItemCode"].Visible = false;
        //    dgvAllConsumeDetailGrid.Columns["UnitCode"].Visible = false;
        //    dgvAllConsumeDetailGrid.Sort(dgvAllConsumeDetailGrid.Columns["DocumentDate"], ListSortDirection.Descending);
        //}
        private void ViewReturnData()
        {
            try
            {
                DataTable dt = itemReturn.GetReturn();
                //DataTable dt = itemReturn.GetReturn().AsEnumerable().Where(X => X.Field<int>("Status") == 1).CopyToDataTable();
                if (dgvReturnGrid.Rows.Count > 0)
                    dgvReturnGrid.Rows.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvReturnGrid.Rows.Add(dr);
                        int index = dgvReturnGrid.Rows.Count - 1;
                        dgvReturnGrid.Rows[index].Cells["ReturnDocumentNo"].Value = dt.Rows[i]["DocumentNo"];
                        dgvReturnGrid.Rows[index].Cells["ReturnReferenceNo"].Value = dt.Rows[i]["ReferenceNo"];
                        dgvReturnGrid.Rows[index].Cells["ReturnConsumptionType"].Value = dt.Rows[i]["ConsumptionType"].ToString();
                        dgvReturnGrid.Rows[index].Cells["ReturnRemarks"].Value = dt.Rows[i]["Remarks"];
                        dgvReturnGrid.Rows[index].Cells["ReturnDocumentDate"].Value = ((DateTime)dt.Rows[i]["DocumentDate"]).ToString("dd-MM-yyyy");// dt.Rows[i]["DocumentDate"];
                        dgvReturnGrid.Rows[index].Cells["ReturnStatus"].Value = ((InvStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        dgvReturnGrid.Sort(dgvReturnGrid.Columns["ReturnDocumentDate"], ListSortDirection.Descending);
                        dgvReturnGrid.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ViewReturnDetailData()
        {
            btnReturnAdd.Visible = false;
            btnReturnAdd.Visible = false;
            DataTable dt = Resources.Instance.GetReturnItemDetail(txtReturnDocNo.Text, txtReturnRefNo.Text);
            dgvReturnDetailGrid.DataSource = dt;
            dgvReturnDetailGrid.Columns["ItemCode"].Visible = false;
            dgvReturnDetailGrid.Columns["UnitCode"].Visible = false;
            dgvReturnDetailGrid.Columns["ReferenceNo"].Visible = false;
            dgvReturnDetailGrid.Columns["DocumentNo"].Visible = false;
            dgvReturnDetailGrid.Columns["ItemCode"].HeaderText = "Item Code";
            dgvReturnDetailGrid.Columns["UnitCode"].HeaderText= "Unit Code";
            dgvReturnDetailGrid.Columns["ReferenceNo"].HeaderText = "Reference No.";
            dgvReturnDetailGrid.Columns["DocumentNo"].HeaderText = "Document No.";
            dgvReturnDetailGrid.Columns["MinimumStock"].HeaderText = "Minimum Stock";
            dgvReturnDetailGrid.Columns["BatchNo"].HeaderText = "Batch No.";
            dgvReturnDetailGrid.Columns["ReturnQty"].HeaderText = "Return Qty";
            dgvReturnDetailGrid.Columns["UnitCost"].HeaderText = "Unit Cost";
            dgvReturnDetailGrid.Columns["TotalCost"].HeaderText = "Total Cost";
            if (dt.Rows.Count > 0 && txtReturnStatus.Text == InvStatus.Open.ToString())
            {
                btnReturnAdd.Visible = true;
                btnReturnAdd.Visible = true;
            }
        }
        private void ViewThresholdProcureDetail()
        {
            dgvProcureLogDetailGrid.DataSource = Resources.Instance.GetThresholdProcureDetail();
            dgvProcureLogDetailGrid.Columns["ItemCode"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Item"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Category"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Sub Category"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Make"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Model"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Unit"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["AvailableQty"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["Minimum Stock"].ReadOnly = true;
            dgvProcureLogDetailGrid.Columns["ItemCode"].HeaderText = "Item Code";
            dgvProcureLogDetailGrid.Columns["AvailableQty"].HeaderText = "Available Qty";
        }
        private void ViewAllStockData()
        {
            dgvViewStockGrid.DataSource = ItemStock.GetStock();
            dgvViewStockGrid.Columns["ItemCode"].HeaderText = "Item Code";
            dgvViewStockGrid.Columns["SubCategory"].HeaderText = "Sub Category";
            dgvViewStockGrid.Columns["AvailableQty"].HeaderText = "Available Qty";
           
            //dgvViewStockGrid.Enabled = false;
            dgvViewStockGrid.Sort(dgvViewStockGrid.Columns["ItemCode"], ListSortDirection.Ascending);
        }

        private void btnAddItemDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProcBillNo.Text))
                {
                    XtraMessageBox.Show("BillNo should not be blank!");
                    return;
                }
                if (itemProcurement.GetProcurement().AsEnumerable().Where(X => X.Field<string>("BillNo") == txtProcBillNo.Text && X.Field<string>("DocumentNo") == txtProcDocNo.Text).ToList().Count > 0)
                {
                    DialogResult dres = XtraMessageBox.Show("BillNo Already Used! Are you want to update ?", "Alert", MessageBoxButtons.YesNo);
                    if (dres == DialogResult.No)
                    {
                        return;
                    }
                }
                if (ValidateProcurement() == false) return;
                ProcureItemDetailView ProcureItemDetailView = new ProcureItemDetailView(txtProcDocNo.Text, true);
                ProcureItemDetailView.GetValue += AddItemDetailHandlerEvent;

                if (ProcureItemDetailView.ShowDialog() == DialogResult.OK)
                {
                    MapProcurementToData();
                    ViewProcureDetailData();
                    ControlProcureEnability();
                    //XtraMessageBox.Show("Item Added Successfully.");
                }
                else
                {
                    //MapProcurementToData();
                    ViewProcureDetailData();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcAddNew_Click(object sender, EventArgs e)
        {
            ShowProcureGroupBoxes();
            RefreshForNewProcurement();
            btnProcureDelete.Visible = false;
            btnProcureClose.Visible = false;
            btnProcureSave.Visible = false;
        }

        public void HideProcureGroupBoxes()
        {
            gbxAddProcure.Visible = false;
            gbxAddProcureDetail.Visible = false;
            btnProcureDelete.Visible = false;
            gbxProcureListView.Visible = true;
            dgvProcureGrid.Refresh();
        }
        public void ShowProcureGroupBoxes()
        {
            gbxAddProcure.Visible = true;
            gbxAddProcureDetail.Visible = true;
            btnAddVendor.Visible = true;
            btnAddItemDetail.Visible = true;
            gbxProcureListView.Visible = false;
        }
        public void HideConsumpGroupBoxes()
        {
            gbxConsumedItem.Visible = false;
            gbxConsumedItemDetail.Visible = false;
            btnConsumeDelete.Visible = false;
            gbxConsumpListView.Visible = true;
        }
        public void ShowConsumpGroupBoxes()
        {
            gbxConsumedItemDetail.Enabled = true;
            gbxConsumedItem.Visible = true;
            gbxConsumedItemDetail.Visible = true;
            gbxConsumpListView.Visible = false;
        }
        public void HideReturnGroupBoxes()
        {
            gbxReturnItem.Visible = false;
            gbxReturnItemDetail.Visible = false;
            btnReturnDelete.Visible = false;
            gbxReturnListView.Visible = true;
        }
        public void ShowReturnGroupBoxes()
        {
            gbxReturnItem.Visible = true;
            gbxReturnItemDetail.Visible = true;
            btnReturnDetailAdd.Visible = true;
            btnReturnAdd.Visible = true;
            gbxReturnListView.Visible = false;
        }

        //public void HideStockViewGroupBoxes()
        //{
        //    gbxAddProcure.Visible = false;
        //    gbxAddProcureDetail.Visible = false;
        //    btnProcureDelete.Visible = false;
        //    gbxProcureListView.Visible = true;
        //}

        private string GenerateGlobalDocID(string procedureId, string preText)
        {
            string procureId = string.Empty;
            int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);
            //string preText = preText;// "PUR";
            Resources.Instance.GetMaxID(procedureId, "@MaxID", ref randomDigit);
            //if (randomDigit == 0)
            //{
            //    randomDigit = 1;
            //}
            //else
            //    randomDigit += 1;
            //if (!CallingLocation)
            procureId = Convert.ToString(preText + '-' + 00 + randomDigit);
            return procureId;
        }
        private void btnProcureCancel_Click(object sender, EventArgs e)
        {
            HideProcureGroupBoxes();
        }
        private void RefreshForNewProcurement()
        {
            dtpProcDate.Enabled = true;
            txtProcBillNo.Enabled = true;
            cmbVendor.Enabled = true;
            txtProcDocNo.Text=string.Empty;
            txtProcDocNo.Text = GenerateGlobalDocID("SP_GetProcDocID", "PUR");

            dtpProcDate.Text = DateTime.Now.ToString();
            dtpDocDate.Text = DateTime.Now.ToString();
            txtProcStatus.Text = InvStatus.Prepare.ToString();
            txtProcBillNo.Text = string.Empty;
            if (cmbVendor.Items.Count > 0)
            {
                cmbVendor.Items.Clear();
                cmbVendor.Text = "";
            }
            LoadVendors();
            if (dgvProcureItemDetailgrid.Rows.Count > 0)
                ((dgvProcureItemDetailgrid.DataSource) as DataTable).Clear();
            btnAddItemDetail.Visible = true;
            DisableControlPermanent();
        }
        private void RefreshForNewConsumption()
        {

            txtConsumpRefNo.Enabled = true;
            cmbConsumpType.Enabled = true;
            txtConsumpRemark.Enabled = true;
            txtConsumpDocNo.Text = string.Empty;
            txtConsumpDocNo.Text = GenerateGlobalDocID("SP_GetConsumpDocID", "CON");
            txtConsumpRefNo.Text = string.Empty;
            dtpConsumpDate.Text = DateTime.Now.ToString();
            txtConsumpStatus.Text = InvStatus.Prepare.ToString();
            txtConsumpRemark.Text = string.Empty;
            if (dgvConsumpDetailGrid.Rows.Count > 0)
                ((dgvConsumpDetailGrid.DataSource) as DataTable).Clear();
            txtConsumpStatus.Enabled = false;
            btnConsumpDetailAdd.Visible = true;
        }
        private void RefreshForNewReturn()
        {
            txtReturnRefNo.Enabled = true;
            txtReturnRemarks.Enabled = true;
            cmbReturnConsumpType.Enabled = true;
            txtReturnDocNo.Text = string.Empty;
            txtReturnDocNo.Text = GenerateGlobalDocID("SP_GetReturnDocID", "RET");
            txtReturnRefNo.Text = string.Empty;
            dtpReturnDocDate.Text = DateTime.Now.ToString();
            txtReturnStatus.Text = InvStatus.Prepare.ToString();
            txtReturnRemarks.Text = string.Empty;

            if (dgvReturnDetailGrid.Rows.Count > 0)
                ((dgvReturnDetailGrid.DataSource) as DataTable).Clear();
            txtReturnStatus.Enabled = false;
            btnReturnDetailAdd.Visible = true;
        }

        private void dgvProcureItemDetailgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                ShowConsumpGroupBoxes();
                ProcureItemDetail pcDetail = new ProcureItemDetail();
                pcDetail.Item = dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                pcDetail.BatchNo = dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["BatchNo"].Value.ToString();
                pcDetail.ItemCode = dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
                pcDetail.ProcureQty = double.Parse(dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["ProcureQty"].Value.ToString());
                pcDetail.Unit = dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                pcDetail.UnitCode = dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["UnitCode"].Value.ToString();
                pcDetail.UnitCost = double.Parse(dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["UnitCost"].Value.ToString());
                pcDetail.TotalCost = double.Parse(dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["TotalCost"].Value.ToString());
                pcDetail.DocumentNo = dgvProcureItemDetailgrid.Rows[e.RowIndex].Cells["DocumentNo"].Value.ToString();
                CreateProcDetailView(pcDetail, false);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public ProcureItemDetailView CreateProcDetailView(ProcureItemDetail pcDetail, Boolean IsNew)
        {
            ProcureItemDetailView procureItemDetailView = new ProcureItemDetailView(pcDetail.DocumentNo, IsNew);// (txtProcDocNo.Text);
            procureItemDetailView.MapProcDetailView(pcDetail);
            procureItemDetailView.GetValue += AddItemDetailHandlerEvent;

            if (procureItemDetailView.ShowDialog() == DialogResult.OK)
            {
                ViewProcureDetailData();
                procureItemDetailView.Close();
                procureItemDetailView.Dispose();
            }
            return procureItemDetailView;
        }
        public ConsumpItemDetailView CreateConsumpDetailView(ConsumpItemDetail consumpDetail, Boolean IsNew, Boolean IsMaint)
        {
            ConsumpItemDetailView consumpItemDetailView = new ConsumpItemDetailView(consumpDetail.DocumentNo, consumpDetail.ReferenceNo, IsNew, IsMaint);// (txtProcDocNo.Text);
            consumpItemDetailView.MapConsumedDetailView(consumpDetail);
            consumpItemDetailView.GetValue += AddItemDetailHandlerEvent;

            if (consumpItemDetailView.ShowDialog() == DialogResult.OK)
            {
                ViewConsumptionDetailData();
                consumpItemDetailView.Close();
                consumpItemDetailView.Dispose();
            }
            return consumpItemDetailView;
        }
        public ReturnItemDetailView CreateReturnDetailView(ReturnItemDetail returnDetail)
        {
            ReturnItemDetailView returnItemDetailView = new ReturnItemDetailView(returnDetail.DocumentNo, returnDetail.ReferenceNo, false,false);// (txtProcDocNo.Text);
            returnItemDetailView.MapReturnDetailView(returnDetail);
            returnItemDetailView.GetValue += AddItemDetailHandlerEvent;

            if (returnItemDetailView.ShowDialog() == DialogResult.OK)
            {
                ViewReturnDetailData();
                returnItemDetailView.Close();
                returnItemDetailView.Dispose();
            }
            return returnItemDetailView;
        }

        private void btnConsumpDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateConsumption() == false) return;

                ConsumpItemDetailView consumpItemDetailView = new ConsumpItemDetailView(txtConsumpDocNo.Text, txtConsumpRefNo.Text, true,false);
                consumpItemDetailView.GetValue += AddItemDetailHandlerEvent;

                if (consumpItemDetailView.ShowDialog() == DialogResult.OK)
                {
                    txtConsumpDocNo.Text= consumpItemDetailView.consumItemDetail.DocumentNo;
                    MapConsumptionData();
                    ViewConsumptionDetailData();
                    XtraMessageBox.Show("Item Added Successfully.");
                    consumpItemDetailView.Close();
                    consumpItemDetailView.Dispose();
                    ControlConsumpEnability();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddConsumpNew_Click(object sender, EventArgs e)
        {
            try
            {

                //if (gbxConsumedItem.Visible == false && gbxConsumedItemDetail.Visible == false)
                ShowConsumpGroupBoxes();
                RefreshForNewConsumption();
                btnConsumClose.Visible = false;
                btnConsumeDelete.Visible = false;
                btnConsumAdd.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsumpCancel_Click(object sender, EventArgs e)
        {
            HideConsumpGroupBoxes();
        }

        private void dgvConsumpDetailGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                ShowConsumpGroupBoxes();
                ConsumpItemDetail consDetail = new ConsumpItemDetail();
                consDetail.Item = dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                consDetail.BatchNo = dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["BatchNo"].Value.ToString();
                consDetail.ItemCode = dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
                consDetail.ConsumedQty = double.Parse(dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["ConsumedQty"].Value.ToString());
                consDetail.UnitCost = double.Parse(dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["UnitCost"].Value.ToString());
                consDetail.UnitCode = dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["UnitCode"].Value.ToString();
                consDetail.TotalCost = double.Parse(dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["TotalCost"].Value.ToString());
                consDetail.DocumentNo = dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["DocumentNo"].Value.ToString();
                consDetail.ReferenceNo = dgvConsumpDetailGrid.Rows[e.RowIndex].Cells["ReferenceNo"].Value.ToString();
                CreateConsumpDetailView(consDetail, false,false);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddReturnNew_Click(object sender, EventArgs e)
        {
            ShowReturnGroupBoxes();
            RefreshForNewReturn();
            btnReturnClose.Visible = false;
            btnReturnDelete.Visible = false;
            btnReturnAdd.Visible = false;
        }

        private void btnReturnCancel_Click(object sender, EventArgs e)
        {
            HideReturnGroupBoxes();
        }

        private void btnReturnDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnItemDetailView returnItemDetailView = new ReturnItemDetailView(txtReturnDocNo.Text, txtReturnRefNo.Text, true,false);
                returnItemDetailView.GetValue += AddItemDetailHandlerEvent;

                if (returnItemDetailView.ShowDialog() == DialogResult.OK)
                {
                    txtReturnDocNo.Text=returnItemDetailView.returnItemDetail.DocumentNo;
                    MapReturnData();

                    XtraMessageBox.Show("Item Added Successfully.");
                    ViewReturnDetailData();
                    ControlReturnEnability();
                    returnItemDetailView.Close();
                    returnItemDetailView.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReturnGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                btnReturnDelete.Visible = true;
                ShowReturnGroupBoxes();
                txtReturnDocNo.Text = dgvReturnGrid.Rows[e.RowIndex].Cells["ReturnDocumentNo"].Value.ToString();
                txtReturnRefNo.Text = dgvReturnGrid.Rows[e.RowIndex].Cells["ReturnReferenceNo"].Value.ToString();
                dtpReturnDocDate.Text = dgvReturnGrid.Rows[e.RowIndex].Cells["ReturnDocumentDate"].Value.ToString();
                cmbReturnConsumpType.Text = dgvReturnGrid.Rows[e.RowIndex].Cells["ReturnConsumptionType"].Value.ToString();
                txtReturnRemarks.Text = dgvReturnGrid.Rows[e.RowIndex].Cells["ReturnRemarks"].Value.ToString();
                txtReturnStatus.Text = dgvReturnGrid.Rows[e.RowIndex].Cells["ReturnStatus"].Value.ToString();
                dgvReturnDetailGrid.Enabled = true;

                ControlReturnEnability();

                //if (txtReturnStatus.Text == InvStatus.Closed.ToString())
                //{
                //    btnReturnDelete.Visible = false;
                //    btnReturnClose.Visible = false;
                //    btnReturnDetailAdd.Visible = false;
                //    btnReturnAdd.Visible = false;
                //    txtReturnRefNo.Enabled = false;
                //    cmbReturnConsumpType.Enabled = false;
                //    txtReturnRemarks.Enabled = false;
                //    dtpReturnDocDate.Enabled = false;
                //    dgvReturnDetailGrid.Enabled = false;
                //}
                //if (txtReturnStatus.Text == InvStatus.Prepare.ToString())
                //{
                //    btnReturnDelete.Visible = false;
                //    btnReturnClose.Visible = false;
                //    btnReturnDetailAdd.Visible = true;
                //    btnReturnAdd.Visible = true;
                //    txtReturnRefNo.Enabled = true;
                //    cmbReturnConsumpType.Enabled = true;
                //    txtReturnRemarks.Enabled = true;
                //    dtpConsumpDate.Enabled = true;
                //}
                //if (txtReturnStatus.Text == InvStatus.Open.ToString())
                //{
                //    btnReturnDelete.Visible = true;
                //    btnReturnClose.Visible = true;
                //    btnReturnDetailAdd.Visible = true;
                //    btnReturnAdd.Visible = true;
                //    txtReturnRefNo.Enabled = true;
                //    dtpConsumpDate.Enabled = true;
                //    cmbReturnConsumpType.Enabled = true;
                //    txtReturnRemarks.Enabled = true;
                //}

                ViewReturnDetailData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReturnDetailGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                ShowReturnGroupBoxes();
                ReturnItemDetail returnDetail = new ReturnItemDetail();
                returnDetail.Item = dgvReturnDetailGrid.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                returnDetail.BatchNo = dgvReturnDetailGrid.Rows[e.RowIndex].Cells["BatchNo"].Value.ToString();
                returnDetail.ItemCode = dgvReturnDetailGrid.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
                returnDetail.ReturnQty = double.Parse(dgvReturnDetailGrid.Rows[e.RowIndex].Cells["ReturnQty"].Value.ToString());
                returnDetail.UnitCost = double.Parse(dgvReturnDetailGrid.Rows[e.RowIndex].Cells["UnitCost"].Value.ToString());
                returnDetail.UnitCode = dgvReturnDetailGrid.Rows[e.RowIndex].Cells["UnitCode"].Value.ToString();
                returnDetail.TotalCost = double.Parse(dgvReturnDetailGrid.Rows[e.RowIndex].Cells["TotalCost"].Value.ToString());
                returnDetail.DocumentNo = dgvReturnDetailGrid.Rows[e.RowIndex].Cells["DocumentNo"].Value.ToString();
                returnDetail.ReferenceNo = dgvReturnDetailGrid.Rows[e.RowIndex].Cells["ReferenceNo"].Value.ToString();
                CreateReturnDetailView(returnDetail);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Boolean ValidateProcurement()
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(txtProcBillNo.Text))
            {
                XtraMessageBox.Show("Please input BillNo!");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(cmbVendor.Text))
            {
                XtraMessageBox.Show("Please select Vendor!");
                IsValid = false;
            }
            if (dtpProcDate.Value > dtpDocDate.Value)
            {
                XtraMessageBox.Show("Purchase date exceeds! Please select purchase date as equal or less than documentdate");
                IsValid = false;
            }
            return IsValid;
        }
        private Boolean ValidateConsumption()
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(txtConsumpRefNo.Text) || string.IsNullOrEmpty(cmbConsumpType.Text) || string.IsNullOrEmpty(txtConsumpRemark.Text))
            {
                XtraMessageBox.Show("Please Fill All Fields!");
                IsValid = false;
            }
            return IsValid;
        }

        private void btnPivotLog_Click(object sender, EventArgs e)
        {
            pgProcureLogPages.SelectedIndex = 1;
            ViewProcureBatchGrid();
            //pgProcureLogPages.SelectedIndex = 1;
            //ViewProcurePivotGrid();
        }

        private void btnGnrlLog_Click(object sender, EventArgs e)
        {
            pgProcureLogPages.SelectedIndex = 0;
            ViewThresholdProcureDetail();
        }

        //private void ViewProcurePivotGrid()
        //{
        //    pvtProcThresGrid.DataSource = Resources.Instance.GetPivotThresholdProcureDetail();

        //    PivotGridField ItemCode = new PivotGridField()
        //    {
        //        Area = PivotArea.RowArea,
        //        AreaIndex = 0,
        //        Caption = "Item Code",
        //        FieldName = "ItemCode"
        //    };
        //    PivotGridField Item = new PivotGridField()
        //    {
        //        Area = PivotArea.RowArea,
        //        AreaIndex = 1,
        //        Caption = "Item",
        //        FieldName = "Item"
        //    };
        //    PivotGridField BatchNo = new PivotGridField()
        //    {
        //        Area = PivotArea.DataArea,
        //        AreaIndex = 2,
        //        Caption = "BatchNo",
        //        FieldName = "BatchNo",
        //    };
        //    PivotGridField Make = new PivotGridField()
        //    {
        //        Area = PivotArea.DataArea,
        //        AreaIndex = 3,
        //        Caption = "Make",
        //        FieldName = "Make",
        //    };
        //    PivotGridField Model = new PivotGridField()
        //    {
        //        Area = PivotArea.RowArea,
        //        AreaIndex = 4,
        //        Caption = "Model",
        //        FieldName = "Model"
        //    };

        //    PivotGridField Category = new PivotGridField()
        //    {
        //        Area = PivotArea.RowArea,
        //        AreaIndex = 5,
        //        Caption = "Category",
        //        FieldName = "Category"
        //    };
        //    PivotGridField SubCategory = new PivotGridField()
        //    {
        //        Area = PivotArea.RowArea,
        //        AreaIndex = 6,
        //        Caption = "Sub Category",
        //        FieldName = "SubCategory"
        //    };

        //    PivotGridField MinimumStock = new PivotGridField()
        //    {
        //        Area = PivotArea.RowArea,
        //        AreaIndex = 7,
        //        Caption = "Minimum Stock",
        //        FieldName = "Minimum Stock"
        //    };


        //    PivotGridField AvailQty = new PivotGridField()
        //    {
        //        Area = PivotArea.DataArea,
        //        AreaIndex = 8,
        //        Caption = "Available Qty",
        //        FieldName = "AvailableQty",
        //    };
        //    PivotGridField Unit = new PivotGridField()
        //    {
        //        Area = PivotArea.DataArea,
        //        AreaIndex = 9,
        //        Caption = "Unit",
        //        FieldName = "Unit",
        //    };
        //    pvtProcThresGrid.Fields.AddRange(new PivotGridField[] {
        //    ItemCode,
        //    Item,
        //    Unit,
        //    Make,
        //    Model,
        //    BatchNo,
        //    Category,
        //    SubCategory,
        //    MinimumStock,
        //    AvailQty
        //    });
        //    pvtProcThresGrid.BestFit();
        //}

        private void ViewProcureBatchGrid()
        {
            dgvProcureLogBatchGrid.DataSource = Resources.Instance.GetPivotThresholdProcureDetail();
        }

        private void dgvViewStockGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gbxBatchWiseStock.Visible = true;
            if (e.RowIndex < 0) return;
            string itemcode = dgvViewStockGrid.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();

            dgvViewBatchStockGrid.DataSource = Resources.Instance.GetSingleItemStock(itemcode);
            dgvViewBatchStockGrid.Columns["ItemCode"].HeaderText = "Item Code";
            dgvViewBatchStockGrid.Columns["BatchNo"].HeaderText = "Batch No.";
            dgvViewBatchStockGrid.Columns["AvailableQty"].HeaderText = "Available Qty";
            dgvViewBatchStockGrid.Columns["UnitCost"].HeaderText = "UnitCost";
            gbxAllStockDetail.Visible = false;
        }

        private void btnStockback_Click(object sender, EventArgs e)
        {
            gbxBatchWiseStock.Visible = false;
            gbxAllStockDetail.Visible = true;
            lblStockConsumedLog.Text = "Stock Consumed Log";
        }

        //private void ShowHideStockGrid()
        //{
        //    gbxBatchWiseStock.Visible = false;
        //    gbxAllStockDetail.Visible = true;
        //}

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CheckVendorData(cmbVendor.SelectedItem.ToString());
        }
        private void CheckVendorData(string name)
        {
            //string name = cmbVendor.SelectedItem.ToString();
            //if (name == "Add New Vendor")
            {
                VendorMasterView vendorMasterView = new VendorMasterView();
                vendorMasterView.GetValue += VendorMasterHandlerEvent;
                if (vendorMasterView.ShowDialog() == DialogResult.OK)
                {
                    vendorMasterView.Close();
                    vendorMasterView.Dispose();
                }
            }
        }
        private void VendorMasterHandlerEvent(params object[] obj)
        {
            if (!cmbVendor.Items.Contains(obj[0].ToString()))
            {
                cmbVendor.Items.Add(obj[0].ToString());
                cmbVendor.Text = obj[0].ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnProcureLog_Click(object sender, EventArgs e)
        {
            gbxProcureAllDetail.Visible = true;
            gbxProcureBatchDetail.Visible = false;
            //gbxProcureBatchDetail.Visible = false;
            //gbxProcureAllDetail.Visible = true;
            lblStockAddedLog.Text = "Stock Added Log";
        }

        private void dgvProcureAllDetailGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            gbxProcureBatchDetail.Visible = false;
            string docNo = dgvProcureAllDetailGrid.Rows[e.RowIndex].Cells["DocumentNo"].Value.ToString();
            dgvProcureBatchDetailGrid.DataSource = Resources.Instance.GetProcureItemDetail(docNo);
            dgvProcureBatchDetailGrid.Columns["ItemCode"].Visible = false;
            dgvProcureBatchDetailGrid.Columns["UnitCode"].Visible = false;
            lblStockAddedLog.Text = "Stock Added Log Detail";
            ////string itemcode = dgvProcureAllDetailGrid.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
            ////dgvProcureBatchDetailGrid.DataSource = Resources.Instance.GetSingleItemStock(itemcode);
            ////gbxProcureBatchDetail.Visible = true;
            dgvProcureBatchDetailGrid.Columns["DocumentNo"].HeaderText = "Document No.";
            dgvProcureBatchDetailGrid.Columns["DocDate"].HeaderText = "Document Date";
            dgvProcureBatchDetailGrid.Columns["BillNo"].HeaderText = "Bill No";
            dgvProcureBatchDetailGrid.Columns["BatchNo"].HeaderText = "Batch No.";
            dgvProcureBatchDetailGrid.Columns["ProcureQty"].HeaderText = "Procure Qty";
            dgvProcureBatchDetailGrid.Columns["UnitCost"].HeaderText = "Unit Cost";
            dgvProcureBatchDetailGrid.Columns["TotalCost"].HeaderText = "Total Cost";
            gbxProcureAllDetail.Visible = false;
            gbxProcureBatchDetail.Visible = true;
        }

        private void btnStockExportXls_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvViewStockGrid, lblStockHeader.Text);
        }

        private void txtProcSearchAddedLog_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dgvProcureAllDetailGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("DocumentNo like '{0}%' OR BillNo like '{0}%' OR Vendor like '{0}%' OR VendorCode like '{0}%'", txtProcSearchAddedLog.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAllConsumpSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dgvAllConsumeDetailGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("ItemCode like '{0}%' OR Item like '{0}%' OR Make like '{0}%' OR Model like '{0}%' OR Category like '{0}%' OR SubCategory like '{0}%'", txtAllConsumpSearch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            CheckVendorData("Add New Vendor");
        }

        //private void monCalProcSearch_DateSelected(object sender, DateRangeEventArgs e)
        //{
        //    //DateTime dtime = monCalProcSearch.SelectionEnd.Date;
        //    //(dgvProcureGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("DocumentDate = '{0}%'", dtime);
        //    //monCalProcSearch.Visible = false;
        //}

        //private void btnProcSearchByDate_Click(object sender, EventArgs e)
        //{
        //    //monCalProcSearch.Visible = true;
        //}

        private void txtProcureLogSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dgvProcureLogDetailGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("ItemCode like '{0}%' OR Item like '{0}%' OR Make like '{0}%' OR Model like '{0}%' OR Category like '{0}%' OR [Sub Category] like '{0}%'", txtProcureLogSearch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProcBatchLogSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dgvProcureLogBatchGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("ItemCode like '{0}%' OR Item like '{0}%' OR Make like '{0}%' OR Model like '{0}%' OR Category like '{0}%' OR [Sub Category] like '{0}%'", txtProcBatchLogSearch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportExcelReport(DataGridView dgv, string fileName)
        {
            try
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value==null) continue;
                        
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

        private void ExportProcureLogExcel(DataGridView dgv, string fileName)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dgv.DataSource as DataTable;
                //Exporting to Excel
                if (dt.Rows.Count > 0)
                {
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
                                DialogResult dgres = XtraMessageBox.Show("File already exists! Are you want to replace?", "Alert", MessageBoxButtons.YesNo);
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
            }


            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendMailExcelReport(DataGridView dgv, string fileName)
        {
            try
            {
                DataTable dt = new DataTable();
                //Adding the Columns
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Name == "Select") continue;
                    dt.Columns.Add(column.Name, column.ValueType);
                }

                //var vv = dgv.Rows.Cast<DataGridViewRow>().Select(X => X.Cells["Select"].Value).ToString();
                var sRows = dgv.Rows.Cast<DataGridViewRow>().Where(X => X.Cells["Select"].Value != null && X.Cells["Select"].Value.ToString() == "1").ToList();
                if (sRows.Count == 0)
                {
                    XtraMessageBox.Show("Please Select Records!");
                    return;
                }
                for (int i = 0; i < sRows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ItemCode"] =sRows[i].Cells["ItemCode"].Value;
                    dr["Item"] = sRows[i].Cells["Item"].Value;
                    dr["Unit"] = sRows[i].Cells["Unit"].Value;
                    dr["Make"] = sRows[i].Cells["Make"].Value;
                    dr["Model"] = sRows[i].Cells["Model"].Value;
                    dr["Category"] = sRows[i].Cells["Category"].Value;
                    dr["Sub Category"] = sRows[i].Cells["Sub Category"].Value;
                    dr["Minimum Stock"] = sRows[i].Cells["Minimum Stock"].Value;
                    dr["AvailableQty"] = sRows[i].Cells["AvailableQty"].Value;
                    dt.Rows.Add(dr);
                }

                //Exporting to Excel
                if (dt.Rows.Count > 0)
                {

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Sheet1");
                        var workbookBytes = new byte[0];
                        using (var ms = new MemoryStream())
                        {
                            wb.SaveAs(ms);
                            workbookBytes = ms.ToArray();
                            Attachment exlAttach = new Attachment(new MemoryStream(workbookBytes), fileName + ".xlsx");
                            ViewMailDetail();
                            //SendMailToFPREx("support@sparrowrms.in", "milan.s@sparrowrms.in", "suraj.s@sparrowrms.in", "PFA", "Minimum Stock Report", exlAttach);
                            if (mailDetail == null) return;
                            SendMailToFPREx(mailDetail, exlAttach);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcStockExportXls_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvProcureAllDetailGrid, lblStockAddedLog.Text);
        }

        private void btnConsumpExportXls_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvAllConsumeDetailGrid, lblStockConsumedLog.Text);
        }

        private void btnProcureGnrlLog_Click(object sender, EventArgs e)
        {
            ExportProcureLogExcel(dgvProcureLogDetailGrid, lblProcureLogHeader.Text);
        }

        private void btnProcureBatchLog_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvProcureLogBatchGrid, pgProcureBatchLog.Text);
        }

        private void btnProcureGnrlMail_Click(object sender, EventArgs e)
        {
            //ViewMailDetail();
            SendMailExcelReport(dgvProcureLogDetailGrid, pgProcGeneralLog.Text);
        }

        private void dgvProcureLogDetailGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {

                if (dgvProcureLogDetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dgvProcureLogDetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }

                string value = dgvProcureLogDetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int selectvalue = 0;
                int.TryParse(value, out selectvalue);
                if (selectvalue == 0)
                {
                    dgvProcureLogDetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                }
                else
                {
                    dgvProcureLogDetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        private void SendMailToFPREx(MailDetail mailDetail, Attachment stream)
        {

            //string mailTo = null;
            string FromMailAddress = string.Empty;
            string MailPassword = string.Empty;
            //string mailCc = null;
            string xmsg = string.Empty;
            MailMessage mail;
            HindalcoiOS.Configuration.MailConfig mConfig = HindalcoiOS.Configuration.MailConfig.Instance;
            mConfig.GetMailConfig();
            try
            {

                mail = new MailMessage();
                FromMailAddress = mConfig.MailFrom;// "support@sparrowrms.in";
                MailPassword = mConfig.MailPassword;// "Zoq36865";
                mail.From = new MailAddress(FromMailAddress, FromMailAddress);// "support@sparrowrms.in");
            }
            catch
            {
                xmsg = "Configure Proper Credentials in SettingOptions";
                throw new Exception(xmsg);
            }
            mail.Attachments.Add(stream);

            string BodyMsg = mailDetail.Body;// sfCred.MessageBody;
            mail.Subject = mailDetail.Subject;// sfCred.Subject;
            mail.Body = BodyMsg;

            if (!string.IsNullOrEmpty(mailDetail.MailTo))
            {
                if (mailDetail.MailTo.Contains(','))
                {
                    foreach (var address in mailDetail.MailTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string mailAddress = address.Trim();
                        mail.To.Add(new MailAddress(mailAddress));
                    }
                }
                else
                {
                    string mailAddress = mailDetail.MailTo.Trim();
                    mail.To.Add(new MailAddress(mailAddress));
                }
            }

            if (!string.IsNullOrEmpty(mailDetail.MailCc))
            {
                if (mailDetail.MailCc.Contains(','))
                {
                    foreach (var address in mailDetail.MailCc.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string mailAddress = address.Trim();
                        mail.CC.Add(new MailAddress(mailAddress));
                    }
                }
                else
                {
                    string mailAddress = mailDetail.MailCc.Trim();
                    mail.CC.Add(new MailAddress(mailAddress));
                }
            }

            try
            {
                if (!string.IsNullOrEmpty(mailDetail.MailTo) && !string.IsNullOrEmpty(FromMailAddress))
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = mConfig.Host;// "smtp.office365.com";
                    smtp.EnableSsl = mConfig.MailSSL;// true; 
                    smtp.Timeout = 200000;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Port = int.Parse(mConfig.Port); //587;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential nc = new NetworkCredential(FromMailAddress, MailPassword);
                    smtp.Credentials = nc;
                    ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                    smtp.Send(mail);
                    mail.Dispose();
                    smtp.Dispose();
                    XtraMessageBox.Show("Report Sent Successfully.");
                }
            }
            catch (Exception Ex)
            {
                //XtraMessageBox.Show("Mail setting/server not working, Configure and try again", "Jubilant Food System!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcAllStockExportXls_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvProcureBatchDetailGrid, lblStockAddedLog.Text);

        }

        //private void dgvProcureBatchDetailGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void dgvStockComsumedLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void dgvStockConsumedLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            gbxConsumeDetailLog.Visible = false;
            lblStockConsumedLog.Text = "Stock Consumed Log Detail";
            string docNo = dgvStockConsumedLog.Rows[e.RowIndex].Cells["DocumentNo"].Value.ToString();
            string refNo = dgvStockConsumedLog.Rows[e.RowIndex].Cells["ReferenceNo"].Value.ToString();
            dgvAllConsumeDetailGrid.DataSource = Resources.Instance.GetAllConsumedItemDetailWithReturn(docNo, refNo);
            dgvAllConsumeDetailGrid.Columns["ItemCode"].Visible = false;
            dgvAllConsumeDetailGrid.Columns["UnitCode"].Visible = false;
            dgvAllConsumeDetailGrid.Columns["DocumentNo"].HeaderText = "Document No.";
            dgvAllConsumeDetailGrid.Columns["DocumentDate"].HeaderText = "Document Date";
            dgvAllConsumeDetailGrid.Columns["ReferenceNo"].HeaderText = "Reference No.";
            dgvAllConsumeDetailGrid.Columns["MinimumStock"].HeaderText = "Minimum Stock";
            dgvAllConsumeDetailGrid.Columns["BatchNo"].HeaderText = "Batch No.";
            dgvAllConsumeDetailGrid.Columns["UnitCost"].HeaderText = "Unit Cost";
            dgvAllConsumeDetailGrid.Columns["ConsumedQty"].HeaderText = "Consumed Qty";
            dgvAllConsumeDetailGrid.Columns["TotalCost"].HeaderText = "Total Cost";
            gbxAllConsumeDetail.Visible = true;

        }

        private void btnStockConsumLog_Click(object sender, EventArgs e)
        {
            gbxConsumeDetailLog.Visible = true;
            gbxAllConsumeDetail.Visible = false;
            lblStockConsumedLog.Text = "Stock Consumed Log";
        }

        private void btnProcureDelete_Click(object sender, EventArgs e)
        {
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                itemProcurement.DeleteProcurementData(txtProcDocNo.Text);
                XtraMessageBox.Show("Record deleted Successfully");
                ViewProcureData();
                ViewProcureDetailData();
            }
        }

        private void btnConsumeDelete_Click(object sender, EventArgs e)
        {
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                itemConsumption.DeleteConsumptionData(txtConsumpDocNo.Text);
                XtraMessageBox.Show("Record deleted Successfully");
                ViewConsumptionData();
                ViewConsumptionDetailData();
                HideConsumpGroupBoxes();
            }
        }

        private void btnReturnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                itemReturn.DeleteReturnData(txtReturnDocNo.Text);
                XtraMessageBox.Show("Record deleted Successfully");
                ViewReturnData();
                ViewReturnDetailData();
                HideReturnGroupBoxes();
            }
        }

        private void btnStkConsumpLogExlExp_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvStockConsumedLog, lblStockConsumedLog.Text);
        }

        //private void FocusButton()
        //{
        //    btnAvaiStock.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
        //    btnAddStock.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
        //    btnStockDetails.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
        //    btnConsumption.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
        //    btnConsumptionDetails.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
        //    btnProcure.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
        //    btnStockReturn.BackColor = this.btnAvaiStock.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));

        //}



        private void btnProcureClose_Click(object sender, EventArgs e)
        {
            DialogResult des = XtraMessageBox.Show("Are you sure want to close ?", "Close", MessageBoxButtons.YesNo);
            if (des == DialogResult.Yes)
            {
                itemProcurement.Status = InvStatus.Closed;
                MapProcurementToData();
                ControlProcureEnability();
                HideProcureGroupBoxes();
            }
        }

        private void btnConsumClose_Click(object sender, EventArgs e)
        {
            DialogResult des = XtraMessageBox.Show("Are you sure want to close ?", "Close", MessageBoxButtons.YesNo);
            if (des == DialogResult.Yes)
            {
                itemConsumption.Status = InvStatus.Closed;
                MapConsumptionData();
                ControlConsumpEnability();
                HideConsumpGroupBoxes();
            }
        }

        private void btnReturnClose_Click(object sender, EventArgs e)
        {
            DialogResult des = XtraMessageBox.Show("Are you sure want to close ?", "Close", MessageBoxButtons.YesNo);
            if (des == DialogResult.Yes)
            {
                itemReturn.Status = InvStatus.Closed;
                MapReturnData();
                ControlReturnEnability();
                HideReturnGroupBoxes();
            }
        }

        private void btnConsumpBack_Click(object sender, EventArgs e)
        {
            HideConsumpGroupBoxes();
        }

        private void btnReturnBack_Click(object sender, EventArgs e)
        {
            HideReturnGroupBoxes();
        }

       

        private void btnProcureBack_Click(object sender, EventArgs e)
        {
            HideProcureGroupBoxes();
            ViewProcureData();
        }

        private void btnProcureSeach_Click(object sender, EventArgs e)
        {
            //ViewProcureFilterData();
            FilterProcureGridData();
        }

        private void btnConsumpSearch_Click(object sender, EventArgs e)
        {
            FilterConsumpGridData();
        }

        private void btnReturnSearch_Click(object sender, EventArgs e)
        {
            FilterReturnGridData();
        }
        private void ControlConsumpEnability()
        {
            if (txtConsumpStatus.Text == InvStatus.Closed.ToString())
            {
                btnConsumeDelete.Visible = false;
                btnConsumClose.Visible = false;
                btnConsumpDetailAdd.Visible = false;
                btnConsumAdd.Visible = false;
                txtConsumpRefNo.Enabled = false;
                cmbConsumpType.Enabled = false;
                txtConsumpRemark.Enabled = false;
                txtConsumpStatus.Enabled = false;
                dtpConsumpDate.Enabled = false;
                dgvConsumpDetailGrid.Enabled = false;
            }
            if (txtConsumpStatus.Text == InvStatus.Prepare.ToString())
            {
                btnConsumeDelete.Visible = false;
                btnConsumClose.Visible = false;
                btnConsumpDetailAdd.Visible = true;
                btnConsumAdd.Visible = false;
                txtConsumpRefNo.Enabled = true;
                cmbConsumpType.Enabled = true;
                txtConsumpRemark.Enabled = true;
                dtpConsumpDate.Enabled = true;
            }
            if (txtConsumpStatus.Text == InvStatus.Open.ToString())
            {
                btnProcureDelete.Visible = false;
                if (HindalcoiOS.Properties.Settings.Default.RoleID == 7)
                {
                    btnConsumeDelete.Visible = true;
                }
                btnConsumClose.Visible = true;
                btnConsumpDetailAdd.Visible = true;
                btnConsumAdd.Visible = true;
                txtConsumpRefNo.Enabled = true;
                dtpConsumpDate.Enabled = true;
                cmbConsumpType.Enabled = true;
                txtConsumpRemark.Enabled = true;
                txtConsumpStatus.Enabled = false;
            }
        }


        private void ControlProcureEnability()
        {
            if (txtProcStatus.Text == InvStatus.Closed.ToString())
            {
                btnProcureDelete.Visible = false;
                btnProcureClose.Visible = false;
                btnAddItemDetail.Visible = false;
                btnAddVendor.Visible = false;
                btnProcureSave.Visible = false;
                txtProcBillNo.Enabled = false;
                cmbVendor.Enabled = false;
                dtpProcDate.Enabled = false;
                dgvProcureItemDetailgrid.Enabled = false;
                btnAddVendor.Visible = false;

            }
            if (txtProcStatus.Text == InvStatus.Prepare.ToString())
            {
                btnProcureDelete.Visible = false;
                btnProcureClose.Visible = false;
                btnAddItemDetail.Visible = true;
                btnAddVendor.Visible = true;
                btnProcureSave.Visible = false;
                txtProcBillNo.Enabled = true;
                cmbVendor.Enabled = true;
                dtpProcDate.Enabled = true;
            }
            if (txtProcStatus.Text == InvStatus.Open.ToString())
            {
                btnProcureDelete.Visible = false;
                if ( HindalcoiOS.Properties.Settings.Default.RoleID==7 && dgvProcureItemDetailgrid.Rows.Count>0)
                {
                    btnProcureDelete.Visible = true;
                }
                btnProcureClose.Visible = true;
                btnAddItemDetail.Visible = true;
                btnAddVendor.Visible = true;
                btnProcureSave.Visible = true;
                txtProcBillNo.Enabled = true;
                cmbVendor.Enabled = true;
                dtpProcDate.Enabled = true;
            }
        }

        private void ControlReturnEnability()
        {
            if (txtReturnStatus.Text == InvStatus.Closed.ToString())
            {
                btnReturnDelete.Visible = false;
                btnReturnClose.Visible = false;
                btnReturnDetailAdd.Visible = false;
                btnReturnAdd.Visible = false;
                txtReturnRefNo.Enabled = false;
                cmbReturnConsumpType.Enabled = false;
                txtReturnRemarks.Enabled = false;
                dtpReturnDocDate.Enabled = false;
                dgvReturnDetailGrid.Enabled = false;
            }
            if (txtReturnStatus.Text == InvStatus.Prepare.ToString())
            {
                btnReturnDelete.Visible = false;
                btnReturnClose.Visible = false;
                btnReturnDetailAdd.Visible = true;
                btnReturnAdd.Visible = true;
                txtReturnRefNo.Enabled = true;
                cmbReturnConsumpType.Enabled = true;
                txtReturnRemarks.Enabled = true;
                dtpConsumpDate.Enabled = true;
            }
            if (txtReturnStatus.Text == InvStatus.Open.ToString())
            {
                btnReturnDelete.Visible = false;
                if (HindalcoiOS.Properties.Settings.Default.RoleID == 7)
                {
                    btnReturnDelete.Visible = true;
                }
                btnReturnClose.Visible = true;
                btnReturnDetailAdd.Visible = true;
                btnReturnAdd.Visible = true;
                txtReturnRefNo.Enabled = true;
                dtpConsumpDate.Enabled = true;
                cmbReturnConsumpType.Enabled = true;
                txtReturnRemarks.Enabled = true;
            }
        }

        private void txtStkConsumpLogSrch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dgvStockConsumedLog.DataSource as DataTable).DefaultView.RowFilter = string.Format("DocumentNo like '{0}%' OR ReferenceNo like '{0}%' OR ConsumptionType like '{0}%'", txtStkConsumpLogSrch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideTabControlPagesHeader(SparrowTabControl tbControl)
        {
            tbControl.Appearance = TabAppearance.FlatButtons;
            tbControl.ItemSize = new Size(0, 1);
            tbControl.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in tbControl.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void DisableControlPermanent()
        {
            txtProcStatus.Enabled = false;
            txtConsumpStatus.Enabled = false;
            txtReturnStatus.Enabled = false;
            txtProcDocNo.Enabled = false;
            txtConsumpDocNo.Enabled = false;
            txtReturnDocNo.Enabled = false;
            dtpDocDate.Enabled = false;
            dtpConsumpDate.Enabled = false;
            dtpReturnDocDate.Enabled = false;
        }
    }
}


