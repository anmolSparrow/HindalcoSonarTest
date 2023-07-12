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
    public partial class Input_Property : XtraForm
    {
        private string SysGenNo = string.Empty;
        private string MachineNAme = string.Empty;
        public Input_Property()
        {
            InitializeComponent();
            //this.Text = "My Test";
        }
        public Input_Property(string sysgenno, string ReceiveMachineNAme)
        {
            InitializeComponent();
            this.MachineNAme = ReceiveMachineNAme;
            this.SysGenNo = sysgenno;

        }

        public Dictionary<string, List<string>> ReceiveConValue
        {
            get;
            set;
        }
        public Dictionary<string, Connector> _listconnt
        {
            get;
            set;
        }
        private void Input_Property_Load(object sender, EventArgs e)
        {

            AddCheckbox();

        }
        DataTable colmkist = new DataTable();
        private void AddCheckbox()
        {
            try
            {
                if (this._listconnt == null) return;
                if (this._listconnt.Count > 0 && !string.IsNullOrEmpty(this.MachineNAme))
                {
                    colmkist.Columns.Add("Macros Connected", typeof(string));
                    colmkist.Columns.Add(new DataColumn("Machine Tag", typeof(string)));
                    colmkist.Columns.Add(new DataColumn("SC", typeof(bool)));
                    colmkist.Columns.Add(new DataColumn("Power", typeof(bool)));
                    colmkist.Columns["Macros Connected"].ReadOnly = true;
                    foreach (KeyValuePair<string, Connector> entry in _listconnt)
                    {
                        string MachineNumber = string.Empty;
                        Connector _Cnn = entry.Value;
                        if (_Cnn.Connecto == this.MachineNAme)
                        {
                            string LineName = RemoveIntegers(entry.Key);
                            DataRow[] Update = colmkist.Select("[Macros Connected]='" + _Cnn.FromData + "'");
                            if (Update.Length <= 0)
                            {
                                DataRow[] MachinTg = Resources.Instance.MachineDt.Select("CadLocation='" + _Cnn.FromDPoint + "'");
                                if (MachinTg.Length > 0)
                                {
                                    MachineNumber = MachinTg[0]["MachineTagNo"].ToString();
                                }
                                DataRow dr = colmkist.NewRow();
                                dr = colmkist.NewRow();
                                dr["Macros Connected"] = _Cnn.FromData;//.Split('-')[1];
                                dr["Machine Tag"] = MachineNumber;
                                if (LineName == "Electrical Cable" || LineName == "Bus Bar")
                                {
                                    dr["SC"] = false;
                                    dr["Power"] = true;
                                    colmkist.Columns["SC"].ReadOnly = true;
                                }
                                else if (LineName == "Pipe")
                                {
                                    dr["SC"] = true;
                                    dr["Power"] = false;
                                    colmkist.Columns["Power"].ReadOnly = true;
                                }
                                colmkist.Rows.Add(dr);
                            }
                        }
                    }
                    // CheckBox chkbox = new CheckBox();
                    dgvInputppty.DataSource = colmkist;
                }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int rsulr = 0;
                string macros = string.Empty;
                if (dgvInputppty.Rows.Count > 0)
                {
                    //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    //{
                    //    macros = row.Cells["Macros Connected"].Value.ToString() + "_" + row.Cells["SC"].Value.ToString() + "_" + row.Cells["Power"].Value.ToString();

                    //}

                    for (int i = 0; i < dgvInputppty.Rows.Count; i++)
                    {
                        macros = dgvInputppty.Rows[i].Cells["Macros Connected"].Value.ToString() + "_" + dgvInputppty.Rows[i].Cells["SC"].Value.ToString() + "_" + dgvInputppty.Rows[i].Cells["Power"].Value.ToString();
                        macros = macros + "_" + this.SysGenNo + "_" + this.MachineNAme;
                        rsulr = Resources.Instance.InsertRecord("Sp_InsertMachineInput", macros, this.Name);
                    }

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
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
