using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
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

namespace Hind.AuditMgmt
{

    public partial class UserCategoryView : XtraForm
    {
        //public event SomeEvents GetValue;
        //public VendorMaster vendorMaster { get; set; }
        public UserCategoryView()
        {
            //vendorMaster = new VendorMaster();
            InitializeComponent();
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            //if (ValidateVendorMaster() == false) return;
            //MapVendorMasterToData();
            //ViewVendorMaster();
            //this.GetValue.Invoke(this.txtVendorName.Text);
            if (btnAddCate.Text == "Add")
            {
                UserCategory userCat = new UserCategory();
                userCat.CateName = txtCateName.Text;
                userCat.CateCode = txtCateCode.Text;
                userCat.CreatedDate = DateTime.Today;
                //put statement to insert---
            }
            else if (btnAddCate.Text == "Update")
            {
                //
            }
            ViewUserCategory();
        }
        

        private void AuditCateMasterView_Load(object sender, EventArgs e)
        {
            //btnAddCate.Text = "Add";
            //ViewVendorMaster();
        }

        //private void txtVendorEmail_Leave(object sender, EventArgs e)
        //{
        //    //System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

        //    //if (!expr.IsMatch(txtVendorEmail.Text))
        //    //{
        //    //    MessageBox.Show("invalid Email Format");
        //    //    txtVendorEmail.Focus();
        //    //}


        //}

        //private void txtVendorContact_Leave(object sender, EventArgs e)
        //{
        //    System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[0-9]{10}$");

        //    //if (!expr.IsMatch(txtVendorContact.Text))
        //    //{
        //    //    MessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No");
        //    //    //txtVendorContact.Focus();
        //    //}
        //}

        private void dgvViewUserCateMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtCateName.Text = dgvViewUserCatMaster.Rows[e.RowIndex].Cells["CateName"].Value.ToString();
                txtCateCode.Text = dgvViewUserCatMaster.Rows[e.RowIndex].Cells["CateCode"].Value.ToString();
                btnAddCate.Text = "Update";
                //ViewVendorMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCateCancel_Click(object sender, EventArgs e)
        {
            btnAddCate.Text = "Add";
            txtCateName.Text = string.Empty;
            txtCateCode.Text = string.Empty;
        }

        private Boolean ValidateVendorMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtCateName.Text))
            {
                XtraMessageBox.Show("Please fill [Category Name] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtCateName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCateName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Category Name] !");
                    txtCateName.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtCateCode.Text))
            {
                XtraMessageBox.Show("!Please fill [Category Code]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtCateCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCateCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Category Code]!");
                    txtCateCode.Focus();
                    IsValid = false;
                }
            }
           
            return IsValid;
        }
        public void ViewUserCategory()
        {

        }
    }
    public class UserCategory
    {
        public string CateName { set; get; }
        public string CateCode { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
