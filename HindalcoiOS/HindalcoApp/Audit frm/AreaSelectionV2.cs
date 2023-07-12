using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Configuration;
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

namespace HindalcoiOS.Audit_frm
{
    public partial class AreaSelection : XtraForm
    {
        private string CurrentValue = string.Empty;
        private string SelectName = string.Empty;
        public AreaSelection()
        {

            InitializeComponent();
        }
        private void AreaSelection_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            GetEmpName();

            this.cmbAreaOwner.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbAreaOwner.AutoCompleteSource = AutoCompleteSource.ListItems;
            DataTable Areamaster = Resources.Instance.GetMachineAreaMaster(); //Change by RP
            for (int y = 0; y < Areamaster.Rows.Count; y++)
            {
                cmbAreaName.Items.Add(Areamaster.Rows[y]["NameOfArea"]);
            }
        }


        private void GetEmpName()
        {
            try
            {
                if (Resources.Instance._EmpName.Rows.Count >= 0)
                {
                    Resources.Instance.AreaOwner.Clear();
                    Resources.Instance.AreaOwner = Resources.Instance.GetDataKey("Sp_FetchAreamMaster");
                    if (Resources.Instance._EmpName.Rows.Count > 0)
                        for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                        {
                            string empName = Resources.Instance._EmpName.Rows[i]["emp_name"].ToString();
                            if(!string.IsNullOrEmpty(empName))
                            {
                                this.cmbAreaOwner.Items.Add(empName);
                            }
                        }
                }
                if (DgvAreaMaster.Rows.Count > 0)
                {
                    this.DgvAreaMaster.Rows.Clear();
                }

                if (Resources.Instance.AreaOwner.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.AreaOwner.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvAreaMaster.Rows.Insert(0, dr);
                        DgvAreaMaster.Rows[0].Cells["Areaname"].Value = Resources.Instance.AreaOwner.Rows[i]["NameOfArea"].ToString();
                        DgvAreaMaster.Rows[0].Cells["AreaOwner"].Value = Resources.Instance.AreaOwner.Rows[i]["AreaOwner"].ToString();
                        DgvAreaMaster.Rows[0].ReadOnly = true;
                    }
                }
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string Recultstring = string.Empty;
                if (cmbAreaName.Text == "")// if (txtAreaName.Text == "")
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Enter Area Name!.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAreaName.Focus();
                    return;
                }
                if (cmbAreaOwner.CheckedItems.Count == 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please select Area Owner Name!.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAreaOwner.Focus();
                    return;
                }
                Resources.Instance.InsertMasterKeycom("Sp_InsertAreaMaster", "@Areaname", "@AreaOwner", this.cmbAreaName.Text, SelectionValue(), "@stringtus", out Recultstring);
                //Resources.Instance.InsertMasterKeycom("Sp_InsertAreaMaster", "@Areaname", "@AreaOwner", this.txtAreaName.Text, SelectionValue(), "@stringtus", out Recultstring);
                XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DialogResult = DialogResult.OK;

