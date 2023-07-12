using HindalcoiOS.Class_Operation;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
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

namespace HindalcoiOS.Maintenance
{
    public partial class MaintenanceCloserResult : DevExpress.XtraEditors.XtraForm
    {

        private bool CAPAStatus = false;
        private string MachineNames = string.Empty;
        private string MachineTag = string.Empty;
        private string Acitivity = string.Empty;
        //public int EventReportId = 0;
        delegate void SetComboBoxCellTypeReult(int iRowIndex, string clmname, int iColumnIndex);
        bool bIsComboBox = false;
        public MaintenanceCloserResult(string machinename, string machinetag, string activity)
        {
            MachineNames = machinename;
            MachineTag = machinetag;
            Acitivity = activity;
            this.Text = "Maintenance Closer Result";
            InitializeComponent();
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
        private void MaintenanceCloserResult_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MachineNames) && string.IsNullOrEmpty(MachineTag) && !string.IsNullOrEmpty(Acitivity))
                {
                    GetCAPADAta();
                }
                else
                {
                    InsertRow();
                }
                DgvResult.Columns["Mtag"].ReadOnly = true;
                DgvResult.Columns["MachineName"].ReadOnly = true;
                DgvResult.Columns["objactivity"].ReadOnly = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCAPADAta()
        {
            DataTable EventReport = Resources.Instance.GetDataKey("Sp_FetchReportEventCAPA", "@eventRptId", int.Parse(Acitivity));
            if (EventReport.Rows.Count > 0)
            {
                btnClose.Enabled = false;
                btnClose.Visible = false;
                XtraTabPage xtraTabPage = null;
                if (XtraTbCtl.TabPages.Count == 1)
                {
                    xtraTabPage = XtraTbCtl.TabPages.Add("CAPA");
                    xtraTabPage.Name = "CAPA";
                    xtraTabPage.Tag = 1;
                    DgvCAPATab = new System.Windows.Forms.DataGridView();
                    DgvCAPATab.DataSource = GlobalDeclaration.MapColumnCAPA();
                    DgvCAPATab.AllowUserToResizeColumns = false;
                    DgvCAPATab.AllowUserToAddRows = false;
                    DgvCAPATab.AllowUserToOrderColumns = false;
                    DgvCAPATab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    DgvCAPATab.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    DgvCAPATab.Dock = DockStyle.Fill;
                    DgvCAPATab.ColumnHeadersHeight = 35;
                    DgvCAPATab.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGoldenrodYellow;
                    xtraTabPage.Controls.Add(DgvCAPATab);
                    //this.FontSet(false);
                    xtraTabPage.Show();
                    DgvCAPATab.Columns["eventReportingId"].Visible = false;
                    DgvCAPATab.Columns["IsReportingCAPA"].Visible = false;
                    DgvCAPATab.Columns["CAPAStatus"].Visible = false;
                    DgvCAPATab.ColumnHeadersVisible = true;

                }

                for (int i = 0; i < EventReport.Rows.Count; i++)
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    DgvResult.Rows.Add(dr);
                    int Index = DgvResult.Rows.Count - 1;
                    DgvResult.Rows[Index].Cells["objactivity"].Value = EventReport.Rows[i]["Activity"];
                    DgvResult.Rows[Index].Cells["Mtag"].Value = EventReport.Rows[i]["clmMachineTag"];
                    DgvResult.Rows[Index].Cells["MachineName"].Value = EventReport.Rows[i]["clmMachineName"];
                    DgvResult.Rows[Index].Cells["Element"].Value = EventReport.Rows[i]["Element"];
                    DgvResult.Rows[Index].Cells["Remark"].Value = EventReport.Rows[i]["Remark"];
                    DgvResult.Rows[Index].Cells["criticality"].Value = EventReport.Rows[i]["criticality"];
                    DgvResult.Rows[Index].Cells["Idrisk"].Value = EventReport.Rows[i]["Identified_Risk"];
                    string Value = EventReport.Rows[i]["responce"].ToString();
                    DgvResult.Rows[Index].Cells["responce"].Value = EventReport.Rows[i]["responce"];
                    if (Value == "Visual")
                    {
                        DgvResult.Columns["observationN"].Visible = false ? true : false;
                        ///DgvResult.Rows[e.RowIndex].Cells["observationV"].Value = true;
                        DgvResult.Columns["Rsult"].Visible = true;// false ? true : false;
                        DgvResult.Columns["Vmin"].Visible = false ? true : false;
                        DgvResult.Columns["Vmax"].Visible = false ? true : false;
                        DgvResult.Columns["Deviations"].Visible = false ? true : false;
                        DgvResult.Rows[Index].Cells["observationN"].Value = EventReport.Rows[i]["observationN"];
                        DgvResult.Rows[Index].Cells["observationN"].ReadOnly = true;
                        DgvResult.Rows[Index].Cells["Vmin"].Value = EventReport.Rows[i]["ValueMin"];
                        DgvResult.Rows[Index].Cells["Vmin"].ReadOnly = true;
                        DgvResult.Rows[Index].Cells["Vmax"].Value = EventReport.Rows[i]["ValueMax"];
                        DgvResult.Rows[Index].Cells["Vmax"].ReadOnly = true;
                        DgvResult.Rows[Index].Cells["Deviations"].Value = EventReport.Rows[i]["Deviations"];
                        DgvResult.Rows[Index].Cells["Deviations"].ReadOnly = true;
                        DgvResult.Rows[Index].Cells["Rsult"].Value = EventReport.Rows[i]["Rsult"];
                    }
                    else
                    {
                        DgvResult.Columns["observationV"].Visible = false ? true : false;
                        DgvResult.Columns["Rsult"].Visible = false;
                        DgvResult.Rows[Index].Cells["observationV"].Value = EventReport.Rows[i]["observationV"];
                        DgvResult.Rows[Index].Cells["observationV"].ReadOnly = true;
                        DgvResult.Rows[Index].Cells["Rsult"].Value = EventReport.Rows[i]["Rsult"];
                        DgvResult.Rows[Index].Cells["Rsult"].ReadOnly = true;
                        DgvResult.Columns["observationN"].Visible = true;
                        DgvResult.Columns["Vmin"].Visible = true;
                        DgvResult.Columns["Vmax"].Visible = true;
                        DgvResult.Columns["Deviations"].Visible = true;
                        DgvResult.Rows[Index].Cells["observationN"].ReadOnly = false;
                        DgvResult.Rows[Index].Cells["Vmin"].ReadOnly = false;
                        //DgvResult.Rows[e.RowIndex].Cells["Vmax"].ReadOnly = false;
                        DgvResult.Rows[Index].Cells["Deviations"].ReadOnly = false;
                        DgvResult.Columns["btnActionable"].Visible = false;
                        DgvResult.Columns["btnActionable"].ReadOnly = true; ;
                    }

                    DataRow[] Update = GlobalDeclaration.CAPAtbl.Select("MachineTag='" + EventReport.Rows[i]["clmMachineTag"] + "' and ObjRslt='" + EventReport.Rows[i]["Rsult"] + "' and Elements='" + EventReport.Rows[i]["Element"] + "'");
                    if (Update.Length <= 0)
                    {
                        DataRow drows = GlobalDeclaration.CAPAtbl.NewRow();
                        drows["MachineTag"] = EventReport.Rows[i]["clmMachineTag"];// futher it should be chnage when CAD Selected Entities Find 
                        drows["MachineName"] = EventReport.Rows[i]["clmMachineName"]; ;//// futher it should be chnage when CAD Selected Entities Find 
                        drows["objectitem"] = EventReport.Rows[i]["Activity"].ToString();
                        drows["ObjObserv"] = EventReport.Rows[i]["ObjObserv"].ToString();
                        drows["ObjRslt"] = EventReport.Rows[i]["Rsult"].ToString();
                        drows["Criticality"] = EventReport.Rows[i]["criticality"].ToString();
                        drows["Elements"] = EventReport.Rows[i]["Element"];
                        drows["IsReportingCAPA"] = EventReport.Rows[i]["IsReportingCAPA"];
                        drows["eventReportingId"] = EventReport.Rows[i]["eventReportingId"];
                        drows["CAPAStatus"] = EventReport.Rows[i]["CAPAStatus"];
                        drows["immediatecause"] = EventReport.Rows[i]["Immdcause"];
                        drows["RootCause"] = EventReport.Rows[i]["RootCause"];
                        drows["CorrectiveAction"] = EventReport.Rows[i]["CorrectiveAction"];
                        drows["Reason"] = EventReport.Rows[i]["Reason"];
                        drows["PreventiveAct"] = EventReport.Rows[i]["PreventiveAct"];
                        drows["Responsibility0"] = EventReport.Rows[i]["Responsibility0"];
                        drows["Responsibility1"] = EventReport.Rows[i]["Responsibility1"];
                        drows["Escalation"] = EventReport.Rows[i]["Escalation"];
                        drows["UserName"] = GlobalDeclaration._holdInfo[0].UserName;
                        drows["UserId"] = GlobalDeclaration._holdInfo[0].UserId;
                        drows["EmpCode"] = GlobalDeclaration._holdInfo[0].EmpCode;
                        GlobalDeclaration.CAPAtbl.Columns["UserName"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserId"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["EmpCode"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Rows.Add(drows);
                        DgvCAPATab.Columns["eventReportingId"].Visible = false;
                        DgvCAPATab.Columns["IsReportingCAPA"].Visible = false;
                        DgvCAPATab.Columns["CAPAStatus"].Visible = false;
                    }
                }
                DgvResult.ReadOnly = true;
                CAPAStatus = true;
                //DgvCAPATab.ReadOnly = true;                            
            }
        }
        public void InsertRow()
        {
            if (!string.IsNullOrEmpty(MachineTag) && !string.IsNullOrEmpty(MachineNames) && !string.IsNullOrEmpty(Acitivity))
            {
                DataGridViewRow drresult = new DataGridViewRow();
                DgvResult.Rows.Insert(0, drresult);
                DgvResult.Rows[0].Cells["Mtag"].Value = MachineTag;
                DgvResult.Rows[0].Cells["MachineName"].Value = MachineNames;
                DgvResult.Rows[0].Cells["objactivity"].Value = this.Acitivity;
            }
        }
        private System.Windows.Forms.DataGridView DgvCAPATab = null;
        //private Bunifu.Framework.UI.BunifuCustomDataGrid DgvCAPATab = null;
        private void dgventry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (DgvResult.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 14)
                    {
                        DgvResult.Rows[e.RowIndex].Selected = true;
                        if (DgvResult.Rows[e.RowIndex].Cells["Rsult"].Value.ToString() == "Not Ok" || DgvResult.Rows[e.RowIndex].Cells["Deviations"].Value.ToString() == "Not In Range")
                        {
                            XtraTabPage xtraTabPage = null;
                            if (XtraTbCtl.TabPages.Count == 1)
                            {
                                xtraTabPage = XtraTbCtl.TabPages.Add("CAPA");
                                xtraTabPage.Name = "CAPA";
                                xtraTabPage.Text = "CAPA Result";
                                xtraTabPage.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
                                xtraTabPage.TooltipIconType = DevExpress.Utils.ToolTipIconType.Information;
                                xtraTabPage.Tag = 1;
                                DgvCAPATab = new System.Windows.Forms.DataGridView();
                                DgvCAPATab.DataSource = GlobalDeclaration.MapColumnCAPA();
                                DgvCAPATab.Columns["eventReportingId"].Visible = false;
                                DgvCAPATab.Columns["IsReportingCAPA"].Visible = false;
                                DgvCAPATab.Columns["CAPAStatus"].Visible = false;
                                DgvCAPATab.AllowUserToResizeColumns = false;
                                DgvCAPATab.AllowUserToAddRows = false;
                                DgvCAPATab.AllowUserToOrderColumns = false;
                                DgvCAPATab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                                DgvCAPATab.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                                DgvCAPATab.Dock = DockStyle.Fill;
                                DgvCAPATab.ColumnHeadersHeight = 29;
                                xtraTabPage.Controls.Add(DgvCAPATab);
                                // DgvCAPATab.CellEndEdit += DgvCAPATab_CellEndEdit;
                                this.FontSet(false);
                                xtraTabPage.Show();

                            }
                            else
                            {
                                //xtraTabPage.Show();
                                XtraTbCtl.TabPages[0].PageEnabled = true;
                                XtraTbCtl.TabPages[0].Show();

                            }
                            if (!CAPAStatus == true)
                                FillCAPAGrid();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true }, Ex.StackTrace, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVResult_CellValueChnaged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (int.Parse(XtraTbCtl.SelectedTabPage.Tag.ToString()) == 0)
                {
                    if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                    {
                        string Value = DgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if (Value == "Visual")
                        {
                            //if(DgvResult.Rows[e.RowIndex].Cells["observationN"].Value)
                            DgvResult.Columns["observationN"].Visible = false ? true : false;
                            ///DgvResult.Rows[e.RowIndex].Cells["observationV"].Value = true;
                            DgvResult.Columns["Rsult"].Visible = true;// false ? true : false;
                            DgvResult.Columns["Vmin"].Visible = false ? true : false;
                            DgvResult.Columns["Vmax"].Visible = false ? true : false;
                            DgvResult.Columns["Deviations"].Visible = false ? true : false;
                            DgvResult.Rows[e.RowIndex].Cells["observationN"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["observationN"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Vmin"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Vmin"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Vmax"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Vmax"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Deviations"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Deviations"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Rsult"].Value = null;
                        }
                        else if (Value == "Numeric")
                        {
                            DgvResult.Columns["observationV"].Visible = false ? true : false;
                            DgvResult.Columns["Rsult"].Visible = false;
                            DgvResult.Rows[e.RowIndex].Cells["observationV"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["observationV"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Rsult"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Rsult"].ReadOnly = true;

                            DgvResult.Columns["observationN"].Visible = true;
                            DgvResult.Columns["Vmin"].Visible = true;
                            DgvResult.Columns["Vmax"].Visible = true;
                            DgvResult.Columns["Deviations"].Visible = true;
                            DgvResult.Rows[e.RowIndex].Cells["observationN"].ReadOnly = false;
                            DgvResult.Rows[e.RowIndex].Cells["Vmin"].ReadOnly = false;
                            //DgvResult.Rows[e.RowIndex].Cells["Vmax"].ReadOnly = false;
                            DgvResult.Rows[e.RowIndex].Cells["Deviations"].ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvResult_cellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellTypeReult objChangeCellTypeResult = new SetComboBoxCellTypeReult(ChangeCellToComboBoxResult);
                if (e.ColumnIndex == this.DgvResult.Columns["responce"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "responce", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["Rsult"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Rsult", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["Deviations"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Deviations", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["criticality"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "criticality", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBoxResult(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "responce")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvResponce = new DataGridViewComboBoxCell();
                        dgvResponce.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Visual", "Numeric" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvResponce.DataSource = RiskDt;
                        dgvResponce.ValueMember = "Name";
                        dgvResponce.DisplayMember = "Name";
                        DgvResult[iColumnIndex, iRowIndex] = dgvResponce;
                        dgvResponce.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Rsult")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvResult = new DataGridViewComboBoxCell();
                        dgvResult.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Ok", "Not Ok" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvResult.DataSource = RiskDt;
                        dgvResult.ValueMember = "Name";
                        dgvResult.DisplayMember = "Name";
                        DgvResult[iColumnIndex, iRowIndex] = dgvResult;
                        dgvResult.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Deviations")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvResultDeviation = new DataGridViewComboBoxCell();
                        dgvResultDeviation.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "InRange", "Not In Range" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvResultDeviation.DataSource = RiskDt;
                        dgvResultDeviation.ValueMember = "Name";
                        dgvResultDeviation.DisplayMember = "Name";
                        DgvResult[iColumnIndex, iRowIndex] = dgvResultDeviation;
                        dgvResultDeviation.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "criticality")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvcriti = new DataGridViewComboBoxCell();
                        dgvcriti.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "High", "Low", "Medium" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvcriti.DataSource = RiskDt;
                        dgvcriti.ValueMember = "Name";
                        dgvcriti.DisplayMember = "Name";
                        DgvResult[iColumnIndex, iRowIndex] = dgvcriti;
                        dgvcriti.Dispose();
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FontSet(bool is_New)
        {
            using (Font font = new Font("Tahoma", 7.8F))
            {

                for (int i = 0; i < DgvCAPATab.Columns.Count - 1; i++)
                {
                    DgvCAPATab.Columns[i].DefaultCellStyle.Font = font;
                }
                //DgvCAPATab.HeaderBgColor = System.Drawing.Color.SeaGreen;
                //DgvCAPATab.HeaderForeColor = System.Drawing.Color.SeaGreen;
                DgvCAPATab.ForeColor = System.Drawing.Color.SeaGreen;
                DgvCAPATab.AutoResizeColumns();
                DgvCAPATab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }


        }
        private void FillCAPAGrid()
        {
            try
            {
                if (DgvResult.SelectedRows.Count > 0)
                {
                    string machintag = DgvResult.SelectedRows[0].Cells["Mtag"].Value.ToString();
                    string Machinename = MachineNames;
                    string Rslt = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                    string Elments = DgvResult.SelectedRows[0].Cells["Element"].Value.ToString();
                    DataRow[] Update = GlobalDeclaration.CAPAtbl.Select("MachineTag='" + machintag + "' and ObjRslt='" + Rslt + "' and Elements='" + Elments + "'");
                    if (Update.Length > 0)
                    {
                        GlobalDeclaration.CAPAtbl.Columns["objectitem"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["ObjObserv"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["ObjRslt"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["Criticality"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["Elements"].ReadOnly = false;
                        foreach (DataRow row in Update)
                        {
                            row["objectitem"] = DgvResult.SelectedRows[0].Cells["objactivity"].Value.ToString();
                            row["ObjObserv"] = DgvResult.SelectedRows[0].Cells["observationV"].Value.ToString();
                            row["ObjRslt"] = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                            row["Criticality"] = DgvResult.SelectedRows[0].Cells["criticality"].Value.ToString();
                            row["Elements"] = DgvResult.SelectedRows[0].Cells["Element"].Value.ToString();
                        }
                        GlobalDeclaration.CAPAtbl.Columns["objectitem"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["ObjObserv"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["ObjRslt"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["Criticality"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["Elements"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserName"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserId"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["EmpCode"].ReadOnly = true;

                    }
                    else
                    {
                        DataRow dr = GlobalDeclaration.CAPAtbl.NewRow();
                        dr["MachineTag"] = machintag;// futher it should be chnage when CAD Selected Entities Find 
                        dr["MachineName"] = Machinename;//// futher it should be chnage when CAD Selected Entities Find 
                        dr["objectitem"] = DgvResult.SelectedRows[0].Cells["objactivity"].Value.ToString();
                        dr["ObjObserv"] = DgvResult.SelectedRows[0].Cells["observationV"].Value.ToString();
                        dr["ObjRslt"] = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                        dr["Criticality"] = DgvResult.SelectedRows[0].Cells["criticality"].Value.ToString();
                        dr["Elements"] = Elments;
                        dr["UserName"] = GlobalDeclaration._holdInfo[0].UserName;
                        dr["UserId"] = GlobalDeclaration._holdInfo[0].UserId;
                        dr["EmpCode"] = GlobalDeclaration._holdInfo[0].EmpCode;
                        if (GlobalDeclaration.EventReportId > 0)
                        {
                            dr["IsReportingCAPA"] = GlobalDeclaration.EventReportId;
                            dr["eventReportingId"] = GlobalDeclaration.EventReportId;
                            dr["CAPAStatus"] = "ReportEvent";
                        }
                        else
                        {
                            dr["IsReportingCAPA"] = 0;
                            dr["eventReportingId"] = 0;
                            dr["CAPAStatus"] = "Closed";
                        }
                        GlobalDeclaration.CAPAtbl.Columns["UserName"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserId"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["EmpCode"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Rows.Add(dr);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {

                if (DgvResult.SelectedRows.Count > 0)
                {
                    AuditReportInsertion _audit = new AuditReportInsertion();
                    string jj = DgvResult.SelectedRows[0].Cells["Mtag"].Value.ToString();
                    if (GlobalDeclaration.EventReportId > 0)
                    {
                        CAPAInsertion("ReportEvent");// Calling Process from FrmGenericReport
                    }
                    else
                    {
                        int Status = _audit.InsertFreeZPlanData(false, DgvResult);
                        if (Status > 0)
                        {
                            CAPAInsertion("Closed");
                        }
                        else
                        {
                            XtraMessageBox.Show("Still not Closed Freez Data.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please Select Any Row.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CAPAInsertion(string CalValue)
        {
            int Status = 0;
            string cmdMaintemnceResult = @"insert into MaintenanceResultData(Activity,responce,Element,ValueMin,ValueMax,observationV,Rsult,observationN,Deviations,Remark,criticality,Identified_Risk,MaintenaceMachineList,UserName,UserId,EmpCode,FreezStatusRslt) values";
            string query = string.Empty;
            int looprn = 0;
            foreach (DataGridViewRow rw in this.DgvResult.SelectedRows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {

                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill All Result Tab Details Entry..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            looprn = DgvResult.Rows.Count;
            for (int i = 0; i < looprn; i++)
            {
                query = query + "('" + DgvResult.SelectedRows[0].Cells["objactivity"].Value.ToString() + "','"
                   + DgvResult.SelectedRows[0].Cells["responce"].Value.ToString() + "','" + DgvResult.SelectedRows[0].Cells["Element"].Value.ToString() + "','"
                   + DgvResult.SelectedRows[0].Cells["Vmin"].Value.ToString() + "','" + DgvResult.SelectedRows[0].Cells["Vmax"].Value.ToString() + "','"
                   + DgvResult.SelectedRows[0].Cells["observationV"].Value.ToString() + "','" + DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString() + "','"
                   + DgvResult.SelectedRows[0].Cells["observationN"].Value.ToString() + "','" + DgvResult.SelectedRows[0].Cells["Deviations"].Value.ToString() + "','"
                   + DgvResult.SelectedRows[0].Cells["Remark"].Value.ToString() + "','" + DgvResult.SelectedRows[0].Cells["criticality"].Value.ToString() + "','"
                    + DgvResult.SelectedRows[0].Cells["Idrisk"].Value.ToString() + "','" + DgvResult.SelectedRows[0].Cells["Mtag"].Value.ToString() + "','"
                    + GlobalDeclaration._holdInfo[0].UserName + "','" + GlobalDeclaration._holdInfo[0].UserId + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" + CalValue + "'),";
            }
            if (!string.IsNullOrEmpty(query))
            {
                cmdMaintemnceResult = cmdMaintemnceResult + query.Remove(query.Length - 1, 1);
                Status = Resources.Instance.SaveMaintenenceData(cmdMaintemnceResult);
                if (Status > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Result Tab Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, " Error in Result Tab Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (DgvCAPATab != null)
            {
                if (DgvCAPATab.Rows.Count > 0)
                {
                    Status = Resources.Instance.SaveMainTenenceData("Sp_InsertCAPADATA", "@CAPAtbl", GlobalDeclaration.CAPAtbl);
                    if (Status > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
