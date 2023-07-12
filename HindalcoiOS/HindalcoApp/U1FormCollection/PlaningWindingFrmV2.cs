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
    public partial class PlaningWindingFrm : XtraForm
    {
        DateTimePicker ActualStartDate = new DateTimePicker();

        public PlaningWindingFrm()
        {
            InitializeComponent();
            this.Text = "Winding Up Planing Info.";
            UpdateTextPosition();

        }

        private void PlaningWindingFrm_Load(object sender, EventArgs e)
        {
            Loaddata();
        }
        private void Loaddata()
        {
            DataTable dt = Resources.Instance.GetDataKey("Sp_FetchWindingPlaningInfo", "@userid", "@username", "@empcode",
                    GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
            DgvPlaningWinding.DataSource = dt;

            DataGridViewTextBoxColumn _datelast = new DataGridViewTextBoxColumn();
            _datelast.HeaderText = "DateOfLastMant";
            _datelast.Name = "datelast";
            _datelast.ReadOnly = false;
            _datelast.ValueType = typeof(string);
            DgvPlaningWinding.Columns.Add(_datelast);

            DataGridViewTextBoxColumn _ExpectTime = new DataGridViewTextBoxColumn();
            _ExpectTime.HeaderText = "Expect Time";
            _ExpectTime.Name = "expecttime";
            _ExpectTime.ReadOnly = false;
            _ExpectTime.ValueType = typeof(string);
            DgvPlaningWinding.Columns.Add(_ExpectTime);

            DataGridViewTextBoxColumn _ActualStartDate = new DataGridViewTextBoxColumn();
            _ActualStartDate.HeaderText = "ActualStartDate";
            _ActualStartDate.Name = "actualdate";
            _ActualStartDate.ReadOnly = false;
            DgvPlaningWinding.Columns.Add(_ActualStartDate);

            DataGridViewTextBoxColumn _ActualEndDate = new DataGridViewTextBoxColumn();
            _ActualEndDate.HeaderText = "ActualEndDate";
            _ActualEndDate.Name = "actualenddate";
            _ActualEndDate.ReadOnly = false;
            DgvPlaningWinding.Columns.Add(_ActualEndDate);

            GridSeeting();

        }
        private void AddDynamicColumn()
        {

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
                DgvPlaningWinding.BorderStyle = BorderStyle.Fixed3D;

                DgvPlaningWinding.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvPlaningWinding.AllowUserToResizeColumns = false;

                DgvPlaningWinding.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvPlaningWinding.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                //DgvBasic.DefaultCellStyle.SelectionForeColor = Color.AliceBlue;
                //DgvBasic.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvPlaningWinding.AlternatingRowsDefaultCellStyle.ForeColor = Color.Coral;
                DgvPlaningWinding.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvPlaningWinding.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvPlaning_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgvPlaning_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DgvPlaningWinding.Rows.Count > 0)
                {
                    string clmName = string.Empty;
                    if (e.RowIndex > -1 && e.ColumnIndex > -1)
                    {
                        DataGridViewCell cell = DgvPlaningWinding.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 12)
                        {
                            cell.ReadOnly = false;
                            DgvPlaningWinding.CurrentCell = cell;
                            DgvPlaningWinding.BeginEdit(true);
                            AddDateValue(DgvPlaningWinding.Columns[e.ColumnIndex].Name, e.ColumnIndex, e.RowIndex);
                        }
                        else
                        {
                            cell.ReadOnly = true;
                            DgvPlaningWinding.CurrentCell = cell;
                            DgvPlaningWinding.BeginEdit(false);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDateValue(string clmName, int ColumnIndex, int RowIndex)
        {
            switch (clmName)
            {
                case "actualdate":
                case "actualenddate":
                    DgvPlaningWinding.Controls.Add(ActualStartDate);
                    ActualStartDate.Visible = false;
                    ActualStartDate.Format = DateTimePickerFormat.Custom;
                    Rectangle _Rectangle = DgvPlaningWinding.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
                    _Rectangle.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    _Rectangle.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    ActualStartDate.CloseUp += new EventHandler(DateTimePickerClose);
                    ActualStartDate.TextChanged += new EventHandler(Set_date_TextChangedEvnts);
                    ActualStartDate.Visible = true;
                    break;
            }
        }
        private void DgvPlaning_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Set_date_TextChangedEvnts(object sender, EventArgs e)
        {
            try
            {
                DgvPlaningWinding.CurrentCell.Value = ActualStartDate.Text.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            ActualStartDate.Visible = false;
        }

        private void DgvPlaningWinding_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ActualStartDate.Visible = false;
        }

        private void DgvPlaningWinding_Scroll(object sender, ScrollEventArgs e)
        {
            ActualStartDate.Visible = false;
        }
    }
}
