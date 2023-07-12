using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Class_Operation
{
    public class AuditReportInsertion
    {

        string InsertQuery = @"insert into InternAuditReportTBL(SrNo,[Date&time],Machinetag ,Typeofobservation ,Observation,Recommendation ,Typeofrecommendation ,RiskCategory ,Auditor ,Responsibility,Timeframe  ,Acceptance,Area,AuditCode,EmpCode) Values";
        string InsertDesc = @"insert into AcceptanceDecripTBL(Timeframe,Capability,Date_of_closure,Responsibility,Inventory_required,Notes,Machinetag,EmpCode,AuditCode)values";
        string InsertAccptDetails = @"insert into AcceptanceDetailsTBL(Description,Constraints,Raise_the_issue,Note,Machinetag,EmpCode,AuditCode)values";
        string Insertauditcale = @"insert into InternAuditCalendarTBL(SrNo, AuditCode, NameofAudit , TypeofAudit,Area,ProcessName , Frequency, Lastdateofaudit, Nextdateofaudit, Department, Individual, Auditowner, Reviewedby, Approvedby,EmpCode)values";
        string InsertQueryExternalAuditCal = @"insert into ExternalAuditCalenTBL([Sr.No],AuditCode,NameofAudit,TypeofAudit,Area,ProcessName,From_date,To_date,ThirdPartyName,Department,Individual,AuditOwner,Remark,EmpCode)values";
        string insertInventory = @"insert into MaintenanceINVRMPCL(DocNo,ItemName,Make,Model,UnitConsumed,UnitCost,TotalCost,ConsumptionType,MaintenanceCode,BatchNo,ItemCode,UnitCode,ReferenceNo)values";
        string InsertMNTWorker = @"insert into MaintenanceWorkerRMPCL(WorkerName,MaintenanceCode) values";
        // private int ReceiveCount = 0;

        public string MessageDisplay = string.Empty;
        public string InsertMNTInventory(System.Windows.Forms.DataGridView DgvInventory, string MCode, string ConsuptionType)
        {
            try
            {
                string query = string.Empty;
                int Status = 0;
                for (int i = 0; i < DgvInventory.Rows.Count; i++)
                {
                    if (DgvInventory.Rows[i].Cells["StatusI"].Value.ToString() == "New")
                    {
                        query = query + "('" + DgvInventory.Rows[i].Cells["DocumentNo"].Value.ToString() +
                            "','" + DgvInventory.Rows[i].Cells["ItemName"].Value.ToString() +
                            "','" + DgvInventory.Rows[i].Cells["Make"].Value.ToString().Trim() +
                            "','" + DgvInventory.Rows[i].Cells["Model"].Value.ToString() +
                            "'," + DgvInventory.Rows[i].Cells["Quantity"].Value.ToString() +
                            "," + DgvInventory.Rows[i].Cells["Unit"].Value.ToString() +
                            "," + DgvInventory.Rows[i].Cells["TotalCost"].Value.ToString() +
                            ",'" + ConsuptionType +
                            "','" + MCode +
                            "','" + DgvInventory.Rows[i].Cells["BatchNo"].Value.ToString() +
                            "','" + DgvInventory.Rows[i].Cells["ItemCode"].Value.ToString() +
                            "','" + DgvInventory.Rows[i].Cells["UnitCode"].Value.ToString() +
                            "','" + DgvInventory.Rows[i].Cells["ReferenceNo"].Value.ToString() + "'),";
                    }
                }
                if (!string.IsNullOrEmpty(query))
                {
                    insertInventory = insertInventory + query.Remove(query.Length - 1, 1);
                    Status = Resources.Instance.SaveMaintenenceData(insertInventory);
                }
                if (Status > 0)
                {
                    MessageDisplay = "Inventory Details Saved Successfully.";
                    //XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen },"Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageDisplay = "";
            }
            return MessageDisplay;
        }
        public string InsertMNTWorkers(System.Windows.Forms.DataGridView DgvInventory, string MCode)
        {
            try
            {
                string query = string.Empty;
                int Status = 0;
                for (int i = 0; i < DgvInventory.Rows.Count; i++)
                {
                    if (DgvInventory.Rows[i].Cells["StatusW"].Value.ToString() == "New")
                    {
                        query = query + "('" + DgvInventory.Rows[i].Cells["WorkerName"].Value.ToString() + "','" + MCode + "'),";
                    }
                }
                if (!string.IsNullOrEmpty(query))
                {
                    InsertMNTWorker = InsertMNTWorker + query.Remove(query.Length - 1, 1);
                    Status = Resources.Instance.SaveMaintenenceData(InsertMNTWorker);
                }
                if (Status > 0)
                {
                    MessageDisplay = "Worker Details Saved Successfully";
                    //XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen },"Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageDisplay = "";
            }
            return MessageDisplay;
        }
        public void InsertAuditReportData(System.Windows.Forms.DataGridView DgvReport, DataTable MapColumnCAPA, string Action, string AuditCode)
        {
            try
            {
                string query = string.Empty;
                int Status = 0;
                if (Action == "Internal")
                {
                    for (int i = 0; i < DgvReport.Rows.Count; i++)
                    {
                        if (DgvReport.Rows[i].Cells["Status"].Value.ToString() == "New")
                        {
                            query = query + "('" + DgvReport.Rows[i].Cells["SrNo"].Value.ToString() + "'," + Convert.ToDateTime(DgvReport.Rows[i].Cells["Dtime"].Value).ToString("yyyy-MM-dd") +
                                ",'" + DgvReport.Rows[i].Cells["Machinetag"].Value.ToString().Trim() + "','" + DgvReport.Rows[i].Cells["Typeofobservation"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Observation"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Recommendation"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Typeofrecommendation"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["RiskCategory"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Auditor"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Responsibility"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Timeframe"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Acceptance"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Area"].Value.ToString() + "','"
                                + DgvReport.Rows[i].Cells["AuditCodeR"].Value.ToString() + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "'),";
                        }
                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        // string dd = "'System.Byte[]'";
                        // query = query.Replace("'System.Byte[]'", "CONVERT(VARBINARY(MAX)," + dd + ")");
                        InsertQuery = InsertQuery + query.Remove(query.Length - 1, 1);
                        Status = Resources.Instance.SaveMaintenenceData(InsertQuery);
                        for (int i = 0; i < DgvReport.Rows.Count; i++)
                        {
                            Resources.Instance.UpdateImage("Sp_SaveImageData", AuditCode, SaveImage(DgvReport.Rows[i].Cells["btnImage"].Value), Action);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < DgvReport.Rows.Count; i++)
                    {
                        if (DgvReport.Rows[i].Cells["Status"].Value.ToString() == "New")
                        {
                            query = query + "('" + DgvReport.Rows[i].Cells["SrNo"].Value.ToString() + "','" + Convert.ToDateTime(DgvReport.Rows[i].Cells["Dtime"].Value.ToString()).ToString("dd-MM-yyyy") +
                                "','" + DgvReport.Rows[i].Cells["Machinetag"].Value.ToString().Trim() + "','" + DgvReport.Rows[i].Cells["Typeofobservation"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Observation"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Recommendation"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Typeofrecommendation"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["RiskCategory"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Auditor"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Responsibility"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Timeframe"].Value.ToString() +
                                "','" + DgvReport.Rows[i].Cells["Acceptance"].Value.ToString() + "','" + DgvReport.Rows[i].Cells["Area"].Value.ToString() + "','"
                                + DgvReport.Rows[i].Cells["AuditCode"].Value.ToString() + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "'),";
                        }
                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        //string dd = "'System.Byte[]'";
                        //query = query.Replace("'System.Byte[]'", "CONVERT(VARBINARY(MAX)," + dd + ")");
                        InsertQuery = InsertQuery + query.Remove(query.Length - 1, 1);
                        InsertQuery = InsertQuery.Replace("InternAuditReportTBL", "ExternalAuditReportTBL");
                        Status = Resources.Instance.SaveMaintenenceData(InsertQuery);
                        for (int i = 0; i < DgvReport.Rows.Count; i++)
                        {
                            Resources.Instance.UpdateImage("Sp_SaveImageData", AuditCode, SaveImage(DgvReport.Rows[i].Cells["btnImage"].Value), Action);
                        }
                    }
                }
                //int Status = Resources.Instance.SaveMaintenenceData(InsertQuery);
                if (MapColumnCAPA.Rows.Count > 0)
                {
                    Status = Resources.Instance.SaveMainTenenceData("Sp_InsertAuditCAPAReport", "@CAPAtbl", MapColumnCAPA, Action);
                }
                if (Status > 0)
                {
                    MessageDisplay = "Data Save SuccessFully..?";

                    //XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen },"Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //MessageDisplay = "Data Save UnSuccessFully..?";
                    //XtraMessageBox.Show("Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int UpdateReceiveCount()
        {
            int result = 0;
            result = Resources.Instance.GetDataKey("Sp_FetchInternalAuditReport", "@tableType", "Internal").Rows.Count;
            return result;

        }
        private byte[] SaveImage(object value)
        {
            Image image = (Image)value;
            byte[] imageData = null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageData = ms.ToArray();
            }
            return imageData;
        }
        public int InsertAcceptanceDetails(System.Windows.Forms.DataGridView DgvAcceptance, int ReceiveCount, string action, string Machinetag, string AuditCode)//Done
        {
            int Status = 0;
            string query = string.Empty;
            if (ReceiveCount > 0)
            {
                for (int i = DgvAcceptance.Rows.Count - 1; i >= ReceiveCount; i--)
                {
                    query = query + "('" + DgvAcceptance.Rows[i].Cells["Timeframe"].Value.ToString() + "','" +
                         DgvAcceptance.Rows[i].Cells["Capability"].Value.ToString() + "','" + DgvAcceptance.Rows[i].Cells["Dateofclosure"].Value.ToString() +
                         "','" + DgvAcceptance.Rows[i].Cells["Note"].Value.ToString() + "','" + DgvAcceptance.Rows[i].Cells["cmbRespoc"].Value.ToString() +
                         "','" + DgvAcceptance.Rows[i].Cells["cmbinventry"].Value.ToString() + "','" + Machinetag + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" +
                         AuditCode + "'),";
                }
            }
            else
            {
                for (int i = 0; i < DgvAcceptance.Rows.Count; i++)
                {
                    query = query + "('" + DgvAcceptance.Rows[i].Cells["Timeframe"].Value.ToString() + "','" +
                         DgvAcceptance.Rows[i].Cells["Capability"].Value.ToString() + "','" + DgvAcceptance.Rows[i].Cells["Dateofclosure"].Value.ToString() +
                         "','" + DgvAcceptance.Rows[i].Cells["Note"].Value.ToString() + "','" + DgvAcceptance.Rows[i].Cells["cmbRespoc"].Value.ToString() +
                         "','" + DgvAcceptance.Rows[i].Cells["cmbinventry"].Value.ToString() + "','" + Machinetag + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" +
                         AuditCode + "'),";
                }
                if (action == "Internal")
                {
                    InsertDesc = InsertDesc + query.Remove(query.Length - 1, 1);
                }
                else
                {
                    InsertDesc = InsertDesc.Replace("AcceptanceDecripTBL", "ExternalAcceptanceDecripTBL") + query.Remove(query.Length - 1, 1);
                }
                Status = Resources.Instance.SaveMaintenenceData(InsertDesc);
            }
            return Status;
        }
        public int InsertAccepdescription(System.Windows.Forms.DataGridView DgvAcceptancedesc, int ReceiveCount, string action, string machtag, string AuditCode)//Done
        {
            int status = 0;
            string query = string.Empty;
            if (ReceiveCount > 0)
            {
                for (int i = DgvAcceptancedesc.Rows.Count - 1; i >= ReceiveCount; i--)
                {
                    query = query + "('" + DgvAcceptancedesc.Rows[i].Cells["Description"].Value.ToString() + "','" +
                         DgvAcceptancedesc.Rows[i].Cells["CmbContraint"].Value.ToString() + "','" + DgvAcceptancedesc.Rows[i].Cells["Raise the issue"].Value.ToString() +
                         "','" + DgvAcceptancedesc.Rows[i].Cells["Note"].Value.ToString() + "','" + machtag + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" + AuditCode + "'),";
                }
            }
            else
            {
                for (int i = 0; i < DgvAcceptancedesc.Rows.Count; i++)
                {
                    query = query + "('" + DgvAcceptancedesc.Rows[i].Cells["Description"].Value.ToString() + "','" +
                         DgvAcceptancedesc.Rows[i].Cells["CmbContraint"].Value.ToString() + "','" + DgvAcceptancedesc.Rows[i].Cells["Raise the issue"].Value.ToString() +
                         "','" + DgvAcceptancedesc.Rows[i].Cells["Note"].Value.ToString() + "','" + machtag + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" + AuditCode + "'),";
                }
                if (action == "Internal")
                {
                    InsertAccptDetails = InsertAccptDetails + query.Remove(query.Length - 1, 1);
                }
                else
                {
                    InsertAccptDetails = InsertAccptDetails.Replace("AcceptanceDetailsTBL", "ExternalAcceptanceDetailsTBL") + query.Remove(query.Length - 1, 1);
                }
                status = Resources.Instance.SaveMaintenenceData(InsertAccptDetails);
            }
            return status;

        }

        public int InsertAuditCalen(System.Windows.Forms.DataGridView DgvAudit)//Done
        {
            int status = 0;
            try
            {
                string query = string.Empty;
                for (int i = 0; i < DgvAudit.Rows.Count; i++)
                {
                    if (DgvAudit.Rows[i].Cells["Status"].Value.ToString() == "New")
                    {
                        string LastDate = Convert.ToDateTime(DgvAudit.Rows[i].Cells["LastDate"].Value.ToString()).ToString("yyyy-MM-dd");
                        string NxtDate = Convert.ToDateTime(DgvAudit.Rows[i].Cells["NextDate"].Value).ToString("yyyy-MM-dd");
                        query = query + "('" + DgvAudit.Rows[i].Cells["SrNo"].Value.ToString() + "','" + DgvAudit.Rows[i].Cells["AuditCode"].Value.ToString() + "','" +
                                         DgvAudit.Rows[i].Cells["NameOfAudit"].Value.ToString() + "','" + DgvAudit.Rows[i].Cells["TypeofAudit"].Value.ToString() + "' ,'" + DgvAudit.Rows[i].Cells["Area"].Value.ToString() +
                                         "','" + DgvAudit.Rows[i].Cells["ProcessName"].Value.ToString() + "','" + DgvAudit.Rows[i].Cells["Frequency"].Value.ToString() +
                                   "','" + LastDate + "','" + NxtDate +
                                   "','" + DgvAudit.Rows[i].Cells["Department"].Value.ToString() + "','" + DgvAudit.Rows[i].Cells["Individual"].Value.ToString() +
                                   "','" + DgvAudit.Rows[i].Cells["AuditOwner"].Value.ToString() + "','" + DgvAudit.Rows[i].Cells["Reviewedby"].Value.ToString() +
                                   "','" + DgvAudit.Rows[i].Cells["Approvedby"].Value.ToString() + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "'),";
                    }
                }
                if (!string.IsNullOrEmpty(query))
                {
                    Insertauditcale = Insertauditcale + query.Remove(query.Length - 1, 1);

                    //DateTime dateTime = Convert.ToDateTime(DgvAudit.Rows[0].Cells["LastDate"].Value.ToString());
                    status = Resources.Instance.SaveMaintenenceData(Insertauditcale);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return status;
        }
        public int InsertFreeZPlanData(bool Fstatus, System.Windows.Forms.DataGridView dgvfreez)//Done
        {
            int Status = 0;
            string value = string.Empty;
            if (Fstatus)
            {
                value = dgvfreez.SelectedRows[0].Cells["Priority"].Value.ToString() + "~" + dgvfreez.SelectedRows[0].Cells["MachineTag"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["MachineName"].Value.ToString() + "~" + dgvfreez.SelectedRows[0].Cells["AdditonalManpower"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["MType"].Value.ToString() + "_~" + dgvfreez.SelectedRows[0].Cells["MaintScheduled"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["ActivityDetails"].Value.ToString() + "~" + dgvfreez.SelectedRows[0].Cells["MReading"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["Datetime"].Value.ToString() + "~" + dgvfreez.SelectedRows[0].Cells["Team"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["UnitsName"].Value.ToString() + "~"
                             + GlobalDeclaration._holdInfo[0].UserId + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" +
                             GlobalDeclaration._holdInfo[0].EmpCode + "~" + dgvfreez.SelectedRows[0].Cells["Freequency"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["ShtdwnReq"].Value.ToString() + "~" + dgvfreez.SelectedRows[0].Cells["Resource"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["btnClickMe"].Value.ToString() + "~" + "";
                Status = Resources.Instance.InsertFreeZplan(value, "Sp_InsertFreePlan");
            }
            else
            {
                value = "test" + "~" + dgvfreez.SelectedRows[0].Cells["Mtag"].Value.ToString() + "~" +
                             dgvfreez.SelectedRows[0].Cells["MachineName"].Value.ToString() + "~" + "" + "~" +
                             "" + "~" + "" + "~" +
                             dgvfreez.SelectedRows[0].Cells["objactivity"].Value.ToString() + "~" + "" + "~" +
                             DateTime.Now + "~" + "" + "~" +
                             "" + "~"
                             + GlobalDeclaration._holdInfo[0].UserId + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" +
                             GlobalDeclaration._holdInfo[0].EmpCode + "~" + "" + "~" +
                             "" + "~" + "" + "~" +
                             "Closed" + "~" + "";
                Status = Resources.Instance.InsertFreeZplan(value, "Sp_InsertFreePlan");
            }
            return Status;
        }

        public int InsertAuditCalendExternal(System.Windows.Forms.DataGridView DGVAuditCal)//Done
        {
            try
            {
                int Status = 0;
                string value = string.Empty;
                {
                    for (int i = 0; i < DGVAuditCal.Rows.Count; i++)
                    {
                        if (DGVAuditCal.Rows[i].Cells["Status"].Value.ToString() == "New")
                        {
                            string LastDate = Convert.ToDateTime(DGVAuditCal.Rows[i].Cells["FDate"].Value.ToString()).ToString("yyyy-MM-dd");
                            string NxtDate = Convert.ToDateTime(DGVAuditCal.Rows[i].Cells["TDate"].Value).ToString("yyyy-MM-dd");
                            value = value + "('" + DGVAuditCal.Rows[i].Cells["SrNo"].Value.ToString() + "','" + DGVAuditCal.Rows[i].Cells["AuditCode"].Value.ToString() + "','" + DGVAuditCal.Rows[i].Cells["NameofAudit"].Value.ToString() +
                               "','" + DGVAuditCal.Rows[i].Cells["TypeofAudit"].Value.ToString() + "','" + DGVAuditCal.Rows[i].Cells["Area"].Value.ToString() + "','" + DGVAuditCal.Rows[i].Cells["ProcessName"].Value.ToString() +
                               "','" + LastDate + "','" + NxtDate +
                              "','" + DGVAuditCal.Rows[i].Cells["ThirdPartyName"].Value.ToString() + "','" + DGVAuditCal.Rows[i].Cells["Department"].Value.ToString() +
                              "','" + DGVAuditCal.Rows[i].Cells["Individual"].Value.ToString() + "','" + DGVAuditCal.Rows[i].Cells["AuditOwner"].Value.ToString() +
                               "','" + DGVAuditCal.Rows[i].Cells["Remark"].Value.ToString() + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "'),";
                        }
                    }
                    InsertQueryExternalAuditCal = InsertQueryExternalAuditCal + value.Remove(value.Length - 1, 1);
                    Status = Resources.Instance.SaveMaintenenceData(InsertQueryExternalAuditCal);
                }
                return Status;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public int InsertFreezPlaingInfo(DataGridView dgvfreez) //Done
        {
            int Status = 0;
            string Value = dgvfreez.SelectedRows[0].Cells["Outsource"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["shqReq"].Value.ToString() + "_" +
                          dgvfreez.SelectedRows[0].Cells["Team"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["expcttime"].Value.ToString() + "_" +
                          dgvfreez.SelectedRows[0].Cells["mntCrtDate"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["Strdate"].Value.ToString() + "_" +
                          dgvfreez.SelectedRows[0].Cells["enddate"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["MachineName"].Value.ToString() + "_" +
                          dgvfreez.SelectedRows[0].Cells["MachineTag"].Value.ToString() + "_" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "_" +
                          GlobalDeclaration._holdInfo[0].UserName + "_" + GlobalDeclaration._holdInfo[0].EmpCode + "_"
                          + dgvfreez.SelectedRows[0].Cells["SrNo"].Value.ToString();

            Status = Resources.Instance.InsertPlaningInfo("Sp_InsertPlaningInfo", "@Outsrc", "@ShtDwnReq", "@EmployeeName", "@ExpctTime",
                "@MainCreateDte", "@StartDate", "@EndDate", "@MachineName", "@MachineTag", "@userid", "@username", "@empcode", "@srNo", Value);
            return Status;

        }
        public int InsertObservationBrkDwn(DataGridView dgvfreez) // Done
        {
            int Status = 0;
            try
            {
                string Value = dgvfreez.SelectedRows[0].Cells["Typeresponce"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["Expected"].Value.ToString() + "_" +
                                   dgvfreez.SelectedRows[0].Cells["Result"].Value.ToString() + "_" +
                                 dgvfreez.SelectedRows[0].Cells["ObservationV"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["ObservationN"].Value.ToString() + "_" +
                                 dgvfreez.SelectedRows[0].Cells["Deviations"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["criticality"].Value.ToString() + "_" +
                                  dgvfreez.SelectedRows[0].Cells["sendbtn"].Value.ToString() + "_" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "_" +
                                  GlobalDeclaration._holdInfo[0].UserName + "_" + GlobalDeclaration._holdInfo[0].EmpCode + "_" +
                                  dgvfreez.SelectedRows[0].Cells["ValueMax"].Value.ToString() + "_" + dgvfreez.SelectedRows[0].Cells["ValueMin"].Value.ToString() + "_" +
                                  dgvfreez.SelectedRows[0].Cells["MachineTagNo"].Value.ToString() + "_"
                        + dgvfreez.SelectedRows[0].Cells["MachineName"].Value.ToString();
                Status = Resources.Instance.InsertPlaningInfo("Sp_InsertObserBrkDwnInfo",
                   "@Responce", "@ExpectedCondition", "@Result", "@ObservVisual", "@ObservaNumeric",
                    "@Deviations", "@Critically", "@ReportStatus", "@username", "@empcode", "@userid", "@vmin", "@vmax", "@MachineTag", "@MachineName", Value);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Status;
        }
    }
}
