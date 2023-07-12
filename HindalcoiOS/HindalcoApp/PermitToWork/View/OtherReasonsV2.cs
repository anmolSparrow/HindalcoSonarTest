using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections;
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
    public partial class OtherReasons : XtraForm
    {
        public OtherReasons()
        {
            InitializeComponent();
        }
        #region "varaible declaration"        
        public static bool isFormClosed = false;
        public static string permitType = "";
        public List<object> usedFormobject = new List<object>();
        #endregion

        private void btnAddReason_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Resources.Instance.AddPermitTypemaster(txtpermitName.Text, txtResson.Text, 1);
                if (i > 0)
                {
                    permitType = txtpermitName.Text;
                    timer1.Enabled = true;
                    MessageBox.Show("Record saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oops something went Wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == 2000)
            {
                this.Dispose();
                isFormClosed = true;

                // PermitQuestionnaire.ActiveForm.Activate();
                // usedFormobject.Add(PermitToWork.CreatePermit.formObject);
            }
        }
        public void DisposeAll(IEnumerable set)
        {
            try
            {
                foreach (Object obj in set)
                {
                    IDisposable disp = obj as IDisposable;
                    if (disp != null) { disp.Dispose(); }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OtherReasonsUpd_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            txtpermitName.Focus();
        }
    }
}
