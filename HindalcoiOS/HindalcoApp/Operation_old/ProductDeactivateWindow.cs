using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using RMPCLApp.DAL;
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

namespace RMPCLApp.Operation
{
    public partial class ProductDeactivateWindow : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> updateActivatedEvent;
        public Operation.BusinessClasses.ProductMaster prodMaster { get; set; }

        public ServiceDAL DalService { get; set; }
        public EventHandler<string> UpdateTimeInterval;

        private DataTable prodData { get; set; }
        private int IsActiveToken { get; set; }
        public enum PlantName
        {
            None,
            PSSP,
            GSSP
        }
        public ProductDeactivateWindow()
        {
            DalService = new ServiceDAL();
            prodMaster = new Operation.BusinessClasses.ProductMaster();
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

     
        private void ProductDeactivateWindow_Load(object sender, EventArgs e)
        {
            try
            {
                var arr = Enum.GetValues(typeof(PlantName));
                var abc = arr.GetValue(0);
                abc= abc.ToString().Replace("None", "N/A");
                string[] bcd = new string[3] {"","","" };
                bcd[0] = abc.ToString();
                bcd[1] = arr.GetValue(1).ToString();
                bcd[2]= arr.GetValue(2).ToString();
                cmbPlantName.DataSource = bcd;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    private void cmbPlantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                prodData = prodMaster.GetProductDataPlantWise(cmbPlantName.Text, "", "", DateTime.Now, "", "", 0, 2, 1, DateTime.Now, DateTime.Now);
                cmbProdName.Items.Clear();
                if (cmbPlantName.Text == "None")
                {
                    cmbPlantName.Items.Clear();
                }
                else
                {
                    for (int n = 0; n < prodData.Rows.Count; n++)
                    {
                        cmbProdName.Items.Add(prodData.Rows[n][4]);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbActivate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(rdbActivate.Checked==true)
                {
                    dtpFrom.Enabled = false;
                    dtpTo.Enabled = false;
                    IsActiveToken = 1;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDeActivate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbDeActivate.Checked == true)
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    IsActiveToken = 0;
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

                prodData = Resources.Instance.GetProductMaster_RMPCL(cmbPlantName.Text, GlobalDeclaration.ProdCode, cmbProdName.Text, DateTime.Now, "", "", 0, 5, IsActiveToken,Convert.ToDateTime( dtpFrom.Value),Convert.ToDateTime( dtpTo.Value));
               if(IsActiveToken==0)
                {
                    XtraMessageBox.Show("Product Deactivated successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "InActive";
                    lblStatus.ForeColor = Color.Red;
                }
                else
                {
                    XtraMessageBox.Show("Product Activated successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "Active";
                    lblStatus.ForeColor = Color.Green;

                }

                if (updateActivatedEvent != null)
                updateActivatedEvent.Invoke(sender, "");
                this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var countryIDs = prodData.AsEnumerable().Where(row => row.Field<String>("ProdName") == cmbProdName.Text).FirstOrDefault();
            if (countryIDs != null)
            {
               GlobalDeclaration.ProdCode= countryIDs[2].ToString();
                if((countryIDs[7].ToString())=="1")
                {
                    lblStatus.Text = "Active";
                    lblStatus.ForeColor = Color.Green;
                    rdbActivate.Checked = true;
                    rdbActivate.Enabled = false;
                }
                else
                {
                    if (countryIDs[8].GetType().IsValueType)
                    {
                        lblStatus.Text = "InActive";
                        lblStatus.ForeColor = Color.Red;
                        dtpFrom.Value = Convert.ToDateTime(countryIDs[8]);
                        dtpTo.Value = Convert.ToDateTime(countryIDs[9]);
                        rdbDeActivate.Checked = true;
                        rdbDeActivate.Enabled = false;
                    }
                }
            }
        }
    }
}