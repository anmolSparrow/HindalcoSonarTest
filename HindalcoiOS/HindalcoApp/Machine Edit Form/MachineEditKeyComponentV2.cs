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

namespace HindalcoiOS.Machine_Edit_Form
{
    public partial class MachineEditKeyComponent : XtraForm
    {
        private string _MachineName;
        private string MacName;
        public MachineEditKeyComponent(string MachineName)
        {
            InitializeComponent();
            this.MacName = MachineName;
            this._MachineName = MachineName;
            if (this._MachineName.Contains("_"))
            {
                this._MachineName = _MachineName.Split('_')[0];
            }

        }
        public EventHandler<string> updatekeyValueHandler;
        //protected override void OnTextChanged(EventArgs e)
        //{
        //    base.OnTextChanged(e);
        //}
        public void LoadData()
        {
            // DataTable dt = Resources.Instance.GetDataKey("Sp_FetchKeyMasterCompList");
            DataTable dt = GlobalDeclaration.KeyComponentDT;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<string> keyData = new List<string>();
                    string[] splArr = new string[] { };
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow[] filteredRows = dt.Select(string.Format("{0} LIKE '%{1}%'", "Column2", this._MachineName));
                        if (filteredRows.Length > 0)
                        {
                            keyData.Add(filteredRows[0]["Column3"].ToString());
                            splArr = keyData[0].Split(',');
                            cmbsearch.DataSource = splArr;
                            break;
                        }
                        // cmbsearch.Items.Add(Resources.Instance.KeyDt.Rows[i]["KeyName"].ToString().Trim());
                    }
                    //cmbsearch.DataSource = dt;
                    cmbsearch.DisplayMember = "KeyName";
                }
                //cmbsearch.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Close();
                //this.Dispose();
                string Recultstring = string.Empty;
                if (cmbsearch.SelectedItem != null)
                {
                    this.txtAddKey.Text = cmbsearch.SelectedItem.ToString().Trim();
                }
                else
                {
                    if (txtAddKey.Text == "")
                    {
                        XtraMessageBox.Show("Please Enter Key to Add in List.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAddKey.Focus();
                        return;
                    }

                    if (!cmbsearch.Items.Contains(this.txtAddKey.Text))
                    {
                        cmbsearch.Items.Add(this.txtAddKey.Text);
                    }



                    Resources.Instance.InsertMasterKeycom("Sp_insertMasterKeyCompList", this.txtAddKey.Text, "p_keyName", "p_returnValue", out Recultstring);
                }
                XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Recultstring == "Same Key Already Exists DB") return;
                //}
                // cmbsearch.SelectedIndex = 0;
                if (updatekeyValueHandler != null)
                    updatekeyValueHandler.Invoke(sender, this.txtAddKey.Text);
                txtAddKey.Text = "";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MachineEditKeyComponentUpd_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
                this.Close();
        }

        private void MachineEditKeyComponentUpd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((Keys)e.KeyValue == Keys.Escape)
            //    this.Close();
        }
        private bool IsCloseStatus = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                IsCloseStatus = true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtAddKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void MachineEditKeyComponentUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            updatekeyValueHandler -= null;
        }

        private void cmbsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void cmbsearch_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbsearch.Text != string.Empty)
            {

            }
        }

        private void cmbsearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:

                    return;
                case Keys.Up:

                    return;
                case Keys.Enter:
                    string Name = cmbsearch.Text;
                    return;
                case Keys.Escape:

                    return;
            }
        }

        private void MachineEditKeyComponentUpd_Load(object sender, EventArgs e)
        {
            try
            {
                cmbsearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbsearch.AutoCompleteSource = AutoCompleteSource.ListItems;
                //  label2.Visible = true;
                btnAdd.Visible = true;
                //if(!IsCloseStatus)
                //LoadData();
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string macname = this._MachineName;
                if (this._MachineName.Contains("_"))
                {

                    _MachineName = _MachineName.Split('_')[0];
                }
                KeyCompoSpecsReader specsRead = new KeyCompoSpecsReader(this.cmbsearch.Text, this.MacName);
                this.Dispose();
                specsRead.ShowDialog();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsearch.SelectedItem != null)
            {
                this.txtAddKey.Text = cmbsearch.SelectedItem.ToString().Trim();
            }
        }
    }
}
