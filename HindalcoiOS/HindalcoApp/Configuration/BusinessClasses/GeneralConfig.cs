using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Configuration
{
    public sealed class GeneralConfig
    {
        // private static Singleton instance; (instead of this, it should be like this, see below)
        private static GeneralConfig instance = new GeneralConfig();

        static GeneralConfig() { }

        private GeneralConfig() { }

        public static GeneralConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GeneralConfig();
                    instance.GetGeneralConfig();
                }
                return instance;
            }
        }
        public string DashboardUrl { set; get; }
        //public string Port { set; get; }
        //public string MailFrom { set; get; }
        //public string MailPassword { set; get; }
        //public bool MailSSL { set; get; }


        public void GetGeneralConfig()
        {
            DataTable dt= Resources.Instance.GetGeneralConfig();
            if(dt.Rows.Count>0)
            DashboardUrl = dt.Rows[0]["DasboardUrl"].ToString();
            //Port = dt.Rows[0]["Port"].ToString();
            //MailFrom = dt.Rows[0]["MailFrom"].ToString();
            //MailPassword = dt.Rows[0]["MailPassword"].ToString();
            //MailSSL =int.Parse(dt.Rows[0]["SSL"].ToString())==1?true:false;
        }
        public void SetMailConfig(GeneralConfig gnConfig)
        {
            Resources.Instance.AddGeneralConfig(gnConfig.DashboardUrl);
        }
    }
}
