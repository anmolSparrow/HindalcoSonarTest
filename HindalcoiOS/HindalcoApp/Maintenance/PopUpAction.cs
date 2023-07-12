using HindalcoiOS.Class_Operation;
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

namespace HindalcoiOS.U1FormCollection
{
    public partial class PopUpAction : DevExpress.XtraEditors.XtraForm
    {
        public string DateStatus = string.Empty;
        public DateTime FreezedDate { get; set; }
        public PopUpAction()
        {
            InitializeComponent();
        }

        private void PopUpAction_Load(object sender, EventArgs e)
        {
            if (FreezedDate.Date >= DateTime.Now.Date)
            {
                btndatePiker.MinDate = DateTime.Now.Date;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
                if (keyData == Keys.Escape)
                {
                    this.Close();
                    return true;
                }
          
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
               // DateTime dateTime = this.btndatePiker.Value;
                //if (DateStatus == "Preponed")
                //{
                //    if (dateTime >= DateTime.Now)
                //    {
                       DialogResult = DialogResult.OK;
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show("You are not able to select previous date .\n Please Select Valid Date.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        DialogResult = DialogResult.None;
                //    }
                //}
                //else
                //{
                //    if (dateTime > DateTime.Now)
                //    {
                //        DialogResult = DialogResult.OK;
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show("Please Select Future Date.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        DialogResult = DialogResult.None;

                //    }
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }     
        
    }
}
