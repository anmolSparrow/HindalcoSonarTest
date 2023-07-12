using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.DAL;
using HindalcoiOS.Models;
using System;
using System.Windows.Forms;

namespace HindalcoiOS.Operation
{
    public partial class AddUnit : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> updateUnitEvent;
        public UnitMaster unitMaster { get; set; }
        public ServiceDAL DalService { get; set; }
        public AddUnit()
        {
            DalService = new ServiceDAL();
            unitMaster = new UnitMaster();
            InitializeComponent();
        }
        int retVal = 0;

        private int ObjectToDALMApper()
        {
            retVal = DalService.AddUnitMaster(unitMaster, 1);
            return retVal;
        }
        private void ObjectToClassMapper()
        {
            try
            {
                unitMaster.UnitName = txtUnitName.Text;
                retVal = ObjectToDALMApper();
                if (retVal > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Record saved successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Oops something went wrong!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUnitName.Text == "")
                {
                    lblErr.Visible = true;
                }
                if (lblErr.Visible == false)
                {
                    ObjectToClassMapper();
                    if (updateUnitEvent != null)
                        GlobalDeclaration.dayList = txtUnitName.Text;
                    updateUnitEvent.Invoke(sender, GlobalDeclaration.dayList);
                    this.Close();
                    this.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUnitName.Text = "";
        }

        private void AddUnit_Load(object sender, EventArgs e)
        {
            try
            {
                lblErr.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {
            if (txtUnitName.Text != "")
            {
                lblErr.Visible = false;
            }
        }
    }
}