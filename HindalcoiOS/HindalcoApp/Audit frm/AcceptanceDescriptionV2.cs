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

namespace HindalcoiOS.Audit_frm
{
    public partial class AcceptanceDescription : XtraForm
    {
        public AcceptanceDescription(string frmaction)
        {
            this.FormAction = frmaction;
            InitializeComponent();
        }

        public List<string> _MachineContain = new List<string>();
        public string MachineTag
        {
            get;
            set;
        }
        private DataTable MapColumn = null;
        private string FormAction
        {
            get;
            set;
        }
        //Milan Supakar
        public string AuditCodeG
        {
            get;
            set;
        }
        private DataTable BindColumn()
        {
            MapColumn = new DataTable();
            MapColumn.Columns.Add("Description", typeof(string));
            MapColumn.Columns.Add("Raise the issue", typeof(string));
            MapColumn.Columns.Add("Note", typeof(string));
            return MapColumn;
        }
        private void DynamicColumnBind()
        {
            DataGridViewComboBoxColumn cmbdecp = new DataGridViewComboBoxColumn();
            cmbdecp.HeaderText = "Constraint";
            cmbdecp.Name = "CmbContraint";
            cmbdecp.Items.Add(" Engineering");
            cmbdecp.Items.Add("Commercials");
            cmbdecp.Items.Add("Man - power");
            cmbdecp.Items.Add("Inventory");
            cmbdecp.Items.Add("Observation rejected");
            DgvAcceptnNo.Columns.Insert(1, cmbdecp);
        }
        private void cipp()
        {
            //DataTable dt =(DataTable) DgvAcceptnNo.DataSource;
        }
        private void AcceptanceDecription_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            DgvAcceptnNo.DataSource = BindColumn();
            DynamicColumnBind();
            LoadHistroydata(this.FormAction);
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
        public void LoadHistroydata(string tabletype)
        {

            DataTable dt = Resources.Instance.GetDataCAPA("Sp_FetchAcceptanceDetails", "@TbaleType", tabletype, "@machineTag", this.MachineTag, "@empCode", GlobalDeclaration._holdInfo[0].EmpCode);
            if (dt.Rows.Count > 0)
            {
                if (DgvAcceptnNo.Columns.Count > 0)
                {
                    _IsUpdateCellCAPA = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = MapColumn.NewRow();
                        MapColumn.Rows.Add(dr);
                        DgvAcceptnNo.Rows[i].Cells["Description"].Value = dt.Rows[i]["Description"];
                        DgvAcceptnNo.Rows[i].Cells["Raise the issue"].Value = dt.Rows[i]["Raise_the_issue"];
                        DgvAcceptnNo.Rows[i].Cells["CmbContraint"].Value = dt.Rows[i]["Constraints"];
                        DgvAcceptnNo.Rows[i].Cells["Note"].Value = dt.Rows[i]["Note"];
                        if (!_MachineContain.Contains(dt.Rows[i]["Machinetag"].ToString()))
                            _MachineContain.Add(dt.Rows[i]["Machinetag"].ToString());
                    }
                }
            }
        }
        private void addEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
            {
                AddRows();

            }
            else
            {
                RemoveRows();
            }
        }
        public void AddMachine(string machine)
        {
            if (!_MachineContain.Contains(machine))
                _MachineContain.Add(machine);
        }

        private void AddRows()
        {
            DataRow dr = MapColumn.NewRow();
            MapColumn.Rows.Add(dr);
        }
        private void RemoveRows()
        {
            try
            {
                if (this.DgvAcceptnNo.SelectedRows.Count > 0)
                {
                    string machinetag = string.Empty;
                    int index = this.DgvAcceptnNo.SelectedRows[0].Index;
                    MapColumn.Rows.RemoveAt(index);
                    if (_MachineContain.Count > 0)
                        machinetag = _MachineContain[index];
                    if (!string.IsNullOrEmpty(machinetag))
                    {
                        int status = Resources.Instance.RemoveEntry("Sp_DeleteAcceptanceDetailsEntry", "@TbaleType", "@machineTag", this.FormAction, machinetag, "");
                        _MachineContain.Remove(machinetag);
                        ReceiveCount--;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int ReceiveCount = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                int status = auditReportInsertion.InsertAccepdescription(this.DgvAcceptnNo, ReceiveCount, this.FormAction, this.MachineTag, this.AuditCodeG);
                if (status > 0)
                {
                    DialogResult = XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReceiveCount = Resources.Instance.GetDataCAPA("Sp_FetchAcceptanceDetails", "@TbaleType", this.FormAction, "@machineTag", this.MachineTag, "@empCode", GlobalDeclaration._holdInfo[0].EmpCode).Rows.Count;
                }
                else
                {

                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel
    ;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool _IsUpdateCellCAPA;
        private void DgvAcceptnNo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_IsUpdateCellCAPA) return;
                int colnindex = DgvAcceptnNo.CurrentCell.ColumnIndex;
                int rowind = DgvAcceptnNo.CurrentCell.RowIndex;
                string upp = @"Update AcceptanceDetailsTBL set " + DgvAcceptnNo.Columns[colnindex].Name + " ='"
                    + DgvAcceptnNo.Rows[e.RowIndex].Cells[colnindex].Value.ToString() + "' where Machinetag='" + _MachineContain[rowind] + "'";//EmpCode='"+ GlobalDeclaration._holdInfo[0].EmpCode+"'
                int r = Resources.Instance.SaveMaintenenceData(upp, "CAPA");
                if (r > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "CAPACell Update SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
