using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.U1FormCollection
{
    public partial class ObservationFrmcs : XtraForm
    {
        private DataTable Loaddt = new DataTable();
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int ColumnIndex);
        private bool bIsComboBox;
        public bool IsCalling;
        public ObservationFrmcs()
        {
            InitializeComponent();
            this.Text = "Machine Observation";
            UpdateTextPosition();
        }

        private void ObservationFrmcs_Load(object sender, EventArgs e)
        {
            if (IsCalling)
            {
                ViewData();
                btnSave.Visible = false;
            }
            else
            {
                LoadData();
            }
            GridSeeting();
        }

        public void ViewData()
        {
            DataTable Dt = Resources.Instance.GetDataKey("Sp_FetchViewOBGDetails", "@userid", "@username", "@empcode", GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    DgvObser.Rows.Add(dr);
                    int rowidex = this.DgvObser.Rows.Count - 1;
                    DgvObser.Rows[rowidex].Cells["MachineTagNo"].Value = Dt.Rows[i]["MachineTagNo"].ToString();
                    DgvObser.Rows[rowidex].Cells["MachineName"].Value = Dt.Rows[i]["MachineName"].ToString();
                    DgvObser.Rows[rowidex].Cells["Typeresponce"].Value = Dt.Rows[i]["Responce"].ToString();
                    DgvObser.Rows[rowidex].Cells["Expected"].Value = Dt.Rows[i]["ExpectedCondition"].ToString();
                    DgvObser.Rows[rowidex].Cells["Result"].Value = Dt.Rows[i]["Result"].ToString();
                    DgvObser.Rows[rowidex].Cells["ObservationV"].Value = Dt.Rows[i]["ObservVisual"].ToString();
                    DgvObser.Rows[rowidex].Cells["ObservationN"].Value = Dt.Rows[i]["ObservaNumeric"].ToString();
                    DgvObser.Rows[rowidex].Cells["Deviations"].Value = Dt.Rows[i]["Deviations"].ToString();
                    DgvObser.Rows[rowidex].Cells["criticality"].Value = Dt.Rows[i]["Critically"].ToString();
                    DgvObser.Rows[rowidex].Cells["ValueMin"].Value = Dt.Rows[i]["Vmin"].ToString();
                    DgvObser.Rows[rowidex].Cells["ValueMax"].Value = Dt.Rows[i]["Vmax"].ToString();
                    DataGridViewButtonCell dgbtn = null;
                    dgbtn = (DataGridViewButtonCell)(DgvObser.Rows[i].Cells["sendbtn"]);
                    if (dgbtn.Value.ToString() == "Click Here")
                    {
                        dgbtn.UseColumnTextForButtonValue = true;
                        dgbtn.UseColumnTextForButtonValue = false;
                        dgbtn.Value = Dt.Rows[i]["ReportStatus"].ToString();
                    }
                    DgvObser.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Green;
                }
                DgvObser.ReadOnly = true;
            }
        }
        private void LoadData()
        {
            try
            {
                if (Loaddt.Rows.Count == 0)
                {
                    Loaddt = Resources.Instance.GetDataKey("Sp_FetchOJMachineInfo", "@userid", "@username", "@empcode", GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                    // DataTable ObjFetch = Resources.Instance.GetDataKey("Sp_FetchObserBrkInfo", "@userid", "@username", "@empcode", GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                    if (Loaddt.Rows.Count > 0)
                    {

                        for (int i = 0; i < Loaddt.Rows.Count; i++)
                        {
                            DataGridViewRow dr = new DataGridViewRow();
                            DgvObser.Rows.Add(dr);
                            int rowidex = this.DgvObser.Rows.Count - 1;
                            // if (string.IsNullOrEmpty(Loaddt.Rows[i]["Result"].ToString()))
                            {
                                DgvObser.Rows[rowidex].Cells["MachineTagNo"].Value = Loaddt.Rows[i]["MachineTag"].ToString();
                                DgvObser.Rows[rowidex].Cells["MachineName"].Value = Loaddt.Rows[i]["MachineName"].ToString();
                                DgvObser.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            //    else
                            //    {

                            //        if (ObjFetch.Rows.Count > 0)
                            //        {
                            //            DgvObser.Rows[rowidex].Cells["MachineTagNo"].Value = ObjFetch.Rows[i]["MachineTagNo"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["MachineName"].Value = ObjFetch.Rows[i]["MachineName"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["Typeresponce"].Value = ObjFetch.Rows[i]["Responce"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["Expected"].Value = ObjFetch.Rows[i]["ExpectedCondition"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["Result"].Value = ObjFetch.Rows[i]["Result"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["ObservationV"].Value = ObjFetch.Rows[i]["ObservVisual"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["ObservationN"].Value = ObjFetch.Rows[i]["ObservaNumeric"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["Deviations"].Value = ObjFetch.Rows[i]["Deviations"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["criticality"].Value = ObjFetch.Rows[i]["Critically"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["ValueMin"].Value = ObjFetch.Rows[i]["Vmin"].ToString();
                            //            DgvObser.Rows[rowidex].Cells["ValueMax"].Value = ObjFetch.Rows[i]["Vmax"].ToString();                                                                        
                            //            DataGridViewButtonCell dgbtn = null;
                            //            dgbtn = (DataGridViewButtonCell)(DgvObser.Rows[i].Cells["sendbtn"]);
                            //            if(dgbtn.Value.ToString()=="Click Here")
                            //            {
                            //                dgbtn.UseColumnTextForButtonValue = true;
                            //                dgbtn.UseColumnTextForButtonValue = false;
                            //                dgbtn.Value = ObjFetch.Rows[i]["ReportStatus"].ToString();
                            //            }
                            //            DgvObser.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Green;
                            //            DgvObser.Rows[rowidex].ReadOnly = true;
                            //        }
                            //    }
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (dgbtn.Value.ToString() == "Click Here")
                    {
                        dgbtn.UseColumnTextForButtonValue = false;
                        DgvObser.CurrentCell = DgvObser.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        DgvObser.CurrentCell.ReadOnly = false;
                        dgbtn.Value = "Send Done";
                        DgvObser.CurrentCell.ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Selected = true;
                        SendMail("Arvind@plant360.org", "Arvind Sharma", "Rajendra@plant360.org", "");
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            for (int i = 0; i < dg.Columns.Count - 1; i++)
            {
                strB.AppendLine("<td align='center' valign='middle'>" + dg.Columns[i].HeaderText + "</td>");
            }
            //create table body
            strB.AppendLine("<tr>");
            for (int i = 0; i < dg.SelectedRows.Count; i++)
            {
                strB.AppendLine("<tr>");
                foreach (DataGridViewCell dgvc in dg.SelectedRows[i].Cells)
                {
                    if (dgvc.Value == null) continue;
                    strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>");
                }
                strB.AppendLine("</tr>");

            }
            //table footer & end of html file
            strB.AppendLine("</table></center></body></html>");
            return strB;
        }
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



                //if (!string.IsNullOrEmpty(mSetting.MailCc))
                //{
                //    foreach (string item in GetMailSender(mSetting.MailCc))
                //    {
                //        if (emailIsValid(item))
                //            mail.CC.Add(new MailAddress(item));
                //    }
                //}

                // mail.Attachments.Add(new Attachment(file));
                mail.BodyEncoding = Encoding.UTF8;
                mail.Subject = "Maintenace Observation Report";
                mail.Body = htmlMessageBody(DgvObser).ToString();
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
                XtraMessageBox.Show("Send");
            }
            catch (Exception ex)
            {
                //bPayment.Error = ex.Message;
                //bPayment.Save();
            }
            finally
            {

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvObser.SelectedRows.Count > 0)
                {
                    if (DgvObser.SelectedRows[0].DefaultCellStyle.ForeColor != Color.Green)
                    {
                        AuditReportInsertion _audinsobj = new AuditReportInsertion();
                        int Status = _audinsobj.InsertObservationBrkDwn(this.DgvObser);
                        if (Status > 0)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Details Save In DB", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgvObser.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error in Fill Details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "This Information Already Save In DB.\n Please Try Another.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvObser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellTypeResult = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvObser.Columns["TypeResponce"].Index)
                {
                    this.DgvObser.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "responce", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvObser.Columns["Result"].Index)
                {
                    this.DgvObser.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Rsult", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvObser.Columns["Deviations"].Index)
                {
                    this.DgvObser.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Deviations", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvObser.Columns["Criticality"].Index)
                {
                    this.DgvObser.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "criticality", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "responce")
                    {
                        if (DgvObser.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
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
                        DgvObser[iColumnIndex, iRowIndex] = dgvResponce;
                        dgvResponce.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Rsult")
                    {
                        if (DgvObser.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
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
                        DgvObser[iColumnIndex, iRowIndex] = dgvResult;
                        dgvResult.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Deviations")
                    {
                        if (DgvObser.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
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
                        DgvObser[iColumnIndex, iRowIndex] = dgvResultDeviation;
                        dgvResultDeviation.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "criticality")
                    {
                        if (DgvObser.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
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
                        DgvObser[iColumnIndex, iRowIndex] = dgvcriti;
                        dgvcriti.Dispose();
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvObser_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                {
                    string Value = DgvObser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "Visual")
                    {
                        //if(DgvResult.Rows[e.RowIndex].Cells["observationN"].Value)
                        DgvObser.Columns["observationN"].Visible = false ? true : false;
                        ///DgvResult.Rows[e.RowIndex].Cells["observationV"].Value = true;
                        DgvObser.Columns["Result"].Visible = true;// false ? true : false;
                        DgvObser.Columns["ValueMin"].Visible = false ? true : false;
                        DgvObser.Columns["ValueMax"].Visible = false ? true : false;
                        DgvObser.Columns["Deviations"].Visible = false ? true : false;
                        DgvObser.Rows[e.RowIndex].Cells["observationN"].Value = "NA";
                        DgvObser.Rows[e.RowIndex].Cells["observationN"].ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Cells["ValueMin"].Value = "NA";
                        DgvObser.Rows[e.RowIndex].Cells["ValueMin"].ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Cells["ValueMax"].Value = "NA";
                        DgvObser.Rows[e.RowIndex].Cells["ValueMax"].ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Cells["Deviations"].Value = "NA";
                        DgvObser.Rows[e.RowIndex].Cells["Deviations"].ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Cells["Result"].Value = null;
                    }
                    else if (Value == "Numeric")
                    {
                        DgvObser.Columns["observationV"].Visible = false ? true : false;
                        DgvObser.Columns["Result"].Visible = false;
                        DgvObser.Rows[e.RowIndex].Cells["observationV"].Value = "NA";
                        DgvObser.Rows[e.RowIndex].Cells["observationV"].ReadOnly = true;
                        DgvObser.Rows[e.RowIndex].Cells["Result"].Value = "NA";
                        DgvObser.Rows[e.RowIndex].Cells["Result"].ReadOnly = true;

                        DgvObser.Columns["observationN"].Visible = true;
                        DgvObser.Columns["ValueMin"].Visible = true;
                        DgvObser.Columns["ValueMax"].Visible = true;
                        DgvObser.Columns["Deviations"].Visible = true;
                        DgvObser.Rows[e.RowIndex].Cells["observationN"].ReadOnly = false;
                        DgvObser.Rows[e.RowIndex].Cells["ValueMin"].ReadOnly = false;
                        //DgvResult.Rows[e.RowIndex].Cells["Vmax"].ReadOnly = false;
                        DgvObser.Rows[e.RowIndex].Cells["Deviations"].ReadOnly = false;
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
