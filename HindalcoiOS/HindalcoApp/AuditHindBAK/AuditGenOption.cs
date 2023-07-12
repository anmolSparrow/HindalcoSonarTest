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

namespace RMPCLApp.AuditHind
{
    public partial class AuditGenOption : XtraForm
    {
        public event SomeEvents GetValue;
        public AuditGenOption()
        {
            InitializeComponent();
        }

        private void btnGenPlan_Click(object sender, EventArgs e)
        {
            if (GetValue != null)
            {
                GetValue.Invoke(cmbAuditType.Text,cmbYear,cmbQuater.Text);
                DialogResult = DialogResult.OK;
            }

        }
    }
}
