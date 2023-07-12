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

namespace HindalcoiOS.AuditMgmt
{

    public partial class AuditAreaView : XtraForm
    {
        //public event SomeEvents GetValue;
        //public VendorMaster vendorMaster { get; set; }
        public AuditAreaView()
        {
            //vendorMaster = new VendorMaster();
            InitializeComponent();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            //if (ValidateVendorMaster() == false) return;
            //MapVendorMasterToData();
            //ViewVendorMaster();
            //this.GetValue.Invoke(this.txtVendorName.Text);
        }
        

        private void VendorMasterView_Load(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            //ViewVendorMaster();
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

        private void dgvViewDeptMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtVendorName.Text = dgvViewAreaMaster.Rows[e.RowIndex].Cells["VendorName"].Value.ToString();
                txtAreaCode.Text = dgvViewAreaMaster.Rows[e.RowIndex].Cells["VendorCode"].Value.ToString();
                //txtVendorContact.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                //txtVendorEmail.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
                //txtVendorContPerson.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["ContactPerson"].Value.ToString();
                //txtVendorAddress.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                //btnAddVendor.Text = "Update";
                //ViewVendorMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVendorCancel_Click(object sender, EventArgs e)
        {
           
        }

        private Boolean ValidateVendorMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtVendorName.Text))
            {
                XtraMessageBox.Show("Please fill Vendor Name !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtVendorName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtVendorName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Vendor Name !");
                    txtVendorName.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtAreaCode.Text))
            {
                XtraMessageBox.Show("!Please fill VendorCode");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtAreaCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtAreaCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in VendorCode!");
                    txtAreaCode.Focus();
                    IsValid = false;
                }
            }
            //if (String.IsNullOrWhiteSpace(txtVendorContact.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Contact");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorContact.Text))
            //{
            //    var regex = new Regex(@"^[0-9]{10}$");
            //    if (regex.IsMatch(txtVendorContact.ToString()))
            //    {
            //        XtraMessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No!");
            //        txtVendorContact.Focus();
            //        IsValid = false;
            //    }
            //}
            //else if (String.IsNullOrWhiteSpace(txtVendorContPerson.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Contact-Person");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorContPerson.Text))
            //{
            //    var regex = new Regex(@"[^a-zA-Z0-9\s]-");
            //    if (regex.IsMatch(txtVendorContPerson.ToString()))
            //    {
            //        XtraMessageBox.Show("Invalid character in Contact-Person!");
            //        txtVendorContPerson.Focus();
            //        IsValid = false;
            //    }
            //}
            //else if (String.IsNullOrWhiteSpace(txtVendorEmail.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Email");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorEmail.Text))
            //{
            //    var regex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            //    if (regex.IsMatch(txtVendorEmail.Text))
            //    {
            //        XtraMessageBox.Show("Invalid Email Format!");
            //        txtVendorEmail.Focus();
            //        IsValid = false;
            //    }
            //}
            //else if (String.IsNullOrWhiteSpace(txtVendorAddress.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Address");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorAddress.Text))
            //{
            //    var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
            //    if (regex.IsMatch(txtVendorAddress.ToString()))
            //    {
            //        XtraMessageBox.Show("Invalid character in Address!");
            //        txtVendorAddress.Focus();
            //        IsValid = false;
            //    }
            //}
            return IsValid;
        }

        
    }
    public class AuditArea
    {
        //[Required]
        public string DepartmentCode { get; set; }
        //[Required]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditAreaId { get; set; }
        //[Required]
        public string AreaName { get; set; }
        //[Required]
        public string AreaCode { get; set; }

    }
}
