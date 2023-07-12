using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hind.AuditMgmt
{

    public partial class AuditCategoryView : XtraForm
    {
        //public event SomeEvents GetValue;
        //public VendorMaster vendorMaster { get; set; }
        public AuditCategoryView()
        {
            //vendorMaster = new VendorMaster();
            InitializeComponent();
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            if (ValidateCategoryMaster() == false) return;
            if (btnAddCate.Text == "Add")
            {
                AuditCategory auditCat = new AuditCategory();
                auditCat.AuditCategoryName = txtCateName.Text;
                auditCat.AuditCategoryCode = txtCateCode.Text;
                //auditCat.DepartmentCode = cmbDept.Text;
                auditCat.DepartmentCode= cmbDept.Text;
                auditCat.CreatedDate = DateTime.Today;
                //put statement to insert---
            }
            else if (btnAddCate.Text == "Update")
            {
                //
            }
            AuditCateView();
        }
        

        private void AuditCateMasterView_Load(object sender, EventArgs e)
        {
            //btnAddCate.Text = "Add";
            LoadDepartments();
            AuditCateView();
        }

        private void txtVendorEmail_Leave(object sender, EventArgs e)
        {
            //System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            //if (!expr.IsMatch(txtVendorEmail.Text))
            //{
            //    MessageBox.Show("invalid Email Format");
            //    txtVendorEmail.Focus();
            //}


        }

        private void txtVendorContact_Leave(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[0-9]{10}$");

            //if (!expr.IsMatch(txtVendorContact.Text))
            //{
            //    MessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No");
            //    //txtVendorContact.Focus();
            //}
        }

        private void dgvViewCateMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtCateName.Text = dgvViewCateMaster.Rows[e.RowIndex].Cells["CateName"].Value.ToString();
                txtCateCode.Text = dgvViewCateMaster.Rows[e.RowIndex].Cells["CateCode"].Value.ToString();
                cmbDept.Text = dgvViewCateMaster.Rows[e.RowIndex].Cells["Dept"].Value.ToString();
                btnAddCate.Text = "Update";
                AuditCateView();
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

        private Boolean ValidateCategoryMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtCateName.Text))
            {
                XtraMessageBox.Show("Please fill Category Name !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtCateName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCateName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [CategoryName] !");
                    txtCateName.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtCateCode.Text))
            {
                XtraMessageBox.Show("Please fill [CategoryCode].");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtCateCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCateCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [CategoryCode] !");
                    txtCateCode.Focus();
                    IsValid = false;
                }
            }
            
            return IsValid;
        }
        public void AuditCateView()
        {

        }
        public void LoadDepartments()
        {
            DataTable deptlist = new DataTable();
            foreach (DataRow dr in deptlist.Rows)
            {
                cmbDept.Items.Add(dr["DeptName"].ToString());
            }
        }
    }

    public class AuditCategory
    {
        public string AuditCategoryName { get; set; }
        public string AuditCategoryCode { get; set; }
        public string DepartmentCode { get; set; }
        public Guid AuditCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    //public class AuditCategory
    //{
    //    public string CateName { set; get; }
    //    public string CateCode { set; get; }
    //    //public string Dept { set; get; }
    //    public string DeptCode { set; get; }
    //    public DateTime CreatedDate { set; get; }
    //}
}
