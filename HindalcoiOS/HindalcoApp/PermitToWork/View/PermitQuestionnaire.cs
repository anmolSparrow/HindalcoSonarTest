using RMPCLApp.Class_Operation;
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
using SparrowRMS;

namespace RMPCLApp.PermitToWork
{
    public delegate void PermitQuestionEvents(params object[] objec);
    public partial class PermitQuestionnaire : XtraForm
    {
        public delegate void delPassData(string  PermitType);
        public PermitQuestionnaire()
        {
            InitializeComponent();
        }
        #region "variable declaration" 
        public event PermitQuestionEvents PermitQtsEvent;
        List<CheckBox> chkBx = new List<CheckBox>();
        int checkedIndex;
        int chkbxcnt;
        public static bool isOthers = false;
        bool isPageLoad = false;
        OtherReasons reason = new OtherReasons();
        #endregion

        private void ChkB8_CheckedChanged(object sender, EventArgs e)
        {
            //if (ChkB8.Checked == true)
            //{
            //    OtherReasons reason = new OtherReasons();
            //    reason.Show();
            //}
        }

        private void rdbQ1Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //isPageLoad = true;
                if (rdbQ1Y.Checked == true)
                {
                    chkBx[1].Checked = true;
                    checkedIndex = 1;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rdbQ1N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ1N.Enabled == true)
                {
                    chkBx[3].Checked = true;
                    checkedIndex = 3;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ2Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ2Y.Enabled == true)
                {
                    chkBx[1].Checked = true;
                    checkedIndex = 1;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ2N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ2N.Enabled == true)
                {
                    chkBx[3].Checked = true;
                    checkedIndex = 3;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ3Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ3Y.Enabled == true)
                {
                    chkBx[2].Checked = true;
                    checkedIndex = 2;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ3N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ3N.Enabled == true)
                {
                    chkBx[2].Checked = true;
                    checkedIndex = 2;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        chkBx[i].Checked = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ4Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ4Y.Enabled == true)
                {
                    chkBx[0].Checked = true;
                    checkedIndex = 0;
                    chkbxcnt = chkBx.Count;

                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ4N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ4N.Enabled == true)
                {
                    chkBx[0].Checked = true;
                    checkedIndex = 0;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        chkBx[i].Checked = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbq5Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbq5Y.Enabled == true)
                {
                    chkBx[5].Checked = true;
                    checkedIndex = 5;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ5N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ5N.Enabled == true)
                {
                    chkBx[0].Checked = true;
                    checkedIndex = 0;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        chkBx[i].Checked = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ6Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbq5Y.Enabled == true)
                {
                    chkBx[4].Checked = true;
                    checkedIndex = 4;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbQ6N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ6N.Enabled == true)
                {
                    chkBx[0].Checked = true;
                    checkedIndex = 0;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        chkBx[i].Checked = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbQ7Y_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ7Y.Enabled == true)
                {
                    chkBx[6].Checked = true;
                    checkedIndex = 6;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        if (i != checkedIndex)
                        {
                            chkBx[i].Checked = false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbQ7N_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbQ7N.Enabled == true)
                {
                    chkBx[0].Checked = true;
                    checkedIndex = 0;
                    chkbxcnt = chkBx.Count;
                    for (int i = 0; i < chkbxcnt; i++)
                    {
                        chkBx[i].Checked = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PermitQuestionnaire_Load(object sender, EventArgs e)
        {
            try

            {
                DataTable chkBoxLst = null;
                bool isOtherReason = PermitToWork.OtherReasons.isFormClosed;
                if (isOtherReason == false)
                {
                     chkBoxLst = Resources.Instance.GetPermitTypemaster("", "", 2);

                }
                else
                {
                    chkBoxLst = Resources.Instance.GetPermitTypemaster("", "", 2);
                }
                string preText = "CHK";
                int a = 1;
                foreach (DataRow row in chkBoxLst.Rows)
                {
                    CheckBox chk = new CheckBox();
                    chk.Tag = preText + 'B' + a;
                    chk.Width = 200;
                    chk.Text = row["permitName"].ToString();
                    chk.CheckedChanged += new EventHandler(CheckBox_Checked);
                    flPanel1.Controls.Add(chk);
                    chkBx.Add(chk);
                    a = a + 1;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DeselectRadioButton();
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (sender as CheckBox);
                if (chk.Checked)
                {

                    for (int i = 0; i < flPanel1.Controls.Count; i++)
                    {
                        if (flPanel1.Controls[i] is CheckBox)
                        {
                            if (((CheckBox)(flPanel1.Controls[i])).Checked == true && i == chkbxcnt - 1)
                            {
                                // DeselectRadioButton();
                                for (int a = 0; a < flPanel1.Controls.Count; a++)
                                {
                                    ((CheckBox)(flPanel1.Controls[i])).Checked = false;

                                }

                                reason.Show();
                            }
                            else
                            {
                                //  ((CheckBox)(flPanel1.Controls[i])).Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeselectRadioButton()
        {
            rdbQ1Y.Checked = false;
            rdbQ1N.Checked = false;
            rdbQ2Y.Checked = false;
            rdbQ2N.Checked = false;
            rdbQ3Y.Checked = false;
            rdbQ3N.Checked = false;
            rdbQ4Y.Checked = false;
            rdbQ4N.Checked = false;
            rdbq5Y.Checked = false;
            rdbQ5N.Checked = false;
            rdbQ6Y.Checked = false;
            rdbQ6N.Checked = false;
            rdbQ7Y.Checked = false;
            rdbQ7N.Checked = false;

        }

        private void flPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void flPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            try
            {
                CheckBox chb = new CheckBox();
                if (flPanel1.Contains(chb))
                {
                    chb.CheckedChanged += new EventHandler(CheckBox_Checked);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flPanel1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < flPanel1.Controls.Count; i++)
                {
                    if (flPanel1.Controls[i] is CheckBox)
                    {
                        if (((CheckBox)(flPanel1.Controls[i])).Checked == true && i == chkbxcnt)
                        {
                            isOthers = true;
                            OtherReasons reason = new OtherReasons();
                            reason.Show();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void flPanel1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                for (int m = 0; m < flPanel1.Controls.Count; m++)
                {
                    if (flPanel1.Controls[m] is CheckBox)
                    {
                        if (((CheckBox)(flPanel1.Controls[m])).Checked == true)
                        {
                            Class_Operation.GlobalDeclaration.PermitType = flPanel1.Controls[m].Text;
                            //CreatePermit permtFrm = new CreatePermit();

                            //int count = Application.OpenForms.Count;
                            //var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "CreatePermit").FirstOrDefault();
                            //if (null != frm)
                            //{
                            //    //frm.Show();
                            //    //  frm = null;

                            //    delPassData del = new delPassData(frm.Name.GetPermitType);
                            //    del(Class_Operation.GlobalDeclaration.PermitType);

                            //}

                            //  permtFrm.Show();
                            //int count=   Application.OpenForms.Count;
                            //var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "CreatePermit").FirstOrDefault();
                            //if (null != frm)
                            //{
                            //    frm.Show();
                            //  //  frm = null;

                            //}
                            // permtFrm.Show();

                            //CreatePermit frmInstance = CreatePermit.getInstance();

                            //frmInstance.  = this.textBox1.Text;
                            //this.Close();
                            
                        }
                    }

                }
               
                if (Class_Operation.GlobalDeclaration.PermitType != "")
                {
                    MessageBox.Show("Permit Type Defined successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (PermitQtsEvent != null)
                {
                    PermitQtsEvent.Invoke(Class_Operation.GlobalDeclaration.PermitType);//txtinhandqty.Text);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
           
        }
    }
}
