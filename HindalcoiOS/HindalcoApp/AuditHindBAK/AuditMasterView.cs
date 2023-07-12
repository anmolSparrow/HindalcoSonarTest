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

    public partial class AuditMasterView : XtraForm
    {
        //public event SomeEvents GetValue;
        //public VendorMaster vendorMaster { get; set; }
        public AuditMasterView()
        {
            //vendorMaster = new VendorMaster();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateAuditMaster() == false) return;
            if (btnSave.Text == "Add")
            {
               AuditMaster auditMaster = new AuditMaster();
               auditMaster.CheckPoint =txtCheckPoint.Text;
               auditMaster.Description=txtRemarks.Text;
               auditMaster.Category = cmbCategory.Text;
               auditMaster.CreatedDate = DateTime.Today;
                //put statement to insert---
            }
            else if (btnSave.Text == "Update")
            {
                //
            }
            AuditMasterDataView();
        }
        

        private void AuditMasterView_Load(object sender, EventArgs e)
        {
            GlobalDeclaration.HideTabCtrlPagesHeader(AuditMasterPages);
            AuditMasterDataView();
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

        private void btnView_Click(object sender, EventArgs e)
        {
            SetDefaultView();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            AuditMasterPages.SelectedIndex = 1;
        }

        private void dgvViewAuditMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtCheckPoint.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["CheckPoint"].Value.ToString();
                txtRemarks.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                cmbCategory.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["AuditCategory"].Value.ToString();
                btnSave.Text = "Update";
                //ViewVendorMaster();
                AuditMasterPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVendorCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Add";
            txtCheckPoint.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            cmbCategory.Text = string.Empty;
        }

        private Boolean ValidateAuditMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtCheckPoint.Text))
            {
                XtraMessageBox.Show("Please fill [Check Points] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtCheckPoint.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCheckPoint.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Check Points] !");
                    txtCheckPoint.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                XtraMessageBox.Show("!Please fill Description");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtRemarks.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Description!");
                    txtRemarks.Focus();
                    IsValid = false;
                }
            }

            if (String.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                XtraMessageBox.Show("!Please Select Category");
                IsValid = false;
            }
            
            return IsValid;
        }
        public void AuditMasterDataView()
        {

        }
        public void LoadAuditCategory()
        {
            DataTable catelist = new DataTable();
            foreach (DataRow dr in catelist.Rows)
            {
                cmbCategory.Items.Add(dr["CateName"].ToString());
            }
        }

        private void SetDefaultView()
        {
            AuditMasterDataView();
            AuditMasterPages.SelectedIndex = 0;
        }
    }
    public class AuditMaster
    {
        public string CheckPoint { set; get; }
        public string Category { set; get; }
        public string CategoryId { set; get; }
        public string Description { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
