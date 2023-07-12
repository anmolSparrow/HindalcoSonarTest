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

namespace HindalcoiOS.Models
{
   public class IncidentReport
    {
        public  string ReportNo { get; set; }
      //  public int ReportId { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime ReportTime { get; set; }
        public string EmployeeType { get; set; }
        public string Shift { get; set; }
        public string IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime IncidentTime { get; set; }
        public string IncidentLocation { get; set; }
        public string ExactLocation { get; set; }
        public string Description { get; set; }
        public string CorrectiveAction { get; set; }
        public string ObservedBy { get; set; }
        public string PersonInjured { get; set; }
        public string ReportedBy { get; set; }
        public string DocumentedBy { get; set; }
        public int DepartmentId { get; set; }
        public string PersonAge { get; set; }
        public string MachineTag { get; set; }
        public byte[] IncidentImage { get; set; }
        public string IncidentStatus { get; set; }
        public string OperationUnit { get; set; }
        public string is_localSaved { get; set; }
        public string is_Assigned { get; set; }
        public string AssignedToGM { get; set; }
        public DateTime ClosureDate { get; set; }
        public string AdminRemarks { get; set; }
        public string Hours { get; set; }
        public string Minuts { get; set; }

        public DataTable LoadAllUsers { set; get; }

        public DataTable GetAllUsers()
        {
            LoadAllUsers = Resources.Instance.GetUserDetails_RMPCL(2);
            return LoadAllUsers;
        }

        public void ReportIncidentMail(IncidentReport incReport)
        {
            GetAllUsers();
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<int>("RoleId") == 7).ToList().FirstOrDefault()["Email"].ToString();
            string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nAn incident {1} for Location {2} has been reported by {3} on {4}.\nKindly review and take appropriate action.\n\nThanks.",
                     mailToName, incReport.ReportNo,incReport.IncidentLocation, curruser, incReport.ReportDate);
            string subject = string.Format("Incident reported for {0}", incReport.ReportNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
        }

        public void RejectIncidentMail(IncidentReport incReport)
        {
            GetAllUsers();
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("EmpCode") == incReport.ObservedBy).ToList().FirstOrDefault()["Email"].ToString();
            string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nAn incident {1} reported by you on {2} for {3} has been rejected by {4}.\nKindly review and take appropriate action.\n\nThanks.",
                     mailToName, incReport.ReportNo, incReport.ReportDate, incReport.IncidentLocation, curruser);
            string subject = string.Format("Incident Rejected for {0}", incReport.ReportNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
        }
        public void CloseIncidentMail(IncidentReport incReport)
        {
            GetAllUsers();
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("EmpCode") == incReport.ObservedBy).ToList().FirstOrDefault()["Email"].ToString();
            string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nAn incident {1} reported by you on {2} for {3} has been closed by {4}.\nKindly review and take appropriate action.\n\nThanks.",
                     mailToName, incReport.ReportNo, incReport.ReportDate, incReport.IncidentLocation, curruser);
            string subject = string.Format("Incident Closed for {0}", incReport.ReportNo);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
            GlobalDeclaration. SendMail(curruser, mailTo, null, subject, msgBody);
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
}
