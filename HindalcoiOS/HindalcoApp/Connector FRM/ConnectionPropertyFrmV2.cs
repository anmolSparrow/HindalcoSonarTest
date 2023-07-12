
using CADImport;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Connector_FRM
{
    public delegate void updateTabPage(string Name);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 0)]
    public struct Connector
    {
        public string FromData;
        public string Connecto;
        public string Points;
        public string FromDPoint;
        public string ToDPoint;
    }
    public partial class ConnectionPropertyFrm : DevExpress.XtraEditors.XtraForm
    {
        public string ReceiveFkType = string.Empty;
        public string location = string.Empty;
        public string RCConnector = string.Empty;
        public string RCCordinate = string.Empty;
        public ConcurrentDictionary<string, DPoint> ReceiveConValue
        {
            get;
            set;
        }
        private ConcurrentDictionary<int, string> _propertyKey
        {
            get;
            set;
        }
        public ConnectionPropertyFrm()
        {
            InitializeComponent();
            //this.Text = "Connection Property Details..";
        }

        private void ConnectionPropertyFrm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalDeclaration.HideTabCtrlPagesHeader(TbConnection);
                HideConnectionPagesHeader();
                UpdateTextPosition();
                List<Control> allControls = GetAllControls(this);
                allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 10));
                Security();
            }
            catch(Exception ex)
            {

            }
            // cmbServiceCnn.Items.Add("Add New Connection");
        }
        private void Security()
        {
            if (!GlobalDeclaration._holdInfo[0].UserRole.Equals("Admin") && !GlobalDeclaration._holdInfo[0].UserRole.Equals("U0-User"))//||GlobalDeclaration._holdInfo[0].UserRole.Trim()!=("U0-User").Trim()
            {
                cmbType.Enabled = false;
                ////numshortcircute.ReadOnly = true;
                cmbBusUnit2.Enabled = false;
                cmbType.Enabled = false;
                ////txtbuscontct.ReadOnly = true;
                ////txtMOC.ReadOnly = true;
                numcapacity.Enabled = false;
                //numcapacity.ReadOnly = true;
                ////txtbusmeterial.ReadOnly = true;
                ////txtstandrd.ReadOnly = true;
                ////txtansi.ReadOnly = true;
                ////txtFluid.ReadOnly = true;
                cmbServiceCnn.Enabled = false;
                cmbvoltage.Enabled = false;
                ////numvoltage.ReadOnly = true;
                ////numcablesize.ReadOnly = true;
                ////numcore.ReadOnly = true;
                ////numratimg.ReadOnly = true;
                ////txtHaz.ReadOnly = true;
                ////TemFluid.ReadOnly = true;
                ////txtmeterial.ReadOnly = true;
                CmpPipeSize.Enabled = false;
                ////numpipe.ReadOnly = true;
                cmbwrkPressure.Enabled = false;
                ////txtrating.ReadOnly = true;
                cmbmaxtemp.Enabled = false;
                ////nummaxtemp.ReadOnly = true;
                ////nummaxpr.ReadOnly = true;
                ////numpipeclass.ReadOnly = true;
                ////numschedule.ReadOnly = true;
                cmbCoupling.Enabled = false;
                cmbTorqueUnits.Enabled = false;
                cmbSizeUnits.Enabled = false;
                ////txtCoupLocation.ReadOnly = true;
                ////txtCouplinConctFrm.ReadOnly = true;
                ////txtCoupCnnTo.ReadOnly = true;
                //txtSizeCoupling.ReadOnly = true;
                //txttorquelimit.ReadOnly = true;
            }
        }
        public void UpdateStrcu(Connector _Coon)
        {
            if (ReceiveFkType == "Pipe")
            {
                txtMachineName.Text = _Coon.FromData.Split('~')[0];
                txtConnectToPipe.Text = _Coon.Connecto.Split('~')[0];
                txtMachineName.Enabled = false;
                txtConnectToPipe.Enabled= false;
            }
            else if (ReceiveFkType == "Bus Bar")
            {
                txtConntToBus.Text = _Coon.Connecto.Split('~')[0];
                TxtFrmDataBus.Text = _Coon.FromData.Split('~')[0];
                txtConntToBus.Enabled = false;
                TxtFrmDataBus.Enabled = false;
            }
            else if (ReceiveFkType == "Electrical Cable")
            {
                txtCableMachine.Text = _Coon.FromData.Split('~')[0];
                txtConnectToCable.Text = _Coon.Connecto.Split('~')[0];
                txtCableMachine.Enabled = false;
                txtConnectToCable.Enabled = false;
            }
            else if (ReceiveFkType == "Coupling")
            {
                txtCouplinConctFrm.Text = _Coon.FromData.Split('~')[0];
                txtCoupCnnTo.Text = _Coon.Connecto.Split('~')[0];
                txtCouplinConctFrm.Enabled = false;
                txtCoupCnnTo.Enabled = false;   
            }
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 3) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 3);
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
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }
            return list;
        }
        public void UpdateTabPage()//string tabvalue, ConcurrentDictionary<int, string> keyValues)
        {
            //ReceiveFkType = tabvalue;
            //DisplayMachineName();
            switch (ReceiveFkType)
            {
                case "Electrical Cable":
                    TbConnection.SelectedIndex = 1;                  
                    TbConnection.TabPages[0].Visible = false;
                    TbConnection.TabPages[2].Visible = false;
                    TbConnection.TabPages[3].Visible = false;
                    PipeConnection.Visible = false;
                    BusConnection.Visible = false;
                    CouplingConnection.Visible = false;
                   CableConnection.BackColor= Color.DodgerBlue;
                    CableConnection.ForeColor = Color.White;
                    FetchCableData();
                   
                    break;
                case "Bus Bar":
                    TbConnection.SelectedIndex = 2;               
                    TbConnection.TabPages[0].Visible = false;
                    TbConnection.TabPages[1].Visible = false;
                    TbConnection.TabPages[3].Visible = false;
                    PipeConnection.Visible = false;
                    CableConnection.Visible = false;
                    CouplingConnection.Visible = false;
                    BusConnection.BackColor = Color.SeaGreen;
                    BusConnection.ForeColor = Color.White;  
                    FetchBusData();
                    break;
                case "Pipe":
                    TbConnection.SelectedIndex = 0;         
                    TbConnection.TabPages[1].Visible = false;
                    TbConnection.TabPages[2].Visible = false;
                    TbConnection.TabPages[3].Visible = false;
                    CableConnection.Visible = false;
                    BusConnection.Visible = false;
                    CouplingConnection.Visible = false;
                    PipeConnection.BackColor = Color.IndianRed;
                    PipeConnection.ForeColor = Color.White;
                    GetServiceConnection("Pipe");
                    FetPipeData();
                    break;
                case "Coupling":
                    TbConnection.SelectedIndex = 3;               
                    TbConnection.TabPages[0].Visible = false;
                    TbConnection.TabPages[1].Visible = false;
                    TbConnection.TabPages[2].Visible = false;
                    PipeConnection.Visible = false;
                    CableConnection.Visible = false;
                    BusConnection.Visible = false;
                    CouplingConnection.BackColor = Color.Purple;
                    CouplingConnection.ForeColor = Color.White;
                    GetServiceConnection("Coupling");
                    FetchCouplingConnection();
                    break;
            }
            //  this._propertyKey = keyValues;

        }
        //private void DisplayMachineName()
        //{
        //    try
        //    {
        //        foreach (KeyValuePair<string, DPoint> entry in ReceiveConValue)
        //        {
        //            string MachineName = entry.Key;
        //            DPoint dPoint = entry.Value;
        //            if (ReceiveFkType == "Pipe")
        //            {
        //                txtMachineName.Text = MachineName;
        //            }
        //            else if (ReceiveFkType == "Bus Bar")
        //            {
        //                TxtFrmDataBus.Text = MachineName;
        //            }
        //            else if (ReceiveFkType == "Electrical Cable")
        //            {
        //                txtCableMachine.Text = MachineName;
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //int F_key = _propertyKey.FirstOrDefault(X => X.Value == ReceiveFkType).Key;
            InsertConnectorData(this.TbConnection.SelectedTab.Name);
            // this.Close();
            //  DialogResult = DialogResult.OK;
        }
        private void InsertConnectorData(string TabName)
        {
            if (TabName == "PipeCnn")
            {
                InsertPipeData();
            }
            else if (TabName == "CableCnn")
            {
                InsertCableData();
            }
            else if (TabName == "BusCnn")
            {
                InsertBusData();
            }
            else if (TabName == "CoupCnn")
            {
                InsertCouplingConnection();
            }
        }
        private void InsertPipeData()
        {
            string Value = string.Empty;
            if (numpipe.Text == "")
            {
                XtraMessageBox.Show("Please Fill Pipe Size Value", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (numschedule.Text == "")
            {
                XtraMessageBox.Show("Please Fill Pipe schedule Value.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (numpipeclass.Text == "")
            {
                XtraMessageBox.Show("Please Fill Pipe Class Value.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (nummaxpr.Text == "")
            {
                XtraMessageBox.Show("Please Fill Pipe MaxPressure Value.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (nummaxtemp.Text == "")
            {
                XtraMessageBox.Show("Please Fill Pipe MaxTemp Value.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nummaxtemp.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtmeterial.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of Material Of Construction.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmeterial.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtrating.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of Rating.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtrating.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtstandrd.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of Standard.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtstandrd.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtansi.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of ANSI.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtansi.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtFluid.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of FFluide.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFluid.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (TemFluid.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of TempFluide.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TemFluid.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtHaz.Text == "")
            {
                XtraMessageBox.Show("Please Enter Value Of Hazard.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHaz.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            int Status = 0;
            try
            {
                if (!string.IsNullOrEmpty(RCConnector))
                {
                    Value = txtLocation.Text + "~" + txtMachineName.Text.Replace('~', '_') + "~" + txtConnectToPipe.Text.Replace('~', '_') + "~" +
                     GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" +
                         numpipe.Text.ToString() + "~" + CmpPipeSize.SelectedItem.ToString() + "~" +
                         numschedule.Text.ToString() + "~" + numpipeclass.Text.ToString() + "~" +
                         nummaxpr.Text.ToString() + "~" + cmbwrkPressure.SelectedItem.ToString() + "~" + nummaxtemp.Text.ToString() + "~" + cmbmaxtemp.SelectedItem.ToString() + "~" +
                         txtmeterial.Text + "~" + txtrating.Text + "~" + txtstandrd.Text + "~" + txtansi.Text + "~" +
                         txtFluid.Text + "~" + cmbFPoint.SelectedItem.ToString() + "~" +
                         TemFluid.Text + "~" + cmbTemPoint.SelectedItem.ToString() + "~" + txtHaz.Text + "~" + cmbServiceCnn.Text.ToString() + "~"
                         + GlobalDeclaration._holdInfo[0].EmpCode + "~" + RCConnector + "~" + RCCordinate;
                }
                else
                {
                    Value = txtLocation.Text + "~" + txtMachineName.Text.Replace('~', '_') + "~" + txtConnectToPipe.Text.Replace('~', '_') + "~" +
                                         GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" +
                                             numpipe.Text.ToString() + "~" + CmpPipeSize.SelectedItem.ToString() + "~" +
                                             numschedule.Text.ToString() + "~" + numpipeclass.Text.ToString() + "~" +
                                             nummaxpr.Text.ToString() + "~" + cmbwrkPressure.SelectedItem.ToString() + "~" + nummaxtemp.Text.ToString() + "~" + cmbmaxtemp.SelectedItem.ToString() + "~" +
                                             txtmeterial.Text + "~" + txtrating.Text + "~" + txtstandrd.Text + "~" + txtansi.Text + "~" +
                                             txtFluid.Text + "~" + cmbFPoint.SelectedItem.ToString() + "~" +
                                             TemFluid.Text + "~" + cmbTemPoint.SelectedItem.ToString() + "~" + txtHaz.Text + "~" + cmbServiceCnn.Text.ToString() + "~"
                                             + GlobalDeclaration._holdInfo[0].EmpCode + "~" + RCConnector + "~" + RCCordinate;
                }


                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                {
                    Status = Resources.Instance.InsertData(Value, "Pipe", "Sp_InsertPipeConnection");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;

            }
            if (Status > 0)
            {
                XtraMessageBox.Show("Successfully Insert In DB.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

        }
        private void cmbServiceCnn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string objval = "Add New Connection";
            // string ComboText = DBGridView.CurrentCell.EditedFormattedValue.ToString();
            if (cmbServiceCnn.Text.Trim() == objval.Trim())
            {
                Form_Collection.AddNewServiceConn servConn = new Form_Collection.AddNewServiceConn();
                servConn.updateComboUnit += KeySafetyHandlerEvent;
                if (DialogResult == servConn.ShowDialog())
                {
                    servConn.Close();
                }
            }
        }
        private void KeySafetyHandlerEvent(object sedner, string Value)
        {
            try
            {
                if (!string.IsNullOrEmpty(Value))
                {
                    if (cmbServiceCnn.Items.Contains(Value))
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Alreday Exists..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //int lenth = cmbServiceCnn.Items.Count;
                        // cmbServiceCnn.Items.Insert(0, Value);                      
                        DataRow[] dataRows = Resources.Instance.serviceConection.Select("Description='" + Value.Split('_')[0] + "'");
                        if (dataRows.Length > 0) return;
                        DataRow dr = Resources.Instance.serviceConection.NewRow();
                        dr["Description"] = Value.Split('_')[0];
                        dr["Code"] = Value.Split('_')[1];
                        Resources.Instance.serviceConection.Rows.Add(dr);
                        if (cmbServiceCnn.Items.Count > 0)
                        {
                            cmbServiceCnn.DataSource = null;
                            cmbServiceCnn.Items.Clear();
                            cmbServiceCnn.DataSource = Resources.Instance.serviceConection.Copy();
                            cmbServiceCnn.DisplayMember = "Description";
                            cmbServiceCnn.ValueMember = "Code";
                            cmbServiceCnn.SelectedIndex = 0;
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Can not Add Blank Key.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("Can not Add Blank Key.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void FetPipeData()
        {
            DataTable _FetPipeDt = null;
            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
            {
                _FetPipeDt = Resources.Instance.GetDataKey("Sp_FetchPipeConnection", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtLocation.Text, txtMachineName.Text, "", "0", "", RCConnector, RCCordinate);
            }
            else
            {
                _FetPipeDt = Resources.Instance.GetDataKey("Sp_FetchPipeConnection", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtLocation.Text, txtMachineName.Text, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, RCConnector, RCCordinate);
            }
            if (_FetPipeDt.Rows.Count > 0)
            {
                try
                {
                    numpipe.Text = _FetPipeDt.Rows[0]["Pipesize"].ToString();
                    //numpipe.ReadOnly = true;
                    CmpPipeSize.SelectedItem = _FetPipeDt.Rows[0]["P_Unit"];
                    // CmpPipeSize.Enabled = false;

                    numschedule.Text = _FetPipeDt.Rows[0]["Schdule"].ToString();
                    // numschedule.ReadOnly = true;

                    numpipeclass.Text = _FetPipeDt.Rows[0]["PipeClass"].ToString();
                    // numpipeclass.ReadOnly = true;

                    nummaxpr.Text = _FetPipeDt.Rows[0]["MaxworKpressure"].ToString();
                    // nummaxpr.ReadOnly = true;
                    cmbwrkPressure.SelectedItem = _FetPipeDt.Rows[0]["Max_Unit"];
                    //cmbwrkPressure.Enabled = false;

                    nummaxtemp.Text = _FetPipeDt.Rows[0]["MaxTemp"].ToString();
                    // nummaxtemp.ReadOnly = true;
                    cmbmaxtemp.SelectedItem = _FetPipeDt.Rows[0]["MaxTem_Unit"];
                    //cmbmaxtemp.Enabled = false;

                    txtmeterial.Text = _FetPipeDt.Rows[0]["MaterialofConstruction"].ToString();
                    //txtmeterial.ReadOnly = true;

                    txtrating.Text = _FetPipeDt.Rows[0]["Ratings"].ToString();
                    //txtrating.ReadOnly = true;

                    txtstandrd.Text = _FetPipeDt.Rows[0]["Standard"].ToString();
                    //txtstandrd.ReadOnly = true;

                    txtansi.Text = _FetPipeDt.Rows[0]["ANSI"].ToString();
                    // txtansi.ReadOnly = true;

                    txtFluid.Text = _FetPipeDt.Rows[0]["Ffuid"].ToString();
                    //  txtFluid.ReadOnly = true;

                    TemFluid.Text = _FetPipeDt.Rows[0]["TempFluid"].ToString();
                    // TemFluid.ReadOnly = true;

                    txtHaz.Text = _FetPipeDt.Rows[0]["Hazchem"].ToString();
                    //txtHaz.ReadOnly = true;

                    cmbServiceCnn.Text = _FetPipeDt.Rows[0]["ServiceConnection"].ToString();
                    cmbFPoint.SelectedItem = _FetPipeDt.Rows[0]["F_Unit"];
                    cmbTemPoint.SelectedItem = _FetPipeDt.Rows[0]["Temp_Unit"];
                    //cmbServiceCnn.Enabled = false;
                }

                catch (Exception Ex)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                CmpPipeSize.SelectedIndex = 0;
                cmbwrkPressure.SelectedIndex = 0;
                cmbmaxtemp.SelectedIndex = 0;
                cmbFPoint.SelectedIndex = 0;
                cmbTemPoint.SelectedIndex = 0;
                //cmbServiceCnn.SelectedIndex = 0;
            }
        }
        private void InsertCableData()
        {
            try
            {
                string Value = string.Empty;
                if (numvoltage.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Voltage", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numvoltage.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbvoltage.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter Voltage Unit", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbvoltage.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (numcablesize.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Cable Size.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numcablesize.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbcable.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter Cable Unit.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbcable.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbtypeinstallation.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter Type Of Insulation.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbtypeinstallation.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (numcore.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Num Core Value", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numcore.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (numratimg.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Num Rating Value", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numratimg.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbnormalcurre.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter Noral Culture", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbnormalcurre.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (numcapacity.Text == "")
                {
                    XtraMessageBox.Show("Please Enter Capacity", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numcapacity.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbshortwishcapity.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter ShortCapacity", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbshortwishcapity.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbMaterial.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter Material Value", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMaterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbposition.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Enter Position Value", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbposition.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }                
                Value = txtCableLocation.Text.Replace('~', '_') + "~" + txtCableMachine.Text.Replace('~', '_') + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" +
                    numvoltage.Text.ToString() + "~" + cmbvoltage.SelectedItem.ToString() + "~" + numcablesize.Text.ToString() + "~" + cmbcable.SelectedItem.ToString() + "~" +
                    cmbtypeinstallation.SelectedItem.ToString() + "~" + numcore.Text.ToString() + "~" + numratimg.Text.ToString() + "~" + cmbnormalcurre.SelectedItem.ToString() + "~" +
                    numcapacity.Text.ToString() + "~" + cmbshortwishcapity.SelectedItem.ToString() + "~" + cmbMaterial.SelectedItem.ToString() + "~" + cmbposition.SelectedItem.ToString() +
                    "~" + GlobalDeclaration._holdInfo[0].EmpCode + "~" + txtConnectToCable.Text + "~" + RCConnector + "~" + RCCordinate;
                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                {
                    int Status = Resources.Instance.InsertData(Value, "Cable", "Sp_InsertCableConn");
                    if (Status > 0)
                    {
                        XtraMessageBox.Show("Successfully Insert In DB.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FetchCableData()
        {
            try
            {
                DataTable _FetCableDt = null;
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                {
                    _FetCableDt = Resources.Instance.GetDataKey("Sp_FetchCableConn", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtCableLocation.Text, txtCableMachine.Text, "", "0", "", RCConnector, RCCordinate);
                }
                else
                {
                    _FetCableDt = Resources.Instance.GetDataKey("Sp_FetchCableConn", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtCableLocation.Text, txtCableMachine.Text, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, RCConnector, RCCordinate);
                }
                if (_FetCableDt.Rows.Count > 0)
                {
                    numvoltage.Text = _FetCableDt.Rows[0]["V_Range"].ToString();
                    //numvoltage.ReadOnly = true;
                    cmbvoltage.SelectedItem = _FetCableDt.Rows[0]["V_Unit"];
                    //cmbvoltage.Enabled = false;
                    numcablesize.Text = _FetCableDt.Rows[0]["CableSize"].ToString();
                    // numcablesize.ReadOnly = true;
                    cmbcable.SelectedItem = _FetCableDt.Rows[0]["V_UnitSize"];
                    cmbtypeinstallation.SelectedItem = _FetCableDt.Rows[0]["Typesofinsulation"];
                    cmbtypeinstallation.Enabled = true;
                    numcore.Text = _FetCableDt.Rows[0]["Numberofcores"].ToString();
                    //numcore.ReadOnly = true;

                    numratimg.Text = _FetCableDt.Rows[0]["Normalcurrentrating"].ToString();
                    // numratimg.ReadOnly = true;
                    cmbnormalcurre.SelectedItem = _FetCableDt.Rows[0]["N_Unit"];

                    numcapacity.Text = _FetCableDt.Rows[0]["Shortcircuit"].ToString();
                    //numcapacity.ReadOnly = true;
                    cmbshortwishcapity.SelectedItem = _FetCableDt.Rows[0]["S_Unit"];
                    cmbshortwishcapity.Enabled = false;
                    cmbMaterial.SelectedItem = _FetCableDt.Rows[0]["Conductormaterial"];
                    cmbMaterial.Enabled = false;
                    cmbposition.SelectedItem = _FetCableDt.Rows[0]["PInstallation"];
                    cmbposition.Enabled = false;
                }
                else
                {
                    cmbvoltage.SelectedIndex = 0;
                    cmbcable.SelectedIndex = 0;
                    cmbnormalcurre.SelectedIndex = 0;
                    cmbshortwishcapity.SelectedIndex = 0;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertBusData()
        {
            try
            {
                string value = string.Empty;
                if (cmbType.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Fill Type.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbType.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (numshortcircute.Text == "")
                {
                    XtraMessageBox.Show("Please Fill Circuite Details.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numshortcircute.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbBusUnit.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Fill Units", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBusUnit.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (numshortcirtime.Text == "")
                {
                    XtraMessageBox.Show("Please Fill ShortCircuite Time", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numshortcirtime.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbBusUnit2.SelectedItem == null)
                {
                    XtraMessageBox.Show("Please Fill ShortCircuite Time Unit", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBusUnit2.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (txtbusmeterial.Text == "")
                {
                    XtraMessageBox.Show("Please Fill Meterial Details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbusmeterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (txtbuscontct.Text == "")
                {
                    XtraMessageBox.Show("Please Fill Contruct Details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbuscontct.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (txtbuslocation.Text == "")
                {
                    XtraMessageBox.Show("Please Fill Location Details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbuslocation.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                value = cmbType.SelectedItem.ToString() + "~" + numshortcircute.Text.ToString() + "~" + cmbBusUnit.SelectedItem.ToString() + "~" + numshortcirtime.Text.ToString() + "~" +
           cmbBusUnit2.SelectedItem.ToString() + "~" + txtbusmeterial.Text + "~" + txtbuscontct.Text + "~" + txtMOC.Text + "~" + txtbuslocation.Text.Replace('~', '_') + "~" + TxtFrmDataBus.Text + "~" +
           GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" +
           GlobalDeclaration._holdInfo[0].EmpCode + "~" + txtConntToBus.Text.Replace('~', '_') + "~" + RCConnector + "~" + RCCordinate;
                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                {
                    int Status = Resources.Instance.InsertData(value, "Bus", "Sp_InsertBusConn");
                    if (Status > 0)
                    {
                        XtraMessageBox.Show("Successfully Insert In DB.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchBusData()
        {
            DataTable _FetBusDt = null;
            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
            {
                _FetBusDt = Resources.Instance.GetDataKey("Sp_FetchBusConnection", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtbuslocation.Text, TxtFrmDataBus.Text, "", "0", "", RCConnector, RCCordinate);
            }
            else
            {
                _FetBusDt = Resources.Instance.GetDataKey("Sp_FetchBusConnection", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtbuslocation.Text, TxtFrmDataBus.Text, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, RCConnector, RCCordinate);
            }
            if (_FetBusDt.Rows.Count > 0)
            {
                cmbType.SelectedItem = _FetBusDt.Rows[0]["BType"];
                // cmbType.Enabled = false;
                numshortcircute.Text = _FetBusDt.Rows[0]["Shortratingcurrent"].ToString();
                // numshortcircute.ReadOnly = true;
                cmbBusUnit.SelectedItem = _FetBusDt.Rows[0]["Short_Unit"];
                // cmbBusUnit.Enabled = false;
                numshortcirtime.Text = _FetBusDt.Rows[0]["ShortcircuitTime"].ToString();
                // numshortcirtime.ReadOnly = true;
                cmbBusUnit2.SelectedItem = _FetBusDt.Rows[0]["ShortTime_Unit"];
                //cmbBusUnit2.Enabled = false;
                txtbusmeterial.Text = _FetBusDt.Rows[0]["BusBarmaterial"].ToString();
                // txtbusmeterial.ReadOnly = true;

                txtbuscontct.Text = _FetBusDt.Rows[0]["Busrating"].ToString();
                // txtbuscontct.ReadOnly = true;

                txtMOC.Text = _FetBusDt.Rows[0]["Busenclosure"].ToString();
                // txtMOC.ReadOnly = true;
            }
            else
            {
                cmbBusUnit.SelectedIndex = 0;
                cmbBusUnit.Enabled = false;
                cmbBusUnit2.SelectedIndex = 0;
                cmbBusUnit2.Enabled = false;
            }
        }
        private void FetchCouplingConnection()
        {
            try
            {
                DataTable _FetcouplingDt = null;
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
                {
                    _FetcouplingDt = Resources.Instance.GetDataKey("Sp_FetchCouplingConnection", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtCoupCnnTo.Text, txtCouplinConctFrm.Text, "", "0", "", RCConnector, RCCordinate);
                }
                else
                {
                    _FetcouplingDt = Resources.Instance.GetDataKey("Sp_FetchCouplingConnection", "p_Mlocation", "p_frmConn", "p_Uname", "p_uid", "p_empCode", "p_RC", "p_RcCord", txtCoupCnnTo.Text, txtCouplinConctFrm.Text, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, RCConnector, RCCordinate);
                }
                if (_FetcouplingDt.Rows.Count > 0)
                {
                    cmbCoupling.SelectedValue = _FetcouplingDt.Rows[0]["CouplingType"];
                    txtSizeCoupling.Text = _FetcouplingDt.Rows[0]["DiameterSize"].ToString();
                    cmbSizeUnits.SelectedItem = _FetcouplingDt.Rows[0]["DiameterUnits"].ToString();
                    txttorquelimit.Text = _FetcouplingDt.Rows[0]["torqueLimit"].ToString();
                    cmbTorqueUnits.SelectedItem = _FetcouplingDt.Rows[0]["TorqueUnits"];
                    txtCouplinConctFrm.Text = _FetcouplingDt.Rows[0]["frmConn"].ToString();
                    txtCoupCnnTo.Text = _FetcouplingDt.Rows[0]["Conntd"].ToString();
                    txtCoupCnnTo.Text = _FetcouplingDt.Rows[0]["Mlocation"].ToString();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertCouplingConnection()
        {
            try
            {
                if (cmbCoupling.SelectedItem.ToString() == "")
                {
                    XtraMessageBox.Show("Please select Coupling Type", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbusmeterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (txtSizeCoupling.Text == "")
                {
                    XtraMessageBox.Show("Please Put Size of Coupling", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbusmeterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbSizeUnits.SelectedItem.ToString() == "")
                {
                    XtraMessageBox.Show("Please Enter Units", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbusmeterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (txttorquelimit.Text == "")
                {
                    XtraMessageBox.Show("Please Put TourqueLimit", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbusmeterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbTorqueUnits.SelectedItem.ToString() == "")
                {
                    XtraMessageBox.Show("Please Enter Units", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbusmeterial.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                string value = string.Empty;
                value = cmbCoupling.SelectedValue.ToString() + "~" + txtSizeCoupling.Text.ToString() + "~" + cmbSizeUnits.SelectedItem.ToString() + "~" + txttorquelimit.Text.ToString() + "~" +
                                     cmbTorqueUnits.SelectedItem.ToString() + "~" + txtCouplinConctFrm.Text.Replace('~', '_') + "~" + txtCoupCnnTo.Text.Replace('~', '_') + "~" + txtCoupLocation.Text + "~" +
                                     GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" +
                                     GlobalDeclaration._holdInfo[0].EmpCode + "~" + RCConnector + "~" + RCCordinate;
                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                {
                    int Status = Resources.Instance.InsertData(value, "Coupling", "Sp_InsertCouplingConnection");
                    if (Status > 0)
                    {
                        XtraMessageBox.Show("Successfully Insert In DB.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideConnectionPagesHeader()
        {
            TbConnection.Appearance = TabAppearance.FlatButtons;
            TbConnection.ItemSize = new Size(0, 1);
            TbConnection.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in TbConnection.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        //public void LOadUnit(string TabName)
        //{
        //    DataTable _UnitMaster = Resources.Instance.GetDataKey("Sp_GetUnitMaster");
        //    if (_UnitMaster.Rows.Count > 0)
        //    {
        //        //cmbworkpress.DataSource = _UnitMaster;
        //        //cmbworkpress.DisplayMember = "UnitName";
        //        //cmbworkpress.ValueMember = "UnitName";
        //        //cmbworkpress.SelectedIndex = 0;


        //        if (TabName == "PipeCnn")
        //        {
        //            CmpPipeSize.DataSource = _UnitMaster;
        //            CmpPipeSize.DisplayMember = "UnitName";
        //            CmpPipeSize.ValueMember = "UnitName";
        //            CmpPipeSize.SelectedIndex = 19;

        //            cmbwrkPressure.DataSource = _UnitMaster.Copy();
        //            cmbwrkPressure.SelectedIndex = 14;
        //            cmbwrkPressure.DisplayMember = "UnitName";
        //            cmbwrkPressure.ValueMember = "UnitName";

        //            cmbmaxtemp.DataSource = _UnitMaster.Copy();
        //            cmbmaxtemp.DisplayMember = "UnitName";
        //            cmbmaxtemp.ValueMember = "UnitName";
        //            cmbmaxtemp.SelectedIndex = 15;


        //        }
        //        else if (TabName == "CableCnn")
        //        {
        //            cmbvoltage.DataSource = _UnitMaster.Copy();
        //            cmbvoltage.DisplayMember = "UnitName";
        //            cmbvoltage.ValueMember = "UnitName";
        //            cmbvoltage.SelectedIndex = 17;
        //            cmbvoltage.Enabled = true;

        //            cmbcable.DataSource = _UnitMaster.Copy();
        //            cmbcable.DisplayMember = "UnitName";
        //            cmbcable.ValueMember = "UnitName";
        //            cmbcable.SelectedIndex = 4;
        //            cmbcable.Enabled = true;

        //            cmbnormalcurre.DataSource = _UnitMaster.Copy();
        //            cmbnormalcurre.DisplayMember = "UnitName";
        //            cmbnormalcurre.ValueMember = "UnitName";
        //            cmbnormalcurre.SelectedIndex = 18;

        //            cmbshortwishcapity.DataSource = _UnitMaster.Copy();
        //            cmbshortwishcapity.DisplayMember = "UnitName";
        //            cmbshortwishcapity.ValueMember = "UnitName";
        //            cmbshortwishcapity.SelectedIndex = 17;
        //        }
        //        else if (TabName == "BusCnn")
        //        {
        //            cmbBusUnit.DataSource = _UnitMaster.Copy();
        //            cmbBusUnit.DisplayMember = "UnitName";
        //            cmbBusUnit.ValueMember = "UnitName";
        //            cmbBusUnit.SelectedIndex = 18;


        //            cmbBusUnit2.DataSource = _UnitMaster.Copy();
        //            cmbBusUnit2.DisplayMember = "UnitName";
        //            cmbBusUnit2.ValueMember = "UnitName";
        //            cmbBusUnit2.SelectedIndex = 5;
        //        }
        //    }
        //}
        private void GetServiceConnection(string CableType)
        {
            if (CableType == "Pipe")
            {
                // DataTable dt = Resources.Instance.GetConnectionType("Sp_GetServiceCode");
                if (Resources.Instance.serviceConection.Rows.Count > 0)
                {
                    cmbServiceCnn.DataSource = Resources.Instance.serviceConection.Copy();
                    cmbServiceCnn.DisplayMember = "Description";
                    cmbServiceCnn.ValueMember = "Code";
                    cmbServiceCnn.SelectedIndex = 0;
                }
            }
            else if (CableType == "Coupling")
            {
                // DataTable dt = Resources.Instance.GetConnectionType("Sp_GetCouplingType");
                if (Resources.Instance.CouplingType.Rows.Count > 0)
                {
                    cmbCoupling.DataSource = Resources.Instance.CouplingType.Copy();
                    cmbCoupling.DisplayMember = "CouplingName";
                    cmbCoupling.ValueMember = "CouplingName";
                    //cmbCoupling.SelectedIndex = 0;
                }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #region Handler Zone
        private void txtmeterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void numpipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numschedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numpipeclass_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void nummaxpr_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void nummaxtemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numvoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numcablesize_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numcore_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numratimg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numshortcircute_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void numshortcirtime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void txtbusmeterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar == '.' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            //{
            //    e.Handled = true;
            //}
        }

        private void txtrating_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar == '.' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            //{
            //    e.Handled = true;
            //}
        }

        private void txttorquelimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}
        }

        private void cmbmaxtemp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblpipeSize_Click(object sender, EventArgs e)
        {

        }

        private void PipeConnection_Click(object sender, EventArgs e)
        {
            TbConnection.SelectedIndex = 0;
        }

        private void CableConnection_Click(object sender, EventArgs e)
        {
            TbConnection.SelectedIndex = 1;
        }

        private void BusConnection_Click(object sender, EventArgs e)
        {
            TbConnection.SelectedIndex = 2;
        }

        private void CouplingConnection_Click(object sender, EventArgs e)
        {
            TbConnection.SelectedIndex = 3;
        }

        private void TbConnection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

