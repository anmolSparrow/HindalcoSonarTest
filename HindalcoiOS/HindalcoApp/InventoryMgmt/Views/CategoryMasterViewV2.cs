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
    public partial class CategoryMasterView : XtraForm
    {
        public EventHandler<string> GetValue;
        private CategoryMaster catMaster { get; set; }
        public CategoryMasterView()
        {
            catMaster = new CategoryMaster();
            InitializeComponent();
        }
        private void MapCatMasterToData()
        {
            try
            {
                string msg = "Sub-Category Added Successfully";
                catMaster.CategoryName = txtCatName.Text;
                catMaster.CategoryCode = txtCatCode.Text;
                if (cmbCatParent.SelectedItem != null && cmbCatParent.SelectedItem.ToString() != "Primary")
                {
                    catMaster.Parent = cmbCatParent.SelectedItem.ToString();
                    catMaster.ParentCode = catMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == cmbCatParent.SelectedItem.ToString()).ToList().FirstOrDefault()["CategoryCode"].ToString();
                }
                if (!string.IsNullOrEmpty(cmbCatParent.Text) && cmbCatParent.Text != "Primary")
                {
                    catMaster.Parent = cmbCatParent.Text;
                    catMaster.ParentCode = catMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == cmbCatParent.Text).ToList().FirstOrDefault()["CategoryCode"].ToString();

                }

                else
                {
                    catMaster.Parent = "Primary";
                    catMaster.ParentCode = "Primary";
                    msg = "Category Added Successfully";
                }

                catMaster.CreatedDate = DateTime.Now;
                catMaster.SetCategoryMasterData(catMaster);
                XtraMessageBox.Show(msg);
                ViewSubCatMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //ViewItemMaster();
        }
        private void CategoryMasterView_Load(object sender, EventArgs e)
        {
            LoadCatParent();
            ViewSubCatMaster();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateCategoryMasterSpace() == false) return;
            if (ValidateCategoryMasterText() == false) return;
            MapCatMasterToData();
            if (GetValue != null)
                GetValue.Invoke(sender, txtCatName.Text);
        }
        private void LoadCatParent()
        {
            for (int i = 0; i < catMaster.GetAllCategory().Rows.Count; i++)
            {
                cmbCatParent.Items.Add(catMaster.GetAllCategory().Rows[i]["CategoryName"]);
            }
        }


        private void ViewCatMaster()
        {
            dgvCatMaster.DataSource = catMaster.GetAllCategory();
            dgvCatMaster.Columns["ParentCode"].Visible = false;
            dgvCatMaster.Columns["Parent"].HeaderText = "Parent";
            dgvCatMaster.Columns["CategoryName"].HeaderText = "Category";
            dgvCatMaster.Columns["CategoryCode"].HeaderText = "CategoryCode";
            //dgvItemMaster.Columns["UnitCode"].Visible = false;
        }
        private void ViewSubCatMaster()
        {
            if (IsParent == true)
            {
                dgvCatMaster.DataSource = catMaster.GetAllCategory();
                dgvCatMaster.Columns["ParentCode"].Visible = false;
                dgvCatMaster.Columns["Parent"].HeaderText = "Parent";
                dgvCatMaster.Columns["CategoryName"].HeaderText = "Category";
                dgvCatMaster.Columns["CategoryCode"].HeaderText = "CategoryCode";

            }
            else
            {
                dgvCatMaster.DataSource = catMaster.GetAllCategory();
                dgvCatMaster.Columns["ParentCode"].Visible = false;
                dgvCatMaster.Columns["Parent"].HeaderText = "Category";
                dgvCatMaster.Columns["CategoryName"].HeaderText = "SubCategory";
                dgvCatMaster.Columns["CategoryCode"].HeaderText = "SubCategoryCode";
            }
            //dgvItemMaster.Columns["UnitCode"].Visible = false;
        }

        private void AddNewCatParentData()
        {
            try
            {
                //string name = cmbCatParent.SelectedItem.ToString();
                //if (name == "Add New Parent")

                CategoryMasterView catView = new CategoryMasterView();
                catView.Text = "Category";
                catView.lblCatgCode.Text = "Category Code";
                catView.lblCatgName.Text = "Category Name";
                catView.lblCatParent.Visible = false;
                catView.cmbCatParent.Visible = false;
                catView.btnCatParent.Visible = false;
                catView.GetValue += CatHandlerEvent;
                catView.cmbCatParent.Text = "Primary";
                catView.IsParent = true;
                //ViewSubCatMaster();
                if (catView.ShowDialog() == DialogResult.OK)
                {
                    catView.Close();
                    catView.Dispose();
                }
                catView.Text = "SubCategory";
                catView.lblCatgCode.Text = "Sub-Category Code";
                catView.lblCatgName.Text = "Sub-Category Name";
                catView.cmbCatParent.Visible = true;
                catView.btnCatParent.Visible = true;
                IsParent = false;
                ViewSubCatMaster();
                //ViewCatMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CatHandlerEvent(object sender, string value)
        {
            if (!cmbCatParent.Items.Contains(value))
            {
                cmbCatParent.Items.Add(value);
                cmbCatParent.Text = value;
                //DialogResult = DialogResult.OK;
            }
        }

        private void cmbCatParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dtt = catMaster.GetAllCategory();
           string SuperParent=catMaster.ParentCode = catMaster.GetAllCategory().AsEnumerable().Where(X => X.Field<string>("CategoryName") == cmbCatParent.Text).ToList().FirstOrDefault()["Parent"].ToString();
            if(SuperParent!="Primary")
            AddNewCatParentData();
        }
        Boolean IsParent;
        private void btnCatParent_Click(object sender, EventArgs e)
        {
            IsParent = true;
            AddNewCatParentData();
        }

        private void dgvCatMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadCatParent();
            txtCatName.Text = dgvCatMaster.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
            txtCatCode.Text = dgvCatMaster.Rows[e.RowIndex].Cells["CategoryCode"].Value.ToString();
            cmbCatParent.Text = dgvCatMaster.Rows[e.RowIndex].Cells["Parent"].Value.ToString();
            btnAdd.Text = "Update";
        }
        private Boolean ValidateCategoryMasterSpace()
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(txtCatName.Text))
            {
                if (IsParent == true)
                    XtraMessageBox.Show("Please Fill Category Name!");
                else
                    XtraMessageBox.Show("Please Fill Sub Category Name!");
                txtCatName.Focus();
                IsValid = false;
            }

            else if (string.IsNullOrEmpty(txtCatCode.Text))
            {
                if (IsParent == true)
                    XtraMessageBox.Show("Please Fill Category Code!");
                else
                    XtraMessageBox.Show("Please Fill Sub Category Code!");
                txtCatCode.Focus();
                IsValid = false;
            }

            if (string.IsNullOrEmpty(cmbCatParent.Text))
            {
                if (IsParent == false)
                {
                    XtraMessageBox.Show("Please Select Category!");
                    cmbCatParent.Focus();
                    IsValid = false;
                }
            }
            return IsValid;
        }

        private Boolean ValidateCategoryMasterText()
        {
            bool IsValid = true;
            if (!string.IsNullOrEmpty(txtCatName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCatName.ToString()))
                //if (txtCatName.Text.ToCharArray().Contains()
                {
                    XtraMessageBox.Show("Invalid character in SubCategoryName!");
                    txtCatName.Focus();
                    IsValid = false;
                }
            }


            else if (!string.IsNullOrEmpty(txtCatCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCatCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in CategoryCode!");
                    txtCatCode.Focus();
                    IsValid = false;
                }
            }

            return IsValid;
        }
    }
}
