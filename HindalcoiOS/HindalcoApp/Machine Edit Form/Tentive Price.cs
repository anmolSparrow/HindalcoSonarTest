using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using SparrowRMS;

namespace RMPCLApp.Machine_Edit_Form
{
    public partial class Tentive_Price : DevExpress.XtraEditors.XtraForm
    {
           
         public string SysGenNo { get; set; }
        public string MachineName { get; set; }
        public string  MachineTag { get; set; }
        public Tentive_Price()
        {
            InitializeComponent();
            this.Text = "Tentative Price";
            UpdateTextPosition();
        }
        public Tentive_Price(string sysgenno,string machinename,string machinetag)
        {
            this.MachineTag = machinetag;
            this.MachineName = machinename;
            this.SysGenNo = sysgenno;
            InitializeComponent();
        }

        private void Tentive_Price_Load(object sender, EventArgs e)
        {
             LoadTentiveprice();
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 4) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 4);
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void LoadTentiveprice()
        {
            try
            {
                if (this.MachineTag != string.Empty)
                {
                    DataTable dt = null;
                    if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                    {
                         dt = Resources.Instance.GetDataKey("Sp_TentivePrice", "@sysgenno", "@machinename", "@machineTag", "@username", "@userid", this.SysGenNo, this.MachineName, this.MachineTag, "", "0");
                    }
                    else
                    {
                         dt = Resources.Instance.GetDataKey("Sp_TentivePrice", "@sysgenno", "@machinename", "@machineTag", "@username", "@userid", this.SysGenNo, this.MachineName, this.MachineTag, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString());
                    }
                   
                    if (dt.Rows.Count > 0)
                    {
                        txtmake.Text = dt.Rows[0]["Make"].ToString();
                        txtNewTechn.Text = dt.Rows[0]["Newtechnogy"].ToString();
                        txtprice.Text = dt.Rows[0]["Price"].ToString();
                        ritchtxtnotes.Text = dt.Rows[0]["Notes"].ToString();
                        txtmake.ReadOnly = true;
                        txtNewTechn.ReadOnly = true;
                       // txtprice.ReadOnly = true;
                        ritchtxtnotes.ReadOnly = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmake.Text == "")
                {
                    XtraMessageBox.Show("Make Should Not be Empty \n Please Enter Value Of Make.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmake.Focus();
                    return;
                }
                if (txtNewTechn.Text == "")
                {
                    XtraMessageBox.Show("New Technology Should Not be Empty \n Please Enter Value Of New Technology Fields.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewTechn.Focus();
                    return;
                }
                if (txtprice.Text == "")
                {
                    XtraMessageBox.Show("Price Should Not be Empty \n Please Enter Value Of Price Fields.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtprice.Focus();
                    return;
                }
                if (ritchtxtnotes.Text == "")
                {
                    XtraMessageBox.Show("Notes Fields Should Not be Empty \n Please Enter Value Of Notes Fields.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtprice.Focus();
                    return;
                }
                if(this.MachineTag==string.Empty)
                {
                    XtraMessageBox.Show("Please Enter Machine Tag First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    return;
                }
                string value = txtmake.Text + "_" + txtNewTechn.Text + "_" + txtprice.Text + "_" + ritchtxtnotes.Text + "_" + this.SysGenNo + "_" + this.MachineName + "_" + this.MachineTag+"_"+GlobalDeclaration._holdInfo[0].UserName+"_"+GlobalDeclaration._holdInfo[0].UserId;
                int Result = Resources.Instance.InsertRecord("Sp_InsertTentivePrice", value, this.Name);
                if (Result > 0)
                {
                    XtraMessageBox.Show("Details SuccessFully Save In Db.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                   // return;
                }
                else
                {
                    XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtmake_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}