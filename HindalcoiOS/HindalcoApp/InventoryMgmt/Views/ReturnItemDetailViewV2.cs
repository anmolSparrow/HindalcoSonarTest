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

namespace HindalcoiOS.InventoryMgmt
{
    public partial class ReturnItemDetailView : XtraForm
    {
        public EventHandler<string> GetValue;
        public ReturnItemDetail returnItemDetail { get; set; }
        public bool IsMaintenance { get; set; }
        public object Selecteditem { get; set; }
        public ReturnItemDetailView()
        {
            InitializeComponent();
            returnItemDetail = new ReturnItemDetail();
        }
        public ReturnItemDetailView(String documentNo, String referenceNo, Boolean IsNew,Boolean IsMaint)
        {
            InitializeComponent();
            returnItemDetail = new ReturnItemDetail();
            returnItemDetail.DocumentNo = documentNo;
            returnItemDetail.ReferenceNo = referenceNo;
            btnReturnDetailDelete.Visible = false;
            btnReturnItemDetailAdd.Text = "Save";
            IsMaintenance = IsMaint;
            if (IsNew == false)
            {
                btnReturnDetailDelete.Visible = true;
                btnReturnItemDetailAdd.Text = "Update";
            }
        }

        private void btnReturnItemDetailAdd_Click(object sender, EventArgs e)
        {
            //string itmcode = returnItemDetail.ItemCode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == cmbReturnItem.Text).ToList().FirstOrDefault()["ItemCode"].ToString();
            //double consumedQty = returnItemDetail.GetBillWiseConsumedItemQty(returnItemDetail.ReferenceNo, itmcode, cmbReturnbatch.Text);
            double consumedQty =Convert.ToDouble(txtConsumedQty.Text);
            double retnQty = Convert.ToDouble(dpnReturnQty.Value);// Convert.ToDouble(txtReturnQty.Text);
            if (retnQty <= consumedQty)
                MapReturnDetailData();
            else
            {
                XtraMessageBox.Show("Return Qty exceeds than Consumed Qty", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dpnReturnQty.Focus();
            }
        }

        private void ReturnItemDetailView_Load(object sender, EventArgs e)
        {
            DisableControlPermanent();
            LoadItems();
        }
        private void LoadItems()
        {
            returnItemDetail.LoadItem = returnItemDetail.LoadItemMaster(returnItemDetail.ReferenceNo);
            IList<string> itemList = returnItemDetail.LoadItem.AsEnumerable().Select(a => a.Field<string>("Item")).Distinct().ToList();
           // IList<string> itemList = returnItemDetail.LoadItem.AsEnumerable().Select(a => a.Field<string>("ItemName")).Distinct().ToList();

            var itemcount = itemList.Count();
            foreach (var itemName in itemList)
            {
                
                cmbReturnItem.Items.Add(itemName);
            }
            if(IsMaintenance)
            {
                cmbReturnItem.SelectedItem = Selecteditem;
                cmbReturnItem.Enabled = false;
            }

            //var itemcount = returnItemDetail.LoadItem.Rows.Count;
            //for (int i = 0; i < itemcount; i++)
            //{
            //    cmbReturnItem.Items.Add(returnItemDetail.LoadItem.Rows[i]["Item"]);
            //}
        }
        private void MapReturnDetailData()
        {
            try
            {
                int icount = 0;
                icount = Resources.Instance.IsReturnExit(returnItemDetail.DocumentNo, out icount);
                if (icount == 0 && IsMaintenance==false)
                {
                    returnItemDetail.DocumentNo = GenerateGlobalDocID("SP_GetReturnDocID", "RET");
                }
               
                if (cmbReturnItem.SelectedItem != null)
                    returnItemDetail.Item = cmbReturnItem.SelectedItem.ToString();
                else
                    returnItemDetail.Item = cmbReturnItem.Text;
                if (!string.IsNullOrWhiteSpace(returnItemDetail.Item))
                    returnItemDetail.ItemCode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == returnItemDetail.Item).ToList().FirstOrDefault()["ItemCode"].ToString();
                returnItemDetail.BatchNo = cmbReturnbatch.Text;
                returnItemDetail.ReturnQty = Convert.ToDouble(dpnReturnQty.Value);// Convert.ToDouble(txtReturnQty.Text);

                if (!string.IsNullOrWhiteSpace(cmbReturnItem.SelectedItem.ToString()))
                    returnItemDetail.UnitCode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == returnItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                else
                    returnItemDetail.UnitCode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == cmbReturnItem.Text).ToList().FirstOrDefault()["UnitCode"].ToString();
                if (!string.IsNullOrWhiteSpace(cmbReturnItem.SelectedItem.ToString()))
                    returnItemDetail.Unit = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == returnItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();
                else
                    returnItemDetail.Unit = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == cmbReturnItem.Text).ToList().FirstOrDefault()["Unit"].ToString();

