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

namespace HindalcoiOS.InventoryMgmt
{
    public partial class MailDetailView : XtraForm
    {
        public event SomeEvents GetValue;
        private MailDetail mailDetail { get; set; }
        public MailDetailView()
        {
            mailDetail = new MailDetail();

            InitializeComponent();
        }
        public void MapMailDetailView()
        {
            mailDetail.MailTo = txtIMailto.Text;
            mailDetail.MailCc = txtIMailCc.Text;
            mailDetail.Subject = txtMailSubject.Text;
            mailDetail.Body = txtMailBody.Text;
        }


        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (ValidateMailDetail() == false) return;
            MapMailDetailView();
            this.GetValue.Invoke(mailDetail);
            DialogResult = DialogResult.OK;
        }
        private Boolean ValidateMailDetail()
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(txtIMailto.Text))
            {
                XtraMessageBox.Show("Please Fill MailTo");
                IsValid = false;
                txtIMailto.Focus();
            }

            else if (string.IsNullOrEmpty(txtMailSubject.Text))
            {
                DialogResult dRes = XtraMessageBox.Show("Want to send Email without Subject ?", "Alert", MessageBoxButtons.YesNo);
                if (dRes == DialogResult.Yes)
                {
                    txtMailSubject.Text = "No Subject";
                    IsValid = true;
                }
                else
                    IsValid = false;
            }
            else if (string.IsNullOrEmpty(txtMailBody.Text))
            {
                DialogResult dRes = XtraMessageBox.Show("Want to send Email without Body?", "Alert", MessageBoxButtons.YesNo);
                if (dRes == DialogResult.Yes)
                {
                    txtMailBody.Text = " ";
                    IsValid = true;
                }
                else
                    IsValid = false;
            }

            return IsValid;
        }
    }
}
