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

namespace HindalcoiOS.Audit_frm
{
    public partial class AuditReportDisplay : XtraForm
    {
        public AuditReportDisplay()
        {
            this.Text = "Audit Report View";
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
        public string TypeReport
        {
            get; set;
        }
        public string AuditCode
        {
            get;
            set;
        }
        DataTable ReportLoad;
        DataTable CapaReport;
        private void DGVReportUpdate()
        {
            ReportLoad = new DataTable();
            ReportLoad.Columns.Add("Sr.No", typeof(string));
            ReportLoad.Columns.Add("Date&Time", typeof(DateTime));
            ReportLoad.Columns.Add("Area", typeof(string));
            ReportLoad.Columns.Add("Machinetag", typeof(string));
            ReportLoad.Columns.Add("Typeofobservation", typeof(string));
            ReportLoad.Columns.Add("Observation", typeof(string));
            ReportLoad.Columns.Add("Recommendation", typeof(string));
            ReportLoad.Columns.Add("Typeofrecommendation", typeof(string));
            ReportLoad.Columns.Add("RiskCategory", typeof(string));
            ReportLoad.Columns.Add("Auditor", typeof(string));
            ReportLoad.Columns.Add("Responsibility", typeof(string));
            ReportLoad.Columns.Add("Timeframe", typeof(string));
            ReportLoad.Columns.Add("Acceptance", typeof(string));
            DgvReport.DataSource = ReportLoad;
        }
        private void AddDynamicButton()
        {
            DataGridViewImageColumn imagebtn = new DataGridViewImageColumn();
            imagebtn.HeaderText = "LoadImage";
            imagebtn.Name = "btnImage";
            DgvReport.Columns.Insert(8, imagebtn);
        }
        private void AddCapaColumn()
        {
            CapaReport = new DataTable();
            CapaReport.Columns.Add("MachineTag", typeof(string));
            CapaReport.Columns["MachineTag"].ReadOnly = true;

            CapaReport.Columns.Add("Area", typeof(string));
            CapaReport.Columns["Area"].ReadOnly = true;

            CapaReport.Columns.Add("Observation", typeof(string));
            CapaReport.Columns["Observation"].ReadOnly = true;

            CapaReport.Columns.Add("Recommendation", typeof(string));
            CapaReport.Columns["Recommendation"].ReadOnly = true;

            CapaReport.Columns.Add("criticality", typeof(string));
            CapaReport.Columns["criticality"].ReadOnly = true;

            CapaReport.Columns.Add("ImmediateCause", typeof(string));
            CapaReport.Columns.Add("RootCause", typeof(string));
            CapaReport.Columns.Add("CorrectiveAction", typeof(string));
            CapaReport.Columns.Add("Reason", typeof(string));
            CapaReport.Columns.Add("PreventiveActions", typeof(string));
            CapaReport.Columns.Add("AddTeam", typeof(string));
            CapaReport.Columns.Add("Escalation", typeof(string));
            DGVCapa.DataSource = CapaReport;
        }
        private void AuditReportDisplay_Load(object sender, EventArgs e)
        {
            HideUAUCPagesHeader();
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            this.grpreport.Visible = false;
            this.Size = grpreport.Size;
            DGVReportUpdate();
            AddDynamicButton();
            AddCapaColumn();
            LoadAudtReport();
            // dataCalculation();
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
        private void dataCalculation()
        {
            if (this.grpreport.Visible)
            {
                this.Size = new Size(1159, this.grpreport.Height + this.grpreport.Height);
            }
            else
            {
                this.grpreport.Width = this.grpreport.Width - this.grpreport.Width;
            }
        }
        private void btnok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void LoadAudtReport()
        {
            //if (DgvReport.Rows.Count > 0)
            //    this.DgvReport.Rows.Clear();
            try
            {
                DataTable _loadAuditHistory = Resources.Instance.FetchAuditReport("Sp_FetchInternalAuditReport", "@tableType", "@AuditCode", "empCode", TypeReport, AuditCode, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_loadAuditHistory.Rows.Count > 0)
                {
                    for (int i = 0; i < _loadAuditHistory.Rows.Count; i++)
                    {
                        DataRow dr = ReportLoad.NewRow();
                        ReportLoad.Rows.Add(dr);
                        DgvReport.Rows[i].Cells["Sr.No"].Value = _loadAuditHistory.Rows[i]["SrNo"];
                        DgvReport.Rows[i].Cells["Date&Time"].Value = _loadAuditHistory.Rows[i]["Date&time"];
                        DgvReport.Rows[i].Cells["Observation"].Value = _loadAuditHistory.Rows[i]["Observation"];
                        DgvReport.Rows[i].Cells["Recommendation"].Value = _loadAuditHistory.Rows[i]["Recommendation"];
                        DgvReport.Rows[i].Cells["Auditor"].Value = _loadAuditHistory.Rows[i]["Auditor"];
                        DgvReport.Rows[i].Cells["Responsibility"].Value = _loadAuditHistory.Rows[i]["Responsibility"];
                        DgvReport.Rows[i].Cells["Timeframe"].Value = _loadAuditHistory.Rows[i]["Timeframe"];
                        DgvReport.Rows[i].Cells["Machinetag"].Value = _loadAuditHistory.Rows[i]["Machinetag"];
                        DgvReport.Rows[i].Cells["Typeofobservation"].Value = _loadAuditHistory.Rows[i]["Typeofobservation"];
                        DgvReport.Rows[i].Cells["Typeofrecommendation"].Value = _loadAuditHistory.Rows[i]["Typeofrecommendation"];
                        DgvReport.Rows[i].Cells["btnImage"].Value = GetImage((byte[])_loadAuditHistory.Rows[i]["Imagesave"]);
                        DgvReport.Rows[i].Cells["RiskCategory"].Value = _loadAuditHistory.Rows[i]["RiskCategory"];
                        DgvReport.Rows[i].Cells["Acceptance"].Value = _loadAuditHistory.Rows[i]["Acceptance"];
                        DgvReport.Rows[i].Cells["Area"].Value = _loadAuditHistory.Rows[i]["Area"];
                        if (!string.IsNullOrEmpty(_loadAuditHistory.Rows[i]["criticality"].ToString()) || !string.IsNullOrEmpty(_loadAuditHistory.Rows[i]["immediatecause"].ToString()) || !string.IsNullOrEmpty(_loadAuditHistory.Rows[i]["rootcause"].ToString()))
                        {
                            //XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Update CAPA Details First.\n Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //AuditCode = string.Empty;
                            //return;
                            // CAPA Data Insertion
                            DataRow capadr = CapaReport.NewRow();
                            capadr["MachineTag"] = _loadAuditHistory.Rows[i]["Machinetag"];
                            capadr["criticality"] = _loadAuditHistory.Rows[i]["criticality"];
                            capadr["Observation"] = _loadAuditHistory.Rows[i]["Observation"];
                            capadr["Recommendation"] = _loadAuditHistory.Rows[i]["Recommendation"];
                            capadr["ImmediateCause"] = _loadAuditHistory.Rows[i]["immediatecause"];
                            capadr["RootCause"] = _loadAuditHistory.Rows[i]["rootcause"];
                            capadr["CorrectiveAction"] = _loadAuditHistory.Rows[i]["correctiveaction"];
                            capadr["Reason"] = _loadAuditHistory.Rows[i]["Reason"];
                            capadr["PreventiveActions"] = _loadAuditHistory.Rows[i]["preventive_actions"];
                            capadr["AddTeam"] = _loadAuditHistory.Rows[i]["Add_team"];
                            capadr["Escalation"] = _loadAuditHistory.Rows[i]["escalation"];
                            capadr["Area"] = _loadAuditHistory.Rows[i]["Area"];
                            CapaReport.Rows.Add(capadr);
                        }

                    }
                    AuditCode = string.Empty;
                }
                //else
                //{
                //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "No Report Upload Against This AuditCode "+AuditCode, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    AuditCode = string.Empty;
                //    DialogResult = DialogResult.None;
                //    //return;
                //}
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }

        private void DgvReport_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex > -1)
            {
                if (DgvReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Image image = (Image)DgvReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    pictureBox1.Image = image;
                    this.grpreport.Visible = true;
                    dataCalculation();
                }
            }
        }
        private void DGVCapa_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btncapa_Click(object sender, EventArgs e)
        {
            controlAuditPages.SelectedIndex = 1;
        }
        private void btnAuditReportDetails_Click(object sender, EventArgs e)
        {
            controlAuditPages.SelectedIndex = 0;
        }

        private void DgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (e.ColumnIndex != 8)
                    {
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image = null;
                            this.grpreport.Visible = false;
                            this.Size = new Size(1159, this.grpreport.Height);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAuditRptDetail_Click(object sender, EventArgs e)
        {
            controlAuditPages.SelectedIndex = 0;
        }

        private void btnAuditRptCAPA_Click(object sender, EventArgs e)
        {
            controlAuditPages.SelectedIndex = 1;
        }
        private void HideUAUCPagesHeader()
        {
            controlAuditPages.Appearance = TabAppearance.FlatButtons;
            controlAuditPages.ItemSize = new Size(0, 1);
            controlAuditPages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in controlAuditPages.TabPages)
            {
                tab.Hide();// = "";
            }
        }

       
    }
}
