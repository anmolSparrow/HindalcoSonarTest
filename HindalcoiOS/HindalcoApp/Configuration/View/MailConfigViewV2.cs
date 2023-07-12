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
    public partial class MailConfigView : XtraForm
    {
        MailConfig mc;
        public MailConfigView()
        {
            InitializeComponent();
            mc = MailConfig.Instance;
            mc.GetMailConfig();
        }

        private void MailConfigView_Load(object sender, EventArgs e)
        {
            ViewMailConfig();

        }
        private void ViewMailConfig()
        {
            txtlMailSetHost.Text = mc.Host;
            txtlMailSetFrom.Text = mc.MailFrom;
            txtlMailSetPwd.Text = mc.MailPassword;
            txtlMailSetPort.Text = mc.Port;
            chklMailSetSSL.Checked = (mc.MailSSL == true ? true : false);
        }

        private void btnlMailSetAdd_Click(object sender, EventArgs e)
        {
            MapMailConfig();
        }
        private void MapMailConfig()
        {
            mc.Host = txtlMailSetHost.Text;
            mc.MailFrom = txtlMailSetFrom.Text;
            mc.MailPassword = txtlMailSetPwd.Text;
            mc.Port = txtlMailSetPort.Text;
            mc.MailSSL = chklMailSetSSL.Checked;
            mc.SetMailConfig(mc);
        }
    }
}
