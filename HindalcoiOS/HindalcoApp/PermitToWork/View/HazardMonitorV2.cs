using DevExpress.XtraEditors;
using log4net;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.PermitToWork
{
    public partial class HazardMonitor : XtraForm
    {
        public HazardMonitor()
        {
            InitializeComponent();
            //this.lblHazard.Size = new System.Drawing.Size(48, 20);
        }
       // public static readonly ILog Log = LogHelper.GetLogger();
        public static string hazardet;
        public static bool validresp = false;
        private void HazardMonitor_Load(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                hazardet = txthazardesc.Text;
                validresp = true;
                this.Close();
                this.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
