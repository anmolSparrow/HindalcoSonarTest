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
    public partial class ViewDetailsFrm : XtraForm
    {
        public ViewDetailsFrm()
        {
            InitializeComponent();
            this.Text = "View in Brief";
            UpdateTextPosition();
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
        private void LoadData()
        {
            DataTable dt = Resources.Instance.GetDataKey("Sp_FetchRawData", "@userid", "@username", "@empcode",
                    GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
            DgvView.DataSource = dt;
        }
        private void GridSeeting()
        {
            try
            {
                DgvView.BorderStyle = BorderStyle.Fixed3D;

                DgvView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvView.AllowUserToResizeColumns = false;

                DgvView.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvView.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvView.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvView.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvView.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ViewDetailsFrm_Load(object sender, EventArgs e)
        {
            LoadData();
            GridSeeting();
        }

    }
}
