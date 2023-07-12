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
    public partial class UOMView : XtraForm
    {

        public EventHandler<string> GetValue;
        public UOM UOM { set; get; }
        public UOMView()
        {
            UOM = new UOM();
            InitializeComponent();
            btnAdd.Text = "Add";
        }
        private void MapUnitMasterToData()
        {
            try
            {
                UOM.UnitCode = txtUnitCode.Text;
                UOM.UnitName = txtUnitName.Text;
                UOM.CreatedDate = DateTime.Now;
                DataTable dt = UOM.GetAllUOM();
                if (dt.AsEnumerable().Where(X => X.Field<string>("UnitName") == UOM.UnitName).ToList().Count > 0)
                    XtraMessageBox.Show("Unit Already Exist!");
                else if (dt.AsEnumerable().Where(X => X.Field<string>("UnitCode") == UOM.UnitCode).ToList().Count > 0)
                    XtraMessageBox.Show("UnitCode Already Exist!");
                else
                {
                    UOM.SetUnitData(UOM);
                    ViewUOMData();
                    XtraMessageBox.Show("Record Saved Succesfully");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateUnitDetail() == false) return;
            MapUnitMasterToData();
            if (GetValue != null)
                GetValue.Invoke(sender, txtUnitName.Text);
        }
        private void ViewUOMData()
        {
            dgvUnitsView.DataSource = UOM.GetAllUOM();
        }

        private void UOMView_Load(object sender, EventArgs e)
        {
            ViewUOMData();
        }

       
        private Boolean ValidateUnitDetail()
        {
            bool IsValid = true;
            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                XtraMessageBox.Show("Please Fill Unit Name!");
                IsValid = false;
                return IsValid;
            }
           else  if (string.IsNullOrWhiteSpace(txtUnitCode.Text))
            {
                XtraMessageBox.Show("Please Fill Unit Code!");
                IsValid = false;
                return IsValid;
            }
           else if (!string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
                if (regex.IsMatch(txtUnitName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in UnitName!");
                    IsValid = false;
                    return IsValid;
                }
            }
            return IsValid;
        }

        private void dgvUnitsView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //btnProcureDelete.Visible = true;
            txtUnitName.Text = dgvUnitsView.Rows[e.RowIndex].Cells["UnitName"].Value.ToString();
            txtUnitCode.Text = dgvUnitsView.Rows[e.RowIndex].Cells["UnitCode"].Value.ToString();
            btnAdd.Text = "Update";
            btnUOMDelete.Visible = true;
        }

        private void btnUnitCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            txtUnitCode.Text = string.Empty;
            txtUnitName.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(UOM..CheckItemOnTranData(txtItemCode.Text).Rows[0]["IsExist"].ToString()) > 0)
            //{
            //    XtraMessageBox.Show("Item Cannot be delete. Used in transaction", "Alert", MessageBoxButtons.OK);
            //    return;
            //}


            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                try
                {
                    UOM.DeleteUOMMasterToData(txtUnitCode.Text);
                    XtraMessageBox.Show("Unit Deleted Successfully.");
                    btnUOMDelete.Visible = false;
                    ViewUOMData();
                    
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
