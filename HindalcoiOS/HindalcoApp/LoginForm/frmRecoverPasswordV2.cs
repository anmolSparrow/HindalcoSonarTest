using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Login_Form
{

    public partial class frmRecoverPassword : XtraForm
    {
        public string result;
        public string question;
        public event SomeEvents GetValue;
        public frmRecoverPassword()
        {
            InitializeComponent();
        }

        private void RecoverPassword_Load(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox3.Hide();
        }

        private void BtnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                Resources.Instance.spCheckEmail(txtEmailID.Text, "CheckEmail", ref result, ref question, txtAnswer.Text, txtConfirmNewPassword.Text);
                XtraMessageBox.Show(result, ApplicationConstants.MessageDisplay,
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                if (result == "Please answer the security Question.")
                {
                    txtQuestion.Text = question;
                    txtQuestion.Enabled = false;
                    groupBox2.Show();
                    groupBox3.Hide();
                }
                else
                {
                    txtQuestion.Text = "";
                    groupBox2.Hide();
                    groupBox3.Hide();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Resources.Instance.spCheckEmail(txtEmailID.Text, "CheckSecurity", ref result, ref question, txtAnswer.Text, txtConfirmNewPassword.Text);
                XtraMessageBox.Show(result, ApplicationConstants.MessageDisplay,
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                if (result == "Enter your password!")
                {
                    txtQuestion.Text = question;
                    groupBox3.Show();
                }
                else
                {
                    //txtQuestion.Text = "";
                    groupBox3.Hide();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                {

                    Resources.Instance.spCheckEmail(txtEmailID.Text, "ChangePassword", ref result, ref question, txtAnswer.Text, txtConfirmNewPassword.Text);
                    XtraMessageBox.Show(result,
                        ApplicationConstants.MessageDisplay,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtEmailID.Text = "";
                    txtAnswer.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmNewPassword.Text = "";
                    txtQuestion.Text = "";
                    groupBox2.Hide();
                    groupBox3.Hide();
                }
                else
                {
                    MessageBox.Show("Password does not matching");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtEmailID__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
