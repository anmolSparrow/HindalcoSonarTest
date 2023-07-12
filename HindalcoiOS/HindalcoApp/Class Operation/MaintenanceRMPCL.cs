using DevExpress.XtraEditors;
using SparrowRMS;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace HindalcoiOS.Class_Operation
{
    /// <summary>
    /// This is for mapping form text value
    /// </summary>
    public class MaintenanceRMPCL
    {
        public DateTime Date { get; set; }
        public string MaintenanceCode { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public string MachineTag { get; set; }
        public string Others { get; set; }
        public string ReportedBy { get; set; }
        public string AssignTo { get; set; }
        public string Comments { get; set; }
        public decimal TimeInHr { get; set; }
        public decimal TimeInMinutes { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public string ExactLocation { get; set; }
        public OperationPlant OperationPlant { get; set; }
        public FormStatus FormStatus { get; set; }
        public bool CallingLocation { get; set; }
        public string InventoryCode { get; set; }
        public string InventoryReturnCode { get; set; }
        public bool IsMaintenanceRequired { get; set; }
        public string FormName { get; set; }
        public int IsLoadBRKMNT { get; set; }
        public BrkStatus brkStatus { get; set; }

        public string Breakdowncode { get; set; }

        public DataTable LoadAllUsers { set; get; }

        public DataTable GetAllUsers()
        {
            LoadAllUsers = Resources.Instance.GetUserDetails_RMPCL(2);
            return LoadAllUsers;
        }

       public void ClosureUpdate(MaintenanceRMPCL mainteRMPCL)
       {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string currUserCode = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == curruser).ToList().FirstOrDefault()["EmpCode"].ToString();
            Resources.Instance.UpdateCloseMaintBreakDown(mainteRMPCL.Breakdowncode, curruser, currUserCode);
       }
        public void SubmitBreakdownMail(MaintenanceRMPCL mainteRMPCL)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            var mailsTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<int>("RoleId") == 3).ToList().CopyToDataTable();

            foreach (DataRow dr in mailsTo.Rows)
            {
                string mailTo = dr["Email"].ToString();

                string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
                string msgBody = string.Format("Hi {0},\n\nA breakdown {1} has been reported by {2} on {3} for Operation Plant {4}.\nKindly review and take appropriate action.\n\nThanks.",
                         mailToName, mainteRMPCL.Breakdowncode, curruser, mainteRMPCL.Date, mainteRMPCL.OperationPlant.ToString());
                string subject = string.Format("Breakdown reported for {0}", mainteRMPCL.Breakdowncode);
                //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
                GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            }

           
        }

        public void BreakdownClosureMail(MaintenanceRMPCL mainteRMPCL)
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == mainteRMPCL.ReportedBy).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA breakdown {1} reported by you on {2} for Operation Plant {3} has been closed by {4}.\n\nThanks.",
                     mainteRMPCL.ReportedBy, mainteRMPCL.Breakdowncode, mainteRMPCL.Date, mainteRMPCL.OperationPlant.ToString(), curruser);
            string subject = string.Format("Breakdown Closed for {0}", mainteRMPCL.Breakdowncode);
           // GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
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
    }
    public enum Status
    {
        Prepare = 1,
        Closed = 3,
        Pending = 5,
        Open = 26,
        Rejected = 7,
        ForApporval = 4,
        Approved = 9,
        Reported = 15,
        Submitted = 10
    }
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
    public enum OperationPlant
    {
        PSSP = 0,
        GSSP = 1,
        Others = 3
    }
    public enum FormStatus
    {
        New = 0,
        Summary = 1,
        Closed = 2,
        MachineInfo = 5
    }
    public enum BrkStatus
    {
        Prepare = 0,
        Reported = 1,
        Closed = 2,
        Submitted = 3

    }
}
