using ClosedXML.Excel;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.InventoryMgmt
{
    public partial class ItemMasterView : XtraForm
    {
        //public EventHandler<string> GetValue;
        public event SomeEvents GetValue;
        private ItemMaster itemMaster { get; set; }
        public ItemMasterView(Boolean IsRoot)
        {
            itemMaster = new ItemMaster();
            InitializeComponent();
            btnItemUpload.Visible = false;
            btnOpeningUpload.Visible = false;
            btnItemDelete.Visible = false;
            btnExportItem.Visible = true;
            if (IsRoot == true)
            {
                btnItemUpload.Visible = true;
                btnOpeningUpload.Visible = true;
                btnExportItem.Visible = true;
            }
        }

        private void MapItemMasterToData(Boolean IsNew)
        {
            try
            {
                string xMsg = "New Item Added Successfully";
                itemMaster.ItemCode = txtItemCode.Text;
                itemMaster.ItemName = txtItemName.Text;
                itemMaster.CreatedDate = DateTime.Now;
                if (cmbUnit.SelectedItem != null && !String.IsNullOrEmpty(cmbUnit.SelectedItem.ToString()))
                {
                    itemMaster.Unit = cmbUnit.SelectedItem.ToString();
                }
                else
                {
                    itemMaster.Unit = cmbUnit.Text;
                }
                itemMaster.UnitCode = itemMaster.LoadUnit().AsEnumerable().Where(X => X.Field<string>("UnitName") == itemMaster.Unit).ToList().FirstOrDefault()["UnitCode"].ToString();

                if (cmbSubCategory.SelectedItem != null && cmbSubCategory.SelectedItem.ToString() != "Add New Category")
                {
                    itemMaster.Category = cmbSubCategory.SelectedItem.ToString();
                    itemMaster.CategoryCode = itemMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == cmbSubCategory.SelectedItem.ToString()).ToList().FirstOrDefault()["CategoryCode"].ToString();
                }
                else
                {
                    itemMaster.Category = cmbSubCategory.Text;
                    itemMaster.CategoryCode = itemMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == cmbSubCategory.Text).ToList().FirstOrDefault()["CategoryCode"].ToString();
                }
                itemMaster.Make = txtMake.Text;
                itemMaster.Model = txtModel.Text;
                itemMaster.ThresholdLimit = Convert.ToDouble(dpnThreslimit.Value.ToString());// Convert.ToDouble(txtThreshold.Text);
                itemMaster.SetItemMasterData(itemMaster);
                if (!IsNew)
                    xMsg = "Item updated Successfully";
                XtraMessageBox.Show(xMsg);
                ViewItemMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ItemMasterView_Load(object sender, EventArgs e)
        {
            txtItemName.Focus();
            LoadAllMasters();
            ViewItemMaster();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateItemMasterSpace() == false) return;
            if (ValidateItemMasterText() == false) return;
            if (itemMaster.GetAllItems().AsEnumerable().Where(X => X.Field<string>("ItemCode") == txtItemCode.Text).ToList().Count > 0)
            {
                DialogResult dres = XtraMessageBox.Show("ItemCode Already Exist! Are you want to update ?", "Alert", MessageBoxButtons.YesNo);
                if (dres == DialogResult.Yes)
                {
                    //if (ValidateItemMaster() == false) return;
                    MapItemMasterToData(false);
                    this.GetValue.Invoke(this.txtItemName.Text, this.cmbUnit.Text, txtParentCategory.Text, cmbSubCategory.Text);
                    ResetAllControls();
                }
                else
                    return;
            }
            else
            {
                //if (ValidateItemMaster() == false) return;
                MapItemMasterToData(true);
                this.GetValue.Invoke(this.txtItemName.Text, this.cmbUnit.Text, txtParentCategory.Text, cmbSubCategory.Text);
            }
            btnAdd.Text = "Add";
        }



        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string ccode=  GetCatCode();
            //  if (cmbCategory.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbCategory.SelectedItem.ToString()))
            //      LoadSubcategory(ccode);
            //  CheckCategoryData();
        }
        private void LoadUnits()
        {
            if(cmbUnit.Items.Count>0)
            cmbUnit.Items.Clear();
            for (int i = 0; i < itemMaster.LoadUnit().Rows.Count; i++)
            {
                cmbUnit.Items.Add(itemMaster.LoadUnit().Rows[i]["UnitName"]);
            }
            //cmbUnit.Items.Add("Add New Unit");
        }
        private void Loadcategory()
        {
            for (int i = 0; i < itemMaster.GetAllCategory().Rows.Count; i++)
            {
                cmbSubCategory.Items.Add(itemMaster.GetAllCategory().Rows[i]["CategoryName"]);
            }
            cmbSubCategory.Items.Add("Add New Category");
        }
        private void LoadSubcategory(String parentCode)
        {
            for (int i = 0; i < itemMaster.GetAllSubCategory(parentCode).Rows.Count; i++)
            {
                cmbSubCategory.Items.Add(itemMaster.GetAllSubCategory(parentCode).Rows[i]["CategoryName"]);
            }
            //cmbUnit.Items.Add("Add New Unit");
        }
        private void LoadSubcategory()
        {
            try
            {
                DataTable catSubDt = itemMaster.GetAllCategory();
                catSubDt = catSubDt.AsEnumerable().Where(X => X.Field<string>("Parent") != "Primary").ToList().CopyToDataTable();
                for (int i = 0; i < catSubDt.Rows.Count; i++)
                {
                    cmbSubCategory.Items.Add(catSubDt.Rows[i]["CategoryName"]);
                }
            }
            catch
            {

            }
            //cmbUnit.Items.Add("Add New Unit");
        }
        private void ViewItemMaster()
        {
            if (itemMaster.GetAllItems().Rows.Count == 0) return;
            dgvItemMaster.DataSource = itemMaster.GetAllItems();
            dgvItemMaster.Columns["UnitCode"].Visible = false;
            dgvItemMaster.Columns["CategoryCode"].Visible = false;
            dgvItemMaster.Columns["SubCategoryCode"].Visible = false;
            dgvItemMaster.Columns["itemCode"].HeaderText = "Item Code";
            dgvItemMaster.Columns["itemName"].HeaderText = "Item Name";
            dgvItemMaster.Columns["CreatedDate"].HeaderText = "Created Date";
            dgvItemMaster.Columns["SubCategory"].HeaderText = "Sub Category";
            dgvItemMaster.Columns["Threshold"].HeaderText = "Minimum Stock";

            dgvItemMaster.Sort(dgvItemMaster.Columns["itemCode"], ListSortDirection.Ascending);

        }
        private void CheckUnitData()
        {
            //string name = cmbUnit.SelectedItem.ToString();
            ///if (name == "Add New Unit")
            //{
            UOMView uOMView = new UOMView();
            uOMView.GetValue += UnitHandlerEvent;
            if (uOMView.ShowDialog() == DialogResult.OK)
            {
                uOMView.Close();
                uOMView.Dispose();
                LoadUnits();
            }
            else
            {
                uOMView.Close();
                uOMView.Dispose();
                LoadUnits();
            }
            //}
        }
        private void CheckCategoryData()
        {
            //string name = cmbSubCategory.SelectedItem.ToString();
            //if (name == "Add New Category")
            {
                CategoryMasterView catView = new CategoryMasterView();
                catView.GetValue += CatHandlerEvent;

                if (catView.ShowDialog() == DialogResult.OK)
                {
                    ViewItemMaster();
                }
                else
                {
                    catView.Close();
                    catView.Dispose();
                }
            }
        }

        private void CatHandlerEvent(object sender, string value)
        {
            if (!cmbSubCategory.Items.Contains(value))
            {
                cmbSubCategory.Items.Add(value);
                cmbSubCategory.Text = value.ToString();
                txtParentCategory.Text = GetParentCategory(cmbSubCategory.Text);
            }
        }
        private void UnitHandlerEvent(object sender, string value)
        {
            if (!cmbUnit.Items.Contains(value))
            {
                cmbUnit.Items.Add(value);
                cmbUnit.Text = value.ToString();
            }
        }
        private string GetCatCode()
        {
            string catcode = string.Empty;
            if (cmbSubCategory.SelectedItem.ToString() != "Add New Category")
            {
                itemMaster.Category = cmbSubCategory.SelectedItem.ToString();
                itemMaster.CategoryCode = itemMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == cmbSubCategory.SelectedItem.ToString()).ToList().FirstOrDefault()["CategoryCode"].ToString();
                catcode = itemMaster.CategoryCode;
            }
            return catcode;
        }
        private string GetParentCategory(string subCategory)
        {

            string pCat = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(subCategory) && subCategory != "Add New Category")
                    pCat = itemMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == subCategory).ToList().FirstOrDefault()["Parent"].ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pCat;
        }

        private void LoadAllMasters()
        {
            LoadUnits();
            //Loadcategory();
            LoadSubcategory();
        }

        private void ItemMasterView_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string ccode = GetCatCode();
            //CheckCategoryData();
            txtParentCategory.Text = GetParentCategory(cmbSubCategory.Text);
        }
        private Boolean ValidateItemMasterSpace()
        {
            bool IsValid = true;
            //if (String.IsNullOrEmpty(txtItemName.Text) || String.IsNullOrEmpty(txtMake.Text) || String.IsNullOrEmpty(txtModel.Text) || String.IsNullOrEmpty(txtItemCode.Text)
            //   || string.IsNullOrEmpty(cmbSubCategory.Text) || string.IsNullOrEmpty(cmbUnit.Text) || dpnThreslimit.Value <= 0)
            //{
            //    XtraMessageBox.Show("!Please fill all fields");
            //    IsValid = false;
            //}
            if (String.IsNullOrWhiteSpace(txtItemName.Text))
            {
                XtraMessageBox.Show("Item Name Missing !");
                txtItemName.Focus();
                IsValid = false;
                return IsValid;
            }
           


             else if (String.IsNullOrWhiteSpace(txtItemCode.Text))
            {
                XtraMessageBox.Show("Please fill Item Code.");
                txtItemCode.Focus();
                IsValid = false;
                return IsValid;
            }

            else if (String.IsNullOrWhiteSpace(txtMake.Text))
            {
                XtraMessageBox.Show("Please fill Make");
                txtMake.Focus();
                IsValid = false;
                return IsValid;
            }

            else if (String.IsNullOrWhiteSpace(txtModel.Text))
            {
                XtraMessageBox.Show("Please fill Model");
                txtModel.Focus();
                IsValid = false;
                return IsValid;
            }

            else if (String.IsNullOrWhiteSpace(cmbSubCategory.Text))
            {
                XtraMessageBox.Show("Please fill SubCategory");
                cmbSubCategory.Focus();
                IsValid = false;
                return IsValid;
            }
            else if (String.IsNullOrWhiteSpace(cmbUnit.Text))
            {
                XtraMessageBox.Show("Please fill Unit");
                cmbUnit.Focus();
                IsValid = false;
                return IsValid;
            }
            else if (dpnThreslimit.Value <= 0)
            {
                XtraMessageBox.Show("Minimum Stock should not be Zero");
                cmbSubCategory.Focus();
                IsValid = false;
                return IsValid;
            }
            return IsValid;
        }
        private Boolean ValidateItemMasterText()
        {
            bool IsValid = true;

            if (!string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
                if (regex.IsMatch(txtItemName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in ItemName!");
                    txtItemName.Focus();
                    IsValid = false;
                }
            }


            else if (!string.IsNullOrWhiteSpace(txtItemCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
                if (regex.IsMatch(txtItemCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in ItemCode!");
                    txtItemCode.Focus();
                    IsValid = false;
                }
            }

            else if (!string.IsNullOrWhiteSpace(txtMake.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
                if (regex.IsMatch(txtMake.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Make!");
                    txtMake.Focus();
                    IsValid = false;
                }
            }

            else if (!string.IsNullOrWhiteSpace(txtModel.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
                if (regex.IsMatch(txtModel.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Model!");
                    txtModel.Focus();
                    IsValid = false;
                }
            }

            return IsValid;
        }

        private void btnItemUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection econ = ExcelConn(GetFilePath());
                string Query = string.Format("Select [ITEMCODE],[ITEMNAME],[MAKE],[MODEL],[MINIMUMSTOCK],[UNIT],[UNITCODE],[SUBCATEGORY],[SUBCATEGORYCODE],[CATEGORY],[CATEGORYCODE] FROM [{0}]", "Sheet1$");
                OleDbDataAdapter da = new OleDbDataAdapter(Query, econ);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Sheet Contains No Data!");
                    return;
                }
                    int count = 0;
                //dt = new DataTable();
                //dt = ds.Tables[0];`
                foreach (DataRow dr in dt.Rows)
                {
                    itemMaster.ItemName = dr["ITEMNAME"].ToString();
                    itemMaster.ItemCode = dr["ITEMCODE"].ToString();

                    if (string.IsNullOrWhiteSpace(itemMaster.ItemName) && string.IsNullOrWhiteSpace(itemMaster.ItemCode))
                    {
                        XtraMessageBox.Show("Please check ItemName or ItemCode on Sheet");
                        return;
                    }
                    itemMaster.Unit = dr["UNIT"].ToString();
                    itemMaster.UnitCode = dr["UNITCODE"].ToString();
                    if (string.IsNullOrWhiteSpace(itemMaster.Unit) && string.IsNullOrWhiteSpace(itemMaster.UnitCode))
                    {
                        XtraMessageBox.Show(string.Format("Please check Unit or UnitCode for Item [{0}]", itemMaster.ItemName));
                        return;
                    }
                    itemMaster.SaveUnit(itemMaster);

                    itemMaster.Category = dr["SUBCATEGORY"].ToString();
                    itemMaster.CategoryCode = dr["SUBCATEGORYCODE"].ToString();
                    ////if (string.IsNullOrWhiteSpace(itemMaster.Category) && string.IsNullOrWhiteSpace(itemMaster.CategoryCode))
                    ////{
                    ////    XtraMessageBox.Show(string.Format("Please check Category or CategoryCode for Item [{0}]", itemMaster.ItemName));
                    ////    return;
                    ////}
                    ////itemMaster.SaveCategory(itemMaster);

                    ////itemMaster.SubCategory = dr["SUBCATEGORY"].ToString();
                    ////itemMaster.SubCategoryCode = dr["SUBCATEGORYCODE"].ToString();
                    ////if (string.IsNullOrWhiteSpace(itemMaster.SubCategory) && string.IsNullOrWhiteSpace(itemMaster.SubCategoryCode))
                    ////{
                    ////    XtraMessageBox.Show(string.Format("Please check SubCategory or SubCategoryCode for Item [{0}]", itemMaster.ItemName));
                    ////    return;
                    ////}
                    ////itemMaster.SaveSubCategory(itemMaster);
                    itemMaster.ThresholdLimit = double.Parse(dr["MINIMUMSTOCK"].ToString());
                    itemMaster.Make = dr["MAKE"].ToString();
                    itemMaster.Model = dr["MODEL"].ToString();
                    itemMaster.CreatedDate = DateTime.Today;
                    itemMaster.SetItemMasterData(itemMaster);
                    count++;
                }
                XtraMessageBox.Show(string.Format("{0} Items Uploaded Successfully", count));
                ViewItemMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCategoryUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection econ = ExcelConn(GetFilePath());
                string Query = string.Format("Select [ITEMCODE],[ITEMNAME],[MAKE],[MODEL],[MINIMUMSTOCK],[UNIT],[UNITCODE],[SUBCATEGORY],[SUBCATEGORYCODE],[CATEGORY],[CATEGORYCODE] FROM [{0}]", "Sheet1$");
                OleDbDataAdapter da = new OleDbDataAdapter(Query, econ);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Sheet Contains No Data!");
                    return;
                }
                int count = 0;
                //dt = new DataTable();
                //dt = ds.Tables[0];`
                foreach (DataRow dr in dt.Rows)
                {
                    ////itemMaster.ItemName = dr["ITEMNAME"].ToString();
                    ////itemMaster.ItemCode = dr["ITEMCODE"].ToString();

                    ////if (string.IsNullOrWhiteSpace(itemMaster.ItemName) && string.IsNullOrWhiteSpace(itemMaster.ItemCode))
                    ////{
                    ////    XtraMessageBox.Show("Please check ItemName or ItemCode on Sheet");
                    ////    return;
                    ////}
                    ////itemMaster.Unit = dr["UNIT"].ToString();
                    ////itemMaster.UnitCode = dr["UNITCODE"].ToString();
                    ////if (string.IsNullOrWhiteSpace(itemMaster.Unit) && string.IsNullOrWhiteSpace(itemMaster.UnitCode))
                    ////{
                    ////    XtraMessageBox.Show(string.Format("Please check Unit or UnitCode for Item [{0}]", itemMaster.ItemName));
                    ////    return;
                    ////}
                    ////itemMaster.SaveUnit(itemMaster);

                    itemMaster.Category = dr["CATEGORY"].ToString();
                    itemMaster.CategoryCode = dr["CATEGORYCODE"].ToString();
                    ////if (string.IsNullOrWhiteSpace(itemMaster.Category) && string.IsNullOrWhiteSpace(itemMaster.CategoryCode))
                    ////{
                    ////    XtraMessageBox.Show(string.Format("Please check Category or CategoryCode for Item [{0}]", itemMaster.ItemName));
                    ////    return;
                    ////}
                    ////itemMaster.SaveCategory(itemMaster);

                    itemMaster.SubCategory = dr["SUBCATEGORY"].ToString();
                    itemMaster.SubCategoryCode = dr["SUBCATEGORYCODE"].ToString();
                    if (string.IsNullOrWhiteSpace(itemMaster.SubCategory) && string.IsNullOrWhiteSpace(itemMaster.SubCategoryCode))
                    {
                        XtraMessageBox.Show(string.Format("Please check SubCategory or SubCategoryCode for Item [{0}]", itemMaster.ItemName));
                        return;
                    }
                    itemMaster.SaveSubCategory(itemMaster);
                    //itemMaster.ThresholdLimit = double.Parse(dr["MINIMUMSTOCK"].ToString());
                    //itemMaster.Make = dr["MAKE"].ToString();
                    //itemMaster.Model = dr["MODEL"].ToString();
                    //itemMaster.CreatedDate = DateTime.Today;
                    //itemMaster.SetItemMasterData(itemMaster);
                    count++;
                }
                XtraMessageBox.Show(string.Format("{0} Category Uploaded Successfully", count));
                ViewItemMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static OleDbConnection ExcelConn(string FilePath)
        {
            OleDbConnection Econ = null;
            string constr = string.Format(@"provider=microsoft.jet.oledb.4.0;data source={0};extended properties=" + "\"excel 8.0;hdr=yes;\"", FilePath);
            Econ = new OleDbConnection(constr);
            return Econ;
        }
        public string GetFilePath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";// "xLsx Files (*.xlsx)|*.xlsx|*.xls";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            ofd.ShowDialog();
            return ofd.FileName;
        }
        private void dgvItemMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                ItemMaster itmMaster = new ItemMaster();
                itmMaster.ItemName = dgvItemMaster.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
                itmMaster.ItemCode = dgvItemMaster.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
                itmMaster.ThresholdLimit = double.Parse(dgvItemMaster.Rows[e.RowIndex].Cells["Threshold"].Value.ToString());
                itmMaster.Make = dgvItemMaster.Rows[e.RowIndex].Cells["Make"].Value.ToString();
                itmMaster.Model = dgvItemMaster.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                itmMaster.Unit = dgvItemMaster.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                itmMaster.UnitCode = dgvItemMaster.Rows[e.RowIndex].Cells["UnitCode"].Value.ToString();
                itmMaster.Category = dgvItemMaster.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                itmMaster.CategoryCode = dgvItemMaster.Rows[e.RowIndex].Cells["CategoryCode"].Value.ToString();
                itmMaster.SubCategory = dgvItemMaster.Rows[e.RowIndex].Cells["SubCategory"].Value.ToString();
                itmMaster.SubCategoryCode = dgvItemMaster.Rows[e.RowIndex].Cells["SubCategoryCode"].Value.ToString();
                MapItemMasterToView(itmMaster);
                btnItemDelete.Visible = true;
                btnAdd.Text = "Update";

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MapItemMasterToView(ItemMaster itmMaster)
        {
            try
            {
                txtItemCode.Text = itmMaster.ItemCode;
                txtItemName.Text = itmMaster.ItemName;
                cmbUnit.Text = itmMaster.Unit;
                cmbSubCategory.Text = itmMaster.SubCategory;
                txtParentCategory.Text = itmMaster.Category;
                txtMake.Text = itmMaster.Make;
                txtModel.Text = itmMaster.Model;
                dpnThreslimit.Value = Convert.ToDecimal(itmMaster.ThresholdLimit);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshItemMasterView()
        {
            try
            {
                txtItemCode.Text = string.Empty;
                txtItemName.Text = string.Empty;
                cmbUnit.Text = string.Empty;
                cmbSubCategory.Text = string.Empty;
                txtParentCategory.Text = string.Empty;
                txtMake.Text = string.Empty;
                txtModel.Text = string.Empty;
                dpnThreslimit.Value = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(itemMaster.CheckItemOnTranData(txtItemCode.Text).Rows[0]["IsExist"].ToString()) > 0)
            {
                XtraMessageBox.Show("Item Cannot be delete. Used in transaction", "Alert", MessageBoxButtons.OK);
                return;
            }


            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                try
                {
                    itemMaster.DeleteItemMasterToData(txtItemCode.Text);
                    XtraMessageBox.Show("Item Deleted Successfully.");
                    btnItemDelete.Visible = false;
                    ViewItemMaster();
                    RefreshItemMasterView();
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            RefreshItemMasterView();
            btnItemDelete.Visible = false;
        }

        private void btnItemAddUnit_Click(object sender, EventArgs e)
        {
            CheckUnitData();
            LoadUnits();
        }

        private void btnItemAddSubCat_Click(object sender, EventArgs e)
        {
            CheckCategoryData();
            txtParentCategory.Text = GetParentCategory(cmbSubCategory.Text);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void ResetAllControls()
        {
            txtItemName.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtMake.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtParentCategory.Text = string.Empty;
            cmbUnit.Text = string.Empty;
            cmbSubCategory.Text = string.Empty;
            dpnThreslimit.Value = 0;
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(txtItemName.Text))
            {
               
                XtraMessageBox.Show("Invalid Name");
                txtItemName.Focus();
            }
        }

        private void btnOpeningUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection econ = ExcelConn(GetFilePath());
                string Query = string.Format("Select [DOCUMENTNO],[BILLNO],[VENDOR],[ITEMCODE],[ITEMNAME],[UNIT],[OPENINGQTY],[UNITCOST] FROM [{0}]", "Sheet1$");
                OleDbDataAdapter da = new OleDbDataAdapter(Query, econ);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Sheet Contains No Data!");
                    return;
                }
                int count = 0;
                //dt = new DataTable();
                //dt = ds.Tables[0];`
                ItemOpeningDetail itemOpening = new ItemOpeningDetail();
                foreach (DataRow dr in dt.Rows)
                {
                    itemOpening.DocumentNo = dr["DOCUMENTNO"].ToString();
                    itemOpening.DocumentDate = DateTime.Today;// DateTime.Parse( dr["DOCUMENTDATE"].ToString());
                    itemOpening.BillNo = dr["BILLNO"].ToString();
                    itemOpening.Vendor = dr["VENDOR"].ToString();
                    itemOpening.ItemName = dr["ITEMNAME"].ToString();
                    itemOpening.ItemCode = dr["ITEMCODE"].ToString();
                    itemOpening.UnitCode = dr["UNIT"].ToString();
                    itemOpening.BatchNo = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    itemOpening.OpeningQty =double.Parse( dr["OPENINGQTY"].ToString());
                    itemOpening.UnitCost =double.Parse(dr["UNITCOST"].ToString());
                    itemOpening.TotalCost =Math.Round(itemOpening.OpeningQty * itemOpening.UnitCost,2);
                    itemOpening.SetProcureItemDetailValue(itemOpening);
                    count++;
                }
                XtraMessageBox.Show(string.Format("{0} Item-Opening Uploaded Successfully", count));
                count++;
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
                        if (cell.Value == null) continue;

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

        private void btnExportItem_Click(object sender, EventArgs e)
        {
            ExportExcelReport(dgvItemMaster, this.Name);
        }
    }
}
