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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.InventoryMgmt
{
    public partial class ConsumpItemDetailView : XtraForm
    {
        public EventHandler<string> GetValue;
        public delegate void MapInventory(params object[] args);
        public event MapInventory mapInventory;
        public bool IsMaintenance{ set; get; }
        public ConsumpItemDetail consumItemDetail { get; set; }

        public ConsumpItemDetailView()
        {
            InitializeComponent();
            consumItemDetail = new ConsumpItemDetail();
        }
        public ConsumpItemDetailView(String documentNo, String referenceNo, Boolean IsNew, Boolean IsMaint)
        {
            InitializeComponent();
            consumItemDetail = new ConsumpItemDetail();
            consumItemDetail.DocumentNo = documentNo;
            consumItemDetail.ReferenceNo = referenceNo;
            btnConsumpDetailDelete.Visible = false;
            btnComsumItemDetailAdd.Text = "Save";
            if (IsNew == false)
            {
                btnConsumpDetailDelete.Visible = true;
                btnComsumItemDetailAdd.Text = "Update";
            }
            IsMaintenance = IsMaint;
        }
        public ConsumpItemDetailView(String documentNo)
        {
            InitializeComponent();
            consumItemDetail = new ConsumpItemDetail();
            consumItemDetail.DocumentNo = documentNo;
        }

        private void ConsumpItemDetailView_Load(object sender, EventArgs e)
        {
            DisableControlPermanent();
            LoadItems();
        }
        private void btnComsumItemDetailAdd_Click(object sender, EventArgs e)
        {
            if (ValidateConsumptionDetail() == false) return;
            if (ValidateConsumedQty() == false) return;
            
            MapConsumedDetailData();
        }

        private void MapConsumedDetailData()
        {
            try
            {
                
                int icount = 0;
                icount = Resources.Instance.IsConsumptionExit(consumItemDetail.DocumentNo, out icount);
                if (icount == 0 && IsMaintenance==false)
                {
                    consumItemDetail.DocumentNo = GenerateGlobalDocID("SP_GetConsumpDocID", "CON");
                }
                if (cmbConsumedItem.SelectedItem != null)
                    consumItemDetail.Item = cmbConsumedItem.SelectedItem.ToString();
                else
                    consumItemDetail.Item = cmbConsumedItem.Text;
                if (!string.IsNullOrWhiteSpace(consumItemDetail.Item))
                    consumItemDetail.ItemCode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == consumItemDetail.Item).ToList().FirstOrDefault()["ItemCode"].ToString();
                consumItemDetail.BatchNo = cmbConsumedbatch.Text;
                consumItemDetail.ConsumedQty =Convert.ToDouble(dpnConsumQty.Value);// Convert.ToDouble(txtConsumQty.Text);

                if (cmbConsumedItem.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbConsumedItem.SelectedItem.ToString()))
                    consumItemDetail.UnitCode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                else
                    consumItemDetail.UnitCode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                if (cmbConsumedItem.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbConsumedItem.SelectedItem.ToString()))
                    consumItemDetail.Unit = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();
                else
                    consumItemDetail.Unit = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();

                consumItemDetail.UnitCost = Convert.ToDouble(txtConsumeUnitCost.Text);
                consumItemDetail.TotalCost = (Convert.ToDouble(dpnConsumQty.Value) * Convert.ToDouble(txtConsumeUnitCost.Text));
                //itemReturn.Remarks = txtReturnRemarks.Text;
                //itemReturn.ConsumptionType = cmbReturnConsumpType.Text;
                consumItemDetail.SetConsumptionItemDetailValue(consumItemDetail);

                DialogResult = DialogResult.OK;
                if(IsMaintenance==false)
                XtraMessageBox.Show("Details Saved Succesfully");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
            //ViewReturnData();

        }

        private void MapConsumedDetailViewToObject()
        {
            try
            {
                if (cmbConsumedItem.SelectedItem != null)
                    consumItemDetail.Item = cmbConsumedItem.SelectedItem.ToString();
                else
                    consumItemDetail.Item = cmbConsumedItem.Text;
                if (!string.IsNullOrWhiteSpace(consumItemDetail.Item))
                    consumItemDetail.ItemCode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == consumItemDetail.Item).ToList().FirstOrDefault()["ItemCode"].ToString();
                consumItemDetail.BatchNo = cmbConsumedbatch.Text;
                consumItemDetail.ConsumedQty = Convert.ToDouble(dpnConsumQty.Value);// Convert.ToDouble(txtConsumQty.Text);

                if (cmbConsumedItem.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbConsumedItem.SelectedItem.ToString()))
                    consumItemDetail.UnitCode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                else
                    consumItemDetail.UnitCode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["UnitCode"].ToString();
                if (cmbConsumedItem.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbConsumedItem.SelectedItem.ToString()))
                    consumItemDetail.Unit = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();
                else
                    consumItemDetail.Unit = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemCode") == consumItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();

                consumItemDetail.UnitCost = Convert.ToDouble(txtConsumeUnitCost.Text);
                consumItemDetail.TotalCost = Convert.ToDouble(dpnConsumQty.Value) * Convert.ToDouble(txtConsumeUnitCost.Text);
                ////consumItemDetail.TotalCost = (Convert.ToDouble(txtConsumQty.Text) * Convert.ToDouble(txtConsumeUnitCost.Text));
                // XtraMessageBox.Show("Details Saved Succesfully");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }

        }
        private void LoadItems()
        {
            consumItemDetail.LoadItem = consumItemDetail.LoadItemMaster();
            var itemcount = consumItemDetail.LoadItem.Rows.Count;
            for (int i = 0; i < itemcount; i++)
            {
                cmbConsumedItem.Items.Add(consumItemDetail.LoadItem.Rows[i]["ItemName"]);
            }
            //cmbConsumedItem.Items.Add("Add New Item");

        }
        private void LoadBatch(string itmCode)
        {
            DataTable batchDt = consumItemDetail.GetAllBatch(itmCode);
            consumItemDetail.LoadBatch = batchDt;
            var itemcount = batchDt.Rows.Count;
            cmbConsumedbatch.Items.Clear();
            cmbConsumedbatch.Text = string.Empty;
            for (int i = 0; i < itemcount; i++)
            {
                cmbConsumedbatch.Items.Add(batchDt.Rows[i]["BatchNo"]);
            }
        }
        private string LoadAvailableQty(string batchNo)
        {
            txtConsumAvailQty.Text = string.Empty;// Clear();
            txtConsumeUnitCost.Text = string.Empty;//Clear();
            txtConsumTotCost.Text = string.Empty;
            dpnConsumQty.Value = 0;
            string avlQty = string.Empty;
            if (!string.IsNullOrWhiteSpace(batchNo))
            {
                avlQty = consumItemDetail.LoadBatch.AsEnumerable().Where(X => X.Field<string>("BatchNo") == batchNo).ToList().FirstOrDefault()["AvailableQty"].ToString();
                txtConsumAvailQty.Text = avlQty;
                txtConsumeUnitCost.Text = consumItemDetail.LoadBatch.AsEnumerable().Where(X => X.Field<string>("BatchNo") == batchNo).ToList().FirstOrDefault()["UnitCost"].ToString();
            }
            return avlQty;
        }

        public void MapConsumedDetailView(ConsumpItemDetail conItemDetail)
        {
            try
            {
                conItemDetail.LoadItem = conItemDetail.LoadItemMaster();
                conItemDetail.LoadBatch = conItemDetail.GetAllBatch(conItemDetail.ItemCode);
                cmbConsumedItem.Text = conItemDetail.Item;
                cmbConsumedbatch.Text = conItemDetail.BatchNo;
                txtConsumeUnitCost.Text = conItemDetail.UnitCost.ToString();
                txtConsumTotCost.Text = conItemDetail.TotalCost.ToString();
                dpnConsumQty.Value=(decimal)(conItemDetail.ConsumedQty);
                ////txtConsumQty.Text = conItemDetail.ConsumedQty.ToString();
                if (conItemDetail.LoadBatch.Rows.Count > 0 && conItemDetail.LoadBatch.AsEnumerable().Where(X => X.Field<string>("BatchNo") == conItemDetail.BatchNo).ToList().Count > 0)
                    txtConsumAvailQty.Text = conItemDetail.LoadBatch.AsEnumerable().Where(X => X.Field<string>("BatchNo") == conItemDetail.BatchNo).ToList().FirstOrDefault()["AvailableQty"].ToString();
                conItemDetail.LoadItem = conItemDetail.LoadItemMaster();
                txtConsumedUnit.Text = conItemDetail.LoadItemMaster().AsEnumerable().Where(X => X.Field<string>("ItemCode") == conItemDetail.ItemCode).ToList().FirstOrDefault()["Unit"].ToString();
                txtConsumpSubCat.Text = conItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == conItemDetail.Item).ToList().FirstOrDefault()["SubCategory"].ToString();
                txtConsumpCat.Text = conItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == conItemDetail.Item).ToList().FirstOrDefault()["Category"].ToString();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbConsumedItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUnit(cmbConsumedItem.SelectedItem.ToString());

            LoadBatch(GetItemCode(cmbConsumedItem.SelectedItem.ToString()));
        }

        public string GetItemCode(string itmName)
        {
            string itmcode = string.Empty;
            if (!string.IsNullOrWhiteSpace(itmName))
                itmcode = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["ItemCode"].ToString();
            return itmcode;
        }
        public string GetUnit(string itmName)
        {
            string itmUnit = string.Empty;
            if (!string.IsNullOrWhiteSpace(itmName))
            {
                itmUnit = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Unit"].ToString();
                txtConsumedUnit.Text = itmUnit;
                txtConsumpCat.Text = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["Category"].ToString();
                txtConsumpSubCat.Text = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == itmName).ToList().FirstOrDefault()["SubCategory"].ToString();
            }
            return itmUnit;
        }

        private void cmbConsumedbatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsumAvailQty.Text = LoadAvailableQty(cmbConsumedbatch.SelectedItem.ToString());
        }

        //private void txtConsumQty_TextChanged(object sender, EventArgs e)
        //{
        //  //if(ValidateConsumedQtyFormat()==false)return;
          
        //    if (string.IsNullOrEmpty(txtConsumQty.Text) || string.IsNullOrEmpty(txtConsumeUnitCost.Text)) return;
        //    //else
        //    {
        //        //if (ValidateConsumedQtyFormat() == false) return;
        //        //else
        //         txtConsumTotCost.Text = (Convert.ToDouble(txtConsumQty.Text) * Convert.ToDouble(txtConsumeUnitCost.Text)).ToString();
        //    }
          
        //}
        private Boolean ValidateConsumptionDetail()
        {
            bool IsValid = true;
            if (dpnConsumQty.Value <=0)
            {
                XtraMessageBox.Show("Please input quantity other than 0 or negetive values!");
                IsValid = false;
            }
          else if (string.IsNullOrEmpty(cmbConsumedItem.Text) || string.IsNullOrEmpty(cmbConsumedbatch.Text))// || string.IsNullOrEmpty(txtConsumQty.Text))
            {
                XtraMessageBox.Show("Please Fill Mandatory Fields!");
                IsValid = false;
            }
            return IsValid;
        }
        private Boolean ValidateConsumedQty()
        {
            bool IsValid = true;
        
            if (dpnConsumQty.Value > 0 || !string.IsNullOrEmpty(txtConsumAvailQty.Text))
            {
                double AvlQty = 0;
                double.TryParse(txtConsumAvailQty.Text, out AvlQty);
                if (decimal.ToDouble(dpnConsumQty.Value) > AvlQty)
                {
                    XtraMessageBox.Show("Input Qty exceeds available Qty!");
                    IsValid = false;
                }
            }
            //if (!string.IsNullOrEmpty(txtConsumQty.Text) || !string.IsNullOrEmpty(txtConsumAvailQty.Text))
            //{
            //    double AvlQty = 0;
            //    double.TryParse(txtConsumAvailQty.Text, out AvlQty);
            //    if (double.Parse(txtConsumQty.Text) > AvlQty)
            //    {
            //        XtraMessageBox.Show("Input Qty exceeds available Qty!");
            //        IsValid = false;
            //    }
            //}
            return IsValid;
        }
      
        //   private Boolean ValidateConsumedQtyFormat()
     //    {

     //       bool IsValid = true;

     //       if (!string.IsNullOrWhiteSpace(txtConsumQty.Text))
     //       {
     //           var regex = new Regex(@"((\d+)((\.\d{1,2})?))$");
     //           if (regex.IsMatch(txtConsumQty.ToString()))
     //           {
     //               XtraMessageBox.Show("Invalid character in ItemName!");
     //               txtConsumQty.Focus();
     //               IsValid = false;
     //           }
     //       }
       
     //   return IsValid;
     //}

        private void btnConsumpDetailDelete_Click(object sender, EventArgs e)
        {
            MapConsumedDetailViewToObject();
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                consumItemDetail.DeleteConsumeDetailData(consumItemDetail);
                XtraMessageBox.Show("Record Deleted Successfully.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void cmbConsumedItem_Leave(object sender, EventArgs e)
        {
            int itmCount = consumItemDetail.LoadItem.AsEnumerable().Where(X => X.Field<string>("ItemName") == cmbConsumedItem.Text).ToList().Count();
            if (itmCount == 0)
            {
                XtraMessageBox.Show("Wrong text in Item field! Please rectify");
                cmbConsumedItem.Focus();
                return;
            }
        }
        private void DisableControlPermanent()
        {
            txtConsumedUnit.Enabled = false;
            txtConsumpSubCat.Enabled = false;
            txtConsumpCat.Enabled = false;
            txtConsumTotCost.Enabled = false;
            txtConsumAvailQty.Enabled = false;
            txtConsumeUnitCost.Enabled = false;
        }

        

        //private void txtConsumQty_Leave(object sender, EventArgs e)
        //{
        //    //if (string.IsNullOrEmpty(txtConsumQty.Text) || string.IsNullOrEmpty(txtConsumeUnitCost.Text)) return;
        //    //txtConsumTotCost.Text = (Convert.ToDouble(txtConsumQty.Text) * Convert.ToDouble(txtConsumeUnitCost.Text)).ToString();
        //}

        private void txtConsumQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtConsumQty.Text) || string.IsNullOrEmpty(txtConsumeUnitCost.Text)) return;
            //txtConsumTotCost.Text = (Convert.ToDouble(txtConsumQty.Text) * Convert.ToDouble(txtConsumeUnitCost.Text)).ToString();
            CalculateTotValue();
        }

        private void ConsumpItemDetailView_MouseHover(object sender, EventArgs e)
        {
            if (decimal.ToDouble(dpnConsumQty.Value) < 0 || string.IsNullOrEmpty(txtConsumeUnitCost.Text)) return;
            txtConsumTotCost.Text = (decimal.ToDouble(dpnConsumQty.Value) * Convert.ToDouble(txtConsumeUnitCost.Text)).ToString();
        }
        private void CalculateTotValue()
        {
            if (decimal.ToDouble(dpnConsumQty.Value) < 0 || string.IsNullOrEmpty(txtConsumeUnitCost.Text)) return;
            txtConsumTotCost.Text = (decimal.ToDouble(dpnConsumQty.Value) * Convert.ToDouble(txtConsumeUnitCost.Text)).ToString();
        }
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
    }
}