                returnItemDetail.UnitCost = Convert.ToDouble(txtReturnUnitCost.Text);
                returnItemDetail.TotalCost = (Convert.ToDouble(dpnReturnQty.Value) * Convert.ToDouble(txtReturnUnitCost.Text));
                returnItemDetail.SetReturnItemDetailValue(returnItemDetail);
                XtraMessageBox.Show("Record Inserted Successfully");
                DialogResult = DialogResult.OK;
                //.this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MapReturnDetailViewToObject()
        {
            try
            {
                if (cmbReturnItem.SelectedItem != null)
                    returnItemDetail.Item = cmbReturnItem.SelectedItem.ToString();
                else
                    returnItemDetail.Item = cmbReturnItem.Text;
                if (!string.IsNullOrWhiteSpace(returnItemDetail.Item))
                    returnItemDetail.ItemCode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("Item") == returnItemDetail.Item).ToList().FirstOrDefault()["ItemCode"].ToString();
                returnItemDetail.BatchNo = cmbReturnbatch.Text;
                DialogResult = DialogResult.OK;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MapReturnDetailView(ReturnItemDetail retnDetail)
        {
            try
            {
                cmbReturnbatch.Text = retnDetail.BatchNo;
                cmbReturnItem.Text = retnDetail.Item;
                dpnReturnQty.Value =Convert.ToDecimal(retnDetail.ReturnQty);
                txtReturnUnitCost.Text = retnDetail.UnitCost.ToString();
                txtReturnTotCost.Text = retnDetail.TotalCost.ToString();
                retnDetail.LoadItem = retnDetail.LoadItemMaster();
                txtReturnUnit.Text = retnDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == retnDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();
                txtReturnCat.Text = retnDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == retnDetail.ItemCode).ToList().FirstOrDefault()["Category"].ToString();
                txtReturnSubCat.Text = retnDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == retnDetail.Item).ToList().FirstOrDefault()["SubCategory"].ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReturnItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReturnItem.SelectedItem == null) return;
            GetUnit(cmbReturnItem.SelectedItem.ToString());
            //LoadBatch(GetItemCode(cmbReturnItem.SelectedItem.ToString()));
            LoadBatch(returnItemDetail.ReferenceNo, cmbReturnItem.SelectedItem.ToString());// GetItemCode(cmbReturnItem.SelectedItem.ToString()));
        }
        public string GetUnit(string itmName)
        {
            returnItemDetail.LoadItem = returnItemDetail.LoadItemMaster();
            string itmUnit = string.Empty;
            if (!string.IsNullOrWhiteSpace(itmName))
            {
                itmUnit = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Unit"].ToString();
                txtReturnUnit.Text = itmUnit;
                txtReturnUnit.Text = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Unit"].ToString();
                txtReturnCat.Text = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Category"].ToString();
                txtReturnSubCat.Text = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["SubCategory"].ToString();
            }
            return itmUnit;
        }
        private void LoadBatch(string RefNo, string itmName)
        {
            try
            {
                cmbReturnbatch.Items.Clear();
                cmbReturnbatch.Text = string.Empty;
                DataTable batchDt = (returnItemDetail.LoadItemMaster(RefNo).AsEnumerable().Where(X => X.Field<string>("Item") == itmName)).CopyToDataTable();
                returnItemDetail.LoadBatch = batchDt;
                var itemcount = batchDt.Rows.Count;
                for (int i = 0; i < itemcount; i++)
                {
                    cmbReturnbatch.Items.Add(batchDt.Rows[i]["BatchNo"]);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LoadBatchOld(string itmCode)
        //{
        //    cmbReturnbatch.Items.Clear();
        //    DataTable batchDt = returnItemDetail.GetAllBatch(itmCode);
        //    returnItemDetail.LoadBatch = batchDt;
        //    var itemcount = batchDt.Rows.Count;
        //    for (int i = 0; i < itemcount; i++)
        //    {
        //        cmbReturnbatch.Items.Add(batchDt.Rows[i]["BatchNo"]);
        //    }
        //}
        //public string GetItemCode(string itmName)
        //{
        //    string itmcode = string.Empty;
        //    if (!string.IsNullOrWhiteSpace(itmName))
        //        itmcode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("Item") == itmName).ToList().FirstOrDefault()["ItemCode"].ToString();
        //    return itmcode;
        //}

        //private void txtReturnQty_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtReturnQty.Text)) txtReturnQty.Text = "0";
        //    if (string.IsNullOrEmpty(txtReturnUnitCost.Text)) txtReturnUnitCost.Text = "0";
        //    try
        //    {
        //        txtReturnTotCost.Text = (Convert.ToDouble(txtReturnQty.Text) * Convert.ToDouble(txtReturnUnitCost.Text)).ToString();
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void cmbReturnbatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbReturnbatch.SelectedItem!=null)
                txtReturnUnitCost.Text = LoadAvailableQty(cmbReturnbatch.SelectedItem.ToString());
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string LoadAvailableQty(string batchNo)
        {
            txtReturnUnitCost.Text = string.Empty;// Clear();
            txtConsumedQty.Text = string.Empty;
            string unitCost = string.Empty;
            try
            {
                if (!string.IsNullOrWhiteSpace(batchNo))
                {
                    unitCost = returnItemDetail.LoadBatch.AsEnumerable().Where(X => X.Field<string>("BatchNo") == batchNo).ToList().FirstOrDefault()["UnitCost"].ToString();
                    txtReturnUnitCost.Text = unitCost;
                    txtConsumedQty.Text = GetConsumedItemQty().ToString();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return unitCost;
        }

        private void btnReturnDetailDelete_Click(object sender, EventArgs e)
        {
            MapReturnDetailViewToObject();
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                returnItemDetail.DeleteReturnDetailData(returnItemDetail);
                XtraMessageBox.Show("Record Deleted Successfully.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        //private void cmbReturnItem_Leave(object sender, EventArgs e)
        //{
        //    int itmCount = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == cmbReturnItem.Text).ToList().Count();
        //    if (itmCount == 0)
        //    {
        //        XtraMessageBox.Show("Wrong text in Item field! Please rectify");
        //        cmbReturnItem.Focus();
        //        return;
        //    }
        //}
        private void DisableControlPermanent()
        {
            txtReturnUnit.Enabled = false;
            txtReturnSubCat.Enabled = false;
            txtReturnCat.Enabled = false;
            txtReturnTotCost.Enabled = false;
            txtReturnUnitCost.Enabled = false;
        }

        private double GetConsumedItemQty()
        {
            double consumedQty = 0;
            string itmcode = returnItemDetail.ItemCode = returnItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == cmbReturnItem.Text).ToList().FirstOrDefault()["ItemCode"].ToString();
            if(!string.IsNullOrEmpty(itmcode))
            consumedQty = returnItemDetail.GetBillWiseConsumedItemQty(returnItemDetail.ReferenceNo, itmcode, cmbReturnbatch.Text);
            return  consumedQty;
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
        private void dpnReturnQty_ValueChanged(object sender, EventArgs e)
        {
            txtReturnTotCost.Text = (Convert.ToDouble(dpnReturnQty.Value) * Convert.ToDouble(txtReturnUnitCost.Text)).ToString();
        }
    }
}
