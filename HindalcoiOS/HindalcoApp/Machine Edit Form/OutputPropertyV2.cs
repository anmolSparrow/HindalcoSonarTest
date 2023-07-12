using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Machine_Edit_Form
{
    public partial class OutPut_Property : XtraForm
    {
        public OutPut_Property()
        {
            InitializeComponent();
        }
        public OutPut_Property(string ReceiveMachineNAme, string sysgenno)
        {
            this.MachineNAme = ReceiveMachineNAme;
            this.SysGenNo = sysgenno;
            InitializeComponent();
        }
        private string SysGenNo = string.Empty;
        private string MachineNAme = string.Empty;
        private void OutPut_Property_Load(object sender, EventArgs e)
        {
            AddCheckbox();
            GridSeeting();
        }
        private void GridSeeting()
        {
            try
            {
                DGVOutput.BorderStyle = BorderStyle.Fixed3D;

                DGVOutput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVOutput.AllowUserToResizeColumns = false;

                DGVOutput.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DGVOutput.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DGVOutput.DefaultCellStyle.SelectionForeColor = Color.Black;
                DGVOutput.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DGVOutput.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DGVOutput.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Dictionary<string, Connector> _listconnt
        {
            get;
            set;
        }
        private void AddCheckbox()
        {
            try
            {
                string MachineNam = string.Empty;
                if (this._listconnt == null) return;
                DataTable OutPutdt = new DataTable();
                if (this._listconnt.Count > 0 && !string.IsNullOrEmpty(this.MachineNAme))
                {
                    OutPutdt.Columns.Add("Macros Connected", typeof(string));
                    OutPutdt.Columns.Add("Machine Tag", typeof(string));
                    OutPutdt.Columns.Add(new DataColumn("SC", typeof(bool)));
                    OutPutdt.Columns.Add(new DataColumn("Power", typeof(bool)));
                    OutPutdt.Columns["Macros Connected"].ReadOnly = true;
                    foreach (KeyValuePair<string, Connector> entry in _listconnt)
                    {
                        string MachineNumber = string.Empty;
                        Connector _Cnn = entry.Value;
                        if (_Cnn.FromData == this.MachineNAme)
                        {
                            string LineName = RemoveIntegers(entry.Key);
                            DataRow[] Update = OutPutdt.Select("[Macros Connected]='" + _Cnn.Connecto + "'");
                            if (Update.Length <= 0)
                            {
                                DataRow[] MachinTg = Resources.Instance.MachineDt.Select("CadLocation='" + _Cnn.ToDPoint + "'");
                                if (MachinTg.Length > 0)
                                {
                                    MachineNumber = MachinTg[0]["MachineTagNo"].ToString();
                                }
                                DataRow dr = OutPutdt.NewRow();
                                dr["Macros Connected"] = _Cnn.Connecto;//.Split('-')[1
                                dr["Machine Tag"] = MachineNumber;//.Split('-')[1];
                                LineName = RemoveIntegers(LineName);
                                if (LineName == "Electrical Cable" || LineName == "Bus Bar")
                                {
                                    dr["SC"] = false;
                                    dr["Power"] = true;
                                    OutPutdt.Columns["SC"].ReadOnly = true;
                                }
                                else if (LineName == "Pipe")
                                {
                                    dr["SC"] = true;
                                    dr["Power"] = false;
                                    OutPutdt.Columns["Power"].ReadOnly = true;

                                }
                                OutPutdt.Rows.Add(dr);
                            }
                        }
                    }
                }
                DGVOutput.DataSource = OutPutdt;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string RemoveIntegers(string input)
        {
            return Regex.Replace(input, @"[\d-]", string.Empty);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int rsulr = 0;
                string macros = string.Empty;
                if (DGVOutput.Rows.Count > 0)
                {
                    //foreach (DataGridViewRow row in DGVOutput.SelectedRows)
                    //{
                    //    macros = row.Cells["Macros Connected"].Value.ToString() + "_" + row.Cells["SC"].Value.ToString() + "_" + row.Cells["Power"].Value.ToString();

                    //}
                    //rsulr = Resources.Instance.InsertRecord("Sp_InsertMachineOutput", macros, this.Name);
                    for (int i = 0; i < DGVOutput.Rows.Count; i++)
                    {
                        macros = DGVOutput.Rows[i].Cells["Macros Connected"].Value.ToString() + "_" + DGVOutput.Rows[i].Cells["SC"].Value.ToString() + "_" + DGVOutput.Rows[i].Cells["Power"].Value.ToString();
                        macros = macros + "_" + this.SysGenNo + "_" + this.MachineNAme;
                        rsulr = Resources.Instance.InsertRecord("Sp_InsertMachineOutput", macros, this.Name);
                    }
                    if (rsulr > 0)
                    {
                        XtraMessageBox.Show("Details SuccessFully Save In Db.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void OutPut_PropertyUpd_Load(object sender, EventArgs e)
        {
            AddCheckbox();
            GridSeeting();
        }
    }
}
