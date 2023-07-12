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
    public partial class AcceptanceDetails : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        public AcceptanceDetails(string respon, string frmaction)
        {
            this.Resposibility = respon;
            this.formaction = frmaction;
            InitializeComponent();
        }
        public List<string> _MachineContain = new List<string>();
        public string MachineTag
        {
            get;
            set;
        }
        public String formaction
        {
            get;
            set;
        }
        public string AuditCodeG
        {
            get;
            set;
        }
        public string Resposibility
        {
            get;
            set;
        }
        private void AcceptanceDetails_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            LoadHistroydata(this.formaction);
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
            DataTable dt = Resources.Instance.GetDataCAPA("Sp_FetchAcceptanceDetail", "@TbaleType", tabletype, "@machineTag", this.MachineTag, "@AuditCode", this.AuditCodeG);
            if (dt.Rows.Count > 0)
            {
                ReceiveCount = dt.Rows.Count;
                _IsUpdateCellCAPA = true;
                if (DgvAcceptance.Columns.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvAcceptance.Rows.Add(dr);
                        int Index = DgvAcceptance.Rows.Count - 1;
                        ; DgvAcceptance.Rows[Index].Cells["Timeframe"].Value = dt.Rows[i]["Timeframe"].ToString();
                        DgvAcceptance.Rows[Index].Cells["Capability"].Value = dt.Rows[i]["Capability"].ToString();
                        DgvAcceptance.Rows[Index].Cells["Dateofclosure"].Value = dt.Rows[i]["Date_of_closure"];
                        DgvAcceptance.Rows[Index].Cells["cmbRespoc"].Value = dt.Rows[i]["Responsibility"].ToString();
                        DgvAcceptance.Rows[Index].Cells["cmbinventry"].Value = dt.Rows[i]["Inventory_required"].ToString();
                        DgvAcceptance.Rows[Index].Cells["Note"].Value = dt.Rows[i]["Notes"].ToString();
                        if (!_MachineContain.Contains(dt.Rows[i]["Machinetag"].ToString()))
                            _MachineContain.Add(dt.Rows[i]["Machinetag"].ToString());
                    }
                }
            }
        }

        //string InsertDetails = @"insert into AcceptanceDecripTBL(Timeframe,Capability,Date_of_closure,Responsibility,Inventory_required,Notes,Machinetag)values";
        private int ReceiveCount = 0;
        public int SaveDetails()
        {
            int Status = 0;
            try
            {
                if (DgvAcceptance.Rows.Count > 0)
                {
                    AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                    int result = auditReportInsertion.InsertAcceptanceDetails(this.DgvAcceptance, this.ReceiveCount, this.formaction, this.MachineTag, this.AuditCodeG);
                    if (result > 0)
                    {
                        Status = result;
                        ReceiveCount = Resources.Instance.GetDataCAPA("Sp_FetchAcceptanceDetail", "@TbaleType", this.formaction, "@machineTag", this.MachineTag, "@AuditCode", this.AuditCodeG).Rows.Count;
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.AuditCodeG = string.Empty;
                    }
                    else
                    {
                        Status = result;
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Status;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (SaveDetails() > 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                //DialogResult = DialogResult.Cancel;
            }

        }

        public void AddMachine(string machine)
        {
            if (!_MachineContain.Contains(machine))
                _MachineContain.Add(machine);
        }
        private void DgvAcceptance_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if(MapAcccml.Rows.Count>0)
            //    {
            //        RemoveRows();
            //    }
            //}
            //else if(e.KeyCode==Keys.Control && e.KeyCode==Keys.A)
            //{
            //    AddRows();
            //}
        }
        private void AddRows()
        {
            DataGridViewRow dr = new DataGridViewRow();
            DgvAcceptance.Rows.Add(dr);
            int Index = DgvAcceptance.Rows.Count - 1;
            DgvAcceptance.Rows[Index].Cells["cmbRespoc"].Value = this.Resposibility;
        }
        private void RemoveRows()
        {
            if (this.DgvAcceptance.SelectedRows.Count > 0)
            {
                string machinetag = string.Empty;
                int index = this.DgvAcceptance.SelectedRows[0].Index;
                if (_MachineContain.Count > 0)
                {
                    machinetag = _MachineContain[index];
                }
                DgvAcceptance.Rows.RemoveAt(index);
                if (!string.IsNullOrEmpty(MachineTag))
                {
                    int status = Resources.Instance.RemoveEntry("Sp_DeleteAcceptanceEntry", "@TbaleType", "@machineTag", this.formaction, machinetag, "");
                    _MachineContain.Remove(machinetag);
                    ReceiveCount--;
                }
            }
        }
        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTimePicker NextDateTimePicker;
        private void DgvAcceptance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                NextDateTimePicker = new DateTimePicker();  //DateTimePicker 

                //Adding DateTimePicker control into DataGridView
                DgvAcceptance.Controls.Add(NextDateTimePicker);

                // Intially made it invisible
                NextDateTimePicker.Visible = false;

                // Setting the format (i.e. 2014-10-10)
                NextDateTimePicker.Format = DateTimePickerFormat.Custom;  //
                NextDateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";

                NextDateTimePicker.TextChanged += new EventHandler(NextDateTimePicker_OntextChange);

                // Now make it visible
                NextDateTimePicker.Visible = true;

                // It returns the retangular area that represents the Display area for a cell
                Rectangle oRectangle = DgvAcceptance.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control
                NextDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location
                NextDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                NextDateTimePicker.CloseUp += new EventHandler(NextDateTimePicker_CloseUp);
            }
        }
        void NextDateTimePicker_OntextChange(object sender, EventArgs e)
        {
            DgvAcceptance.CurrentCell.Value = NextDateTimePicker.Text.ToString();
        }
        void NextDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            NextDateTimePicker.Visible = false;
        }
        bool _IsUpdateCellCAPA;
        private void DgvAcceptance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_IsUpdateCellCAPA) return;
                if (DgvAcceptance.Rows.Count > 0)
                {

                    int colnindex = DgvAcceptance.CurrentCell.ColumnIndex;
                    int rowind = DgvAcceptance.CurrentCell.RowIndex;
                    string upp = @"Update AcceptanceDecripTBL set " + DgvAcceptance.Columns[colnindex].Name + " ='" +
                        DgvAcceptance.Rows[e.RowIndex].Cells[colnindex].Value.ToString() + "' where Machinetag='" + _MachineContain[rowind] + "'";//and EmpCode='"+ GlobalDeclaration._holdInfo[0].EmpCode+"'
                    int r = Resources.Instance.SaveMaintenenceData(upp, "CAPA");
                    if (r > 0)
                    {
                        XtraMessageBox.Show("CAPACell Update SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool bIsComboBox;
        private void DgvAcceptance_Scroll(object sender, ScrollEventArgs e)
        {
            if (NextDateTimePicker != null)
                NextDateTimePicker.Visible = false;
        }

        private void DgvAcceptance_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
            if (e.ColumnIndex == this.DgvAcceptance.Columns["cmbRespoc"].Index)
            {
                this.DgvAcceptance.BeginInvoke(objChangeCellType, e.RowIndex, "cmbRespoc", e.ColumnIndex);
                bIsComboBox = false;
            }

            else if (e.ColumnIndex == this.DgvAcceptance.Columns["cmbinventry"].Index)
            {
                this.DgvAcceptance.BeginInvoke(objChangeCellType, e.RowIndex, "cmbinventry", e.ColumnIndex);
                bIsComboBox = false;
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "cmbRespoc")
                    {
                        if (DgvAcceptance.Rows[iRowIndex].Cells[DgvAcceptance.CurrentCell.ColumnIndex].Value != null) return;

                    }
                    else if (ColumnName == "cmbinventry")
                    {
                        DataGridViewComboBoxCell DGVcmbMachineTag = new DataGridViewComboBoxCell();
                        DGVcmbMachineTag.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Yes", "No" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        DGVcmbMachineTag.DataSource = RiskDt;
                        DGVcmbMachineTag.ValueMember = "Name";
                        DGVcmbMachineTag.DisplayMember = "Name";
                        DgvAcceptance.Rows[iRowIndex].Cells[DgvAcceptance.CurrentCell.ColumnIndex] = DGVcmbMachineTag;
                        //bIsComboBox = true;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}