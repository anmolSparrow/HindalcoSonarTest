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

namespace HindalcoiOS.AuditHind
{
    public partial class AuditMessage : XtraForm
    {
        public event SomeEvents GetValue;
        public AuditMessage()
        {
            InitializeComponent();
        }
        
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GetValue != null)
            {
                GetValue.Invoke(txtRejectMsg.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void AuditMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
