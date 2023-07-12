using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Dynamic_Form;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace HindalcoiOS.Safety_Form_list
{
    public partial class JSAInput : XtraForm
    {
        #region "Variable Declaration"
        bool isNewControl = false;


        #endregion
        public string MachineTag
        {
            get;
            set;
        }

        public string MachineCoordinate
        {
            get;
            set;
        }
        //public JSAInput(string machinetag)
        //{
        //    InitializeComponent();
        //    this.Text = "Safety HIRA/JSA Input Information";
        //    UpdateTextPosition();
        //    MachineTag = machinetag;
        //}

        public JSAInput(string machinetag, string machineCoordinate)
        {
            InitializeComponent();
            this.Text = "Safety HIRA/JSA Input Information";
            UpdateTextPosition();
            MachineTag = machinetag;
            MachineCoordinate = machineCoordinate;

        }

        private void JSAInput_Load(object sender, EventArgs e)
        {
            HideJSAInputPagesHeader();
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            //{
            GridFillData(xtraTabControl.SelectedTab.Name);
            GridSeeting();
            //}
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
        private void GridSeeting()
        {
            try
            {
                DGVJSinput.BorderStyle = BorderStyle.Fixed3D;
                DGVJSinput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVJSinput.AllowUserToResizeColumns = false;
                DGVJSinput.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                DGVJSinput.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                DGVJSinput.DefaultCellStyle.SelectionForeColor = Color.Black;
                DGVJSinput.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DGVJSinput.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DGVJSinput.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);


                DGVWithCTRL.BorderStyle = BorderStyle.Fixed3D;
                DGVWithCTRL.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVWithCTRL.AllowUserToResizeColumns = false;
                DGVWithCTRL.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                DGVWithCTRL.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                DGVWithCTRL.DefaultCellStyle.SelectionForeColor = Color.Black;
                DGVWithCTRL.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DGVWithCTRL.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DGVWithCTRL.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            try
            {
                if (isNewControl == true && DGVWithCTRL.Rows.Count > 0)
                {

                    using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        int rowIndex = DGVJSinput.Rows.Count;
                        for (int a = 0; a < rowIndex; a++)
                        {
                            Resources.Instance.AddSafetyJSANoControl(DGVJSinput.Rows[a].Cells[0].Value.ToString(), DGVJSinput.Rows[a].Cells[1].Value.ToString(), DGVJSinput.Rows[a].Cells[2].Value.ToString(), DGVJSinput.Rows[a].Cells[3].Value.ToString(), DGVJSinput.Rows[a].Cells[4].Value.ToString(), DGVJSinput.Rows[a].Cells[5].Value.ToString(), DGVJSinput.Rows[a].Cells[6].Value.ToString(), Convert.ToInt32(DGVJSinput.Rows[a].Cells[7].Value), Convert.ToInt32(DGVJSinput.Rows[a].Cells[8].Value), DGVJSinput.Rows[a].Cells[9].Value.ToString(), DGVJSinput.Rows[a].Cells[10].Value.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, MachineCoordinate);
                            Resources.Instance.AddJSAInptMstNewCtrlTBL(DGVWithCTRL.Rows[a].Cells[0].Value.ToString(), DGVWithCTRL.Rows[a].Cells[1].Value.ToString(), Convert.ToInt32(DGVWithCTRL.Rows[a].Cells[2].Value), Convert.ToInt32(DGVWithCTRL.Rows[a].Cells[3].Value), DGVWithCTRL.Rows[a].Cells[4].Value.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, MachineCoordinate);
                        }

                        txscope.Complete();
                        XtraMessageBox.Show("Record saved successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.MachineCoordinate = string.Empty;
                        this.MachineTag = string.Empty;
                        this.Close();
                        //this.Dispose();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please fill HIRA with New Control too.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // this.xtraTabControl.SelectedTabPageIndex = 1;

                    //string Name = ((XtraTabControl)sender).Name;
                    //GridFillData(Name);
                    //return;
                }

                isNewControl = false;
            }
            catch (Exception Ex)
            {
                this.MachineCoordinate = string.Empty;
                this.MachineTag = string.Empty;
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        DataRow dr = null;
        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Ctrl = ((ToolStripMenuItem)sender).Tag.ToString();
                if (Ctrl == "Add")
                {
                    if (xtraTabControl.SelectedTab.Name == xtraTabPageWithctrl.Name)
                    {
                        dr = GlobalDeclaration.MapColumnDGV.NewRow();
                        GlobalDeclaration.MapColumnDGV.Rows.Add(dr);
                        int index = DGVJSinput.Rows.Count - 1;
                        DGVJSinput.Rows[index].Cells["Sr.No"].Value = GlobalDeclaration.MapColumnDGV.Rows.Count;
                    }
                    else
                    {
                        dr = GlobalDeclaration.MapColumnDVGWithCTRL.NewRow();
                        GlobalDeclaration.MapColumnDVGWithCTRL.Rows.Add(dr);
                        isNewControl = true;
                        //int index = DGVWithCTRL.Rows.Count - 1;
                        //DGVWithCTRL.Rows[index].Cells["SrNo"].Value = GlobalDeclaration.MapColumnDVGWithCTRL.Rows.Count;
                    }
                }
                else
                {
                    DelteRowFromGrid(sender);
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelteRowFromGrid(object sender)
        {
            if (GlobalDeclaration.MapColumnDGV.Rows.Count > 0 || GlobalDeclaration.MapColumnDVGWithCTRL.Rows.Count > 0)
            {
                if (xtraTabControl.SelectedTab.Name == xtraTabPageWithctrl.Name)
                {
                    //foreach (DataGridViewRow item in this.DGVJSinput.SelectedRows)
                    //{
                    GlobalDeclaration.MapColumnDGV.Rows.RemoveAt(this.DGVJSinput.SelectedRows[0].Index);
                    GlobalDeclaration.MapColumnDGV.AcceptChanges();
                    // DGVJSinput.Rows.RemoveAt(item.Index);
                    //}
                }
                else
                {
                    //foreach (DataGridViewRow item in this.DGVWithCTRL.SelectedRows)
                    //{
                    GlobalDeclaration.MapColumnDVGWithCTRL.Rows.RemoveAt(this.DGVWithCTRL.SelectedRows[0].Index);
                    GlobalDeclaration.MapColumnDVGWithCTRL.AcceptChanges();

                    //DGVWithCTRL.Rows.RemoveAt(item.Index);
                    //}
                }
            }
            else
            {
                XtraMessageBox.Show("No Rows Are Remain For Delete", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GridFillData(string TabName)
        {
            try
            {
                if (TabName == xtraTabPageWithctrl.Name) //"xtraTabPageWithctrl")
                {
                    if (DGVJSinput.Columns.Count > 0) return;

                    if (GlobalDeclaration.MapColumnDGV.Columns.Count > 0)
                    {
                        DataGridViewComboBoxColumn colCombo = new DataGridViewComboBoxColumn();
                        colCombo.HeaderText = "TypeOfWork";
                        colCombo.Name = "cmbTypework";
                        colCombo.Items.Add("Routine");
                        colCombo.Items.Add("Non-Routine");
                        DataGridViewComboBoxColumn colCombo1 = new DataGridViewComboBoxColumn();
                        colCombo1.HeaderText = "TypeofControls";
                        colCombo1.Name = "cmbTypeworkcontl";
                        colCombo1.Items.Add("Elimination");
                        colCombo1.Items.Add("Substitution");
                        colCombo1.Items.Add("Engineering");
                        colCombo1.Items.Add("Administrative");
                        colCombo1.Items.Add("PPE");
                        colCombo1.Items.Add("Training and Awarness");
                        DGVJSinput.DataSource = GlobalDeclaration.MapColumnDGV;

                        int columnindex = DGVJSinput.Columns["TypeOfWork"].Index;
                        int typeofctrlindex = DGVJSinput.Columns["TypeofControls"].Index;
                        DGVJSinput.Columns.Remove("TypeOfWork");
                        DGVJSinput.Columns.Insert(columnindex, colCombo);
                        DGVJSinput.Columns.Remove("TypeofControls");
                        DGVJSinput.Columns.Insert(typeofctrlindex, colCombo1);
                    }

                }
                else
                {
                    if (DGVWithCTRL.Columns.Count > 0) return;
                    DataGridViewComboBoxColumn colComboCTRL = new DataGridViewComboBoxColumn();
                    colComboCTRL.HeaderText = "Acceptibility";
                    colComboCTRL.Name = "cmbAcceptibility";
                    colComboCTRL.Items.Add("Yes");
                    colComboCTRL.Items.Add("No");
                    DGVWithCTRL.DataSource = GlobalDeclaration.MapColumnDVGWithCTRL;
                    DGVWithCTRL.Columns.Remove("Acceptibility");
                    DGVWithCTRL.Columns.Insert(4, colComboCTRL);



                }
            }
            catch (Exception Ex)
            {
                this.MachineCoordinate = string.Empty;
                this.MachineTag = string.Empty;
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void xtraTabControl_Click(object sender, EventArgs e)
        {
            string Name = ((XtraTabControl)sender).Name;
            GridFillData(Name);
        }

        private void DGVWithCTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DelteRowFromGrid(sender);
            }
        }

        private void DGVJSinput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DelteRowFromGrid(sender);
            }
        }
        private void DGVJSinput_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGVJSinput.CurrentCell.ColumnIndex == 10 && e.Control is System.Windows.Forms.ComboBox)
            {
                System.Windows.Forms.ComboBox comboBox = e.Control as System.Windows.Forms.ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var currentcell = DGVJSinput.CurrentCellAddress;
                var sendingCB = sender as DataGridViewComboBoxEditingControl;
                // DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)DGVJSinput.Rows[currentcell.Y].Cells[10];
                string Value = sendingCB.EditingControlFormattedValue.ToString();
                if (!string.IsNullOrEmpty(Value) && Value == "Training and Awarness")
                {
                    if (!string.IsNullOrEmpty(MachineTag))
                    {
                        TrainingCalenderUpload _upload = new TrainingCalenderUpload(string.Empty);
                        _upload.TopMost = true;
                        if (_upload.ShowDialog() == DialogResult.OK)
                        {
                            _upload.Close();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Please enter MachineTag First in Function Tab", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void JSAInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalDeclaration.MapColumnDGV.Rows.Clear();
        }

        private void xtraTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnWithoutControl_Click(object sender, EventArgs e)
        {
            xtraTabControl.SelectedIndex = 0;
        }
        private void btnWithControl_Click(object sender, EventArgs e)
        {
            xtraTabControl.SelectedIndex = 1;
        }

        
        private void HideJSAInputPagesHeader()
        {
            xtraTabControl.Appearance = TabAppearance.FlatButtons;
            xtraTabControl.ItemSize = new Size(0, 1);
            xtraTabControl.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in xtraTabControl.TabPages)
            {
                tab.Hide();// = "";
            }
        }
    }
}
