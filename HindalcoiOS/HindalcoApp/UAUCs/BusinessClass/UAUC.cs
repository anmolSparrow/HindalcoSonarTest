using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.UAUCs
{
      public  class UAUC: IDisposable
    {
        public DateTime CreatedDate { set; get; }
        public String ObservationNo { set; get; }
        public DateTime ObservationDate { set; get; }
        public string OperationUnit { set; get; }
        public string OperationUnitCode { set; get; }
        public String DocumentedBy { set; get; }
        public String DocumentedCode { set; get; }
        public String MachineTag { set; get; }
        public string ObservedBy { set; get; }
        public string ObservedByCode { set; get; }
        public string PlantArea { set; get; }
        public string PlantAreaCode { set; get; }
        public String Observation { set; get; }
        public String SpecificArea { set; get; }
        public int UnsafeCondition { set; get; }
        public string AssigenedTo { set; get; }
        public string AssigenedToCode { set; get; }
        public string SafetyUser { set; get; }
        public string SafetyUserCode { set; get; }
        public DateTime AssigenedDate { set; get; }
        public string CurrentUserCode { set; get; }
        public int Status { set; get; }
        public string Recommendation { set; get; }
        public string Remarks { set; get; }
        public byte[] SnapImage { get; set; }
        public string Hours { get; set; }
        public string Minuts { get; set; }
        public string CurrentUserRole { set; get; }
        public DataTable LoadData { set; get; }

        public DataTable LoadAllUsers { set; get; }
        //public DataTable LoadCategory { set; get; }

        public void SetUAUCToData(UAUC uauc)
        {
            try
            {
                DataTable dt = CreateDatatable(uauc);
                Resources.Instance.AddUAUC(dt);
            }
            catch(Exception ex)
            {

            }
        }
        private DataTable CreateDatatable(UAUC uauc)
        {
            DataTable ppeDt = null;
            ppeDt = new DataTable();
            ppeDt.Columns.Add("ObservationNo", typeof(string));
            ppeDt.Columns.Add("ObservationDate", typeof(DateTime));
            ppeDt.Columns.Add("OperationUnit", typeof(string));
            ppeDt.Columns.Add("OperationUnitCode", typeof(string));
            ppeDt.Columns.Add("DocumentedBy", typeof(string));
            ppeDt.Columns.Add("DocumentedByCode", typeof(string));
            ppeDt.Columns.Add("UnsafeCondition", typeof(int));
            ppeDt.Columns.Add("PlantArea", typeof(string));
            ppeDt.Columns.Add("PlantAreaCode", typeof(string));
            ppeDt.Columns.Add("SpecificArea", typeof(string));
            ppeDt.Columns.Add("MachineTag", typeof(string));
            ppeDt.Columns.Add("Observation", typeof(string));
            ppeDt.Columns.Add("ObservedBy", typeof(string));
            ppeDt.Columns.Add("ObservedByCode", typeof(string));
            ppeDt.Columns.Add("AssignedTo", typeof(string));
            ppeDt.Columns.Add("AssignedToCode", typeof(string));
            ppeDt.Columns.Add("AssignedDate", typeof(DateTime));
            ppeDt.Columns.Add("Recommendation", typeof(string));
            ppeDt.Columns.Add("Remarks", typeof(string));
            ppeDt.Columns.Add("Status", typeof(int));
            ppeDt.Columns.Add("SnapImage", typeof(byte[]));
            ppeDt.Columns.Add("SafetyUser", typeof(string));
            ppeDt.Columns.Add("SafetyUserCode", typeof(string));
            ppeDt.Columns.Add("UACHours", typeof(string));
            ppeDt.Columns.Add("UACMinuts", typeof(string));

            DataRow dr = ppeDt.NewRow();
            dr["ObservationNo"] = uauc.ObservationNo;
            dr["ObservationDate"] = uauc.ObservationDate;
            dr["OperationUnit"] = uauc.OperationUnit;
            dr["OperationUnitCode"] = uauc.OperationUnitCode;
            dr["DocumentedBy"] = uauc.DocumentedBy;
            dr["DocumentedByCode"] = uauc.DocumentedCode;
            dr["UnsafeCondition"] = uauc.UnsafeCondition;
            dr["PlantArea"] = uauc.PlantArea;
            dr["PlantAreaCode"] = uauc.PlantAreaCode;
            dr["SpecificArea"] = uauc.SpecificArea;
            dr["MachineTag"] = uauc.MachineTag;
            dr["Observation"] = uauc.Observation;
            dr["ObservedBy"] = uauc.ObservedBy;
            dr["ObservedByCode"] = uauc.ObservedByCode;
            dr["AssignedTo"] = uauc.AssigenedTo;
            dr["AssignedToCode"] = uauc.AssigenedToCode;
            dr["AssignedDate"] = uauc.AssigenedDate;
            dr["Recommendation"] = uauc.Recommendation;
            dr["Remarks"] = uauc.Remarks;
            dr["Status"] = uauc.Status;
            dr["SnapImage"] = uauc.SnapImage;
            dr["SafetyUser"] = string.Empty;
            dr["SafetyUserCode"] = string.Empty;
            dr["UACHours"] = uauc.Hours;
            dr["UACMinuts"] = uauc.Minuts;
            ppeDt.Rows.Add(dr);
            return ppeDt;
        }

        public DataTable GetAllUAUC()
        {
            return Resources.Instance.GetUAUC();
        }
        public DataTable GetUAUCByUser(string userCode)
        {
            return Resources.Instance.GetCreatedUAUC(userCode);
        }
        public DataTable GetAssignedUAUC(string assignedToCode)
        {
            return Resources.Instance.GetAssignedUAUC(assignedToCode);
        }
        public DataTable GetAllOperationUnits()
        {
            return Resources.Instance.GetOperationUnit();
        }
        public DataTable GetAllUsers()
        {
            LoadAllUsers= Resources.Instance.GetUserDetails_RMPCL(2);
            return LoadAllUsers;
        }
        public DataTable GetAllArea()
        {
            return Resources.Instance.GetMachineAreaMaster();
        }


        //string mailbody = string.Format("Hi {0},\n\nA new UA/UC {1} for area location {2} has been submitted on {3}.\nKindly review and take appropriate action.\n\nThanks",
        //         null, oHCReport.);

       
        //* submission to safety user
        public void SubmitMail(UAUC uAUC)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            
            string mailTo= LoadAllUsers.AsEnumerable().Where(X => X.Field<int>("RoleId") == 5).ToList().FirstOrDefault()["Email"].ToString();
            string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA new UA/UC {1} for area location {2} has been submitted on {3} {4}:{5}.\nKindly review and take appropriate action.\n\nThanks",
                     mailToName, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate.ToString("dd-MM-yyyy"),uAUC.Hours,uAUC.Minuts);
            string subject = string.Format("UAUC Submitted for {0}",uAUC.ObservationNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
        }
        //* Approve & assigned user by safety user.
        public void ApproveMail(UAUC uAUC)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == uAUC.AssigenedTo).ToList().FirstOrDefault()["Email"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA new UA/UC {1} for area location {2} on {3} {4}:{5} has been assigned to you.\nKindly review and take appropriate action.\n\nThanks.",
                     uAUC.AssigenedTo, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate.ToString("dd-MM-yyyy"), uAUC.Hours, uAUC.Minuts);
            string subject = string.Format("UAUC Assigned for {0}", uAUC.ObservationNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
        }

        //* Rejection to creator by safety user
        public void RejectMail(UAUC uAUC)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") ==uAUC.DocumentedBy).ToList().FirstOrDefault()["Email"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA new UA/UC {1} for area location {2} submitted by you on {3} {4}:{5} has been rejected by {4}.\nKindly review and take appropriate action.\n\nThanks.",
            uAUC.DocumentedBy, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate.ToString("dd-MM-yyyy"), uAUC.Hours, uAUC.Minuts, curruser);
            string subject = string.Format("UAUC Rejected for {0}", uAUC.ObservationNo);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        //* Closed by assigned user to safety user
        public void DeptClosureMail(UAUC uAUC)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == uAUC.SafetyUser).ToList().FirstOrDefault()["Email"].ToString();
            string msgBody = string.Format("Hi {0},\nThe UA/UC {1} for area location {2} submitted on {3} {4}:{5} has been closed by {6}.\nKindly review and take appropriate action.\n\nThanks",
            uAUC.SafetyUser, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate.ToString("dd-MM-yyyy"), uAUC.Hours, uAUC.Minuts, curruser);
            string subject = string.Format("UAUC Dept Closure for {0}", uAUC.ObservationNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
        }

        public void ClosureMail(UAUC uAUC)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string subject = string.Format("UAUC Closure for {0}", uAUC.ObservationNo);

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == uAUC.DocumentedBy).ToList().FirstOrDefault()["Email"].ToString();
            string msgBody = string.Format("Hi {0},\n\nThe UA / UC {1} for area location {2} submitted on {3} {4}:{5} has been closed.\n\nThanks",
            uAUC.DocumentedBy, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate.ToString("dd-MM-yyyy"), uAUC.Hours, uAUC.Minuts);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);

            string mailTo1 = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == uAUC.AssigenedTo).ToList().FirstOrDefault()["Email"].ToString();
            string msgBody1 = string.Format("Hi {0},\n\nThe UA / UC {1} for area location {2} submitted on {3} {4}:{5} has been closed.\n\nThanks",
            uAUC.AssigenedTo, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate.ToString("dd-MM-yyyy"), uAUC.Hours, uAUC.Minuts, curruser);
            string subject1 = string.Format("UAUC Closure for {0}", uAUC.ObservationNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject1, msgBody1);
            GlobalDeclaration.SendMail(curruser, mailTo1, null, subject1, msgBody1);
        }

        public void ReOpenMail(UAUC uAUC)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == uAUC.AssigenedTo).ToList().FirstOrDefault()["Email"].ToString();
            string msgBody = string.Format("Hi {0},\n\nThe UA/UC {1} for area location {2} on {3} assigned to you has been reopened.\nKindly review and take appropriate action.\n\nThanks",
              uAUC.AssigenedTo, uAUC.ObservationNo, uAUC.PlantArea, uAUC.ObservationDate);
            string subject = string.Format("UAUC Reopened for {0}", uAUC.ObservationNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
        }

        //private void SendMail(string fromMail, string mailTo, string mailCc, string Subject, string msgBody)
        //{

        //    //string mailTo = null;
        //    string FromMailAddress = string.Empty;
        //    string MailPassword = string.Empty;
        //    //string mailCc = null;
        //    string xmsg = string.Empty;
        //    MailMessage mail;
        //    HindalcoiOS.Configuration.MailConfig mConfig = HindalcoiOS.Configuration.MailConfig.Instance;
        //    mConfig.GetMailConfig();
        //    try
        //    {

        //        mail = new MailMessage();
        //        FromMailAddress = mConfig.MailFrom;// "support@sparrowrms.in";
        //        MailPassword = mConfig.MailPassword;// "Zoq36865";
        //        mail.From = new MailAddress(FromMailAddress, fromMail);// "support@sparrowrms.in");
        //    }
        //    catch
        //    {
        //        xmsg = "Configure Proper Credentials in SettingOptions";
        //        throw new Exception(xmsg);
        //    }
        //    //mail.Attachments.Add(stream);


        //    mail.Subject = Subject;// sfCred.Subject;
        //    mail.Body = msgBody;

        //    if (!string.IsNullOrEmpty(mailTo))
        //    {
        //        if (mailTo.Contains(','))
        //        {
        //            foreach (var address in mailTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                string mailAddress = address.Trim();
        //                mail.To.Add(new MailAddress(mailAddress));
        //            }
        //        }
        //        else
        //        {
        //            string mailAddress = mailTo.Trim();
        //            mail.To.Add(new MailAddress(mailAddress));
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(mailCc))
        //    {
        //        if (mailCc.Contains(','))
        //        {
        //            foreach (var address in mailCc.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                string mailAddress = address.Trim();
        //                mail.CC.Add(new MailAddress(mailAddress));
        //            }
        //        }
        //        else
        //        {
        //            string mailAddress = mailCc.Trim();
        //            mail.CC.Add(new MailAddress(mailAddress));
        //        }
        //    }

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(mailTo) && !string.IsNullOrEmpty(FromMailAddress))
        //        {
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = mConfig.Host;// "smtp.office365.com";
        //            smtp.EnableSsl = mConfig.MailSSL;// true; 
        //            smtp.Timeout = 200000;
        //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            smtp.Port = int.Parse(mConfig.Port); //587;
        //            smtp.UseDefaultCredentials = false;
        //            NetworkCredential nc = new NetworkCredential(FromMailAddress, MailPassword);
        //            smtp.Credentials = nc;
        //            ServicePointManager.ServerCertificateValidationCallback =
        //        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //        { return true; };

        //            smtp.Send(mail);
        //            mail.Dispose();
        //            smtp.Dispose();
        //            //XtraMessageBox.Show("Mail Sent Successfully.");
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        //XtraMessageBox.Show("Mail setting/server not working, Configure and try again", "Jubilant Food System!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void Dispose()
        {
           
        }
    }
}
