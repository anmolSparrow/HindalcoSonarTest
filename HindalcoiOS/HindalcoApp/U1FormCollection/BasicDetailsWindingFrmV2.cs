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
    public partial class BasicDetailsWindingFrm : XtraForm
    {
        public BasicDetailsWindingFrm()
        {
            InitializeComponent();
            this.Text = "Basic Details";
            UpdateTextPosition();
        }
        private void BindDynamicClm()
        {
            DataTable dt = Resources.Instance.GetDataKey("Sp_FetchWindingBasicDetails", "@userid", "@username", "@empcode",
                    GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
            DgvBasic.DataSource = dt;

            DataGridViewTextBoxColumn _briefDesc = new DataGridViewTextBoxColumn();
            _briefDesc.HeaderText = "Activity details";
            _briefDesc.Name = "actvity";
            _briefDesc.ReadOnly = false;
            _briefDesc.ValueType = typeof(string);
            DgvBasic.Columns.Insert(4, _briefDesc);

            DataGridViewTextBoxColumn _priovity = new DataGridViewTextBoxColumn();
            _priovity.HeaderText = "Priovity";
            _priovity.Name = "Prvty";
            _priovity.ReadOnly = false;
            _priovity.ValueType = typeof(string);
            DgvBasic.Columns.Add(_priovity);

            DataGridViewTextBoxColumn _ActualRedaing = new DataGridViewTextBoxColumn();
            _ActualRedaing.HeaderText = "Actual Meter reading";
            _ActualRedaing.Name = "acvityreading";
            _ActualRedaing.ReadOnly = false;
            _ActualRedaing.ValueType = typeof(string);
            DgvBasic.Columns.Add(_ActualRedaing);


        }
        private void GridSeeting()
        {
            try
            {
                DgvBasic.BorderStyle = BorderStyle.Fixed3D;

                DgvBasic.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvBasic.AllowUserToResizeColumns = false;

                DgvBasic.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvBasic.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                //DgvBasic.DefaultCellStyle.SelectionForeColor = Color.AliceBlue;
                //DgvBasic.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvBasic.AlternatingRowsDefaultCellStyle.ForeColor = Color.Coral;
                DgvBasic.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvBasic.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

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
        private void BasicDetailsWindingFrm_Load(object sender, EventArgs e)
        {
            BindDynamicClm();
            GridSeeting();

        }

        private void DgvBasic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvBasic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    DataGridViewCell cell = DgvBasic.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (e.ColumnIndex == 4 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
                    {
                        cell.ReadOnly = false;
                        DgvBasic.CurrentCell = cell;
                        DgvBasic.BeginEdit(true);
                    }
                    else
                    {
                        cell.ReadOnly = true;
                        DgvBasic.CurrentCell = cell;
                        DgvBasic.BeginEdit(false);
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvBasic_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