                var items = cmbAreaOwner.CheckedItems;
                for (int i = 0; i < items.Count; i++)
                {
                    cmbAreaOwner.SetItemChecked(i, false);
                }
                if (cmbAreaOwner.CheckedItems.Count > 0)
                {
                    cmbAreaOwner.Items.Clear();
                    if (Resources.Instance._EmpName.Rows.Count > 0)
                    {
                        if (Resources.Instance._EmpName.Rows.Count > 0)
                            for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                            {
                                this.cmbAreaOwner.Items.Add(Resources.Instance._EmpName.Rows[i]["emp_name"].ToString());
                            }
                    }

                }
                if (Recultstring == "Successfully")
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    DgvAreaMaster.Rows.Insert(0, dr);
                    DgvAreaMaster.Rows[0].Cells["Areaname"].Value = cmbAreaName.Text;// this.txtAreaName.Text;
                    DgvAreaMaster.Rows[0].Cells["Owner"].Value = SelectionValue();
                    DgvAreaMaster.Rows[0].ReadOnly = true;
                    cmbAreaName.Text = string.Empty;
                    //txtAreaName.Text = string.Empty;// Clear();
                    for (int i = cmbAreaOwner.Items.Count - 1; i >= 0; i--)
                    {
                        // clb is the name of the CheckedListBox control.
                        if (cmbAreaOwner.GetItemChecked(i))
                        {
                            cmbAreaOwner.Items.Remove(cmbAreaOwner.Items[i]);
                        }
                    }
                    SelectName = string.Empty;
                }
                ResetAll();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string SelectionValue()
        {

            var item = cmbAreaOwner.CheckedItems;
            for (int i = 0; i < item.Count; i++)
            {
                //SelectName = item[i].ToString();
                SelectName = SelectName + item[i].ToString() + ",";
            }
            if (!string.IsNullOrEmpty(SelectName))
            {
                if (SelectName.Contains(','))
                {
                    SelectName = SelectName.Remove(SelectName.Length - 1, 1);
                }
            }
            return SelectName;
        }

        private void txtboxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void cmbAreaOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selindex = cmbAreaOwner.SelectedIndex;
                if (selindex >= 0)
                {
                    if (cmbAreaOwner.CheckedItems.Count == 2) return;
                    cmbAreaOwner.SetItemChecked(selindex, true);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

       

        private void btnAreaUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               // if (DgvAreaMaster.SelectedRows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(cmbAreaName.Text))//(txtAreaName.Text))//CurrentValue))
                    {
                        string AreaName = cmbAreaName.Text;// DgvAreaMaster.SelectedRows[0].Cells["Areaname"].Value.ToString();
                        string Owner = string.Empty;
                        for (int m = 0; m < cmbAreaOwner.CheckedItems.Count; m++)
                        {
                            Owner = Owner + ',' + cmbAreaOwner.CheckedItems[m].ToString();
                        }
                        if (Owner.StartsWith(","))
                        {
                            Owner = Owner.Remove(0, 1);
                        }
                        if (string.IsNullOrEmpty(Owner))
                        {
                            MessageBox.Show("Please select atleast single AreaOwner!");
                            return;
                        }
                        int Status = Resources.Instance.UpdateArea("Sp_UpdateArea", "@Areaname", "@AreaOwner", "@sts", "@UpdateArea", AreaName, Owner, "update", CurrentValue);
                        if (Status > 0)
                        {
                            CurrentValue = string.Empty;
                            XtraMessageBox.Show("Record updated successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        GetEmpName();
                    }
                }
                //ResetAll();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetAll()
        {
            cmbAreaName.Text = string.Empty;
            cmbAreaOwner.Text = string.Empty;
            for (int i = 0; i < cmbAreaOwner.Items.Count; i++)
            {
                cmbAreaOwner.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetAll();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewArea_Click(object sender, EventArgs e)
        {
            CheckAreaData();
        }
        private void CheckAreaData()
        {
            
            AreaCreationView areaView = new AreaCreationView();
            areaView.GetValue += UnitHandlerEvent;
            if (areaView.ShowDialog() == DialogResult.OK)
            {
                areaView.Close();
                areaView.Dispose();
                LoadAreaMaster();
            }
            //else
            //{
            //    uOMView.Close();
            //    uOMView.Dispose();
            //}
            //}
        }

        private void UnitHandlerEvent(object sender, string value)
        {
            //if (!cmbUnit.Items.Contains(value))
            //{
            //    cmbUnit.Items.Add(value);
            //    cmbUnit.Text = value.ToString();
            //}
        }

        private void DgvAreaMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex > -1 && e.RowIndex >= 0)
                {
                    if (DgvAreaMaster.Rows.Count > 0)
                    {
                        CurrentValue = DgvAreaMaster.Rows[e.RowIndex].Cells["Areaname"].Value.ToString();
                        //if (e.ColumnIndex == 0)
                        {
                            DgvAreaMaster.Rows[e.RowIndex].ReadOnly = true;
                            btnAreaUpdate.Visible = true;
                            cmbAreaName.Text= this.DgvAreaMaster.Rows[e.RowIndex].Cells["AreaName"].Value.ToString();
                            string[] areaowner = new string[] { };
                            string areaown = this.DgvAreaMaster.Rows[e.RowIndex].Cells["AreaOwner"].Value.ToString();
                            areaowner = areaown.Split(',');
                            if (!string.IsNullOrEmpty(areaown))
                            {
                                var items = cmbAreaOwner.CheckedItems;
                                for (int i = 0; i < items.Count; i++)
                                {
                                    cmbAreaOwner.SetItemChecked(i, false);
                                }
                                if (cmbAreaOwner.CheckedItems.Count > 0)
                                {
                                    cmbAreaOwner.Items.Clear();
                                    if (Resources.Instance._EmpName.Rows.Count > 0)
                                    {
                                        if (Resources.Instance._EmpName.Rows.Count > 0)
                                            for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                                            {
                                                this.cmbAreaOwner.Items.Add(Resources.Instance._EmpName.Rows[i]["emp_name"].ToString());
                                            }
                                     }
                                }

                                //foreach (var item in cmbAreaOwner.Items)
                                //{
                                //    int index = cmbAreaOwner.Items.IndexOf(item);
                                //    cmbAreaOwner.SetItemCheckState(index, CheckState.Unchecked);
                                //}  
                            } 
                            for (int i = 0; i < areaowner.Length; i++)
                            {
                                
                                int index = cmbAreaOwner.Items.IndexOf(areaowner[i].ToString());
                                if(index!=-1)
                                cmbAreaOwner.SetItemCheckState(index, CheckState.Checked);
                            }
                        }
                        //else if (e.ColumnIndex == 1)
                        //{
                        //    string AreaName = DgvAreaMaster.Rows[e.RowIndex].Cells["Areaname"].Value.ToString();
                        //    string Owner = DgvAreaMaster.Rows[e.RowIndex].Cells["AreaOwner"].Value.ToString();
                        //    int Status = Resources.Instance.UpdateArea("Sp_UpdateArea", "@Areaname", "@AreaOwner", "@sts", "@UpdateArea", AreaName, Owner, "delete", CurrentValue);
                        //    if (Status > 0)
                        //    {
                        //        XtraMessageBox.Show("Record Deleted Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //    DgvAreaMaster.Rows.RemoveAt(e.RowIndex);
                        //}
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAreaMaster()
        {
            DataTable Areamaster = Resources.Instance.GetMachineAreaMaster(); //Change by RP
            for (int y = 0; y < Areamaster.Rows.Count; y++)
            {
                cmbAreaName.Items.Add(Areamaster.Rows[y]["NameOfArea"]);
            }
        }


    }
}
