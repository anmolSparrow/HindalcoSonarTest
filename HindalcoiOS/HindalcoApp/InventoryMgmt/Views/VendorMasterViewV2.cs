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

    public partial class VendorMasterView : XtraForm
    {
        public event SomeEvents GetValue;
        public VendorMaster vendorMaster { get; set; }
        public VendorMasterView()
        {
            vendorMaster = new VendorMaster();
            InitializeComponent();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            if (ValidateVendorMaster() == false) return;
            MapVendorMasterToData();
            ViewVendorMaster();
            this.GetValue.Invoke(this.txtVendorName.Text);
        }
        private void MapVendorMasterToData()
        {
            try
            {
                vendorMaster.VendorName = txtVendorName.Text;
                vendorMaster.VendorCode = txtVendorCode.Text;
                vendorMaster.ContactPerson = txtVendorContPerson.Text;
                vendorMaster.Address = txtVendorAddress.Text;
                vendorMaster.Contact = txtVendorContact.Text;
                vendorMaster.EmailId = txtVendorEmail.Text;
                vendorMaster.CreatedDate = DateTime.Now;
                vendorMaster.SetVendorData(vendorMaster);
                XtraMessageBox.Show("Vendor Added Successfully");
            }
            catch (Exception ex)
            {

            }
            //ViewItemMaster();
        }
        private void ViewVendorMaster()
        {
            try
            {
                DataTable vendorDt = vendorMaster.LoadVendorMaster();
                if (vendorDt.Rows.Count > 0)
                {
                    for (int i = 0; i < vendorDt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvViewVendorMaster.Rows.Add(dr);
                        int rowidex = this.dgvViewVendorMaster.Rows.Count - 1;
                        dgvViewVendorMaster.Rows[rowidex].Cells["VendorName"].Value = vendorDt.Rows[i]["VendorName"].ToString();
                        dgvViewVendorMaster.Rows[rowidex].Cells["VendorCode"].Value = vendorDt.Rows[i]["VendorCode"].ToString();
                        dgvViewVendorMaster.Rows[rowidex].Cells["Contact"].Value = vendorDt.Rows[i]["vContact"].ToString();
                        dgvViewVendorMaster.Rows[rowidex].Cells["ContactPerson"].Value = vendorDt.Rows[i]["vContactPeson"].ToString();
                        dgvViewVendorMaster.Rows[rowidex].Cells["EmailId"].Value = vendorDt.Rows[i]["vEmailId"].ToString();
                        dgvViewVendorMaster.Rows[rowidex].Cells["CreatedDate"].Value = vendorDt.Rows[i]["CreatedDate"].ToString();
                        dgvViewVendorMaster.Rows[rowidex].Cells["Address"].Value = vendorDt.Rows[i]["vAddress"].ToString();
                    }
                    dgvViewVendorMaster.ReadOnly = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void VendorMasterView_Load(object sender, EventArgs e)
        {
            btnAddVendor.Text = "Add";
            ViewVendorMaster();
        }

        private void txtVendorEmail_Leave(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (!expr.IsMatch(txtVendorEmail.Text))
            {
                MessageBox.Show("invalid Email Format");
                txtVendorEmail.Focus();
            }


        }

        private void txtVendorContact_Leave(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[0-9]{10}$");

            if (!expr.IsMatch(txtVendorContact.Text))
            {
                MessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No");
                txtVendorContact.Focus();
            }
        }

        private void dgvViewVendorMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtVendorName.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["VendorName"].Value.ToString();
                txtVendorCode.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["VendorCode"].Value.ToString();
                txtVendorContact.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                txtVendorEmail.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
                txtVendorContPerson.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["ContactPerson"].Value.ToString();
                txtVendorAddress.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                btnAddVendor.Text = "Update";
                ViewVendorMaster();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVendorCancel_Click(object sender, EventArgs e)
        {
            btnAddVendor.Text = "Add";
            txtVendorName.Text = string.Empty;// Clear();
            txtVendorCode.Text = string.Empty; //Clear();
            txtVendorContact.Text = string.Empty; //Clear();
            txtVendorEmail.Text = string.Empty; //Clear();
            txtVendorContPerson.Text = string.Empty; //Clear();
            txtVendorAddress.Text = string.Empty; //Clear();
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
            else if (String.IsNullOrWhiteSpace(txtVendorCode.Text))
            {
                XtraMessageBox.Show("!Please fill VendorCode");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtVendorCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtVendorCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in VendorCode!");
                    txtVendorCode.Focus();
                    IsValid = false;
                }
            }
            if (String.IsNullOrWhiteSpace(txtVendorContact.Text))
            {
                XtraMessageBox.Show("!Please fill Contact");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtVendorContact.Text))
            {
                var regex = new Regex(@"^[0-9]{10}$");
                if (regex.IsMatch(txtVendorContact.ToString()))
                {
                    XtraMessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No!");
                    txtVendorContact.Focus();
                    IsValid = false;
                }
            }
            else if (String.IsNullOrWhiteSpace(txtVendorContPerson.Text))
            {
                XtraMessageBox.Show("!Please fill Contact-Person");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtVendorContPerson.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtVendorContPerson.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Contact-Person!");
                    txtVendorContPerson.Focus();
                    IsValid = false;
                }
            }
            else if (String.IsNullOrWhiteSpace(txtVendorEmail.Text))
            {
                XtraMessageBox.Show("!Please fill Email");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtVendorEmail.Text))
            {
                var regex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (regex.IsMatch(txtVendorEmail.Text))
                {
                    XtraMessageBox.Show("Invalid Email Format!");
                    txtVendorEmail.Focus();
                    IsValid = false;
                }
            }
            else if (String.IsNullOrWhiteSpace(txtVendorAddress.Text))
            {
                XtraMessageBox.Show("!Please fill Address");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtVendorAddress.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
                if (regex.IsMatch(txtVendorAddress.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Address!");
                    txtVendorAddress.Focus();
                    IsValid = false;
                }
            }
            return IsValid;
        }

        
    }
}
