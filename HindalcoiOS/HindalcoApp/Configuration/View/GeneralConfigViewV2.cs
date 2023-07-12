using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Configuration
{
    public partial class GeneralConfigView : XtraForm
    {
        GeneralConfig mc;
        public GeneralConfigView()
        {
            InitializeComponent();
            mc = GeneralConfig.Instance;
            mc.GetGeneralConfig();
        }

        private void MailConfigView_Load(object sender, EventArgs e)
        {
            ViewMailConfig();

        }
        private void ViewMailConfig()
        {
            txtDashboardUrl.Text = mc.DashboardUrl;
            //txtlMailSetFrom.Text = mc.MailFrom;
            //txtlMailSetPwd.Text = mc.MailPassword;
            //txtlMailSetPort.Text = mc.Port;
            //chklMailSetSSL.Checked = (mc.MailSSL == true ? true : false);
        }

        private void btnlMailSetAdd_Click(object sender, EventArgs e)
        {
            MapMailConfig();
        }
        private void MapMailConfig()
        {
            mc.DashboardUrl = txtDashboardUrl.Text;
           
            mc.SetMailConfig(mc);
        }
    }
}
