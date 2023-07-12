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

namespace HindalcoiOS.PermitToWork
{
    public partial class ViewPermit : XtraForm
    {
        public ViewPermit()
        {
            InitializeComponent();

        }
        #region "variable declaration"       
        public static bool frmRedirect = false;
        public static DataTable peritDetailsData = new DataTable();
        #endregion 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable permitDetails = Resources.Instance.GetPermitDetails(txtpermitCode.Text);
                DBGridViewPermit.DataSource = permitDetails;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DBGridViewPermit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    // peritDetailsData = permitDetails;
                    peritDetailsData.Clear();
                    //  permitDetails.Clear();
                    AddColumnsTODT();
                    AddRowsToDT(e.RowIndex);
                    frmRedirect = true;
                    if (frmRedirect == true)
                    {
                        PermitToWork.CreatePermit newpermit = new CreatePermit();
                        newpermit.Show();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumnsTODT()
        {
            peritDetailsData.Columns.Add("permitCode");
            peritDetailsData.Columns.Add("RequestedTime");
            peritDetailsData.Columns.Add("RequestedBy");
            peritDetailsData.Columns.Add("durationFrom");
            peritDetailsData.Columns.Add("durationTo");
            // peritDetailsData.Columns.Add("permitCode");
            peritDetailsData.Columns.Add("areaName");
            peritDetailsData.Columns.Add("MachineTagNo");
            peritDetailsData.Columns.Add("AreaApproverId");
            peritDetailsData.Columns.Add("description");
            peritDetailsData.Columns.Add("WorkType");
            peritDetailsData.Columns.Add("capability");
            peritDetailsData.Columns.Add("permitType");
        }
        private void AddRowsToDT(int rowindex)
        {
            try
            {
                int colCount = DBGridViewPermit.Columns.Count;
                DataRow dr = peritDetailsData.NewRow();
                for (int i = 0; i < colCount - 1; i++)
                {
                    dr[i] = DBGridViewPermit.Rows[rowindex].Cells[i + 1].Value;
                }

                peritDetailsData.Rows.Add(dr);
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewPermitUpd_Load(object sender, EventArgs e)
        {

        }
    }
}
