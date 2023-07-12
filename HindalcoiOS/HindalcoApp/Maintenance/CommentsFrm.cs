using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using System;
using System.Windows.Forms;

namespace HindalcoiOS.Maintenance
{
    public partial class CommentsFrm : DevExpress.XtraEditors.XtraForm
    {
        public CommentsFrm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.Escape)
            {
                this.Close();
                DialogResult = DialogResult.None;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtcomments.Text=="")
            {
                XtraMessageBox.Show("Please Enter your Comments First!!!!",
                                  ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void lblComments_Click(object sender, EventArgs e)
        {

        }

        private void txtcomments__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
