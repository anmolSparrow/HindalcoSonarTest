﻿using CADImport;
using DevExpress.XtraEditors;
using ExcelDataReader;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Audit_frm
{
    public partial class AuditReport : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        delegate void SetComboBoxCellTypeCAPA(int iRowIndex, string clmname, int iColumnIndex);
        public AuditReport()
        {
            this.Text = " Audit Report Presentation";
            InitializeComponent();
            //UpdateTextPosition();
        }

        DataTable MapColumnCAPA = null;
        DataTable MachineDt = new DataTable();
        DataTable EmployeeMaster = new DataTable();
        private bool bIsComboBox;
        bool _IsFirsttime;
        private List<string> _SheetNameHold = new List<string>();
        private DataTable BidMapCAPAColm()
        {
            MapColumnCAPA = new DataTable();
            MapColumnCAPA.Columns.Add("MachineTag", typeof(string));
            MapColumnCAPA.Columns["MachineTag"].ReadOnly = true;

            MapColumnCAPA.Columns.Add("Area", typeof(string));
            MapColumnCAPA.Columns["Area"].ReadOnly = true;

            MapColumnCAPA.Columns.Add("Observation", typeof(string));
            MapColumnCAPA.Columns["Observation"].ReadOnly = true;

            MapColumnCAPA.Columns.Add("Recommendation", typeof(string));
            MapColumnCAPA.Columns["Recommendation"].ReadOnly = true;

            MapColumnCAPA.Columns.Add("criticality", typeof(string));
            //MapColumnCAPA.Columns["criticality"].ReadOnly = true;

            MapColumnCAPA.Columns.Add("ImmediateCause", typeof(string));
            MapColumnCAPA.Columns.Add("RootCause", typeof(string));
            MapColumnCAPA.Columns.Add("CorrectiveAction", typeof(string));
            MapColumnCAPA.Columns.Add("Reason", typeof(string));
            MapColumnCAPA.Columns.Add("PreventiveActions", typeof(string));
            MapColumnCAPA.Columns.Add("AddTeam", typeof(string));
            MapColumnCAPA.Columns.Add("Escalation", typeof(string));
            MapColumnCAPA.Columns.Add("EmpCode", typeof(string));
            MapColumnCAPA.Columns.Add("AuditCode", typeof(string));
            MapColumnCAPA.Columns["AuditCode"].ReadOnly = true;

            return MapColumnCAPA;
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
        private void AuditReport_Load(object sender, EventArgs e)
        {
            grpreport.Visible = false;
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            //this.groupBox1.Visible = false;

            //if (GlobalDeclaration.UserType.Equals("U1Maintenance") || GlobalDeclaration.UserType.Equals("U1Safety"))
            //    grpreport.Visible = false;

          
            LoadMachines();            
            // LoadHistory();           
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
       
        private void btnbrowser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtfile.Text))
                    txtfile.Text = "";
                OpenFileDialog obd = new OpenFileDialog();
                obd.Filter = "Supported files | *.pdf| pdf | *.pdf | All |*.*";
                DialogResult dlgRes = obd.ShowDialog(this);
                if ((dlgRes != DialogResult.OK) || (string.IsNullOrEmpty(obd.FileName)))
                {
                    return;
                }
                
                    txtfile.Text = obd.FileName;
                    txtfile.Enabled = false;
                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                      ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMachines()
        {
            try
            {
                DataTable dt = Resources.Instance.GetDataKey("Sp_FetchAuditCodeReportRMPCL");
                EmployeeMaster = Resources.Instance.GetDataKey("SP_GetEmployeeName");
                if (dt.Rows.Count > 0)
                {
                    //CodezviewList.DataSource = dt;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        CodezviewList.Rows.Add(dr);
                        int Index = CodezviewList.Rows.Count - 1;
                        CodezviewList.Rows[Index].Cells["AuditCode"].Value = dt.Rows[i]["Audit Code"];
                        CodezviewList.Rows[Index].Cells["NameofAudit"].Value = dt.Rows[i]["Name Of Audit"];
                        CodezviewList.Rows[Index].Cells["AuditDate"].Value = Convert.ToDateTime(dt.Rows[i]["Audit Date"]).ToString("dd-MM-yyyy");
                        CodezviewList.Rows[Index].Cells["TypeofAudit"].Value = dt.Rows[i]["Type Of Audit"];
                        CodezviewList.Rows[Index].Cells["NextAuditDate"].Value = Convert.ToDateTime(dt.Rows[i]["Next Date"]).ToString("dd-MM-yyyy");
                        if (!string.IsNullOrEmpty(dt.Rows[i]["Audit Date"].ToString()))
                        {
                            CodezviewList.Rows[Index].DefaultCellStyle.ForeColor = Color.LimeGreen;
                        }
                    }
                }                          
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }              
        private Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }

        private DataSet ds;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //if (DgvReport.Rows.Count > 0) return;
            try
            {
                string fileExtention = Path.GetExtension(this.txtfile.Text);
                string[] s = (this.txtfile.Text.ToString()).Split('\\');
                int count = s.Length;
                string FileName = s[count - 1].Split('.')[0];
                if (fileExtention.ToUpper() == ".PDF")
                {
                    if (!_SheetNameHold.Contains(FileName))
                    {
                        //tabcontrolAudit.SelectedIndex = 2;
                        //tabcontrolAudit.TabPages[0].Hide();
                        //tabcontrolAudit.TabPages[1].Hide();                       
                        _SheetNameHold.Add(FileName);
                        SavePDFFile(fileExtention, this.txtfile.Text);
                    }
                    else
                    {
                        XtraMessageBox.Show("Same File " + this.txtfile.Text + " Already Uploaded", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }               
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SavePDFFile(string filetype, string filename)
        {
            if (CodezviewList.SelectedRows.Count > 0)
            {
                byte[] FileBytes = null;
                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(filename).Length;

                    // read entire file into buffer
                    FileBytes = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                    int result = Resources.Instance.InsertPDFFile("insert into PDFupload(fname,fcontent,AuditCode,ReportUploadDate) values (@FN, @FB,@AuditCode,@ReportUploadDate)", CodezviewList.SelectedRows[0].Cells["AuditCode"].Value.ToString(), filename, FileBytes, DateTime.Now);
                    if (result > 0)
                    {
                        ////btnCapatab.Visible = false;
                        ////btnControlAudit.Visible = false;
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVPDF.Rows.Add(dr);
                        int rowidex = this.DGVPDF.Rows.Count - 1;
                        DGVPDF.Rows[rowidex].Cells["FileName"].Value = txtfile.Text;
                        DGVPDF.Rows[rowidex].Cells["AuditCodePDF"].Value = CodezviewList.SelectedRows[0].Cells["AuditCode"].Value;
                        DGVPDF.Rows[rowidex].DefaultCellStyle.ForeColor = Color.LimeGreen;
                        DGVPDF.ReadOnly = true;
                        CodezviewList.SelectedRows[0].Cells["ReportDate"].Value = DateTime.Now.ToString("dd-MM-yyyy");
                        XtraMessageBox.Show("Save File Successfully!!!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK);
                    }
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Please select Audit Code First!!!!!!!!!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void LoadPDFFile(string Code)
        {
            DataTable Dt = Resources.Instance.GetDataKey("SP_GetPDFFile", "@AuditCode", Code);
            try
            {                
                if (DGVPDF.Rows.Count > 0)
                {
                    DGVPDF.Rows.Clear();
                }
                if (Dt.Rows.Count > 0 && DGVPDF.Rows.Count == 0)
                {                
                    var date = Dt.AsEnumerable().Where(X => X.Field<string>("AuditCode") == Code).Select(X => X.Field<DateTime>("ReportUploadDate")).Distinct().ToList();
                    CodezviewList.SelectedRows[0].Cells["ReportDate"].Value = date[0];
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVPDF.Rows.Add(dr);
                        int rowidex = this.DGVPDF.Rows.Count - 1;
                        DGVPDF.Rows[rowidex].Cells["FileName"].Value = Dt.Rows[i]["fname"];
                        DGVPDF.Rows[rowidex].Cells["AuditCodePDF"].Value = Dt.Rows[i]["AuditCode"];
                        string[] s = (Dt.Rows[i]["fname"].ToString()).Split('\\');
                        int count = s.Length;
                        string FileName = s[count - 1].Split('.')[0];
                        if (!_SheetNameHold.Contains(FileName))
                            _SheetNameHold.Add(FileName);
                    }
                }
                else
                {
                    grpreport.Visible = true;                  
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVPDF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FileStream FS = null;
                byte[] dbbyte;
                string auditcode = DGVPDF.Rows[e.RowIndex].Cells["AuditCodePDF"].Value.ToString();
                DataTable Dt = Resources.Instance.GetDataKey("SP_GetPDFContent", "@AuditCode", auditcode);
                dbbyte = (byte[])Dt.Rows[0]["fcontent"];
                string filepath = @"C:\Users\Public\Downloads\AuditReport.pdf";
                //Assign File path create file
                FS = new FileStream(filepath, System.IO.FileMode.Create);

                //Write bytes to create file
                FS.Write(dbbyte, 0, dbbyte.Length);

                //Close FileStream instance
                FS.Close();
                // Open fila after write 

                //Create instance for process class
                Process Proc = new Process();

                //assign file path for process
                Proc.StartInfo.FileName = filepath;
                Proc.Start();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                       
        bool _IsNewRow;
       
        

        #region Audit Report Mail Send
        public void SendMail(string From, string DisplayName, string ToMail, string ccEmail)
        {
            // SettingOptions mSetting = null;
            System.Net.Mail.MailMessage mail = null;
            try
            {
                //if (SettingOptions.Instance == null)
                //    SettingOptions.ReloadInstance(session);
                //mSetting = SettingOptions.Instance;
                mail = new System.Net.Mail.MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(From, DisplayName);
                mail.To.Add(new MailAddress(ToMail));
                if (!string.IsNullOrEmpty(ccEmail))
                    mail.CC.Add(ccEmail);
                mail.Subject = "Audit Report Upload Status";
               // mail.Body = htmlMessageBody(DgvReport).ToString();
                SmtpClient smtp = new SmtpClient();
                string fromaddr = "Arvind@plant360.org";// mSetting.UserName;
                string password = "AKS360!!";//mSetting.Password;
                smtp.Host = "smtp-mail.outlook.com"; //mSetting.EmailServer;
                smtp.EnableSsl = true;// mSetting.UseSSL;
                smtp.Timeout = 20000;//Convert.ToInt32(mSetting.Timeout);//
                smtp.Port = 587;//Convert.ToInt32(mSetting.EmailServerPort);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential(fromaddr, password);
                smtp.Credentials = nc;
                ServicePointManager.ServerCertificateValidationCallback =
                 delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                 { return true; };
                smtp.Send(mail);
                XtraMessageBox.Show("Audit Report Information Sended On Mail.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
        private StringBuilder htmlMessageBody(DataGridView dg)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("Dear Sir,\n");

            strB.AppendLine("Please Find the Attachment");


            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");
            strB.AppendLine("<tr>");

            strB.AppendLine("<html><body><center><table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");
            //cteate table header
            for (int i = 0; i < 10; i++)
            {
                if (dg.Columns[i].HeaderText == "Load Image") continue;
                strB.AppendLine("<td align='center' valign='middle'>" + dg.Columns[i].HeaderText + "</td>");
            }
            //create table body
            strB.AppendLine("<tr>");
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                strB.AppendLine("<tr>");
                foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                {
                    if (dgvc.ColumnIndex == 8) continue;
                    if (dgvc.ColumnIndex == 10) break;
                    strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>");

                }
                strB.AppendLine("</tr>");

            }
            //table footer & end of html file
            strB.AppendLine("</table></center></body></html>");
            return strB;
        }
        #endregion
     
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (CodezviewList.SelectedRows.Count > 0)
                {
                    AuditReportDisplay auditReportDisplay = new AuditReportDisplay();
                    auditReportDisplay.AuditCode = CodezviewList.SelectedRows[0].Cells["AuditCode"].Value.ToString();
                    auditReportDisplay.TopMost = true;
                    auditReportDisplay.TypeReport = "Internal";
                    if (auditReportDisplay.ShowDialog() == DialogResult.OK)
                    {
                        auditReportDisplay.Close();
                        auditReportDisplay.Dispose();
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select AuditCode First \n from AUdit Code List Then Save?.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CodezviewList.Focus();
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DgvReport_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        

        //DataTable TpeofObDT = null;
        //DataTable TypeOFRecomm = null;
        DataTable RiskDt = null;              
        private void CodezviewList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CodezviewList.SelectedCells.Count > 0)
                {
                    string Value = CodezviewList.SelectedCells[0].Value.ToString();
                    //var Rows = DgvReport.Rows.Cast<DataGridViewRow>().Where(X => X.Cells["AuditCodeR"].Value.ToString() == Value).ToList();
                    //if (Rows.Count <= 0)
                    //    LoadHistory(Value, e.RowIndex, e.ColumnIndex);                   
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Audit Code First From List.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CodezviewList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CodezviewList.SelectedRows.Count > 0)
                {
                    string Value = CodezviewList.SelectedRows[0].Cells["AuditCode"].Value.ToString();              
                    LoadPDFFile(Value);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Audit Code First From List.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                       
        private void CodezviewList_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (grpreport.Visible)
            //    grpreport.Visible = false;
            //else
            //    grpreport.Visible = true;
        }          

    }
}
