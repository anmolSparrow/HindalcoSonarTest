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

    public partial class FreezeStatus : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex);
        public FreezeStatus()
        {
            InitializeComponent();

        }

        private void FreezeStatus_Load(object sender, EventArgs e)
        {

            LoadFreezPlanStaus();
            // Adjust the row heights so that all content is visible.
            DgvStatus.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            LoadGridSetting();

        }
        private void LoadGridSetting()
        {
            DgvStatus.BorderStyle = BorderStyle.Fixed3D;
            //  DgvStatus.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DgvStatus.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DgvStatus.AllowUserToResizeColumns = false;
            DgvStatus.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvStatus.AllowUserToResizeRows = false;
            DgvStatus.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;


            // Set the selection background color for all the cells.
            DgvStatus.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            DgvStatus.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            //DgvStatus.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows. 
            // DgvStatus.RowsDefaultCellStyle.BackColor = Color.LightGray;
            DgvStatus.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            // Dgv Column sorting
            DgvStatus.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

        }
        DataTable StatusCode;
        private void LoadFreezPlanStaus()
        {
            DataTable dt = Resources.Instance.GetDataKey("SP_FetchMaintenaceU1Status");
            StatusCode = new DataTable();
            StatusCode = Resources.Instance.GetDataKey("Sp_FetchFreezStatus");
            if (dt.Rows.Count > 0)
            {
                DgvStatus.DataSource = dt;

                DataGridViewTextBoxColumn _Status = new DataGridViewTextBoxColumn();
                _Status.HeaderText = "Status";
                _Status.Name = "Sts";
                _Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DgvStatus.Columns.Add(_Status);
                DgvStatus.Columns["Sts"].Width = 100;
            }
        }


        private void DgvStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.ColumnIndex == DgvStatus.Columns[DgvStatus.CurrentCell.ColumnIndex].Index)
                {
                    DgvStatus.ReadOnly = false;
                    //DgvStatus.Rows[e.RowIndex].Cells[DgvStatus.CurrentCell.ColumnIndex].ReadOnly = false;
                }
            }
        }

        bool bIsComboBox;
        private void DgvStatus_Enter(object sender, DataGridViewCellEventArgs e)
        {
            SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
            if (this.DgvStatus.Columns["Sts"] != null)
            {
                if (e.ColumnIndex == this.DgvStatus.Columns["Sts"].Index)
                {
                    this.DgvStatus.BeginInvoke(objChangeCellType, e.RowIndex);
                    bIsComboBox = false;
                }
            }
        }

        private void ChangeCellToComboBox(int iRowIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                    dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    dgComboCell.DataSource = StatusCode;
                    dgComboCell.ValueMember = "Code";
                    dgComboCell.DisplayMember = "Code";
                    dgComboCell.DropDownWidth = 210;
                    DgvStatus.Rows[iRowIndex].Cells[DgvStatus.CurrentCell.ColumnIndex] = dgComboCell;
                    bIsComboBox = true;
                    DgvStatus.ReadOnly = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.DgvStatus.Columns["Sts"] != null)
            {
                if (e.ColumnIndex == DgvStatus.Columns["Sts"].Index && e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "Not Attended.":
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            //e.CellStyle.SelectionForeColor = Color.Red;
                            //e.CellStyle.ForeColor = Color.Red;
                            break;
                        case "Completed":
                            //e.CellStyle.SelectionForeColor = Color.White;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "In Progress":
                            // e.CellStyle.SelectionForeColor = Color.LightGreen;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.LightGreen;
                            break;
                        case "Due in Next 7 Days":
                            // e.CellStyle.SelectionForeColor = Color.Yellow;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
                            break;
                        case "Due in Next 14 Days":
                            //e.CellStyle.SelectionForeColor = Color.Lime;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Lime;
                            break;
                        case "Due in Next 21 Days":
                            // e.CellStyle.SelectionForeColor = Color.LightSeaGreen;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.LightSeaGreen;
                            break;
                        case "Due in Next 30 Days":
                            // e.CellStyle.SelectionForeColor = Color.DeepSkyBlue;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DeepSkyBlue;
                            break;
                        case "Ongoing and Deadline Passed":
                            // e.CellStyle.SelectionForeColor = Color.OrangeRed;
                            this.DgvStatus.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.OrangeRed;
                            break;
                    }
                }
            }
        }
        private void FreezeStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            //this.Dispose();
        }
    }
}
