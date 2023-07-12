using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.InventoryMgmt
{
    public partial class ProcureItemDetailView : XtraForm
    {
        public EventHandler<string> GetValue;
        public ProcureItemDetail procureItemDetail { get; set; }
        public ProcureItemDetailView()
        {
            InitializeComponent();
            procureItemDetail = new ProcureItemDetail();
        }
        public ProcureItemDetailView(String documentNo, Boolean IsNew)
        {
            InitializeComponent();
            procureItemDetail = new ProcureItemDetail();
            procureItemDetail.DocumentNo = documentNo;
            procureItemDetail.BatchNo = DateTime.Now.ToString();
            btnProcItemDetailDelete.Visible = false;
            btnProcItemDetailAdd.Text = "Save";
            if (IsNew == false)
            {
                btnProcItemDetailDelete.Visible = true;
                btnProcItemDetailAdd.Text = "Update";
            }
        }
        private void ProcureItemDetailView_Load(object sender, EventArgs e)
        {
            DisableControlPermanent();
            GenerateNewBatch();
            LoadItems();
            DisableControls();
           
        }
        private void btnProcItemDetailAdd_Click(object sender, EventArgs e)
        {
            MapProcureDetailData();
        }

        private void MapProcureDetailData()
        {
            if (ValidateProcureDetail() == false) return;
            //procureItemDetail.DocumentNo = txt.Text;
            try
            {
                if (cmbProcureItem.SelectedItem != null && cmbProcureItem.SelectedItem.ToString() != "Add New Item")
                    procureItemDetail.Item = cmbProcureItem.SelectedItem.ToString();
                else
                    procureItemDetail.Item = cmbProcureItem.Text;
                if (!string.IsNullOrWhiteSpace(procureItemDetail.Item))
                {
                    procureItemDetail.LoadItem = procureItemDetail.LoadItemMaster();
                    procureItemDetail.ItemCode = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == procureItemDetail.Item).ToList().FirstOrDefault()["ItemCode"].ToString();
                }
                procureItemDetail.BatchNo = txtProcBatchno.Text;
                procureItemDetail.ProcureQty = Convert.ToDouble(dpnProcureQty.Value);// Convert.ToDouble(txtProcureQty.Text);

                if (cmbProcureItem.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbProcureItem.SelectedItem.ToString()))
                    procureItemDetail.UnitCode = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == procureItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                else
                    procureItemDetail.UnitCode = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == procureItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();

                procureItemDetail.UnitCost = Convert.ToDouble(nUpdnProcureUnitCost.Value);// Convert.ToDouble(txtProcureUnitCost.Text);
                procureItemDetail.TotalCost = (Convert.ToDouble(dpnProcureQty.Value) * Convert.ToDouble(nUpdnProcureUnitCost.Value));// (Convert.ToDouble(txtProcureQty.Text) * Convert.ToDouble(txtProcureUnitCost.Text));
                //itemReturn.Remarks = txtReturnRemarks.Text;
                //itemReturn.ConsumptionType = cmbReturnConsumpType.Text;
                if (CheckItemExist() == true)
                {
                    DialogResult result = XtraMessageBox.Show("Item already exist with this BillNo! Want to add more Item ?", "Alert", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        procureItemDetail.SetProcureItemDetailValue(procureItemDetail);
                        XtraMessageBox.Show("Details Saved Succesfully");
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        return;
                    }
                }
                else
                {
                    procureItemDetail.SetProcureItemDetailValue(procureItemDetail);
                    XtraMessageBox.Show("Details Saved Succesfully");
                }
                DialogResult = DialogResult.OK;

                //this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //ViewReturnData();

        }

        private void MapProcureDetailViewToObject()
        {
            //if (ValidateProcureDetail() == false) return;
            try
            {
                if (cmbProcureItem.SelectedItem != null && cmbProcureItem.SelectedItem.ToString() != "Add New Item")
                    procureItemDetail.Item = cmbProcureItem.SelectedItem.ToString();
                else
                    procureItemDetail.Item = cmbProcureItem.Text;
                if (!string.IsNullOrWhiteSpace(procureItemDetail.Item))
                {
                    procureItemDetail.LoadItem = procureItemDetail.LoadItemMaster();
                    procureItemDetail.ItemCode = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == procureItemDetail.Item).ToList().FirstOrDefault()["ItemCode"].ToString();
                }
                procureItemDetail.BatchNo = txtProcBatchno.Text;
                procureItemDetail.ProcureQty = Convert.ToDouble(dpnProcureQty.Value); ;// Convert.ToDouble(txtProcureQty.Text);

                if (cmbProcureItem.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbProcureItem.SelectedItem.ToString()))
                    procureItemDetail.UnitCode = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == procureItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                else
                    procureItemDetail.UnitCode = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == procureItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();

                procureItemDetail.UnitCost =Convert.ToDouble(nUpdnProcureUnitCost.Value);// Convert.ToDouble(txtProcureUnitCost.Text);
                procureItemDetail.TotalCost = (Convert.ToDouble(dpnProcureQty.Value) * Convert.ToDouble(nUpdnProcureUnitCost.Value)); // (Convert.ToDouble(txtProcureQty.Text) * Convert.ToDouble(txtProcureUnitCost.Text));

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadItems()
        {
            procureItemDetail.LoadItem = procureItemDetail.LoadItemMaster();

            var itemcount = procureItemDetail.LoadItem.Rows.Count;
            for (int i = 0; i < itemcount; i++)
            {
                cmbProcureItem.Items.Add(procureItemDetail.LoadItem.Rows[i]["ItemName"]);
            }
        }

        private void AddNewItemMaster(string keyString)
        {
            if (keyString == "Add New Item")
            {
                ItemMasterView itemMaster = new ItemMasterView(false);
                itemMaster.GetValue += ItemMasterHandlerEvent;
                if (itemMaster.ShowDialog() == DialogResult.OK)
                {
                    itemMaster.Close();
                    itemMaster.Dispose();
                }
            }
        }
        private void ItemMasterHandlerEvent(params object[] obj)
        {
            if (!cmbProcureItem.Items.Contains(obj[0].ToString()))
            {
                cmbProcureItem.Items.Add(obj[0].ToString());
                cmbProcureItem.Text = obj[0].ToString();
                txtProcureUnit.Text = obj[1].ToString();
                txtItemCategory.Text = obj[2].ToString();
                txtItemSubcategory.Text = obj[3].ToString();
            }
        }

        //private void ItemMasterHandlerEvent(object sender, string value)
        //{
        //    if (!cmbProcureItem.Items.Contains(value))
        //    {
        //        cmbProcureItem.Items.Add(value);
        //        cmbProcureItem.Text = value.ToString();
        //        //txtProcureUnit.Text = unitvalue;
        //    }
        //}
        public void MapProcDetailView(ProcureItemDetail pcItemDetail)
        {
            pcItemDetail.LoadItem = pcItemDetail.LoadItemMaster();
            cmbProcureItem.Text = pcItemDetail.Item;
            txtProcBatchno.Text = pcItemDetail.BatchNo;
            dpnProcureQty.Value =Convert.ToDecimal(pcItemDetail.ProcureQty);
            txtProcureUnit.Text = pcItemDetail.Unit;
            nUpdnProcureUnitCost.Value =Convert.ToDecimal(pcItemDetail.UnitCost.ToString());
            //txtProcureUnitCost.Text = pcItemDetail.UnitCost.ToString();
            txtProcureTotCost.Text = pcItemDetail.TotalCost.ToString();
            txtItemCategory.Text = pcItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == pcItemDetail.Item).ToList().FirstOrDefault()["Category"].ToString();
            txtItemSubcategory.Text = pcItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == pcItemDetail.Item).ToList().FirstOrDefault()["SubCategory"].ToString();
            //pcItemDetail.LoadItem= procureItemDetail.LoadItemMaster();
            //txtProcureUnit.Text = pcItemDetail.LoadItemMaster().AsEnumerable().Where(X => X.Field<string>("ItemCode") == pcItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString(); 


        }
        public void GenerateNewBatch()
        {
            if (string.IsNullOrEmpty(txtProcBatchno.Text))
                txtProcBatchno.Text = DateTime.Now.ToString("ddMMyyyyhhmmss");
        }

        private void cmbProcureItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProcureItem.SelectedItem != null)
            {
                GetUnit(cmbProcureItem.SelectedItem.ToString());
            }
            ////AddNewItemMaster(cmbProcureItem.SelectedItem.ToString());
        }
        public string GetUnit(string itmName)
        {
            string itmUnit = string.Empty;
            if (!string.IsNullOrWhiteSpace(itmName) && itmName != "Add New Item")
            {
                procureItemDetail.LoadItem = procureItemDetail.LoadItemMaster();
                itmUnit = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Unit"].ToString();
                txtProcureUnit.Text = itmUnit;
                txtItemCategory.Text = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Category"].ToString();
                txtItemSubcategory.Text = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["SubCategory"].ToString();
            }
            return itmUnit;
        }

        //private void txtProcureQty_TextChanged(object sender, EventArgs e)
        //{
        //    ////CalculateTotCost();
        //    CalculateTotCostExt();
        //}

        ////private void CalculateTotCost()
        ////{
        ////    if ((txtProcureQty.Text.ToCharArray().Any(x => Char.IsLetter(x) == true) || (txtProcureUnitCost.Text.ToCharArray().Any(x => Char.IsLetter(x) == true))))
        ////    {
        ////        XtraMessageBox.Show("!Invalid Input");
        ////        return;
        ////    }
        ////    try
        ////    {
        ////        if (string.IsNullOrEmpty(txtProcureUnitCost.Text)) txtProcureUnitCost.Text = "0";
        ////        if (string.IsNullOrEmpty(txtProcureQty.Text)) txtProcureQty.Text = "0";
        ////        txtProcureTotCost.Text = (Convert.ToDouble(txtProcureQty.Text) * Convert.ToDouble(txtProcureUnitCost.Text)).ToString();
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////    }
        ////}

        private void CalculateTotCostExt()
        {
            ////if ((txtProcureQty.Text.ToCharArray().Any(x => Char.IsLetter(x) == true)))// || (txtProcureUnitCost.Text.ToCharArray().Any(x => Char.IsLetter(x) == true))))
            ////{
            ////    XtraMessageBox.Show("!Invalid Input");
            ////    return;
            ////}
            try
            {
                //if (string.IsNullOrEmpty(txtProcureUnitCost.Text)) txtProcureUnitCost.Text = "0";

                ////if (string.IsNullOrEmpty(txtProcureQty.Text)) txtProcureQty.Text = "0";
                txtProcureTotCost.Text = (Convert.ToDouble(dpnProcureQty.Value) * Convert.ToDouble(nUpdnProcureUnitCost.Value)).ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ////private void txtProcureUnitCost_TextChanged(object sender, EventArgs e)
        ////{
        ////    CalculateTotCost();
        ////}
        private void DisableControls()
        {
            txtProcureTotCost.Enabled = false;
            txtProcBatchno.Enabled = false;
            txtProcureUnit.Enabled = false;
        }
        private Boolean ValidateProcureDetail()
        {
            bool IsValid = true;

            int itmCount = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == cmbProcureItem.Text).ToList().Count();
            if (itmCount == 0)
            {
                XtraMessageBox.Show("Wrong text in Item field! Please rectify");
                cmbProcureItem.Focus();
                IsValid = false;
            }
            else if (dpnProcureQty.Value ==0)
            {
                XtraMessageBox.Show("Please fill Procure Quantity!");
                dpnProcureQty.Focus();
                IsValid = false;
            }
           
            else if (nUpdnProcureUnitCost.Value==0)
            {
                XtraMessageBox.Show("Please fill Unit-Cost!");
                nUpdnProcureUnitCost.Focus();
                IsValid = false;
            }

            ////else if (string.IsNullOrEmpty(txtProcureUnitCost.Text))
            ////{
            ////    XtraMessageBox.Show("Please fill Unit-Cost!");
            ////    txtProcureUnitCost.Focus();
            ////    IsValid = false;
            ////}
            ////else if (!Regex.IsMatch(txtProcureUnitCost.Text, @"^\d+$"))
            ////{
            ////    XtraMessageBox.Show("Invalid input in Unit-Cost");
            ////    txtProcureUnitCost.Focus();
            ////    IsValid = false;
            ////}
            return IsValid;
        }

        private void btnAddnewItem_Click(object sender, EventArgs e)
        {
            AddNewItemMaster("Add New Item");
        }

        private void btnProcItemDetailDelete_Click(object sender, EventArgs e)
        {
            MapProcureDetailViewToObject();
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                procureItemDetail.DeleteProcurementDetailData(procureItemDetail);
                XtraMessageBox.Show("Record Deleted Successfully.");
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        //private void cmbProcureItem_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    procureItemDetail.LoadItem.DefaultView.RowFilter = string.Format("ItemName like '{0}%'", cmbProcureItem.Text);

        //    cmbProcureItem.DataSource = procureItemDetail.LoadItem;

        //    // if all values removed, bind the original full list again
        //    if (String.IsNullOrWhiteSpace(cmbProcureItem.Text))
        //    {
        //        procureItemDetail.LoadItem = procureItemDetail.LoadItemMaster();

        //        var itemcount = procureItemDetail.LoadItem.Rows.Count;
        //        for (int i = 0; i < itemcount; i++)
        //        {
        //            cmbProcureItem.Items.Add(procureItemDetail.LoadItem.Rows[i]["ItemName"]);
        //        }
        //    }

        //}
        public bool CheckItemExist()
        {
            bool IsItemExist = false;
            DataTable dt = procureItemDetail.GetProcureItemDetailByDocNo(procureItemDetail);
            if (dt.AsEnumerable().Where(X => X.Field<string>("ItemCode") == procureItemDetail.ItemCode).Count() > 0)
            {
                string itmName = dt.AsEnumerable().Where(X => X.Field<string>("ItemCode") == procureItemDetail.ItemCode).ToList().FirstOrDefault()["Item"].ToString();
                if (!string.IsNullOrWhiteSpace(itmName))
                {
                    IsItemExist = true;
                }
            }
            return IsItemExist;
        }

        //private void cmbProcureItem_TextUpdate(object sender, EventArgs e)
        //{
        //    string filter_param = cmbProcureItem.Text;

        //    var filteredItems = procureItemDetail.LoadItem.AsEnumerable().Where(x => x.Field<string>("ItemName").Contains(filter_param)).ToList();
        //    // another variant for filtering using StartsWith:
        //    // List<string> filteredItems = arrProjectList.FindAll(x => x.StartsWith(filter_param));

        //    cmbProcureItem.DataSource = filteredItems;

        //    if (String.IsNullOrWhiteSpace(filter_param))
        //    {
        //        LoadItems();
        //    }
        //    cmbProcureItem.DroppedDown = true;

        //    // this will ensure that the drop down is as long as the list
        //    cmbProcureItem.IntegralHeight = true;

        //    // remove automatically selected first item
        //    cmbProcureItem.SelectedIndex = -1;

        //    cmbProcureItem.Text = filter_param;

        //    // set the position of the cursor
        //    cmbProcureItem.SelectionStart = filter_param.Length;
        //    cmbProcureItem.SelectionLength = 0;
        //}

        private void cmbProcureItem_Leave(object sender, EventArgs e)
        {
            int itmCount = procureItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == cmbProcureItem.Text).ToList().Count();
            if (itmCount == 0 && !string.IsNullOrEmpty(cmbProcureItem.Text))
            {
                XtraMessageBox.Show("Wrong text in Item field! Please rectify");
                cmbProcureItem.Focus();
                return;
            }
        }
        private void DisableControlPermanent()
        {
            txtItemSubcategory.Enabled = false;
            txtItemCategory.Enabled = false;
            txtProcureUnit.Enabled = false;
        }

        private void nUpdnProcureUnitCost_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotCostExt();
        }

        //private void nUpdnProcureUnitCost_Leave(object sender, EventArgs e)
        //{
        //    CalculateTotCostExt();
        //}

        private void nUpdnProcureUnitCost_KeyDown(object sender, KeyEventArgs e)
        {
            CalculateTotCostExt();
        }

        private void nUpdnProcureUnitCost_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotCostExt();
        }
    }
}
