using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Configuration
{
    public sealed class MailConfig
    {
        // private static Singleton instance; (instead of this, it should be like this, see below)
        private static MailConfig instance = new MailConfig();

        static MailConfig() { }

        private MailConfig() { }

        public static MailConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MailConfig();
                    instance.GetMailConfig();
                }
                return instance;
            }
        }
        public string Host { set; get; }
        public string Port { set; get; }
        public string MailFrom { set; get; }
        public string MailPassword { set; get; }
        public bool MailSSL { set; get; }


        public void GetMailConfig()
        {
            DataTable dt= Resources.Instance.GetMailConfig();
            if (dt.Rows.Count > 0)
            {
                Host = dt.Rows[0]["Host"].ToString();
                Port = dt.Rows[0]["Port"].ToString();
                MailFrom = dt.Rows[0]["MailFrom"].ToString();
                MailPassword = dt.Rows[0]["MailPassword"].ToString();
                MailSSL = int.Parse(dt.Rows[0]["SSL"].ToString()) == 1 ? true : false;
            }
        }
        public void SetMailConfig(MailConfig mailConfig)
        {
            Resources.Instance.AddMailConfig(mailConfig.Host,mailConfig.Port,mailConfig.MailFrom,mailConfig.MailPassword,mailConfig.MailSSL);
        }
    }
}
