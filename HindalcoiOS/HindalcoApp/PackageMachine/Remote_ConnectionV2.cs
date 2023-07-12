using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CADImport;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using SparrowRMS;

namespace HindalcoiOS.PackageMachine
{
    public partial class Remote_Connection : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        public delegate void ConnectorEvent(params object[] args);
        public event ConnectorEvent ConnectorEvnt;
        public delegate void DrawImageonCad(params object[] args);
        public event DrawImageonCad DrawImage;
        private string Query = @"insert into RemoteConnectionTBL(SourceMachine,SourceCordinates,DestinationMachine,DestinationCordinates,MachineTag,ConnectorType,SourceTag,DestinationTag,RCDestinationCor,RCSourceCor,UserId,UserName,EmpCode) values";
        bool bIsComboBox;
        public string SysGenNumber = string.Empty;
        public DPoint SourceCordinate;
        private bool CallingSource;
        public Remote_Connection(DPoint points, bool callingsource)
        {
            InitializeComponent();
            CallingSource = callingsource;
            SourceCordinate = points;
            this.Text = "Remote Connection Configuration";
            UpdateTextPosition();

        }
        public Dictionary<string, DPoint> _Mcordinates
        {
            get;
            set;
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;


                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                this.Text = tmp + this.Text.Trim();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Remote_Connection_Load(object sender, EventArgs e)
        {
            try
            {
                if (CallingSource)
                {
                    string Crd = "X" + SourceCordinate.X + " " + "Y" + SourceCordinate.Y;
                    LoadRemoteConnectionList(Crd);
                }
                else
                {
                    if (GlobalDeclaration._MyTagDictinary.Count > 0)
                    {
                        cmbsearch.DataSource = new BindingSource(GlobalDeclaration._MyTagDictinary, null);
                        cmbsearch.DisplayMember = "Value";
                        cmbsearch.ValueMember = "Key";
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtinpute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void LoadRemoteConnectionList(string crd)
        {
            try
            {
                DataTable dt = Resources.Instance.GetDataKey("SP_FetchRemoteConnection", "p_RCSourceCor", crd, "p_RCDestinationCor", crd);
                if (dt.Rows.Count > 0)
                {
                    NumberCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVLoadRC.Rows.Add(dr);
                        DGVLoadRC.Rows[i].Cells["SNo"].Value = dt.Rows[i]["SrNo"];
                        DGVLoadRC.Rows[i].Cells["MName"].Value = dt.Rows[i]["DestinationMachine"];
                        DGVLoadRC.Rows[i].Cells["MCor"].Value = dt.Rows[i]["DestinationCordinates"];
                        DGVLoadRC.Rows[i].Cells["SysNo"].Value = dt.Rows[i]["MachineTag"];
                        DGVLoadRC.Rows[i].Cells["CType"].Value = dt.Rows[i]["ConnectorType"];
                        DGVLoadRC.Rows[i].Cells["SSource"].Value = dt.Rows[i]["SourceTag"];
                        DGVLoadRC.Rows[i].Cells["Dtination"].Value = dt.Rows[i]["DestinationTag"];
                        DGVLoadRC.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        DGVLoadRC.Rows[i].ReadOnly = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVLoadRC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DGVLoadRC.Columns["CType"].Index && e.RowIndex > -1)
                {
                    string Value = DGVLoadRC.Rows[e.RowIndex].Cells["CType"].Value.ToString();
                    string SourceMachine = DGVLoadRC.Rows[e.RowIndex].Cells["SSource"].Value.ToString().Split(',')[0].ToString();
                    Connector cnn = new Connector();
                    cnn.FromData = SourceMachine;
                    //cnn.FromDPoint = txtCordinate.Text;
                    cnn.Connecto = DGVLoadRC.Rows[e.RowIndex].Cells["MName"].Value.ToString();
                    cnn.ToDPoint = DGVLoadRC.Rows[e.RowIndex].Cells["MCor"].Value.ToString();
                    this.Hide();
                    this.ConnectorEvnt.Invoke(Value.ToString(), cnn, "RC");
                    // this.Hide();

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVLoadRC.Rows.Count > 0)
                {
                    List<DPoint> _Cordinates = RetrunCordinate();
                    DrawImage.Invoke(_Cordinates, DGVLoadRC);
                    SaveInDB(_Cordinates);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Please Add any connection in grid?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int SaveInDB(List<DPoint> _Cordinates)
        {
            int Status = 0;
            try
            {
                string query = string.Empty;
                string crdsecound = string.Empty;
                string Crd = string.Empty;
                int LitCounter = 0;
                for (int i = 0; i < DGVLoadRC.Rows.Count; i++)
                {
                    DPoint dPointfist = _Cordinates[LitCounter];
                    crdsecound = "X" + dPointfist.X + " " + "Y" + dPointfist.Y;
                    LitCounter++;
                    DPoint dPoint = _Cordinates[LitCounter];
                    Crd = "X" + dPoint.X + " " + "Y" + dPoint.Y;
                    LitCounter++;
                    if (DGVLoadRC.Rows[i].DefaultCellStyle.ForeColor != Color.Green)
                    {
                        query = query + "('" + txtsource.Text + "','" + txtCordinate.Text + "','" + DGVLoadRC.Rows[i].Cells["MachineName"].Value.ToString() +
                                       "','" + DGVLoadRC.Rows[i].Cells["MachineCor"].Value.ToString() + "','" + DGVLoadRC.Rows[i].Cells["SysGenNo"].Value.ToString() +
                                       "','" + DGVLoadRC.Rows[i].Cells["ConnType"].Value.ToString() +
                                       "','" + DGVLoadRC.Rows[i].Cells["Source"].Value.ToString() +
                                       "','" + DGVLoadRC.Rows[i].Cells["Destination"].Value.ToString() +
                                       "','" + crdsecound + "','" + Crd + "','" + GlobalDeclaration._holdInfo[0].UserId +
                                       "','" + GlobalDeclaration._holdInfo[0].UserName + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "'),";
                    }
                    else
                    {
                        // XtraMessageBox.Show("This Information Already Updated in DB. \n Please try Another ", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
                if (!string.IsNullOrEmpty(query))
                {
                    Query = Query + query.Remove(query.Length - 1, 1);
                    Status = Resources.Instance.SaveMaintenenceData(Query);
                    if (Status > 0)
                    {
                        XtraMessageBox.Show("Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGVLoadRC.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.DefaultCellStyle.ForeColor = Color.Green);
                        LitCounter = 0;
                    }
                    else
                    {
                        XtraMessageBox.Show("Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Status = 0;
            }
            return Status;
        }
        private List<DPoint> RetrunCordinate()
        {
            List<DPoint> _Cordinates = new List<DPoint>();
            try
            {
                for (int i = 0; i < DGVLoadRC.Rows.Count; i++)
                {
                    DPoint pos = GlobalDeclaration._Dpoint(DGVLoadRC.Rows[i].Cells["MachineCor"].Value.ToString());
                    if (!_Cordinates.Contains(pos))
                        _Cordinates.Add(pos);
                    // DgvRC.Rows[i].DefaultCellStyle.ForeColor = Color.Green;        
                }
                double X = 786.1086;
                double Y = 113.3313;
                string[] SourceValue = txtCordinate.Text.Split(' ');
                double X11 = double.Parse(SourceValue[0].Substring(1));
                double Y11 = double.Parse(SourceValue[1].Substring(1));
                X11 = X11 + X;
                Y11 = Y11 + Y;
                DPoint poSource = new DPoint(Math.Round(X11, 4), Math.Round(Y11, 4), 0);
                if (!_Cordinates.Contains(poSource))
                    _Cordinates.Add(poSource);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Cordinates;
        }

        private void DgvRC_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DGVLoadRC.Columns["ConnType"].Index)
                {
                    this.DGVLoadRC.BeginInvoke(objChangeCellType, e.RowIndex, "CnType", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "CnType")
                    {
                        if (DGVLoadRC.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.ReadOnly = false;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Electrical Cable", "Pipe", "Bus Bar", "Coupling" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        DGVLoadRC.Rows[iRowIndex].Cells[iColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DeleteRow()
        {
            try
            {
                if (this.DGVLoadRC.SelectedRows.Count > 0)
                {
                    int indes = this.DGVLoadRC.SelectedRows[0].Index;
                    DGVLoadRC.Rows.RemoveAt(indes);
                    NumberCount--;
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int NumberCount = 1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DPoint _Crd = (DPoint)cmbsearch.SelectedValue;
                string MachineName = this._Mcordinates.FirstOrDefault(X => X.Value == _Crd).Key.ToString();
                string MachineTag = ((KeyValuePair<CADImport.DPoint, string>)cmbsearch.SelectedItem).Value;
                if (txtCordinate.Text != "X" + _Crd.X + " " + "Y" + _Crd.Y)
                {
                    bool IExists = DGVLoadRC.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["SysGenNo"].Value.Equals(MachineTag));
                    if (!IExists)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVLoadRC.Rows.Add(dr);
                        int index = DGVLoadRC.Rows.Count - 1;
                        DGVLoadRC.Rows[index].Cells["SrNo"].Value = NumberCount++;
                        DGVLoadRC.Rows[index].Cells["MachineCor"].Value = "X" + _Crd.X + " " + "Y" + _Crd.Y;
                        DGVLoadRC.Rows[index].Cells["MachineName"].Value = MachineName;
                        DGVLoadRC.Rows[index].Cells["SysGenNo"].Value = MachineTag;
                        DGVLoadRC.Rows[index].Cells["Source"].Value = txtsource.Text + "," + GlobalDeclaration._MyTagDictinary[SourceCordinate];
                        DGVLoadRC.Rows[index].Cells["Destination"].Value = MachineName + "," + DGVLoadRC.Rows[index].Cells["SysGenNo"].Value;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please Select Destination Machine.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddNewRow()
        {
            try
            {
                DataGridViewRow dr = new DataGridViewRow();
                DGVLoadRC.Rows.Add(dr);
                int index = DGVLoadRC.Rows.Count - 1;
                DGVLoadRC.Rows[index].Cells["SrNo"].Value = NumberCount++;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            switch (((ToolStripMenuItem)sender).Text.ToString())
            {
                case "Add Row":
                    {
                        AddNewRow();
                    }
                    break;
                case "Delete Row":
                    DeleteRow();
                    break;
            }
        }

        private void DgvRC_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVLoadRC.IsCurrentCellDirty)
            {
                DGVLoadRC.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void Remote_Connection_Shown(object sender, EventArgs e)
        {
            // LoadRemoteConnectionList();
        }
        private void DgvRC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == 4 && e.RowIndex > -1)
                //{
                //    if (DgvRC.Rows[e.RowIndex].Cells["ConnType"].Value != null)
                //    {
                //        var ConnectioTpe = DgvRC.Rows[e.RowIndex].Cells["ConnType"].Value;
                //        Connector cnn = new Connector();
                //        cnn.FromData = txtsource.Text;
                //        cnn.FromDPoint = txtCordinate.Text;
                //        cnn.Connecto = DgvRC.Rows[e.RowIndex].Cells["MachineName"].Value.ToString();
                //        cnn.ToDPoint = DgvRC.Rows[e.RowIndex].Cells["MachineCor"].Value.ToString();
                //        DgvRC.Rows[e.RowIndex].ReadOnly = true;
                //        this.Hide();
                //        this.ConnectorEvnt.Invoke(ConnectioTpe, cnn, "RC");

                //    }
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvRC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (DGVLoadRC.CurrentCell.ColumnIndex == 4 && e.Control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = e.Control as System.Windows.Forms.ComboBox;
                    comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                    comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var sendingCB = sender as DataGridViewComboBoxEditingControl;
                string Value = sendingCB.EditingControlFormattedValue.ToString();
                if (!string.IsNullOrEmpty(Value))
                {
                    DGVLoadRC.CurrentRow.Selected = true;
                    if (DGVLoadRC.SelectedRows[0].Cells["ConnType"].Value == DBNull.Value) return;
                    if (DGVLoadRC.SelectedRows.Count > 0)
                    {
                        Connector cnn = new Connector();
                        cnn.FromData = txtsource.Text;
                        cnn.FromDPoint = txtCordinate.Text;
                        cnn.Connecto = DGVLoadRC.SelectedRows[0].Cells["MachineName"].Value.ToString();
                        cnn.ToDPoint = DGVLoadRC.SelectedRows[0].Cells["MachineCor"].Value.ToString();
                        this.Hide();
                        this.ConnectorEvnt.Invoke(Value.ToString(), cnn, "RC");
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVLoadRC.SelectedRows.Count > 0)
                {
                    string ToDpoints = DGVLoadRC.SelectedRows[0].Cells["MCor"].Value.ToString();
                    DPoint pos = GlobalDeclaration._Dpoint(ToDpoints);
                    string Points = "X" + pos.X + " " + "Y" + pos.Y;
                    RemoveRemoteConnectionData(Points, DGVLoadRC.SelectedRows[0].Cells["MName"].Value.ToString());
                }
                else
                {
                    XtraMessageBox.Show("Please Select Row.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DGVLoadRC.Focus();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoveRemoteConnectionData(string points, string name)
        {
            try
            {
                int sts = Resources.Instance.RemoveEntry("SP_RemoveRemoteConnection", "p_RcCordinate", points);
                if (sts > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Successfully Deleted Information of \n " + name + " from DB.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DGVLoadRC.Rows.RemoveAt(DGVLoadRC.SelectedRows[0].Index);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLoadRC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
