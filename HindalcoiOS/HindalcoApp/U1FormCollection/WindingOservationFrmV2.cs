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
    public partial class WindingOservationFrm : XtraForm
    {
        public WindingOservationFrm()
        {
            InitializeComponent();
            this.Text = "Winding Observation Details";
            UpdateTextPosition();
        }

        private void WindingOservationFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            DataTable Loaddt = Resources.Instance.GetDataKey("Sp_FetchObserBrkInfo", "@userid", "@username", "@empcode",
                    GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
            DgvObser.DataSource = Loaddt;
            DynamicColumAdd();
        }
        private void DynamicColumAdd()
        {
            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.Name = "sendbtn";
            btnclm.HeaderText = "Send";
            btnclm.Text = "Send For Preview";
            btnclm.UseColumnTextForButtonValue = true;
            DgvObser.Columns.Add(btnclm);
            GridSeeting();
        }
        private void GridSeeting()
        {
            try
            {
                DgvObser.BorderStyle = BorderStyle.Fixed3D;

                DgvObser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvObser.AllowUserToResizeColumns = false;

                DgvObser.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvObser.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvObser.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvObser.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvObser.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvObser.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void DgvObser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.DgvObser.Rows[e.RowIndex].Cells["sendbtn"].ColumnIndex)
                {
                    DataGridViewButtonCell dgbtn = null;
                    dgbtn = (DataGridViewButtonCell)(DgvObser.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                    if (dgbtn.Value.ToString() == "Send For Preview")
                    {
                        dgbtn.UseColumnTextForButtonValue = false;
                        DgvObser.CurrentCell = DgvObser.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        DgvObser.CurrentCell.ReadOnly = false;
                        dgbtn.Value = "Send Done";
                        DgvObser.CurrentCell.ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Selected = true;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvObser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    DataGridViewCell cell = DgvObser.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6))
                    {
                        cell.ReadOnly = false;
                        DgvObser.CurrentCell = cell;
                        DgvObser.BeginEdit(true);
                    }
                    else
                    {
                        cell.ReadOnly = true;
                        DgvObser.CurrentCell = cell;
                        DgvObser.BeginEdit(false);
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
