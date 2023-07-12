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
    public partial class TrainingDashBoardFrm : XtraForm
    {
        public TrainingDashBoardFrm()
        {
            InitializeComponent();
            this.Text = "Training DashBoard Status";
            UpdateTextPosition();
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 4) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 4);
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

        private void TrainingDashBoardFrm_Load(object sender, EventArgs e)
        {
            Load_Data();
            GridSeeting();
        }


        private void GridSeeting()
        {
            try
            {
                DgvStatus.BorderStyle = BorderStyle.Fixed3D;
                DgvStatus.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvStatus.AllowUserToResizeColumns = false;
                DgvStatus.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                DgvStatus.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                // DgvStatus.RowHeadersVisible = false;
                DgvStatus.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvStatus.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvStatus.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvStatus.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                DgvStatus.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.ReadOnly = true);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Load_Data()
        {
            DataTable dt = Resources.Instance.GetDataKey("Sp_FetchDashBoardStatus");
            DgvStatus.DataSource = dt;
        }

    }
}
