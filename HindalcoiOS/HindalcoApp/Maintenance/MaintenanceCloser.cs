using HindalcoiOS.Class_Operation;
using HindalcoiOS.Maintenance;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SparrowRMS;

namespace HindalcoiOS.U1FormCollection
{
    public partial class MaintenanceCloser : DevExpress.XtraEditors.XtraForm
    {
        public MaintenanceCloser()
        {
            InitializeComponent();
            this.Text = "Maintenance Closer";
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
        private void MaintenanceCloser_Load(object sender, EventArgs e)
        {
            GetFreeData();
        }
        public void GetFreeData()
        {
            try
            {
                DataTable dt = Resources.Instance.GetDataKey("Sp_GetFreezedData");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvClosed.Rows.Add(dr);
                        int rowidex = this.DgvClosed.Rows.Count - 1;
                        DgvClosed.Rows[rowidex].Cells["Priority"].Value = dt.Rows[i]["PriorityUp"].ToString();
                        DgvClosed.Rows[rowidex].Cells["MachineTag"].Value = dt.Rows[i]["MachineTag"].ToString();
                        DgvClosed.Rows[rowidex].Cells["MachineName"].Value = dt.Rows[i]["MachineName"].ToString();
                        DgvClosed.Rows[rowidex].Cells["Frequency"].Value = dt.Rows[i]["Frequency"].ToString();
                        DgvClosed.Rows[rowidex].Cells["ShutDown"].Value = dt.Rows[i]["ShutDownReq"].ToString();
                        DgvClosed.Rows[rowidex].Cells["Resource"].Value = dt.Rows[i]["Resource"].ToString();
                        DgvClosed.Rows[rowidex].Cells["Activity"].Value = dt.Rows[i]["Activity"].ToString();
                        DgvClosed.Rows[rowidex].Cells["FreezDate"].Value = dt.Rows[i]["Setdate"].ToString();
                        if (Convert.ToDateTime(DgvClosed.Rows[rowidex].Cells["FreezDate"].Value) == DateTime.Now.Date)
                        {
                            Btnpostpont.Text = "Postpone";

                        }
                        else
                        {
                            Btnpostpont.Text = "Prepone";
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnClosed_Click(object sender, EventArgs e)
        {
            try
            {
                SparrowRMSControl.SparrowControl.SparrowButton btn = sender as SparrowRMSControl.SparrowControl.SparrowButton;
                if (int.Parse(btn.Tag.ToString()) == 2)
                {
                    if (DgvClosed.SelectedRows.Count > 0)
                    {
                        string MachineTag = DgvClosed.SelectedRows[0].Cells["MachineTag"].Value.ToString();
                        string MachineName = DgvClosed.SelectedRows[0].Cells["MachineName"].Value.ToString();
                        string Activity = DgvClosed.SelectedRows[0].Cells["Activity"].Value.ToString();
                        MaintenanceCloserResult Rslt = new MaintenanceCloserResult(MachineName, MachineTag, Activity);
                        if (Rslt.ShowDialog() == DialogResult.OK)
                        {
                            DgvClosed.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Red;
                            DgvClosed.Rows.RemoveAt(DgvClosed.SelectedRows[0].Index);
                            Rslt.Close();
                            Rslt.Dispose();
                        }
                        else
                        {
                            Rslt.Close();
                            Rslt.Dispose();
                        }
                    }
                }
                else if (int.Parse(btn.Tag.ToString()) == 1 || int.Parse(this.Btnpostpont.Tag.ToString()) == 0)
                {
                    PopUpAction popUpAction = new PopUpAction();
                    if (int.Parse(btn.Tag.ToString()) == 1)
                    {
                        popUpAction.DateStatus = "Preponed";
                    }
                    else
                    {
                        popUpAction.DateStatus = "Posponed";
                    }
                    if (popUpAction.ShowDialog() == DialogResult.OK)
                    {                     
                        DateTime dateTime = popUpAction.btndatePiker.Value;
                        if (DgvClosed.Rows.Count > 0)
                        {
                            DgvClosed.SelectedRows[0].Cells["FreezDate"].Value = dateTime;
                            DgvClosed.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Yellow;
                            string value = DgvClosed.SelectedRows[0].Cells["MachineTag"].Value.ToString() + "~" + DgvClosed.SelectedRows[0].Cells["MachineName"].Value.ToString() + "~"
                                + DgvClosed.SelectedRows[0].Cells["Activity"].Value.ToString() + "~" + dateTime + "~" + GlobalDeclaration._holdInfo[0].UserId + "~" +
                                GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].EmpCode + "~" + "Close" + "~" + "";
                            int Statu = Resources.Instance.UpdateFreezPlan("Sp_UpdateFreezPlan", value);
                        }
                        popUpAction.DateStatus = string.Empty;
                        popUpAction.Close();
                        popUpAction.Dispose();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
            
        }

        private void DgvClosed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToDateTime(DgvClosed.SelectedRows[0].Cells["FreezDate"].Value) == DateTime.Now.Date)
            {
                Btnpostpont.Text = "Postpone";

            }
            else
            {
                Btnpostpont.Text = "Prepone";
            }
        }
    }
}
