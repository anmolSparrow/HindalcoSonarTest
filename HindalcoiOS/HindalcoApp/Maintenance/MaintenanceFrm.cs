using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Maintenance
{
    public partial class MaintenanceFrm : DevExpress.XtraEditors.XtraForm
    {
        private readonly string SysGenName = string.Empty;
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        private string machinename = string.Empty;
        public MaintenanceFrm(string sysname,string MachineName)
        {
            SysGenName = sysname;
            this.machinename = MachineName;
            this.Text = "Maintenance Machine Checklist ";
            UpdateTextPosition();
            InitializeComponent();
        }
        public Dictionary<string, Connector> _listconnt
        {
            get;
            set;
        }
        public Dictionary<string, List<string>> ReceiveConValue
        {
            get;
            set;
        }

        private void MaintenanceFrm_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            AddHeaderCheckBox();
            //HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            //HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            //dgvSelectAll.CellValueChanged += new DataGridViewCellEventHandler(dgvSelectAll_CellValueChanged);
            //dgvSelectAll.CurrentCellDirtyStateChanged += new EventHandler(dgvSelectAll_CurrentCellDirtyStateChanged);
            //dgvSelectAll.CellPainting += new DataGridViewCellPaintingEventHandler(dgvSelectAll_CellPainting);
            BindGridView();
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
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void BindGridView()
        {
            GetDataSource();
            TotalCheckBoxes = dgvSelectAll.RowCount;
            TotalCheckedCheckBoxes = 0;
        }

        private void GetDataSource()
        {

            try
            {
                if (this.ReceiveConValue == null) return;
                if (this._listconnt.Count > 0 && !string.IsNullOrEmpty(this.machinename))
                {
                    foreach (KeyValuePair<string, Connector> entry in _listconnt)
                    {
                        Connector _Cnn = entry.Value;
                        string MachineValue = string.Empty;
                        string Conntype = string.Empty;
                        if (_Cnn.Connecto == this.machinename)
                        {
                            MachineValue = _Cnn.FromData;
                            Conntype = "Input";
                            DataGridViewRow dr = new DataGridViewRow();
                            dgvSelectAll.Rows.Add(dr);
                            int  Index = dgvSelectAll.Rows.Count - 1;
                            dgvSelectAll.Rows[Index].Cells["txtBxMachineKey"].Value = MachineValue;
                            dgvSelectAll.Rows[Index].Cells["ConnectType"].Value = Conntype;

                        }
                        else if(_Cnn.FromData== this.machinename)
                        {
                            MachineValue = _Cnn.Connecto;
                            Conntype = "Output";
                            DataGridViewRow dr = new DataGridViewRow();
                            dgvSelectAll.Rows.Add(dr);
                            int  Index = dgvSelectAll.Rows.Count - 1;
                            dgvSelectAll.Rows[Index].Cells["txtBxMachineKey"].Value = MachineValue;
                            dgvSelectAll.Rows[Index].Cells["ConnectType"].Value = Conntype;

                        }
                        
                    }
                   
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (!IsHeaderCheckBoxClicked)
        //        RowCheckBoxClick((DataGridViewCheckBoxCell)dgvSelectAll[e.ColumnIndex, e.RowIndex]);
        //}

        //private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
        //        dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //}

        //private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        //{
        //    HeaderCheckBoxClick((CheckBox)sender);
        //}

        //private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Space)
        //        HeaderCheckBoxClick((CheckBox)sender);
        //}

        //private void dgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    if (e.RowIndex == -1 && e.ColumnIndex == 0)
        //        ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        //}

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();
            Point headerCellLocation = this.dgvSelectAll.GetCellDisplayRectangle(0, -1, true).Location;
            //Place the Header CheckBox in the Location of the Header Cell.
            HeaderCheckBox.Location = new Point(headerCellLocation.X + 2, headerCellLocation.Y + 4);
            HeaderCheckBox.BackColor = Color.White;
            HeaderCheckBox.Size = new Size(18, 18);
            //Assign Click event to the Header CheckBox.
            HeaderCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dgvSelectAll.Controls.Add(HeaderCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dgvSelectAll.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dgvSelectAll.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dgvSelectAll.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = HeaderCheckBox.Checked;
            }
        }

        //private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        //{
        //    //Get the column header cell bounds
        //    Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

        //    Point oPoint = new Point();

        //    oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
        //    oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

        //    //Change the location of the CheckBox to make it stay on the header
        //    HeaderCheckBox.Location = oPoint;
        //}

        //private void HeaderCheckBoxClick(CheckBox HCheckBox)
        //{
        //    IsHeaderCheckBoxClicked = true;

        //    foreach (DataGridViewRow Row in dgvSelectAll.Rows)
        //        ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect"]).Value = HCheckBox.Checked;

        //    dgvSelectAll.RefreshEdit();

        //    TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

        //    IsHeaderCheckBoxClicked = false;
        //}

        //private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        //{
        //    if (RCheckBox != null)
        //    {
        //        //Modifiy Counter;            
        //        if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
        //            TotalCheckedCheckBoxes++;
        //        else if (TotalCheckedCheckBoxes > 0)
        //            TotalCheckedCheckBoxes--;

        //        //Change state of the header CheckBox.
        //        if (TotalCheckedCheckBoxes < TotalCheckBoxes)
        //            HeaderCheckBox.Checked = false;
        //        else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
        //            HeaderCheckBox.Checked = true;
        //    }
        //}

        private void dgvSelectAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in dgvSelectAll.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                HeaderCheckBox.Checked = isChecked;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnApply1_Click(object sender, EventArgs e)
        {

        }
    }
}
