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

namespace HindalcoiOS.U1FormCollection
{
    public partial class InventoryAddDetails : XtraForm
    {
        string MachineTagname = string.Empty;
        public InventoryAddDetails(string MachineTag)
        {
            MachineTagname = MachineTag;
            InitializeComponent();
        }

        public string ItemName
        {
            get;
            set;
        }
        public string UnitName
        {
            set;
            get;
        }
        private void InventoryAddDetails_Load(object sender, EventArgs e)
        {
            LoadUnit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbItems.SelectedItem.ToString() == "") return;
            ItemName = cmbItems.SelectedItem.ToString();
            UnitName = cmbUnits.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
        }
        private void LoadUnit()
        {
            try
            {
                // DataTable Dt = Resources.Instance.GetDataKey("Sp_FetchUnitMaster");
                DataTable InvDt = Resources.Instance.GetDataKey("getInvetoryByMachineTagNo", MachineTagname.Trim());
                if (Resources.Instance._UnitMaster.Rows.Count > 0)
                {
                    cmbUnits.DataSource = Resources.Instance._UnitMaster;
                    cmbUnits.DisplayMember = "UnitName";
                    cmbUnits.ValueMember = "UnitName";
                }
                if (InvDt.Rows.Count > 0)
                {
                    cmbItems.Items.Add(InvDt.Rows[0]["item_name"].ToString());
                    txtQty.Text = InvDt.Rows[0]["stock_in_hand"].ToString();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gbxInventory_Enter(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
