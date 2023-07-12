using DevExpress.XtraEditors;
using ExcelDataReader;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.U1FormCollection
{
    public partial class UploadReportFrm : XtraForm
    {
        public UploadReportFrm()
        {
            InitializeComponent();
        }

        private void UploadReportFrm_Load(object sender, EventArgs e)
        {
            this.Text = "Upload Download Format.";
            UpdateTextPosition();
            txtfile.Text = "";
            sheetCombo.Enabled = false;
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;

                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                this.Text = tmp + this.Text.Trim();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnbrowser_Click(object sender, EventArgs e)
        {
            var obd = openFileDialog1.ShowDialog();
            // openFileDialog1.Filter = "Supported files | *.xls; *.xlsx; *.xlsb; *.csv | xls | *.xls | xlsx | *.xlsx | xlsb | *.xlsb | csv | *.csv | All | *.*";           
            if ((obd != DialogResult.OK) || (string.IsNullOrEmpty(openFileDialog1.FileName)))
            {
                return;
            }
            string[] s = (openFileDialog1.FileName.ToString()).Split('\\');
            int count = s.Length;
            string FileName = s[count - 1].Split('.')[0];
            txtfile.Text = FileName;
            var stream = new FileStream(openFileDialog1.FileName.ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            ds = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                UseColumnDataType = false,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true

                }
            }); ;
            var tablenames = GlobalDeclaration.GetTablenames(ds.Tables);
            sheetCombo.Enabled = true;
            sheetCombo.DataSource = tablenames;
            
        }
        public DataSet ds;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Upload Maintenance Excel Sheet  from Drive
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                //if (tablenames.Count > 0)
                //sheetCombo.SelectedIndex = 0;

                DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Please Browse File", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string SelectTable()
        {
            string tablename=string.Empty;
            if (sheetCombo.SelectedItem!=null)
             tablename = sheetCombo.SelectedItem.ToString();

            //dgventry.AutoGenerateColumns = true;
            //dgventry.DataSource = ds; // dataset
            //dgventry.DataMember = tablename;
            //GetValues(ds, tablename);
            return tablename;
        }
        public void GetValues(DataSet dataset, string sheetName)
        {
            try
            {
                int uu = dataset.Tables[sheetName].Rows.Count;
                for (int i = 0; i < dataset.Tables[sheetName].Rows.Count; i++)
                {
                    DataRow row = dataset.Tables[sheetName].Rows[i];
                    //DataRow dr = GlobalDeclaration._maintenancclm.NewRow();
                    //GlobalDeclaration._maintenancclm.Rows.Add(dr);
                    //int rowidex = dgventry.Rows.Count - 1;
                    //dgventry.Rows[rowidex].Cells["S.No"].Value = row["S.NO"].ToString();//row.Table.Columns[i].ToString()
                    //dgventry.Rows[rowidex].Cells["clmMachineTag"].Value = "ABBBB";
                    //dgventry.Rows[rowidex].Cells["clmMachineName"].Value = "ZZZZZZZ0";
                    //// dgventry.Rows[i].Cells["ItemActivity"].Value = row["Item (Activity)"].ToString();
                    ////dgventry.Rows[i].Cells["cmbitmactvty"].Value = row["Pick team"].ToString();
                    //dgventry.Rows[rowidex].Cells["Date_of_Last_Maintenance"].Value = Convert.ToDateTime(row["Date of last maintenance"]);
                    //// dgventry.Rows[i].Cells["cmboutsorce"].Value = row["Outsourced/ inhouse"].ToString();
                    //// dgventry.Rows[i].Cells["ShtdwnReq"].Value = row["Shut down Req"].ToString();
                    ////dgventry.Rows[i].Cells["cmbexpct"].Value = row["Expected time to complete (hr)"].ToString();
                    ////dgventry.Rows[i].Cells["cmbresponce"].Value = row["type of response"].ToString();
                    ////dgventry.Rows[i].Cells["cmbRsult"].Value = row["result (Ok/Not Ok)"].ToString();
                    //dgventry.Rows[rowidex].Cells["Observation_(visual_only)"].Value = row["Observation  (visual only)"].ToString();
                    //dgventry.Rows[rowidex].Cells["Observation_(Numeric/test etc.)"].Value = row["Observation (Numeric/test etc.)"].ToString();
                    ////dgventry.Rows[i].Cells["cmbDeviations"].Value = row["Deviations"].ToString();
                    //dgventry.Rows[rowidex].Cells["criticality"].Value = row["criticality"].ToString();
                    ////dgventry.Rows[i].Cells["Upload"].Value = _GlobalCAPAtbl.Rows[i]["Upload"].ToString();
                    //dgventry.Rows[rowidex].Cells["Input"].Value = row["Input "].ToString();
                    //dgventry.Rows[rowidex].Cells["Identified_Risk"].Value = row["Identified Risk"].ToString();
                    //dgventry.Rows[rowidex].Cells["Special_tools"].Value = row["Special tools"].ToString();
                    //dgventry.Rows[rowidex].Cells[19].Value = row["PPE List"].ToString();



                    //Datechange();
                    // dgventry.CellFormatting += Dgventry_CellFormatting;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SheetComboSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTable();

        }
    }
}
