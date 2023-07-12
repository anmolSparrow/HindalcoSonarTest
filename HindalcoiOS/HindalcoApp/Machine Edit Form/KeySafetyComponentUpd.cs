using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
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

namespace RMPCLApp.Machine_Edit_Form
{
    public partial class KeySafetyComponent : XtraForm
    {
        public EventHandler<string> updatekeySafetyHandler;
        private string _MachineName;
        public KeySafetyComponent(string MachineName)
        {
            this._MachineName = MachineName;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KeySafetyComponent_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            LoadData();

        }


        public void LoadData()
        {
            // DataTable dt = Resources.Instance.GetDataKey("Sp_FetchSafetyMasterCompList");
            DataTable dt = GlobalDeclaration.KeyComponentDT;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow[] filteredRows = dt.Select(string.Format("{0} LIKE '%{1}%'", "Column1", this._MachineName));
                        cmbsearch.Items.Add(dt.Rows[i]["keysafetyitem"].ToString().Trim());
                    }
                    //cmbsearch.DataSource = dt;
                    cmbsearch.DisplayMember = "keysafetyitem";
                }
                //cmbsearch.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadData(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmbsearch.Items.Add(dt.Rows[i]["KeySafetyItem"].ToString().Trim());
                    }
                    //cmbsearch.DataSource = dt;
                    cmbsearch.DisplayMember = "KeySafetyItem";
                }
                //cmbsearch.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
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

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                string Recultstring = string.Empty;
                if (cmbsearch.SelectedItem != null)
                {
                    this.txtAddKeySafety.Text = cmbsearch.SelectedItem.ToString();
                }
                else
                {

                    if (txtAddKeySafety.Text == "")
                    {
                        XtraMessageBox.Show("Please Enter Key First?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAddKeySafety.Focus();
                        return;
                    }
                    if (!cmbsearch.Items.Contains(this.txtAddKeySafety.Text.Trim()))
                    {

                        cmbsearch.Items.Add(txtAddKeySafety.Text);
                    }
                    Resources.Instance.InsertMasterKeycom("Sp_InsertKeySafetyComListMST", this.txtAddKeySafety.Text, "@keycmplist", "@returnvalue", out Recultstring);
                    XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Recultstring == "Same Key Already Exists DB") return;

                }
                // cmbsearch.SelectedIndex = 0;
                if (updatekeySafetyHandler != null)
                    updatekeySafetyHandler.Invoke(sender, txtAddKeySafety.Text);
                txtAddKeySafety.Text = "";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAddKeySafety_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

       
    }
}